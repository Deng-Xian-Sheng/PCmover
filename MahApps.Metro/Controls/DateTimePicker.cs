using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200008B RID: 139
	[TemplatePart(Name = "PART_Calendar", Type = typeof(System.Windows.Controls.Calendar))]
	[DefaultEvent("SelectedDateChanged")]
	public class DateTimePicker : TimePickerBase
	{
		// Token: 0x06000744 RID: 1860 RVA: 0x0001DAA4 File Offset: 0x0001BCA4
		static DateTimePicker()
		{
			DateTimePicker.SelectedDateChangedEvent = EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Direct, typeof(EventHandler<TimePickerBaseSelectionChangedEventArgs<DateTime?>>), typeof(DateTimePicker));
			DateTimePicker.SelectedDateProperty = DatePicker.SelectedDateProperty.AddOwner(typeof(DateTimePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DateTimePicker.OnSelectedDateChanged)));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimePicker), new FrameworkPropertyMetadata(typeof(DateTimePicker)));
			TimePickerBase.IsClockVisibleProperty.OverrideMetadata(typeof(DateTimePicker), new PropertyMetadata(new PropertyChangedCallback(DateTimePicker.OnClockVisibilityChanged)));
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000745 RID: 1861 RVA: 0x0001DC35 File Offset: 0x0001BE35
		// (remove) Token: 0x06000746 RID: 1862 RVA: 0x0001DC43 File Offset: 0x0001BE43
		public event EventHandler<TimePickerBaseSelectionChangedEventArgs<DateTime?>> SelectedDateChanged
		{
			add
			{
				base.AddHandler(DateTimePicker.SelectedDateChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(DateTimePicker.SelectedDateChangedEvent, value);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x0001DC51 File Offset: 0x0001BE51
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x0001DC63 File Offset: 0x0001BE63
		public DateTime? DisplayDate
		{
			get
			{
				return (DateTime?)base.GetValue(DateTimePicker.DisplayDateProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.DisplayDateProperty, value);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x0001DC76 File Offset: 0x0001BE76
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x0001DC88 File Offset: 0x0001BE88
		public DateTime? DisplayDateEnd
		{
			get
			{
				return (DateTime?)base.GetValue(DateTimePicker.DisplayDateEndProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.DisplayDateEndProperty, value);
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x0001DC9B File Offset: 0x0001BE9B
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x0001DCAD File Offset: 0x0001BEAD
		public DateTime? DisplayDateStart
		{
			get
			{
				return (DateTime?)base.GetValue(DateTimePicker.DisplayDateStartProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.DisplayDateStartProperty, value);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0001DCC0 File Offset: 0x0001BEC0
		// (set) Token: 0x0600074E RID: 1870 RVA: 0x0001DCD2 File Offset: 0x0001BED2
		public DayOfWeek FirstDayOfWeek
		{
			get
			{
				return (DayOfWeek)base.GetValue(DateTimePicker.FirstDayOfWeekProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.FirstDayOfWeekProperty, value);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x0001DCE5 File Offset: 0x0001BEE5
		// (set) Token: 0x06000750 RID: 1872 RVA: 0x0001DCF7 File Offset: 0x0001BEF7
		[Category("Appearance")]
		[DefaultValue(DatePickerFormat.Short)]
		public DatePickerFormat SelectedDateFormat
		{
			get
			{
				return (DatePickerFormat)base.GetValue(DateTimePicker.SelectedDateFormatProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.SelectedDateFormatProperty, value);
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x0001DD0A File Offset: 0x0001BF0A
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x0001DD1C File Offset: 0x0001BF1C
		public bool IsTodayHighlighted
		{
			get
			{
				return (bool)base.GetValue(DateTimePicker.IsTodayHighlightedProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.IsTodayHighlightedProperty, value);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x0001DD2F File Offset: 0x0001BF2F
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x0001DD41 File Offset: 0x0001BF41
		[Category("Layout")]
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(DateTimePicker.OrientationProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.OrientationProperty, value);
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x0001DD54 File Offset: 0x0001BF54
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x0001DD66 File Offset: 0x0001BF66
		public DateTime? SelectedDate
		{
			get
			{
				return (DateTime?)base.GetValue(DateTimePicker.SelectedDateProperty);
			}
			set
			{
				base.SetValue(DateTimePicker.SelectedDateProperty, value);
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0001DD79 File Offset: 0x0001BF79
		public override void OnApplyTemplate()
		{
			this._calendar = (base.GetTemplateChild("PART_Calendar") as System.Windows.Controls.Calendar);
			base.OnApplyTemplate();
			this.SetDatePartValues();
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001DD9D File Offset: 0x0001BF9D
		protected virtual void OnSelectedDateChanged(TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001DDA8 File Offset: 0x0001BFA8
		private static void OnSelectedDateFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DateTimePicker dateTimePicker = d as DateTimePicker;
			if (dateTimePicker != null)
			{
				dateTimePicker.WriteValueToTextBox();
			}
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
		protected override void ApplyBindings()
		{
			base.ApplyBindings();
			if (this._calendar != null)
			{
				this._calendar.SetBinding(System.Windows.Controls.Calendar.DisplayDateProperty, base.GetBinding(DateTimePicker.DisplayDateProperty));
				this._calendar.SetBinding(System.Windows.Controls.Calendar.DisplayDateStartProperty, base.GetBinding(DateTimePicker.DisplayDateStartProperty));
				this._calendar.SetBinding(System.Windows.Controls.Calendar.DisplayDateEndProperty, base.GetBinding(DateTimePicker.DisplayDateEndProperty));
				this._calendar.SetBinding(System.Windows.Controls.Calendar.FirstDayOfWeekProperty, base.GetBinding(DateTimePicker.FirstDayOfWeekProperty));
				this._calendar.SetBinding(System.Windows.Controls.Calendar.IsTodayHighlightedProperty, base.GetBinding(DateTimePicker.IsTodayHighlightedProperty));
				this._calendar.SetBinding(FrameworkElement.FlowDirectionProperty, base.GetBinding(FrameworkElement.FlowDirectionProperty));
				this._calendar.SelectedDatesChanged += this.OnCalendarSelectedDateChanged;
			}
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0001DEA5 File Offset: 0x0001C0A5
		protected sealed override void ApplyCulture()
		{
			base.ApplyCulture();
			base.SetCurrentValue(DateTimePicker.FirstDayOfWeekProperty, base.SpecificCultureInfo.DateTimeFormat.FirstDayOfWeek);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001DED0 File Offset: 0x0001C0D0
		protected override string GetValueForTextBox()
		{
			DateTimeFormatInfo dateTimeFormat = base.SpecificCultureInfo.DateTimeFormat;
			string arg = (base.SelectedTimeFormat == TimePickerFormat.Long) ? dateTimeFormat.LongTimePattern : dateTimeFormat.ShortTimePattern;
			string arg2 = (this.SelectedDateFormat == DatePickerFormat.Long) ? dateTimeFormat.LongDatePattern : dateTimeFormat.ShortDatePattern;
			string format = string.Intern(string.Format("{0} {1}", arg2, arg));
			DateTime? selectedDateTimeFromGUI = this.GetSelectedDateTimeFromGUI();
			if (selectedDateTimeFromGUI == null)
			{
				return null;
			}
			return selectedDateTimeFromGUI.GetValueOrDefault().ToString(format, base.SpecificCultureInfo);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0001DF53 File Offset: 0x0001C153
		protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseUp(e);
			if (Mouse.Captured is CalendarItem)
			{
				Mouse.Capture(null);
			}
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0001DF6F File Offset: 0x0001C16F
		protected override void OnRangeBaseValueChanged(object sender, SelectionChangedEventArgs e)
		{
			base.OnRangeBaseValueChanged(sender, e);
			this.SetDatePartValues();
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001DF80 File Offset: 0x0001C180
		protected override void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
		{
			DateTime value;
			if (DateTime.TryParse(((DatePickerTextBox)sender).Text, base.SpecificCultureInfo, DateTimeStyles.None, out value))
			{
				this.SelectedDate = new DateTime?(value);
				return;
			}
			if (this.SelectedDate == null)
			{
				this.WriteValueToTextBox();
			}
			this.SelectedDate = null;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0001DFDA File Offset: 0x0001C1DA
		protected override void WriteValueToTextBox()
		{
			if (!this._deactivateWriteValueToTextBox)
			{
				base.WriteValueToTextBox();
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001DFEC File Offset: 0x0001C1EC
		private void OnCalendarSelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0)
			{
				DateTime dateTime = (DateTime)e.AddedItems[0];
				TimeSpan timeOfDay = this.SelectedDate.GetValueOrDefault().TimeOfDay;
				dateTime += timeOfDay;
				this.SelectedDate = new DateTime?(dateTime);
			}
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001E044 File Offset: 0x0001C244
		private static object CoerceOrientation(DependencyObject d, object basevalue)
		{
			if (((DateTimePicker)d).IsClockVisible)
			{
				return basevalue;
			}
			return Orientation.Vertical;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001E05B File Offset: 0x0001C25B
		private static void OnClockVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.CoerceValue(DateTimePicker.OrientationProperty);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001E068 File Offset: 0x0001C268
		private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DateTimePicker dateTimePicker = (DateTimePicker)d;
			dateTimePicker._deactivateWriteValueToTextBox = true;
			DateTime? dateTime = (DateTime?)e.NewValue;
			if (dateTime != null)
			{
				dateTimePicker.SelectedTime = new TimeSpan?(dateTime.Value.TimeOfDay);
				dateTimePicker.OnSelectedDateChanged(new TimePickerBaseSelectionChangedEventArgs<DateTime?>(DateTimePicker.SelectedDateChangedEvent, (DateTime?)e.OldValue, (DateTime?)e.NewValue));
			}
			else
			{
				dateTimePicker.SetDefaultTimeOfDayValues();
			}
			dateTimePicker._deactivateWriteValueToTextBox = false;
			dateTimePicker.WriteValueToTextBox();
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0001E0F0 File Offset: 0x0001C2F0
		private DateTime? GetSelectedDateTimeFromGUI()
		{
			DateTime? selectedDate = this.SelectedDate;
			if (selectedDate != null)
			{
				return new DateTime?(selectedDate.Value.Date + base.GetSelectedTimeFromGUI().GetValueOrDefault());
			}
			return null;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0001E140 File Offset: 0x0001C340
		private void SetDatePartValues()
		{
			DateTime? selectedDateTimeFromGUI = this.GetSelectedDateTimeFromGUI();
			if (selectedDateTimeFromGUI != null)
			{
				DateTime? dateTime = selectedDateTimeFromGUI;
				DateTime minValue = DateTime.MinValue;
				this.DisplayDate = ((dateTime == null || (dateTime != null && dateTime.GetValueOrDefault() != minValue)) ? selectedDateTimeFromGUI : new DateTime?(DateTime.Today));
				if (this.SelectedDate != this.DisplayDate)
				{
					DateTime? selectedDate = this.SelectedDate;
					minValue = DateTime.MinValue;
					if (selectedDate == null || (selectedDate != null && selectedDate.GetValueOrDefault() != minValue))
					{
						goto IL_E0;
					}
				}
				if (base.Popup == null || !base.Popup.IsOpen)
				{
					return;
				}
				IL_E0:
				this.SelectedDate = this.DisplayDate;
			}
		}

		// Token: 0x040002F8 RID: 760
		public static readonly DependencyProperty DisplayDateEndProperty = DatePicker.DisplayDateEndProperty.AddOwner(typeof(DateTimePicker));

		// Token: 0x040002F9 RID: 761
		public static readonly DependencyProperty DisplayDateProperty = DatePicker.DisplayDateProperty.AddOwner(typeof(DateTimePicker));

		// Token: 0x040002FA RID: 762
		public static readonly DependencyProperty DisplayDateStartProperty = DatePicker.DisplayDateStartProperty.AddOwner(typeof(DateTimePicker));

		// Token: 0x040002FB RID: 763
		public static readonly DependencyProperty FirstDayOfWeekProperty = DatePicker.FirstDayOfWeekProperty.AddOwner(typeof(DateTimePicker));

		// Token: 0x040002FC RID: 764
		public static readonly DependencyProperty IsTodayHighlightedProperty = DatePicker.IsTodayHighlightedProperty.AddOwner(typeof(DateTimePicker));

		// Token: 0x040002FD RID: 765
		public static readonly DependencyProperty SelectedDateFormatProperty = DatePicker.SelectedDateFormatProperty.AddOwner(typeof(DateTimePicker), new FrameworkPropertyMetadata(DatePickerFormat.Short, new PropertyChangedCallback(DateTimePicker.OnSelectedDateFormatChanged)));

		// Token: 0x040002FE RID: 766
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(DateTimePicker), new PropertyMetadata(Orientation.Horizontal, null, new CoerceValueCallback(DateTimePicker.CoerceOrientation)));

		// Token: 0x04000300 RID: 768
		public static readonly DependencyProperty SelectedDateProperty;

		// Token: 0x04000301 RID: 769
		private const string ElementCalendar = "PART_Calendar";

		// Token: 0x04000302 RID: 770
		private System.Windows.Controls.Calendar _calendar;

		// Token: 0x04000303 RID: 771
		private bool _deactivateWriteValueToTextBox;
	}
}
