using System;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x0200003B RID: 59
	public static class NetworkListManager
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x000043AC File Offset: 0x000025AC
		public static NetworkCollection GetNetworks(NetworkConnectivityLevels level)
		{
			CoreHelpers.ThrowIfNotVista();
			return new NetworkCollection(NetworkListManager.manager.GetNetworks(level));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000043D4 File Offset: 0x000025D4
		public static Network GetNetwork(Guid networkId)
		{
			CoreHelpers.ThrowIfNotVista();
			return new Network(NetworkListManager.manager.GetNetwork(networkId));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000043FC File Offset: 0x000025FC
		public static NetworkConnectionCollection GetNetworkConnections()
		{
			CoreHelpers.ThrowIfNotVista();
			return new NetworkConnectionCollection(NetworkListManager.manager.GetNetworkConnections());
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004424 File Offset: 0x00002624
		public static NetworkConnection GetNetworkConnection(Guid networkConnectionId)
		{
			CoreHelpers.ThrowIfNotVista();
			return new NetworkConnection(NetworkListManager.manager.GetNetworkConnection(networkConnectionId));
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000FD RID: 253 RVA: 0x0000444C File Offset: 0x0000264C
		public static bool IsConnectedToInternet
		{
			get
			{
				CoreHelpers.ThrowIfNotVista();
				return NetworkListManager.manager.IsConnectedToInternet;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00004470 File Offset: 0x00002670
		public static bool IsConnected
		{
			get
			{
				CoreHelpers.ThrowIfNotVista();
				return NetworkListManager.manager.IsConnected;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004494 File Offset: 0x00002694
		public static ConnectivityStates Connectivity
		{
			get
			{
				CoreHelpers.ThrowIfNotVista();
				return NetworkListManager.manager.GetConnectivity();
			}
		}

		// Token: 0x0400021D RID: 541
		private static NetworkListManagerClass manager = new NetworkListManagerClass();
	}
}
