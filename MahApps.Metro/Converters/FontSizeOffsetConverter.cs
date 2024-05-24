using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200000B RID: 11
	public class FontSizeOffsetConverter : IValueConverter
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00003182 File Offset: 0x00001382
		private FontSizeOffsetConverter()
		{
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000318A File Offset: 0x0000138A
		public static FontSizeOffsetConverter Instance
		{
			get
			{
				FontSizeOffsetConverter result;
				if ((result = FontSizeOffsetConverter._instance) == null)
				{
					result = (FontSizeOffsetConverter._instance = new FontSizeOffsetConverter());
				}
				return result;
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000031A0 File Offset: 0x000013A0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is double && parameter is double)
			{
				double num = (double)parameter;
				return Math.Round((double)value + num);
			}
			return value;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000031D8 File Offset: 0x000013D8
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x0400000D RID: 13
		private static FontSizeOffsetConverter _instance;
	}
}
