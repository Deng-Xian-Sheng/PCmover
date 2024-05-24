using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace WizardModule.Engine.ClientReports
{
	// Token: 0x020000C2 RID: 194
	public interface IClientReportParameters
	{
		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06001038 RID: 4152
		ReportData ReportData { get; }

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06001039 RID: 4153
		LlTraceSource Ts { get; }

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x0600103A RID: 4154
		TaskSummaryData Summary { get; }

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x0600103B RID: 4155
		TaskStats TaskStats { get; }

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x0600103C RID: 4156
		UserMappings UserMappings { get; }

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x0600103D RID: 4157
		IEnumerable<ApplicationData> Applications { get; }
	}
}
