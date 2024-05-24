using System;
using System.Collections.Generic;
using System.Linq;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200000B RID: 11
	public class GenerateReportsActivity : PcmActivity, ITaskActivity
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000033AA File Offset: 0x000015AA
		public IEnumerable<ReportData> Reports { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000033B2 File Offset: 0x000015B2
		public ServiceTask ActivityServiceTask { get; }

		// Token: 0x06000042 RID: 66 RVA: 0x000033BA File Offset: 0x000015BA
		public GenerateReportsActivity(PcmoverManager manager, ServiceTask serviceTask, IEnumerable<ReportData> reports) : base(ActivityType.GenerateReports, manager)
		{
			this.ActivityServiceTask = serviceTask;
			this.Reports = reports;
			this._reportCount = this.Reports.Count<ReportData>();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000033E4 File Offset: 0x000015E4
		private void FireProgress(ReportData report, int numDone)
		{
			this.OnProgressChanged(new ProgressInfo
			{
				TimeStampUtc = DateTime.UtcNow,
				Task = "Generate Reports",
				Action = "Generate",
				Item = ((report != null) ? report.FileName : null),
				Percentage = (ushort)(numDone * 100 / this._reportCount)
			});
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003444 File Offset: 0x00001644
		protected override void Run()
		{
			this.m_bSuccess = false;
			ServiceTask activityServiceTask = this.ActivityServiceTask;
			IPcmTask pcmTask = (activityServiceTask != null) ? activityServiceTask.Task : null;
			if (pcmTask == null)
			{
				return;
			}
			this.m_bSuccess = true;
			int num = 0;
			foreach (ReportData reportData in this.Reports)
			{
				if (this.m_bCancel)
				{
					break;
				}
				this.FireProgress(reportData, num++);
				ReportPolicy reportPolicy = this.m_app.CreateReportPolicy();
				if (reportPolicy == null)
				{
					this.m_ts.TraceInformation("Unable to create report policy");
					this.m_bSuccess = false;
					break;
				}
				reportPolicy.strFileName = reportData.FileName;
				reportPolicy.Format = (REPORT_FORMAT)reportData.Format;
				reportPolicy.Type = (REPORT_TYPE)reportData.Type;
				reportPolicy.bExceptionsOnly = reportData.IncludeExceptionsOnly;
				reportPolicy.bAppend = reportData.Append;
				reportPolicy.bTimeStamp = reportData.IncludeTimestamp;
				reportPolicy.Mask = reportData.Mask;
				reportPolicy.nItems = (uint)reportData.Items;
				reportPolicy.bMigrated = reportData.Migrated;
				reportPolicy.bShowComponents = reportData.ShowComponents;
				if (!pcmTask.GenerateReport(reportPolicy))
				{
					this.m_ts.TraceInformation("Generate reports failure for " + reportData.FileName);
				}
			}
			this.FireProgress(null, this._reportCount);
		}

		// Token: 0x0400001E RID: 30
		private int _reportCount;
	}
}
