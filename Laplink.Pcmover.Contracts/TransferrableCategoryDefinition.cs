using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000088 RID: 136
	public class TransferrableCategoryDefinition : CategoryDefinition, ITransferrableContainer, ITransferrable
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0000445C File Offset: 0x0000265C
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00004464 File Offset: 0x00002664
		public Transferrable Transferrable { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0000446D File Offset: 0x0000266D
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00004475 File Offset: 0x00002675
		public string Target { get; set; }
	}
}
