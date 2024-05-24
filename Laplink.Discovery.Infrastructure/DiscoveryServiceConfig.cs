using System;
using Laplink.Tools.Helpers;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x0200000B RID: 11
	public class DiscoveryServiceConfig
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002C0A File Offset: 0x00000E0A
		public string AnnouncementUriString
		{
			get
			{
				return DiscoveryConstants.CreateUriString(this.Scheme, this.Host, this.Port, this.AnnouncementPath);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002C29 File Offset: 0x00000E29
		public string ProbeUriString
		{
			get
			{
				return DiscoveryConstants.CreateUriString(this.Scheme, this.Host, this.Port, this.ProbePath);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002C48 File Offset: 0x00000E48
		public DiscoveryServiceConfig() : this("discoveryService", null, 29720, null, null, null)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002C60 File Offset: 0x00000E60
		public DiscoveryServiceConfig(string configName, string scheme, int port, string host, string announcementPath = null, string probePath = null)
		{
			this.Scheme = (scheme ?? DiscoveryConstants.DiscoveryServiceScheme);
			this.Port = port;
			this.Host = host;
			this.AnnouncementPath = (announcementPath ?? DiscoveryConstants.DiscoveryServiceAnnouncementPath);
			this.ProbePath = (probePath ?? DiscoveryConstants.DiscoveryServiceProbePath);
			this.GetSettings(configName);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002CC4 File Offset: 0x00000EC4
		private void GetSettings(string configName)
		{
			this.Scheme = ConfigHelper.GetStringSetting(configName + "Scheme", this.Scheme);
			this.Port = ConfigHelper.GetIntSetting(configName + "Port", this.Port);
			this.Host = ConfigHelper.GetStringSetting(configName + "Host", this.Host);
			this.AnnouncementPath = ConfigHelper.GetStringSetting(configName + "AnnouncementPath", this.AnnouncementPath);
			this.ProbePath = ConfigHelper.GetStringSetting(configName + "ProbePath", this.ProbePath);
		}

		// Token: 0x0400001D RID: 29
		public string Scheme;

		// Token: 0x0400001E RID: 30
		public int Port = -1;

		// Token: 0x0400001F RID: 31
		public string Host;

		// Token: 0x04000020 RID: 32
		public string AnnouncementPath;

		// Token: 0x04000021 RID: 33
		public string ProbePath;
	}
}
