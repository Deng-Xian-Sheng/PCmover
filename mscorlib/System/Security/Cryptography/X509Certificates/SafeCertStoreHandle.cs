using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002A7 RID: 679
	[SecurityCritical]
	internal sealed class SafeCertStoreHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x06002402 RID: 9218 RVA: 0x0008234A File Offset: 0x0008054A
		private SafeCertStoreHandle() : base(true)
		{
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x00082353 File Offset: 0x00080553
		internal SafeCertStoreHandle(IntPtr handle) : base(true)
		{
			base.SetHandle(handle);
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06002404 RID: 9220 RVA: 0x00082364 File Offset: 0x00080564
		internal static SafeCertStoreHandle InvalidHandle
		{
			get
			{
				SafeCertStoreHandle safeCertStoreHandle = new SafeCertStoreHandle(IntPtr.Zero);
				GC.SuppressFinalize(safeCertStoreHandle);
				return safeCertStoreHandle;
			}
		}

		// Token: 0x06002405 RID: 9221
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _FreeCertStoreContext(IntPtr hCertStore);

		// Token: 0x06002406 RID: 9222 RVA: 0x00082383 File Offset: 0x00080583
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			SafeCertStoreHandle._FreeCertStoreContext(this.handle);
			return true;
		}
	}
}
