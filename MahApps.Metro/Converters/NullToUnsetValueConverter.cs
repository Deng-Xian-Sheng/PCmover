using System;
using System.Globalization;
using System.Windows;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000016 RID: 22
	public class NullToUnsetValueConverter : MarkupConverter
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00003605 File Offset: 0x00001805
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			NullToUnsetValueConverter result;
			if ((result = NullToUnsetValueConverter._instance) == null)
			{
				result = (NullToUnsetValueConverter._instance = new NullToUnsetValueConverter());
			}
			return result;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000361B File Offset: 0x0000181B
		protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value ?? DependencyProperty.UnsetValue;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003627 File Offset: 0x00001827
		protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x0400001D RID: 29
		private static NullToUnsetValueConverter _instance;
	}
}
