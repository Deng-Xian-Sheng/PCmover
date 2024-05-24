using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000009 RID: 9
	public class BackgroundToForegroundConverter : IValueConverter, IMultiValueConverter
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002F52 File Offset: 0x00001152
		private BackgroundToForegroundConverter()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002F5A File Offset: 0x0000115A
		public static BackgroundToForegroundConverter Instance
		{
			get
			{
				BackgroundToForegroundConverter result;
				if ((result = BackgroundToForegroundConverter._instance) == null)
				{
					result = (BackgroundToForegroundConverter._instance = new BackgroundToForegroundConverter());
				}
				return result;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002F70 File Offset: 0x00001170
		private Color IdealTextColor(Color bg)
		{
			int num = System.Convert.ToInt32((double)bg.R * 0.299 + (double)bg.G * 0.587 + (double)bg.B * 0.114);
			if (255 - num >= 86)
			{
				return Colors.White;
			}
			return Colors.Black;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002FD1 File Offset: 0x000011D1
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is SolidColorBrush)
			{
				SolidColorBrush solidColorBrush = new SolidColorBrush(this.IdealTextColor(((SolidColorBrush)value).Color));
				solidColorBrush.Freeze();
				return solidColorBrush;
			}
			return Brushes.White;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002FFD File Offset: 0x000011FD
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003004 File Offset: 0x00001204
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			Brush value = (values.Length != 0) ? (values[0] as Brush) : null;
			Brush brush = (values.Length > 1) ? (values[1] as Brush) : null;
			if (brush != null)
			{
				return brush;
			}
			return this.Convert(value, targetType, parameter, culture);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003043 File Offset: 0x00001243
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return (from t in targetTypes
			select DependencyProperty.UnsetValue).ToArray<object>();
		}

		// Token: 0x0400000B RID: 11
		private static BackgroundToForegroundConverter _instance;
	}
}
