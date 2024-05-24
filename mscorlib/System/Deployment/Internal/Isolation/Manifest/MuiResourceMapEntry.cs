using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D0 RID: 1744
	[StructLayout(LayoutKind.Sequential)]
	internal class MuiResourceMapEntry : IDisposable
	{
		// Token: 0x06005061 RID: 20577 RVA: 0x0011DA50 File Offset: 0x0011BC50
		~MuiResourceMapEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x06005062 RID: 20578 RVA: 0x0011DA80 File Offset: 0x0011BC80
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06005063 RID: 20579 RVA: 0x0011DA8C File Offset: 0x0011BC8C
		[SecuritySafeCritical]
		public void Dispose(bool fDisposing)
		{
			if (this.ResourceTypeIdInt != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.ResourceTypeIdInt);
				this.ResourceTypeIdInt = IntPtr.Zero;
			}
			if (this.ResourceTypeIdString != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.ResourceTypeIdString);
				this.ResourceTypeIdString = IntPtr.Zero;
			}
			if (fDisposing)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x040022E9 RID: 8937
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr ResourceTypeIdInt;

		// Token: 0x040022EA RID: 8938
		public uint ResourceTypeIdIntSize;

		// Token: 0x040022EB RID: 8939
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr ResourceTypeIdString;

		// Token: 0x040022EC RID: 8940
		public uint ResourceTypeIdStringSize;
	}
}
