using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008E5 RID: 2277
	[ComVisible(false)]
	internal struct DependentHandle
	{
		// Token: 0x06005DF2 RID: 24050 RVA: 0x0014A418 File Offset: 0x00148618
		[SecurityCritical]
		public DependentHandle(object primary, object secondary)
		{
			IntPtr handle = (IntPtr)0;
			DependentHandle.nInitialize(primary, secondary, out handle);
			this._handle = handle;
		}

		// Token: 0x17001024 RID: 4132
		// (get) Token: 0x06005DF3 RID: 24051 RVA: 0x0014A43C File Offset: 0x0014863C
		public bool IsAllocated
		{
			get
			{
				return this._handle != (IntPtr)0;
			}
		}

		// Token: 0x06005DF4 RID: 24052 RVA: 0x0014A450 File Offset: 0x00148650
		[SecurityCritical]
		public object GetPrimary()
		{
			object result;
			DependentHandle.nGetPrimary(this._handle, out result);
			return result;
		}

		// Token: 0x06005DF5 RID: 24053 RVA: 0x0014A46B File Offset: 0x0014866B
		[SecurityCritical]
		public void GetPrimaryAndSecondary(out object primary, out object secondary)
		{
			DependentHandle.nGetPrimaryAndSecondary(this._handle, out primary, out secondary);
		}

		// Token: 0x06005DF6 RID: 24054 RVA: 0x0014A47C File Offset: 0x0014867C
		[SecurityCritical]
		public void Free()
		{
			if (this._handle != (IntPtr)0)
			{
				IntPtr handle = this._handle;
				this._handle = (IntPtr)0;
				DependentHandle.nFree(handle);
			}
		}

		// Token: 0x06005DF7 RID: 24055
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void nInitialize(object primary, object secondary, out IntPtr dependentHandle);

		// Token: 0x06005DF8 RID: 24056
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void nGetPrimary(IntPtr dependentHandle, out object primary);

		// Token: 0x06005DF9 RID: 24057
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void nGetPrimaryAndSecondary(IntPtr dependentHandle, out object primary, out object secondary);

		// Token: 0x06005DFA RID: 24058
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void nFree(IntPtr dependentHandle);

		// Token: 0x04002A3D RID: 10813
		private IntPtr _handle;
	}
}
