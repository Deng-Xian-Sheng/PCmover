using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006EE RID: 1774
	[StructLayout(LayoutKind.Sequential)]
	internal class AssemblyReferenceDependentAssemblyEntry : IDisposable
	{
		// Token: 0x060050AD RID: 20653 RVA: 0x0011DC80 File Offset: 0x0011BE80
		~AssemblyReferenceDependentAssemblyEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x060050AE RID: 20654 RVA: 0x0011DCB0 File Offset: 0x0011BEB0
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060050AF RID: 20655 RVA: 0x0011DCB9 File Offset: 0x0011BEB9
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
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x04002352 RID: 9042
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Group;

		// Token: 0x04002353 RID: 9043
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Codebase;

		// Token: 0x04002354 RID: 9044
		public ulong Size;

		// Token: 0x04002355 RID: 9045
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr HashValue;

		// Token: 0x04002356 RID: 9046
		public uint HashValueSize;

		// Token: 0x04002357 RID: 9047
		public uint HashAlgorithm;

		// Token: 0x04002358 RID: 9048
		public uint Flags;

		// Token: 0x04002359 RID: 9049
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ResourceFallbackCulture;

		// Token: 0x0400235A RID: 9050
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Description;

		// Token: 0x0400235B RID: 9051
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SupportUrl;

		// Token: 0x0400235C RID: 9052
		public ISection HashElements;
	}
}
