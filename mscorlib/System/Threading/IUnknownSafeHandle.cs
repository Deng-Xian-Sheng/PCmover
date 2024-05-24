using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004FB RID: 1275
	[SecurityCritical]
	internal class IUnknownSafeHandle : SafeHandle
	{
		// Token: 0x06003C3F RID: 15423 RVA: 0x000E3F26 File Offset: 0x000E2126
		public IUnknownSafeHandle() : base(IntPtr.Zero, true)
		{
		}

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x06003C40 RID: 15424 RVA: 0x000E3F34 File Offset: 0x000E2134
		public override bool IsInvalid
		{
			[SecurityCritical]
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}

		// Token: 0x06003C41 RID: 15425 RVA: 0x000E3F46 File Offset: 0x000E2146
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			HostExecutionContextManager.ReleaseHostSecurityContext(this.handle);
			return true;
		}

		// Token: 0x06003C42 RID: 15426 RVA: 0x000E3F58 File Offset: 0x000E2158
		internal object Clone()
		{
			IUnknownSafeHandle unknownSafeHandle = new IUnknownSafeHandle();
			if (!this.IsInvalid)
			{
				HostExecutionContextManager.CloneHostSecurityContext(this, unknownSafeHandle);
			}
			return unknownSafeHandle;
		}
	}
}
