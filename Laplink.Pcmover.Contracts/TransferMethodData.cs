using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200007D RID: 125
	public class TransferMethodData
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000348 RID: 840 RVA: 0x00003FED File Offset: 0x000021ED
		// (set) Token: 0x06000349 RID: 841 RVA: 0x00003FF5 File Offset: 0x000021F5
		public int Handle { get; set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00003FFE File Offset: 0x000021FE
		// (set) Token: 0x0600034B RID: 843 RVA: 0x00004006 File Offset: 0x00002206
		public TransferMethodType TransferMethodType { get; set; }
	}
}
