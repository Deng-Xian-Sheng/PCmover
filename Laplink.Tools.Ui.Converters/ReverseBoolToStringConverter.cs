using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000004 RID: 4
	public class ReverseBoolToStringConverter : BoolConverter, IValueConverter
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002154 File Offset: 0x00000354
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool? flag = value as bool?;
			if (flag == null)
			{
				return base.Convert(flag);
			}
			return base.Convert(!flag);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021AC File Offset: 0x000003AC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool? flag = base.ConvertBack((value != null) ? value.ToString() : null);
			if (flag == null)
			{
				return flag;
			}
			return !flag;
		}
	}
}
