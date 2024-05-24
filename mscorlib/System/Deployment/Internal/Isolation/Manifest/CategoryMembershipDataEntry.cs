using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006DC RID: 1756
	[StructLayout(LayoutKind.Sequential)]
	internal class CategoryMembershipDataEntry
	{
		// Token: 0x0400232A RID: 9002
		public uint index;

		// Token: 0x0400232B RID: 9003
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Xml;

		// Token: 0x0400232C RID: 9004
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Description;
	}
}
