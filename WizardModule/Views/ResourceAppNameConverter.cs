using System;
using System.Globalization;
using System.Windows.Data;
using PcmBrandUI.Properties;

namespace WizardModule.Views
{
	// Token: 0x0200001B RID: 27
	public sealed class ResourceAppNameConverter : IValueConverter
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x00008A48 File Offset: 0x00006C48
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				string text = (string)value;
				return (text != null) ? text.Replace("%p", Resources.ProgramName) : null;
			}
			catch (Exception)
			{
			}
			return value;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00008A8C File Offset: 0x00006C8C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Empty;
		}
	}
}
