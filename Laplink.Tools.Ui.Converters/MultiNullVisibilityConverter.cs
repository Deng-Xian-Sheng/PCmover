using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x0200000E RID: 14
	public class MultiNullVisibilityConverter : VisibilityConverter, IMultiValueConverter
	{
		// Token: 0x06000036 RID: 54 RVA: 0x0000252A File Offset: 0x0000072A
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return base.Convert(values.Any((object v) => v != null), parameter);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000255D File Offset: 0x0000075D
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
