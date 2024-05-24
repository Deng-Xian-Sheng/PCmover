using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000010 RID: 16
	public class AllTrueBoolToVisibilityConverter : VisibilityConverter, IMultiValueConverter
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000025B0 File Offset: 0x000007B0
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = true;
			foreach (object obj in values)
			{
				if (obj is bool)
				{
					bool flag2 = (bool)obj;
					flag = (flag && flag2);
				}
			}
			return base.Convert(flag, parameter);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000025F5 File Offset: 0x000007F5
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
