using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography
{
	// Token: 0x0200028F RID: 655
	[SecurityCritical]
	internal sealed class SafeHashHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x06002349 RID: 9033 RVA: 0x000801EC File Offset: 0x0007E3EC
		private SafeHashHandle() : base(true)
		{
			base.SetHandle(IntPtr.Zero);
		}

		// Token: 0x0600234A RID: 9034 RVA: 0x00080200 File Offset: 0x0007E400
		private SafeHashHandle(IntPtr handle) : base(true)
		{
			base.SetHandle(handle);
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x0600234B RID: 9035 RVA: 0x00080210 File Offset: 0x0007E410
		internal static SafeHashHandle InvalidHandle
		{
			get
			{
				return new SafeHashHandle();
			}
		}

		// Token: 0x0600234C RID: 9036
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void FreeHash(IntPtr pHashContext);

		// Token: 0x0600234D RID: 9037 RVA: 0x00080217 File Offset: 0x0007E417
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			SafeHashHandle.FreeHash(this.handle);
			return true;
		}
	}
}
