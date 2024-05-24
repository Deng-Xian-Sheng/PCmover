using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200000D RID: 13
	[MarkupExtensionReturnType(typeof(IValueConverter))]
	public abstract class MarkupConverter : MarkupExtension, IValueConverter
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00003211 File Offset: 0x00001411
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}

		// Token: 0x06000054 RID: 84
		protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		// Token: 0x06000055 RID: 85
		protected abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

		// Token: 0x06000056 RID: 86 RVA: 0x00003214 File Offset: 0x00001414
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = this.Convert(value, targetType, parameter, culture);
			}
			catch
			{
				result = DependencyProperty.UnsetValue;
			}
			return result;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000324C File Offset: 0x0000144C
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			try
			{
				result = this.ConvertBack(value, targetType, parameter, culture);
			}
			catch
			{
				result = DependencyProperty.UnsetValue;
			}
			return result;
		}
	}
}
