using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006E5 RID: 1765
	[StructLayout(LayoutKind.Sequential)]
	internal class COMServerEntry
	{
		// Token: 0x04002338 RID: 9016
		public Guid Clsid;

		// Token: 0x04002339 RID: 9017
		public uint Flags;

		// Token: 0x0400233A RID: 9018
		public Guid ConfiguredGuid;

		// Token: 0x0400233B RID: 9019
		public Guid ImplementedClsid;

		// Token: 0x0400233C RID: 9020
		public Guid TypeLibrary;

		// Token: 0x0400233D RID: 9021
		public uint ThreadingModel;

		// Token: 0x0400233E RID: 9022
		[MarshalAs(UnmanagedType.LPWStr)]
		public string RuntimeVersion;

		// Token: 0x0400233F RID: 9023
		[MarshalAs(UnmanagedType.LPWStr)]
		public string HostFile;
	}
}
