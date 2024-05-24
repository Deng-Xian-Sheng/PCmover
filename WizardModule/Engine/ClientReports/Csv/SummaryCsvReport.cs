using System;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;
using WizardModule.ViewModels;

namespace WizardModule.Engine.ClientReports.Csv
{
	// Token: 0x020000C9 RID: 201
	public class SummaryCsvReport : CsvReport
	{
		// Token: 0x06001061 RID: 4193 RVA: 0x0002AABD File Offset: 0x00028CBD
		public SummaryCsvReport(IClientReportParameters parameters) : base(parameters)
		{
			base.Title = Resources.Report_Summary_Title;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0002AAD4 File Offset: 0x00028CD4
		protected override bool AddCsvHeaders()
		{
			base.StartLine();
			base.AppendToCsvLine(Resources.Report_Summary_VersionLabel);
			base.AppendToCsvLine(Resources.Report_Summary_BegunLabel);
			base.AppendToCsvLine(Resources.Report_Summary_FinishedLabel);
			base.AppendToCsvLine(Resources.Report_Summary_StatusLabel);
			base.AppendToCsvLine(Resources.Report_Summary_SrcNameLabel);
			base.AppendToCsvLine(Resources.Report_Summary_SrcUserLabel);
			base.AppendToCsvLine(Resources.Report_Summary_DestNameLabel);
			base.AppendToCsvLine(Resources.Report_Summary_DestUserLabel);
			base.AppendToCsvLine(Resources.Report_Summary_ActionLabel);
			base.AppendToCsvLine(Resources.Report_Summary_ConnectionLabel);
			base.AppendToCsvLine(Resources.Report_Summary_UsersTransferredLabel);
			base.AppendToCsvLine(Resources.Report_Summary_UsersCreatedLabel);
			base.AppendToCsvLine(Resources.Report_Summary_GroupsTransferredLabel);
			base.AppendToCsvLine(Resources.Report_Summary_GroupsCreatedLabel);
			base.AppendToCsvLine(Resources.Report_Summary_ApplicationsLabel);
			base.AppendToCsvLine(Resources.Report_Summary_FoldersLabel);
			base.AppendToCsvLine(Resources.Report_Summary_FilesLabel);
			base.AppendToCsvLine(Resources.Report_Summary_FileSizeLabel);
			base.AppendToCsvLine(Resources.Report_Summary_KeysLabel);
			base.AppendToCsvLine(Resources.Report_Summary_ValuesLabel);
			base.AppendToCsvLine(Resources.Report_Summary_ValueSizeLabel);
			base.StoreLine();
			return true;
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0002ABD8 File Offset: 0x00028DD8
		protected override bool AddCsvContent()
		{
			base.StartLine();
			base.AppendToCsvLine(this._summary.Version);
			base.AppendToCsvLine(this._summary.StartTime);
			base.AppendToCsvLine(this._summary.FinishTime);
			base.AppendToCsvLine(Tools.LookupEnumResource(this._summary.Status));
			MachineData srcMachine = this._summary.SrcMachine;
			base.AppendToCsvLine((srcMachine != null) ? srcMachine.NetName : null);
			UserDetail srcUser = this._summary.SrcUser;
			base.AppendToCsvLine((srcUser != null) ? srcUser.FriendlyName : null);
			MachineData destMachine = this._summary.DestMachine;
			base.AppendToCsvLine((destMachine != null) ? destMachine.NetName : null);
			UserDetail destUser = this._summary.DestUser;
			base.AppendToCsvLine((destUser != null) ? destUser.FriendlyName : null);
			base.AppendToCsvLine(Tools.LookupEnumResource(this._summary.Action));
			base.AppendToCsvLine(Tools.LookupEnumResource(this._summary.TransferMethodType));
			base.AppendToCsvLine(this._summary.UsersTransferred);
			base.AppendToCsvLine(this._summary.UsersCreated);
			base.AppendToCsvLine(this._summary.GroupsTransferred);
			base.AppendToCsvLine(this._summary.GroupsCreated);
			base.AppendToCsvLine(this._summary.Applications);
			TaskStats taskStats = this._parameters.TaskStats;
			this.AddSummaryContainerText((taskStats != null) ? taskStats.Disk : null);
			TaskStats taskStats2 = this._parameters.TaskStats;
			this.AddSummaryContainerText((taskStats2 != null) ? taskStats2.Registry : null);
			base.StoreLine();
			return true;
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x0002AD90 File Offset: 0x00028F90
		private void AddSummaryContainerText(ContainerStats stats)
		{
			base.AppendToCsvLine((stats != null) ? new ulong?(stats.NumItems) : null);
			base.AppendToCsvLine((stats != null) ? new ulong?(stats.NumContainers) : null);
			base.AppendToCsvLine((stats != null) ? new ulong?(stats.TotalSize) : null);
		}
	}
}
