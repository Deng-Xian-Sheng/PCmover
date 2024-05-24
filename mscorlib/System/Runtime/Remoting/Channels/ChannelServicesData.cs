using System;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200082A RID: 2090
	internal class ChannelServicesData
	{
		// Token: 0x040028C7 RID: 10439
		internal long remoteCalls;

		// Token: 0x040028C8 RID: 10440
		internal CrossContextChannel xctxmessageSink;

		// Token: 0x040028C9 RID: 10441
		internal CrossAppDomainChannel xadmessageSink;

		// Token: 0x040028CA RID: 10442
		internal bool fRegisterWellKnownChannels;
	}
}
