using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006FA RID: 1786
	[StructLayout(LayoutKind.Sequential)]
	internal class EntryPointEntry
	{
		// Token: 0x04002379 RID: 9081
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		// Token: 0x0400237A RID: 9082
		[MarshalAs(UnmanagedType.LPWStr)]
		public string CommandLine_File;

		// Token: 0x0400237B RID: 9083
		[MarshalAs(UnmanagedType.LPWStr)]
		public string CommandLine_Parameters;

		// Token: 0x0400237C RID: 9084
		public IReferenceIdentity Identity;

		// Token: 0x0400237D RID: 9085
		public uint Flags;
	}
}
