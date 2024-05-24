using System;
using System.Globalization;
using System.Windows.Data;

namespace WizardModule.Views
{
	// Token: 0x02000018 RID: 24
	public class AppImageConverter : IValueConverter
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00008930 File Offset: 0x00006B30
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value ?? AppImageConverter._defaultAppImage;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000893C File Offset: 0x00006B3C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!((string)value == AppImageConverter._defaultAppImage))
			{
				return value;
			}
			return null;
		}

		// Token: 0x0400003E RID: 62
		private static string _defaultAppImage = "/WizardModule;component/Assets/DefaultAppImage.png";
	}
}
