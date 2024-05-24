using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000700 RID: 1792
	[StructLayout(LayoutKind.Sequential)]
	internal class AssemblyRequestEntry
	{
		// Token: 0x04002387 RID: 9095
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		// Token: 0x04002388 RID: 9096
		[MarshalAs(UnmanagedType.LPWStr)]
		public string permissionSetID;
	}
}
