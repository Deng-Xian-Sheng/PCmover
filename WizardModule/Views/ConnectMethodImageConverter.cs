using System;
using System.Globalization;
using System.Windows.Data;
using Laplink.Pcmover.Contracts;

namespace WizardModule.Views
{
	// Token: 0x02000019 RID: 25
	public class ConnectMethodImageConverter : IValueConverter
	{
		// Token: 0x060003E9 RID: 1001 RVA: 0x0000895F File Offset: 0x00006B5F
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((TransferMethodType)value == TransferMethodType.Usb)
			{
				return "/WizardModule;component/Assets/usb.png";
			}
			if ((TransferMethodType)value == TransferMethodType.Network || (TransferMethodType)value == TransferMethodType.SSL)
			{
				return "/WizardModule;component/Assets/lan.png";
			}
			return "/WizardModule;component/Assets/file.png";
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00008990 File Offset: 0x00006B90
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
