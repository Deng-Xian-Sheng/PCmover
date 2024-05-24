using System;
using System.Windows;
using PCmover.Infrastructure;

namespace WizardModule
{
	// Token: 0x02000003 RID: 3
	public interface IWizardParameters : IEngineParameters
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12
		bool CompactUI { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13
		// (set) Token: 0x0600000E RID: 14
		string DestAddress { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15
		string Email { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16
		bool HideUI { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17
		bool IsNew { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000012 RID: 18
		bool IsOld { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000013 RID: 19
		string LogFolder { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000014 RID: 20
		PolicyInfo PolicyInfo { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000015 RID: 21
		// (set) Token: 0x06000016 RID: 22
		string ReportFolder { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000017 RID: 23
		bool IsReportFolderSpecified { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000018 RID: 24
		// (set) Token: 0x06000019 RID: 25
		string SourceAddress { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001A RID: 26
		// (set) Token: 0x0600001B RID: 27
		string SourceCertificate { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001C RID: 28
		// (set) Token: 0x0600001D RID: 29
		SplashScreen SplashScreen { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600001E RID: 30
		string VanFile { get; }
	}
}
