using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000686 RID: 1670
	[Guid("a5c6aaa3-03e4-478d-b9f5-2e45908d5e4f")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_ASSEMBLY_FILE
	{
		// Token: 0x06004F4F RID: 20303
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] STORE_ASSEMBLY_FILE[] rgelt);

		// Token: 0x06004F50 RID: 20304
		[SecurityCritical]
		void Skip([In] uint celt);

		// Token: 0x06004F51 RID: 20305
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F52 RID: 20306
		[SecurityCritical]
		IEnumSTORE_ASSEMBLY_FILE Clone();
	}
}
