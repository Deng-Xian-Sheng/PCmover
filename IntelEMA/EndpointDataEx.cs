using System;
using System.Collections.Generic;

namespace IntelEMA
{
	// Token: 0x0200000B RID: 11
	public class EndpointDataEx
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000063 RID: 99 RVA: 0x0000244E File Offset: 0x0000064E
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002456 File Offset: 0x00000656
		public string EndpointId { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000245F File Offset: 0x0000065F
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002467 File Offset: 0x00000667
		public string EndpointGroupId { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002470 File Offset: 0x00000670
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002478 File Offset: 0x00000678
		public string EndpointGroupName { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002481 File Offset: 0x00000681
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00002489 File Offset: 0x00000689
		public string LastUpdate { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002492 File Offset: 0x00000692
		// (set) Token: 0x0600006C RID: 108 RVA: 0x0000249A File Offset: 0x0000069A
		public string ComputerName { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000024A3 File Offset: 0x000006A3
		// (set) Token: 0x0600006E RID: 110 RVA: 0x000024AB File Offset: 0x000006AB
		public int? PlatformType { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000024B4 File Offset: 0x000006B4
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000024BC File Offset: 0x000006BC
		public string AgentVersion { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000024C5 File Offset: 0x000006C5
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000024CD File Offset: 0x000006CD
		public string AgentType { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000024D6 File Offset: 0x000006D6
		// (set) Token: 0x06000074 RID: 116 RVA: 0x000024DE File Offset: 0x000006DE
		public int? PowerState { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000024E7 File Offset: 0x000006E7
		// (set) Token: 0x06000076 RID: 118 RVA: 0x000024EF File Offset: 0x000006EF
		public string PowerStateUpdate { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000024F8 File Offset: 0x000006F8
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002500 File Offset: 0x00000700
		public bool? IsConnected { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002509 File Offset: 0x00000709
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002511 File Offset: 0x00000711
		public bool? IsCiraConnected { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000251A File Offset: 0x0000071A
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002522 File Offset: 0x00000722
		public int? NodeIdentity { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000252B File Offset: 0x0000072B
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00002533 File Offset: 0x00000733
		public string OperatingSystem { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600007F RID: 127 RVA: 0x0000253C File Offset: 0x0000073C
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00002544 File Offset: 0x00000744
		public int? NeighborsCount { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000081 RID: 129 RVA: 0x0000254D File Offset: 0x0000074D
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00002555 File Offset: 0x00000755
		public int? AgentLocalAdminMode { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000255E File Offset: 0x0000075E
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00002566 File Offset: 0x00000766
		public List<NetworkInterfaceData> NetworkInterfaces { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000256F File Offset: 0x0000076F
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002577 File Offset: 0x00000777
		public MEInfo MEInfo { get; set; }
	}
}
