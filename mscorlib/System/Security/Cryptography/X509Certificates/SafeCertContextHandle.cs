using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002A6 RID: 678
	[SecurityCritical]
	internal sealed class SafeCertContextHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x060023FC RID: 9212 RVA: 0x000822DE File Offset: 0x000804DE
		private SafeCertContextHandle() : base(true)
		{
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x000822E7 File Offset: 0x000804E7
		internal SafeCertContextHandle(IntPtr handle) : base(true)
		{
			base.SetHandle(handle);
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x060023FE RID: 9214 RVA: 0x000822F8 File Offset: 0x000804F8
		internal static SafeCertContextHandle InvalidHandle
		{
			get
			{
				SafeCertContextHandle safeCertContextHandle = new SafeCertContextHandle(IntPtr.Zero);
				GC.SuppressFinalize(safeCertContextHandle);
				return safeCertContextHandle;
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x060023FF RID: 9215 RVA: 0x00082317 File Offset: 0x00080517
		internal IntPtr pCertContext
		{
			get
			{
				if (this.handle == IntPtr.Zero)
				{
					return IntPtr.Zero;
				}
				return Marshal.ReadIntPtr(this.handle);
			}
		}

		// Token: 0x06002400 RID: 9216
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _FreePCertContext(IntPtr pCert);

		// Token: 0x06002401 RID: 9217 RVA: 0x0008233C File Offset: 0x0008053C
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			SafeCertContextHandle._FreePCertContext(this.handle);
			return true;
		}
	}
}
