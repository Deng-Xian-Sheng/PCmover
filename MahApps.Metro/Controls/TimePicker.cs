using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200008D RID: 141
	public class TimePicker : TimePickerBase
	{
		// Token: 0x06000768 RID: 1896 RVA: 0x0001E241 File Offset: 0x0001C441
		static TimePicker()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0001E266 File Offset: 0x0001C466
		public TimePicker()
		{
			base.IsDatePickerVisible = false;
		}
	}
}
