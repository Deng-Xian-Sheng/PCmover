using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;

namespace WizardModule.Engine.ClientReports.DynamicPdf
{
	// Token: 0x020000C6 RID: 198
	public class UsersDynamicPdfReport : DynamicPdfReport
	{
		// Token: 0x06001054 RID: 4180 RVA: 0x0002A630 File Offset: 0x00028830
		public UsersDynamicPdfReport(IClientReportParameters parameters) : base(parameters)
		{
			base.Title = Resources.Report_Users_Title;
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x0002A644 File Offset: 0x00028844
		protected override bool AddContent(Document document)
		{
			Page page = base.CreatePage();
			document.Pages.Add(page);
			Table2 table = base.CreateFullTable(page);
			table.Columns.Add(base.StringToPoints(Resources.Report_Users_SrcColumnWidth));
			table.Columns.Add(base.StringToPoints(Resources.Report_Users_DestColumnWidth));
			table.Columns.Add(base.StringToPoints(Resources.Report_Users_CreatedColumnWidth));
			Row2 row = table.Rows.Add();
			row.CellDefault.Font = base.BoldDynamicFont;
			row.CellDefault.Underline = new bool?(true);
			row.Cells.Add(Resources.Report_Users_SrcColumnLabel);
			row.Cells.Add(Resources.Report_Users_DestColumnLabel);
			row.Cells.Add(Resources.Report_Users_CreatedColumnLabel);
			if (this._parameters.UserMappings != null)
			{
				foreach (UserMapping userMapping in this._parameters.UserMappings.Mappings)
				{
					Row2 row2 = table.Rows.Add();
					Cell2List cells = row2.Cells;
					UserDetail old = userMapping.Old;
					cells.Add((old != null) ? old.FriendlyName : null);
					Cell2List cells2 = row2.Cells;
					UserDetail @new = userMapping.New;
					cells2.Add((@new != null) ? @new.FriendlyName : null);
					row2.Cells.Add(userMapping.Create ? Resources.Report_Users_CreatedYes : Resources.Report_Users_CreatedNo);
				}
			}
			page.Elements.Add(table);
			return true;
		}
	}
}
