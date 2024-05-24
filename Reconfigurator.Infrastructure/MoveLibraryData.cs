using System;
using System.IO;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x02000008 RID: 8
	public class MoveLibraryData
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x0000238C File Offset: 0x0000058C
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00002394 File Offset: 0x00000594
		public string LibraryDisplayName { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000018 RID: 24 RVA: 0x0000239D File Offset: 0x0000059D
		// (set) Token: 0x06000019 RID: 25 RVA: 0x000023A5 File Offset: 0x000005A5
		public DirectoryInfo Source { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000023AE File Offset: 0x000005AE
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000023B6 File Offset: 0x000005B6
		public DirectoryInfo Destination { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000023BF File Offset: 0x000005BF
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000023C7 File Offset: 0x000005C7
		public int CopyPopupCount { get; set; }
	}
}
