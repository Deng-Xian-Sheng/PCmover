using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000709 RID: 1801
	[StructLayout(LayoutKind.Sequential)]
	internal class DependentOSMetadataEntry
	{
		// Token: 0x040023A3 RID: 9123
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SupportUrl;

		// Token: 0x040023A4 RID: 9124
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Description;

		// Token: 0x040023A5 RID: 9125
		public ushort MajorVersion;

		// Token: 0x040023A6 RID: 9126
		public ushort MinorVersion;

		// Token: 0x040023A7 RID: 9127
		public ushort BuildNumber;

		// Token: 0x040023A8 RID: 9128
		public byte ServicePackMajor;

		// Token: 0x040023A9 RID: 9129
		public byte ServicePackMinor;
	}
}
