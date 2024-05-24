using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200000E RID: 14
	[MarkupExtensionReturnType(typeof(MarkupMultiConverter))]
	public abstract class MarkupMultiConverter : MarkupExtension, IValueConverter, IMultiValueConverter
	{
		// Token: 0x06000059 RID: 89
		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		// Token: 0x0600005A RID: 90
		public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

		// Token: 0x0600005B RID: 91
		public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

		// Token: 0x0600005C RID: 92
		public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

		// Token: 0x0600005D RID: 93 RVA: 0x0000328C File Offset: 0x0000148C
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
