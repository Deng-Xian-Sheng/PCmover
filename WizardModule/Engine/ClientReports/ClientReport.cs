using System;
using System.IO;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using WizardModule.Engine.ClientReports.Csv;
using WizardModule.Engine.ClientReports.DynamicPdf;
using WizardModule.Properties;
using WizardModule.ViewModels;

namespace WizardModule.Engine.ClientReports
{
	// Token: 0x020000C1 RID: 193
	public abstract class ClientReport
	{
		// Token: 0x06001030 RID: 4144 RVA: 0x00029B04 File Offset: 0x00027D04
		public static ClientReport CreateReport(IClientReportParameters parameters, ReportFormat format)
		{
			ReportData reportData = parameters.ReportData;
			if (reportData == null)
			{
				return null;
			}
			switch (reportData.Type)
			{
			case ReportType.Summary:
				if (format == ReportFormat.CSV)
				{
					return new SummaryCsvReport(parameters);
				}
				if (format == ReportFormat.PDF)
				{
					return new SummaryDynamicPdfReport(parameters);
				}
				break;
			case ReportType.Applications:
				if (format == ReportFormat.CSV)
				{
					return new ApplicationsCsvReport(parameters);
				}
				if (format == ReportFormat.PDF)
				{
					return new ApplicationsDynamicPdfReport(parameters);
				}
				break;
			case ReportType.Users:
				if (format == ReportFormat.CSV)
				{
					return new UsersCsvReport(parameters);
				}
				if (format == ReportFormat.PDF)
				{
					return new UsersDynamicPdfReport(parameters);
				}
				break;
			}
			return null;
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x00029B83 File Offset: 0x00027D83
		// (set) Token: 0x06001032 RID: 4146 RVA: 0x00029B8B File Offset: 0x00027D8B
		public string Title { get; set; }

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x00029B94 File Offset: 0x00027D94
		protected string Subheading
		{
			get
			{
				string report_Subheading = Resources.Report_Subheading;
				object arg = Tools.LookupEnumResource(this._summary.Action);
				MachineData srcMachine = this._summary.SrcMachine;
				object arg2 = (srcMachine != null) ? srcMachine.NetName : null;
				MachineData destMachine = this._summary.DestMachine;
				return string.Format(report_Subheading, arg, arg2, (destMachine != null) ? destMachine.NetName : null);
			}
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x00029BE9 File Offset: 0x00027DE9
		public ClientReport(IClientReportParameters parameters)
		{
			this._parameters = parameters;
			this._reportData = parameters.ReportData;
			this._summary = parameters.Summary;
			this._ts = parameters.Ts;
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x00029C1C File Offset: 0x00027E1C
		protected bool CreateFolderForFile(string fileName)
		{
			bool result;
			try
			{
				result = (Directory.CreateDirectory(Path.GetDirectoryName(fileName)) != null);
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "CreateFolderForFile");
				result = false;
			}
			return result;
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x00029C64 File Offset: 0x00027E64
		protected string AppendExtension(string fileName, string extension)
		{
			if (Path.HasExtension(fileName))
			{
				return fileName;
			}
			return fileName + extension;
		}

		// Token: 0x06001037 RID: 4151
		public abstract bool GenerateReport();

		// Token: 0x0400057C RID: 1404
		protected readonly TaskSummaryData _summary;

		// Token: 0x0400057D RID: 1405
		protected readonly LlTraceSource _ts;

		// Token: 0x0400057E RID: 1406
		protected readonly ReportData _reportData;

		// Token: 0x0400057F RID: 1407
		protected readonly IClientReportParameters _parameters;
	}
}
