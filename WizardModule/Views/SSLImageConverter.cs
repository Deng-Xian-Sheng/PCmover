using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WizardModule.Views
{
	// Token: 0x0200001E RID: 30
	public class SSLImageConverter : IMultiValueConverter
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x00008B74 File Offset: 0x00006D74
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				if (values.Length != 0)
				{
					object obj = values[0];
					if (obj is bool)
					{
						bool flag = (bool)obj;
						if (flag)
						{
							return new BitmapImage(new Uri("pack://application:,,,/WizardModule;Component/Assets/SSLLocked.png", UriKind.RelativeOrAbsolute));
						}
					}
				}
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00008B70 File Offset: 0x00006D70
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
