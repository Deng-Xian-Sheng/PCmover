using System;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using PCmover.Infrastructure;
using Prism.Events;
using Prism.Mvvm;

namespace WizardModule.ViewModels
{
	// Token: 0x02000095 RID: 149
	public class SslConfigurationViewModel : BindableBase
	{
		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x000208B9 File Offset: 0x0001EAB9
		// (set) Token: 0x06000C5B RID: 3163 RVA: 0x000208C1 File Offset: 0x0001EAC1
		public SslInfo SSLInfo
		{
			get
			{
				return this._SSLInfo;
			}
			set
			{
				this.SetProperty<SslInfo>(ref this._SSLInfo, value, "SSLInfo");
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x000208D6 File Offset: 0x0001EAD6
		// (set) Token: 0x06000C5D RID: 3165 RVA: 0x000208DE File Offset: 0x0001EADE
		public bool ShowSSL
		{
			get
			{
				return this._ShowSSL;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowSSL, value, "ShowSSL");
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x000208F3 File Offset: 0x0001EAF3
		// (set) Token: 0x06000C5F RID: 3167 RVA: 0x000208FB File Offset: 0x0001EAFB
		public string CertificateIssuer
		{
			get
			{
				return this._CertificateIssuer;
			}
			private set
			{
				this.SetProperty<string>(ref this._CertificateIssuer, value, "CertificateIssuer");
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00020910 File Offset: 0x0001EB10
		[Obsolete("For design only", true)]
		public SslConfigurationViewModel()
		{
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00020918 File Offset: 0x0001EB18
		public SslConfigurationViewModel(IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, LlTraceSource ts)
		{
			this._pcmoverEngine = pcmoverEngine;
			this._ts = ts;
			eventAggregator.GetEvent<Events.SSLInfoChanged>().Subscribe(new Action(this.OnSSLInfoChanged), ThreadOption.UIThread, false);
			eventAggregator.GetEvent<Events.ShowSSLIcon>().Subscribe(new Action<bool>(this.OnShowSSLIcon), ThreadOption.UIThread, false);
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00020970 File Offset: 0x0001EB70
		private void OnSSLInfoChanged()
		{
			try
			{
				this._pcmoverEngine.CatchCommEx(delegate
				{
					string text = null;
					MachineData otherMachine = this._pcmoverEngine.OtherMachine;
					if (otherMachine != null && otherMachine.Type == MachineType.Image)
					{
						this.SSLInfo = this._pcmoverEngine.GetLocalSslInfo();
						SslInfo sslinfo = this.SSLInfo;
						text = ((sslinfo != null) ? sslinfo.LocalIssuer : null);
					}
					else
					{
						this.SSLInfo = (this._pcmoverEngine.ThisMachineIsOld ? this._pcmoverEngine.GetLocalSslInfo() : this._pcmoverEngine.GetSslInfo());
						if (this.SSLInfo != null)
						{
							text = (this.SSLInfo.IsSSLClient ? this.SSLInfo.Issuer : this.SSLInfo.LocalIssuer);
							if (!string.IsNullOrWhiteSpace(text))
							{
								this.OnShowSSLIcon(this.SSLInfo.IsSecure);
							}
						}
					}
					string certificateIssuer;
					if (!string.IsNullOrWhiteSpace(text))
					{
						certificateIssuer = text;
					}
					else
					{
						SslInfo sslinfo2 = this.SSLInfo;
						certificateIssuer = ((sslinfo2 != null) ? sslinfo2.PeerName : null);
					}
					this.CertificateIssuer = certificateIssuer;
				}, "OnSSLInfoChanged");
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "OnSSLInfoChanged");
				this.SSLInfo = null;
			}
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x000209C8 File Offset: 0x0001EBC8
		private void OnShowSSLIcon(bool show)
		{
			try
			{
				if (this._ShowSSL != show)
				{
					this.ShowSSL = show;
				}
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "OnShowSSLIcon");
				this.ShowSSL = false;
			}
		}

		// Token: 0x040003F8 RID: 1016
		private readonly IPCmoverEngine _pcmoverEngine;

		// Token: 0x040003F9 RID: 1017
		private readonly LlTraceSource _ts;

		// Token: 0x040003FA RID: 1018
		private SslInfo _SSLInfo;

		// Token: 0x040003FB RID: 1019
		private bool _ShowSSL;

		// Token: 0x040003FC RID: 1020
		private string _CertificateIssuer;
	}
}
