using System;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000035 RID: 53
	public class NetworkConnection
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00003F34 File Offset: 0x00002134
		internal NetworkConnection(INetworkConnection networkConnection)
		{
			this.networkConnection = networkConnection;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00003F48 File Offset: 0x00002148
		public Network Network
		{
			get
			{
				return new Network(this.networkConnection.GetNetwork());
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00003F6C File Offset: 0x0000216C
		public Guid AdapterId
		{
			get
			{
				return this.networkConnection.GetAdapterId();
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00003F8C File Offset: 0x0000218C
		public Guid ConnectionId
		{
			get
			{
				return this.networkConnection.GetConnectionId();
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00003FAC File Offset: 0x000021AC
		public ConnectivityStates Connectivity
		{
			get
			{
				return this.networkConnection.GetConnectivity();
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00003FCC File Offset: 0x000021CC
		public DomainType DomainType
		{
			get
			{
				return this.networkConnection.GetDomainType();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003FEC File Offset: 0x000021EC
		public bool IsConnectedToInternet
		{
			get
			{
				return this.networkConnection.IsConnectedToInternet;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x0000400C File Offset: 0x0000220C
		public bool IsConnected
		{
			get
			{
				return this.networkConnection.IsConnected;
			}
		}

		// Token: 0x04000205 RID: 517
		private INetworkConnection networkConnection;
	}
}
