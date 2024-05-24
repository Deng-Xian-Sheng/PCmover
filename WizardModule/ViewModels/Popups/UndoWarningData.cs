using System;
using System.Threading;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000B0 RID: 176
	public class UndoWarningData
	{
		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x00027E30 File Offset: 0x00026030
		// (set) Token: 0x06000EFF RID: 3839 RVA: 0x00027E38 File Offset: 0x00026038
		public bool Start { get; set; }

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06000F00 RID: 3840 RVA: 0x00027E41 File Offset: 0x00026041
		// (set) Token: 0x06000F01 RID: 3841 RVA: 0x00027E49 File Offset: 0x00026049
		public AutoResetEvent ResetEvent { get; set; }
	}
}
