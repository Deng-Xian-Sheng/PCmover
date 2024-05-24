using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000702 RID: 1794
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("2474ECB4-8EFD-4410-9F31-B3E7C4A07731")]
	[ComImport]
	internal interface IAssemblyRequestEntry
	{
		// Token: 0x17000D25 RID: 3365
		// (get) Token: 0x060050D6 RID: 20694
		AssemblyRequestEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000D26 RID: 3366
		// (get) Token: 0x060050D7 RID: 20695
		string Name { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000D27 RID: 3367
		// (get) Token: 0x060050D8 RID: 20696
		string permissionSetID { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}
}
