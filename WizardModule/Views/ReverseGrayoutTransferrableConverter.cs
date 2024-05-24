using System;
using System.Globalization;
using System.Windows.Data;
using Laplink.Pcmover.Contracts;

namespace WizardModule.Views
{
	// Token: 0x02000017 RID: 23
	public class ReverseGrayoutTransferrableConverter : IValueConverter
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x000088BC File Offset: 0x00006ABC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Transferrable transferrable = (Transferrable)value;
			if (transferrable == Transferrable.RuleExcluded)
			{
				return "Gray";
			}
			if (transferrable == Transferrable.Filtered)
			{
				return "Silver";
			}
			return "Black";
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000088EC File Offset: 0x00006AEC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string a = (string)value;
			if (a == "Silver")
			{
				return Transferrable.Filtered;
			}
			if (!(a == "Gray"))
			{
				return Transferrable.Transfer;
			}
			return Transferrable.RuleExcluded;
		}
	}
}
