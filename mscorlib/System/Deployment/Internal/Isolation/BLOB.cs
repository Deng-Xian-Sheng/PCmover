using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000673 RID: 1651
	internal struct BLOB : IDisposable
	{
		// Token: 0x06004F29 RID: 20265 RVA: 0x0011C2CF File Offset: 0x0011A4CF
		[SecuritySafeCritical]
		public void Dispose()
		{
			if (this.BlobData != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.BlobData);
				this.BlobData = IntPtr.Zero;
			}
		}

		// Token: 0x040021D8 RID: 8664
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x040021D9 RID: 8665
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr BlobData;
	}
}
