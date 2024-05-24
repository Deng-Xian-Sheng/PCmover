using System;
using System.Windows;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x0200000A RID: 10
	public class VisibilityConverter
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000023E9 File Offset: 0x000005E9
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000023F1 File Offset: 0x000005F1
		public Visibility HiddenVisibility { get; set; } = Visibility.Collapsed;

		// Token: 0x06000027 RID: 39 RVA: 0x000023FC File Offset: 0x000005FC
		public Visibility Convert(bool bValue, object parameter)
		{
			if (bValue)
			{
				return Visibility.Visible;
			}
			if (parameter != null)
			{
				string a = parameter.ToString().ToLower();
				if (a == "hidden")
				{
					return Visibility.Hidden;
				}
				if (a == "collapsed")
				{
					return Visibility.Collapsed;
				}
			}
			return this.HiddenVisibility;
		}
	}
}
