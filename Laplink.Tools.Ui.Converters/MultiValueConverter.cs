using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000006 RID: 6
	public class MultiValueConverter : IMultiValueConverter
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002236 File Offset: 0x00000436
		public object Convert(object[] values, Type targetType, object parm, CultureInfo culture)
		{
			return values.Clone();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000223E File Offset: 0x0000043E
		public object[] ConvertBack(object value, Type[] targetTypes, object parm, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
