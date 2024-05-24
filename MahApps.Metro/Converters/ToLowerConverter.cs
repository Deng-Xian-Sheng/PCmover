using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x02000020 RID: 32
	[MarkupExtensionReturnType(typeof(ToLowerConverter))]
	public class ToLowerConverter : MarkupConverter
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			ToLowerConverter result;
			if ((result = ToLowerConverter._instance) == null)
			{
				result = (ToLowerConverter._instance = new ToLowerConverter());
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003BEC File Offset: 0x00001DEC
		protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = value as string;
			if (text == null)
			{
				return value;
			}
			return text.ToLower();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003C0B File Offset: 0x00001E0B
		protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}

		// Token: 0x0400002B RID: 43
		private static ToLowerConverter _instance;
	}
}
