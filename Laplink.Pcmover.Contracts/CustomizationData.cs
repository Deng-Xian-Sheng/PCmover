using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000034 RID: 52
	public class CustomizationData
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00002ED0 File Offset: 0x000010D0
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00002ED8 File Offset: 0x000010D8
		public CustomizationResult Result { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00002EE1 File Offset: 0x000010E1
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00002EE9 File Offset: 0x000010E9
		public string Message { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00002EF2 File Offset: 0x000010F2
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00002EFA File Offset: 0x000010FA
		public CustomizationAffects Affects { get; set; }
	}
}
