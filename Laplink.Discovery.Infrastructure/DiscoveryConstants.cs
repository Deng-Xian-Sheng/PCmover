using System;

namespace Laplink.Discovery.Infrastructure
{
	// Token: 0x02000009 RID: 9
	public class DiscoveryConstants
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00002B3E File Offset: 0x00000D3E
		public static string CreateUriString(string scheme, string host, int port, string path)
		{
			if (string.IsNullOrWhiteSpace(host))
			{
				return null;
			}
			return new UriBuilder(scheme, host, port, path).Uri.AbsoluteUri;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002B5D File Offset: 0x00000D5D
		public static string CreateAnnouncementUriString(string scheme, string host, int port)
		{
			return DiscoveryConstants.CreateUriString(scheme, host, port, DiscoveryConstants.DiscoveryServiceAnnouncementPath);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002B6C File Offset: 0x00000D6C
		public static string CreateProbeUriString(string scheme, string host, int port)
		{
			return DiscoveryConstants.CreateUriString(scheme, host, port, DiscoveryConstants.DiscoveryServiceProbePath);
		}

		// Token: 0x04000017 RID: 23
		public static readonly string DiscoveryServiceScheme = Uri.UriSchemeNetTcp;

		// Token: 0x04000018 RID: 24
		public static readonly string DiscoveryServiceAnnouncementPath = "LlDiscoveryService/none/none/Announcement";

		// Token: 0x04000019 RID: 25
		public static readonly string DiscoveryServiceProbePath = "LlDiscoveryService/none/none/Probe";

		// Token: 0x0400001A RID: 26
		public static readonly TimeSpan DiscoveryRetryTime = TimeSpan.FromSeconds(30.0);

		// Token: 0x0400001B RID: 27
		public static readonly TimeSpan DiscoveryTimeout = TimeSpan.FromSeconds(65.0);

		// Token: 0x0400001C RID: 28
		public static readonly int DiscoveryMissedLimit = 3;
	}
}
