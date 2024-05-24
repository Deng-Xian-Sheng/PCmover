using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200008E RID: 142
	[TemplatePart(Name = "PART_Button", Type = typeof(Button))]
	[TemplatePart(Name = "PART_HourHand", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_HourPicker", Type = typeof(Selector))]
	[TemplatePart(Name = "PART_MinuteHand", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_SecondHand", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_SecondPicker", Type = typeof(Selector))]
	[TemplatePart(Name = "PART_MinutePicker", Type = typeof(Selector))]
	[TemplatePart(Name = "PART_AmPmSwitcher", Type = typeof(Selector))]
	[TemplatePart(Name = "PART_TextBox", Type = typeof(DatePickerTextBox))]
	public abstract class TimePickerBase : Control
	{
		// Token: 0x0600076A RID: 1898 RVA: 0x0001E278 File Offset: 0x0001C478
		static TimePickerBase()
		{
			TimePickerBase.SelectedTimeChangedEvent = EventManager.RegisterRoutedEvent("SelectedTimeChanged", RoutingStrategy.Direct, typeof(EventHandler<TimePickerBaseSelectionChangedEventArgs<TimeSpan?>>), typeof(TimePickerBase));
			TimePickerBase.SelectedTimeProperty = DependencyProperty.Register("SelectedTime", typeof(TimeSpan?), typeof(TimePickerBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(TimePickerBase.OnSelectedTimeChanged), new CoerceValueCallback(TimePickerBase.CoerceSelectedTime)));
			TimePickerBase.SelectedTimeFormatProperty = DependencyProperty.Register("SelectedTimeFormat", typeof(TimePickerFormat), typeof(TimePickerBase), new PropertyMetadata(TimePickerFormat.Long, new PropertyChangedCallback(TimePickerBase.OnSelectedTimeFormatChanged)));
			TimePickerBase.IsDatePickerVisiblePropertyKey = DependencyProperty.RegisterReadOnly("IsDatePickerVisible", typeof(bool), typeof(TimePickerBase), new PropertyMetadata(true));
			TimePickerBase.IsDatePickerVisibleProperty = TimePickerBase.IsDatePickerVisiblePropertyKey.DependencyProperty;
			TimePickerBase.MinTimeOfDay = TimeSpan.Zero;
			TimePickerBase.MaxTimeOfDay = TimeSpan.FromDays(1.0) - TimeSpan.FromTicks(1L);
			TimePickerBase.IntervalOf5 = TimePickerBase.CreateValueList(5);
			TimePickerBase.IntervalOf10 = TimePickerBase.CreateValueList(10);
			TimePickerBase.IntervalOf15 = TimePickerBase.CreateValueList(15);
			EventManager.RegisterClassHandler(typeof(TimePickerBase), UIElement.GotFocusEvent, new RoutedEventHandler(TimePickerBase.OnGotFocus));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePickerBase), new FrameworkPropertyMetadata(typeof(TimePickerBase)));
			Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(TimePickerBase), new FrameworkPropertyMetadata(VerticalAlignment.Center));
			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(TimePickerBase), new FrameworkPropertyMetadata(new PropertyChangedCallback(TimePickerBase.OnCultureChanged)));
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0001E62A File Offset: 0x0001C82A
		protected TimePickerBase()
		{
			Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, new MouseButtonEventHandler(this.OutsideCapturedElementHandler));
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x0600076C RID: 1900 RVA: 0x0001E644 File Offset: 0x0001C844
		// (remove) Token: 0x0600076D RID: 1901 RVA: 0x0001E652 File Offset: 0x0001C852
		public event EventHandler<TimePickerBaseSelectionChangedEventArgs<TimeSpan?>> SelectedTimeChanged
		{
			add
			{
				base.AddHandler(TimePickerBase.SelectedTimeChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(TimePickerBase.SelectedTimeChangedEvent, value);
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x0001E660 File Offset: 0x0001C860
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x0001E672 File Offset: 0x0001C872
		[Category("Behavior")]
		[DefaultValue(null)]
		public CultureInfo Culture
		{
			get
			{
				return (CultureInfo)base.GetValue(TimePickerBase.CultureProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.CultureProperty, value);
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0001E680 File Offset: 0x0001C880
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x0001E692 File Offset: 0x0001C892
		[Category("Appearance")]
		[DefaultValue(TimePartVisibility.All)]
		public TimePartVisibility HandVisibility
		{
			get
			{
				return (TimePartVisibility)base.GetValue(TimePickerBase.HandVisibilityProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.HandVisibilityProperty, value);
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0001E6A5 File Offset: 0x0001C8A5
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x0001E6B7 File Offset: 0x0001C8B7
		public bool IsDatePickerVisible
		{
			get
			{
				return (bool)base.GetValue(TimePickerBase.IsDatePickerVisibleProperty);
			}
			protected set
			{
				base.SetValue(TimePickerBase.IsDatePickerVisiblePropertyKey, value);
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0001E6CA File Offset: 0x0001C8CA
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x0001E6DC File Offset: 0x0001C8DC
		[Category("Appearance")]
		public bool IsClockVisible
		{
			get
			{
				return (bool)base.GetValue(TimePickerBase.IsClockVisibleProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.IsClockVisibleProperty, value);
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0001E6EF File Offset: 0x0001C8EF
		// (set) Token: 0x06000777 RID: 1911 RVA: 0x0001E701 File Offset: 0x0001C901
		public bool IsDropDownOpen
		{
			get
			{
				return (bool)base.GetValue(TimePickerBase.IsDropDownOpenProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.IsDropDownOpenProperty, value);
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0001E714 File Offset: 0x0001C914
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x0001E726 File Offset: 0x0001C926
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(TimePickerBase.IsReadOnlyProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.IsReadOnlyProperty, value);
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0001E739 File Offset: 0x0001C939
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x0001E74B File Offset: 0x0001C94B
		[Category("Appearance")]
		[DefaultValue(TimePartVisibility.All)]
		public TimePartVisibility PickerVisibility
		{
			get
			{
				return (TimePartVisibility)base.GetValue(TimePickerBase.PickerVisibilityProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.PickerVisibilityProperty, value);
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0001E75E File Offset: 0x0001C95E
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x0001E770 File Offset: 0x0001C970
		public TimeSpan? SelectedTime
		{
			get
			{
				return (TimeSpan?)base.GetValue(TimePickerBase.SelectedTimeProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.SelectedTimeProperty, value);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0001E783 File Offset: 0x0001C983
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x0001E795 File Offset: 0x0001C995
		[Category("Appearance")]
		[DefaultValue(TimePickerFormat.Long)]
		public TimePickerFormat SelectedTimeFormat
		{
			get
			{
				return (TimePickerFormat)base.GetValue(TimePickerBase.SelectedTimeFormatProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.SelectedTimeFormatProperty, value);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x0001E7A8 File Offset: 0x0001C9A8
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x0001E7BA File Offset: 0x0001C9BA
		[Category("Common")]
		public IEnumerable<int> SourceHours
		{
			get
			{
				return (IEnumerable<int>)base.GetValue(TimePickerBase.SourceHoursProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.SourceHoursProperty, value);
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x0001E7C8 File Offset: 0x0001C9C8
		// (set) Token: 0x06000783 RID: 1923 RVA: 0x0001E7DA File Offset: 0x0001C9DA
		[Category("Common")]
		public IEnumerable<int> SourceMinutes
		{
			get
			{
				return (IEnumerable<int>)base.GetValue(TimePickerBase.SourceMinutesProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.SourceMinutesProperty, value);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x0001E7E8 File Offset: 0x0001C9E8
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x0001E7FA File Offset: 0x0001C9FA
		[Category("Common")]
		public IEnumerable<int> SourceSeconds
		{
			get
			{
				return (IEnumerable<int>)base.GetValue(TimePickerBase.SourceSecondsProperty);
			}
			set
			{
				base.SetValue(TimePickerBase.SourceSecondsProperty, value);
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x0001E808 File Offset: 0x0001CA08
		public bool IsMilitaryTime
		{
			get
			{
				DateTimeFormatInfo dateTimeFormat = this.SpecificCultureInfo.DateTimeFormat;
				return !string.IsNullOrEmpty(dateTimeFormat.AMDesignator) && (dateTimeFormat.ShortTimePattern.Contains("h") || dateTimeFormat.LongTimePattern.Contains("h"));
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x0001E854 File Offset: 0x0001CA54
		protected internal Popup Popup
		{
			get
			{
				return this._popup;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x0001E85C File Offset: 0x0001CA5C
		protected CultureInfo SpecificCultureInfo
		{
			get
			{
				return this.Culture ?? base.Language.GetSpecificCulture();
			}
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0001E874 File Offset: 0x0001CA74
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.UnSubscribeEvents();
			this._popup = (base.GetTemplateChild("PART_Popup") as Popup);
			this._button = (base.GetTemplateChild("PART_Button") as Button);
			this._hourInput = (base.GetTemplateChild("PART_HourPicker") as Selector);
			this._minuteInput = (base.GetTemplateChild("PART_MinutePicker") as Selector);
			this._secondInput = (base.GetTemplateChild("PART_SecondPicker") as Selector);
			this._hourHand = (base.GetTemplateChild("PART_HourHand") as FrameworkElement);
			this._ampmSwitcher = (base.GetTemplateChild("PART_AmPmSwitcher") as Selector);
			this._minuteHand = (base.GetTemplateChild("PART_MinuteHand") as FrameworkElement);
			this._secondHand = (base.GetTemplateChild("PART_SecondHand") as FrameworkElement);
			this._textBox = (base.GetTemplateChild("PART_TextBox") as DatePickerTextBox);
			this.SetHandVisibility(this.HandVisibility);
			this.SetPickerVisibility(this.PickerVisibility);
			this.SetHourPartValues(this.SelectedTime.GetValueOrDefault());
			this.WriteValueToTextBox();
			this.SetDefaultTimeOfDayValues();
			this.SubscribeEvents();
			this.ApplyCulture();
			this.ApplyBindings();
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0001E9B3 File Offset: 0x0001CBB3
		protected virtual void ApplyBindings()
		{
			if (this.Popup != null)
			{
				this.Popup.SetBinding(Popup.IsOpenProperty, this.GetBinding(TimePickerBase.IsDropDownOpenProperty));
			}
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001E9DC File Offset: 0x0001CBDC
		protected virtual void ApplyCulture()
		{
			this._deactivateRangeBaseEvent = true;
			if (this._ampmSwitcher != null)
			{
				this._ampmSwitcher.Items.Clear();
				if (!string.IsNullOrEmpty(this.SpecificCultureInfo.DateTimeFormat.AMDesignator))
				{
					this._ampmSwitcher.Items.Add(this.SpecificCultureInfo.DateTimeFormat.AMDesignator);
				}
				if (!string.IsNullOrEmpty(this.SpecificCultureInfo.DateTimeFormat.PMDesignator))
				{
					this._ampmSwitcher.Items.Add(this.SpecificCultureInfo.DateTimeFormat.PMDesignator);
				}
			}
			this.SetAmPmVisibility();
			base.CoerceValue(TimePickerBase.SourceHoursProperty);
			if (this.SelectedTime != null)
			{
				this.SetHourPartValues(this.SelectedTime.Value);
			}
			this.SetDefaultTimeOfDayValues();
			this._deactivateRangeBaseEvent = false;
			this.WriteValueToTextBox();
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001EAC3 File Offset: 0x0001CCC3
		protected Binding GetBinding(DependencyProperty property)
		{
			return new Binding(property.Name)
			{
				Source = this
			};
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
		protected virtual string GetValueForTextBox()
		{
			string str = (this.SelectedTimeFormat == TimePickerFormat.Long) ? string.Intern(this.SpecificCultureInfo.DateTimeFormat.LongTimePattern) : string.Intern(this.SpecificCultureInfo.DateTimeFormat.ShortTimePattern);
			DateTime minValue = DateTime.MinValue;
			TimeSpan? selectedTime = this.SelectedTime;
			DateTime? dateTime;
			DateTime? dateTime2;
			if (selectedTime == null)
			{
				dateTime = null;
				dateTime2 = dateTime;
			}
			else
			{
				dateTime2 = new DateTime?(minValue + selectedTime.GetValueOrDefault());
			}
			dateTime = dateTime2;
			if (dateTime == null)
			{
				return null;
			}
			return dateTime.GetValueOrDefault().ToString(string.Intern(str), this.SpecificCultureInfo);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0001EB78 File Offset: 0x0001CD78
		protected virtual void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
		{
			DateTime dateTime;
			if (DateTime.TryParse(string.Intern(string.Format("{0} {1}", DateTime.MinValue.ToString(this.SpecificCultureInfo.DateTimeFormat.ShortDatePattern), ((DatePickerTextBox)sender).Text)), this.SpecificCultureInfo, DateTimeStyles.None, out dateTime))
			{
				this.SelectedTime = new TimeSpan?(dateTime.TimeOfDay);
				return;
			}
			if (this.SelectedTime == null)
			{
				this.WriteValueToTextBox();
			}
			this.SelectedTime = null;
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0001EC04 File Offset: 0x0001CE04
		protected virtual void OnRangeBaseValueChanged(object sender, SelectionChangedEventArgs e)
		{
			this.SelectedTime = this.GetSelectedTimeFromGUI();
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0001EC12 File Offset: 0x0001CE12
		protected virtual void OnSelectedTimeChanged(TimePickerBaseSelectionChangedEventArgs<TimeSpan?> e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0001EC1C File Offset: 0x0001CE1C
		private static void OnSelectedTimeFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TimePickerBase timePickerBase = d as TimePickerBase;
			if (timePickerBase != null)
			{
				timePickerBase.WriteValueToTextBox();
			}
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001EC39 File Offset: 0x0001CE39
		protected void SetDefaultTimeOfDayValues()
		{
			TimePickerBase.SetDefaultTimeOfDayValue(this._hourInput);
			TimePickerBase.SetDefaultTimeOfDayValue(this._minuteInput);
			TimePickerBase.SetDefaultTimeOfDayValue(this._secondInput);
			TimePickerBase.SetDefaultTimeOfDayValue(this._ampmSwitcher);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0001EC68 File Offset: 0x0001CE68
		protected virtual void SubscribeEvents()
		{
			this.SubscribeRangeBaseValueChanged(new Selector[]
			{
				this._hourInput,
				this._minuteInput,
				this._secondInput,
				this._ampmSwitcher
			});
			if (this._button != null)
			{
				this._button.Click += this.OnButtonClicked;
			}
			if (this._textBox != null)
			{
				this._textBox.TextChanged += this.OnTextChanged;
				this._textBox.LostFocus += this.InternalOnTextBoxLostFocus;
			}
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0001ECFC File Offset: 0x0001CEFC
		protected virtual void UnSubscribeEvents()
		{
			this.UnsubscribeRangeBaseValueChanged(new Selector[]
			{
				this._hourInput,
				this._minuteInput,
				this._secondInput,
				this._ampmSwitcher
			});
			if (this._button != null)
			{
				this._button.Click -= this.OnButtonClicked;
			}
			if (this._textBox != null)
			{
				this._textBox.TextChanged -= this.OnTextChanged;
				this._textBox.LostFocus -= this.InternalOnTextBoxLostFocus;
			}
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001ED8E File Offset: 0x0001CF8E
		protected virtual void WriteValueToTextBox()
		{
			if (this._textBox != null)
			{
				this._deactivateTextChangedEvent = true;
				this._textBox.Text = this.GetValueForTextBox();
				this._deactivateTextChangedEvent = false;
			}
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001EDB7 File Offset: 0x0001CFB7
		private static IList<int> CreateValueList(int interval)
		{
			return Enumerable.Repeat<int>(interval, 60 / interval).Select((int value, int index) => value * index).ToList<int>();
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001EDEC File Offset: 0x0001CFEC
		private static object CoerceSelectedTime(DependencyObject d, object basevalue)
		{
			TimeSpan? timeSpan = (TimeSpan?)basevalue;
			if (timeSpan < TimePickerBase.MinTimeOfDay)
			{
				return TimePickerBase.MinTimeOfDay;
			}
			if (timeSpan > TimePickerBase.MaxTimeOfDay)
			{
				return TimePickerBase.MaxTimeOfDay;
			}
			return timeSpan;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001EE64 File Offset: 0x0001D064
		private static object CoerceSource60(DependencyObject d, object basevalue)
		{
			IEnumerable<int> enumerable = basevalue as IEnumerable<int>;
			if (enumerable != null)
			{
				return from i in enumerable
				where i >= 0 && i < 60
				select i;
			}
			return Enumerable.Empty<int>();
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001EEA8 File Offset: 0x0001D0A8
		private static object CoerceSourceHours(DependencyObject d, object basevalue)
		{
			TimePickerBase timePickerBase = d as TimePickerBase;
			IEnumerable<int> enumerable = basevalue as IEnumerable<int>;
			if (timePickerBase == null || enumerable == null)
			{
				return Enumerable.Empty<int>();
			}
			if (timePickerBase.IsMilitaryTime)
			{
				return (from i in enumerable
				where i > 0 && i <= 12
				select i).OrderBy((int i) => i, new AmPmComparer());
			}
			return from i in enumerable
			where i >= 0 && i < 24
			select i;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001EF4E File Offset: 0x0001D14E
		private void InternalOnTextBoxLostFocus(object sender, RoutedEventArgs e)
		{
			if (this._textInputChanged)
			{
				this._textInputChanged = false;
				this.OnTextBoxLostFocus(sender, e);
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001EF67 File Offset: 0x0001D167
		private void InternalOnRangeBaseValueChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!this._deactivateRangeBaseEvent)
			{
				this.OnRangeBaseValueChanged(sender, e);
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001EF7C File Offset: 0x0001D17C
		private static void OnCultureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TimePickerBase timePickerBase = (TimePickerBase)d;
			if (e.NewValue is XmlLanguage)
			{
				timePickerBase.Language = (XmlLanguage)e.NewValue;
			}
			else if (e.NewValue is CultureInfo)
			{
				timePickerBase.Language = XmlLanguage.GetLanguage(((CultureInfo)e.NewValue).IetfLanguageTag);
			}
			else
			{
				timePickerBase.Language = XmlLanguage.Empty;
			}
			timePickerBase.ApplyCulture();
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001EFEF File Offset: 0x0001D1EF
		protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnIsKeyboardFocusWithinChanged(e);
			if (!(bool)e.NewValue)
			{
				this.IsDropDownOpen = false;
			}
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001F00D File Offset: 0x0001D20D
		private void OutsideCapturedElementHandler(object sender, MouseButtonEventArgs e)
		{
			this.IsDropDownOpen = false;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001F018 File Offset: 0x0001D218
		private static void OnGotFocus(object sender, RoutedEventArgs e)
		{
			TimePickerBase timePickerBase = (TimePickerBase)sender;
			if (!e.Handled && timePickerBase.Focusable)
			{
				if (object.Equals(e.OriginalSource, timePickerBase))
				{
					TraversalRequest request = new TraversalRequest(((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
					UIElement uielement = Keyboard.FocusedElement as UIElement;
					if (uielement != null)
					{
						uielement.MoveFocus(request);
					}
					else
					{
						timePickerBase.Focus();
					}
					e.Handled = true;
					return;
				}
				if (timePickerBase._textBox != null && object.Equals(e.OriginalSource, timePickerBase._textBox))
				{
					timePickerBase._textBox.SelectAll();
					e.Handled = true;
				}
			}
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001F0B2 File Offset: 0x0001D2B2
		private static void OnHandVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TimePickerBase)d).SetHandVisibility((TimePartVisibility)e.NewValue);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001F0CB File Offset: 0x0001D2CB
		private static void OnPickerVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TimePickerBase)d).SetPickerVisibility((TimePartVisibility)e.NewValue);
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0001F0E4 File Offset: 0x0001D2E4
		private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TimePickerBase timePickerBase = (TimePickerBase)d;
			if (timePickerBase._deactivateRangeBaseEvent)
			{
				return;
			}
			timePickerBase.SetHourPartValues((e.NewValue as TimeSpan?).GetValueOrDefault(TimeSpan.Zero));
			timePickerBase.OnSelectedTimeChanged(new TimePickerBaseSelectionChangedEventArgs<TimeSpan?>(TimePickerBase.SelectedTimeChangedEvent, (TimeSpan?)e.OldValue, (TimeSpan?)e.NewValue));
			timePickerBase.WriteValueToTextBox();
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0001F153 File Offset: 0x0001D353
		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (!this._deactivateTextChangedEvent)
			{
				this._textInputChanged = true;
			}
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001F164 File Offset: 0x0001D364
		private static void SetVisibility(UIElement partHours, UIElement partMinutes, UIElement partSeconds, TimePartVisibility visibility)
		{
			if (partHours != null)
			{
				partHours.Visibility = (visibility.HasFlag(TimePartVisibility.Hour) ? Visibility.Visible : Visibility.Collapsed);
			}
			if (partMinutes != null)
			{
				partMinutes.Visibility = (visibility.HasFlag(TimePartVisibility.Minute) ? Visibility.Visible : Visibility.Collapsed);
			}
			if (partSeconds != null)
			{
				partSeconds.Visibility = (visibility.HasFlag(TimePartVisibility.Second) ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0001F1D1 File Offset: 0x0001D3D1
		private static bool IsValueSelected(Selector selector)
		{
			return selector != null && selector.SelectedItem != null;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001F1E1 File Offset: 0x0001D3E1
		private static void SetDefaultTimeOfDayValue(Selector selector)
		{
			if (selector != null && selector.SelectedValue == null)
			{
				selector.SelectedIndex = 0;
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001F1F8 File Offset: 0x0001D3F8
		protected TimeSpan? GetSelectedTimeFromGUI()
		{
			if (TimePickerBase.IsValueSelected(this._hourInput) && TimePickerBase.IsValueSelected(this._minuteInput) && TimePickerBase.IsValueSelected(this._secondInput))
			{
				int num = (int)this._hourInput.SelectedItem;
				int minutes = (int)this._minuteInput.SelectedItem;
				int seconds = (int)this._secondInput.SelectedItem;
				num += this.GetAmPmOffset(num);
				return new TimeSpan?(new TimeSpan(num, minutes, seconds));
			}
			return this.SelectedTime;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001F280 File Offset: 0x0001D480
		private int GetAmPmOffset(int currentHour)
		{
			if (this.IsMilitaryTime)
			{
				if (currentHour == 12)
				{
					if (object.Equals(this._ampmSwitcher.SelectedItem, this.SpecificCultureInfo.DateTimeFormat.AMDesignator))
					{
						return -12;
					}
				}
				else if (object.Equals(this._ampmSwitcher.SelectedItem, this.SpecificCultureInfo.DateTimeFormat.PMDesignator))
				{
					return 12;
				}
			}
			return 0;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0001F2E5 File Offset: 0x0001D4E5
		private void OnButtonClicked(object sender, RoutedEventArgs e)
		{
			this.IsDropDownOpen = !this.IsDropDownOpen;
			if (this.Popup != null)
			{
				this.Popup.IsOpen = this.IsDropDownOpen;
			}
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0001F310 File Offset: 0x0001D510
		private void SetAmPmVisibility()
		{
			if (this._ampmSwitcher != null)
			{
				if (!this.PickerVisibility.HasFlag(TimePartVisibility.Hour))
				{
					this._ampmSwitcher.Visibility = Visibility.Collapsed;
					return;
				}
				this._ampmSwitcher.Visibility = (this.IsMilitaryTime ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0001F361 File Offset: 0x0001D561
		private void SetHandVisibility(TimePartVisibility visibility)
		{
			TimePickerBase.SetVisibility(this._hourHand, this._minuteHand, this._secondHand, visibility);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0001F37C File Offset: 0x0001D57C
		private void SetHourPartValues(TimeSpan timeOfDay)
		{
			if (this._deactivateRangeBaseEvent)
			{
				return;
			}
			this._deactivateRangeBaseEvent = true;
			if (this._hourInput != null)
			{
				if (this.IsMilitaryTime)
				{
					this._ampmSwitcher.SelectedValue = ((timeOfDay.Hours < 12) ? this.SpecificCultureInfo.DateTimeFormat.AMDesignator : this.SpecificCultureInfo.DateTimeFormat.PMDesignator);
					if (timeOfDay.Hours == 0 || timeOfDay.Hours == 12)
					{
						this._hourInput.SelectedValue = 12;
					}
					else
					{
						this._hourInput.SelectedValue = timeOfDay.Hours % 12;
					}
				}
				else
				{
					this._hourInput.SelectedValue = timeOfDay.Hours;
				}
			}
			if (this._minuteInput != null)
			{
				this._minuteInput.SelectedValue = timeOfDay.Minutes;
			}
			if (this._secondInput != null)
			{
				this._secondInput.SelectedValue = timeOfDay.Seconds;
			}
			this._deactivateRangeBaseEvent = false;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001F484 File Offset: 0x0001D684
		private void SetPickerVisibility(TimePartVisibility visibility)
		{
			TimePickerBase.SetVisibility(this._hourInput, this._minuteInput, this._secondInput, visibility);
			this.SetAmPmVisibility();
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0001F4A4 File Offset: 0x0001D6A4
		private void SubscribeRangeBaseValueChanged(params Selector[] selectors)
		{
			foreach (Selector selector in from i in selectors
			where i != null
			select i)
			{
				selector.SelectionChanged += this.InternalOnRangeBaseValueChanged;
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0001F51C File Offset: 0x0001D71C
		private void UnsubscribeRangeBaseValueChanged(params Selector[] selectors)
		{
			foreach (Selector selector in from i in selectors
			where i != null
			select i)
			{
				selector.SelectionChanged -= this.InternalOnRangeBaseValueChanged;
			}
		}

		// Token: 0x0400030A RID: 778
		public static readonly DependencyProperty SourceHoursProperty = DependencyProperty.Register("SourceHours", typeof(IEnumerable<int>), typeof(TimePickerBase), new FrameworkPropertyMetadata(Enumerable.Range(0, 24), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, new CoerceValueCallback(TimePickerBase.CoerceSourceHours)));

		// Token: 0x0400030B RID: 779
		public static readonly DependencyProperty SourceMinutesProperty = DependencyProperty.Register("SourceMinutes", typeof(IEnumerable<int>), typeof(TimePickerBase), new FrameworkPropertyMetadata(Enumerable.Range(0, 60), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, new CoerceValueCallback(TimePickerBase.CoerceSource60)));

		// Token: 0x0400030C RID: 780
		public static readonly DependencyProperty SourceSecondsProperty = DependencyProperty.Register("SourceSeconds", typeof(IEnumerable<int>), typeof(TimePickerBase), new FrameworkPropertyMetadata(Enumerable.Range(0, 60), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, new CoerceValueCallback(TimePickerBase.CoerceSource60)));

		// Token: 0x0400030D RID: 781
		public static readonly DependencyProperty IsDropDownOpenProperty = DatePicker.IsDropDownOpenProperty.AddOwner(typeof(TimePickerBase), new PropertyMetadata(false));

		// Token: 0x0400030E RID: 782
		public static readonly DependencyProperty IsClockVisibleProperty = DependencyProperty.Register("IsClockVisible", typeof(bool), typeof(TimePickerBase), new PropertyMetadata(true));

		// Token: 0x0400030F RID: 783
		public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(TimePickerBase), new PropertyMetadata(false));

		// Token: 0x04000310 RID: 784
		public static readonly DependencyProperty HandVisibilityProperty = DependencyProperty.Register("HandVisibility", typeof(TimePartVisibility), typeof(TimePickerBase), new PropertyMetadata(TimePartVisibility.All, new PropertyChangedCallback(TimePickerBase.OnHandVisibilityChanged)));

		// Token: 0x04000311 RID: 785
		public static readonly DependencyProperty CultureProperty = DependencyProperty.Register("Culture", typeof(CultureInfo), typeof(TimePickerBase), new PropertyMetadata(null, new PropertyChangedCallback(TimePickerBase.OnCultureChanged)));

		// Token: 0x04000312 RID: 786
		public static readonly DependencyProperty PickerVisibilityProperty = DependencyProperty.Register("PickerVisibility", typeof(TimePartVisibility), typeof(TimePickerBase), new PropertyMetadata(TimePartVisibility.All, new PropertyChangedCallback(TimePickerBase.OnPickerVisibilityChanged)));

		// Token: 0x04000314 RID: 788
		public static readonly DependencyProperty SelectedTimeProperty;

		// Token: 0x04000315 RID: 789
		public static readonly DependencyProperty SelectedTimeFormatProperty;

		// Token: 0x04000316 RID: 790
		private const string ElementAmPmSwitcher = "PART_AmPmSwitcher";

		// Token: 0x04000317 RID: 791
		private const string ElementButton = "PART_Button";

		// Token: 0x04000318 RID: 792
		private const string ElementHourHand = "PART_HourHand";

		// Token: 0x04000319 RID: 793
		private const string ElementHourPicker = "PART_HourPicker";

		// Token: 0x0400031A RID: 794
		private const string ElementMinuteHand = "PART_MinuteHand";

		// Token: 0x0400031B RID: 795
		private const string ElementMinutePicker = "PART_MinutePicker";

		// Token: 0x0400031C RID: 796
		private const string ElementPopup = "PART_Popup";

		// Token: 0x0400031D RID: 797
		private const string ElementSecondHand = "PART_SecondHand";

		// Token: 0x0400031E RID: 798
		private const string ElementSecondPicker = "PART_SecondPicker";

		// Token: 0x0400031F RID: 799
		private const string ElementTextBox = "PART_TextBox";

		// Token: 0x04000320 RID: 800
		private static readonly DependencyPropertyKey IsDatePickerVisiblePropertyKey;

		// Token: 0x04000321 RID: 801
		public static readonly DependencyProperty IsDatePickerVisibleProperty;

		// Token: 0x04000322 RID: 802
		private static readonly TimeSpan MinTimeOfDay;

		// Token: 0x04000323 RID: 803
		private static readonly TimeSpan MaxTimeOfDay;

		// Token: 0x04000324 RID: 804
		public static readonly IEnumerable<int> IntervalOf5;

		// Token: 0x04000325 RID: 805
		public static readonly IEnumerable<int> IntervalOf10;

		// Token: 0x04000326 RID: 806
		public static readonly IEnumerable<int> IntervalOf15;

		// Token: 0x04000327 RID: 807
		private Selector _ampmSwitcher;

		// Token: 0x04000328 RID: 808
		private Button _button;

		// Token: 0x04000329 RID: 809
		private bool _deactivateRangeBaseEvent;

		// Token: 0x0400032A RID: 810
		private bool _deactivateTextChangedEvent;

		// Token: 0x0400032B RID: 811
		private bool _textInputChanged;

		// Token: 0x0400032C RID: 812
		private UIElement _hourHand;

		// Token: 0x0400032D RID: 813
		private Selector _hourInput;

		// Token: 0x0400032E RID: 814
		private UIElement _minuteHand;

		// Token: 0x0400032F RID: 815
		private Selector _minuteInput;

		// Token: 0x04000330 RID: 816
		private Popup _popup;

		// Token: 0x04000331 RID: 817
		private UIElement _secondHand;

		// Token: 0x04000332 RID: 818
		private Selector _secondInput;

		// Token: 0x04000333 RID: 819
		protected DatePickerTextBox _textBox;
	}
}
