using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200005E RID: 94
	public class SecurityProductsData
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600028A RID: 650 RVA: 0x0000376B File Offset: 0x0000196B
		// (set) Token: 0x0600028B RID: 651 RVA: 0x00003773 File Offset: 0x00001973
		public string AntivirusProduct { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600028C RID: 652 RVA: 0x0000377C File Offset: 0x0000197C
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00003784 File Offset: 0x00001984
		public string FirewallProduct { get; set; }
	}
}
