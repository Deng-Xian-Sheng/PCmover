using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000009 RID: 9
	public class EnumToBooleanConverter : IValueConverter
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002398 File Offset: 0x00000598
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null)
			{
				return false;
			}
			return value.Equals(Enum.Parse(value.GetType(), parameter.ToString()));
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000023C3 File Offset: 0x000005C3
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || parameter == null || !(bool)value)
			{
				return null;
			}
			return Enum.Parse(targetType, parameter.ToString());
		}
	}
}
