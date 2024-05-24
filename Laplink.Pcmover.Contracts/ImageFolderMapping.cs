using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200007E RID: 126
	public class ImageFolderMapping
	{
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000400F File Offset: 0x0000220F
		public bool IsDriveC
		{
			get
			{
				return string.Compare(this.VStr, "C:\\", true) == 0 || string.Compare(this.VStr, "C:", true) == 0;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600034E RID: 846 RVA: 0x0000403A File Offset: 0x0000223A
		// (set) Token: 0x0600034F RID: 847 RVA: 0x00004042 File Offset: 0x00002242
		public string VStr { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000350 RID: 848 RVA: 0x0000404B File Offset: 0x0000224B
		// (set) Token: 0x06000351 RID: 849 RVA: 0x00004053 File Offset: 0x00002253
		public string PStr { get; set; }
	}
}
