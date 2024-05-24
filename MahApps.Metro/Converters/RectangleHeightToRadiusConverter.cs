using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000018 RID: 24
	[ValueConversion(typeof(double?), typeof(double))]
	[MarkupExtensionReturnType(typeof(RectangleHeightToRadiusConverter))]
	public class RectangleHeightToRadiusConverter : MarkupConverter
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00003689 File Offset: 0x00001889
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			RectangleHeightToRadiusConverter result;
			if ((result = RectangleHeightToRadiusConverter._instance) == null)
			{
				result = (RectangleHeightToRadiusConverter._instance = new RectangleHeightToRadiusConverter());
			}
			return result;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000036A0 File Offset: 0x000018A0
		protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value as double?).GetValueOrDefault(0.0) / 2.0;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000036D8 File Offset: 0x000018D8
		protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x0400001E RID: 30
		private static RectangleHeightToRadiusConverter _instance;
	}
}
