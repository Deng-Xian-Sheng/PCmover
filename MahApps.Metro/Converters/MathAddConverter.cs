using System;
using System.Globalization;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000011 RID: 17
	[MarkupExtensionReturnType(typeof(MathAddConverter))]
	public sealed class MathAddConverter : MarkupMultiConverter
	{
		// Token: 0x06000068 RID: 104 RVA: 0x000033F6 File Offset: 0x000015F6
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(values, targetType, parameter, culture);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003408 File Offset: 0x00001608
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.Convert(value, targetType, parameter, culture);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000341A File Offset: 0x0000161A
		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetTypes, parameter, culture);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000342C File Offset: 0x0000162C
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return this.theMathConverter.ConvertBack(value, targetType, parameter, culture);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000343E File Offset: 0x0000163E
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			MathAddConverter result;
			if ((result = MathAddConverter._instance) == null)
			{
				result = (MathAddConverter._instance = new MathAddConverter());
			}
			return result;
		}

		// Token: 0x04000015 RID: 21
		private static MathAddConverter _instance;

		// Token: 0x04000016 RID: 22
		private readonly MathConverter theMathConverter = new MathConverter
		{
			Operation = MathOperation.Add
		};
	}
}
