using System;

namespace PCmover.Infrastructure
{
	// Token: 0x02000030 RID: 48
	public class PolicyInfo
	{
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00007823 File Offset: 0x00005A23
		// (set) Token: 0x060002AF RID: 687 RVA: 0x0000782B File Offset: 0x00005A2B
		public string PolicyPath { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00007834 File Offset: 0x00005A34
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x0000783C File Offset: 0x00005A3C
		public string PolicyString { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00007845 File Offset: 0x00005A45
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000784D File Offset: 0x00005A4D
		public DefaultPolicy Policy { get; set; }
	}
}
