using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006CF RID: 1743
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("55b2dec1-d0f6-4bf4-91b1-30f73ad8e4df")]
	[ComImport]
	internal interface IMuiResourceTypeIdIntEntry
	{
		// Token: 0x17000CCA RID: 3274
		// (get) Token: 0x0600505E RID: 20574
		MuiResourceTypeIdIntEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CCB RID: 3275
		// (get) Token: 0x0600505F RID: 20575
		object StringIds { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000CCC RID: 3276
		// (get) Token: 0x06005060 RID: 20576
		object IntegerIds { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }
	}
}
