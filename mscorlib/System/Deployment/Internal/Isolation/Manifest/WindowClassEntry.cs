using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006F4 RID: 1780
	[StructLayout(LayoutKind.Sequential)]
	internal class WindowClassEntry
	{
		// Token: 0x0400236F RID: 9071
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ClassName;

		// Token: 0x04002370 RID: 9072
		[MarshalAs(UnmanagedType.LPWStr)]
		public string HostDll;

		// Token: 0x04002371 RID: 9073
		public bool fVersioned;
	}
}
