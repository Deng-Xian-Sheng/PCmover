using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography
{
	// Token: 0x0200028E RID: 654
	[SecurityCritical]
	internal sealed class SafeKeyHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x06002344 RID: 9028 RVA: 0x000801B3 File Offset: 0x0007E3B3
		private SafeKeyHandle() : base(true)
		{
			base.SetHandle(IntPtr.Zero);
		}

		// Token: 0x06002345 RID: 9029 RVA: 0x000801C7 File Offset: 0x0007E3C7
		private SafeKeyHandle(IntPtr handle) : base(true)
		{
			base.SetHandle(handle);
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06002346 RID: 9030 RVA: 0x000801D7 File Offset: 0x0007E3D7
		internal static SafeKeyHandle InvalidHandle
		{
			get
			{
				return new SafeKeyHandle();
			}
		}

		// Token: 0x06002347 RID: 9031
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void FreeKey(IntPtr pKeyCotext);

		// Token: 0x06002348 RID: 9032 RVA: 0x000801DE File Offset: 0x0007E3DE
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			SafeKeyHandle.FreeKey(this.handle);
			return true;
		}
	}
}
