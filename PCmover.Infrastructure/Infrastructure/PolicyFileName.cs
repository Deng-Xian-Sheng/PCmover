using System;
using System.IO;

namespace PCmover.Infrastructure
{
	// Token: 0x0200002F RID: 47
	public class PolicyFileName
	{
		// Token: 0x060002A7 RID: 679 RVA: 0x00007780 File Offset: 0x00005980
		public PolicyFileName(string path)
		{
			this.FilePath = path;
			try
			{
				this.FileName = Path.GetFileName(path);
				this.FileDate = File.GetLastWriteTime(path).ToShortDateString() + " " + File.GetLastWriteTime(path).ToShortTimeString();
				this.FilePath = path;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x000077F0 File Offset: 0x000059F0
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x000077F8 File Offset: 0x000059F8
		public string FileName { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00007801 File Offset: 0x00005A01
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00007809 File Offset: 0x00005A09
		public string FileDate { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00007812 File Offset: 0x00005A12
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0000781A File Offset: 0x00005A1A
		public string FilePath { get; set; }
	}
}
