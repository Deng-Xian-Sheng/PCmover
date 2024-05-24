using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200068A RID: 1674
	[Guid("19be1967-b2fc-4dc1-9627-f3cb6305d2a7")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_CATEGORY_SUBCATEGORY
	{
		// Token: 0x06004F65 RID: 20325
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] STORE_CATEGORY_SUBCATEGORY[] rgElements);

		// Token: 0x06004F66 RID: 20326
		[SecurityCritical]
		void Skip([In] uint ulElements);

		// Token: 0x06004F67 RID: 20327
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F68 RID: 20328
		[SecurityCritical]
		IEnumSTORE_CATEGORY_SUBCATEGORY Clone();
	}
}
