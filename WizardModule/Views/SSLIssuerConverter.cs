using System;
using System.Globalization;
using System.Windows.Data;
using WizardModule.Properties;

namespace WizardModule.Views
{
	// Token: 0x0200001C RID: 28
	public sealed class SSLIssuerConverter : IValueConverter
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x00008A94 File Offset: 0x00006C94
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				if (string.IsNullOrEmpty((string)value))
				{
					return Resources.SSL_SelfSigned;
				}
			}
			catch
			{
			}
			return value;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00008A8C File Offset: 0x00006C8C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Empty;
		}
	}
}
