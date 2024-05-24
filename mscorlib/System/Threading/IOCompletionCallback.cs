using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000524 RID: 1316
	// (Invoke) Token: 0x06003DED RID: 15853
	[SecurityCritical]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public unsafe delegate void IOCompletionCallback(uint errorCode, uint numBytes, NativeOverlapped* pOVERLAP);
}
