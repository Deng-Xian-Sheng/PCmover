using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using ControlzEx.Standard;

namespace ControlzEx.Windows.Shell
{
	// Token: 0x02000013 RID: 19
	public class WindowChrome : Freezable
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000451F File Offset: 0x0000271F
		public static Thickness GlassFrameCompleteThickness
		{
			get
			{
				return new Thickness(-1.0);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004530 File Offset: 0x00002730
		private static void _OnChromeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (DesignerProperties.GetIsInDesignMode(d))
			{
				return;
			}
			Window window = (Window)d;
			WindowChrome windowChrome = (WindowChrome)e.NewValue;
			WindowChromeWorker windowChromeWorker = WindowChromeWorker.GetWindowChromeWorker(window);
			if (windowChromeWorker == null)
			{
				windowChromeWorker = new WindowChromeWorker();
				WindowChromeWorker.SetWindowChromeWorker(window, windowChromeWorker);
			}
			windowChromeWorker.SetWindowChrome(windowChrome);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004578 File Offset: 0x00002778
		[Category("ControlzEx")]
		public static WindowChrome GetWindowChrome(Window window)
		{
			Verify.IsNotNull<Window>(window, "window");
			return (WindowChrome)window.GetValue(WindowChrome.WindowChromeProperty);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004595 File Offset: 0x00002795
		public static void SetWindowChrome(Window window, WindowChrome chrome)
		{
			Verify.IsNotNull<Window>(window, "window");
			window.SetValue(WindowChrome.WindowChromeProperty, chrome);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000045AE File Offset: 0x000027AE
		[Category("ControlzEx")]
		public static bool GetIsHitTestVisibleInChrome(IInputElement inputElement)
		{
			Verify.IsNotNull<IInputElement>(inputElement, "inputElement");
			DependencyObject dependencyObject = inputElement as DependencyObject;
			if (dependencyObject == null)
			{
				throw new ArgumentException("The element must be a DependencyObject", "inputElement");
			}
			return (bool)dependencyObject.GetValue(WindowChrome.IsHitTestVisibleInChromeProperty);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000045E3 File Offset: 0x000027E3
		public static void SetIsHitTestVisibleInChrome(IInputElement inputElement, bool hitTestVisible)
		{
			Verify.IsNotNull<IInputElement>(inputElement, "inputElement");
			DependencyObject dependencyObject = inputElement as DependencyObject;
			if (dependencyObject == null)
			{
				throw new ArgumentException("The element must be a DependencyObject", "inputElement");
			}
			dependencyObject.SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, hitTestVisible);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004619 File Offset: 0x00002819
		[Category("ControlzEx")]
		public static ResizeGripDirection GetResizeGripDirection(IInputElement inputElement)
		{
			Verify.IsNotNull<IInputElement>(inputElement, "inputElement");
			DependencyObject dependencyObject = inputElement as DependencyObject;
			if (dependencyObject == null)
			{
				throw new ArgumentException("The element must be a DependencyObject", "inputElement");
			}
			return (ResizeGripDirection)dependencyObject.GetValue(WindowChrome.ResizeGripDirectionProperty);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000464E File Offset: 0x0000284E
		public static void SetResizeGripDirection(IInputElement inputElement, ResizeGripDirection direction)
		{
			Verify.IsNotNull<IInputElement>(inputElement, "inputElement");
			DependencyObject dependencyObject = inputElement as DependencyObject;
			if (dependencyObject == null)
			{
				throw new ArgumentException("The element must be a DependencyObject", "inputElement");
			}
			dependencyObject.SetValue(WindowChrome.ResizeGripDirectionProperty, direction);
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004684 File Offset: 0x00002884
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00004696 File Offset: 0x00002896
		public double CaptionHeight
		{
			get
			{
				return (double)base.GetValue(WindowChrome.CaptionHeightProperty);
			}
			set
			{
				base.SetValue(WindowChrome.CaptionHeightProperty, value);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000046A9 File Offset: 0x000028A9
		// (set) Token: 0x060000CA RID: 202 RVA: 0x000046BB File Offset: 0x000028BB
		public Thickness ResizeBorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(WindowChrome.ResizeBorderThicknessProperty);
			}
			set
			{
				base.SetValue(WindowChrome.ResizeBorderThicknessProperty, value);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000046CE File Offset: 0x000028CE
		private static object _CoerceGlassFrameThickness(Thickness thickness)
		{
			if (!thickness.IsNonNegative())
			{
				return WindowChrome.GlassFrameCompleteThickness;
			}
			return thickness;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000046E9 File Offset: 0x000028E9
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000046FB File Offset: 0x000028FB
		public Thickness GlassFrameThickness
		{
			get
			{
				return (Thickness)base.GetValue(WindowChrome.GlassFrameThicknessProperty);
			}
			set
			{
				base.SetValue(WindowChrome.GlassFrameThicknessProperty, value);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000CE RID: 206 RVA: 0x0000470E File Offset: 0x0000290E
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00004720 File Offset: 0x00002920
		public bool UseAeroCaptionButtons
		{
			get
			{
				return (bool)base.GetValue(WindowChrome.UseAeroCaptionButtonsProperty);
			}
			set
			{
				base.SetValue(WindowChrome.UseAeroCaptionButtonsProperty, value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004733 File Offset: 0x00002933
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00004745 File Offset: 0x00002945
		public bool IgnoreTaskbarOnMaximize
		{
			get
			{
				return (bool)base.GetValue(WindowChrome.IgnoreTaskbarOnMaximizeProperty);
			}
			set
			{
				base.SetValue(WindowChrome.IgnoreTaskbarOnMaximizeProperty, value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00004758 File Offset: 0x00002958
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x0000476A File Offset: 0x0000296A
		public CornerRadius CornerRadius
		{
			get
			{
				return (CornerRadius)base.GetValue(WindowChrome.CornerRadiusProperty);
			}
			set
			{
				base.SetValue(WindowChrome.CornerRadiusProperty, value);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004780 File Offset: 0x00002980
		private static bool _IsValidSacrificialEdge(object value)
		{
			SacrificialEdge sacrificialEdge = SacrificialEdge.None;
			try
			{
				sacrificialEdge = (SacrificialEdge)value;
			}
			catch (InvalidCastException)
			{
				return false;
			}
			return sacrificialEdge == SacrificialEdge.None || ((sacrificialEdge | WindowChrome.SacrificialEdge_All) == WindowChrome.SacrificialEdge_All && sacrificialEdge != WindowChrome.SacrificialEdge_All);
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x000047D0 File Offset: 0x000029D0
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x000047E2 File Offset: 0x000029E2
		public SacrificialEdge SacrificialEdge
		{
			get
			{
				return (SacrificialEdge)base.GetValue(WindowChrome.SacrificialEdgeProperty);
			}
			set
			{
				base.SetValue(WindowChrome.SacrificialEdgeProperty, value);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000047F5 File Offset: 0x000029F5
		protected override Freezable CreateInstanceCore()
		{
			return new WindowChrome();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000047FC File Offset: 0x000029FC
		public WindowChrome()
		{
			foreach (WindowChrome._SystemParameterBoundProperty systemParameterBoundProperty in WindowChrome._BoundProperties)
			{
				BindingOperations.SetBinding(this, systemParameterBoundProperty.DependencyProperty, new Binding
				{
					Path = new PropertyPath("(SystemParameters." + systemParameterBoundProperty.SystemParameterPropertyName + ")", Array.Empty<object>()),
					Mode = BindingMode.OneWay,
					UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
				});
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004894 File Offset: 0x00002A94
		private void _OnPropertyChangedThatRequiresRepaint()
		{
			EventHandler propertyChangedThatRequiresRepaint = this.PropertyChangedThatRequiresRepaint;
			if (propertyChangedThatRequiresRepaint != null)
			{
				propertyChangedThatRequiresRepaint(this, EventArgs.Empty);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000DA RID: 218 RVA: 0x000048B8 File Offset: 0x00002AB8
		// (remove) Token: 0x060000DB RID: 219 RVA: 0x000048F0 File Offset: 0x00002AF0
		internal event EventHandler PropertyChangedThatRequiresRepaint;

		// Token: 0x0400006E RID: 110
		public static readonly DependencyProperty WindowChromeProperty = DependencyProperty.RegisterAttached("WindowChrome", typeof(WindowChrome), typeof(WindowChrome), new PropertyMetadata(null, new PropertyChangedCallback(WindowChrome._OnChromeChanged)));

		// Token: 0x0400006F RID: 111
		public static readonly DependencyProperty IsHitTestVisibleInChromeProperty = DependencyProperty.RegisterAttached("IsHitTestVisibleInChrome", typeof(bool), typeof(WindowChrome), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000070 RID: 112
		public static readonly DependencyProperty ResizeGripDirectionProperty = DependencyProperty.RegisterAttached("ResizeGripDirection", typeof(ResizeGripDirection), typeof(WindowChrome), new FrameworkPropertyMetadata(ResizeGripDirection.None, FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000071 RID: 113
		public static readonly DependencyProperty CaptionHeightProperty = DependencyProperty.Register("CaptionHeight", typeof(double), typeof(WindowChrome), new PropertyMetadata(0.0, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((WindowChrome)d)._OnPropertyChangedThatRequiresRepaint();
		}), (object value) => (double)value >= 0.0);

		// Token: 0x04000072 RID: 114
		public static readonly DependencyProperty ResizeBorderThicknessProperty = DependencyProperty.Register("ResizeBorderThickness", typeof(Thickness), typeof(WindowChrome), new PropertyMetadata(default(Thickness)), (object value) => ((Thickness)value).IsNonNegative());

		// Token: 0x04000073 RID: 115
		public static readonly DependencyProperty GlassFrameThicknessProperty = DependencyProperty.Register("GlassFrameThickness", typeof(Thickness), typeof(WindowChrome), new PropertyMetadata(default(Thickness), delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((WindowChrome)d)._OnPropertyChangedThatRequiresRepaint();
		}, (DependencyObject d, object o) => WindowChrome._CoerceGlassFrameThickness((Thickness)o)));

		// Token: 0x04000074 RID: 116
		public static readonly DependencyProperty UseAeroCaptionButtonsProperty = DependencyProperty.Register("UseAeroCaptionButtons", typeof(bool), typeof(WindowChrome), new FrameworkPropertyMetadata(true));

		// Token: 0x04000075 RID: 117
		public static readonly DependencyProperty IgnoreTaskbarOnMaximizeProperty = DependencyProperty.Register("IgnoreTaskbarOnMaximize", typeof(bool), typeof(WindowChrome), new FrameworkPropertyMetadata(false, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((WindowChrome)d)._OnPropertyChangedThatRequiresRepaint();
		}));

		// Token: 0x04000076 RID: 118
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(WindowChrome), new PropertyMetadata(default(CornerRadius), delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((WindowChrome)d)._OnPropertyChangedThatRequiresRepaint();
		}), (object value) => ((CornerRadius)value).IsValid());

		// Token: 0x04000077 RID: 119
		public static readonly DependencyProperty SacrificialEdgeProperty = DependencyProperty.Register("SacrificialEdge", typeof(SacrificialEdge), typeof(WindowChrome), new PropertyMetadata(SacrificialEdge.None, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((WindowChrome)d)._OnPropertyChangedThatRequiresRepaint();
		}), new ValidateValueCallback(WindowChrome._IsValidSacrificialEdge));

		// Token: 0x04000078 RID: 120
		private static readonly SacrificialEdge SacrificialEdge_All = SacrificialEdge.Left | SacrificialEdge.Top | SacrificialEdge.Right | SacrificialEdge.Bottom;

		// Token: 0x04000079 RID: 121
		private static readonly List<WindowChrome._SystemParameterBoundProperty> _BoundProperties = new List<WindowChrome._SystemParameterBoundProperty>
		{
			new WindowChrome._SystemParameterBoundProperty
			{
				DependencyProperty = WindowChrome.CornerRadiusProperty,
				SystemParameterPropertyName = "WindowCornerRadius"
			},
			new WindowChrome._SystemParameterBoundProperty
			{
				DependencyProperty = WindowChrome.CaptionHeightProperty,
				SystemParameterPropertyName = "WindowCaptionHeight"
			},
			new WindowChrome._SystemParameterBoundProperty
			{
				DependencyProperty = WindowChrome.ResizeBorderThicknessProperty,
				SystemParameterPropertyName = "WindowResizeBorderThickness"
			},
			new WindowChrome._SystemParameterBoundProperty
			{
				DependencyProperty = WindowChrome.GlassFrameThicknessProperty,
				SystemParameterPropertyName = "WindowNonClientFrameThickness"
			}
		};

		// Token: 0x020000CC RID: 204
		private struct _SystemParameterBoundProperty
		{
			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000C3F9 File Offset: 0x0000A5F9
			// (set) Token: 0x0600042B RID: 1067 RVA: 0x0000C401 File Offset: 0x0000A601
			public string SystemParameterPropertyName { get; set; }

			// Token: 0x1700005D RID: 93
			// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000C40A File Offset: 0x0000A60A
			// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000C412 File Offset: 0x0000A612
			public DependencyProperty DependencyProperty { get; set; }
		}
	}
}
