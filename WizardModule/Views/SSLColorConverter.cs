using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WizardModule.Views
{
	// Token: 0x0200001D RID: 29
	public class SSLColorConverter : IMultiValueConverter
	{
		// Token: 0x060003F5 RID: 1013 RVA: 0x00008AD0 File Offset: 0x00006CD0
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				bool flag = (bool)values[0];
				bool flag2 = (bool)values[1];
				if (flag && flag2)
				{
					return Color.FromArgb(byte.MaxValue, 220, byte.MaxValue, 220);
				}
				if (flag)
				{
					return Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, 180);
				}
			}
			catch
			{
			}
			return Color.FromArgb(byte.MaxValue, byte.MaxValue, 220, 220);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00008B70 File Offset: 0x00006D70
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
