using System;
using System.IO;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x02000005 RID: 5
	public class FolderToMove
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020BD File Offset: 0x000002BD
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000020C5 File Offset: 0x000002C5
		public DirectoryInfo DirectoryInfo { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020CE File Offset: 0x000002CE
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000020D6 File Offset: 0x000002D6
		public int level { get; set; }

		// Token: 0x06000012 RID: 18 RVA: 0x000020DF File Offset: 0x000002DF
		public FolderToMove(DirectoryInfo dirInfo, int level)
		{
			this.DirectoryInfo = dirInfo;
			this.level = level;
		}
	}
}
