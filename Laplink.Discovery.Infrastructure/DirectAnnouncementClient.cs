using System;
using System.ServiceModel.Discovery;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000005 RID: 5
	public class DirectAnnouncementClient : IDisposable
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000258B File Offset: 0x0000078B
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002593 File Offset: 0x00000793
		public AnnouncementClient AnnouncementClient { get; private set; }

		// Token: 0x0600001F RID: 31 RVA: 0x0000259C File Offset: 0x0000079C
		public DirectAnnouncementClient(DirectEndpoint<AnnouncementEndpoint> announcementEndpoint)
		{
			this.AnnouncementClient = new AnnouncementClient(announcementEndpoint.Endpoint);
			this.AnnouncementClient.Open();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000025C0 File Offset: 0x000007C0
		public DirectAnnouncementClient(string uriString) : this(new DirectEndpoint<AnnouncementEndpoint>(uriString))
		{
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000025CE File Offset: 0x000007CE
		public DirectAnnouncementClient(Uri uri) : this(new DirectEndpoint<AnnouncementEndpoint>(uri))
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000025DC File Offset: 0x000007DC
		public void Close()
		{
			this.AnnouncementClient.Close();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025E9 File Offset: 0x000007E9
		public void Announce(EndpointDiscoveryMetadata discoveryMetadata, AnnouncementType type)
		{
			if (type == AnnouncementType.Online)
			{
				this.AnnounceOnline(discoveryMetadata);
				return;
			}
			if (type == AnnouncementType.Offline)
			{
				this.AnnounceOffline(discoveryMetadata);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002601 File Offset: 0x00000801
		public void AnnounceOnline(EndpointDiscoveryMetadata discoveryMetadata)
		{
			this.AnnouncementClient.AnnounceOnline(discoveryMetadata);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000260F File Offset: 0x0000080F
		public void AnnounceOffline(EndpointDiscoveryMetadata discoveryMetadata)
		{
			this.AnnouncementClient.AnnounceOffline(discoveryMetadata);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000261D File Offset: 0x0000081D
		public void Dispose()
		{
			AnnouncementClient announcementClient = this.AnnouncementClient;
			if (announcementClient == null)
			{
				return;
			}
			((IDisposable)announcementClient).Dispose();
		}
	}
}
