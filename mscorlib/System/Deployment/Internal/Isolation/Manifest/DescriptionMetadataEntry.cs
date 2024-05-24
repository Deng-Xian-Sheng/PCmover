using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000703 RID: 1795
	[StructLayout(LayoutKind.Sequential)]
	internal class DescriptionMetadataEntry
	{
		// Token: 0x0400238B RID: 9099
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Publisher;

		// Token: 0x0400238C RID: 9100
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Product;

		// Token: 0x0400238D RID: 9101
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SupportUrl;

		// Token: 0x0400238E RID: 9102
		[MarshalAs(UnmanagedType.LPWStr)]
		public string IconFile;

		// Token: 0x0400238F RID: 9103
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ErrorReportUrl;

		// Token: 0x04002390 RID: 9104
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SuiteName;
	}
}
