using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006E2 RID: 1762
	[StructLayout(LayoutKind.Sequential)]
	internal class CategoryMembershipEntry
	{
		// Token: 0x04002334 RID: 9012
		public IDefinitionIdentity Identity;

		// Token: 0x04002335 RID: 9013
		public ISection SubcategoryMembership;
	}
}
