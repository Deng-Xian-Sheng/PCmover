using System;
using System.Globalization;
using System.Windows.Data;
using Laplink.Pcmover.Contracts;

namespace WizardModule.Views
{
	// Token: 0x02000016 RID: 22
	public class TransferrableToNullableBoolConverter : IValueConverter
	{
		// Token: 0x060003DF RID: 991 RVA: 0x00008874 File Offset: 0x00006A74
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Transferrable transferrable = (Transferrable)value;
			if (transferrable == Transferrable.RuleExcluded)
			{
				return null;
			}
			if (transferrable == Transferrable.Filtered)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000889F File Offset: 0x00006A9F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return Transferrable.RuleExcluded;
			}
			return ((bool)value) ? Transferrable.Transfer : Transferrable.Filtered;
		}
	}
}
