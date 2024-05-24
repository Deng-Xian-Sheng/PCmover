using System;
using Laplink.Pcmover.Contracts;
using WizardModule.Properties;

namespace WizardModule.Engine.ClientReports.Csv
{
	// Token: 0x020000CA RID: 202
	public class UsersCsvReport : CsvReport
	{
		// Token: 0x06001065 RID: 4197 RVA: 0x0002AE09 File Offset: 0x00029009
		public UsersCsvReport(IClientReportParameters parameters) : base(parameters)
		{
			base.Title = Resources.Report_Users_Title;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0002AE1D File Offset: 0x0002901D
		protected override bool AddCsvHeaders()
		{
			base.StartLine();
			base.AppendToCsvLine(Resources.Report_Users_SrcColumnLabel);
			base.AppendToCsvLine(Resources.Report_Users_DestColumnLabel);
			base.AppendToCsvLine(Resources.Report_Users_CreatedColumnLabel);
			base.StoreLine();
			return true;
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x0002AE50 File Offset: 0x00029050
		protected override bool AddCsvContent()
		{
			if (this._parameters.UserMappings != null)
			{
				foreach (UserMapping userMapping in this._parameters.UserMappings.Mappings)
				{
					base.StartLine();
					UserDetail old = userMapping.Old;
					base.AppendToCsvLine((old != null) ? old.FriendlyName : null);
					UserDetail @new = userMapping.New;
					base.AppendToCsvLine((@new != null) ? @new.FriendlyName : null);
					base.AppendToCsvLine(userMapping.Create ? Resources.Report_Users_CreatedYes : Resources.Report_Users_CreatedNo);
					base.StoreLine();
				}
			}
			return true;
		}
	}
}
