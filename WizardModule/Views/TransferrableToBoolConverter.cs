using System;
using System.Globalization;
using System.Windows.Data;
using Laplink.Pcmover.Contracts;

namespace WizardModule.Views
{
	// Token: 0x02000015 RID: 21
	public class TransferrableToBoolConverter : IValueConverter
	{
		// Token: 0x060003DC RID: 988 RVA: 0x00008830 File Offset: 0x00006A30
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Transferrable transferrable = (Transferrable)value;
			if (transferrable == Transferrable.RuleExcluded)
			{
				return false;
			}
			if (transferrable == Transferrable.Filtered)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00008860 File Offset: 0x00006A60
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? Transferrable.Transfer : Transferrable.Filtered;
		}
	}
}
