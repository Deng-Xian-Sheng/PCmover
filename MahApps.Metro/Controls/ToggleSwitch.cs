using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000091 RID: 145
	[TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
	[TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
	[TemplatePart(Name = "Switch", Type = typeof(ToggleButton))]
	public class ToggleSwitch : HeaderedContentControl
	{
		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060007B3 RID: 1971 RVA: 0x0001F5BC File Offset: 0x0001D7BC
		// (remove) Token: 0x060007B4 RID: 1972 RVA: 0x0001F5F4 File Offset: 0x0001D7F4
		public event EventHandler<RoutedEventArgs> Checked;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060007B5 RID: 1973 RVA: 0x0001F62C File Offset: 0x0001D82C
		// (remove) Token: 0x060007B6 RID: 1974 RVA: 0x0001F664 File Offset: 0x0001D864
		public event EventHandler<RoutedEventArgs> Unchecked;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060007B7 RID: 1975 RVA: 0x0001F69C File Offset: 0x0001D89C
		// (remove) Token: 0x060007B8 RID: 1976 RVA: 0x0001F6D4 File Offset: 0x0001D8D4
		public event EventHandler<RoutedEventArgs> Indeterminate;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x060007B9 RID: 1977 RVA: 0x0001F70C File Offset: 0x0001D90C
		// (remove) Token: 0x060007BA RID: 1978 RVA: 0x0001F744 File Offset: 0x0001D944
		public event EventHandler<RoutedEventArgs> Click;

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0001F779 File Offset: 0x0001D979
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x0001F78B File Offset: 0x0001D98B
		[Bindable(true)]
		[Localizability(LocalizationCategory.Font)]
		public FontFamily HeaderFontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(ToggleSwitch.HeaderFontFamilyProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.HeaderFontFamilyProperty, value);
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0001F799 File Offset: 0x0001D999
		// (set) Token: 0x060007BE RID: 1982 RVA: 0x0001F7AB File Offset: 0x0001D9AB
		public string OnLabel
		{
			get
			{
				return (string)base.GetValue(ToggleSwitch.OnLabelProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.OnLabelProperty, value);
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x0001F7B9 File Offset: 0x0001D9B9
		// (set) Token: 0x060007C0 RID: 1984 RVA: 0x0001F7CB File Offset: 0x0001D9CB
		public string OffLabel
		{
			get
			{
				return (string)base.GetValue(ToggleSwitch.OffLabelProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.OffLabelProperty, value);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x0001F7D9 File Offset: 0x0001D9D9
		// (set) Token: 0x060007C2 RID: 1986 RVA: 0x0001F7EB File Offset: 0x0001D9EB
		[Obsolete("This property will be deleted in the next release. You should use OnSwitchBrush and OffSwitchBrush to change the switch's brushes.")]
		public Brush SwitchForeground
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitch.SwitchForegroundProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.SwitchForegroundProperty, value);
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0001F7F9 File Offset: 0x0001D9F9
		// (set) Token: 0x060007C4 RID: 1988 RVA: 0x0001F80B File Offset: 0x0001DA0B
		public Brush OnSwitchBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitch.OnSwitchBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.OnSwitchBrushProperty, value);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x0001F819 File Offset: 0x0001DA19
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x0001F82B File Offset: 0x0001DA2B
		public Brush OffSwitchBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitch.OffSwitchBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.OffSwitchBrushProperty, value);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0001F839 File Offset: 0x0001DA39
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x0001F84B File Offset: 0x0001DA4B
		public Brush ThumbIndicatorBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitch.ThumbIndicatorBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.ThumbIndicatorBrushProperty, value);
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x0001F859 File Offset: 0x0001DA59
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x0001F86B File Offset: 0x0001DA6B
		public Brush ThumbIndicatorDisabledBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitch.ThumbIndicatorDisabledBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.ThumbIndicatorDisabledBrushProperty, value);
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x0001F879 File Offset: 0x0001DA79
		// (set) Token: 0x060007CC RID: 1996 RVA: 0x0001F88B File Offset: 0x0001DA8B
		public double ThumbIndicatorWidth
		{
			get
			{
				return (double)base.GetValue(ToggleSwitch.ThumbIndicatorWidthProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.ThumbIndicatorWidthProperty, value);
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0001F89E File Offset: 0x0001DA9E
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x0001F8B0 File Offset: 0x0001DAB0
		public FlowDirection ContentDirection
		{
			get
			{
				return (FlowDirection)base.GetValue(ToggleSwitch.ContentDirectionProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.ContentDirectionProperty, value);
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0001F8C3 File Offset: 0x0001DAC3
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x0001F8D5 File Offset: 0x0001DAD5
		[Bindable(true)]
		[Category("MahApps.Metro")]
		public Thickness ContentPadding
		{
			get
			{
				return (Thickness)base.GetValue(ToggleSwitch.ContentPaddingProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.ContentPaddingProperty, value);
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x0001F8E8 File Offset: 0x0001DAE8
		// (set) Token: 0x060007D2 RID: 2002 RVA: 0x0001F8FA File Offset: 0x0001DAFA
		public Style ToggleSwitchButtonStyle
		{
			get
			{
				return (Style)base.GetValue(ToggleSwitch.ToggleSwitchButtonStyleProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.ToggleSwitchButtonStyleProperty, value);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0001F908 File Offset: 0x0001DB08
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x0001F91A File Offset: 0x0001DB1A
		[TypeConverter(typeof(NullableBoolConverter))]
		public bool? IsChecked
		{
			get
			{
				return (bool?)base.GetValue(ToggleSwitch.IsCheckedProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.IsCheckedProperty, value);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0001F92D File Offset: 0x0001DB2D
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x0001F93F File Offset: 0x0001DB3F
		public ICommand CheckChangedCommand
		{
			get
			{
				return (ICommand)base.GetValue(ToggleSwitch.CheckChangedCommandProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.CheckChangedCommandProperty, value);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x0001F94D File Offset: 0x0001DB4D
		// (set) Token: 0x060007D8 RID: 2008 RVA: 0x0001F95F File Offset: 0x0001DB5F
		public ICommand CheckedCommand
		{
			get
			{
				return (ICommand)base.GetValue(ToggleSwitch.CheckedCommandProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.CheckedCommandProperty, value);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x0001F96D File Offset: 0x0001DB6D
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x0001F97F File Offset: 0x0001DB7F
		public ICommand UnCheckedCommand
		{
			get
			{
				return (ICommand)base.GetValue(ToggleSwitch.UnCheckedCommandProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.UnCheckedCommandProperty, value);
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0001F98D File Offset: 0x0001DB8D
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x0001F99A File Offset: 0x0001DB9A
		public object CheckChangedCommandParameter
		{
			get
			{
				return base.GetValue(ToggleSwitch.CheckChangedCommandParameterProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.CheckChangedCommandParameterProperty, value);
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x0001F9A8 File Offset: 0x0001DBA8
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x0001F9B5 File Offset: 0x0001DBB5
		public object CheckedCommandParameter
		{
			get
			{
				return base.GetValue(ToggleSwitch.CheckedCommandParameterProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.CheckedCommandParameterProperty, value);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0001F9C3 File Offset: 0x0001DBC3
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x0001F9D0 File Offset: 0x0001DBD0
		public object UnCheckedCommandParameter
		{
			get
			{
				return base.GetValue(ToggleSwitch.UnCheckedCommandParameterProperty);
			}
			set
			{
				base.SetValue(ToggleSwitch.UnCheckedCommandParameterProperty, value);
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060007E1 RID: 2017 RVA: 0x0001F9E0 File Offset: 0x0001DBE0
		// (remove) Token: 0x060007E2 RID: 2018 RVA: 0x0001FA18 File Offset: 0x0001DC18
		public event EventHandler IsCheckedChanged;

		// Token: 0x060007E3 RID: 2019 RVA: 0x0001FA50 File Offset: 0x0001DC50
		private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ToggleSwitch toggleSwitch = (ToggleSwitch)d;
			if (toggleSwitch._toggleButton != null && (bool?)e.OldValue != (bool?)e.NewValue)
			{
				ICommand checkChangedCommand = toggleSwitch.CheckChangedCommand;
				object parameter = toggleSwitch.CheckChangedCommandParameter ?? toggleSwitch;
				if (checkChangedCommand != null && checkChangedCommand.CanExecute(parameter))
				{
					checkChangedCommand.Execute(parameter);
				}
				EventHandler isCheckedChanged = toggleSwitch.IsCheckedChanged;
				if (isCheckedChanged != null)
				{
					isCheckedChanged(toggleSwitch, EventArgs.Empty);
				}
			}
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0001FAFC File Offset: 0x0001DCFC
		static ToggleSwitch()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwitch), new FrameworkPropertyMetadata(typeof(ToggleSwitch)));
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0001FE77 File Offset: 0x0001E077
		public ToggleSwitch()
		{
			base.PreviewKeyUp += this.ToggleSwitch_PreviewKeyUp;
			base.MouseUp += delegate(object sender, MouseButtonEventArgs args)
			{
				Keyboard.Focus(this);
			};
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0001FEA4 File Offset: 0x0001E0A4
		private void ToggleSwitch_PreviewKeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space && e.OriginalSource == sender)
			{
				base.SetCurrentValue(ToggleSwitch.IsCheckedProperty, !this.IsChecked);
			}
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0001FEFE File Offset: 0x0001E0FE
		private void ChangeVisualState(bool useTransitions)
		{
			VisualStateManager.GoToState(this, base.IsEnabled ? "Normal" : "Disabled", useTransitions);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0001FF1C File Offset: 0x0001E11C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this._toggleButton != null)
			{
				this._toggleButton.Checked -= this.CheckedHandler;
				this._toggleButton.Unchecked -= this.UncheckedHandler;
				this._toggleButton.Indeterminate -= this.IndeterminateHandler;
				this._toggleButton.Click -= this.ClickHandler;
				BindingOperations.ClearBinding(this._toggleButton, ToggleButton.IsCheckedProperty);
				this._toggleButton.IsEnabledChanged -= this.IsEnabledHandler;
				this._toggleButton.PreviewMouseUp -= this.ToggleButtonPreviewMouseUp;
			}
			this._toggleButton = (base.GetTemplateChild("Switch") as ToggleButton);
			if (this._toggleButton != null)
			{
				this._toggleButton.Checked += this.CheckedHandler;
				this._toggleButton.Unchecked += this.UncheckedHandler;
				this._toggleButton.Indeterminate += this.IndeterminateHandler;
				this._toggleButton.Click += this.ClickHandler;
				Binding binding = new Binding("IsChecked")
				{
					Source = this
				};
				this._toggleButton.SetBinding(ToggleButton.IsCheckedProperty, binding);
				this._toggleButton.IsEnabledChanged += this.IsEnabledHandler;
				this._toggleButton.PreviewMouseUp += this.ToggleButtonPreviewMouseUp;
			}
			this.ChangeVisualState(false);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x000200AA File Offset: 0x0001E2AA
		private void ToggleButtonPreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			Keyboard.Focus(this);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x000200B3 File Offset: 0x0001E2B3
		private void IsEnabledHandler(object sender, DependencyPropertyChangedEventArgs e)
		{
			this.ChangeVisualState(false);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x000200BC File Offset: 0x0001E2BC
		private void CheckedHandler(object sender, RoutedEventArgs e)
		{
			ICommand checkedCommand = this.CheckedCommand;
			object parameter = this.CheckedCommandParameter ?? this;
			if (checkedCommand != null && checkedCommand.CanExecute(parameter))
			{
				checkedCommand.Execute(parameter);
			}
			SafeRaise.Raise<RoutedEventArgs>(this.Checked, this, e);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x000200FC File Offset: 0x0001E2FC
		private void UncheckedHandler(object sender, RoutedEventArgs e)
		{
			ICommand unCheckedCommand = this.UnCheckedCommand;
			object parameter = this.UnCheckedCommandParameter ?? this;
			if (unCheckedCommand != null && unCheckedCommand.CanExecute(parameter))
			{
				unCheckedCommand.Execute(parameter);
			}
			SafeRaise.Raise<RoutedEventArgs>(this.Unchecked, this, e);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002013C File Offset: 0x0001E33C
		private void IndeterminateHandler(object sender, RoutedEventArgs e)
		{
			SafeRaise.Raise<RoutedEventArgs>(this.Indeterminate, this, e);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0002014B File Offset: 0x0001E34B
		private void ClickHandler(object sender, RoutedEventArgs e)
		{
			SafeRaise.Raise<RoutedEventArgs>(this.Click, this, e);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0002015A File Offset: 0x0001E35A
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{{ToggleSwitch IsChecked={0}, Content={1}}}", this.IsChecked, base.Content);
		}

		// Token: 0x04000339 RID: 825
		private const string CommonStates = "CommonStates";

		// Token: 0x0400033A RID: 826
		private const string NormalState = "Normal";

		// Token: 0x0400033B RID: 827
		private const string DisabledState = "Disabled";

		// Token: 0x0400033C RID: 828
		private const string SwitchPart = "Switch";

		// Token: 0x0400033D RID: 829
		private ToggleButton _toggleButton;

		// Token: 0x0400033E RID: 830
		public static readonly DependencyProperty HeaderFontFamilyProperty = DependencyProperty.Register("HeaderFontFamily", typeof(FontFamily), typeof(ToggleSwitch), new PropertyMetadata(SystemFonts.MessageFontFamily));

		// Token: 0x0400033F RID: 831
		public static readonly DependencyProperty OnLabelProperty = DependencyProperty.Register("OnLabel", typeof(string), typeof(ToggleSwitch), new PropertyMetadata("On"));

		// Token: 0x04000340 RID: 832
		public static readonly DependencyProperty OffLabelProperty = DependencyProperty.Register("OffLabel", typeof(string), typeof(ToggleSwitch), new PropertyMetadata("Off"));

		// Token: 0x04000341 RID: 833
		[Obsolete("This property will be deleted in the next release. You should use OnSwitchBrush and OffSwitchBrush to change the switch's brushes.")]
		public static readonly DependencyProperty SwitchForegroundProperty = DependencyProperty.Register("SwitchForeground", typeof(Brush), typeof(ToggleSwitch), new PropertyMetadata(null, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((ToggleSwitch)o).OnSwitchBrush = (e.NewValue as Brush);
		}));

		// Token: 0x04000342 RID: 834
		public static readonly DependencyProperty OnSwitchBrushProperty = DependencyProperty.Register("OnSwitchBrush", typeof(Brush), typeof(ToggleSwitch), null);

		// Token: 0x04000343 RID: 835
		public static readonly DependencyProperty OffSwitchBrushProperty = DependencyProperty.Register("OffSwitchBrush", typeof(Brush), typeof(ToggleSwitch), null);

		// Token: 0x04000344 RID: 836
		public static readonly DependencyProperty ThumbIndicatorBrushProperty = DependencyProperty.Register("ThumbIndicatorBrush", typeof(Brush), typeof(ToggleSwitch), null);

		// Token: 0x04000345 RID: 837
		public static readonly DependencyProperty ThumbIndicatorDisabledBrushProperty = DependencyProperty.Register("ThumbIndicatorDisabledBrush", typeof(Brush), typeof(ToggleSwitch), null);

		// Token: 0x04000346 RID: 838
		public static readonly DependencyProperty ThumbIndicatorWidthProperty = DependencyProperty.Register("ThumbIndicatorWidth", typeof(double), typeof(ToggleSwitch), new PropertyMetadata(13.0));

		// Token: 0x04000347 RID: 839
		public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool?), typeof(ToggleSwitch), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(ToggleSwitch.OnIsCheckedChanged)));

		// Token: 0x04000348 RID: 840
		public static readonly DependencyProperty CheckChangedCommandProperty = DependencyProperty.Register("CheckChangedCommand", typeof(ICommand), typeof(ToggleSwitch), new PropertyMetadata(null));

		// Token: 0x04000349 RID: 841
		public static readonly DependencyProperty CheckedCommandProperty = DependencyProperty.Register("CheckedCommand", typeof(ICommand), typeof(ToggleSwitch), new PropertyMetadata(null));

		// Token: 0x0400034A RID: 842
		public static readonly DependencyProperty UnCheckedCommandProperty = DependencyProperty.Register("UnCheckedCommand", typeof(ICommand), typeof(ToggleSwitch), new PropertyMetadata(null));

		// Token: 0x0400034B RID: 843
		public static readonly DependencyProperty CheckChangedCommandParameterProperty = DependencyProperty.Register("CheckChangedCommandParameter", typeof(object), typeof(ToggleSwitch), new PropertyMetadata(null));

		// Token: 0x0400034C RID: 844
		public static readonly DependencyProperty CheckedCommandParameterProperty = DependencyProperty.Register("CheckedCommandParameter", typeof(object), typeof(ToggleSwitch), new PropertyMetadata(null));

		// Token: 0x0400034D RID: 845
		public static readonly DependencyProperty UnCheckedCommandParameterProperty = DependencyProperty.Register("UnCheckedCommandParameter", typeof(object), typeof(ToggleSwitch), new PropertyMetadata(null));

		// Token: 0x0400034E RID: 846
		public static readonly DependencyProperty ContentDirectionProperty = DependencyProperty.Register("ContentDirection", typeof(FlowDirection), typeof(ToggleSwitch), new PropertyMetadata(FlowDirection.LeftToRight));

		// Token: 0x0400034F RID: 847
		public static readonly DependencyProperty ContentPaddingProperty = DependencyProperty.Register("ContentPadding", typeof(Thickness), typeof(ToggleSwitch), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsParentMeasure));

		// Token: 0x04000350 RID: 848
		public static readonly DependencyProperty ToggleSwitchButtonStyleProperty = DependencyProperty.Register("ToggleSwitchButtonStyle", typeof(Style), typeof(ToggleSwitch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
	}
}
