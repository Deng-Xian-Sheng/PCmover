using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;
using WizardModule.ViewModels;

namespace WizardModule.Engine.ClientReports.DynamicPdf
{
	// Token: 0x020000C5 RID: 197
	public class SummaryDynamicPdfReport : DynamicPdfReport
	{
		// Token: 0x06001050 RID: 4176 RVA: 0x0002A306 File Offset: 0x00028506
		public SummaryDynamicPdfReport(IClientReportParameters parameters) : base(parameters)
		{
			base.Title = Resources.Report_Summary_Title;
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x0002A31C File Offset: 0x0002851C
		protected override bool AddContent(Document document)
		{
			Page page = base.CreatePage();
			document.Pages.Add(page);
			Table2 table = base.CreateFullTable(page);
			table.Columns.Add(base.StringToPoints(Resources.Report_Summary_LabelColumnWidth)).CellDefault.Font = base.BoldDynamicFont;
			table.Columns.Add(base.StringToPoints(Resources.Report_Summary_DataColumnWidth));
			this.AddPromptedText(table, Resources.Report_Summary_VersionLabel, this._summary.Version);
			this.AddPromptedText(table, Resources.Report_Summary_BegunLabel, this._summary.StartTime);
			this.AddPromptedText(table, Resources.Report_Summary_FinishedLabel, this._summary.FinishTime);
			this.AddPromptedText(table, Resources.Report_Summary_StatusLabel, Tools.LookupEnumResource(this._summary.Status));
			Table2 table2 = table;
			string report_Summary_SrcNameLabel = Resources.Report_Summary_SrcNameLabel;
			MachineData srcMachine = this._summary.SrcMachine;
			this.AddPromptedText(table2, report_Summary_SrcNameLabel, (srcMachine != null) ? srcMachine.NetName : null);
			Table2 table3 = table;
			string report_Summary_SrcUserLabel = Resources.Report_Summary_SrcUserLabel;
			UserDetail srcUser = this._summary.SrcUser;
			this.AddPromptedText(table3, report_Summary_SrcUserLabel, (srcUser != null) ? srcUser.FriendlyName : null);
			Table2 table4 = table;
			string report_Summary_DestNameLabel = Resources.Report_Summary_DestNameLabel;
			MachineData destMachine = this._summary.DestMachine;
			this.AddPromptedText(table4, report_Summary_DestNameLabel, (destMachine != null) ? destMachine.NetName : null);
			Table2 table5 = table;
			string report_Summary_DestUserLabel = Resources.Report_Summary_DestUserLabel;
			UserDetail destUser = this._summary.DestUser;
			this.AddPromptedText(table5, report_Summary_DestUserLabel, (destUser != null) ? destUser.FriendlyName : null);
			this.AddPromptedText(table, Resources.Report_Summary_ActionLabel, Tools.LookupEnumResource(this._summary.Action));
			this.AddPromptedText(table, Resources.Report_Summary_ConnectionLabel, Tools.LookupEnumResource(this._summary.TransferMethodType));
			this.AddPromptedText(table, Resources.Report_Summary_UsersTransferredLabel, this._summary.UsersTransferred);
			this.AddPromptedText(table, Resources.Report_Summary_UsersCreatedLabel, this._summary.UsersCreated);
			this.AddPromptedText(table, Resources.Report_Summary_GroupsTransferredLabel, this._summary.GroupsTransferred);
			this.AddPromptedText(table, Resources.Report_Summary_GroupsCreatedLabel, this._summary.GroupsCreated);
			this.AddPromptedText(table, Resources.Report_Summary_ApplicationsLabel, this._summary.Applications);
			Table2 table6 = table;
			TaskStats taskStats = this._parameters.TaskStats;
			this.AddSummaryContainerText(table6, (taskStats != null) ? taskStats.Disk : null, Resources.Report_Summary_FoldersLabel, Resources.Report_Summary_FilesLabel, Resources.Report_Summary_FileSizeLabel);
			Table2 table7 = table;
			TaskStats taskStats2 = this._parameters.TaskStats;
			this.AddSummaryContainerText(table7, (taskStats2 != null) ? taskStats2.Registry : null, Resources.Report_Summary_KeysLabel, Resources.Report_Summary_ValuesLabel, Resources.Report_Summary_ValueSizeLabel);
			page.Elements.Add(table);
			return true;
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x0002A5A4 File Offset: 0x000287A4
		private void AddPromptedText(Table2 table, string prompt, object val)
		{
			if (!string.IsNullOrWhiteSpace(prompt))
			{
				Row2 row = table.Rows.Add();
				row.Cells.Add(prompt);
				row.Cells.Add((val == null) ? "" : val.ToString());
			}
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x0002A5E4 File Offset: 0x000287E4
		private void AddSummaryContainerText(Table2 table, ContainerStats stats, string itemPrompt, string containerPrompt, string sizePrompt)
		{
			if (stats == null)
			{
				return;
			}
			this.AddPromptedText(table, itemPrompt, stats.NumItems);
			this.AddPromptedText(table, containerPrompt, stats.NumContainers);
			this.AddPromptedText(table, sizePrompt, stats.TotalSize);
		}
	}
}
