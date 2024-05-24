using System;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000037 RID: 55
	[Flags]
	public enum ConnectivityStates
	{
		// Token: 0x04000208 RID: 520
		None = 0,
		// Token: 0x04000209 RID: 521
		IPv4Internet = 64,
		// Token: 0x0400020A RID: 522
		IPv4LocalNetwork = 32,
		// Token: 0x0400020B RID: 523
		IPv4NoTraffic = 1,
		// Token: 0x0400020C RID: 524
		IPv4Subnet = 16,
		// Token: 0x0400020D RID: 525
		IPv6Internet = 1024,
		// Token: 0x0400020E RID: 526
		IPv6LocalNetwork = 512,
		// Token: 0x0400020F RID: 527
		IPv6NoTraffic = 2,
		// Token: 0x04000210 RID: 528
		IPv6Subnet = 256
	}
}
