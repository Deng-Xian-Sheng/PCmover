using System;
using System.Collections.Generic;
using System.Threading;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000AE RID: 174
	public class SelectAzureAccountData
	{
		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x00027CDE File Offset: 0x00025EDE
		// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x00027CE6 File Offset: 0x00025EE6
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x00027CEF File Offset: 0x00025EEF
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x00027CF7 File Offset: 0x00025EF7
		public List<string> Accounts { get; set; }

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x00027D00 File Offset: 0x00025F00
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x00027D08 File Offset: 0x00025F08
		public string SelectedAccount { get; set; }
	}
}
