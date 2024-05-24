using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x0200051D RID: 1309
	[ComVisible(true)]
	public sealed class RegisteredWaitHandle : MarshalByRefObject
	{
		// Token: 0x06003DD1 RID: 15825 RVA: 0x000E73FC File Offset: 0x000E55FC
		internal RegisteredWaitHandle()
		{
			this.internalRegisteredWait = new RegisteredWaitHandleSafe();
		}

		// Token: 0x06003DD2 RID: 15826 RVA: 0x000E740F File Offset: 0x000E560F
		internal void SetHandle(IntPtr handle)
		{
			this.internalRegisteredWait.SetHandle(handle);
		}

		// Token: 0x06003DD3 RID: 15827 RVA: 0x000E741D File Offset: 0x000E561D
		[SecurityCritical]
		internal void SetWaitObject(WaitHandle waitObject)
		{
			this.internalRegisteredWait.SetWaitObject(waitObject);
		}

		// Token: 0x06003DD4 RID: 15828 RVA: 0x000E742B File Offset: 0x000E562B
		[SecuritySafeCritical]
		[ComVisible(true)]
		public bool Unregister(WaitHandle waitObject)
		{
			return this.internalRegisteredWait.Unregister(waitObject);
		}

		// Token: 0x04001A0C RID: 6668
		private RegisteredWaitHandleSafe internalRegisteredWait;
	}
}
