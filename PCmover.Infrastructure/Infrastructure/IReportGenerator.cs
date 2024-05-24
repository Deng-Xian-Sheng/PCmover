using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200002A RID: 42
	public interface IReportGenerator
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600027E RID: 638
		// (set) Token: 0x0600027F RID: 639
		List<ReportData> Reports { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000280 RID: 640
		// (set) Token: 0x06000281 RID: 641
		bool ShouldCreatePdfReports { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000282 RID: 642
		// (set) Token: 0x06000283 RID: 643
		bool ShouldCreateCsvReports { get; set; }

		// Token: 0x06000284 RID: 644
		void GenerateReports(int taskHandle);

		// Token: 0x06000285 RID: 645
		void InitializeReports(ClientReportPolicyData policyData);
	}
}
