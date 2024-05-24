using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000015 RID: 21
	public class MetroTabItemCloseButtonWidthConverter : IValueConverter
	{
		// Token: 0x06000083 RID: 131 RVA: 0x000035DC File Offset: 0x000017DC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (double)System.Convert.ToInt32(value) * 0.5;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000035F4 File Offset: 0x000017F4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
