using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D2 RID: 1746
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("397927f5-10f2-4ecb-bfe1-3c264212a193")]
	[ComImport]
	internal interface IMuiResourceMapEntry
	{
		// Token: 0x17000CCD RID: 3277
		// (get) Token: 0x06005065 RID: 20581
		MuiResourceMapEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CCE RID: 3278
		// (get) Token: 0x06005066 RID: 20582
		object ResourceTypeIdInt { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000CCF RID: 3279
		// (get) Token: 0x06005067 RID: 20583
		object ResourceTypeIdString { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
