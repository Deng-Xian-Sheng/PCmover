using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200003C RID: 60
	public class ItemFilterData
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00002F9B File Offset: 0x0000119B
		// (set) Token: 0x0600015E RID: 350 RVA: 0x00002FA3 File Offset: 0x000011A3
		public string SourceMask { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00002FAC File Offset: 0x000011AC
		// (set) Token: 0x06000160 RID: 352 RVA: 0x00002FB4 File Offset: 0x000011B4
		public string Target { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00002FBD File Offset: 0x000011BD
		// (set) Token: 0x06000162 RID: 354 RVA: 0x00002FC5 File Offset: 0x000011C5
		public bool? Transfer { get; set; }
	}
}
