using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000027 RID: 39
	public class ContainerStats
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00002C13 File Offset: 0x00000E13
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00002C1B File Offset: 0x00000E1B
		public ulong NumContainers { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00002C24 File Offset: 0x00000E24
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00002C2C File Offset: 0x00000E2C
		public ulong NumItems { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00002C35 File Offset: 0x00000E35
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00002C3D File Offset: 0x00000E3D
		public ulong TotalSize { get; set; }
	}
}
