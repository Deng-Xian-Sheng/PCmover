using System;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
	// Token: 0x02000533 RID: 1331
	[__DynamicallyInvokable]
	public static class WaitHandleExtensions
	{
		// Token: 0x06003EA0 RID: 16032 RVA: 0x000E91B0 File Offset: 0x000E73B0
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static SafeWaitHandle GetSafeWaitHandle(this WaitHandle waitHandle)
		{
			if (waitHandle == null)
			{
				throw new ArgumentNullException("waitHandle");
			}
			return waitHandle.SafeWaitHandle;
		}

		// Token: 0x06003EA1 RID: 16033 RVA: 0x000E91C6 File Offset: 0x000E73C6
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void SetSafeWaitHandle(this WaitHandle waitHandle, SafeWaitHandle value)
		{
			if (waitHandle == null)
			{
				throw new ArgumentNullException("waitHandle");
			}
			waitHandle.SafeWaitHandle = value;
		}
	}
}
