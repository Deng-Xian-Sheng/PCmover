using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D6 RID: 1750
	[StructLayout(LayoutKind.Sequential)]
	internal class FileEntry : IDisposable
	{
		// Token: 0x06005073 RID: 20595 RVA: 0x0011DBA8 File Offset: 0x0011BDA8
		~FileEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x06005074 RID: 20596 RVA: 0x0011DBD8 File Offset: 0x0011BDD8
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06005075 RID: 20597 RVA: 0x0011DBE4 File Offset: 0x0011BDE4
		[SecuritySafeCritical]
		public void Dispose(bool fDisposing)
		{
			if (this.HashValue != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.HashValue);
				this.HashValue = IntPtr.Zero;
			}
			if (fDisposing)
			{
				if (this.MuiMapping != null)
				{
					this.MuiMapping.Dispose(true);
					this.MuiMapping = null;
				}
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x04002302 RID: 8962
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		// Token: 0x04002303 RID: 8963
		public uint HashAlgorithm;

		// Token: 0x04002304 RID: 8964
		[MarshalAs(UnmanagedType.LPWStr)]
		public string LoadFrom;

		// Token: 0x04002305 RID: 8965
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SourcePath;

		// Token: 0x04002306 RID: 8966
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ImportPath;

		// Token: 0x04002307 RID: 8967
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SourceName;

		// Token: 0x04002308 RID: 8968
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Location;

		// Token: 0x04002309 RID: 8969
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr HashValue;

		// Token: 0x0400230A RID: 8970
		public uint HashValueSize;

		// Token: 0x0400230B RID: 8971
		public ulong Size;

		// Token: 0x0400230C RID: 8972
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Group;

		// Token: 0x0400230D RID: 8973
		public uint Flags;

		// Token: 0x0400230E RID: 8974
		public MuiResourceMapEntry MuiMapping;

		// Token: 0x0400230F RID: 8975
		public uint WritableType;

		// Token: 0x04002310 RID: 8976
		public ISection HashElements;
	}
}
