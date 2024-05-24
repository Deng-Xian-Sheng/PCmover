using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006FD RID: 1789
	[StructLayout(LayoutKind.Sequential)]
	internal class PermissionSetEntry
	{
		// Token: 0x04002383 RID: 9091
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Id;

		// Token: 0x04002384 RID: 9092
		[MarshalAs(UnmanagedType.LPWStr)]
		public string XmlSegment;
	}
}
