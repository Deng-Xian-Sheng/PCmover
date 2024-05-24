using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ThankYou.Views
{
	// Token: 0x0200000A RID: 10
	public class ReverseBoolToVisiblilityConverter : IValueConverter
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002706 File Offset: 0x00000906
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
			{
				return Visibility.Collapsed;
			}
			return Visibility.Visible;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000026FE File Offset: 0x000008FE
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Visibility.Visible;
		}
	}
}
