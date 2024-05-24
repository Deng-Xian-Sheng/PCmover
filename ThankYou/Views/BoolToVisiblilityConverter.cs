using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ThankYou.Views
{
	// Token: 0x02000009 RID: 9
	public class BoolToVisiblilityConverter : IValueConverter
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000026E7 File Offset: 0x000008E7
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000026FE File Offset: 0x000008FE
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Visibility.Visible;
		}
	}
}
