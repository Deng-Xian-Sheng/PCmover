using System;
using System.IO;
using System.ServiceModel;
using System.Windows;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PCmover.Infrastructure;
using WizardModule.Properties;

namespace WizardModule
{
	// Token: 0x02000004 RID: 4
	public class WizardParameters : IWizardParameters, IEngineParameters
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000022E1 File Offset: 0x000004E1
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000022E9 File Offset: 0x000004E9
		public bool UseScriptEngine { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000022F2 File Offset: 0x000004F2
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000022FA File Offset: 0x000004FA
		public bool MockPcmover { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002303 File Offset: 0x00000503
		// (set) Token: 0x06000024 RID: 36 RVA: 0x0000230B File Offset: 0x0000050B
		public AuthorizationRequestData AuthInfo { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002314 File Offset: 0x00000514
		// (set) Token: 0x06000026 RID: 38 RVA: 0x0000231C File Offset: 0x0000051C
		public bool ForceSimMode { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002325 File Offset: 0x00000525
		// (set) Token: 0x06000028 RID: 40 RVA: 0x0000232D File Offset: 0x0000052D
		public bool MSaad { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002336 File Offset: 0x00000536
		// (set) Token: 0x0600002A RID: 42 RVA: 0x0000233E File Offset: 0x0000053E
		public bool Newpol { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002347 File Offset: 0x00000547
		// (set) Token: 0x0600002C RID: 44 RVA: 0x0000234F File Offset: 0x0000054F
		public bool MinUI { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002358 File Offset: 0x00000558
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002360 File Offset: 0x00000560
		public bool DisableRecord { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002369 File Offset: 0x00000569
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002371 File Offset: 0x00000571
		public bool NoSplash { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000031 RID: 49 RVA: 0x0000237A File Offset: 0x0000057A
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002382 File Offset: 0x00000582
		public bool HideUI { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000033 RID: 51 RVA: 0x0000238B File Offset: 0x0000058B
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00002393 File Offset: 0x00000593
		public bool CompactUI { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000239C File Offset: 0x0000059C
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000023A4 File Offset: 0x000005A4
		public string ConnectionId { get; set; } = string.Empty;

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000023AD File Offset: 0x000005AD
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000023B5 File Offset: 0x000005B5
		public string DeferredVan { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000023BE File Offset: 0x000005BE
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000023C6 File Offset: 0x000005C6
		public string Email { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000023CF File Offset: 0x000005CF
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000023D7 File Offset: 0x000005D7
		public EndpointAddress PcmoverServiceAddress { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000023E0 File Offset: 0x000005E0
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000023E8 File Offset: 0x000005E8
		public IConnectToService ConnectToService { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000023F1 File Offset: 0x000005F1
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000023F9 File Offset: 0x000005F9
		public bool IsNew { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002402 File Offset: 0x00000602
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000240A File Offset: 0x0000060A
		public bool IsOld { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002413 File Offset: 0x00000613
		// (set) Token: 0x06000044 RID: 68 RVA: 0x0000241B File Offset: 0x0000061B
		public string Source { get; set; } = string.Empty;

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002424 File Offset: 0x00000624
		// (set) Token: 0x06000046 RID: 70 RVA: 0x0000242C File Offset: 0x0000062C
		public string DestAddress { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002435 File Offset: 0x00000635
		// (set) Token: 0x06000048 RID: 72 RVA: 0x0000243D File Offset: 0x0000063D
		public string SourceAddress { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002446 File Offset: 0x00000646
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000244E File Offset: 0x0000064E
		public string SourceCertificate { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002457 File Offset: 0x00000657
		// (set) Token: 0x0600004C RID: 76 RVA: 0x0000245F File Offset: 0x0000065F
		public string VanFile { get; set; } = string.Empty;

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002468 File Offset: 0x00000668
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002470 File Offset: 0x00000670
		public bool LaunchDownloadManager { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002479 File Offset: 0x00000679
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002481 File Offset: 0x00000681
		public bool? SingleMachineMode { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000248A File Offset: 0x0000068A
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002492 File Offset: 0x00000692
		public SplashScreen SplashScreen { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000249B File Offset: 0x0000069B
		// (set) Token: 0x06000054 RID: 84 RVA: 0x000024A3 File Offset: 0x000006A3
		public string HostName { get; set; } = "localhost";

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000024AC File Offset: 0x000006AC
		// (set) Token: 0x06000056 RID: 86 RVA: 0x000024EB File Offset: 0x000006EB
		public string LogFolder
		{
			get
			{
				if (this._logFolder == null)
				{
					Environment.SpecialFolder folder = IdentityHelper.IsAdministrator ? Environment.SpecialFolder.CommonApplicationData : Environment.SpecialFolder.ApplicationData;
					this._logFolder = Path.Combine(Environment.GetFolderPath(folder), "Laplink\\Pcmover");
				}
				return this._logFolder;
			}
			set
			{
				this._logFolder = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000024F4 File Offset: 0x000006F4
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000253E File Offset: 0x0000073E
		public string ReportFolder
		{
			get
			{
				if (this._reportFolder == null)
				{
					Environment.SpecialFolder folder = Environment.SpecialFolder.Personal;
					string text = Resources.WP_ReportsPath;
					if (text.StartsWith("\\"))
					{
						text = text.Substring(1);
					}
					this._reportFolder = Path.Combine(Environment.GetFolderPath(folder), text);
				}
				return this._reportFolder;
			}
			set
			{
				this._reportFolder = value;
				this.IsReportFolderSpecified = true;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000254E File Offset: 0x0000074E
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002556 File Offset: 0x00000756
		public bool IsReportFolderSpecified { get; private set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000255F File Offset: 0x0000075F
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002567 File Offset: 0x00000767
		public PolicyInfo PolicyInfo { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002570 File Offset: 0x00000770
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002578 File Offset: 0x00000778
		public EnvLookup ServiceEnvironment { get; set; }

		// Token: 0x0600005F RID: 95 RVA: 0x00002581 File Offset: 0x00000781
		public WizardParameters()
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000025B8 File Offset: 0x000007B8
		public WizardParameters(StartupEventArgs e)
		{
			WizardParameters <>4__this = this;
			CmdLine cmdLine = new CmdLine(e);
			if (cmdLine.HasSwitch("script"))
			{
				this.UseScriptEngine = true;
			}
			if (cmdLine.HasSwitch("host"))
			{
				this.HostName = cmdLine.GetSafeArgument("host", 0, this.HostName);
			}
			if (cmdLine.HasSwitch("live"))
			{
				this.MockPcmover = false;
			}
			if (cmdLine.HasSwitch("downloadmanager"))
			{
				this.LaunchDownloadManager = true;
			}
			if (cmdLine.HasSwitch("policy"))
			{
				this.PolicyInfo = new PolicyInfo
				{
					PolicyPath = cmdLine.GetSafeArgument("policy", 0, "")
				};
			}
			if (cmdLine.HasSwitch("endpoint"))
			{
				CodeHelper.trycatch(delegate()
				{
					<>4__this.PcmoverServiceAddress = new EndpointAddress(cmdLine.GetSafeArgument("endpoint", 0, ""));
				});
			}
			if (cmdLine.HasSwitch("source"))
			{
				this.Source = cmdLine.GetSafeArgument("source", 0, "");
			}
			if (cmdLine.HasSwitch("SN"))
			{
				this.AuthInfo = new AuthorizationRequestData
				{
					SerialNumber = cmdLine.GetSafeArgument("SN", 0, "")
				};
			}
			if (cmdLine.HasSwitch("forceSimMode"))
			{
				this.ForceSimMode = true;
			}
			if (cmdLine.HasSwitch("aad"))
			{
				this.MSaad = true;
			}
			if (cmdLine.HasSwitch("newpol"))
			{
				this.Newpol = true;
			}
			if (cmdLine.HasSwitch("minui"))
			{
				this.MinUI = true;
			}
			if (cmdLine.HasSwitch("id"))
			{
				this.ConnectionId = cmdLine.GetSafeArgument("id", 0, string.Empty);
			}
			if (cmdLine.HasSwitch("old"))
			{
				this.IsOld = true;
			}
			if (cmdLine.HasSwitch("new"))
			{
				this.IsNew = true;
			}
			if (cmdLine.HasSwitch("file"))
			{
				this.VanFile = cmdLine.GetSafeArgument("file", 0, string.Empty);
			}
			if (cmdLine.HasSwitch("deferred"))
			{
				this.DeferredVan = cmdLine.GetSafeArgument("deferred", 0, string.Empty);
			}
			if (cmdLine.HasSwitch("disablerecord"))
			{
				this.DisableRecord = true;
			}
			if (cmdLine.HasSwitch("email"))
			{
				this.Email = cmdLine.GetSafeArgument("email", 0, string.Empty);
			}
			if (cmdLine.HasSwitch("compactui"))
			{
				this.CompactUI = true;
			}
			if (cmdLine.HasSwitch("nosplash"))
			{
				this.NoSplash = true;
			}
			if (cmdLine.HasSwitch("singlemachinemode"))
			{
				this.SingleMachineMode = new bool?(true);
			}
			if (cmdLine.HasSwitch("hideui"))
			{
				this.HideUI = true;
			}
			if (cmdLine.HasSwitch("logfolder"))
			{
				this.LogFolder = cmdLine.GetSafeArgument("logfolder", 0, null);
			}
			if (cmdLine.HasSwitch("reportfolder"))
			{
				this.ReportFolder = cmdLine.GetSafeArgument("reportfolder", 0, null);
			}
		}

		// Token: 0x04000023 RID: 35
		private string _logFolder;

		// Token: 0x04000024 RID: 36
		private string _reportFolder;
	}
}
