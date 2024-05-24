using System;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000966 RID: 2406
	[ComVisible(false)]
	[__DynamicallyInvokable]
	public interface ICustomQueryInterface
	{
		// Token: 0x06006222 RID: 25122
		[SecurityCritical]
		CustomQueryInterfaceResult GetInterface([In] ref Guid iid, out IntPtr ppv);
	}
}
