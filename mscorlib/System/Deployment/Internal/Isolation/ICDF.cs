using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000672 RID: 1650
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("285a8860-c84a-11d7-850f-005cd062464f")]
	[ComImport]
	internal interface ICDF
	{
		// Token: 0x06004F24 RID: 20260
		ISection GetRootSection(uint SectionId);

		// Token: 0x06004F25 RID: 20261
		ISectionEntry GetRootSectionEntry(uint SectionId);

		// Token: 0x17000C9B RID: 3227
		// (get) Token: 0x06004F26 RID: 20262
		object _NewEnum { [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000C9C RID: 3228
		// (get) Token: 0x06004F27 RID: 20263
		uint Count { get; }

		// Token: 0x06004F28 RID: 20264
		object GetItem(uint SectionId);
	}
}
