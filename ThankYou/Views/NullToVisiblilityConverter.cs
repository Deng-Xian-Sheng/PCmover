using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ThankYou.Views
{
	// Token: 0x0200000B RID: 11
	public class NullToVisiblilityConverter : IValueConverter
	{
		// Token: 0x06000028 RID: 40 RVA: 0x0000271D File Offset: 0x0000091D
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Visibility.Collapsed;
			}
			return Visibility.Visible;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000026FE File Offset: 0x000008FE
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Visibility.Visible;
		}
	}
}
