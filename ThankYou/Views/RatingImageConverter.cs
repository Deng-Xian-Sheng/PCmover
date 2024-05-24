using System;
using System.Globalization;
using System.Windows.Data;

namespace ThankYou.Views
{
	// Token: 0x0200000C RID: 12
	public class RatingImageConverter : IValueConverter
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00002730 File Offset: 0x00000930
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int num = System.Convert.ToInt32(parameter);
			if ((int)value >= num)
			{
				return "/ThankYou;component/Assets/star_On.png";
			}
			return "/ThankYou;component/Assets/star_Off.png";
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002758 File Offset: 0x00000958
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
