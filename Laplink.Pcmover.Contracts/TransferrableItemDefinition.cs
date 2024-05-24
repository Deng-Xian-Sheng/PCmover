using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200008A RID: 138
	public class TransferrableItemDefinition : ItemDefinition, ITransferrable
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600039A RID: 922 RVA: 0x000044A8 File Offset: 0x000026A8
		// (set) Token: 0x0600039B RID: 923 RVA: 0x000044B0 File Offset: 0x000026B0
		public Transferrable Transferrable { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600039C RID: 924 RVA: 0x000044B9 File Offset: 0x000026B9
		// (set) Token: 0x0600039D RID: 925 RVA: 0x000044C1 File Offset: 0x000026C1
		public string Target { get; set; }
	}
}
