using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006C9 RID: 1737
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("24abe1f7-a396-4a03-9adf-1d5b86a5569f")]
	[ComImport]
	internal interface IMuiResourceIdLookupMapEntry
	{
		// Token: 0x17000CC5 RID: 3269
		// (get) Token: 0x06005051 RID: 20561
		MuiResourceIdLookupMapEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CC6 RID: 3270
		// (get) Token: 0x06005052 RID: 20562
		uint Count { [SecurityCritical] get; }
	}
}
