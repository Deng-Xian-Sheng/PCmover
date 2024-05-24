using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A0 RID: 160
	public abstract class BaseMetroDialog : ContentControl
	{
		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x00022BEF File Offset: 0x00020DEF
		// (set) Token: 0x060008A5 RID: 2213 RVA: 0x00022BF7 File Offset: 0x00020DF7
		public MetroDialogSettings DialogSettings { get; private set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x00022C00 File Offset: 0x00020E00
		// (set) Token: 0x060008A7 RID: 2215 RVA: 0x00022C12 File Offset: 0x00020E12
		public string Title
		{
			get
			{
				return (string)base.GetValue(BaseMetroDialog.TitleProperty);
			}
			set
			{
				base.SetValue(BaseMetroDialog.TitleProperty, value);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x00022C20 File Offset: 0x00020E20
		// (set) Token: 0x060008A9 RID: 2217 RVA: 0x00022C2D File Offset: 0x00020E2D
		public object DialogTop
		{
			get
			{
				return base.GetValue(BaseMetroDialog.DialogTopProperty);
			}
			set
			{
				base.SetValue(BaseMetroDialog.DialogTopProperty, value);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00022C3B File Offset: 0x00020E3B
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x00022C48 File Offset: 0x00020E48
		public object DialogBottom
		{
			get
			{
				return base.GetValue(BaseMetroDialog.DialogBottomProperty);
			}
			set
			{
				base.SetValue(BaseMetroDialog.DialogBottomProperty, value);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x00022C56 File Offset: 0x00020E56
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x00022C68 File Offset: 0x00020E68
		public double DialogTitleFontSize
		{
			get
			{
				return (double)base.GetValue(BaseMetroDialog.DialogTitleFontSizeProperty);
			}
			set
			{
				base.SetValue(BaseMetroDialog.DialogTitleFontSizeProperty, value);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00022C7B File Offset: 0x00020E7B
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x00022C8D File Offset: 0x00020E8D
		public double DialogMessageFontSize
		{
			get
			{
				return (double)base.GetValue(BaseMetroDialog.DialogMessageFontSizeProperty);
			}
			set
			{
				base.SetValue(BaseMetroDialog.DialogMessageFontSizeProperty, value);
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00022CA0 File Offset: 0x00020EA0
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x00022CA8 File Offset: 0x00020EA8
		internal SizeChangedEventHandler SizeChangedHandler { get; set; }

		// Token: 0x060008B2 RID: 2226 RVA: 0x00022CB4 File Offset: 0x00020EB4
		static BaseMetroDialog()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseMetroDialog), new FrameworkPropertyMetadata(typeof(BaseMetroDialog)));
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00022DCB File Offset: 0x00020FCB
		protected BaseMetroDialog(MetroWindow owningWindow, MetroDialogSettings settings)
		{
			this.Initialize(owningWindow, settings);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00022DDB File Offset: 0x00020FDB
		protected BaseMetroDialog() : this(null, new MetroDialogSettings())
		{
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00022DE9 File Offset: 0x00020FE9
		protected virtual MetroDialogSettings ConfigureSettings(MetroDialogSettings settings)
		{
			return settings;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00022DEC File Offset: 0x00020FEC
		private void Initialize(MetroWindow owningWindow, MetroDialogSettings settings)
		{
			this.OwningWindow = owningWindow;
			this.DialogSettings = this.ConfigureSettings(settings ?? (((owningWindow != null) ? owningWindow.MetroDialogOptions : null) ?? new MetroDialogSettings()));
			MetroDialogSettings dialogSettings = this.DialogSettings;
			if (((dialogSettings != null) ? dialogSettings.CustomResourceDictionary : null) != null)
			{
				base.Resources.MergedDictionaries.Add(this.DialogSettings.CustomResourceDictionary);
			}
			this.HandleThemeChange();
			base.Loaded += this.BaseMetroDialogLoaded;
			base.Unloaded += this.BaseMetroDialogUnloaded;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00022E7F File Offset: 0x0002107F
		private void BaseMetroDialogLoaded(object sender, RoutedEventArgs e)
		{
			ThemeManager.IsThemeChanged -= this.ThemeManagerIsThemeChanged;
			ThemeManager.IsThemeChanged += this.ThemeManagerIsThemeChanged;
			this.OnLoaded();
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00022EA9 File Offset: 0x000210A9
		private void BaseMetroDialogUnloaded(object sender, RoutedEventArgs e)
		{
			ThemeManager.IsThemeChanged -= this.ThemeManagerIsThemeChanged;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00022EBC File Offset: 0x000210BC
		private void ThemeManagerIsThemeChanged(object sender, OnThemeChangedEventArgs e)
		{
			this.HandleThemeChange();
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00022EC4 File Offset: 0x000210C4
		private static object TryGetResource(Accent accent, AppTheme theme, string key)
		{
			if (accent == null || theme == null)
			{
				return null;
			}
			object result = theme.Resources[key];
			object obj = accent.Resources[key];
			if (obj != null)
			{
				return obj;
			}
			return result;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00022EFC File Offset: 0x000210FC
		internal void HandleThemeChange()
		{
			Tuple<AppTheme, Accent> tuple = BaseMetroDialog.DetectTheme(this);
			if (DesignerProperties.GetIsInDesignMode(this) || tuple == null)
			{
				return;
			}
			Accent item = tuple.Item2;
			AppTheme appTheme = tuple.Item1;
			if (this.DialogSettings != null)
			{
				switch (this.DialogSettings.ColorScheme)
				{
				case MetroDialogColorScheme.Theme:
					ThemeManager.ChangeAppStyle(base.Resources, item, appTheme);
					base.SetValue(Control.BackgroundProperty, BaseMetroDialog.TryGetResource(item, appTheme, "WhiteColorBrush"));
					base.SetValue(Control.ForegroundProperty, BaseMetroDialog.TryGetResource(item, appTheme, "BlackBrush"));
					break;
				case MetroDialogColorScheme.Accented:
					ThemeManager.ChangeAppStyle(base.Resources, item, appTheme);
					base.SetValue(Control.BackgroundProperty, BaseMetroDialog.TryGetResource(item, appTheme, "HighlightBrush"));
					base.SetValue(Control.ForegroundProperty, BaseMetroDialog.TryGetResource(item, appTheme, "IdealForegroundColorBrush"));
					break;
				case MetroDialogColorScheme.Inverted:
					appTheme = ThemeManager.GetInverseAppTheme(appTheme);
					if (appTheme == null)
					{
						throw new InvalidOperationException("The inverse dialog theme only works if the window theme abides the naming convention. See ThemeManager.GetInverseAppTheme for more infos");
					}
					ThemeManager.ChangeAppStyle(base.Resources, item, appTheme);
					base.SetValue(Control.BackgroundProperty, BaseMetroDialog.TryGetResource(item, appTheme, "WhiteColorBrush"));
					base.SetValue(Control.ForegroundProperty, BaseMetroDialog.TryGetResource(item, appTheme, "BlackBrush"));
					break;
				}
			}
			if (this.ParentDialogWindow != null)
			{
				this.ParentDialogWindow.SetValue(Control.BackgroundProperty, base.Background);
				object obj = BaseMetroDialog.TryGetResource(item, appTheme, "AccentColorBrush");
				if (obj != null)
				{
					this.ParentDialogWindow.SetValue(MetroWindow.GlowBrushProperty, obj);
				}
			}
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00023067 File Offset: 0x00021267
		protected virtual void OnLoaded()
		{
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0002306C File Offset: 0x0002126C
		private static Tuple<AppTheme, Accent> DetectTheme(BaseMetroDialog dialog)
		{
			if (dialog == null)
			{
				return null;
			}
			MetroWindow metroWindow = dialog.OwningWindow ?? dialog.TryFindParent<MetroWindow>();
			Tuple<AppTheme, Accent> tuple = (metroWindow != null) ? ThemeManager.DetectAppStyle(metroWindow) : null;
			if (((tuple != null) ? tuple.Item2 : null) != null)
			{
				return tuple;
			}
			if (Application.Current != null)
			{
				MetroWindow metroWindow2 = Application.Current.MainWindow as MetroWindow;
				tuple = ((metroWindow2 != null) ? ThemeManager.DetectAppStyle(metroWindow2) : null);
				if (((tuple != null) ? tuple.Item2 : null) != null)
				{
					return tuple;
				}
				tuple = ThemeManager.DetectAppStyle(Application.Current);
				if (((tuple != null) ? tuple.Item2 : null) != null)
				{
					return tuple;
				}
			}
			return null;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x000230FC File Offset: 0x000212FC
		public Task WaitForLoadAsync()
		{
			base.Dispatcher.VerifyAccess();
			if (base.IsLoaded)
			{
				return new Task(delegate()
				{
				});
			}
			if (!this.DialogSettings.AnimateShow)
			{
				base.Opacity = 1.0;
			}
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			RoutedEventHandler handler = null;
			handler = delegate(object sender, RoutedEventArgs args)
			{
				this.Loaded -= handler;
				this.Focus();
				tcs.TrySetResult(null);
			};
			base.Loaded += handler;
			return tcs.Task;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x000231A8 File Offset: 0x000213A8
		public Task RequestCloseAsync()
		{
			if (!this.OnRequestClose())
			{
				return Task.Factory.StartNew(delegate()
				{
				});
			}
			if (this.ParentDialogWindow == null)
			{
				return this.OwningWindow.HideMetroDialogAsync(this, null);
			}
			return this._WaitForCloseAsync().ContinueWith(delegate(Task x)
			{
				this.ParentDialogWindow.Dispatcher.Invoke(delegate()
				{
					this.ParentDialogWindow.Close();
				});
			});
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00023214 File Offset: 0x00021414
		protected internal virtual void OnShown()
		{
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00023216 File Offset: 0x00021416
		protected internal virtual void OnClose()
		{
			Window parentDialogWindow = this.ParentDialogWindow;
			if (parentDialogWindow == null)
			{
				return;
			}
			parentDialogWindow.Close();
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00023228 File Offset: 0x00021428
		protected internal virtual bool OnRequestClose()
		{
			return true;
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060008C3 RID: 2243 RVA: 0x0002322B File Offset: 0x0002142B
		// (set) Token: 0x060008C4 RID: 2244 RVA: 0x00023233 File Offset: 0x00021433
		protected internal Window ParentDialogWindow { get; internal set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0002323C File Offset: 0x0002143C
		// (set) Token: 0x060008C6 RID: 2246 RVA: 0x00023244 File Offset: 0x00021444
		protected internal MetroWindow OwningWindow { get; internal set; }

		// Token: 0x060008C7 RID: 2247 RVA: 0x00023250 File Offset: 0x00021450
		public Task WaitUntilUnloadedAsync()
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			base.Unloaded += delegate(object s, RoutedEventArgs e)
			{
				tcs.TrySetResult(null);
			};
			return tcs.Task;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0002328C File Offset: 0x0002148C
		public Task _WaitForCloseAsync()
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			if (this.DialogSettings.AnimateHide)
			{
				Storyboard closingStoryboard = base.TryFindResource("DialogCloseStoryboard") as Storyboard;
				if (closingStoryboard == null)
				{
					throw new InvalidOperationException("Unable to find the dialog closing storyboard. Did you forget to add BaseMetroDialog.xaml to your merged dictionaries?");
				}
				EventHandler handler = null;
				handler = delegate(object sender, EventArgs args)
				{
					closingStoryboard.Completed -= handler;
					tcs.TrySetResult(null);
				};
				closingStoryboard = closingStoryboard.Clone();
				closingStoryboard.Completed += handler;
				closingStoryboard.Begin(this);
			}
			else
			{
				base.Opacity = 0.0;
				tcs.TrySetResult(null);
			}
			return tcs.Task;
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0002335D File Offset: 0x0002155D
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new MetroDialogAutomationPeer(this);
		}

		// Token: 0x040003E8 RID: 1000
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(BaseMetroDialog), new PropertyMetadata(null));

		// Token: 0x040003E9 RID: 1001
		public static readonly DependencyProperty DialogTopProperty = DependencyProperty.Register("DialogTop", typeof(object), typeof(BaseMetroDialog), new PropertyMetadata(null));

		// Token: 0x040003EA RID: 1002
		public static readonly DependencyProperty DialogBottomProperty = DependencyProperty.Register("DialogBottom", typeof(object), typeof(BaseMetroDialog), new PropertyMetadata(null));

		// Token: 0x040003EB RID: 1003
		public static readonly DependencyProperty DialogTitleFontSizeProperty = DependencyProperty.Register("DialogTitleFontSize", typeof(double), typeof(BaseMetroDialog), new PropertyMetadata(26.0));

		// Token: 0x040003EC RID: 1004
		public static readonly DependencyProperty DialogMessageFontSizeProperty = DependencyProperty.Register("DialogMessageFontSize", typeof(double), typeof(BaseMetroDialog), new PropertyMetadata(15.0));
	}
}
