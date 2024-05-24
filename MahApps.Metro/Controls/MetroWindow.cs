using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ControlzEx.Behaviors;
using ControlzEx.Native;
using ControlzEx.Standard;
using ControlzEx.Windows.Shell;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls.Dialogs;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200006B RID: 107
	[TemplatePart(Name = "PART_Icon", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_TitleBar", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_WindowTitleBackground", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_WindowTitleThumb", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_FlyoutModalDragMoveThumb", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_LeftWindowCommands", Type = typeof(WindowCommands))]
	[TemplatePart(Name = "PART_RightWindowCommands", Type = typeof(WindowCommands))]
	[TemplatePart(Name = "PART_WindowButtonCommands", Type = typeof(WindowButtonCommands))]
	[TemplatePart(Name = "PART_OverlayBox", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_MetroActiveDialogContainer", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_MetroInactiveDialogsContainer", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_FlyoutModal", Type = typeof(Rectangle))]
	public class MetroWindow : Window
	{
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x0600049F RID: 1183 RVA: 0x00011B58 File Offset: 0x0000FD58
		// (remove) Token: 0x060004A0 RID: 1184 RVA: 0x00011B66 File Offset: 0x0000FD66
		public event RoutedEventHandler FlyoutsStatusChanged
		{
			add
			{
				base.AddHandler(MetroWindow.FlyoutsStatusChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(MetroWindow.FlyoutsStatusChangedEvent, value);
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060004A1 RID: 1185 RVA: 0x00011B74 File Offset: 0x0000FD74
		// (remove) Token: 0x060004A2 RID: 1186 RVA: 0x00011B82 File Offset: 0x0000FD82
		public event RoutedEventHandler WindowTransitionCompleted
		{
			add
			{
				base.AddHandler(MetroWindow.WindowTransitionCompletedEvent, value);
			}
			remove
			{
				base.RemoveHandler(MetroWindow.WindowTransitionCompletedEvent, value);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00011B90 File Offset: 0x0000FD90
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x00011BA2 File Offset: 0x0000FDA2
		public SolidColorBrush OverrideDefaultWindowCommandsBrush
		{
			get
			{
				return (SolidColorBrush)base.GetValue(MetroWindow.OverrideDefaultWindowCommandsBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.OverrideDefaultWindowCommandsBrushProperty, value);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00011BB0 File Offset: 0x0000FDB0
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x00011BC2 File Offset: 0x0000FDC2
		public MetroDialogSettings MetroDialogOptions
		{
			get
			{
				return (MetroDialogSettings)base.GetValue(MetroWindow.MetroDialogOptionsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.MetroDialogOptionsProperty, value);
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x00011BD0 File Offset: 0x0000FDD0
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x00011BE2 File Offset: 0x0000FDE2
		[Obsolete("This property will be deleted in the next release. You should use BorderThickness=\"0\" and a GlowBrush=\"Black\" to get a drop shadow around the Window.")]
		public bool EnableDWMDropShadow
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.EnableDWMDropShadowProperty);
			}
			set
			{
				base.SetValue(MetroWindow.EnableDWMDropShadowProperty, value);
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00011BF5 File Offset: 0x0000FDF5
		private static void OnEnableDWMDropShadowPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue != e.OldValue && (bool)e.NewValue)
			{
				((MetroWindow)d).UseDropShadow();
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00011C20 File Offset: 0x0000FE20
		private void UseDropShadow()
		{
			base.SetCurrentValue(Control.BorderThicknessProperty, new Thickness(0.0));
			base.SetCurrentValue(Control.BorderBrushProperty, null);
			base.SetCurrentValue(MetroWindow.GlowBrushProperty, Brushes.Black);
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00011C5C File Offset: 0x0000FE5C
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x00011C6E File Offset: 0x0000FE6E
		public bool IsWindowDraggable
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IsWindowDraggableProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IsWindowDraggableProperty, value);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00011C81 File Offset: 0x0000FE81
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x00011C93 File Offset: 0x0000FE93
		public WindowCommandsOverlayBehavior LeftWindowCommandsOverlayBehavior
		{
			get
			{
				return (WindowCommandsOverlayBehavior)base.GetValue(MetroWindow.LeftWindowCommandsOverlayBehaviorProperty);
			}
			set
			{
				base.SetValue(MetroWindow.LeftWindowCommandsOverlayBehaviorProperty, value);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00011CA6 File Offset: 0x0000FEA6
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x00011CB8 File Offset: 0x0000FEB8
		public WindowCommandsOverlayBehavior RightWindowCommandsOverlayBehavior
		{
			get
			{
				return (WindowCommandsOverlayBehavior)base.GetValue(MetroWindow.RightWindowCommandsOverlayBehaviorProperty);
			}
			set
			{
				base.SetValue(MetroWindow.RightWindowCommandsOverlayBehaviorProperty, value);
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x00011CCB File Offset: 0x0000FECB
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x00011CDD File Offset: 0x0000FEDD
		public WindowCommandsOverlayBehavior WindowButtonCommandsOverlayBehavior
		{
			get
			{
				return (WindowCommandsOverlayBehavior)base.GetValue(MetroWindow.WindowButtonCommandsOverlayBehaviorProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowButtonCommandsOverlayBehaviorProperty, value);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x00011CF0 File Offset: 0x0000FEF0
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x00011D02 File Offset: 0x0000FF02
		public WindowCommandsOverlayBehavior IconOverlayBehavior
		{
			get
			{
				return (WindowCommandsOverlayBehavior)base.GetValue(MetroWindow.IconOverlayBehaviorProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IconOverlayBehaviorProperty, value);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060004B5 RID: 1205 RVA: 0x00011D15 File Offset: 0x0000FF15
		// (set) Token: 0x060004B6 RID: 1206 RVA: 0x00011D27 File Offset: 0x0000FF27
		[Obsolete("This property will be deleted in the next release. You should use LightMinButtonStyle or DarkMinButtonStyle in WindowButtonCommands to override the style.")]
		public Style WindowMinButtonStyle
		{
			get
			{
				return (Style)base.GetValue(MetroWindow.WindowMinButtonStyleProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowMinButtonStyleProperty, value);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00011D35 File Offset: 0x0000FF35
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00011D47 File Offset: 0x0000FF47
		[Obsolete("This property will be deleted in the next release. You should use LightMaxButtonStyle or DarkMaxButtonStyle in WindowButtonCommands to override the style.")]
		public Style WindowMaxButtonStyle
		{
			get
			{
				return (Style)base.GetValue(MetroWindow.WindowMaxButtonStyleProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowMaxButtonStyleProperty, value);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00011D55 File Offset: 0x0000FF55
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x00011D67 File Offset: 0x0000FF67
		[Obsolete("This property will be deleted in the next release. You should use LightCloseButtonStyle or DarkCloseButtonStyle in WindowButtonCommands to override the style.")]
		public Style WindowCloseButtonStyle
		{
			get
			{
				return (Style)base.GetValue(MetroWindow.WindowCloseButtonStyleProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowCloseButtonStyleProperty, value);
			}
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00011D78 File Offset: 0x0000FF78
		public static void OnWindowButtonStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue == e.OldValue)
			{
				return;
			}
			MetroWindow metroWindow = (MetroWindow)d;
			if (metroWindow.WindowButtonCommands != null)
			{
				metroWindow.WindowButtonCommands.ApplyTheme();
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x00011DB0 File Offset: 0x0000FFB0
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x00011DC2 File Offset: 0x0000FFC2
		public bool WindowTransitionsEnabled
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.WindowTransitionsEnabledProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowTransitionsEnabledProperty, value);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00011DD5 File Offset: 0x0000FFD5
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x00011DE7 File Offset: 0x0000FFE7
		public FlyoutsControl Flyouts
		{
			get
			{
				return (FlyoutsControl)base.GetValue(MetroWindow.FlyoutsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.FlyoutsProperty, value);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00011DF5 File Offset: 0x0000FFF5
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00011E07 File Offset: 0x00010007
		public DataTemplate IconTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(MetroWindow.IconTemplateProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IconTemplateProperty, value);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00011E15 File Offset: 0x00010015
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00011E27 File Offset: 0x00010027
		public DataTemplate TitleTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(MetroWindow.TitleTemplateProperty);
			}
			set
			{
				base.SetValue(MetroWindow.TitleTemplateProperty, value);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00011E35 File Offset: 0x00010035
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x00011E47 File Offset: 0x00010047
		public WindowCommands LeftWindowCommands
		{
			get
			{
				return (WindowCommands)base.GetValue(MetroWindow.LeftWindowCommandsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.LeftWindowCommandsProperty, value);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00011E55 File Offset: 0x00010055
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x00011E67 File Offset: 0x00010067
		public WindowCommands RightWindowCommands
		{
			get
			{
				return (WindowCommands)base.GetValue(MetroWindow.RightWindowCommandsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.RightWindowCommandsProperty, value);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00011E75 File Offset: 0x00010075
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x00011E87 File Offset: 0x00010087
		public WindowButtonCommands WindowButtonCommands
		{
			get
			{
				return (WindowButtonCommands)base.GetValue(MetroWindow.WindowButtonCommandsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowButtonCommandsProperty, value);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x00011E95 File Offset: 0x00010095
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x00011EA7 File Offset: 0x000100A7
		public bool IgnoreTaskbarOnMaximize
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IgnoreTaskbarOnMaximizeProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IgnoreTaskbarOnMaximizeProperty, value);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x00011EBA File Offset: 0x000100BA
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x00011ECC File Offset: 0x000100CC
		public Thickness ResizeBorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(MetroWindow.ResizeBorderThicknessProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ResizeBorderThicknessProperty, value);
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00011EDF File Offset: 0x000100DF
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x00011EF1 File Offset: 0x000100F1
		public Brush TitleForeground
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.TitleForegroundProperty);
			}
			set
			{
				base.SetValue(MetroWindow.TitleForegroundProperty, value);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00011EFF File Offset: 0x000100FF
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00011F11 File Offset: 0x00010111
		public bool SaveWindowPosition
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.SaveWindowPositionProperty);
			}
			set
			{
				base.SetValue(MetroWindow.SaveWindowPositionProperty, value);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00011F24 File Offset: 0x00010124
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00011F36 File Offset: 0x00010136
		public IWindowPlacementSettings WindowPlacementSettings
		{
			get
			{
				return (IWindowPlacementSettings)base.GetValue(MetroWindow.WindowPlacementSettingsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowPlacementSettingsProperty, value);
			}
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00011F44 File Offset: 0x00010144
		public virtual IWindowPlacementSettings GetWindowPlacementSettings()
		{
			return this.WindowPlacementSettings ?? new WindowApplicationSettings(this);
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00011F56 File Offset: 0x00010156
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x00011F68 File Offset: 0x00010168
		public bool ShowIconOnTitleBar
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowIconOnTitleBarProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowIconOnTitleBarProperty, value);
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00011F7C File Offset: 0x0001017C
		private static void OnShowIconOnTitleBarPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			MetroWindow metroWindow = (MetroWindow)d;
			if (e.NewValue != e.OldValue)
			{
				metroWindow.SetVisibiltyForIcon();
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00011FA6 File Offset: 0x000101A6
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00011FB8 File Offset: 0x000101B8
		public bool ShowDialogsOverTitleBar
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowDialogsOverTitleBarProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowDialogsOverTitleBarProperty, value);
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00011FCB File Offset: 0x000101CB
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x00011FDD File Offset: 0x000101DD
		public bool IsAnyDialogOpen
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IsAnyDialogOpenProperty);
			}
			private set
			{
				base.SetValue(MetroWindow.IsAnyDialogOpenPropertyKey, value);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x00011FF0 File Offset: 0x000101F0
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x00012002 File Offset: 0x00010202
		public EdgeMode IconEdgeMode
		{
			get
			{
				return (EdgeMode)base.GetValue(MetroWindow.IconEdgeModeProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IconEdgeModeProperty, value);
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00012015 File Offset: 0x00010215
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x00012027 File Offset: 0x00010227
		public BitmapScalingMode IconBitmapScalingMode
		{
			get
			{
				return (BitmapScalingMode)base.GetValue(MetroWindow.IconBitmapScalingModeProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IconBitmapScalingModeProperty, value);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0001203A File Offset: 0x0001023A
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0001204C File Offset: 0x0001024C
		public MultiFrameImageMode IconScalingMode
		{
			get
			{
				return (MultiFrameImageMode)base.GetValue(MetroWindow.IconScalingModeProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IconScalingModeProperty, value);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0001205F File Offset: 0x0001025F
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x00012071 File Offset: 0x00010271
		public bool ShowTitleBar
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowTitleBarProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowTitleBarProperty, value);
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00012084 File Offset: 0x00010284
		private static void OnShowTitleBarPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			MetroWindow metroWindow = (MetroWindow)d;
			if (e.NewValue != e.OldValue)
			{
				metroWindow.SetVisibiltyForAllTitleElements();
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000120AE File Offset: 0x000102AE
		private static object OnShowTitleBarCoerceValueCallback(DependencyObject d, object value)
		{
			if (((MetroWindow)d).UseNoneWindowStyle)
			{
				return false;
			}
			return value;
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x000120C5 File Offset: 0x000102C5
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x000120D7 File Offset: 0x000102D7
		public bool UseNoneWindowStyle
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.UseNoneWindowStyleProperty);
			}
			set
			{
				base.SetValue(MetroWindow.UseNoneWindowStyleProperty, value);
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000120EA File Offset: 0x000102EA
		private static void OnUseNoneWindowStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue != e.OldValue && (bool)e.NewValue)
			{
				((MetroWindow)d).SetCurrentValue(MetroWindow.ShowTitleBarProperty, false);
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x00012120 File Offset: 0x00010320
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x00012132 File Offset: 0x00010332
		public bool ShowMinButton
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowMinButtonProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowMinButtonProperty, value);
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00012145 File Offset: 0x00010345
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x00012157 File Offset: 0x00010357
		public bool ShowMaxRestoreButton
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowMaxRestoreButtonProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowMaxRestoreButtonProperty, value);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0001216A File Offset: 0x0001036A
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0001217C File Offset: 0x0001037C
		public bool ShowCloseButton
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowCloseButtonProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowCloseButtonProperty, value);
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0001218F File Offset: 0x0001038F
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x000121A1 File Offset: 0x000103A1
		public bool IsMinButtonEnabled
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IsMinButtonEnabledProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IsMinButtonEnabledProperty, value);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x000121B4 File Offset: 0x000103B4
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x000121C6 File Offset: 0x000103C6
		public bool IsMaxRestoreButtonEnabled
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IsMaxRestoreButtonEnabledProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IsMaxRestoreButtonEnabledProperty, value);
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x000121D9 File Offset: 0x000103D9
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x000121EB File Offset: 0x000103EB
		public bool IsCloseButtonEnabled
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IsCloseButtonEnabledProperty);
			}
			set
			{
				base.SetValue(MetroWindow.IsCloseButtonEnabledProperty, value);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x000121FE File Offset: 0x000103FE
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x00012210 File Offset: 0x00010410
		public bool IsCloseButtonEnabledWithDialog
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.IsCloseButtonEnabledWithDialogProperty);
			}
			private set
			{
				base.SetValue(MetroWindow.IsCloseButtonEnabledWithDialogPropertyKey, value);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x00012223 File Offset: 0x00010423
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x00012235 File Offset: 0x00010435
		public bool ShowSystemMenuOnRightClick
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.ShowSystemMenuOnRightClickProperty);
			}
			set
			{
				base.SetValue(MetroWindow.ShowSystemMenuOnRightClickProperty, value);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x00012248 File Offset: 0x00010448
		// (set) Token: 0x060004FA RID: 1274 RVA: 0x0001225A File Offset: 0x0001045A
		public int TitlebarHeight
		{
			get
			{
				return (int)base.GetValue(MetroWindow.TitlebarHeightProperty);
			}
			set
			{
				base.SetValue(MetroWindow.TitlebarHeightProperty, value);
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00012270 File Offset: 0x00010470
		private static void TitlebarHeightPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			MetroWindow metroWindow = (MetroWindow)dependencyObject;
			if (e.NewValue != e.OldValue)
			{
				metroWindow.SetVisibiltyForAllTitleElements();
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0001229C File Offset: 0x0001049C
		private void SetVisibiltyForIcon()
		{
			if (this.icon != null)
			{
				Visibility visibility = ((this.IconOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.HiddenTitleBar) && !this.ShowTitleBar) || (this.ShowIconOnTitleBar && this.ShowTitleBar)) ? Visibility.Visible : Visibility.Collapsed;
				this.icon.Visibility = visibility;
			}
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x000122F8 File Offset: 0x000104F8
		private void SetVisibiltyForAllTitleElements()
		{
			this.SetVisibiltyForIcon();
			Visibility visibility = (this.TitlebarHeight > 0 && this.ShowTitleBar && !this.UseNoneWindowStyle) ? Visibility.Visible : Visibility.Collapsed;
			UIElement uielement = this.titleBar;
			if (uielement != null)
			{
				uielement.SetCurrentValue(UIElement.VisibilityProperty, visibility);
			}
			UIElement uielement2 = this.titleBarBackground;
			if (uielement2 != null)
			{
				uielement2.SetCurrentValue(UIElement.VisibilityProperty, visibility);
			}
			Visibility visibility2 = (this.LeftWindowCommandsOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.HiddenTitleBar) && !this.UseNoneWindowStyle) ? Visibility.Visible : visibility;
			ContentPresenter leftWindowCommandsPresenter = this.LeftWindowCommandsPresenter;
			if (leftWindowCommandsPresenter != null)
			{
				leftWindowCommandsPresenter.SetCurrentValue(UIElement.VisibilityProperty, visibility2);
			}
			Visibility visibility3 = (this.RightWindowCommandsOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.HiddenTitleBar) && !this.UseNoneWindowStyle) ? Visibility.Visible : visibility;
			ContentPresenter rightWindowCommandsPresenter = this.RightWindowCommandsPresenter;
			if (rightWindowCommandsPresenter != null)
			{
				rightWindowCommandsPresenter.SetCurrentValue(UIElement.VisibilityProperty, visibility3);
			}
			Visibility visibility4 = this.WindowButtonCommandsOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.HiddenTitleBar) ? Visibility.Visible : visibility;
			ContentPresenter windowButtonCommandsPresenter = this.WindowButtonCommandsPresenter;
			if (windowButtonCommandsPresenter != null)
			{
				windowButtonCommandsPresenter.SetCurrentValue(UIElement.VisibilityProperty, visibility4);
			}
			this.SetWindowEvents();
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x00012422 File Offset: 0x00010622
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x00012434 File Offset: 0x00010634
		[Obsolete("This property will be deleted in the next release. You should use the new TitleCharacterCasing dependency property.")]
		public bool TitleCaps
		{
			get
			{
				return (bool)base.GetValue(MetroWindow.TitleCapsProperty);
			}
			set
			{
				base.SetValue(MetroWindow.TitleCapsProperty, value);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00012447 File Offset: 0x00010647
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x00012459 File Offset: 0x00010659
		public CharacterCasing TitleCharacterCasing
		{
			get
			{
				return (CharacterCasing)base.GetValue(MetroWindow.TitleCharacterCasingProperty);
			}
			set
			{
				base.SetValue(MetroWindow.TitleCharacterCasingProperty, value);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001246C File Offset: 0x0001066C
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x0001247E File Offset: 0x0001067E
		public HorizontalAlignment TitleAlignment
		{
			get
			{
				return (HorizontalAlignment)base.GetValue(MetroWindow.TitleAlignmentProperty);
			}
			set
			{
				base.SetValue(MetroWindow.TitleAlignmentProperty, value);
			}
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00012494 File Offset: 0x00010694
		private static void OnTitleAlignmentChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			MetroWindow metroWindow = dependencyObject as MetroWindow;
			if (metroWindow != null)
			{
				metroWindow.SizeChanged -= new SizeChangedEventHandler(metroWindow.MetroWindow_SizeChanged);
				if (e.NewValue is HorizontalAlignment && (HorizontalAlignment)e.NewValue == HorizontalAlignment.Center)
				{
					metroWindow.SizeChanged += new SizeChangedEventHandler(metroWindow.MetroWindow_SizeChanged);
				}
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x000124EC File Offset: 0x000106EC
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x000124FE File Offset: 0x000106FE
		public Brush WindowTitleBrush
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.WindowTitleBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.WindowTitleBrushProperty, value);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0001250C File Offset: 0x0001070C
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x0001251E File Offset: 0x0001071E
		public Brush GlowBrush
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.GlowBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.GlowBrushProperty, value);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0001252C File Offset: 0x0001072C
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x0001253E File Offset: 0x0001073E
		public Brush NonActiveGlowBrush
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.NonActiveGlowBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.NonActiveGlowBrushProperty, value);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0001254C File Offset: 0x0001074C
		// (set) Token: 0x0600050C RID: 1292 RVA: 0x0001255E File Offset: 0x0001075E
		public Brush NonActiveBorderBrush
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.NonActiveBorderBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.NonActiveBorderBrushProperty, value);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x0001256C File Offset: 0x0001076C
		// (set) Token: 0x0600050E RID: 1294 RVA: 0x0001257E File Offset: 0x0001077E
		public Brush NonActiveWindowTitleBrush
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.NonActiveWindowTitleBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.NonActiveWindowTitleBrushProperty, value);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x0001258C File Offset: 0x0001078C
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0001259E File Offset: 0x0001079E
		public Brush OverlayBrush
		{
			get
			{
				return (Brush)base.GetValue(MetroWindow.OverlayBrushProperty);
			}
			set
			{
				base.SetValue(MetroWindow.OverlayBrushProperty, value);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x000125AC File Offset: 0x000107AC
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x000125BE File Offset: 0x000107BE
		public double OverlayOpacity
		{
			get
			{
				return (double)base.GetValue(MetroWindow.OverlayOpacityProperty);
			}
			set
			{
				base.SetValue(MetroWindow.OverlayOpacityProperty, value);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x000125D1 File Offset: 0x000107D1
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x000125E3 File Offset: 0x000107E3
		public Storyboard OverlayFadeIn
		{
			get
			{
				return (Storyboard)base.GetValue(MetroWindow.OverlayFadeInProperty);
			}
			set
			{
				base.SetValue(MetroWindow.OverlayFadeInProperty, value);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x000125F1 File Offset: 0x000107F1
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x00012603 File Offset: 0x00010803
		public Storyboard OverlayFadeOut
		{
			get
			{
				return (Storyboard)base.GetValue(MetroWindow.OverlayFadeOutProperty);
			}
			set
			{
				base.SetValue(MetroWindow.OverlayFadeOutProperty, value);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x00012611 File Offset: 0x00010811
		[Obsolete("This property will be deleted in the next release.")]
		public string WindowTitle
		{
			get
			{
				if (!this.TitleCaps)
				{
					return base.Title;
				}
				return base.Title.ToUpper();
			}
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00012630 File Offset: 0x00010830
		private bool CanUseOverlayFadingStoryboard(Storyboard sb, out DoubleAnimation animation)
		{
			animation = null;
			if (sb == null)
			{
				return false;
			}
			sb.Dispatcher.VerifyAccess();
			animation = sb.Children.OfType<DoubleAnimation>().FirstOrDefault<DoubleAnimation>();
			return animation != null && ((sb.Duration.HasTimeSpan && sb.Duration.TimeSpan.Ticks > 0L) || sb.AccelerationRatio > 0.0 || sb.DecelerationRatio > 0.0 || (animation.Duration.HasTimeSpan && animation.Duration.TimeSpan.Ticks > 0L) || animation.AccelerationRatio > 0.0 || animation.DecelerationRatio > 0.0);
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00012708 File Offset: 0x00010908
		public Task ShowOverlayAsync()
		{
			MetroWindow.<>c__DisplayClass260_0 CS$<>8__locals1 = new MetroWindow.<>c__DisplayClass260_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.overlayBox == null)
			{
				throw new InvalidOperationException("OverlayBox can not be founded in this MetroWindow's template. Are you calling this before the window has loaded?");
			}
			CS$<>8__locals1.tcs = new TaskCompletionSource<object>();
			if (this.IsOverlayVisible() && this.overlayStoryboard == null)
			{
				CS$<>8__locals1.tcs.SetResult(null);
				return CS$<>8__locals1.tcs.Task;
			}
			base.Dispatcher.VerifyAccess();
			MetroWindow.<>c__DisplayClass260_0 CS$<>8__locals2 = CS$<>8__locals1;
			Storyboard overlayFadeIn = this.OverlayFadeIn;
			CS$<>8__locals2.sb = ((overlayFadeIn != null) ? overlayFadeIn.Clone() : null);
			this.overlayStoryboard = CS$<>8__locals1.sb;
			DoubleAnimation doubleAnimation;
			if (this.CanUseOverlayFadingStoryboard(CS$<>8__locals1.sb, out doubleAnimation))
			{
				this.overlayBox.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Visible);
				doubleAnimation.To = new double?(this.OverlayOpacity);
				EventHandler completionHandler = null;
				completionHandler = delegate(object sender, EventArgs args)
				{
					CS$<>8__locals1.sb.Completed -= completionHandler;
					if (CS$<>8__locals1.<>4__this.overlayStoryboard == CS$<>8__locals1.sb)
					{
						CS$<>8__locals1.<>4__this.overlayStoryboard = null;
					}
					CS$<>8__locals1.tcs.TrySetResult(null);
				};
				CS$<>8__locals1.sb.Completed += completionHandler;
				this.overlayBox.BeginStoryboard(CS$<>8__locals1.sb);
			}
			else
			{
				this.ShowOverlay();
				CS$<>8__locals1.tcs.TrySetResult(null);
			}
			return CS$<>8__locals1.tcs.Task;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00012840 File Offset: 0x00010A40
		public Task HideOverlayAsync()
		{
			MetroWindow.<>c__DisplayClass261_0 CS$<>8__locals1 = new MetroWindow.<>c__DisplayClass261_0();
			CS$<>8__locals1.<>4__this = this;
			if (this.overlayBox == null)
			{
				throw new InvalidOperationException("OverlayBox can not be founded in this MetroWindow's template. Are you calling this before the window has loaded?");
			}
			CS$<>8__locals1.tcs = new TaskCompletionSource<object>();
			if (this.overlayBox.Visibility == Visibility.Visible && this.overlayBox.Opacity <= 0.0)
			{
				this.overlayBox.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Hidden);
				CS$<>8__locals1.tcs.SetResult(null);
				return CS$<>8__locals1.tcs.Task;
			}
			base.Dispatcher.VerifyAccess();
			MetroWindow.<>c__DisplayClass261_0 CS$<>8__locals2 = CS$<>8__locals1;
			Storyboard overlayFadeOut = this.OverlayFadeOut;
			CS$<>8__locals2.sb = ((overlayFadeOut != null) ? overlayFadeOut.Clone() : null);
			this.overlayStoryboard = CS$<>8__locals1.sb;
			DoubleAnimation doubleAnimation;
			if (this.CanUseOverlayFadingStoryboard(CS$<>8__locals1.sb, out doubleAnimation))
			{
				doubleAnimation.To = new double?(0.0);
				EventHandler completionHandler = null;
				completionHandler = delegate(object sender, EventArgs args)
				{
					CS$<>8__locals1.sb.Completed -= completionHandler;
					if (CS$<>8__locals1.<>4__this.overlayStoryboard == CS$<>8__locals1.sb)
					{
						CS$<>8__locals1.<>4__this.overlayBox.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Hidden);
						CS$<>8__locals1.<>4__this.overlayStoryboard = null;
					}
					CS$<>8__locals1.tcs.TrySetResult(null);
				};
				CS$<>8__locals1.sb.Completed += completionHandler;
				this.overlayBox.BeginStoryboard(CS$<>8__locals1.sb);
			}
			else
			{
				this.HideOverlay();
				CS$<>8__locals1.tcs.TrySetResult(null);
			}
			return CS$<>8__locals1.tcs.Task;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001298E File Offset: 0x00010B8E
		public bool IsOverlayVisible()
		{
			if (this.overlayBox == null)
			{
				throw new InvalidOperationException("OverlayBox can not be founded in this MetroWindow's template. Are you calling this before the window has loaded?");
			}
			return this.overlayBox.Visibility == Visibility.Visible && this.overlayBox.Opacity >= this.OverlayOpacity;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x000129C8 File Offset: 0x00010BC8
		public void ShowOverlay()
		{
			this.overlayBox.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Visible);
			this.overlayBox.SetCurrentValue(UIElement.OpacityProperty, this.OverlayOpacity);
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000129FB File Offset: 0x00010BFB
		public void HideOverlay()
		{
			this.overlayBox.SetCurrentValue(UIElement.OpacityProperty, 0.0);
			this.overlayBox.SetCurrentValue(UIElement.VisibilityProperty, Visibility.Hidden);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00012A34 File Offset: 0x00010C34
		public void StoreFocus(IInputElement thisElement = null)
		{
			base.Dispatcher.BeginInvoke(new Action(delegate()
			{
				MetroWindow <>4__this = this;
				IInputElement inputElement;
				if ((inputElement = thisElement) == null)
				{
					inputElement = (this.restoreFocus ?? FocusManager.GetFocusedElement(this));
				}
				<>4__this.restoreFocus = inputElement;
			}), Array.Empty<object>());
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00012A72 File Offset: 0x00010C72
		internal void RestoreFocus()
		{
			if (this.restoreFocus != null)
			{
				base.Dispatcher.BeginInvoke(new Action(delegate()
				{
					Keyboard.Focus(this.restoreFocus);
					this.restoreFocus = null;
				}), Array.Empty<object>());
			}
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00012A99 File Offset: 0x00010C99
		public void ResetStoredFocus()
		{
			this.restoreFocus = null;
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00012AA4 File Offset: 0x00010CA4
		static MetroWindow()
		{
			MetroWindow.FlyoutsStatusChangedEvent = EventManager.RegisterRoutedEvent("FlyoutsStatusChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MetroWindow));
			MetroWindow.WindowTransitionCompletedEvent = EventManager.RegisterRoutedEvent("WindowTransitionCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MetroWindow));
			MetroWindow.ResizeBorderThicknessProperty = DependencyProperty.Register("ResizeBorderThickness", typeof(Thickness), typeof(MetroWindow), new PropertyMetadata(WindowChromeBehavior.GetDefaultResizeBorderThickness()));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(typeof(MetroWindow)));
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00013534 File Offset: 0x00011734
		public MetroWindow()
		{
			this.MetroDialogOptions = new MetroDialogSettings();
			base.DataContextChanged += this.MetroWindow_DataContextChanged;
			base.Loaded += this.MetroWindow_Loaded;
			this.InitializeStylizedBehaviors();
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00013574 File Offset: 0x00011774
		private void InitializeStylizedBehaviors()
		{
			StylizedBehaviorCollection value = new StylizedBehaviorCollection
			{
				new BorderlessWindowBehavior(),
				new WindowsSettingBehaviour(),
				new GlowWindowBehavior()
			};
			StylizedBehaviors.SetBehaviors(this, value);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x000135B0 File Offset: 0x000117B0
		protected override async void OnClosing(CancelEventArgs e)
		{
			if (!e.Cancel)
			{
				BaseMetroDialog baseMetroDialog = await this.GetCurrentDialogAsync<BaseMetroDialog>();
				e.Cancel = (baseMetroDialog != null && (this.ShowDialogsOverTitleBar || baseMetroDialog.DialogSettings == null || !baseMetroDialog.DialogSettings.OwnerCanCloseWithDialog));
			}
			base.OnClosing(e);
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x000135F4 File Offset: 0x000117F4
		private void MetroWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.LeftWindowCommands != null)
			{
				this.LeftWindowCommands.DataContext = base.DataContext;
			}
			if (this.RightWindowCommands != null)
			{
				this.RightWindowCommands.DataContext = base.DataContext;
			}
			if (this.WindowButtonCommands != null)
			{
				this.WindowButtonCommands.DataContext = base.DataContext;
			}
			if (this.Flyouts != null)
			{
				this.Flyouts.DataContext = base.DataContext;
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00013668 File Offset: 0x00011868
		private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.EnableDWMDropShadow)
			{
				this.UseDropShadow();
			}
			if (this.WindowTransitionsEnabled)
			{
				VisualStateManager.GoToState(this, "AfterLoaded", true);
			}
			if (this.Flyouts == null)
			{
				this.Flyouts = new FlyoutsControl();
			}
			this.ResetAllWindowCommandsBrush();
			ThemeManager.IsThemeChanged += this.ThemeManagerOnIsThemeChanged;
			base.Unloaded += delegate(object o, RoutedEventArgs args)
			{
				ThemeManager.IsThemeChanged -= this.ThemeManagerOnIsThemeChanged;
			};
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000136D4 File Offset: 0x000118D4
		private void MetroWindow_SizeChanged(object sender, RoutedEventArgs e)
		{
			if (this.TitleAlignment != HorizontalAlignment.Center)
			{
				return;
			}
			double num = base.ActualWidth / 2.0;
			double num2 = this.titleBar.DesiredSize.Width / 2.0;
			double num3 = this.icon.ActualWidth + this.LeftWindowCommands.ActualWidth;
			double num4 = this.WindowButtonCommands.ActualWidth + this.RightWindowCommands.ActualWidth;
			double num5 = num3 + num2 + 5.0;
			double num6 = num4 + num2 + 5.0;
			if (num5 < num && num6 < num)
			{
				Grid.SetColumn(this.titleBar, 0);
				Grid.SetColumnSpan(this.titleBar, 7);
				return;
			}
			Grid.SetColumn(this.titleBar, 3);
			Grid.SetColumnSpan(this.titleBar, 1);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001379C File Offset: 0x0001199C
		private void ThemeManagerOnIsThemeChanged(object sender, OnThemeChangedEventArgs e)
		{
			if (e.Accent != null)
			{
				List<Flyout> list = this.Flyouts.GetFlyouts().ToList<Flyout>();
				List<FlyoutsControl> source = (base.Content as DependencyObject).FindChildren(true).ToList<FlyoutsControl>();
				if (source.Any<FlyoutsControl>())
				{
					list.AddRange(source.SelectMany((FlyoutsControl flyoutsControl) => flyoutsControl.GetFlyouts()));
				}
				if (!list.Any<Flyout>())
				{
					this.ResetAllWindowCommandsBrush();
					return;
				}
				foreach (Flyout flyout in list)
				{
					flyout.ChangeFlyoutTheme(e.Accent, e.AppTheme);
				}
				this.HandleWindowCommandsForFlyouts(list, null);
			}
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00013870 File Offset: 0x00011A70
		private void FlyoutsPreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			DependencyObject dependencyObject = e.OriginalSource as DependencyObject;
			if (dependencyObject != null && (dependencyObject.TryFindParent<Flyout>() != null || object.Equals(dependencyObject, this.overlayBox) || dependencyObject.TryFindParent<BaseMetroDialog>() != null || object.Equals(dependencyObject.TryFindParent<ContentControl>(), this.icon) || dependencyObject.TryFindParent<WindowCommands>() != null || dependencyObject.TryFindParent<WindowButtonCommands>() != null))
			{
				return;
			}
			if (this.Flyouts.OverrideExternalCloseButton == null)
			{
				IEnumerable<Flyout> flyouts = this.Flyouts.GetFlyouts();
				Func<Flyout, bool> <>9__0;
				Func<Flyout, bool> predicate;
				if ((predicate = <>9__0) == null)
				{
					predicate = (<>9__0 = ((Flyout x) => x.IsOpen && x.ExternalCloseButton == e.ChangedButton && (!x.IsPinned || this.Flyouts.OverrideIsPinned)));
				}
				using (IEnumerator<Flyout> enumerator = flyouts.Where(predicate).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Flyout flyout = enumerator.Current;
						flyout.IsOpen = false;
					}
					return;
				}
			}
			if (this.Flyouts.OverrideExternalCloseButton == e.ChangedButton)
			{
				IEnumerable<Flyout> flyouts2 = this.Flyouts.GetFlyouts();
				Func<Flyout, bool> <>9__1;
				Func<Flyout, bool> predicate2;
				if ((predicate2 = <>9__1) == null)
				{
					predicate2 = (<>9__1 = ((Flyout x) => x.IsOpen && (!x.IsPinned || this.Flyouts.OverrideIsPinned)));
				}
				foreach (Flyout flyout2 in flyouts2.Where(predicate2))
				{
					flyout2.IsOpen = false;
				}
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00013A00 File Offset: 0x00011C00
		private static void UpdateLogicalChilds(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			MetroWindow metroWindow = dependencyObject as MetroWindow;
			if (metroWindow == null)
			{
				return;
			}
			FrameworkElement frameworkElement = e.OldValue as FrameworkElement;
			if (frameworkElement != null)
			{
				metroWindow.RemoveLogicalChild(frameworkElement);
			}
			FrameworkElement frameworkElement2 = e.NewValue as FrameworkElement;
			if (frameworkElement2 != null)
			{
				metroWindow.AddLogicalChild(frameworkElement2);
				frameworkElement2.DataContext = metroWindow.DataContext;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x00013A54 File Offset: 0x00011C54
		protected override IEnumerator LogicalChildren
		{
			get
			{
				ArrayList arrayList = new ArrayList
				{
					base.Content
				};
				if (this.LeftWindowCommands != null)
				{
					arrayList.Add(this.LeftWindowCommands);
				}
				if (this.RightWindowCommands != null)
				{
					arrayList.Add(this.RightWindowCommands);
				}
				if (this.WindowButtonCommands != null)
				{
					arrayList.Add(this.WindowButtonCommands);
				}
				if (this.Flyouts != null)
				{
					arrayList.Add(this.Flyouts);
				}
				return arrayList.GetEnumerator();
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00013AD0 File Offset: 0x00011CD0
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.LeftWindowCommandsPresenter = (base.GetTemplateChild("PART_LeftWindowCommands") as ContentPresenter);
			this.RightWindowCommandsPresenter = (base.GetTemplateChild("PART_RightWindowCommands") as ContentPresenter);
			this.WindowButtonCommandsPresenter = (base.GetTemplateChild("PART_WindowButtonCommands") as ContentPresenter);
			if (this.LeftWindowCommands == null)
			{
				this.LeftWindowCommands = new WindowCommands();
			}
			if (this.RightWindowCommands == null)
			{
				this.RightWindowCommands = new WindowCommands();
			}
			if (this.WindowButtonCommands == null)
			{
				this.WindowButtonCommands = new WindowButtonCommands();
			}
			this.LeftWindowCommands.ParentWindow = this;
			this.RightWindowCommands.ParentWindow = this;
			this.WindowButtonCommands.ParentWindow = this;
			this.overlayBox = (base.GetTemplateChild("PART_OverlayBox") as Grid);
			this.metroActiveDialogContainer = (base.GetTemplateChild("PART_MetroActiveDialogContainer") as Grid);
			this.metroInactiveDialogContainer = (base.GetTemplateChild("PART_MetroInactiveDialogsContainer") as Grid);
			this.flyoutModal = (Rectangle)base.GetTemplateChild("PART_FlyoutModal");
			this.flyoutModal.PreviewMouseDown += this.FlyoutsPreviewMouseDown;
			base.PreviewMouseDown += this.FlyoutsPreviewMouseDown;
			this.icon = (base.GetTemplateChild("PART_Icon") as FrameworkElement);
			this.titleBar = (base.GetTemplateChild("PART_TitleBar") as UIElement);
			this.titleBarBackground = (base.GetTemplateChild("PART_WindowTitleBackground") as UIElement);
			this.windowTitleThumb = (base.GetTemplateChild("PART_WindowTitleThumb") as Thumb);
			this.flyoutModalDragMoveThumb = (base.GetTemplateChild("PART_FlyoutModalDragMoveThumb") as Thumb);
			this.SetVisibiltyForAllTitleElements();
			MetroContentControl metroContentControl = base.GetTemplateChild("PART_Content") as MetroContentControl;
			if (metroContentControl != null)
			{
				metroContentControl.TransitionCompleted += delegate(object sender, RoutedEventArgs args)
				{
					base.RaiseEvent(new RoutedEventArgs(MetroWindow.WindowTransitionCompletedEvent));
				};
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00013C9D File Offset: 0x00011E9D
		protected IntPtr CriticalHandle
		{
			get
			{
				return (IntPtr)typeof(Window).GetProperty("CriticalHandle", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this, new object[0]);
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00013CC8 File Offset: 0x00011EC8
		private void ClearWindowEvents()
		{
			if (this.windowTitleThumb != null)
			{
				this.windowTitleThumb.PreviewMouseLeftButtonUp -= this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				this.windowTitleThumb.DragDelta -= this.WindowTitleThumbMoveOnDragDelta;
				this.windowTitleThumb.MouseDoubleClick -= this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				this.windowTitleThumb.MouseRightButtonUp -= this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			IMetroThumb metroThumb = this.titleBar as IMetroThumb;
			if (metroThumb != null)
			{
				metroThumb.PreviewMouseLeftButtonUp -= this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				metroThumb.DragDelta -= this.WindowTitleThumbMoveOnDragDelta;
				metroThumb.MouseDoubleClick -= this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				metroThumb.MouseRightButtonUp -= this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			if (this.flyoutModalDragMoveThumb != null)
			{
				this.flyoutModalDragMoveThumb.PreviewMouseLeftButtonUp -= this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				this.flyoutModalDragMoveThumb.DragDelta -= this.WindowTitleThumbMoveOnDragDelta;
				this.flyoutModalDragMoveThumb.MouseDoubleClick -= this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				this.flyoutModalDragMoveThumb.MouseRightButtonUp -= this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			if (this.icon != null)
			{
				this.icon.MouseDown -= this.IconMouseDown;
			}
			base.SizeChanged -= new SizeChangedEventHandler(this.MetroWindow_SizeChanged);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00013E28 File Offset: 0x00012028
		private void SetWindowEvents()
		{
			this.ClearWindowEvents();
			if (this.icon != null && this.icon.Visibility == Visibility.Visible)
			{
				this.icon.MouseDown += this.IconMouseDown;
			}
			if (this.windowTitleThumb != null)
			{
				this.windowTitleThumb.PreviewMouseLeftButtonUp += this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				this.windowTitleThumb.DragDelta += this.WindowTitleThumbMoveOnDragDelta;
				this.windowTitleThumb.MouseDoubleClick += this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				this.windowTitleThumb.MouseRightButtonUp += this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			IMetroThumb metroThumb = this.titleBar as IMetroThumb;
			if (metroThumb != null)
			{
				metroThumb.PreviewMouseLeftButtonUp += this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				metroThumb.DragDelta += this.WindowTitleThumbMoveOnDragDelta;
				metroThumb.MouseDoubleClick += this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				metroThumb.MouseRightButtonUp += this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			if (this.flyoutModalDragMoveThumb != null)
			{
				this.flyoutModalDragMoveThumb.PreviewMouseLeftButtonUp += this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				this.flyoutModalDragMoveThumb.DragDelta += this.WindowTitleThumbMoveOnDragDelta;
				this.flyoutModalDragMoveThumb.MouseDoubleClick += this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				this.flyoutModalDragMoveThumb.MouseRightButtonUp += this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			if (this.titleBar != null && this.TitleAlignment == HorizontalAlignment.Center)
			{
				base.SizeChanged += new SizeChangedEventHandler(this.MetroWindow_SizeChanged);
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00013FA9 File Offset: 0x000121A9
		private void IconMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				if (e.ClickCount == 2)
				{
					base.Close();
					return;
				}
				MetroWindow.ShowSystemMenuPhysicalCoordinates(this, base.PointToScreen(new Point(0.0, (double)this.TitlebarHeight)));
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00013FE4 File Offset: 0x000121E4
		private void WindowTitleThumbOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			MetroWindow.DoWindowTitleThumbOnPreviewMouseLeftButtonUp(this, e);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00013FED File Offset: 0x000121ED
		private void WindowTitleThumbMoveOnDragDelta(object sender, DragDeltaEventArgs dragDeltaEventArgs)
		{
			MetroWindow.DoWindowTitleThumbMoveOnDragDelta(sender as IMetroThumb, this, dragDeltaEventArgs);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00013FFC File Offset: 0x000121FC
		private void WindowTitleThumbChangeWindowStateOnMouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			MetroWindow.DoWindowTitleThumbChangeWindowStateOnMouseDoubleClick(this, mouseButtonEventArgs);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00014005 File Offset: 0x00012205
		private void WindowTitleThumbSystemMenuOnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			MetroWindow.DoWindowTitleThumbSystemMenuOnMouseRightButtonUp(this, e);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0001400E File Offset: 0x0001220E
		internal static void DoWindowTitleThumbOnPreviewMouseLeftButtonUp(MetroWindow window, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (mouseButtonEventArgs.Source == mouseButtonEventArgs.OriginalSource)
			{
				Mouse.Capture(null);
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00014028 File Offset: 0x00012228
		internal static void DoWindowTitleThumbMoveOnDragDelta(IMetroThumb thumb, MetroWindow window, DragDeltaEventArgs dragDeltaEventArgs)
		{
			if (thumb == null)
			{
				throw new ArgumentNullException("thumb");
			}
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (!window.IsWindowDraggable || (Math.Abs(dragDeltaEventArgs.HorizontalChange) <= 2.0 && Math.Abs(dragDeltaEventArgs.VerticalChange) <= 2.0))
			{
				return;
			}
			window.VerifyAccess();
			bool flag = window.WindowState == WindowState.Maximized;
			if ((Mouse.GetPosition(thumb).Y > (double)window.TitlebarHeight || window.TitlebarHeight <= 0) && flag)
			{
				return;
			}
			UnsafeNativeMethods.ReleaseCapture();
			if (flag)
			{
				EventHandler windowOnStateChanged = null;
				windowOnStateChanged = delegate(object sender, EventArgs args)
				{
					window.StateChanged -= windowOnStateChanged;
					if (window.WindowState == WindowState.Normal)
					{
						Mouse.Capture(thumb, CaptureMode.Element);
					}
				};
				window.StateChanged += windowOnStateChanged;
			}
			IntPtr criticalHandle = window.CriticalHandle;
			NativeMethods.SendMessage(criticalHandle, WM.SYSCOMMAND, (IntPtr)61458, IntPtr.Zero);
			NativeMethods.SendMessage(criticalHandle, WM.LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00014180 File Offset: 0x00012380
		internal static void DoWindowTitleThumbChangeWindowStateOnMouseDoubleClick(MetroWindow window, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (mouseButtonEventArgs.ChangedButton == MouseButton.Left)
			{
				bool flag = window.ResizeMode == ResizeMode.CanResizeWithGrip || window.ResizeMode == ResizeMode.CanResize;
				bool flag2 = Mouse.GetPosition(window).Y <= (double)window.TitlebarHeight && window.TitlebarHeight > 0;
				if (flag && flag2)
				{
					if (window.WindowState == WindowState.Normal)
					{
						ControlzEx.Windows.Shell.SystemCommands.MaximizeWindow(window);
					}
					else
					{
						ControlzEx.Windows.Shell.SystemCommands.RestoreWindow(window);
					}
					mouseButtonEventArgs.Handled = true;
				}
			}
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x000141F0 File Offset: 0x000123F0
		internal static void DoWindowTitleThumbSystemMenuOnMouseRightButtonUp(MetroWindow window, MouseButtonEventArgs e)
		{
			if (window.ShowSystemMenuOnRightClick)
			{
				Point position = e.GetPosition(window);
				if ((position.Y <= (double)window.TitlebarHeight && window.TitlebarHeight > 0) || (window.UseNoneWindowStyle && window.TitlebarHeight <= 0))
				{
					MetroWindow.ShowSystemMenuPhysicalCoordinates(window, window.PointToScreen(position));
				}
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00014244 File Offset: 0x00012444
		internal T GetPart<T>(string name) where T : class
		{
			return base.GetTemplateChild(name) as T;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00014257 File Offset: 0x00012457
		internal DependencyObject GetPart(string name)
		{
			return base.GetTemplateChild(name);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00014260 File Offset: 0x00012460
		private static void ShowSystemMenuPhysicalCoordinates(Window window, Point physicalScreenLocation)
		{
			if (window == null)
			{
				return;
			}
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (handle == IntPtr.Zero || !NativeMethods.IsWindow(handle))
			{
				return;
			}
			uint num = NativeMethods.TrackPopupMenuEx(NativeMethods.GetSystemMenu(handle, false), 256U, (int)physicalScreenLocation.X, (int)physicalScreenLocation.Y, handle, IntPtr.Zero);
			if (num != 0U)
			{
				NativeMethods.PostMessage(handle, WM.SYSCOMMAND, new IntPtr((long)((ulong)num)), IntPtr.Zero);
			}
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x000142D8 File Offset: 0x000124D8
		internal void HandleFlyoutStatusChange(Flyout flyout, IList<Flyout> visibleFlyouts)
		{
			int num = flyout.IsOpen ? (Panel.GetZIndex(flyout) + 3) : (visibleFlyouts.Count<Flyout>() + 2);
			FrameworkElement frameworkElement = this.icon;
			if (frameworkElement != null)
			{
				frameworkElement.SetValue(Panel.ZIndexProperty, (flyout.IsModal && flyout.IsOpen) ? 0 : (this.IconOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.Flyouts) ? num : 1));
			}
			ContentPresenter leftWindowCommandsPresenter = this.LeftWindowCommandsPresenter;
			if (leftWindowCommandsPresenter != null)
			{
				leftWindowCommandsPresenter.SetValue(Panel.ZIndexProperty, (flyout.IsModal && flyout.IsOpen) ? 0 : (this.LeftWindowCommandsOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.Flyouts) ? num : 1));
			}
			ContentPresenter rightWindowCommandsPresenter = this.RightWindowCommandsPresenter;
			if (rightWindowCommandsPresenter != null)
			{
				rightWindowCommandsPresenter.SetValue(Panel.ZIndexProperty, (flyout.IsModal && flyout.IsOpen) ? 0 : (this.RightWindowCommandsOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.Flyouts) ? num : 1));
			}
			ContentPresenter windowButtonCommandsPresenter = this.WindowButtonCommandsPresenter;
			if (windowButtonCommandsPresenter != null)
			{
				windowButtonCommandsPresenter.SetValue(Panel.ZIndexProperty, (flyout.IsModal && flyout.IsOpen) ? 0 : (this.WindowButtonCommandsOverlayBehavior.HasFlag(WindowCommandsOverlayBehavior.Flyouts) ? num : 1));
			}
			this.HandleWindowCommandsForFlyouts(visibleFlyouts, null);
			if (this.flyoutModal != null)
			{
				this.flyoutModal.Visibility = (visibleFlyouts.Any((Flyout x) => x.IsModal) ? Visibility.Visible : Visibility.Hidden);
			}
			base.RaiseEvent(new MetroWindow.FlyoutStatusChangedRoutedEventArgs(MetroWindow.FlyoutsStatusChangedEvent, this)
			{
				ChangedFlyout = flyout
			});
		}

		// Token: 0x040001B3 RID: 435
		private const string PART_Icon = "PART_Icon";

		// Token: 0x040001B4 RID: 436
		private const string PART_TitleBar = "PART_TitleBar";

		// Token: 0x040001B5 RID: 437
		private const string PART_WindowTitleBackground = "PART_WindowTitleBackground";

		// Token: 0x040001B6 RID: 438
		private const string PART_WindowTitleThumb = "PART_WindowTitleThumb";

		// Token: 0x040001B7 RID: 439
		private const string PART_FlyoutModalDragMoveThumb = "PART_FlyoutModalDragMoveThumb";

		// Token: 0x040001B8 RID: 440
		private const string PART_LeftWindowCommands = "PART_LeftWindowCommands";

		// Token: 0x040001B9 RID: 441
		private const string PART_RightWindowCommands = "PART_RightWindowCommands";

		// Token: 0x040001BA RID: 442
		private const string PART_WindowButtonCommands = "PART_WindowButtonCommands";

		// Token: 0x040001BB RID: 443
		private const string PART_OverlayBox = "PART_OverlayBox";

		// Token: 0x040001BC RID: 444
		private const string PART_MetroActiveDialogContainer = "PART_MetroActiveDialogContainer";

		// Token: 0x040001BD RID: 445
		private const string PART_MetroInactiveDialogsContainer = "PART_MetroInactiveDialogsContainer";

		// Token: 0x040001BE RID: 446
		private const string PART_FlyoutModal = "PART_FlyoutModal";

		// Token: 0x040001BF RID: 447
		private const string PART_Content = "PART_Content";

		// Token: 0x040001C0 RID: 448
		public static readonly DependencyProperty ShowIconOnTitleBarProperty = DependencyProperty.Register("ShowIconOnTitleBar", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true, new PropertyChangedCallback(MetroWindow.OnShowIconOnTitleBarPropertyChangedCallback)));

		// Token: 0x040001C1 RID: 449
		public static readonly DependencyProperty IconEdgeModeProperty = DependencyProperty.Register("IconEdgeMode", typeof(EdgeMode), typeof(MetroWindow), new PropertyMetadata(EdgeMode.Aliased));

		// Token: 0x040001C2 RID: 450
		public static readonly DependencyProperty IconBitmapScalingModeProperty = DependencyProperty.Register("IconBitmapScalingMode", typeof(BitmapScalingMode), typeof(MetroWindow), new PropertyMetadata(BitmapScalingMode.HighQuality));

		// Token: 0x040001C3 RID: 451
		public static readonly DependencyProperty IconScalingModeProperty = DependencyProperty.Register("IconScalingMode", typeof(MultiFrameImageMode), typeof(MetroWindow), new FrameworkPropertyMetadata(MultiFrameImageMode.ScaleDownLargerFrame, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x040001C4 RID: 452
		public static readonly DependencyProperty ShowTitleBarProperty = DependencyProperty.Register("ShowTitleBar", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true, new PropertyChangedCallback(MetroWindow.OnShowTitleBarPropertyChangedCallback), new CoerceValueCallback(MetroWindow.OnShowTitleBarCoerceValueCallback)));

		// Token: 0x040001C5 RID: 453
		public static readonly DependencyProperty ShowDialogsOverTitleBarProperty = DependencyProperty.Register("ShowDialogsOverTitleBar", typeof(bool), typeof(MetroWindow), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x040001C6 RID: 454
		public static readonly DependencyPropertyKey IsAnyDialogOpenPropertyKey = DependencyProperty.RegisterReadOnly("IsAnyDialogOpen", typeof(bool), typeof(MetroWindow), new PropertyMetadata(false));

		// Token: 0x040001C7 RID: 455
		public static readonly DependencyProperty IsAnyDialogOpenProperty = MetroWindow.IsAnyDialogOpenPropertyKey.DependencyProperty;

		// Token: 0x040001C8 RID: 456
		public static readonly DependencyProperty ShowMinButtonProperty = DependencyProperty.Register("ShowMinButton", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001C9 RID: 457
		public static readonly DependencyProperty ShowMaxRestoreButtonProperty = DependencyProperty.Register("ShowMaxRestoreButton", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001CA RID: 458
		public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001CB RID: 459
		public static readonly DependencyProperty IsMinButtonEnabledProperty = DependencyProperty.Register("IsMinButtonEnabled", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001CC RID: 460
		public static readonly DependencyProperty IsMaxRestoreButtonEnabledProperty = DependencyProperty.Register("IsMaxRestoreButtonEnabled", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001CD RID: 461
		public static readonly DependencyProperty IsCloseButtonEnabledProperty = DependencyProperty.Register("IsCloseButtonEnabled", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001CE RID: 462
		public static readonly DependencyPropertyKey IsCloseButtonEnabledWithDialogPropertyKey = DependencyProperty.RegisterReadOnly("IsCloseButtonEnabledWithDialog", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001CF RID: 463
		public static readonly DependencyProperty IsCloseButtonEnabledWithDialogProperty = MetroWindow.IsCloseButtonEnabledWithDialogPropertyKey.DependencyProperty;

		// Token: 0x040001D0 RID: 464
		public static readonly DependencyProperty ShowSystemMenuOnRightClickProperty = DependencyProperty.Register("ShowSystemMenuOnRightClick", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001D1 RID: 465
		public static readonly DependencyProperty TitlebarHeightProperty = DependencyProperty.Register("TitlebarHeight", typeof(int), typeof(MetroWindow), new PropertyMetadata(30, new PropertyChangedCallback(MetroWindow.TitlebarHeightPropertyChangedCallback)));

		// Token: 0x040001D2 RID: 466
		[Obsolete("This property will be deleted in the next release. You should use the new TitleCharacterCasing dependency property.")]
		public static readonly DependencyProperty TitleCapsProperty = DependencyProperty.Register("TitleCaps", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((MetroWindow)o).SetCurrentValue(MetroWindow.TitleCharacterCasingProperty, ((bool)e.NewValue) ? CharacterCasing.Upper : CharacterCasing.Normal);
		}));

		// Token: 0x040001D3 RID: 467
		public static readonly DependencyProperty TitleCharacterCasingProperty = DependencyProperty.Register("TitleCharacterCasing", typeof(CharacterCasing), typeof(MetroWindow), new FrameworkPropertyMetadata(CharacterCasing.Upper, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits), (object value) => CharacterCasing.Normal <= (CharacterCasing)value && (CharacterCasing)value <= CharacterCasing.Upper);

		// Token: 0x040001D4 RID: 468
		public static readonly DependencyProperty TitleAlignmentProperty = DependencyProperty.Register("TitleAlignment", typeof(HorizontalAlignment), typeof(MetroWindow), new PropertyMetadata(HorizontalAlignment.Stretch, new PropertyChangedCallback(MetroWindow.OnTitleAlignmentChanged)));

		// Token: 0x040001D5 RID: 469
		public static readonly DependencyProperty SaveWindowPositionProperty = DependencyProperty.Register("SaveWindowPosition", typeof(bool), typeof(MetroWindow), new PropertyMetadata(false));

		// Token: 0x040001D6 RID: 470
		public static readonly DependencyProperty WindowPlacementSettingsProperty = DependencyProperty.Register("WindowPlacementSettings", typeof(IWindowPlacementSettings), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001D7 RID: 471
		public static readonly DependencyProperty TitleForegroundProperty = DependencyProperty.Register("TitleForeground", typeof(Brush), typeof(MetroWindow));

		// Token: 0x040001D8 RID: 472
		public static readonly DependencyProperty IgnoreTaskbarOnMaximizeProperty = DependencyProperty.Register("IgnoreTaskbarOnMaximize", typeof(bool), typeof(MetroWindow), new PropertyMetadata(false));

		// Token: 0x040001D9 RID: 473
		public static readonly DependencyProperty FlyoutsProperty = DependencyProperty.Register("Flyouts", typeof(FlyoutsControl), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.UpdateLogicalChilds)));

		// Token: 0x040001DA RID: 474
		public static readonly DependencyProperty WindowTransitionsEnabledProperty = DependencyProperty.Register("WindowTransitionsEnabled", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001DB RID: 475
		public static readonly DependencyProperty MetroDialogOptionsProperty = DependencyProperty.Register("MetroDialogOptions", typeof(MetroDialogSettings), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001DC RID: 476
		public static readonly DependencyProperty WindowTitleBrushProperty = DependencyProperty.Register("WindowTitleBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(Brushes.Transparent));

		// Token: 0x040001DD RID: 477
		public static readonly DependencyProperty NonActiveWindowTitleBrushProperty = DependencyProperty.Register("NonActiveWindowTitleBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(Brushes.Gray));

		// Token: 0x040001DE RID: 478
		public static readonly DependencyProperty NonActiveBorderBrushProperty = DependencyProperty.Register("NonActiveBorderBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(Brushes.Gray));

		// Token: 0x040001DF RID: 479
		public static readonly DependencyProperty GlowBrushProperty = DependencyProperty.Register("GlowBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E0 RID: 480
		public static readonly DependencyProperty NonActiveGlowBrushProperty = DependencyProperty.Register("NonActiveGlowBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E1 RID: 481
		public static readonly DependencyProperty OverlayBrushProperty = DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E2 RID: 482
		public static readonly DependencyProperty OverlayOpacityProperty = DependencyProperty.Register("OverlayOpacity", typeof(double), typeof(MetroWindow), new PropertyMetadata(0.7));

		// Token: 0x040001E3 RID: 483
		public static readonly DependencyProperty OverlayFadeInProperty = DependencyProperty.Register("OverlayFadeIn", typeof(Storyboard), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E4 RID: 484
		public static readonly DependencyProperty OverlayFadeOutProperty = DependencyProperty.Register("OverlayFadeOut", typeof(Storyboard), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E5 RID: 485
		public static readonly DependencyProperty IconTemplateProperty = DependencyProperty.Register("IconTemplate", typeof(DataTemplate), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E6 RID: 486
		public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register("TitleTemplate", typeof(DataTemplate), typeof(MetroWindow), new PropertyMetadata(null));

		// Token: 0x040001E7 RID: 487
		public static readonly DependencyProperty LeftWindowCommandsProperty = DependencyProperty.Register("LeftWindowCommands", typeof(WindowCommands), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.UpdateLogicalChilds)));

		// Token: 0x040001E8 RID: 488
		public static readonly DependencyProperty RightWindowCommandsProperty = DependencyProperty.Register("RightWindowCommands", typeof(WindowCommands), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.UpdateLogicalChilds)));

		// Token: 0x040001E9 RID: 489
		public static readonly DependencyProperty WindowButtonCommandsProperty = DependencyProperty.Register("WindowButtonCommands", typeof(WindowButtonCommands), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.UpdateLogicalChilds)));

		// Token: 0x040001EA RID: 490
		public static readonly DependencyProperty LeftWindowCommandsOverlayBehaviorProperty = DependencyProperty.Register("LeftWindowCommandsOverlayBehavior", typeof(WindowCommandsOverlayBehavior), typeof(MetroWindow), new PropertyMetadata(WindowCommandsOverlayBehavior.Flyouts, new PropertyChangedCallback(MetroWindow.OnShowTitleBarPropertyChangedCallback)));

		// Token: 0x040001EB RID: 491
		public static readonly DependencyProperty RightWindowCommandsOverlayBehaviorProperty = DependencyProperty.Register("RightWindowCommandsOverlayBehavior", typeof(WindowCommandsOverlayBehavior), typeof(MetroWindow), new PropertyMetadata(WindowCommandsOverlayBehavior.Flyouts, new PropertyChangedCallback(MetroWindow.OnShowTitleBarPropertyChangedCallback)));

		// Token: 0x040001EC RID: 492
		public static readonly DependencyProperty WindowButtonCommandsOverlayBehaviorProperty = DependencyProperty.Register("WindowButtonCommandsOverlayBehavior", typeof(WindowCommandsOverlayBehavior), typeof(MetroWindow), new PropertyMetadata(WindowCommandsOverlayBehavior.Always, new PropertyChangedCallback(MetroWindow.OnShowTitleBarPropertyChangedCallback)));

		// Token: 0x040001ED RID: 493
		public static readonly DependencyProperty IconOverlayBehaviorProperty = DependencyProperty.Register("IconOverlayBehavior", typeof(WindowCommandsOverlayBehavior), typeof(MetroWindow), new PropertyMetadata(WindowCommandsOverlayBehavior.Never, new PropertyChangedCallback(MetroWindow.OnShowTitleBarPropertyChangedCallback)));

		// Token: 0x040001EE RID: 494
		[Obsolete("This property will be deleted in the next release. You should use LightMinButtonStyle or DarkMinButtonStyle in WindowButtonCommands to override the style.")]
		public static readonly DependencyProperty WindowMinButtonStyleProperty = DependencyProperty.Register("WindowMinButtonStyle", typeof(Style), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.OnWindowButtonStyleChanged)));

		// Token: 0x040001EF RID: 495
		[Obsolete("This property will be deleted in the next release. You should use LightMaxButtonStyle or DarkMaxButtonStyle in WindowButtonCommands to override the style.")]
		public static readonly DependencyProperty WindowMaxButtonStyleProperty = DependencyProperty.Register("WindowMaxButtonStyle", typeof(Style), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.OnWindowButtonStyleChanged)));

		// Token: 0x040001F0 RID: 496
		[Obsolete("This property will be deleted in the next release. You should use LightCloseButtonStyle or DarkCloseButtonStyle in WindowButtonCommands to override the style.")]
		public static readonly DependencyProperty WindowCloseButtonStyleProperty = DependencyProperty.Register("WindowCloseButtonStyle", typeof(Style), typeof(MetroWindow), new PropertyMetadata(null, new PropertyChangedCallback(MetroWindow.OnWindowButtonStyleChanged)));

		// Token: 0x040001F1 RID: 497
		public static readonly DependencyProperty UseNoneWindowStyleProperty = DependencyProperty.Register("UseNoneWindowStyle", typeof(bool), typeof(MetroWindow), new PropertyMetadata(false, new PropertyChangedCallback(MetroWindow.OnUseNoneWindowStylePropertyChangedCallback)));

		// Token: 0x040001F2 RID: 498
		public static readonly DependencyProperty OverrideDefaultWindowCommandsBrushProperty = DependencyProperty.Register("OverrideDefaultWindowCommandsBrush", typeof(SolidColorBrush), typeof(MetroWindow));

		// Token: 0x040001F3 RID: 499
		[Obsolete("This property will be deleted in the next release. You should use BorderThickness=\"0\" and a GlowBrush=\"Black\" to get a drop shadow around the Window.")]
		public static readonly DependencyProperty EnableDWMDropShadowProperty = DependencyProperty.Register("EnableDWMDropShadow", typeof(bool), typeof(MetroWindow), new PropertyMetadata(false, new PropertyChangedCallback(MetroWindow.OnEnableDWMDropShadowPropertyChangedCallback)));

		// Token: 0x040001F4 RID: 500
		public static readonly DependencyProperty IsWindowDraggableProperty = DependencyProperty.Register("IsWindowDraggable", typeof(bool), typeof(MetroWindow), new PropertyMetadata(true));

		// Token: 0x040001F5 RID: 501
		private FrameworkElement icon;

		// Token: 0x040001F6 RID: 502
		private UIElement titleBar;

		// Token: 0x040001F7 RID: 503
		private UIElement titleBarBackground;

		// Token: 0x040001F8 RID: 504
		private Thumb windowTitleThumb;

		// Token: 0x040001F9 RID: 505
		private Thumb flyoutModalDragMoveThumb;

		// Token: 0x040001FA RID: 506
		private IInputElement restoreFocus;

		// Token: 0x040001FB RID: 507
		internal ContentPresenter LeftWindowCommandsPresenter;

		// Token: 0x040001FC RID: 508
		internal ContentPresenter RightWindowCommandsPresenter;

		// Token: 0x040001FD RID: 509
		internal ContentPresenter WindowButtonCommandsPresenter;

		// Token: 0x040001FE RID: 510
		internal Grid overlayBox;

		// Token: 0x040001FF RID: 511
		internal Grid metroActiveDialogContainer;

		// Token: 0x04000200 RID: 512
		internal Grid metroInactiveDialogContainer;

		// Token: 0x04000201 RID: 513
		private Storyboard overlayStoryboard;

		// Token: 0x04000202 RID: 514
		private Rectangle flyoutModal;

		// Token: 0x04000205 RID: 517
		public static readonly DependencyProperty ResizeBorderThicknessProperty;

		// Token: 0x020000EE RID: 238
		public class FlyoutStatusChangedRoutedEventArgs : RoutedEventArgs
		{
			// Token: 0x06000AE8 RID: 2792 RVA: 0x0002974B File Offset: 0x0002794B
			internal FlyoutStatusChangedRoutedEventArgs(RoutedEvent rEvent, object source) : base(rEvent, source)
			{
			}

			// Token: 0x17000217 RID: 535
			// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x00029755 File Offset: 0x00027955
			// (set) Token: 0x06000AEA RID: 2794 RVA: 0x0002975D File Offset: 0x0002795D
			public Flyout ChangedFlyout { get; internal set; }
		}
	}
}
