using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D9 RID: 1753
	[StructLayout(LayoutKind.Sequential)]
	internal class FileAssociationEntry
	{
		// Token: 0x04002320 RID: 8992
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Extension;

		// Token: 0x04002321 RID: 8993
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Description;

		// Token: 0x04002322 RID: 8994
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ProgID;

		// Token: 0x04002323 RID: 8995
		[MarshalAs(UnmanagedType.LPWStr)]
		public string DefaultIcon;

		// Token: 0x04002324 RID: 8996
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Parameter;
	}
}
