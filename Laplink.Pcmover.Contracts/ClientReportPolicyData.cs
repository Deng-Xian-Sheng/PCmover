using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000023 RID: 35
	public class ClientReportPolicyData
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00002B82 File Offset: 0x00000D82
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00002B8A File Offset: 0x00000D8A
		public string BaseDir { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00002B93 File Offset: 0x00000D93
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00002B9B File Offset: 0x00000D9B
		public bool GenerateDefaultReports { get; set; } = true;

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00002BA4 File Offset: 0x00000DA4
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00002BAC File Offset: 0x00000DAC
		public IEnumerable<ReportData> Reports { get; set; } = new List<ReportData>();
	}
}
