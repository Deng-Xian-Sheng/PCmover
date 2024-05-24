using System;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;

namespace WizardModule.Engine.ClientReports.Csv
{
	// Token: 0x020000C7 RID: 199
	public class ApplicationsCsvReport : CsvReport
	{
		// Token: 0x06001056 RID: 4182 RVA: 0x0002A7D8 File Offset: 0x000289D8
		public ApplicationsCsvReport(IClientReportParameters parameters) : base(parameters)
		{
			base.Title = Resources.Report_Applications_Title;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0002A7EC File Offset: 0x000289EC
		protected override bool AddCsvHeaders()
		{
			base.StartLine();
			base.AppendToCsvLine(Resources.Report_Applications_NameColumnLabel);
			base.AppendToCsvLine(Resources.Report_Applications_PublisherColumnLabel);
			base.AppendToCsvLine(Resources.Report_Applications_TransferredColumnLabel);
			base.StoreLine();
			return true;
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x0002A81C File Offset: 0x00028A1C
		protected override bool AddCsvContent()
		{
			if (this._parameters.Applications != null)
			{
				foreach (ApplicationData applicationData in this._parameters.Applications)
				{
					base.StartLine();
					base.AppendToCsvLine(applicationData.Name);
					base.AppendToCsvLine(applicationData.Publisher);
					base.AppendToCsvLine(applicationData.Selected ? Resources.Report_Applications_TransferredYes : Resources.Report_Applications_TransferredNo);
					base.StoreLine();
				}
			}
			return true;
		}
	}
}
