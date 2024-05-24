using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000031 RID: 49
	[TemplatePart(Name = "PART_Root", Type = typeof(FrameworkElement))]
	[TemplatePart(Name = "PART_Header", Type = typeof(FrameworkElement))]
	[TemplatePart(Name = "PART_Content", Type = typeof(FrameworkElement))]
	public class Flyout : HeaderedContentControl
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600019D RID: 413 RVA: 0x00007F8C File Offset: 0x0000618C
		// (remove) Token: 0x0600019E RID: 414 RVA: 0x00007F9A File Offset: 0x0000619A
		public event RoutedEventHandler IsOpenChanged
		{
			add
			{
				base.AddHandler(Flyout.IsOpenChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(Flyout.IsOpenChangedEvent, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600019F RID: 415 RVA: 0x00007FA8 File Offset: 0x000061A8
		// (remove) Token: 0x060001A0 RID: 416 RVA: 0x00007FB6 File Offset: 0x000061B6
		public event RoutedEventHandler ClosingFinished
		{
			add
			{
				base.AddHandler(Flyout.ClosingFinishedEvent, value);
			}
			remove
			{
				base.RemoveHandler(Flyout.ClosingFinishedEvent, value);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00007FC4 File Offset: 0x000061C4
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00007FCC File Offset: 0x000061CC
		internal PropertyChangeNotifier IsOpenPropertyChangeNotifier { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00007FD5 File Offset: 0x000061D5
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00007FDD File Offset: 0x000061DD
		internal PropertyChangeNotifier ThemePropertyChangeNotifier { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00007FE6 File Offset: 0x000061E6
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00007FF8 File Offset: 0x000061F8
		public bool AreAnimationsEnabled
		{
			get
			{
				return (bool)base.GetValue(Flyout.AreAnimationsEnabledProperty);
			}
			set
			{
				base.SetValue(Flyout.AreAnimationsEnabledProperty, value);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000800B File Offset: 0x0000620B
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x0000801D File Offset: 0x0000621D
		public Visibility TitleVisibility
		{
			get
			{
				return (Visibility)base.GetValue(Flyout.TitleVisibilityProperty);
			}
			set
			{
				base.SetValue(Flyout.TitleVisibilityProperty, value);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00008030 File Offset: 0x00006230
		// (set) Token: 0x060001AA RID: 426 RVA: 0x00008042 File Offset: 0x00006242
		public Visibility CloseButtonVisibility
		{
			get
			{
				return (Visibility)base.GetValue(Flyout.CloseButtonVisibilityProperty);
			}
			set
			{
				base.SetValue(Flyout.CloseButtonVisibilityProperty, value);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00008055 File Offset: 0x00006255
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00008067 File Offset: 0x00006267
		public bool CloseButtonIsCancel
		{
			get
			{
				return (bool)base.GetValue(Flyout.CloseButtonIsCancelProperty);
			}
			set
			{
				base.SetValue(Flyout.CloseButtonIsCancelProperty, value);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000807A File Offset: 0x0000627A
		// (set) Token: 0x060001AE RID: 430 RVA: 0x0000808C File Offset: 0x0000628C
		public ICommand CloseCommand
		{
			get
			{
				return (ICommand)base.GetValue(Flyout.CloseCommandProperty);
			}
			set
			{
				base.SetValue(Flyout.CloseCommandProperty, value);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000809A File Offset: 0x0000629A
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x000080A7 File Offset: 0x000062A7
		public object CloseCommandParameter
		{
			get
			{
				return base.GetValue(Flyout.CloseCommandParameterProperty);
			}
			set
			{
				base.SetValue(Flyout.CloseCommandParameterProperty, value);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000080B5 File Offset: 0x000062B5
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x000080C7 File Offset: 0x000062C7
		[Obsolete("This property will be deleted in the next release. Please use the new CloseFlyoutAction trigger.")]
		internal ICommand InternalCloseCommand
		{
			get
			{
				return (ICommand)base.GetValue(Flyout.InternalCloseCommandProperty);
			}
			set
			{
				base.SetValue(Flyout.InternalCloseCommandProperty, value);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x000080D5 File Offset: 0x000062D5
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x000080E7 File Offset: 0x000062E7
		public bool IsOpen
		{
			get
			{
				return (bool)base.GetValue(Flyout.IsOpenProperty);
			}
			set
			{
				base.SetValue(Flyout.IsOpenProperty, value);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x000080FA File Offset: 0x000062FA
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x0000810C File Offset: 0x0000630C
		public bool AnimateOnPositionChange
		{
			get
			{
				return (bool)base.GetValue(Flyout.AnimateOnPositionChangeProperty);
			}
			set
			{
				base.SetValue(Flyout.AnimateOnPositionChangeProperty, value);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000811F File Offset: 0x0000631F
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00008131 File Offset: 0x00006331
		public bool AnimateOpacity
		{
			get
			{
				return (bool)base.GetValue(Flyout.AnimateOpacityProperty);
			}
			set
			{
				base.SetValue(Flyout.AnimateOpacityProperty, value);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00008144 File Offset: 0x00006344
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00008156 File Offset: 0x00006356
		public bool IsPinned
		{
			get
			{
				return (bool)base.GetValue(Flyout.IsPinnedProperty);
			}
			set
			{
				base.SetValue(Flyout.IsPinnedProperty, value);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00008169 File Offset: 0x00006369
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000817B File Offset: 0x0000637B
		public MouseButton ExternalCloseButton
		{
			get
			{
				return (MouseButton)base.GetValue(Flyout.ExternalCloseButtonProperty);
			}
			set
			{
				base.SetValue(Flyout.ExternalCloseButtonProperty, value);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000818E File Offset: 0x0000638E
		// (set) Token: 0x060001BE RID: 446 RVA: 0x000081A0 File Offset: 0x000063A0
		public bool IsModal
		{
			get
			{
				return (bool)base.GetValue(Flyout.IsModalProperty);
			}
			set
			{
				base.SetValue(Flyout.IsModalProperty, value);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001BF RID: 447 RVA: 0x000081B3 File Offset: 0x000063B3
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x000081C5 File Offset: 0x000063C5
		public Position Position
		{
			get
			{
				return (Position)base.GetValue(Flyout.PositionProperty);
			}
			set
			{
				base.SetValue(Flyout.PositionProperty, value);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x000081D8 File Offset: 0x000063D8
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x000081EA File Offset: 0x000063EA
		public FlyoutTheme Theme
		{
			get
			{
				return (FlyoutTheme)base.GetValue(Flyout.ThemeProperty);
			}
			set
			{
				base.SetValue(Flyout.ThemeProperty, value);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000081FD File Offset: 0x000063FD
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x0000820F File Offset: 0x0000640F
		public FrameworkElement FocusedElement
		{
			get
			{
				return (FrameworkElement)base.GetValue(Flyout.FocusedElementProperty);
			}
			set
			{
				base.SetValue(Flyout.FocusedElementProperty, value);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x0000821D File Offset: 0x0000641D
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000822F File Offset: 0x0000642F
		public bool IsAutoCloseEnabled
		{
			get
			{
				return (bool)base.GetValue(Flyout.IsAutoCloseEnabledProperty);
			}
			set
			{
				base.SetValue(Flyout.IsAutoCloseEnabledProperty, value);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00008242 File Offset: 0x00006442
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00008254 File Offset: 0x00006454
		public long AutoCloseInterval
		{
			get
			{
				return (long)base.GetValue(Flyout.AutoCloseIntervalProperty);
			}
			set
			{
				base.SetValue(Flyout.AutoCloseIntervalProperty, value);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00008267 File Offset: 0x00006467
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00008279 File Offset: 0x00006479
		public bool AllowFocusElement
		{
			get
			{
				return (bool)base.GetValue(Flyout.AllowFocusElementProperty);
			}
			set
			{
				base.SetValue(Flyout.AllowFocusElementProperty, value);
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000828C File Offset: 0x0000648C
		static Flyout()
		{
			Flyout.IsOpenChangedEvent = EventManager.RegisterRoutedEvent("IsOpenChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Flyout));
			Flyout.ClosingFinishedEvent = EventManager.RegisterRoutedEvent("ClosingFinished", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Flyout));
			Flyout.PositionProperty = DependencyProperty.Register("Position", typeof(Position), typeof(Flyout), new PropertyMetadata(Position.Left, new PropertyChangedCallback(Flyout.PositionChanged)));
			Flyout.IsPinnedProperty = DependencyProperty.Register("IsPinned", typeof(bool), typeof(Flyout), new PropertyMetadata(true));
			Flyout.IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(Flyout), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Flyout.IsOpenedChanged)));
			Flyout.AnimateOnPositionChangeProperty = DependencyProperty.Register("AnimateOnPositionChange", typeof(bool), typeof(Flyout), new PropertyMetadata(true));
			Flyout.AnimateOpacityProperty = DependencyProperty.Register("AnimateOpacity", typeof(bool), typeof(Flyout), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(Flyout.AnimateOpacityChanged)));
			Flyout.IsModalProperty = DependencyProperty.Register("IsModal", typeof(bool), typeof(Flyout));
			Flyout.CloseCommandProperty = DependencyProperty.RegisterAttached("CloseCommand", typeof(ICommand), typeof(Flyout), new UIPropertyMetadata(null));
			Flyout.CloseCommandParameterProperty = DependencyProperty.Register("CloseCommandParameter", typeof(object), typeof(Flyout), new PropertyMetadata(null));
			Flyout.InternalCloseCommandProperty = DependencyProperty.Register("InternalCloseCommand", typeof(ICommand), typeof(Flyout));
			Flyout.ThemeProperty = DependencyProperty.Register("Theme", typeof(FlyoutTheme), typeof(Flyout), new FrameworkPropertyMetadata(FlyoutTheme.Dark, new PropertyChangedCallback(Flyout.ThemeChanged)));
			Flyout.ExternalCloseButtonProperty = DependencyProperty.Register("ExternalCloseButton", typeof(MouseButton), typeof(Flyout), new PropertyMetadata(MouseButton.Left));
			Flyout.CloseButtonVisibilityProperty = DependencyProperty.Register("CloseButtonVisibility", typeof(Visibility), typeof(Flyout), new FrameworkPropertyMetadata(Visibility.Visible));
			Flyout.CloseButtonIsCancelProperty = DependencyProperty.Register("CloseButtonIsCancel", typeof(bool), typeof(Flyout), new FrameworkPropertyMetadata(false));
			Flyout.TitleVisibilityProperty = DependencyProperty.Register("TitleVisibility", typeof(Visibility), typeof(Flyout), new FrameworkPropertyMetadata(Visibility.Visible));
			Flyout.AreAnimationsEnabledProperty = DependencyProperty.Register("AreAnimationsEnabled", typeof(bool), typeof(Flyout), new PropertyMetadata(true));
			Flyout.FocusedElementProperty = DependencyProperty.Register("FocusedElement", typeof(FrameworkElement), typeof(Flyout), new UIPropertyMetadata(null));
			Flyout.AllowFocusElementProperty = DependencyProperty.Register("AllowFocusElement", typeof(bool), typeof(Flyout), new PropertyMetadata(true));
			Flyout.IsAutoCloseEnabledProperty = DependencyProperty.Register("IsAutoCloseEnabled", typeof(bool), typeof(Flyout), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(Flyout.IsAutoCloseEnabledChanged)));
			Flyout.AutoCloseIntervalProperty = DependencyProperty.Register("AutoCloseInterval", typeof(long), typeof(Flyout), new FrameworkPropertyMetadata(5000L, new PropertyChangedCallback(Flyout.AutoCloseIntervalChanged)));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Flyout), new FrameworkPropertyMetadata(typeof(Flyout)));
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000869C File Offset: 0x0000689C
		public Flyout()
		{
			this.InternalCloseCommand = new CloseCommand(new Func<object, bool>(this.InternalCloseCommandCanExecute), new Action<object>(this.InternalCloseCommandExecuteAction));
			base.Loaded += delegate(object sender, RoutedEventArgs args)
			{
				this.UpdateFlyoutTheme();
			};
			this.InitializeAutoCloseTimer();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000086EA File Offset: 0x000068EA
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new FlyoutAutomationPeer(this);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000086F4 File Offset: 0x000068F4
		private void InternalCloseCommandExecuteAction(object o)
		{
			ICommand closeCommand = this.CloseCommand;
			if (closeCommand == null)
			{
				base.SetCurrentValue(Flyout.IsOpenProperty, false);
				return;
			}
			object parameter = this.CloseCommandParameter ?? this;
			if (closeCommand.CanExecute(parameter))
			{
				closeCommand.Execute(parameter);
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000873C File Offset: 0x0000693C
		private bool InternalCloseCommandCanExecute(object o)
		{
			ICommand closeCommand = this.CloseCommand;
			return closeCommand == null || closeCommand.CanExecute(this.CloseCommandParameter ?? this);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00008768 File Offset: 0x00006968
		private void InitializeAutoCloseTimer()
		{
			this.StopAutoCloseTimer();
			this.autoCloseTimer = new DispatcherTimer();
			this.autoCloseTimer.Tick += this.AutoCloseTimerCallback;
			this.autoCloseTimer.Interval = TimeSpan.FromMilliseconds((double)this.AutoCloseInterval);
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000087B4 File Offset: 0x000069B4
		private MetroWindow ParentWindow
		{
			get
			{
				MetroWindow result;
				if ((result = this.parentWindow) == null)
				{
					result = (this.parentWindow = this.TryFindParent<MetroWindow>());
				}
				return result;
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000087DC File Offset: 0x000069DC
		private void UpdateFlyoutTheme()
		{
			FlyoutsControl flyoutsControl = this.TryFindParent<FlyoutsControl>();
			if (DesignerProperties.GetIsInDesignMode(this))
			{
				base.Visibility = ((flyoutsControl != null) ? Visibility.Collapsed : Visibility.Visible);
			}
			MetroWindow metroWindow = this.ParentWindow;
			if (metroWindow != null)
			{
				Tuple<AppTheme, Accent> tuple = Flyout.DetectTheme(this);
				if (((tuple != null) ? tuple.Item2 : null) != null)
				{
					Accent item = tuple.Item2;
					this.ChangeFlyoutTheme(item, tuple.Item1);
				}
				if (flyoutsControl != null && this.IsOpen)
				{
					flyoutsControl.HandleFlyoutStatusChange(this, metroWindow);
				}
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000884C File Offset: 0x00006A4C
		internal void ChangeFlyoutTheme(Accent windowAccent, AppTheme windowTheme)
		{
			switch (this.Theme)
			{
			case FlyoutTheme.Adapt:
				ThemeManager.ChangeAppStyle(base.Resources, windowAccent, windowTheme);
				this.OverrideFlyoutResources(base.Resources, false);
				return;
			case FlyoutTheme.Inverse:
			{
				AppTheme inverseAppTheme = ThemeManager.GetInverseAppTheme(windowTheme);
				if (inverseAppTheme == null)
				{
					throw new InvalidOperationException("The inverse flyout theme only works if the window theme abides the naming convention. See ThemeManager.GetInverseAppTheme for more infos");
				}
				ThemeManager.ChangeAppStyle(base.Resources, windowAccent, inverseAppTheme);
				this.OverrideFlyoutResources(base.Resources, false);
				return;
			}
			case FlyoutTheme.Dark:
				ThemeManager.ChangeAppStyle(base.Resources, windowAccent, ThemeManager.GetAppTheme("BaseDark"));
				this.OverrideFlyoutResources(base.Resources, false);
				return;
			case FlyoutTheme.Light:
				ThemeManager.ChangeAppStyle(base.Resources, windowAccent, ThemeManager.GetAppTheme("BaseLight"));
				this.OverrideFlyoutResources(base.Resources, false);
				return;
			case FlyoutTheme.Accent:
				ThemeManager.ChangeAppStyle(base.Resources, windowAccent, windowTheme);
				this.OverrideFlyoutResources(base.Resources, true);
				return;
			default:
				return;
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00008928 File Offset: 0x00006B28
		private void OverrideFlyoutResources(ResourceDictionary resources, bool accent = false)
		{
			string key = accent ? "HighlightColor" : "FlyoutColor";
			resources.BeginInit();
			Color color = (Color)resources[key];
			resources["WhiteColor"] = color;
			resources["FlyoutColor"] = color;
			SolidColorBrush solidColorBrush = new SolidColorBrush(color);
			solidColorBrush.Freeze();
			resources["FlyoutBackgroundBrush"] = solidColorBrush;
			resources["ControlBackgroundBrush"] = solidColorBrush;
			resources["WhiteBrush"] = solidColorBrush;
			resources["WhiteColorBrush"] = solidColorBrush;
			resources["DisabledWhiteBrush"] = solidColorBrush;
			resources["WindowBackgroundBrush"] = solidColorBrush;
			resources[SystemColors.WindowBrushKey] = solidColorBrush;
			if (accent)
			{
				color = (Color)resources["IdealForegroundColor"];
				solidColorBrush = new SolidColorBrush(color);
				solidColorBrush.Freeze();
				resources["FlyoutForegroundBrush"] = solidColorBrush;
				resources["TextBrush"] = solidColorBrush;
				resources["LabelTextBrush"] = solidColorBrush;
				if (resources.Contains("AccentBaseColor"))
				{
					color = (Color)resources["AccentBaseColor"];
				}
				else
				{
					Color color2 = (Color)resources["AccentColor"];
					color = Color.FromArgb(byte.MaxValue, color2.R, color2.G, color2.B);
				}
				solidColorBrush = new SolidColorBrush(color);
				solidColorBrush.Freeze();
				resources["HighlightColor"] = color;
				resources["HighlightBrush"] = solidColorBrush;
			}
			resources.EndInit();
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00008AA4 File Offset: 0x00006CA4
		private static Tuple<AppTheme, Accent> DetectTheme(Flyout flyout)
		{
			if (flyout == null)
			{
				return null;
			}
			MetroWindow metroWindow = flyout.ParentWindow;
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

		// Token: 0x060001D6 RID: 470 RVA: 0x00008B2C File Offset: 0x00006D2C
		private void UpdateOpacityChange()
		{
			if (this.flyoutRoot == null || this.fadeOutFrame == null || DesignerProperties.GetIsInDesignMode(this))
			{
				return;
			}
			if (!this.AnimateOpacity)
			{
				this.fadeOutFrame.Value = 1.0;
				this.flyoutRoot.Opacity = 1.0;
				return;
			}
			this.fadeOutFrame.Value = 0.0;
			if (!this.IsOpen)
			{
				this.flyoutRoot.Opacity = 0.0;
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00008BB4 File Offset: 0x00006DB4
		private static void IsOpenedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Flyout flyout = (Flyout)dependencyObject;
			Action method = delegate()
			{
				if (e.NewValue != e.OldValue)
				{
					if (flyout.AreAnimationsEnabled)
					{
						if ((bool)e.NewValue)
						{
							if (flyout.hideStoryboard != null)
							{
								flyout.hideStoryboard.Completed -= flyout.HideStoryboardCompleted;
							}
							flyout.Visibility = Visibility.Visible;
							flyout.ApplyAnimation(flyout.Position, flyout.AnimateOpacity, true);
							flyout.TryFocusElement();
							if (flyout.IsAutoCloseEnabled)
							{
								flyout.StartAutoCloseTimer();
							}
						}
						else
						{
							flyout.StopAutoCloseTimer();
							if (flyout.hideStoryboard != null)
							{
								flyout.hideStoryboard.Completed += flyout.HideStoryboardCompleted;
							}
							else
							{
								flyout.Hide();
							}
						}
						VisualStateManager.GoToState(flyout, (!(bool)e.NewValue) ? "Hide" : "Show", true);
					}
					else
					{
						if ((bool)e.NewValue)
						{
							flyout.Visibility = Visibility.Visible;
							flyout.TryFocusElement();
							if (flyout.IsAutoCloseEnabled)
							{
								flyout.StartAutoCloseTimer();
							}
						}
						else
						{
							flyout.StopAutoCloseTimer();
							flyout.Hide();
						}
						VisualStateManager.GoToState(flyout, (!(bool)e.NewValue) ? "HideDirect" : "ShowDirect", true);
					}
				}
				flyout.RaiseEvent(new RoutedEventArgs(Flyout.IsOpenChangedEvent));
			};
			flyout.Dispatcher.BeginInvoke(DispatcherPriority.Background, method);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00008BF8 File Offset: 0x00006DF8
		private static void IsAutoCloseEnabledChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Flyout flyout = (Flyout)dependencyObject;
			Action method = delegate()
			{
				if (e.NewValue != e.OldValue)
				{
					if ((bool)e.NewValue)
					{
						if (flyout.IsOpen)
						{
							flyout.StartAutoCloseTimer();
							return;
						}
					}
					else
					{
						flyout.StopAutoCloseTimer();
					}
				}
			};
			flyout.Dispatcher.BeginInvoke(DispatcherPriority.Background, method);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00008C3C File Offset: 0x00006E3C
		private static void AutoCloseIntervalChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Flyout flyout = (Flyout)dependencyObject;
			Action method = delegate()
			{
				if (e.NewValue != e.OldValue)
				{
					flyout.InitializeAutoCloseTimer();
					if (flyout.IsAutoCloseEnabled && flyout.IsOpen)
					{
						flyout.StartAutoCloseTimer();
					}
				}
			};
			flyout.Dispatcher.BeginInvoke(DispatcherPriority.Background, method);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00008C80 File Offset: 0x00006E80
		private void StartAutoCloseTimer()
		{
			this.StopAutoCloseTimer();
			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				this.autoCloseTimer.Start();
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00008C9B File Offset: 0x00006E9B
		private void StopAutoCloseTimer()
		{
			if (this.autoCloseTimer != null && this.autoCloseTimer.IsEnabled)
			{
				this.autoCloseTimer.Stop();
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00008CBD File Offset: 0x00006EBD
		private void AutoCloseTimerCallback(object sender, EventArgs e)
		{
			this.StopAutoCloseTimer();
			if (this.IsOpen && this.IsAutoCloseEnabled)
			{
				this.IsOpen = false;
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00008CDC File Offset: 0x00006EDC
		private void HideStoryboardCompleted(object sender, EventArgs e)
		{
			this.hideStoryboard.Completed -= this.HideStoryboardCompleted;
			this.Hide();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00008CFB File Offset: 0x00006EFB
		private void Hide()
		{
			base.Visibility = Visibility.Hidden;
			base.RaiseEvent(new RoutedEventArgs(Flyout.ClosingFinishedEvent));
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00008D14 File Offset: 0x00006F14
		private void TryFocusElement()
		{
			if (this.AllowFocusElement)
			{
				base.Focus();
				if (this.FocusedElement != null)
				{
					this.FocusedElement.Focus();
					return;
				}
				if (this.flyoutContent == null || !this.flyoutContent.MoveFocus(new TraversalRequest(FocusNavigationDirection.First)))
				{
					FrameworkElement frameworkElement = this.flyoutHeader;
					if (frameworkElement == null)
					{
						return;
					}
					frameworkElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00008D77 File Offset: 0x00006F77
		private static void ThemeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			((Flyout)dependencyObject).UpdateFlyoutTheme();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00008D84 File Offset: 0x00006F84
		private static void AnimateOpacityChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			((Flyout)dependencyObject).UpdateOpacityChange();
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008D94 File Offset: 0x00006F94
		private static void PositionChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			Flyout flyout = (Flyout)dependencyObject;
			bool isOpen = flyout.IsOpen;
			if (isOpen && flyout.AnimateOnPositionChange)
			{
				flyout.ApplyAnimation((Position)e.NewValue, flyout.AnimateOpacity, true);
				VisualStateManager.GoToState(flyout, "Hide", true);
			}
			else
			{
				flyout.ApplyAnimation((Position)e.NewValue, flyout.AnimateOpacity, false);
			}
			if (isOpen && flyout.AnimateOnPositionChange)
			{
				flyout.ApplyAnimation((Position)e.NewValue, flyout.AnimateOpacity, true);
				VisualStateManager.GoToState(flyout, "Show", true);
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00008E2C File Offset: 0x0000702C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.flyoutRoot = (base.GetTemplateChild("PART_Root") as FrameworkElement);
			if (this.flyoutRoot == null)
			{
				return;
			}
			this.flyoutHeader = (base.GetTemplateChild("PART_Header") as FrameworkElement);
			FrameworkElement frameworkElement = this.flyoutHeader;
			if (frameworkElement != null)
			{
				frameworkElement.ApplyTemplate();
			}
			this.flyoutContent = (base.GetTemplateChild("PART_Content") as FrameworkElement);
			IMetroThumb metroThumb = this.flyoutHeader as IMetroThumb;
			if (metroThumb != null)
			{
				metroThumb.DragStarted -= this.WindowTitleThumbOnDragStarted;
				metroThumb.DragCompleted -= this.WindowTitleThumbOnDragCompleted;
				metroThumb.PreviewMouseLeftButtonUp -= this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				metroThumb.DragDelta -= this.WindowTitleThumbMoveOnDragDelta;
				metroThumb.MouseDoubleClick -= this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				metroThumb.MouseRightButtonUp -= this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
				if (this.TryFindParent<FlyoutsControl>() != null)
				{
					metroThumb.DragStarted += this.WindowTitleThumbOnDragStarted;
					metroThumb.DragCompleted += this.WindowTitleThumbOnDragCompleted;
					metroThumb.PreviewMouseLeftButtonUp += this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
					metroThumb.DragDelta += this.WindowTitleThumbMoveOnDragDelta;
					metroThumb.MouseDoubleClick += this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
					metroThumb.MouseRightButtonUp += this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
				}
			}
			this.hideStoryboard = (base.GetTemplateChild("HideStoryboard") as Storyboard);
			this.hideFrame = (base.GetTemplateChild("hideFrame") as SplineDoubleKeyFrame);
			this.hideFrameY = (base.GetTemplateChild("hideFrameY") as SplineDoubleKeyFrame);
			this.showFrame = (base.GetTemplateChild("showFrame") as SplineDoubleKeyFrame);
			this.showFrameY = (base.GetTemplateChild("showFrameY") as SplineDoubleKeyFrame);
			this.fadeOutFrame = (base.GetTemplateChild("fadeOutFrame") as SplineDoubleKeyFrame);
			if (this.hideFrame == null || this.showFrame == null || this.hideFrameY == null || this.showFrameY == null || this.fadeOutFrame == null)
			{
				return;
			}
			this.ApplyAnimation(this.Position, this.AnimateOpacity, true);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000904E File Offset: 0x0000724E
		private void WindowTitleThumbOnDragCompleted(object sender, DragCompletedEventArgs e)
		{
			this.dragStartedMousePos = null;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000905C File Offset: 0x0000725C
		private void WindowTitleThumbOnDragStarted(object sender, DragStartedEventArgs e)
		{
			if (this.ParentWindow != null && this.Position != Position.Bottom)
			{
				this.dragStartedMousePos = new Point?(Mouse.GetPosition((IInputElement)sender));
				return;
			}
			this.dragStartedMousePos = null;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00009094 File Offset: 0x00007294
		protected internal void CleanUp(FlyoutsControl flyoutsControl)
		{
			IMetroThumb metroThumb = this.flyoutHeader as IMetroThumb;
			if (metroThumb != null)
			{
				metroThumb.DragStarted -= this.WindowTitleThumbOnDragStarted;
				metroThumb.DragCompleted -= this.WindowTitleThumbOnDragCompleted;
				metroThumb.PreviewMouseLeftButtonUp -= this.WindowTitleThumbOnPreviewMouseLeftButtonUp;
				metroThumb.DragDelta -= this.WindowTitleThumbMoveOnDragDelta;
				metroThumb.MouseDoubleClick -= this.WindowTitleThumbChangeWindowStateOnMouseDoubleClick;
				metroThumb.MouseRightButtonUp -= this.WindowTitleThumbSystemMenuOnMouseRightButtonUp;
			}
			this.parentWindow = null;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00009124 File Offset: 0x00007324
		private void WindowTitleThumbOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			MetroWindow metroWindow = this.ParentWindow;
			if (metroWindow != null && this.Position != Position.Bottom)
			{
				MetroWindow.DoWindowTitleThumbOnPreviewMouseLeftButtonUp(metroWindow, e);
			}
			this.dragStartedMousePos = null;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00009158 File Offset: 0x00007358
		private void WindowTitleThumbMoveOnDragDelta(object sender, DragDeltaEventArgs dragDeltaEventArgs)
		{
			MetroWindow metroWindow = this.ParentWindow;
			if (metroWindow != null && this.Position != Position.Bottom)
			{
				MetroWindow.DoWindowTitleThumbMoveOnDragDelta(sender as IMetroThumb, metroWindow, dragDeltaEventArgs);
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00009188 File Offset: 0x00007388
		private void WindowTitleThumbChangeWindowStateOnMouseDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			MetroWindow metroWindow = this.ParentWindow;
			if (metroWindow != null && this.Position != Position.Bottom && Mouse.GetPosition((IInputElement)sender).Y <= (double)metroWindow.TitlebarHeight && metroWindow.TitlebarHeight > 0)
			{
				MetroWindow.DoWindowTitleThumbChangeWindowStateOnMouseDoubleClick(metroWindow, mouseButtonEventArgs);
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000091D4 File Offset: 0x000073D4
		private void WindowTitleThumbSystemMenuOnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			MetroWindow metroWindow = this.ParentWindow;
			if (metroWindow != null && this.Position != Position.Bottom && Mouse.GetPosition((IInputElement)sender).Y <= (double)metroWindow.TitlebarHeight && metroWindow.TitlebarHeight > 0)
			{
				MetroWindow.DoWindowTitleThumbSystemMenuOnMouseRightButtonUp(metroWindow, e);
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00009220 File Offset: 0x00007420
		internal void ApplyAnimation(Position position, bool animateOpacity, bool resetShowFrame = true)
		{
			if (this.flyoutRoot == null || this.hideFrame == null || this.showFrame == null || this.hideFrameY == null || this.showFrameY == null || this.fadeOutFrame == null)
			{
				return;
			}
			if (this.Position == Position.Left || this.Position == Position.Right)
			{
				this.showFrame.Value = 0.0;
			}
			if (this.Position == Position.Top || this.Position == Position.Bottom)
			{
				this.showFrameY.Value = 0.0;
			}
			if (!animateOpacity)
			{
				this.fadeOutFrame.Value = 1.0;
				this.flyoutRoot.Opacity = 1.0;
			}
			else
			{
				this.fadeOutFrame.Value = 0.0;
				if (!this.IsOpen)
				{
					this.flyoutRoot.Opacity = 0.0;
				}
			}
			switch (position)
			{
			case Position.Right:
				base.HorizontalAlignment = ((base.Margin.Left <= 0.0) ? ((base.HorizontalContentAlignment != HorizontalAlignment.Stretch) ? HorizontalAlignment.Right : base.HorizontalContentAlignment) : HorizontalAlignment.Stretch);
				base.VerticalAlignment = VerticalAlignment.Stretch;
				this.hideFrame.Value = this.flyoutRoot.ActualWidth + base.Margin.Right;
				if (resetShowFrame)
				{
					this.flyoutRoot.RenderTransform = new TranslateTransform(this.flyoutRoot.ActualWidth, 0.0);
					return;
				}
				break;
			case Position.Top:
				base.HorizontalAlignment = HorizontalAlignment.Stretch;
				base.VerticalAlignment = ((base.Margin.Bottom <= 0.0) ? ((base.VerticalContentAlignment != VerticalAlignment.Stretch) ? VerticalAlignment.Top : base.VerticalContentAlignment) : VerticalAlignment.Stretch);
				this.hideFrameY.Value = -this.flyoutRoot.ActualHeight - 1.0 - base.Margin.Top;
				if (resetShowFrame)
				{
					this.flyoutRoot.RenderTransform = new TranslateTransform(0.0, -this.flyoutRoot.ActualHeight - 1.0);
					return;
				}
				break;
			case Position.Bottom:
				base.HorizontalAlignment = HorizontalAlignment.Stretch;
				base.VerticalAlignment = ((base.Margin.Top <= 0.0) ? ((base.VerticalContentAlignment != VerticalAlignment.Stretch) ? VerticalAlignment.Bottom : base.VerticalContentAlignment) : VerticalAlignment.Stretch);
				this.hideFrameY.Value = this.flyoutRoot.ActualHeight + base.Margin.Bottom;
				if (resetShowFrame)
				{
					this.flyoutRoot.RenderTransform = new TranslateTransform(0.0, this.flyoutRoot.ActualHeight);
				}
				break;
			default:
				base.HorizontalAlignment = ((base.Margin.Right <= 0.0) ? ((base.HorizontalContentAlignment != HorizontalAlignment.Stretch) ? HorizontalAlignment.Left : base.HorizontalContentAlignment) : HorizontalAlignment.Stretch);
				base.VerticalAlignment = VerticalAlignment.Stretch;
				this.hideFrame.Value = -this.flyoutRoot.ActualWidth - base.Margin.Left;
				if (resetShowFrame)
				{
					this.flyoutRoot.RenderTransform = new TranslateTransform(-this.flyoutRoot.ActualWidth, 0.0);
					return;
				}
				break;
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000955C File Offset: 0x0000775C
		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			base.OnRenderSizeChanged(sizeInfo);
			if (!this.IsOpen)
			{
				return;
			}
			if (!sizeInfo.WidthChanged && !sizeInfo.HeightChanged)
			{
				return;
			}
			if (this.flyoutRoot == null || this.hideFrame == null || this.showFrame == null || this.hideFrameY == null || this.showFrameY == null)
			{
				return;
			}
			if (this.Position == Position.Left || this.Position == Position.Right)
			{
				this.showFrame.Value = 0.0;
			}
			if (this.Position == Position.Top || this.Position == Position.Bottom)
			{
				this.showFrameY.Value = 0.0;
			}
			switch (this.Position)
			{
			case Position.Right:
				this.hideFrame.Value = this.flyoutRoot.ActualWidth + base.Margin.Right;
				return;
			case Position.Top:
				this.hideFrameY.Value = -this.flyoutRoot.ActualHeight - 1.0 - base.Margin.Top;
				return;
			case Position.Bottom:
				this.hideFrameY.Value = this.flyoutRoot.ActualHeight + base.Margin.Bottom;
				return;
			default:
				this.hideFrame.Value = -this.flyoutRoot.ActualWidth - base.Margin.Left;
				return;
			}
		}

		// Token: 0x04000089 RID: 137
		public static readonly DependencyProperty PositionProperty;

		// Token: 0x0400008A RID: 138
		public static readonly DependencyProperty IsPinnedProperty;

		// Token: 0x0400008B RID: 139
		public static readonly DependencyProperty IsOpenProperty;

		// Token: 0x0400008C RID: 140
		public static readonly DependencyProperty AnimateOnPositionChangeProperty;

		// Token: 0x0400008D RID: 141
		public static readonly DependencyProperty AnimateOpacityProperty;

		// Token: 0x0400008E RID: 142
		public static readonly DependencyProperty IsModalProperty;

		// Token: 0x0400008F RID: 143
		public static readonly DependencyProperty CloseCommandProperty;

		// Token: 0x04000090 RID: 144
		public static readonly DependencyProperty CloseCommandParameterProperty;

		// Token: 0x04000091 RID: 145
		[Obsolete("This property will be deleted in the next release. Please use the new CloseFlyoutAction trigger.")]
		internal static readonly DependencyProperty InternalCloseCommandProperty;

		// Token: 0x04000092 RID: 146
		public static readonly DependencyProperty ThemeProperty;

		// Token: 0x04000093 RID: 147
		public static readonly DependencyProperty ExternalCloseButtonProperty;

		// Token: 0x04000094 RID: 148
		public static readonly DependencyProperty CloseButtonVisibilityProperty;

		// Token: 0x04000095 RID: 149
		public static readonly DependencyProperty CloseButtonIsCancelProperty;

		// Token: 0x04000096 RID: 150
		public static readonly DependencyProperty TitleVisibilityProperty;

		// Token: 0x04000097 RID: 151
		public static readonly DependencyProperty AreAnimationsEnabledProperty;

		// Token: 0x04000098 RID: 152
		public static readonly DependencyProperty FocusedElementProperty;

		// Token: 0x04000099 RID: 153
		public static readonly DependencyProperty AllowFocusElementProperty;

		// Token: 0x0400009A RID: 154
		public static readonly DependencyProperty IsAutoCloseEnabledProperty;

		// Token: 0x0400009B RID: 155
		public static readonly DependencyProperty AutoCloseIntervalProperty;

		// Token: 0x0400009E RID: 158
		private MetroWindow parentWindow;

		// Token: 0x0400009F RID: 159
		private DispatcherTimer autoCloseTimer;

		// Token: 0x040000A0 RID: 160
		private FrameworkElement flyoutRoot;

		// Token: 0x040000A1 RID: 161
		private Storyboard hideStoryboard;

		// Token: 0x040000A2 RID: 162
		private SplineDoubleKeyFrame hideFrame;

		// Token: 0x040000A3 RID: 163
		private SplineDoubleKeyFrame hideFrameY;

		// Token: 0x040000A4 RID: 164
		private SplineDoubleKeyFrame showFrame;

		// Token: 0x040000A5 RID: 165
		private SplineDoubleKeyFrame showFrameY;

		// Token: 0x040000A6 RID: 166
		private SplineDoubleKeyFrame fadeOutFrame;

		// Token: 0x040000A7 RID: 167
		private FrameworkElement flyoutHeader;

		// Token: 0x040000A8 RID: 168
		private FrameworkElement flyoutContent;

		// Token: 0x040000A9 RID: 169
		private Point? dragStartedMousePos;
	}
}
