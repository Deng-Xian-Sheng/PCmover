using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000084 RID: 132
	[TemplatePart(Name = "PaneClipRectangle", Type = typeof(RectangleGeometry))]
	[TemplatePart(Name = "LightDismissLayer", Type = typeof(Rectangle))]
	[TemplateVisualState(Name = "Closed                 ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "ClosedCompactLeft      ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "ClosedCompactRight     ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "OpenOverlayLeft        ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "OpenOverlayRight       ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "OpenInlineLeft         ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "OpenInlineRight        ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "OpenCompactOverlayLeft ", GroupName = "DisplayModeStates")]
	[TemplateVisualState(Name = "OpenCompactOverlayRight", GroupName = "DisplayModeStates")]
	[ContentProperty("Content")]
	public class SplitView : Control
	{
		// Token: 0x060006FC RID: 1788 RVA: 0x0001CDA7 File Offset: 0x0001AFA7
		private static void OnMetricsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SplitView splitView = d as SplitView;
			if (splitView != null)
			{
				SplitViewTemplateSettings templateSettings = splitView.TemplateSettings;
				if (templateSettings != null)
				{
					templateSettings.Update();
				}
			}
			if (splitView == null)
			{
				return;
			}
			splitView.ChangeVisualState(true);
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x0001CDD1 File Offset: 0x0001AFD1
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x0001CDE3 File Offset: 0x0001AFE3
		public double CompactPaneLength
		{
			get
			{
				return (double)base.GetValue(SplitView.CompactPaneLengthProperty);
			}
			set
			{
				base.SetValue(SplitView.CompactPaneLengthProperty, value);
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x0001CDF6 File Offset: 0x0001AFF6
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x0001CE08 File Offset: 0x0001B008
		public UIElement Content
		{
			get
			{
				return (UIElement)base.GetValue(SplitView.ContentProperty);
			}
			set
			{
				base.SetValue(SplitView.ContentProperty, value);
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001CE16 File Offset: 0x0001B016
		private static void OnStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SplitView splitView = d as SplitView;
			if (splitView == null)
			{
				return;
			}
			splitView.ChangeVisualState(true);
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x0001CE29 File Offset: 0x0001B029
		// (set) Token: 0x06000703 RID: 1795 RVA: 0x0001CE3B File Offset: 0x0001B03B
		public SplitViewDisplayMode DisplayMode
		{
			get
			{
				return (SplitViewDisplayMode)base.GetValue(SplitView.DisplayModeProperty);
			}
			set
			{
				base.SetValue(SplitView.DisplayModeProperty, value);
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0001CE50 File Offset: 0x0001B050
		private static void OnIsPaneOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SplitView splitView = d as SplitView;
			bool flag = (bool)e.NewValue;
			bool flag2 = (bool)e.OldValue;
			if (splitView == null || flag == flag2)
			{
				return;
			}
			if (flag)
			{
				splitView.ChangeVisualState(true);
				return;
			}
			splitView.OnIsPaneOpenChanged();
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x0001CE97 File Offset: 0x0001B097
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x0001CEA9 File Offset: 0x0001B0A9
		public bool IsPaneOpen
		{
			get
			{
				return (bool)base.GetValue(SplitView.IsPaneOpenProperty);
			}
			set
			{
				base.SetValue(SplitView.IsPaneOpenProperty, value);
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0001CEBC File Offset: 0x0001B0BC
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x0001CECE File Offset: 0x0001B0CE
		public double OpenPaneLength
		{
			get
			{
				return (double)base.GetValue(SplitView.OpenPaneLengthProperty);
			}
			set
			{
				base.SetValue(SplitView.OpenPaneLengthProperty, value);
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x0001CEE1 File Offset: 0x0001B0E1
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x0001CEF3 File Offset: 0x0001B0F3
		public UIElement Pane
		{
			get
			{
				return (UIElement)base.GetValue(SplitView.PaneProperty);
			}
			set
			{
				base.SetValue(SplitView.PaneProperty, value);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x0001CF01 File Offset: 0x0001B101
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x0001CF13 File Offset: 0x0001B113
		public Brush PaneBackground
		{
			get
			{
				return (Brush)base.GetValue(SplitView.PaneBackgroundProperty);
			}
			set
			{
				base.SetValue(SplitView.PaneBackgroundProperty, value);
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001CF21 File Offset: 0x0001B121
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x0001CF33 File Offset: 0x0001B133
		public Brush PaneForeground
		{
			get
			{
				return (Brush)base.GetValue(SplitView.PaneForegroundProperty);
			}
			set
			{
				base.SetValue(SplitView.PaneForegroundProperty, value);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x0001CF41 File Offset: 0x0001B141
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x0001CF53 File Offset: 0x0001B153
		public SplitViewPanePlacement PanePlacement
		{
			get
			{
				return (SplitViewPanePlacement)base.GetValue(SplitView.PanePlacementProperty);
			}
			set
			{
				base.SetValue(SplitView.PanePlacementProperty, value);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x0001CF66 File Offset: 0x0001B166
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x0001CF78 File Offset: 0x0001B178
		public SplitViewTemplateSettings TemplateSettings
		{
			get
			{
				return (SplitViewTemplateSettings)base.GetValue(SplitView.TemplateSettingsProperty);
			}
			private set
			{
				base.SetValue(SplitView.TemplateSettingsProperty, value);
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0001CF86 File Offset: 0x0001B186
		public SplitView()
		{
			base.DefaultStyleKey = typeof(SplitView);
			this.TemplateSettings = new SplitViewTemplateSettings(this);
			base.Loaded += delegate(object s, RoutedEventArgs args)
			{
				this.TemplateSettings.Update();
				this.ChangeVisualState(false);
			};
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000714 RID: 1812 RVA: 0x0001CFBC File Offset: 0x0001B1BC
		// (remove) Token: 0x06000715 RID: 1813 RVA: 0x0001CFF4 File Offset: 0x0001B1F4
		public event EventHandler PaneClosed;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000716 RID: 1814 RVA: 0x0001D02C File Offset: 0x0001B22C
		// (remove) Token: 0x06000717 RID: 1815 RVA: 0x0001D064 File Offset: 0x0001B264
		public event EventHandler<SplitViewPaneClosingEventArgs> PaneClosing;

		// Token: 0x06000718 RID: 1816 RVA: 0x0001D09C File Offset: 0x0001B29C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.paneClipRectangle = (base.GetTemplateChild("PaneClipRectangle") as RectangleGeometry);
			this.lightDismissLayer = (base.GetTemplateChild("LightDismissLayer") as Rectangle);
			if (this.lightDismissLayer != null)
			{
				this.lightDismissLayer.MouseDown += this.OnLightDismiss;
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0001D0FA File Offset: 0x0001B2FA
		protected override void OnRenderSizeChanged(SizeChangedInfo info)
		{
			base.OnRenderSizeChanged(info);
			if (this.paneClipRectangle != null)
			{
				this.paneClipRectangle.Rect = new Rect(0.0, 0.0, this.OpenPaneLength, base.ActualHeight);
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001D13C File Offset: 0x0001B33C
		protected virtual void ChangeVisualState(bool animated = true)
		{
			if (this.paneClipRectangle != null)
			{
				this.paneClipRectangle.Rect = new Rect(0.0, 0.0, this.OpenPaneLength, base.ActualHeight);
			}
			string text = string.Empty;
			if (this.IsPaneOpen)
			{
				text += "Open";
				SplitViewDisplayMode displayMode = this.DisplayMode;
				if (displayMode == SplitViewDisplayMode.CompactInline)
				{
					text += "Inline";
				}
				else
				{
					text += this.DisplayMode.ToString();
				}
				text += this.PanePlacement.ToString();
			}
			else
			{
				text += "Closed";
				if (this.DisplayMode == SplitViewDisplayMode.CompactInline || this.DisplayMode == SplitViewDisplayMode.CompactOverlay)
				{
					text += "Compact";
					text += this.PanePlacement.ToString();
				}
			}
			VisualStateManager.GoToState(this, "None", animated);
			VisualStateManager.GoToState(this, text, animated);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0001D248 File Offset: 0x0001B448
		protected virtual void OnIsPaneOpenChanged()
		{
			bool flag = false;
			if (this.PaneClosing != null)
			{
				SplitViewPaneClosingEventArgs splitViewPaneClosingEventArgs = new SplitViewPaneClosingEventArgs();
				Delegate[] invocationList = this.PaneClosing.GetInvocationList();
				for (int i = 0; i < invocationList.Length; i++)
				{
					EventHandler<SplitViewPaneClosingEventArgs> eventHandler = invocationList[i] as EventHandler<SplitViewPaneClosingEventArgs>;
					if (eventHandler != null)
					{
						eventHandler(this, splitViewPaneClosingEventArgs);
						if (splitViewPaneClosingEventArgs.Cancel)
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				base.SetCurrentValue(SplitView.IsPaneOpenProperty, false);
				return;
			}
			this.ChangeVisualState(true);
			EventHandler paneClosed = this.PaneClosed;
			if (paneClosed == null)
			{
				return;
			}
			paneClosed(this, EventArgs.Empty);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0001D2D4 File Offset: 0x0001B4D4
		private void OnLightDismiss(object sender, MouseButtonEventArgs e)
		{
			base.SetCurrentValue(SplitView.IsPaneOpenProperty, false);
		}

		// Token: 0x040002CF RID: 719
		public static readonly DependencyProperty CompactPaneLengthProperty = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(SplitView), new PropertyMetadata(0.0, new PropertyChangedCallback(SplitView.OnMetricsChanged)));

		// Token: 0x040002D0 RID: 720
		public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(UIElement), typeof(SplitView), new PropertyMetadata(null));

		// Token: 0x040002D1 RID: 721
		public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(SplitViewDisplayMode), typeof(SplitView), new PropertyMetadata(SplitViewDisplayMode.Overlay, new PropertyChangedCallback(SplitView.OnStateChanged)));

		// Token: 0x040002D2 RID: 722
		public static readonly DependencyProperty IsPaneOpenProperty = DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(SplitView), new PropertyMetadata(false, new PropertyChangedCallback(SplitView.OnIsPaneOpenChanged)));

		// Token: 0x040002D3 RID: 723
		public static readonly DependencyProperty OpenPaneLengthProperty = DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(SplitView), new PropertyMetadata(0.0, new PropertyChangedCallback(SplitView.OnMetricsChanged)));

		// Token: 0x040002D4 RID: 724
		public static readonly DependencyProperty PaneProperty = DependencyProperty.Register("Pane", typeof(UIElement), typeof(SplitView), new PropertyMetadata(null));

		// Token: 0x040002D5 RID: 725
		public static readonly DependencyProperty PaneBackgroundProperty = DependencyProperty.Register("PaneBackground", typeof(Brush), typeof(SplitView), new PropertyMetadata(null));

		// Token: 0x040002D6 RID: 726
		public static readonly DependencyProperty PaneForegroundProperty = DependencyProperty.Register("PaneForeground", typeof(Brush), typeof(SplitView), new PropertyMetadata(null));

		// Token: 0x040002D7 RID: 727
		public static readonly DependencyProperty PanePlacementProperty = DependencyProperty.Register("PanePlacement", typeof(SplitViewPanePlacement), typeof(SplitView), new PropertyMetadata(SplitViewPanePlacement.Left, new PropertyChangedCallback(SplitView.OnStateChanged)));

		// Token: 0x040002D8 RID: 728
		public static readonly DependencyProperty TemplateSettingsProperty = DependencyProperty.Register("TemplateSettings", typeof(SplitViewTemplateSettings), typeof(SplitView), new PropertyMetadata(null));

		// Token: 0x040002D9 RID: 729
		private Rectangle lightDismissLayer;

		// Token: 0x040002DA RID: 730
		private RectangleGeometry paneClipRectangle;
	}
}
