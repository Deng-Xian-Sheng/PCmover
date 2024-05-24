using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000619 RID: 1561
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum PropertyAttributes
	{
		// Token: 0x04001DFC RID: 7676
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001DFD RID: 7677
		[__DynamicallyInvokable]
		SpecialName = 512,
		// Token: 0x04001DFE RID: 7678
		ReservedMask = 62464,
		// Token: 0x04001DFF RID: 7679
		[__DynamicallyInvokable]
		RTSpecialName = 1024,
		// Token: 0x04001E00 RID: 7680
		[__DynamicallyInvokable]
		HasDefault = 4096,
		// Token: 0x04001E01 RID: 7681
		Reserved2 = 8192,
		// Token: 0x04001E02 RID: 7682
		Reserved3 = 16384,
		// Token: 0x04001E03 RID: 7683
		Reserved4 = 32768
	}
}
