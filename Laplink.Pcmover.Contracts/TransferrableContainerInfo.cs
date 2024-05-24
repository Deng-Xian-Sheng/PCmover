using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000089 RID: 137
	public class TransferrableContainerInfo : ContainerInfo, ITransferrableContainer, ITransferrable
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00004486 File Offset: 0x00002686
		// (set) Token: 0x06000396 RID: 918 RVA: 0x0000448E File Offset: 0x0000268E
		public Transferrable Transferrable { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00004497 File Offset: 0x00002697
		// (set) Token: 0x06000398 RID: 920 RVA: 0x0000449F File Offset: 0x0000269F
		public string Target { get; set; }
	}
}
