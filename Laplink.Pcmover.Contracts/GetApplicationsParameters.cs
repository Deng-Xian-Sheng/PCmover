using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200000D RID: 13
	public class GetApplicationsParameters
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002551 File Offset: 0x00000751
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002559 File Offset: 0x00000759
		public bool DisplayableOnly { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002562 File Offset: 0x00000762
		// (set) Token: 0x06000025 RID: 37 RVA: 0x0000256A File Offset: 0x0000076A
		public bool NotMatchingOnly { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002573 File Offset: 0x00000773
		// (set) Token: 0x06000027 RID: 39 RVA: 0x0000257B File Offset: 0x0000077B
		public bool ModifiableOnly { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002584 File Offset: 0x00000784
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000258C File Offset: 0x0000078C
		public bool ComponentsAlso { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002595 File Offset: 0x00000795
		// (set) Token: 0x0600002B RID: 43 RVA: 0x0000259D File Offset: 0x0000079D
		public bool IncludeBitmap { get; set; }
	}
}
