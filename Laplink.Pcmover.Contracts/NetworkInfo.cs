using System;
using System.Net.NetworkInformation;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200008F RID: 143
	public class NetworkInfo
	{
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060003BA RID: 954 RVA: 0x000045A6 File Offset: 0x000027A6
		// (set) Token: 0x060003BB RID: 955 RVA: 0x000045AE File Offset: 0x000027AE
		public string Description { get; set; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060003BC RID: 956 RVA: 0x000045B7 File Offset: 0x000027B7
		// (set) Token: 0x060003BD RID: 957 RVA: 0x000045BF File Offset: 0x000027BF
		public string Name { get; set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060003BE RID: 958 RVA: 0x000045C8 File Offset: 0x000027C8
		// (set) Token: 0x060003BF RID: 959 RVA: 0x000045D0 File Offset: 0x000027D0
		public int OperationalStatusInteger { get; set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x000045D9 File Offset: 0x000027D9
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x000045E1 File Offset: 0x000027E1
		public int NetworkInterfaceTypeInteger { get; set; }

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x000045EA File Offset: 0x000027EA
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x000045F2 File Offset: 0x000027F2
		public bool IsReceiveOnly { get; set; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x000045FB File Offset: 0x000027FB
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x00004603 File Offset: 0x00002803
		public long Speed { get; set; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000460C File Offset: 0x0000280C
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x00004614 File Offset: 0x00002814
		public bool SupportsMulticast { get; set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000461D File Offset: 0x0000281D
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x00004625 File Offset: 0x00002825
		public string Id { get; set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0000462E File Offset: 0x0000282E
		public NetworkInterfaceType NetworkInterfaceType
		{
			get
			{
				return (NetworkInterfaceType)this.NetworkInterfaceTypeInteger;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00004636 File Offset: 0x00002836
		public OperationalStatus OperationalStatus
		{
			get
			{
				return (OperationalStatus)this.OperationalStatusInteger;
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00002050 File Offset: 0x00000250
		public NetworkInfo()
		{
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00004640 File Offset: 0x00002840
		public NetworkInfo(NetworkInterface nic)
		{
			this.Description = nic.Description;
			this.Name = nic.Name;
			this.OperationalStatusInteger = (int)nic.OperationalStatus;
			this.NetworkInterfaceTypeInteger = (int)nic.NetworkInterfaceType;
			this.IsReceiveOnly = nic.IsReceiveOnly;
			this.Speed = nic.Speed;
			this.SupportsMulticast = nic.SupportsMulticast;
			this.Id = nic.Id;
		}
	}
}
