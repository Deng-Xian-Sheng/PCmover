using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200007F RID: 127
	public class ImageMapData
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000405C File Offset: 0x0000225C
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00004064 File Offset: 0x00002264
		public IEnumerable<ImageFolderMapping> Folders { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000406D File Offset: 0x0000226D
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00004075 File Offset: 0x00002275
		public string WinDir { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000357 RID: 855 RVA: 0x0000407E File Offset: 0x0000227E
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00004086 File Offset: 0x00002286
		public string ImageName { get; set; }
	}
}
