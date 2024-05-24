using System;
using System.Globalization;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200001E RID: 30
	[ValueConversion(typeof(TimeSpan?), typeof(string))]
	internal class TimeSpanToStringConverter : IValueConverter
	{
		// Token: 0x060000AA RID: 170 RVA: 0x00003AF8 File Offset: 0x00001CF8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TimeSpan? timeSpan = value as TimeSpan?;
			if (timeSpan == null)
			{
				return null;
			}
			return DateTime.MinValue.Add(timeSpan.GetValueOrDefault()).ToString(culture.DateTimeFormat.LongTimePattern, culture);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003B48 File Offset: 0x00001D48
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			DateTime dateTime;
			if (DateTime.TryParseExact(value.ToString(), culture.DateTimeFormat.LongTimePattern, culture, DateTimeStyles.None, out dateTime))
			{
				return dateTime.TimeOfDay;
			}
			return null;
		}
	}
}
