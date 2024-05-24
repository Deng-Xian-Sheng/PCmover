using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using System.Threading;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000006 RID: 6
	public class DirectAnnouncementManager : IDisposable
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000262F File Offset: 0x0000082F
		public string AnnouncementUriString { get; }

		// Token: 0x06000028 RID: 40 RVA: 0x00002637 File Offset: 0x00000837
		public DirectAnnouncementManager(ServiceHost host, string contractNamespace, string announcementUriString, LlTraceSource ts)
		{
			this._host = host;
			this._contractNamespace = contractNamespace;
			this.AnnouncementUriString = announcementUriString;
			this.Ts = ts;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002668 File Offset: 0x00000868
		public void AnnounceOnline()
		{
			if (this._announcements.Count > 0)
			{
				return;
			}
			if (this._exitAnnouncementEvent != null)
			{
				return;
			}
			this._exitAnnouncementEvent = new ManualResetEvent(false);
			this._announcementThread = new Thread(new ThreadStart(this.AnnouncementThread));
			this._announcementThread.Start();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026BC File Offset: 0x000008BC
		private void AnnouncementThread()
		{
			do
			{
				try
				{
					using (DirectAnnouncementClient directAnnouncementClient = new DirectAnnouncementClient(this.AnnouncementUriString))
					{
						this._announcements.Clear();
						LlTraceSource ts = this.Ts;
						if (ts != null)
						{
							ts.TraceCaller("Connected to Discovery service at " + this.AnnouncementUriString, "AnnouncementThread");
						}
						foreach (ServiceEndpoint serviceEndpoint in this._host.Description.Endpoints)
						{
							EndpointDiscoveryBehavior endpointDiscoveryBehavior = serviceEndpoint.EndpointBehaviors.FirstOrDefault((IEndpointBehavior b) => b is EndpointDiscoveryBehavior) as EndpointDiscoveryBehavior;
							if ((endpointDiscoveryBehavior == null || endpointDiscoveryBehavior.Enabled) && (this._contractNamespace == null || !(serviceEndpoint.Contract.Namespace != this._contractNamespace)))
							{
								EndpointDiscoveryMetadata endpointDiscoveryMetadata = EndpointDiscoveryMetadata.FromServiceEndpoint(serviceEndpoint);
								LlTraceSource ts2 = this.Ts;
								if (ts2 != null)
								{
									ts2.TraceCaller(endpointDiscoveryMetadata.GetFriendlyName(), "AnnouncementThread");
								}
								this._announcements.Add(endpointDiscoveryMetadata);
								directAnnouncementClient.Announce(endpointDiscoveryMetadata, AnnouncementType.Online);
							}
						}
						directAnnouncementClient.Close();
					}
				}
				catch (SystemException ex) when (ex is EndpointNotFoundException || ex is TimeoutException)
				{
					LlTraceSource ts3 = this.Ts;
					if (ts3 != null)
					{
						ts3.TraceCaller("Unable to connect to Discovery service at " + this.AnnouncementUriString, "AnnouncementThread");
					}
				}
			}
			while (!this._exitAnnouncementEvent.WaitOne(DiscoveryConstants.DiscoveryRetryTime));
			this._exitAnnouncementEvent.Close();
			this._exitAnnouncementEvent = null;
			if (this._exitWithoutAnnouncing)
			{
				return;
			}
			try
			{
				using (DirectAnnouncementClient directAnnouncementClient2 = new DirectAnnouncementClient(this.AnnouncementUriString))
				{
					LlTraceSource ts4 = this.Ts;
					if (ts4 != null)
					{
						ts4.TraceCaller("Connected to Discovery service at " + this.AnnouncementUriString, "AnnouncementThread");
					}
					List<EndpointDiscoveryMetadata> announcements = this._announcements;
					this._announcements = new List<EndpointDiscoveryMetadata>();
					foreach (EndpointDiscoveryMetadata endpointDiscoveryMetadata2 in announcements)
					{
						LlTraceSource ts5 = this.Ts;
						if (ts5 != null)
						{
							ts5.TraceCaller(endpointDiscoveryMetadata2.GetFriendlyName(), "AnnouncementThread");
						}
						directAnnouncementClient2.Announce(endpointDiscoveryMetadata2, AnnouncementType.Offline);
					}
					directAnnouncementClient2.Close();
				}
			}
			catch (SystemException ex2) when (ex2 is EndpointNotFoundException || ex2 is TimeoutException)
			{
				LlTraceSource ts6 = this.Ts;
				if (ts6 != null)
				{
					ts6.TraceCaller("Unable to connect to Discovery service at " + this.AnnouncementUriString, "AnnouncementThread");
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A00 File Offset: 0x00000C00
		public void AnnounceOffline()
		{
			ManualResetEvent exitAnnouncementEvent = this._exitAnnouncementEvent;
			if (exitAnnouncementEvent == null)
			{
				return;
			}
			exitAnnouncementEvent.Set();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002A13 File Offset: 0x00000C13
		public void Disconnect()
		{
			this._exitWithoutAnnouncing = true;
			ManualResetEvent exitAnnouncementEvent = this._exitAnnouncementEvent;
			if (exitAnnouncementEvent == null)
			{
				return;
			}
			exitAnnouncementEvent.Set();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002A30 File Offset: 0x00000C30
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				try
				{
					this.AnnounceOffline();
				}
				catch
				{
				}
				this.disposedValue = true;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002A6C File Offset: 0x00000C6C
		~DirectAnnouncementManager()
		{
			this.Dispose(false);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002A9C File Offset: 0x00000C9C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0400000B RID: 11
		private readonly string _contractNamespace;

		// Token: 0x0400000C RID: 12
		private readonly LlTraceSource Ts;

		// Token: 0x0400000D RID: 13
		private readonly ServiceHost _host;

		// Token: 0x0400000E RID: 14
		private List<EndpointDiscoveryMetadata> _announcements = new List<EndpointDiscoveryMetadata>();

		// Token: 0x0400000F RID: 15
		private ManualResetEvent _exitAnnouncementEvent;

		// Token: 0x04000010 RID: 16
		private Thread _announcementThread;

		// Token: 0x04000011 RID: 17
		private bool _exitWithoutAnnouncing;

		// Token: 0x04000012 RID: 18
		private bool disposedValue;
	}
}
