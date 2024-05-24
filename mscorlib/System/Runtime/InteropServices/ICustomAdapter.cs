using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000963 RID: 2403
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface ICustomAdapter
	{
		// Token: 0x06006220 RID: 25120
		[__DynamicallyInvokable]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetUnderlyingObject();
	}
}
