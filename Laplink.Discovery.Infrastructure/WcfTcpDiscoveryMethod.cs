using System;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading.Tasks;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000011 RID: 17
	public class WcfTcpDiscoveryMethod : WcfDiscoveryMethodBase, IDiscoveryMethod, IDisposable
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000317C File Offset: 0x0000137C
		protected virtual FindCriteria DirectFindCriteria
		{
			get
			{
				return this.DefaultFindCriteria;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003184 File Offset: 0x00001384
		public bool IsEnabled { get; } = 1;

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000318C File Offset: 0x0000138C
		public bool UseAsync { get; }

		// Token: 0x06000061 RID: 97 RVA: 0x00003194 File Offset: 0x00001394
		public WcfTcpDiscoveryMethod(DiscoveryServiceConfig discoveryServiceConfig, DiscoveryServiceConfig localServiceConfig, IDiscoveryOutput discoveryOutput) : base(discoveryOutput)
		{
			this._discoveryServiceConfig = discoveryServiceConfig;
			this._localServiceConfig = localServiceConfig;
			this.IsEnabled = ConfigHelper.GetBoolSetting("DiscoverViaTcp", this.IsEnabled);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000031C8 File Offset: 0x000013C8
		public bool StartMonitoring()
		{
			AnnouncementEndpoint announcementEndpoint = this.CreateLocalAnnouncementService(this._localServiceConfig);
			if (announcementEndpoint == null)
			{
				return false;
			}
			using (DirectAnnouncementClient directAnnouncementClient = this.CreateDirectAnnouncementClient())
			{
				if (directAnnouncementClient == null)
				{
					return false;
				}
				this._announcedEdm = EndpointDiscoveryMetadata.FromServiceEndpoint(announcementEndpoint);
				try
				{
					directAnnouncementClient.AnnounceOnline(this._announcedEdm);
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "StartMonitoring");
					this._announcedEdm = null;
				}
			}
			return this._announcedEdm != null;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000325C File Offset: 0x0000145C
		private AnnouncementEndpoint CreateLocalAnnouncementService(DiscoveryServiceConfig localServiceConfig)
		{
			if (localServiceConfig == null)
			{
				return null;
			}
			AnnouncementService announcementService = new AnnouncementService();
			announcementService.OnlineAnnouncementReceived += this.OnOnlineAnnouncementDirect;
			announcementService.OfflineAnnouncementReceived += this.OnOfflineAnnouncementDirect;
			this._directAnnouncementServiceHost = new ServiceHost(announcementService, Array.Empty<Uri>());
			this._localAnnouncementUriString = localServiceConfig.AnnouncementUriString;
			AnnouncementEndpoint announcementEndpoint = new DirectEndpoint<AnnouncementEndpoint>(this._localAnnouncementUriString).Endpoint;
			this._directAnnouncementServiceHost.AddServiceEndpoint(announcementEndpoint);
			try
			{
				this._directAnnouncementServiceHost.Open();
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CreateLocalAnnouncementService");
				this._directAnnouncementServiceHost = null;
				announcementEndpoint = null;
			}
			return announcementEndpoint;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003310 File Offset: 0x00001510
		private void OnOnlineAnnouncementDirect(object sender, AnnouncementEventArgs e)
		{
			base.DiscoveryOutput.FireEndpointChange(e.EndpointDiscoveryMetadata, DiscoveryEndpointChange.Found);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003324 File Offset: 0x00001524
		private void OnOfflineAnnouncementDirect(object sender, AnnouncementEventArgs e)
		{
			base.DiscoveryOutput.FireEndpointChange(e.EndpointDiscoveryMetadata, DiscoveryEndpointChange.Lost);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003338 File Offset: 0x00001538
		private DirectAnnouncementClient CreateDirectAnnouncementClient()
		{
			DirectAnnouncementClient result = null;
			try
			{
				DiscoveryServiceConfig discoveryServiceConfig = this._discoveryServiceConfig;
				if (!string.IsNullOrWhiteSpace((discoveryServiceConfig != null) ? discoveryServiceConfig.Host : null))
				{
					result = new DirectAnnouncementClient(this._discoveryServiceConfig.AnnouncementUriString);
					base.Ts.TraceCaller(this._discoveryServiceConfig.AnnouncementUriString, "CreateDirectAnnouncementClient");
				}
			}
			catch (SystemException ex) when (ex is EndpointNotFoundException || ex is TimeoutException)
			{
				base.Ts.TraceException(ex, "CreateDirectAnnouncementClient");
			}
			return result;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000033DC File Offset: 0x000015DC
		public void FindEndpoints()
		{
			DiscoveryServiceConfig discoveryServiceConfig = this._discoveryServiceConfig;
			if (!string.IsNullOrWhiteSpace((discoveryServiceConfig != null) ? discoveryServiceConfig.Host : null))
			{
				DirectEndpoint<DiscoveryEndpoint> directEndpoint = new DirectEndpoint<DiscoveryEndpoint>(this._discoveryServiceConfig.ProbeUriString);
				base.Find(directEndpoint.Endpoint, this.DirectFindCriteria);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003425 File Offset: 0x00001625
		public Task FindEndpointsAsync()
		{
			this.FindEndpoints();
			return Task.CompletedTask;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003434 File Offset: 0x00001634
		public void Dispose()
		{
			if (this._announcedEdm != null)
			{
				DirectAnnouncementClient announcementClient = this.CreateDirectAnnouncementClient();
				try
				{
					CodeHelper.trycatch(delegate()
					{
						DirectAnnouncementClient announcementClient = announcementClient;
						if (announcementClient == null)
						{
							return;
						}
						announcementClient.AnnounceOffline(this._announcedEdm);
					});
					this._announcedEdm = null;
				}
				finally
				{
					if (announcementClient != null)
					{
						((IDisposable)announcementClient).Dispose();
					}
				}
			}
			CodeHelper.trycatch(delegate()
			{
				ServiceHost directAnnouncementServiceHost = this._directAnnouncementServiceHost;
				if (directAnnouncementServiceHost == null)
				{
					return;
				}
				directAnnouncementServiceHost.Close();
			});
		}

		// Token: 0x0400002E RID: 46
		private ServiceHost _directAnnouncementServiceHost;

		// Token: 0x0400002F RID: 47
		private DiscoveryServiceConfig _discoveryServiceConfig;

		// Token: 0x04000030 RID: 48
		private DiscoveryServiceConfig _localServiceConfig;

		// Token: 0x04000031 RID: 49
		private EndpointDiscoveryMetadata _announcedEdm;

		// Token: 0x04000032 RID: 50
		protected string _localAnnouncementUriString;
	}
}
