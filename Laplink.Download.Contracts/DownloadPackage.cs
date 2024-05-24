using System;

namespace Laplink.Download.Contracts
{
	// Token: 0x02000006 RID: 6
	public class DownloadPackage
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020BE File Offset: 0x000002BE
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020C6 File Offset: 0x000002C6
		public string Name { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020CF File Offset: 0x000002CF
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020D7 File Offset: 0x000002D7
		public string URL { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020E0 File Offset: 0x000002E0
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000020E8 File Offset: 0x000002E8
		public string LaunchParameters { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020F1 File Offset: 0x000002F1
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000020F9 File Offset: 0x000002F9
		public string File { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002102 File Offset: 0x00000302
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000210A File Offset: 0x0000030A
		public double DownloadProgress { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002113 File Offset: 0x00000313
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000211B File Offset: 0x0000031B
		public bool RebootAfterInstall { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002124 File Offset: 0x00000324
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000212C File Offset: 0x0000032C
		public int Timeout { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002135 File Offset: 0x00000335
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000213D File Offset: 0x0000033D
		public int DownloadRetries { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002146 File Offset: 0x00000346
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000214E File Offset: 0x0000034E
		public int InstallRetries { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002157 File Offset: 0x00000357
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000215F File Offset: 0x0000035F
		public int ExitCode { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002168 File Offset: 0x00000368
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002170 File Offset: 0x00000370
		public bool IsDownloading { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002179 File Offset: 0x00000379
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002181 File Offset: 0x00000381
		public bool IsInstalling { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000218A File Offset: 0x0000038A
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002192 File Offset: 0x00000392
		public string Id { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000219B File Offset: 0x0000039B
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000021A3 File Offset: 0x000003A3
		public DownloadManagerError ErrorCode { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000021AC File Offset: 0x000003AC
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000021B4 File Offset: 0x000003B4
		public PackageState State
		{
			get
			{
				return this._State;
			}
			set
			{
				this._State = value;
				this.IsDownloading = (this._State == PackageState.Downloading);
				this.IsInstalling = (this._State == PackageState.Installing);
			}
		}

		// Token: 0x0400001C RID: 28
		private PackageState _State;
	}
}
