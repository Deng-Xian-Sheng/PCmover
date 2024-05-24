using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PCmover.Infrastructure
{
	// Token: 0x02000034 RID: 52
	public class Reports
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x000079D9 File Offset: 0x00005BD9
		// (set) Token: 0x060002BA RID: 698 RVA: 0x000079E1 File Offset: 0x00005BE1
		public string FilePath { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000079EA File Offset: 0x00005BEA
		// (set) Token: 0x060002BC RID: 700 RVA: 0x000079F2 File Offset: 0x00005BF2
		public string FileName { get; set; }

		// Token: 0x060002BD RID: 701 RVA: 0x000079FB File Offset: 0x00005BFB
		public Reports(string path)
		{
			this.FilePath = path;
			this.FileName = Path.GetFileName(path);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00007A18 File Offset: 0x00005C18
		public void Open()
		{
			try
			{
				Process.Start(new ProcessStartInfo(this.FilePath));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
