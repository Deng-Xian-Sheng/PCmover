using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200002E RID: 46
	public class ContainerData : ContainerInfo
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00002D16 File Offset: 0x00000F16
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00002D1E File Offset: 0x00000F1E
		public IEnumerable<ContainerInfo> Containers { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00002D27 File Offset: 0x00000F27
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00002D2F File Offset: 0x00000F2F
		public IEnumerable<ItemDefinition> Items { get; set; }
	}
}
