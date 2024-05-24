using System;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000436 RID: 1078
	[FriendAccessAllowed]
	[__DynamicallyInvokable]
	public enum EventOpcode
	{
		// Token: 0x040017EA RID: 6122
		[__DynamicallyInvokable]
		Info,
		// Token: 0x040017EB RID: 6123
		[__DynamicallyInvokable]
		Start,
		// Token: 0x040017EC RID: 6124
		[__DynamicallyInvokable]
		Stop,
		// Token: 0x040017ED RID: 6125
		[__DynamicallyInvokable]
		DataCollectionStart,
		// Token: 0x040017EE RID: 6126
		[__DynamicallyInvokable]
		DataCollectionStop,
		// Token: 0x040017EF RID: 6127
		[__DynamicallyInvokable]
		Extension,
		// Token: 0x040017F0 RID: 6128
		[__DynamicallyInvokable]
		Reply,
		// Token: 0x040017F1 RID: 6129
		[__DynamicallyInvokable]
		Resume,
		// Token: 0x040017F2 RID: 6130
		[__DynamicallyInvokable]
		Suspend,
		// Token: 0x040017F3 RID: 6131
		[__DynamicallyInvokable]
		Send,
		// Token: 0x040017F4 RID: 6132
		[__DynamicallyInvokable]
		Receive = 240
	}
}
