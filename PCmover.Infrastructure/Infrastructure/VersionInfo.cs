using System;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200003F RID: 63
	public class VersionInfo
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0000899D File Offset: 0x00006B9D
		public Version CurrentVersion { get; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600033B RID: 827 RVA: 0x000089A5 File Offset: 0x00006BA5
		public AppUpdateData UpdateData { get; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600033C RID: 828 RVA: 0x000089AD File Offset: 0x00006BAD
		public bool AppUpdateAvailable
		{
			get
			{
				return this.UpdateData != null && this.UpdateData.AppUpdateAvailable;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600033D RID: 829 RVA: 0x000089C4 File Offset: 0x00006BC4
		public bool DataUpdateAvailable
		{
			get
			{
				return this.UpdateData != null && this.UpdateData.DataUpdateAvailable;
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000089DB File Offset: 0x00006BDB
		public VersionInfo(Version version, AppUpdateData updateData)
		{
			this.CurrentVersion = version;
			this.UpdateData = updateData;
		}
	}
}
