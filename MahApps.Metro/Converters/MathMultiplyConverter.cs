using System;
using System.Globalization;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000013 RID: 19
	[MarkupExtensionReturnType(typeof(MathMultiplyConverter))]
	public sealed class MathMultiplyConverter : MarkupMultiConverter
	{
		// Token: 0x06000076 RID: 118 RVA: 0x000034EA File Offset: 0x000016EA
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(values, targetType, parameter, culture);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000034FC File Offset: 0x000016FC
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(value, targetType, parameter, culture);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000350E File Offset: 0x0000170E
		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetTypes, parameter, culture);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003520 File Offset: 0x00001720
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetType, parameter, culture);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003532 File Offset: 0x00001732
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			MathMultiplyConverter result;
			if ((result = MathMultiplyConverter._instance) == null)
			{
				result = (MathMultiplyConverter._instance = new MathMultiplyConverter());
			}
			return result;
		}

		// Token: 0x04000019 RID: 25
		private static MathMultiplyConverter _instance;

		// Token: 0x0400001A RID: 26
		private readonly MathConverter theMathConverter = new MathConverter
		{
			Operation = MathOperation.Multiply
		};
	}
}
