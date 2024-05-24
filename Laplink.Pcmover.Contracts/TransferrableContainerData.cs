using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200008B RID: 139
	public class TransferrableContainerData : TransferrableContainerInfo
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600039F RID: 927 RVA: 0x000044D2 File Offset: 0x000026D2
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x000044DA File Offset: 0x000026DA
		public IEnumerable<TransferrableContainerInfo> Containers { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x000044E3 File Offset: 0x000026E3
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x000044EB File Offset: 0x000026EB
		public IEnumerable<TransferrableItemDefinition> Items { get; set; }
	}
}
