using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;

namespace WizardModule.Engine.ClientReports.DynamicPdf
{
	// Token: 0x020000C3 RID: 195
	public class ApplicationsDynamicPdfReport : DynamicPdfReport
	{
		// Token: 0x0600103E RID: 4158 RVA: 0x00029C77 File Offset: 0x00027E77
		public ApplicationsDynamicPdfReport(IClientReportParameters parameters) : base(parameters)
		{
			base.Title = Resources.Report_Applications_Title;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00029C8C File Offset: 0x00027E8C
		protected override bool AddContent(Document document)
		{
			Page page = base.CreatePage();
			document.Pages.Add(page);
			Table2 table = base.CreateFullTable(page);
			table.Columns.Add(base.StringToPoints(Resources.Report_Applications_NameColumnWidth));
			table.Columns.Add(base.StringToPoints(Resources.Report_Applications_PublisherColumnWidth));
			table.Columns.Add(base.StringToPoints(Resources.Report_Applications_TransferredColumnWidth));
			Row2 row = table.Rows.Add();
			row.CellDefault.Font = base.BoldDynamicFont;
			row.CellDefault.Underline = new bool?(true);
			row.Cells.Add(Resources.Report_Applications_NameColumnLabel);
			row.Cells.Add(Resources.Report_Applications_PublisherColumnLabel);
			row.Cells.Add(Resources.Report_Applications_TransferredColumnLabel);
			if (this._parameters.Applications != null)
			{
				foreach (ApplicationData applicationData in this._parameters.Applications)
				{
					Row2 row2 = table.Rows.Add();
					row2.Cells.Add(applicationData.Name);
					row2.Cells.Add(applicationData.Publisher);
					row2.Cells.Add(applicationData.Selected ? Resources.Report_Applications_TransferredYes : Resources.Report_Applications_TransferredNo);
				}
			}
			page.Elements.Add(table);
			return true;
		}
	}
}
