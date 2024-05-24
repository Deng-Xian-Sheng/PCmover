using System;

namespace IntelEMA
{
	// Token: 0x0200000A RID: 10
	public class MEInfo
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600004C RID: 76 RVA: 0x0000238B File Offset: 0x0000058B
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002393 File Offset: 0x00000593
		public string VersionString { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600004E RID: 78 RVA: 0x0000239C File Offset: 0x0000059C
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000023A4 File Offset: 0x000005A4
		public bool? IsAmtEnabled { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000023AD File Offset: 0x000005AD
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000023B5 File Offset: 0x000005B5
		public bool? CiraEnabled { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000023BE File Offset: 0x000005BE
		// (set) Token: 0x06000053 RID: 83 RVA: 0x000023C6 File Offset: 0x000005C6
		public int? AmtProvisioningState { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000023CF File Offset: 0x000005CF
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000023D7 File Offset: 0x000005D7
		public int? AmtProvisioningMode { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000023E0 File Offset: 0x000005E0
		// (set) Token: 0x06000057 RID: 87 RVA: 0x000023E8 File Offset: 0x000005E8
		public int? AmtControlMode { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000023F1 File Offset: 0x000005F1
		// (set) Token: 0x06000059 RID: 89 RVA: 0x000023F9 File Offset: 0x000005F9
		public string MEVersion { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002402 File Offset: 0x00000602
		// (set) Token: 0x0600005B RID: 91 RVA: 0x0000240A File Offset: 0x0000060A
		public int? MEFWBuildNumber { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002413 File Offset: 0x00000613
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000241B File Offset: 0x0000061B
		public bool? IsEHBC { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002424 File Offset: 0x00000624
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000242C File Offset: 0x0000062C
		public bool? IsAmtVersionValid { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002435 File Offset: 0x00000635
		// (set) Token: 0x06000061 RID: 97 RVA: 0x0000243D File Offset: 0x0000063D
		public int? Version { get; set; }
	}
}
