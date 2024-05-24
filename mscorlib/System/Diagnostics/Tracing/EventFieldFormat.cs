using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000443 RID: 1091
	[__DynamicallyInvokable]
	public enum EventFieldFormat
	{
		// Token: 0x04001821 RID: 6177
		[__DynamicallyInvokable]
		Default,
		// Token: 0x04001822 RID: 6178
		[__DynamicallyInvokable]
		String = 2,
		// Token: 0x04001823 RID: 6179
		[__DynamicallyInvokable]
		Boolean,
		// Token: 0x04001824 RID: 6180
		[__DynamicallyInvokable]
		Hexadecimal,
		// Token: 0x04001825 RID: 6181
		[__DynamicallyInvokable]
		Xml = 11,
		// Token: 0x04001826 RID: 6182
		[__DynamicallyInvokable]
		Json,
		// Token: 0x04001827 RID: 6183
		[__DynamicallyInvokable]
		HResult = 15
	}
}
