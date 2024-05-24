using System;
using System.Globalization;
using System.Windows.Data;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000003 RID: 3
	public class BoolToStringConverter : BoolConverter, IValueConverter
	{
		// Token: 0x0600000A RID: 10 RVA: 0x0000211D File Offset: 0x0000031D
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return base.Convert(value as bool?);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002130 File Offset: 0x00000330
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return base.ConvertBack((value != null) ? value.ToString() : null);
		}
	}
}
