using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ControlzEx.Native;
using ControlzEx.Windows.Shell;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000099 RID: 153
	[TemplatePart(Name = "PART_Min", Type = typeof(Button))]
	[TemplatePart(Name = "PART_Max", Type = typeof(Button))]
	[TemplatePart(Name = "PART_Close", Type = typeof(Button))]
	public class WindowButtonCommands : ContentControl, INotifyPropertyChanged
	{
		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0600083A RID: 2106 RVA: 0x000218C0 File Offset: 0x0001FAC0
		// (remove) Token: 0x0600083B RID: 2107 RVA: 0x000218F8 File Offset: 0x0001FAF8
		public event WindowButtonCommands.ClosingWindowEventHandler ClosingWindow;

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0002192D File Offset: 0x0001FB2D
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x0002193F File Offset: 0x0001FB3F
		public Style LightMinButtonStyle
		{
			get
			{
				return (Style)base.GetValue(WindowButtonCommands.LightMinButtonStyleProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.LightMinButtonStyleProperty, value);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0002194D File Offset: 0x0001FB4D
		// (set) Token: 0x0600083F RID: 2111 RVA: 0x0002195F File Offset: 0x0001FB5F
		public Style LightMaxButtonStyle
		{
			get
			{
				return (Style)base.GetValue(WindowButtonCommands.LightMaxButtonStyleProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.LightMaxButtonStyleProperty, value);
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0002196D File Offset: 0x0001FB6D
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x0002197F File Offset: 0x0001FB7F
		public Style LightCloseButtonStyle
		{
			get
			{
				return (Style)base.GetValue(WindowButtonCommands.LightCloseButtonStyleProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.LightCloseButtonStyleProperty, value);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0002198D File Offset: 0x0001FB8D
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x0002199F File Offset: 0x0001FB9F
		public Style DarkMinButtonStyle
		{
			get
			{
				return (Style)base.GetValue(WindowButtonCommands.DarkMinButtonStyleProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.DarkMinButtonStyleProperty, value);
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x000219AD File Offset: 0x0001FBAD
		// (set) Token: 0x06000845 RID: 2117 RVA: 0x000219BF File Offset: 0x0001FBBF
		public Style DarkMaxButtonStyle
		{
			get
			{
				return (Style)base.GetValue(WindowButtonCommands.DarkMaxButtonStyleProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.DarkMaxButtonStyleProperty, value);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x000219CD File Offset: 0x0001FBCD
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x000219DF File Offset: 0x0001FBDF
		public Style DarkCloseButtonStyle
		{
			get
			{
				return (Style)base.GetValue(WindowButtonCommands.DarkCloseButtonStyleProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.DarkCloseButtonStyleProperty, value);
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x000219ED File Offset: 0x0001FBED
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x000219FF File Offset: 0x0001FBFF
		public Theme Theme
		{
			get
			{
				return (Theme)base.GetValue(WindowButtonCommands.ThemeProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.ThemeProperty, value);
			}
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00021A12 File Offset: 0x0001FC12
		private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue == e.OldValue)
			{
				return;
			}
			((WindowButtonCommands)d).ApplyTheme();
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x00021A30 File Offset: 0x0001FC30
		// (set) Token: 0x0600084C RID: 2124 RVA: 0x00021A42 File Offset: 0x0001FC42
		public string Minimize
		{
			get
			{
				return (string)base.GetValue(WindowButtonCommands.MinimizeProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.MinimizeProperty, value);
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x00021A50 File Offset: 0x0001FC50
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x00021A62 File Offset: 0x0001FC62
		public string Maximize
		{
			get
			{
				return (string)base.GetValue(WindowButtonCommands.MaximizeProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.MaximizeProperty, value);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x00021A70 File Offset: 0x0001FC70
		// (set) Token: 0x06000850 RID: 2128 RVA: 0x00021A82 File Offset: 0x0001FC82
		public string Close
		{
			get
			{
				return (string)base.GetValue(WindowButtonCommands.CloseProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.CloseProperty, value);
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00021A90 File Offset: 0x0001FC90
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x00021AA2 File Offset: 0x0001FCA2
		public string Restore
		{
			get
			{
				return (string)base.GetValue(WindowButtonCommands.RestoreProperty);
			}
			set
			{
				base.SetValue(WindowButtonCommands.RestoreProperty, value);
			}
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00021AB0 File Offset: 0x0001FCB0
		static WindowButtonCommands()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowButtonCommands), new FrameworkPropertyMetadata(typeof(WindowButtonCommands)));
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00021CFC File Offset: 0x0001FEFC
		public WindowButtonCommands()
		{
			base.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(delegate()
			{
				if (string.IsNullOrWhiteSpace(this.Minimize))
				{
					base.SetCurrentValue(WindowButtonCommands.MinimizeProperty, this.GetCaption(900));
				}
				if (string.IsNullOrWhiteSpace(this.Maximize))
				{
					base.SetCurrentValue(WindowButtonCommands.MaximizeProperty, this.GetCaption(901));
				}
				if (string.IsNullOrWhiteSpace(this.Close))
				{
					base.SetCurrentValue(WindowButtonCommands.CloseProperty, this.GetCaption(905));
				}
				if (string.IsNullOrWhiteSpace(this.Restore))
				{
					base.SetCurrentValue(WindowButtonCommands.RestoreProperty, this.GetCaption(903));
				}
			}));
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00021D20 File Offset: 0x0001FF20
		private string GetCaption(int id)
		{
			if (this.user32 == null)
			{
				this.user32 = UnsafeNativeMethods.LoadLibrary(Environment.SystemDirectory + "\\User32.dll");
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			UnsafeNativeMethods.LoadString(this.user32, (uint)id, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString().Replace("&", "");
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00021D84 File Offset: 0x0001FF84
		public void ApplyTheme()
		{
			if (this.close != null)
			{
				MetroWindow parentWindow = this.ParentWindow;
				if (((parentWindow != null) ? parentWindow.WindowCloseButtonStyle : null) != null)
				{
					this.close.Style = this.ParentWindow.WindowCloseButtonStyle;
				}
				else
				{
					this.close.Style = ((this.Theme == Theme.Light) ? this.LightCloseButtonStyle : this.DarkCloseButtonStyle);
				}
			}
			if (this.max != null)
			{
				MetroWindow parentWindow2 = this.ParentWindow;
				if (((parentWindow2 != null) ? parentWindow2.WindowMaxButtonStyle : null) != null)
				{
					this.max.Style = this.ParentWindow.WindowMaxButtonStyle;
				}
				else
				{
					this.max.Style = ((this.Theme == Theme.Light) ? this.LightMaxButtonStyle : this.DarkMaxButtonStyle);
				}
			}
			if (this.min != null)
			{
				MetroWindow parentWindow3 = this.ParentWindow;
				if (((parentWindow3 != null) ? parentWindow3.WindowMinButtonStyle : null) != null)
				{
					this.min.Style = this.ParentWindow.WindowMinButtonStyle;
					return;
				}
				this.min.Style = ((this.Theme == Theme.Light) ? this.LightMinButtonStyle : this.DarkMinButtonStyle);
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00021E90 File Offset: 0x00020090
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.close = (base.Template.FindName("PART_Close", this) as Button);
			if (this.close != null)
			{
				this.close.Click += this.CloseClick;
			}
			this.max = (base.Template.FindName("PART_Max", this) as Button);
			if (this.max != null)
			{
				this.max.Click += this.MaximizeClick;
			}
			this.min = (base.Template.FindName("PART_Min", this) as Button);
			if (this.min != null)
			{
				this.min.Click += this.MinimizeClick;
			}
			this.ApplyTheme();
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00021F5C File Offset: 0x0002015C
		protected void OnClosingWindow(ClosingWindowEventHandlerArgs args)
		{
			WindowButtonCommands.ClosingWindowEventHandler closingWindow = this.ClosingWindow;
			if (closingWindow != null)
			{
				closingWindow(this, args);
			}
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00021F7B File Offset: 0x0002017B
		private void MinimizeClick(object sender, RoutedEventArgs e)
		{
			if (this.ParentWindow == null)
			{
				return;
			}
			ControlzEx.Windows.Shell.SystemCommands.MinimizeWindow(this.ParentWindow);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00021F91 File Offset: 0x00020191
		private void MaximizeClick(object sender, RoutedEventArgs e)
		{
			if (this.ParentWindow == null)
			{
				return;
			}
			if (this.ParentWindow.WindowState == WindowState.Maximized)
			{
				ControlzEx.Windows.Shell.SystemCommands.RestoreWindow(this.ParentWindow);
				return;
			}
			ControlzEx.Windows.Shell.SystemCommands.MaximizeWindow(this.ParentWindow);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00021FC4 File Offset: 0x000201C4
		private void CloseClick(object sender, RoutedEventArgs e)
		{
			ClosingWindowEventHandlerArgs closingWindowEventHandlerArgs = new ClosingWindowEventHandlerArgs();
			this.OnClosingWindow(closingWindowEventHandlerArgs);
			if (closingWindowEventHandlerArgs.Cancelled)
			{
				return;
			}
			if (this.ParentWindow == null)
			{
				return;
			}
			this.ParentWindow.Close();
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x00021FFB File Offset: 0x000201FB
		// (set) Token: 0x0600085D RID: 2141 RVA: 0x00022003 File Offset: 0x00020203
		public MetroWindow ParentWindow
		{
			get
			{
				return this._parentWindow;
			}
			set
			{
				if (object.Equals(this._parentWindow, value))
				{
					return;
				}
				this._parentWindow = value;
				this.RaisePropertyChanged("ParentWindow");
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x0600085E RID: 2142 RVA: 0x00022028 File Offset: 0x00020228
		// (remove) Token: 0x0600085F RID: 2143 RVA: 0x00022060 File Offset: 0x00020260
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000860 RID: 2144 RVA: 0x00022098 File Offset: 0x00020298
		protected virtual void RaisePropertyChanged(string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x040003C3 RID: 963
		public static readonly DependencyProperty LightMinButtonStyleProperty = DependencyProperty.Register("LightMinButtonStyle", typeof(Style), typeof(WindowButtonCommands), new PropertyMetadata(null, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003C4 RID: 964
		public static readonly DependencyProperty LightMaxButtonStyleProperty = DependencyProperty.Register("LightMaxButtonStyle", typeof(Style), typeof(WindowButtonCommands), new PropertyMetadata(null, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003C5 RID: 965
		public static readonly DependencyProperty LightCloseButtonStyleProperty = DependencyProperty.Register("LightCloseButtonStyle", typeof(Style), typeof(WindowButtonCommands), new PropertyMetadata(null, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003C6 RID: 966
		public static readonly DependencyProperty DarkMinButtonStyleProperty = DependencyProperty.Register("DarkMinButtonStyle", typeof(Style), typeof(WindowButtonCommands), new PropertyMetadata(null, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003C7 RID: 967
		public static readonly DependencyProperty DarkMaxButtonStyleProperty = DependencyProperty.Register("DarkMaxButtonStyle", typeof(Style), typeof(WindowButtonCommands), new PropertyMetadata(null, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003C8 RID: 968
		public static readonly DependencyProperty DarkCloseButtonStyleProperty = DependencyProperty.Register("DarkCloseButtonStyle", typeof(Style), typeof(WindowButtonCommands), new PropertyMetadata(null, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003C9 RID: 969
		public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register("Theme", typeof(Theme), typeof(WindowButtonCommands), new PropertyMetadata(Theme.Light, new PropertyChangedCallback(WindowButtonCommands.OnThemeChanged)));

		// Token: 0x040003CA RID: 970
		public static readonly DependencyProperty MinimizeProperty = DependencyProperty.Register("Minimize", typeof(string), typeof(WindowButtonCommands), new PropertyMetadata(null));

		// Token: 0x040003CB RID: 971
		public static readonly DependencyProperty MaximizeProperty = DependencyProperty.Register("Maximize", typeof(string), typeof(WindowButtonCommands), new PropertyMetadata(null));

		// Token: 0x040003CC RID: 972
		public static readonly DependencyProperty CloseProperty = DependencyProperty.Register("Close", typeof(string), typeof(WindowButtonCommands), new PropertyMetadata(null));

		// Token: 0x040003CD RID: 973
		public static readonly DependencyProperty RestoreProperty = DependencyProperty.Register("Restore", typeof(string), typeof(WindowButtonCommands), new PropertyMetadata(null));

		// Token: 0x040003CE RID: 974
		private Button min;

		// Token: 0x040003CF RID: 975
		private Button max;

		// Token: 0x040003D0 RID: 976
		private Button close;

		// Token: 0x040003D1 RID: 977
		private SafeLibraryHandle user32;

		// Token: 0x040003D2 RID: 978
		private MetroWindow _parentWindow;

		// Token: 0x02000111 RID: 273
		// (Invoke) Token: 0x06000B6E RID: 2926
		public delegate void ClosingWindowEventHandler(object sender, ClosingWindowEventHandlerArgs args);
	}
}
