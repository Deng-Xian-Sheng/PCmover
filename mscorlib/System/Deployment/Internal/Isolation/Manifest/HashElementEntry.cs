using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D3 RID: 1747
	[StructLayout(LayoutKind.Sequential)]
	internal class HashElementEntry : IDisposable
	{
		// Token: 0x06005068 RID: 20584 RVA: 0x0011DAFC File Offset: 0x0011BCFC
		~HashElementEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x06005069 RID: 20585 RVA: 0x0011DB2C File Offset: 0x0011BD2C
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x0600506A RID: 20586 RVA: 0x0011DB38 File Offset: 0x0011BD38
		[SecuritySafeCritical]
		public void Dispose(bool fDisposing)
		{
			if (this.TransformMetadata != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.TransformMetadata);
				this.TransformMetadata = IntPtr.Zero;
			}
			if (this.DigestValue != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.DigestValue);
				this.DigestValue = IntPtr.Zero;
			}
			if (fDisposing)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x040022F2 RID: 8946
		public uint index;

		// Token: 0x040022F3 RID: 8947
		public byte Transform;

		// Token: 0x040022F4 RID: 8948
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr TransformMetadata;

		// Token: 0x040022F5 RID: 8949
		public uint TransformMetadataSize;

		// Token: 0x040022F6 RID: 8950
		public byte DigestMethod;

		// Token: 0x040022F7 RID: 8951
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr DigestValue;

		// Token: 0x040022F8 RID: 8952
		public uint DigestValueSize;

		// Token: 0x040022F9 RID: 8953
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Xml;
	}
}
