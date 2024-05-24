using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000682 RID: 1666
	[Guid("5fa4f590-a416-4b22-ac79-7c3f0d31f303")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_DEPLOYMENT_METADATA_PROPERTY
	{
		// Token: 0x06004F39 RID: 20281
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] StoreOperationMetadataProperty[] AppIds);

		// Token: 0x06004F3A RID: 20282
		[SecurityCritical]
		void Skip([In] uint celt);

		// Token: 0x06004F3B RID: 20283
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F3C RID: 20284
		[SecurityCritical]
		IEnumSTORE_DEPLOYMENT_METADATA_PROPERTY Clone();
	}
}
