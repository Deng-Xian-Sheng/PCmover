using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002BF RID: 703
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	internal sealed class SafeBCryptAlgorithmHandle : SafeHandle
	{
		// Token: 0x0600250A RID: 9482
		[SecurityCritical]
		[DllImport("bcrypt.dll")]
		private static extern int BCryptCloseAlgorithmProvider([In] IntPtr hAlgorithm, [In] uint dwFlags);

		// Token: 0x0600250B RID: 9483 RVA: 0x00086DC6 File Offset: 0x00084FC6
		[SecurityCritical]
		public SafeBCryptAlgorithmHandle() : base(IntPtr.Zero, true)
		{
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x0600250C RID: 9484 RVA: 0x00086DD4 File Offset: 0x00084FD4
		public override bool IsInvalid
		{
			[SecurityCritical]
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x00086DE8 File Offset: 0x00084FE8
		[SecurityCritical]
		protected sealed override bool ReleaseHandle()
		{
			int num = SafeBCryptAlgorithmHandle.BCryptCloseAlgorithmProvider(this.handle, 0U);
			return num == 0;
		}
	}
}
