using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000078 RID: 120
	public class DriveSpaceRequired
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00003F8A File Offset: 0x0000218A
		// (set) Token: 0x0600033C RID: 828 RVA: 0x00003F92 File Offset: 0x00002192
		public string Drive { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00003F9B File Offset: 0x0000219B
		// (set) Token: 0x0600033E RID: 830 RVA: 0x00003FA3 File Offset: 0x000021A3
		public ulong Required { get; set; }
	}
}
