using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x0200070C RID: 1804
	[StructLayout(LayoutKind.Sequential)]
	internal class CompatibleFrameworksMetadataEntry
	{
		// Token: 0x040023B2 RID: 9138
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SupportUrl;
	}
}
