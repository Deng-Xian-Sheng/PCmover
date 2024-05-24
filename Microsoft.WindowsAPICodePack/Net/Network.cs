using System;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000033 RID: 51
	public class Network
	{
		// Token: 0x060000DC RID: 220 RVA: 0x000039C5 File Offset: 0x00001BC5
		internal Network(INetwork network)
		{
			this.network = network;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000DD RID: 221 RVA: 0x000039D8 File Offset: 0x00001BD8
		// (set) Token: 0x060000DE RID: 222 RVA: 0x000039F5 File Offset: 0x00001BF5
		public NetworkCategory Category
		{
			get
			{
				return this.network.GetCategory();
			}
			set
			{
				this.network.SetCategory(value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003A08 File Offset: 0x00001C08
		public DateTime ConnectedTime
		{
			get
			{
				uint num;
				uint num2;
				uint num3;
				uint num4;
				this.network.GetTimeCreatedAndConnected(out num, out num2, out num3, out num4);
				long num5 = (long)((ulong)num4);
				num5 <<= 32;
				num5 |= (long)((ulong)num3);
				return DateTime.FromFileTimeUtc(num5);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00003A4C File Offset: 0x00001C4C
		public NetworkConnectionCollection Connections
		{
			get
			{
				return new NetworkConnectionCollection(this.network.GetNetworkConnections());
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00003A70 File Offset: 0x00001C70
		public ConnectivityStates Connectivity
		{
			get
			{
				return this.network.GetConnectivity();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00003A90 File Offset: 0x00001C90
		public DateTime CreatedTime
		{
			get
			{
				uint num;
				uint num2;
				uint num3;
				uint num4;
				this.network.GetTimeCreatedAndConnected(out num, out num2, out num3, out num4);
				long num5 = (long)((ulong)num2);
				num5 <<= 32;
				num5 |= (long)((ulong)num);
				return DateTime.FromFileTimeUtc(num5);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003AD4 File Offset: 0x00001CD4
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00003AF1 File Offset: 0x00001CF1
		public string Description
		{
			get
			{
				return this.network.GetDescription();
			}
			set
			{
				this.network.SetDescription(value);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00003B04 File Offset: 0x00001D04
		public DomainType DomainType
		{
			get
			{
				return this.network.GetDomainType();
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00003B24 File Offset: 0x00001D24
		public bool IsConnected
		{
			get
			{
				return this.network.IsConnected;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00003B44 File Offset: 0x00001D44
		public bool IsConnectedToInternet
		{
			get
			{
				return this.network.IsConnectedToInternet;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00003B64 File Offset: 0x00001D64
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00003B81 File Offset: 0x00001D81
		public string Name
		{
			get
			{
				return this.network.GetName();
			}
			set
			{
				this.network.SetName(value);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00003B94 File Offset: 0x00001D94
		public Guid NetworkId
		{
			get
			{
				return this.network.GetNetworkId();
			}
		}

		// Token: 0x04000203 RID: 515
		private INetwork network;
	}
}
