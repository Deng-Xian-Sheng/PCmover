using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005F0 RID: 1520
	internal sealed class LoaderAllocatorScout
	{
		// Token: 0x0600466B RID: 18027
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern bool Destroy(IntPtr nativeLoaderAllocator);

		// Token: 0x0600466C RID: 18028 RVA: 0x001025FC File Offset: 0x001007FC
		[SecuritySafeCritical]
		~LoaderAllocatorScout()
		{
			if (!this.m_nativeLoaderAllocator.IsNull())
			{
				if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload() && !LoaderAllocatorScout.Destroy(this.m_nativeLoaderAllocator))
				{
					GC.ReRegisterForFinalize(this);
				}
			}
		}

		// Token: 0x04001CCC RID: 7372
		internal IntPtr m_nativeLoaderAllocator;
	}
}
