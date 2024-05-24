using System;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading.Tasks;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000012 RID: 18
	public class WcfUdpDiscoveryMethod : WcfDiscoveryMethodBase, IDiscoveryMethod, IDisposable
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000317C File Offset: 0x0000137C
		public virtual FindCriteria UdpFindCriteria
		{
			get
			{
				return this.DefaultFindCriteria;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006C RID: 108 RVA: 0x000034C6 File Offset: 0x000016C6
		public bool IsEnabled { get; } = 1;

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000034CE File Offset: 0x000016CE
		public bool UseAsync { get; }

		// Token: 0x0600006E RID: 110 RVA: 0x000034D6 File Offset: 0x000016D6
		public WcfUdpDiscoveryMethod(IDiscoveryOutput discoveryOutput) : base(discoveryOutput)
		{
			this.IsEnabled = ConfigHelper.GetBoolSetting("DiscoverViaUdp", this.IsEnabled);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000034FC File Offset: 0x000016FC
		public bool StartMonitoring()
		{
			AnnouncementService announcementService = new AnnouncementService();
			announcementService.OnlineAnnouncementReceived += this.OnOnlineAnnouncementUdp;
			announcementService.OfflineAnnouncementReceived += this.OnOfflineAnnouncementUdp;
			this._udpAnnouncementServiceHost = new ServiceHost(announcementService, Array.Empty<Uri>());
			this._udpAnnouncementServiceHost.AddServiceEndpoint(new UdpAnnouncementEndpoint());
			try
			{
				this._udpAnnouncementServiceHost.Open();
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartMonitoring");
				this._udpAnnouncementServiceHost = null;
			}
			return this._udpAnnouncementServiceHost != null;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003310 File Offset: 0x00001510
		private void OnOnlineAnnouncementUdp(object sender, AnnouncementEventArgs e)
		{
			base.DiscoveryOutput.FireEndpointChange(e.EndpointDiscoveryMetadata, DiscoveryEndpointChange.Found);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003324 File Offset: 0x00001524
		private void OnOfflineAnnouncementUdp(object sender, AnnouncementEventArgs e)
		{
			base.DiscoveryOutput.FireEndpointChange(e.EndpointDiscoveryMetadata, DiscoveryEndpointChange.Lost);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003598 File Offset: 0x00001798
		public void FindEndpoints()
		{
			base.Find(new UdpDiscoveryEndpoint(), this.UdpFindCriteria);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000035AB File Offset: 0x000017AB
		public Task FindEndpointsAsync()
		{
			this.FindEndpoints();
			return Task.CompletedTask;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000035B8 File Offset: 0x000017B8
		public void Dispose()
		{
			CodeHelper.trycatch(delegate()
			{
				ServiceHost udpAnnouncementServiceHost = this._udpAnnouncementServiceHost;
				if (udpAnnouncementServiceHost == null)
				{
					return;
				}
				udpAnnouncementServiceHost.Close();
			});
		}

		// Token: 0x04000035 RID: 53
		private ServiceHost _udpAnnouncementServiceHost;
	}
}
