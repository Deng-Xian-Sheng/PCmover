using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography
{
	// Token: 0x0200028D RID: 653
	[SecurityCritical]
	internal sealed class SafeProvHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x0600233F RID: 9023 RVA: 0x0008017A File Offset: 0x0007E37A
		private SafeProvHandle() : base(true)
		{
			base.SetHandle(IntPtr.Zero);
		}

		// Token: 0x06002340 RID: 9024 RVA: 0x0008018E File Offset: 0x0007E38E
		private SafeProvHandle(IntPtr handle) : base(true)
		{
			base.SetHandle(handle);
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06002341 RID: 9025 RVA: 0x0008019E File Offset: 0x0007E39E
		internal static SafeProvHandle InvalidHandle
		{
			get
			{
				return new SafeProvHandle();
			}
		}

		// Token: 0x06002342 RID: 9026
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void FreeCsp(IntPtr pProviderContext);

		// Token: 0x06002343 RID: 9027 RVA: 0x000801A5 File Offset: 0x0007E3A5
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			SafeProvHandle.FreeCsp(this.handle);
			return true;
		}
	}
}
