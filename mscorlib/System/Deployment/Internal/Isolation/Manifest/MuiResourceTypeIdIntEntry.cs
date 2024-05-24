using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006CD RID: 1741
	[StructLayout(LayoutKind.Sequential)]
	internal class MuiResourceTypeIdIntEntry : IDisposable
	{
		// Token: 0x0600505A RID: 20570 RVA: 0x0011D9A4 File Offset: 0x0011BBA4
		~MuiResourceTypeIdIntEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x0600505B RID: 20571 RVA: 0x0011D9D4 File Offset: 0x0011BBD4
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x0600505C RID: 20572 RVA: 0x0011D9E0 File Offset: 0x0011BBE0
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

		// Token: 0x040022E0 RID: 8928
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr StringIds;

		// Token: 0x040022E1 RID: 8929
		public uint StringIdsSize;

		// Token: 0x040022E2 RID: 8930
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr IntegerIds;

		// Token: 0x040022E3 RID: 8931
		public uint IntegerIdsSize;
	}
}
