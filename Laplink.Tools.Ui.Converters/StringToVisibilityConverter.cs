using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x0200000D RID: 13
	public class StringToVisibilityConverter : VisibilityConverter, IValueConverter
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000024EC File Offset: 0x000006EC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool bValue = value != null && !string.IsNullOrWhiteSpace(value.ToString());
			return base.Convert(bValue, parameter);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000251B File Offset: 0x0000071B
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
