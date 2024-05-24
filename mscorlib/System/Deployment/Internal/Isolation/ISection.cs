using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200066D RID: 1645
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("285a8862-c84a-11d7-850f-005cd062464f")]
	[ComImport]
	internal interface ISection
	{
		// Token: 0x17000C96 RID: 3222
		// (get) Token: 0x06004F17 RID: 20247
		object _NewEnum { [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000C97 RID: 3223
		// (get) Token: 0x06004F18 RID: 20248
		uint Count { get; }

		// Token: 0x17000C98 RID: 3224
		// (get) Token: 0x06004F19 RID: 20249
		uint SectionID { get; }

		// Token: 0x17000C99 RID: 3225
		// (get) Token: 0x06004F1A RID: 20250
		string SectionName { [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
