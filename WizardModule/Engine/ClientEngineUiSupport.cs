using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Events;
using WizardModule.Engine.ClientReports;
using WizardModule.Properties;
using WizardModule.Views.Popups;

namespace WizardModule.Engine
{
	// Token: 0x020000BC RID: 188
	public class ClientEngineUiSupport : IReportGenerator
	{
		// Token: 0x06001004 RID: 4100 RVA: 0x00029038 File Offset: 0x00027238
		public ClientEngineUiSupport(IUnityContainer container, IEventAggregator eventAggregator, IWizardParameters wizardParameters, LlTraceSource ts)
		{
			this._container = container;
			this._eventAggregator = eventAggregator;
			this._wizardParameters = wizardParameters;
			this._ts = ts;
			eventAggregator.GetEvent<EngineEvents.ShowOfficeTrialPopupEvent>().Subscribe(new Action<IEnumerable<ApplicationData>>(this.OnShowOfficeTrialPopup));
			eventAggregator.GetEvent<EngineEvents.ShowProxyCredentialsPopupEvent>().Subscribe(new Action<EngineEvents.ProxyCredentialsData>(this.OnShowProxyCredentialsPopup));
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x0002909F File Offset: 0x0002729F
		private void OnShowOfficeTrialPopup(IEnumerable<ApplicationData> trialApps)
		{
			if (trialApps != null && trialApps.Any<ApplicationData>())
			{
				this._eventAggregator.GetEvent<PopupEvents.ShowPopup>().Publish(new PopupEvents.ResolveInfo(typeof(OfficeTrial), new ParameterOverride("configData", trialApps)));
			}
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x000290D6 File Offset: 0x000272D6
		private void OnShowProxyCredentialsPopup(EngineEvents.ProxyCredentialsData credentialsData)
		{
			this._eventAggregator.GetEvent<PopupEvents.ShowPopup>().Publish(new PopupEvents.ResolveInfo(typeof(ProxyCredentials), new ParameterOverride("configData", credentialsData)));
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x00029102 File Offset: 0x00027302
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x0002910A File Offset: 0x0002730A
		public List<ReportData> Reports { get; set; }

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x00029113 File Offset: 0x00027313
		// (set) Token: 0x0600100A RID: 4106 RVA: 0x00029145 File Offset: 0x00027345
		public bool ShouldCreatePdfReports
		{
			get
			{
				if (this._shouldCreatePdfReports == null)
				{
					this._shouldCreatePdfReports = new bool?(!string.IsNullOrWhiteSpace(Resources.Report_PDF_Font_Normal));
				}
				return this._shouldCreatePdfReports.Value;
			}
			set
			{
				this._shouldCreatePdfReports = new bool?(value);
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x0600100B RID: 4107 RVA: 0x00029153 File Offset: 0x00027353
		// (set) Token: 0x0600100C RID: 4108 RVA: 0x0002915B File Offset: 0x0002735B
		public bool ShouldCreateCsvReports { get; set; } = true;

		// Token: 0x0600100D RID: 4109 RVA: 0x00029164 File Offset: 0x00027364
		public void GenerateReports(int taskHandle)
		{
			try
			{
				ClientReportParameters clientReportParameters = new ClientReportParameters(this._container.Resolve(Array.Empty<ResolverOverride>()), taskHandle);
				this._ts.TraceInformation("Generating local reports");
				foreach (ReportData reportData in this.Reports)
				{
					clientReportParameters.ReportData = reportData;
					if (reportData.Format.HasFlag(ReportFormat.CSV))
					{
						if (this.ShouldCreateCsvReports)
						{
							this.CreateReport(clientReportParameters, ReportFormat.CSV);
						}
						else
						{
							this._ts.TraceCaller(TraceEventType.Verbose, string.Format("Skipping CSV report {0}", reportData.Type), "GenerateReports");
						}
					}
					if (reportData.Format.HasFlag(ReportFormat.PDF))
					{
						if (this.ShouldCreatePdfReports)
						{
							this.CreateReport(clientReportParameters, ReportFormat.PDF);
						}
						else
						{
							this._ts.TraceCaller(TraceEventType.Verbose, string.Format("Skipping PDF report {0}", reportData.Type), "GenerateReports");
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "GenerateReports");
			}
			this._ts.TraceInformation("Done generating reports");
			this._eventAggregator.GetEvent<EngineEvents.ReportsGenerated>().Publish(this._wizardParameters.ReportFolder);
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x000292EC File Offset: 0x000274EC
		private void CreateReport(IClientReportParameters clientReportParameters, ReportFormat format)
		{
			this._ts.TraceInformation(string.Format("Generating local report {0} in {1} format", clientReportParameters.ReportData.Type, format));
			ClientReport clientReport = ClientReport.CreateReport(clientReportParameters, format);
			if (clientReport != null)
			{
				try
				{
					if (!clientReport.GenerateReport())
					{
						this._ts.TraceInformation("GenerateReport returned failure");
					}
					return;
				}
				catch (Exception ex)
				{
					this._ts.TraceException(ex, "CreateReport");
					return;
				}
			}
			this._ts.TraceError("Unable to create client report");
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00029380 File Offset: 0x00027580
		private ReportData NewReport(string fileName, ReportType type, ReportFormat format, bool append = false)
		{
			return new ReportData
			{
				FileName = Path.Combine(this._wizardParameters.ReportFolder, fileName),
				Type = type,
				Format = format,
				Append = append
			};
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x000293B4 File Offset: 0x000275B4
		public void InitializeReports(ClientReportPolicyData reportPolicyData)
		{
			if (!this._wizardParameters.IsReportFolderSpecified && !string.IsNullOrEmpty(reportPolicyData.BaseDir))
			{
				this._wizardParameters.ReportFolder = reportPolicyData.BaseDir;
			}
			if (reportPolicyData.GenerateDefaultReports)
			{
				this.Reports = new List<ReportData>
				{
					this.NewReport(Resources.Report_Filename_Summary, ReportType.Summary, ReportFormat.CSV | ReportFormat.PDF, true),
					this.NewReport(Resources.Report_Filename_Applications, ReportType.Applications, ReportFormat.CSV | ReportFormat.PDF, false),
					this.NewReport(Resources.Report_Filename_Users, ReportType.Users, ReportFormat.CSV | ReportFormat.PDF, false)
				};
			}
			if (reportPolicyData.Reports != null)
			{
				foreach (ReportData item in reportPolicyData.Reports)
				{
					this.Reports.Add(item);
				}
			}
		}

		// Token: 0x04000568 RID: 1384
		private IEventAggregator _eventAggregator;

		// Token: 0x04000569 RID: 1385
		private IWizardParameters _wizardParameters;

		// Token: 0x0400056A RID: 1386
		private IUnityContainer _container;

		// Token: 0x0400056B RID: 1387
		private LlTraceSource _ts;

		// Token: 0x0400056D RID: 1389
		private bool? _shouldCreatePdfReports;
	}
}
