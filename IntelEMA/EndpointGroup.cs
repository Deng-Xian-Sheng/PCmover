using System;

namespace IntelEMA
{
	// Token: 0x02000007 RID: 7
	public class EndpointGroup
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002175 File Offset: 0x00000375
		// (set) Token: 0x0600000E RID: 14 RVA: 0x0000217D File Offset: 0x0000037D
		public string EndpointGroupId { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002186 File Offset: 0x00000386
		// (set) Token: 0x06000010 RID: 16 RVA: 0x0000218E File Offset: 0x0000038E
		public string Name { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002197 File Offset: 0x00000397
		// (set) Token: 0x06000012 RID: 18 RVA: 0x0000219F File Offset: 0x0000039F
		public int? EndpointCount { get; set; }
	}
}
