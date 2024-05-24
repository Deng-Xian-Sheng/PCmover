using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006CC RID: 1740
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("11df5cad-c183-479b-9a44-3842b71639ce")]
	[ComImport]
	internal interface IMuiResourceTypeIdStringEntry
	{
		// Token: 0x17000CC7 RID: 3271
		// (get) Token: 0x06005057 RID: 20567
		MuiResourceTypeIdStringEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CC8 RID: 3272
		// (get) Token: 0x06005058 RID: 20568
		object StringIds { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000CC9 RID: 3273
		// (get) Token: 0x06005059 RID: 20569
		object IntegerIds { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
