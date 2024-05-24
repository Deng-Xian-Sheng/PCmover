using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006E8 RID: 1768
	[StructLayout(LayoutKind.Sequential)]
	internal class ProgIdRedirectionEntry
	{
		// Token: 0x04002348 RID: 9032
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ProgId;

		// Token: 0x04002349 RID: 9033
		public Guid RedirectedGuid;
	}
}
