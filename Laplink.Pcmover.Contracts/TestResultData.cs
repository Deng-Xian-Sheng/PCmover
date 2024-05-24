using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200006D RID: 109
	public class TestResultData
	{
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00003D8A File Offset: 0x00001F8A
		// (set) Token: 0x06000304 RID: 772 RVA: 0x00003D92 File Offset: 0x00001F92
		public byte[] Buffer { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00003D9B File Offset: 0x00001F9B
		// (set) Token: 0x06000306 RID: 774 RVA: 0x00003DA3 File Offset: 0x00001FA3
		public string S { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00003DAC File Offset: 0x00001FAC
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public int I { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000309 RID: 777 RVA: 0x00003DBD File Offset: 0x00001FBD
		// (set) Token: 0x0600030A RID: 778 RVA: 0x00003DC5 File Offset: 0x00001FC5
		public bool B { get; set; }
	}
}
