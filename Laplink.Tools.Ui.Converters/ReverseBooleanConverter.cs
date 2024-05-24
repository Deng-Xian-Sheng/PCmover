using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000005 RID: 5
	public class ReverseBooleanConverter : IValueConverter
	{
		// Token: 0x06000010 RID: 16 RVA: 0x0000220E File Offset: 0x0000040E
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000221E File Offset: 0x0000041E
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
