using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000022 RID: 34
	public class InteractiveCustomizationPolicyData
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00002AEA File Offset: 0x00000CEA
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00002AF2 File Offset: 0x00000CF2
		public bool Applications { get; set; } = true;

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00002AFB File Offset: 0x00000CFB
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00002B03 File Offset: 0x00000D03
		public bool FileFilters { get; set; } = true;

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00002B0C File Offset: 0x00000D0C
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00002B14 File Offset: 0x00000D14
		public bool DirFilters { get; set; } = true;

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002B1D File Offset: 0x00000D1D
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00002B25 File Offset: 0x00000D25
		public bool UserMap { get; set; } = true;

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00002B2E File Offset: 0x00000D2E
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00002B36 File Offset: 0x00000D36
		public bool DriveMap { get; set; } = true;

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00002B3F File Offset: 0x00000D3F
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00002B47 File Offset: 0x00000D47
		public bool MigMod { get; set; } = true;
	}
}
