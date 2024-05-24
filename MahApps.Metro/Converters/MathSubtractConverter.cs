using System;
using System.Globalization;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000012 RID: 18
	[MarkupExtensionReturnType(typeof(MathSubtractConverter))]
	public sealed class MathSubtractConverter : MarkupMultiConverter
	{
		// Token: 0x0600006F RID: 111 RVA: 0x00003470 File Offset: 0x00001670
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(values, targetType, parameter, culture);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003482 File Offset: 0x00001682
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(value, targetType, parameter, culture);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003494 File Offset: 0x00001694
		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetTypes, parameter, culture);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000034A6 File Offset: 0x000016A6
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetType, parameter, culture);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000034B8 File Offset: 0x000016B8
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			MathSubtractConverter result;
			if ((result = MathSubtractConverter._instance) == null)
			{
				result = (MathSubtractConverter._instance = new MathSubtractConverter());
			}
			return result;
		}

		// Token: 0x04000017 RID: 23
		private static MathSubtractConverter _instance;

		// Token: 0x04000018 RID: 24
		private readonly MathConverter theMathConverter = new MathConverter
		{
			Operation = MathOperation.Subtract
		};
	}
}
