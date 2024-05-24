using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200007A RID: 122
	[Flags]
	public enum ConnectionPolicyMethods
	{
		// Token: 0x040002E5 RID: 741
		None = 0,
		// Token: 0x040002E6 RID: 742
		Network = 1,
		// Token: 0x040002E7 RID: 743
		Udp = 2,
		// Token: 0x040002E8 RID: 744
		TcpOrUdp = 3,
		// Token: 0x040002E9 RID: 745
		Usb = 4,
		// Token: 0x040002EA RID: 746
		File = 8,
		// Token: 0x040002EB RID: 747
		Image = 16,
		// Token: 0x040002EC RID: 748
		Self = 32,
		// Token: 0x040002ED RID: 749
		All = 63
	}
}
