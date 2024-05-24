using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000013 RID: 19
	public class PolicyData
	{
		// Token: 0x0600005B RID: 91 RVA: 0x0000271C File Offset: 0x0000091C
		public PolicyData()
		{
			this.Engine = new EnginePolicyData();
			this.Settings = new SettingsPolicyData();
			this.Connection = new ConnectionPolicyData();
			this.MigrationType = new MigrationTypePolicyData();
			this.MigrationItems = new MigrationItemsPolicyData();
			this.TransferComplete = new TransferCompletePolicyData();
			this.Properties = new Dictionary<string, string>();
			this.Interactive = new InteractivePolicyData();
			this.ClientReports = new ClientReportPolicyData();
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002792 File Offset: 0x00000992
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000279A File Offset: 0x0000099A
		public EnginePolicyData Engine { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000027A3 File Offset: 0x000009A3
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000027AB File Offset: 0x000009AB
		public SettingsPolicyData Settings { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000027B4 File Offset: 0x000009B4
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000027BC File Offset: 0x000009BC
		public ConnectionPolicyData Connection { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000027C5 File Offset: 0x000009C5
		// (set) Token: 0x06000063 RID: 99 RVA: 0x000027CD File Offset: 0x000009CD
		public MigrationTypePolicyData MigrationType { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000027D6 File Offset: 0x000009D6
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000027DE File Offset: 0x000009DE
		public MigrationItemsPolicyData MigrationItems { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000027E7 File Offset: 0x000009E7
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000027EF File Offset: 0x000009EF
		public TransferCompletePolicyData TransferComplete { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000027F8 File Offset: 0x000009F8
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002800 File Offset: 0x00000A00
		public IDictionary<string, string> Properties { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002809 File Offset: 0x00000A09
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002811 File Offset: 0x00000A11
		public InteractivePolicyData Interactive { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000281A File Offset: 0x00000A1A
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002822 File Offset: 0x00000A22
		public ClientReportPolicyData ClientReports { get; set; }
	}
}
