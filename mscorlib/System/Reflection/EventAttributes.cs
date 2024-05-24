using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005E0 RID: 1504
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum EventAttributes
	{
		// Token: 0x04001C8E RID: 7310
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001C8F RID: 7311
		[__DynamicallyInvokable]
		SpecialName = 512,
		// Token: 0x04001C90 RID: 7312
		ReservedMask = 1024,
		// Token: 0x04001C91 RID: 7313
		[__DynamicallyInvokable]
		RTSpecialName = 1024
	}
}
