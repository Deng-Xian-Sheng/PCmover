using System;
using System.Net;

namespace Laplink.Tools.Helpers
{
	// Token: 0x0200000B RID: 11
	public class NetworkHelper
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000033FC File Offset: 0x000015FC
		public static string LocalHostName
		{
			get
			{
				if (NetworkHelper._localHostName == null)
				{
					try
					{
						NetworkHelper._localHostName = Dns.GetHostName();
					}
					catch (Exception)
					{
						NetworkHelper._localHostName = "localhost";
					}
				}
				return NetworkHelper._localHostName;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003440 File Offset: 0x00001640
		public static string GetHostName(string address)
		{
			if (address == null || address == "localhost")
			{
				return address;
			}
			string name = address;
			CodeHelper.trycatch(delegate()
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(address);
				name = hostEntry.HostName;
			});
			return name;
		}

		// Token: 0x0400001A RID: 26
		public const int PcmoverUdpConnectPort = 12345;

		// Token: 0x0400001B RID: 27
		public const int PcmoverSslUdpConnectPort = 12346;

		// Token: 0x0400001C RID: 28
		public const int PcmoverUdpDiscoveryPort = 29717;

		// Token: 0x0400001D RID: 29
		public const int PcmoverTcpConnectPort = 29717;

		// Token: 0x0400001E RID: 30
		public const int PcmoverSslConnectPort = 29718;

		// Token: 0x0400001F RID: 31
		public const int WcfUdpDiscoveryPort = 3702;

		// Token: 0x04000020 RID: 32
		public const int WcfTcpDefaultPort = 808;

		// Token: 0x04000021 RID: 33
		public const int PcmoverServicePort = 29719;

		// Token: 0x04000022 RID: 34
		public const int DiscoveryServicePort = 29720;

		// Token: 0x04000023 RID: 35
		public const int LocalAnnouncementPort = 29721;

		// Token: 0x04000024 RID: 36
		public const int PcmoverLoaderUiPort = 29722;

		// Token: 0x04000025 RID: 37
		public const int DownloadManagerPort = 29723;

		// Token: 0x04000026 RID: 38
		public const int PcmoverLoaderServicePort = 29724;

		// Token: 0x04000027 RID: 39
		public const int PcmoverUnifiedPort = 29725;

		// Token: 0x04000028 RID: 40
		public const int DefaultPort = -1;

		// Token: 0x04000029 RID: 41
		public const string LocalHost = "localhost";

		// Token: 0x0400002A RID: 42
		private static string _localHostName;
	}
}
