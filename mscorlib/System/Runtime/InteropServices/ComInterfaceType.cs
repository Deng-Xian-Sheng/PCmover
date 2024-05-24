using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000912 RID: 2322
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ComInterfaceType
	{
		// Token: 0x04002A5F RID: 10847
		[__DynamicallyInvokable]
		InterfaceIsDual,
		// Token: 0x04002A60 RID: 10848
		[__DynamicallyInvokable]
		InterfaceIsIUnknown,
		// Token: 0x04002A61 RID: 10849
		[__DynamicallyInvokable]
		InterfaceIsIDispatch,
		// Token: 0x04002A62 RID: 10850
		[ComVisible(false)]
		[__DynamicallyInvokable]
		InterfaceIsIInspectable
	}
}
