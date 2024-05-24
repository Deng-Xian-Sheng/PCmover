using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000003 RID: 3
	public class AnnouncementManager : IDisposable
	{
		// Token: 0x06000011 RID: 17 RVA: 0x0000220B File Offset: 0x0000040B
		public AnnouncementManager(ServiceHost host, string contractNamespace, DiscoveryServiceConfig discoveryServiceConfig, LlTraceSource ts)
		{
			this._host = host;
			this._contractNamespace = contractNamespace;
			this.Ts = ts;
			this.AddDirectAnnouncementManager((discoveryServiceConfig != null) ? discoveryServiceConfig.AnnouncementUriString : null, false);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002248 File Offset: 0x00000448
		public void AddUdpAnnouncements()
		{
			LlTraceSource ts = this.Ts;
			if (ts != null)
			{
				ts.TraceCaller(null, "AddUdpAnnouncements");
			}
			ServiceDiscoveryBehavior serviceDiscoveryBehavior = new ServiceDiscoveryBehavior();
			this._host.Description.Behaviors.Add(serviceDiscoveryBehavior);
			serviceDiscoveryBehavior.AnnouncementEndpoints.Add(new CorrectedUdpAnnouncementEndpoint());
			this._host.AddServiceEndpoint(new UdpDiscoveryEndpoint());
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022A8 File Offset: 0x000004A8
		private DirectAnnouncementManager GetDirectAnnouncementManager(string announcementUriString)
		{
			List<DirectAnnouncementManager> directAnnouncementManagers = this._directAnnouncementManagers;
			DirectAnnouncementManager result;
			lock (directAnnouncementManagers)
			{
				result = this._directAnnouncementManagers.FirstOrDefault((DirectAnnouncementManager dam) => string.Compare(announcementUriString, dam.AnnouncementUriString, true) == 0);
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002308 File Offset: 0x00000508
		public DirectAnnouncementManager AddDirectAnnouncementManager(string announcementUriString, bool announceOnline = true)
		{
			if (string.IsNullOrWhiteSpace(announcementUriString))
			{
				return null;
			}
			List<DirectAnnouncementManager> directAnnouncementManagers = this._directAnnouncementManagers;
			DirectAnnouncementManager directAnnouncementManager;
			lock (directAnnouncementManagers)
			{
				directAnnouncementManager = this.GetDirectAnnouncementManager(announcementUriString);
				if (directAnnouncementManager != null)
				{
					return directAnnouncementManager;
				}
				directAnnouncementManager = new DirectAnnouncementManager(this._host, this._contractNamespace, announcementUriString, this.Ts);
				this._directAnnouncementManagers.Add(directAnnouncementManager);
			}
			if (announceOnline)
			{
				directAnnouncementManager.AnnounceOnline();
			}
			return directAnnouncementManager;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000238C File Offset: 0x0000058C
		public bool RemoveDirectAnnouncementManager(string announcementUriString)
		{
			List<DirectAnnouncementManager> directAnnouncementManagers = this._directAnnouncementManagers;
			DirectAnnouncementManager directAnnouncementManager;
			lock (directAnnouncementManagers)
			{
				directAnnouncementManager = this.GetDirectAnnouncementManager(announcementUriString);
				if (directAnnouncementManager == null)
				{
					return false;
				}
				this._directAnnouncementManagers.Remove(directAnnouncementManager);
			}
			directAnnouncementManager.Disconnect();
			return true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000023EC File Offset: 0x000005EC
		public void AnnounceOnline()
		{
			List<DirectAnnouncementManager> directAnnouncementManagers = this._directAnnouncementManagers;
			lock (directAnnouncementManagers)
			{
				foreach (DirectAnnouncementManager directAnnouncementManager in this._directAnnouncementManagers)
				{
					directAnnouncementManager.AnnounceOnline();
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002464 File Offset: 0x00000664
		public void AnnounceOffline()
		{
			List<DirectAnnouncementManager> directAnnouncementManagers = this._directAnnouncementManagers;
			lock (directAnnouncementManagers)
			{
				foreach (DirectAnnouncementManager directAnnouncementManager in this._directAnnouncementManagers)
				{
					directAnnouncementManager.AnnounceOffline();
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024DC File Offset: 0x000006DC
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				CodeHelper.trycatch(delegate()
				{
					this.AnnounceOffline();
				});
				this.disposedValue = true;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002500 File Offset: 0x00000700
		~AnnouncementManager()
		{
			this.Dispose(false);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002530 File Offset: 0x00000730
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000004 RID: 4
		private readonly string _contractNamespace;

		// Token: 0x04000005 RID: 5
		private readonly LlTraceSource Ts;

		// Token: 0x04000006 RID: 6
		private readonly ServiceHost _host;

		// Token: 0x04000007 RID: 7
		private readonly List<DirectAnnouncementManager> _directAnnouncementManagers = new List<DirectAnnouncementManager>();

		// Token: 0x04000008 RID: 8
		private bool disposedValue;
	}
}
