using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PCmover.Infrastructure;
using WizardModule.Engine.ClientReports;

namespace WizardModule.Engine
{
	// Token: 0x020000BD RID: 189
	public class ClientReportParameters : IClientReportParameters
	{
		// Token: 0x06001011 RID: 4113 RVA: 0x00029488 File Offset: 0x00027688
		public ClientReportParameters(IPCmoverEngine engine, int taskHandle)
		{
			this._engine = engine;
			this._taskHandle = taskHandle;
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001012 RID: 4114 RVA: 0x0002949E File Offset: 0x0002769E
		// (set) Token: 0x06001013 RID: 4115 RVA: 0x000294A6 File Offset: 0x000276A6
		public ReportData ReportData { get; set; }

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001014 RID: 4116 RVA: 0x000294AF File Offset: 0x000276AF
		ReportData IClientReportParameters.ReportData
		{
			get
			{
				return this.ReportData;
			}
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06001015 RID: 4117 RVA: 0x000294B7 File Offset: 0x000276B7
		LlTraceSource IClientReportParameters.Ts
		{
			get
			{
				return this._engine.Ts;
			}
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001016 RID: 4118 RVA: 0x000294C4 File Offset: 0x000276C4
		// (set) Token: 0x06001017 RID: 4119 RVA: 0x000294EC File Offset: 0x000276EC
		public TaskSummaryData Summary
		{
			get
			{
				if (this._summary == null)
				{
					this._summary = this._engine.GetTaskSummaryData(this._taskHandle, true);
				}
				return this._summary;
			}
			set
			{
				this._summary = value;
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001018 RID: 4120 RVA: 0x000294F5 File Offset: 0x000276F5
		TaskSummaryData IClientReportParameters.Summary
		{
			get
			{
				return this.Summary;
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06001019 RID: 4121 RVA: 0x000294FD File Offset: 0x000276FD
		// (set) Token: 0x0600101A RID: 4122 RVA: 0x00029525 File Offset: 0x00027725
		public TaskStats TaskStats
		{
			get
			{
				if (this._taskStats == null)
				{
					this._taskStats = this._engine.TaskGetStats(this._taskHandle, false);
				}
				return this._taskStats;
			}
			set
			{
				this._taskStats = value;
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x0600101B RID: 4123 RVA: 0x0002952E File Offset: 0x0002772E
		TaskStats IClientReportParameters.TaskStats
		{
			get
			{
				return this.TaskStats;
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x0600101C RID: 4124 RVA: 0x00029536 File Offset: 0x00027736
		// (set) Token: 0x0600101D RID: 4125 RVA: 0x0002955E File Offset: 0x0002775E
		public UserMappings UserMappings
		{
			get
			{
				if (this._userMappings == null)
				{
					this._userMappings = this._engine.TaskGetUserMappings(this._taskHandle, true);
				}
				return this._userMappings;
			}
			set
			{
				this._userMappings = value;
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x0600101E RID: 4126 RVA: 0x00029567 File Offset: 0x00027767
		UserMappings IClientReportParameters.UserMappings
		{
			get
			{
				return this.UserMappings;
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x0600101F RID: 4127 RVA: 0x0002956F File Offset: 0x0002776F
		// (set) Token: 0x06001020 RID: 4128 RVA: 0x000295A2 File Offset: 0x000277A2
		public IEnumerable<ApplicationData> Applications
		{
			get
			{
				if (this._applications == null)
				{
					this._applications = this._engine.GetApplications(this._taskHandle, new GetApplicationsParameters
					{
						DisplayableOnly = true
					});
				}
				return this._applications;
			}
			set
			{
				this._applications = value;
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x000295AB File Offset: 0x000277AB
		IEnumerable<ApplicationData> IClientReportParameters.Applications
		{
			get
			{
				return this.Applications;
			}
		}

		// Token: 0x0400056F RID: 1391
		private readonly IPCmoverEngine _engine;

		// Token: 0x04000570 RID: 1392
		private readonly int _taskHandle;

		// Token: 0x04000572 RID: 1394
		private TaskSummaryData _summary;

		// Token: 0x04000573 RID: 1395
		private TaskStats _taskStats;

		// Token: 0x04000574 RID: 1396
		private UserMappings _userMappings;

		// Token: 0x04000575 RID: 1397
		private IEnumerable<ApplicationData> _applications;
	}
}
