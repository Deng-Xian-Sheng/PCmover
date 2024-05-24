using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000011 RID: 17
	public class StringMatchVisibilityConverter : VisibilityConverter, IValueConverter
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00002604 File Offset: 0x00000804
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return base.Convert(false, null);
			}
			return base.Convert(string.Compare(value.ToString(), parameter.ToString(), true) == 0, null);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000263B File Offset: 0x0000083B
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
