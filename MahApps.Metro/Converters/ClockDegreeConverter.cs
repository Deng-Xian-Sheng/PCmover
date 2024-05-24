using System;
using System.Globalization;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200000A RID: 10
	[ValueConversion(typeof(double), typeof(double))]
	public class ClockDegreeConverter : IValueConverter
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000306F File Offset: 0x0000126F
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00003077 File Offset: 0x00001277
		public double TotalParts { get; set; }

		// Token: 0x06000046 RID: 70 RVA: 0x00003080 File Offset: 0x00001280
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return 0;
			}
			if (value is TimeSpan)
			{
				TimeSpan timeSpan = (TimeSpan)value;
				string a = (string)parameter;
				if (a == "h")
				{
					return 30.0 * timeSpan.TotalHours;
				}
				if (a == "m")
				{
					return 6.0 * timeSpan.TotalMinutes;
				}
				if (!(a == "s"))
				{
					throw new ArgumentException("must be \"h\", \"m\", or \"s", "parameter");
				}
				return 6.0 * (double)timeSpan.Seconds;
			}
			else
			{
				if (value is int)
				{
					return 360.0 / this.TotalParts * (double)((int)value);
				}
				return 360.0 / this.TotalParts * (double)value;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003171 File Offset: 0x00001371
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException();
		}
	}
}
