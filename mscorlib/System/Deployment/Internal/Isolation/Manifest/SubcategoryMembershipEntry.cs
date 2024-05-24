using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006DF RID: 1759
	[StructLayout(LayoutKind.Sequential)]
	internal class SubcategoryMembershipEntry
	{
		// Token: 0x04002330 RID: 9008
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Subcategory;

		// Token: 0x04002331 RID: 9009
		public ISection CategoryMembershipData;
	}
}
