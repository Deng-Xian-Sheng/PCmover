using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000094 RID: 148
	public class MapiProfile
	{
		// Token: 0x060003CE RID: 974 RVA: 0x00002050 File Offset: 0x00000250
		public MapiProfile()
		{
		}

		// Token: 0x060003CF RID: 975 RVA: 0x000046B3 File Offset: 0x000028B3
		public MapiProfile(string profileName, string sourceMachineName, string sourceUserName, string sourceProfileName)
		{
			this.ProfileName = profileName;
			this.SourceMachineName = sourceMachineName;
			this.SourceUserName = sourceUserName;
			this.SourceProfileName = sourceProfileName;
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x000046D8 File Offset: 0x000028D8
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x000046E0 File Offset: 0x000028E0
		public string ProfileName { get; set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x000046E9 File Offset: 0x000028E9
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x000046F1 File Offset: 0x000028F1
		public string SourceMachineName { get; set; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x000046FA File Offset: 0x000028FA
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x00004702 File Offset: 0x00002902
		public string SourceUserName { get; set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000470B File Offset: 0x0000290B
		// (set) Token: 0x060003D7 RID: 983 RVA: 0x00004713 File Offset: 0x00002913
		public string SourceProfileName { get; set; }
	}
}
