using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000674 RID: 1652
	internal struct IDENTITY_ATTRIBUTE
	{
		// Token: 0x040021DA RID: 8666
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Namespace;

		// Token: 0x040021DB RID: 8667
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		// Token: 0x040021DC RID: 8668
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Value;
	}
}
