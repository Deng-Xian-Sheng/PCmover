using System;
using System.IO;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x02000004 RID: 4
	public class FolderPair
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002082 File Offset: 0x00000282
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208A File Offset: 0x0000028A
		public FolderToMove SourceFolder { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002093 File Offset: 0x00000293
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209B File Offset: 0x0000029B
		public DirectoryInfo DestinationFolder { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A4 File Offset: 0x000002A4
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020AC File Offset: 0x000002AC
		public string LibraryDisplayName { get; set; }
	}
}
