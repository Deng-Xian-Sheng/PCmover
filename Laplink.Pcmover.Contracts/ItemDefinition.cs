using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200002D RID: 45
	public class ItemDefinition
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00002CF4 File Offset: 0x00000EF4
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00002CFC File Offset: 0x00000EFC
		public string Name { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00002D05 File Offset: 0x00000F05
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00002D0D File Offset: 0x00000F0D
		public ulong Size { get; set; }
	}
}
