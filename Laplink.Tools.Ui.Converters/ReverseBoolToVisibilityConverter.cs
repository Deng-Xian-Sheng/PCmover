using System;
using System.Globalization;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x0200000C RID: 12
	public class ReverseBoolToVisibilityConverter : BoolToVisibilityConverter
	{
		// Token: 0x06000030 RID: 48 RVA: 0x000024A0 File Offset: 0x000006A0
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = (bool)value;
			return base.Convert(!flag, targetType, parameter, culture);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000024C7 File Offset: 0x000006C7
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)base.ConvertBack(value, targetType, parameter, culture);
		}
	}
}
