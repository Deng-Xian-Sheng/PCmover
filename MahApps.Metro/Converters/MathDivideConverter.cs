using System;
using System.Globalization;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000014 RID: 20
	[MarkupExtensionReturnType(typeof(MathDivideConverter))]
	public sealed class MathDivideConverter : MarkupMultiConverter
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00003564 File Offset: 0x00001764
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(values, targetType, parameter, culture);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003576 File Offset: 0x00001776
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(value, targetType, parameter, culture);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003588 File Offset: 0x00001788
		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetTypes, parameter, culture);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000359A File Offset: 0x0000179A
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetType, parameter, culture);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000035AC File Offset: 0x000017AC
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			MathDivideConverter result;
			if ((result = MathDivideConverter._instance) == null)
			{
				result = (MathDivideConverter._instance = new MathDivideConverter());
			}
			return result;
		}

		// Token: 0x0400001B RID: 27
		private static MathDivideConverter _instance;

		// Token: 0x0400001C RID: 28
		private readonly MathConverter theMathConverter = new MathConverter
		{
			Operation = MathOperation.Divide
		};
	}
}
