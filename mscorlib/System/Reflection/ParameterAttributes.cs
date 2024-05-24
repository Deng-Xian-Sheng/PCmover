using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000614 RID: 1556
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ParameterAttributes
	{
		// Token: 0x04001DDA RID: 7642
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001DDB RID: 7643
		[__DynamicallyInvokable]
		In = 1,
		// Token: 0x04001DDC RID: 7644
		[__DynamicallyInvokable]
		Out = 2,
		// Token: 0x04001DDD RID: 7645
		[__DynamicallyInvokable]
		Lcid = 4,
		// Token: 0x04001DDE RID: 7646
		[__DynamicallyInvokable]
		Retval = 8,
		// Token: 0x04001DDF RID: 7647
		[__DynamicallyInvokable]
		Optional = 16,
		// Token: 0x04001DE0 RID: 7648
		ReservedMask = 61440,
		// Token: 0x04001DE1 RID: 7649
		[__DynamicallyInvokable]
		HasDefault = 4096,
		// Token: 0x04001DE2 RID: 7650
		[__DynamicallyInvokable]
		HasFieldMarshal = 8192,
		// Token: 0x04001DE3 RID: 7651
		Reserved3 = 16384,
		// Token: 0x04001DE4 RID: 7652
		Reserved4 = 32768
	}
}
