using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006F7 RID: 1783
	[StructLayout(LayoutKind.Sequential)]
	internal class ResourceTableMappingEntry
	{
		// Token: 0x04002375 RID: 9077
		[MarshalAs(UnmanagedType.LPWStr)]
		public string id;

		// Token: 0x04002376 RID: 9078
		[MarshalAs(UnmanagedType.LPWStr)]
		public string FinalStringMapped;
	}
}
