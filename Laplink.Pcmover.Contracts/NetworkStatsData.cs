using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200008D RID: 141
	public class NetworkStatsData
	{
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x000044FC File Offset: 0x000026FC
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00004504 File Offset: 0x00002704
		public ulong TotalUDPBytes { get; set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000450D File Offset: 0x0000270D
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00004515 File Offset: 0x00002715
		public ulong TotalUDPPackets { get; set; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0000451E File Offset: 0x0000271E
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x00004526 File Offset: 0x00002726
		public ulong TotalUDPTries { get; set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060003AA RID: 938 RVA: 0x0000452F File Offset: 0x0000272F
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00004537 File Offset: 0x00002737
		public ulong TotalUDPErrors { get; set; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00004540 File Offset: 0x00002740
		// (set) Token: 0x060003AD RID: 941 RVA: 0x00004548 File Offset: 0x00002748
		public uint UDPTimeSinceReceive { get; set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00004551 File Offset: 0x00002751
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00004559 File Offset: 0x00002759
		public int Ieee80211 { get; set; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00004562 File Offset: 0x00002762
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x0000456A File Offset: 0x0000276A
		public int Hardwired { get; set; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x00004573 File Offset: 0x00002773
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x0000457B File Offset: 0x0000277B
		public USBState USBState { get; set; }
	}
}
