using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x0200000F RID: 15
	public class ReverseMultiNullVisibilityConverter : VisibilityConverter, IMultiValueConverter
	{
		// Token: 0x06000039 RID: 57 RVA: 0x0000256C File Offset: 0x0000076C
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return base.Convert(values.All((object v) => v == null), parameter);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000259F File Offset: 0x0000079F
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
