using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000706 RID: 1798
	[StructLayout(LayoutKind.Sequential)]
	internal class DeploymentMetadataEntry
	{
		// Token: 0x04002398 RID: 9112
		[MarshalAs(UnmanagedType.LPWStr)]
		public string DeploymentProviderCodebase;

		// Token: 0x04002399 RID: 9113
		[MarshalAs(UnmanagedType.LPWStr)]
		public string MinimumRequiredVersion;

		// Token: 0x0400239A RID: 9114
		public ushort MaximumAge;

		// Token: 0x0400239B RID: 9115
		public byte MaximumAge_Unit;

		// Token: 0x0400239C RID: 9116
		public uint DeploymentFlags;
	}
}
