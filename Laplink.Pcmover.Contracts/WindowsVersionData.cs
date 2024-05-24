using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200009C RID: 156
	public class WindowsVersionData
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x000049CE File Offset: 0x00002BCE
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x000049D6 File Offset: 0x00002BD6
		public int Platform { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x000049DF File Offset: 0x00002BDF
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x000049E7 File Offset: 0x00002BE7
		public string ServicePack { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x000049F0 File Offset: 0x00002BF0
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x000049F8 File Offset: 0x00002BF8
		public Version Version { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x00004A01 File Offset: 0x00002C01
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x00004A09 File Offset: 0x00002C09
		public string VersionString { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x00004A12 File Offset: 0x00002C12
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x00004A1A File Offset: 0x00002C1A
		public bool Is64Bit { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x00004A23 File Offset: 0x00002C23
		public bool IsWindows11
		{
			get
			{
				return WindowsVersionData.IsVersionWindows11(this.Version);
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00004A30 File Offset: 0x00002C30
		public static bool IsVersionWindows11(Version winVer)
		{
			return winVer.Major == 10 && winVer.Minor == 0 && winVer.Build >= 21996;
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x00004A56 File Offset: 0x00002C56
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x00004A5E File Offset: 0x00002C5E
		public ProductType ProductType { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00004A67 File Offset: 0x00002C67
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x00004A6F File Offset: 0x00002C6F
		public uint EnablePreviewBuilds { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00004A78 File Offset: 0x00002C78
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x00004A80 File Offset: 0x00002C80
		public uint WindowsEdition { get; set; }

		// Token: 0x06000420 RID: 1056 RVA: 0x00004A8C File Offset: 0x00002C8C
		public int CompareMajorMinor(WindowsVersionData Other)
		{
			int num = this.CompareNum(this.Platform, Other.Platform);
			if (num == 0)
			{
				num = this.CompareNum(this.Version.Major, Other.Version.Major);
			}
			if (num == 0)
			{
				num = this.CompareNum(this.Version.Minor, Other.Version.Minor);
			}
			if (num == 0 && this.Version.Major == 10)
			{
				num = this.CompareNum(this.Version.Build, Other.Version.Build);
			}
			return num;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00004B1C File Offset: 0x00002D1C
		private int CompareNum(int n1, int n2)
		{
			if (n1 == n2)
			{
				return 0;
			}
			if (n1 < n2)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00004B2C File Offset: 0x00002D2C
		public override string ToString()
		{
			return string.Format("Platform: {0}\nServicePack: {1}\nVersion: {2}", this.Platform, this.ServicePack, this.Version) + string.Format("\nVersionString: {0}\nIs64Bit: {1}\nProductType: {2}", this.VersionString, this.Is64Bit, this.ProductType) + string.Format("\nEnablePreviewBuilds: {0}\nWindowsEdition: {1}", this.EnablePreviewBuilds, this.WindowsEdition);
		}

		// Token: 0x040003FC RID: 1020
		public const int Win11FirstBuild = 21996;
	}
}
