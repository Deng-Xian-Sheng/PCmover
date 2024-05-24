using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200068C RID: 1676
	[Guid("5ba7cb30-8508-4114-8c77-262fcda4fadb")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_CATEGORY_INSTANCE
	{
		// Token: 0x06004F70 RID: 20336
		[SecurityCritical]
		uint Next([In] uint ulElements, [MarshalAs(UnmanagedType.LPArray)] [Out] STORE_CATEGORY_INSTANCE[] rgInstances);

		// Token: 0x06004F71 RID: 20337
		[SecurityCritical]
		void Skip([In] uint ulElements);

		// Token: 0x06004F72 RID: 20338
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F73 RID: 20339
		[SecurityCritical]
		IEnumSTORE_CATEGORY_INSTANCE Clone();
	}
}
