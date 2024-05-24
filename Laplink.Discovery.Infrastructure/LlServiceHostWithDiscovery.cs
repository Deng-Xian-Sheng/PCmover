using System;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x0200000F RID: 15
	public class LlServiceHostWithDiscovery : LlServiceHost
	{
		// Token: 0x06000048 RID: 72 RVA: 0x00002D60 File Offset: 0x00000F60
		public static H CreateDiscoveryHost<H>(Func<H> hostNew, bool optionalTcp = false) where H : LlServiceHostWithDiscovery
		{
			H h = default(H);
			try
			{
				h = hostNew();
				bool flag = h.Initialize();
				if (!flag)
				{
					h.Ts.TraceInformation("Could not create ServiceHost.");
					if (optionalTcp && h.AllowTcpBindings && (h.CreateSecureTcpBindings || h.CreateOpenTcpBindings))
					{
						h.Ts.TraceInformation("Trying again without TCP");
						h.Abort();
						h = hostNew();
						h.AllowTcpBindings = false;
						flag = h.Initialize();
					}
				}
				if (flag)
				{
					h.Ts.TraceInformation("ServiceHost created");
					return h;
				}
				h.Ts.TraceInformation("Could not create ServiceHost");
				h.Abort();
			}
			catch (Exception ex)
			{
				H h2 = h;
				if (h2 != null)
				{
					h2.Ts.TraceException(ex, "CreateDiscoveryHost");
				}
			}
			return default(H);
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002E84 File Offset: 0x00001084
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002E8C File Offset: 0x0000108C
		public DiscoveryServiceConfig DiscoveryServiceConfig { get; set; } = new DiscoveryServiceConfig();

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002E95 File Offset: 0x00001095
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002E9D File Offset: 0x0000109D
		public AnnouncementManager AnnouncementManager { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002EA6 File Offset: 0x000010A6
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002EAE File Offset: 0x000010AE
		public bool AllowDiscovery { get; set; } = true;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002EB7 File Offset: 0x000010B7
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002EBF File Offset: 0x000010BF
		public string AllowDiscoverySetting { get; set; } = "allowDiscovery";

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002EC8 File Offset: 0x000010C8
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002ED0 File Offset: 0x000010D0
		public string ContractNamespace { get; set; }

		// Token: 0x06000053 RID: 83 RVA: 0x00002ED9 File Offset: 0x000010D9
		public LlServiceHostWithDiscovery(object singletonInstance, LlTraceSource ts) : base(singletonInstance, ts)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002F00 File Offset: 0x00001100
		public override bool Initialize()
		{
			this.AnnouncementManager = new AnnouncementManager(this, this.ContractNamespace, this.DiscoveryServiceConfig, base.Ts);
			this.ReadDiscoverySettings();
			if (!base.Initialize())
			{
				return false;
			}
			this.AnnouncementManager.AnnounceOnline();
			return true;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F3C File Offset: 0x0000113C
		private void ReadDiscoverySettings()
		{
			if (this.AllowDiscovery)
			{
				this.AllowDiscovery = ConfigHelper.GetBoolSetting(this.AllowDiscoverySetting, true);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002F58 File Offset: 0x00001158
		protected override void OnClose(TimeSpan timeout)
		{
			AnnouncementManager announcementManager = this.AnnouncementManager;
			if (announcementManager != null)
			{
				announcementManager.AnnounceOffline();
			}
			base.OnClose(timeout);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002F74 File Offset: 0x00001174
		public override void ConfigureEndpoint(ServiceEndpoint serviceEndpoint)
		{
			if (serviceEndpoint.ListenUri.Host == "localhost")
			{
				EndpointDiscoveryBehavior item = new EndpointDiscoveryBehavior
				{
					Enabled = false
				};
				serviceEndpoint.EndpointBehaviors.Add(item);
			}
			base.ConfigureEndpoint(serviceEndpoint);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002FB8 File Offset: 0x000011B8
		protected override void PrepareToOpen()
		{
			if (this.AllowDiscovery)
			{
				this.AnnouncementManager.AddUdpAnnouncements();
				base.Ts.TraceInformation("Added UDP announcements");
			}
			base.PrepareToOpen();
		}
	}
}
