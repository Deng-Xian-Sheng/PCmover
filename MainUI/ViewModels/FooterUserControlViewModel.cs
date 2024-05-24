using System;
using System.Diagnostics;
using System.Reflection;
using Laplink.Tools.Helpers;
using MainUI.Properties;
using Prism.Commands;
using Prism.Mvvm;

namespace MainUI.ViewModels
{
	// Token: 0x02000013 RID: 19
	public class FooterUserControlViewModel : BindableBase
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00004FC8 File Offset: 0x000031C8
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00004FD0 File Offset: 0x000031D0
		public bool IsAboutOpen
		{
			get
			{
				return this._IsAboutOpen;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsAboutOpen, value, "IsAboutOpen");
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004FE5 File Offset: 0x000031E5
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00004FED File Offset: 0x000031ED
		public bool IsLatestVersion
		{
			get
			{
				return this._IsLatestVersion;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsLatestVersion, value, "IsLatestVersion");
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00005002 File Offset: 0x00003202
		// (set) Token: 0x060000DB RID: 219 RVA: 0x0000500A File Offset: 0x0000320A
		public string LatestVersion
		{
			get
			{
				return this.latestVersion;
			}
			private set
			{
				this.SetProperty<string>(ref this.latestVersion, value, "LatestVersion");
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00005020 File Offset: 0x00003220
		public FooterUserControlViewModel(LlTraceSource ts)
		{
			this.ts = ts;
			this.OnFTAClick = new DelegateCommand(new Action(this.OnFTAClickCommand));
			this.OnAbout = new DelegateCommand(new Action(this.OnAboutCommand));
			this.OnCloseAbout = new DelegateCommand(new Action(this.OnCloseAboutCommand));
			this.LatestVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
			this.IsAboutOpen = false;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000DD RID: 221 RVA: 0x000050A0 File Offset: 0x000032A0
		// (set) Token: 0x060000DE RID: 222 RVA: 0x000050A8 File Offset: 0x000032A8
		public DelegateCommand OnFTAClick { get; private set; }

		// Token: 0x060000DF RID: 223 RVA: 0x000050B4 File Offset: 0x000032B4
		private void OnFTAClickCommand()
		{
			try
			{
				Uri uri = new Uri(Resources.FTAURL);
				if (!string.IsNullOrWhiteSpace(uri.AbsoluteUri))
				{
					Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
				}
			}
			catch (Exception ex)
			{
				this.ts.TraceException(ex, "OnFTAClickCommand");
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00005110 File Offset: 0x00003310
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00005118 File Offset: 0x00003318
		public DelegateCommand OnAbout { get; private set; }

		// Token: 0x060000E2 RID: 226 RVA: 0x00005121 File Offset: 0x00003321
		private void OnAboutCommand()
		{
			this.IsAboutOpen = true;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000512A File Offset: 0x0000332A
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00005132 File Offset: 0x00003332
		public DelegateCommand OnCloseAbout { get; private set; }

		// Token: 0x060000E5 RID: 229 RVA: 0x0000513B File Offset: 0x0000333B
		private void OnCloseAboutCommand()
		{
			this.IsAboutOpen = false;
		}

		// Token: 0x04000057 RID: 87
		private readonly LlTraceSource ts;

		// Token: 0x04000058 RID: 88
		private bool _IsAboutOpen;

		// Token: 0x04000059 RID: 89
		private bool _IsLatestVersion;

		// Token: 0x0400005A RID: 90
		private string latestVersion;
	}
}
