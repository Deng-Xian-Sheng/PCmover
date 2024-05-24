using System;
using System.Threading;
using Laplink.Service.Contracts;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000AA RID: 170
	public class RebootPendingData
	{
		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x000279AB File Offset: 0x00025BAB
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x000279B3 File Offset: 0x00025BB3
		public RebootPendingReasons Reasons { get; set; }

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x000279BC File Offset: 0x00025BBC
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x000279C4 File Offset: 0x00025BC4
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x000279CD File Offset: 0x00025BCD
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x000279D5 File Offset: 0x00025BD5
		public bool Cancelled { get; set; }
	}
}
