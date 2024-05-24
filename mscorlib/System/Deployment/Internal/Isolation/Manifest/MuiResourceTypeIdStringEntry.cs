using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006CA RID: 1738
	[StructLayout(LayoutKind.Sequential)]
	internal class MuiResourceTypeIdStringEntry : IDisposable
	{
		// Token: 0x06005053 RID: 20563 RVA: 0x0011D8F8 File Offset: 0x0011BAF8
		~MuiResourceTypeIdStringEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x06005054 RID: 20564 RVA: 0x0011D928 File Offset: 0x0011BB28
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06005055 RID: 20565 RVA: 0x0011D934 File Offset: 0x0011BB34
		[SecuritySafeCritical]
		public void Dispose(bool fDisposing)
		{
			if (this.StringIds != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.StringIds);
				this.StringIds = IntPtr.Zero;
			}
			if (this.IntegerIds != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.IntegerIds);
				this.IntegerIds = IntPtr.Zero;
			}
			if (fDisposing)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x040022D7 RID: 8919
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr StringIds;

		// Token: 0x040022D8 RID: 8920
		public uint StringIdsSize;

		// Token: 0x040022D9 RID: 8921
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr IntegerIds;

		// Token: 0x040022DA RID: 8922
		public uint IntegerIdsSize;
	}
}
