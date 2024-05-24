using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MahApps.Metro.Converters
{
	// Token: 0x0200001F RID: 31
	[MarkupExtensionReturnType(typeof(ToUpperConverter))]
	public class ToUpperConverter : MarkupConverter
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00003B8B File Offset: 0x00001D8B
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			ToUpperConverter result;
			if ((result = ToUpperConverter._instance) == null)
			{
				result = (ToUpperConverter._instance = new ToUpperConverter());
			}
			return result;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003BA4 File Offset: 0x00001DA4
		protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = value as string;
			if (text == null)
			{
				return value;
			}
			return text.ToUpper();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003BC3 File Offset: 0x00001DC3
		protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}

		// Token: 0x0400002A RID: 42
		private static ToUpperConverter _instance;
	}
}
