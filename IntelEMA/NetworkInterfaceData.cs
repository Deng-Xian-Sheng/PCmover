using System;

namespace IntelEMA
{
	// Token: 0x02000009 RID: 9
	public class NetworkInterfaceData
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000022FB File Offset: 0x000004FB
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002303 File Offset: 0x00000503
		public string IPv4Address { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000230C File Offset: 0x0000050C
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002314 File Offset: 0x00000514
		public string IPv6Address { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000231D File Offset: 0x0000051D
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002325 File Offset: 0x00000525
		public string Subnet { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000041 RID: 65 RVA: 0x0000232E File Offset: 0x0000052E
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002336 File Offset: 0x00000536
		public string Gateway { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000233F File Offset: 0x0000053F
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002347 File Offset: 0x00000547
		public string DnsSuffix { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002350 File Offset: 0x00000550
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002358 File Offset: 0x00000558
		public string Mac { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002361 File Offset: 0x00000561
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002369 File Offset: 0x00000569
		public string GatewayMac { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002372 File Offset: 0x00000572
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000237A File Offset: 0x0000057A
		public string Description { get; set; }
	}
}
