using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A0C RID: 2572
	[Flags]
	internal enum InterfaceForwardingSupport
	{
		// Token: 0x04002D34 RID: 11572
		None = 0,
		// Token: 0x04002D35 RID: 11573
		IBindableVector = 1,
		// Token: 0x04002D36 RID: 11574
		IVector = 2,
		// Token: 0x04002D37 RID: 11575
		IBindableVectorView = 4,
		// Token: 0x04002D38 RID: 11576
		IVectorView = 8,
		// Token: 0x04002D39 RID: 11577
		IBindableIterableOrIIterable = 16
	}
}
