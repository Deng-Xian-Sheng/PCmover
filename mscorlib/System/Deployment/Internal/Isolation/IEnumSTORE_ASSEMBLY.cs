using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000684 RID: 1668
	[Guid("a5c637bf-6eaa-4e5f-b535-55299657e33e")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_ASSEMBLY
	{
		// Token: 0x06004F44 RID: 20292
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] STORE_ASSEMBLY[] rgelt);

		// Token: 0x06004F45 RID: 20293
		[SecurityCritical]
		void Skip([In] uint celt);

		// Token: 0x06004F46 RID: 20294
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F47 RID: 20295
		[SecurityCritical]
		IEnumSTORE_ASSEMBLY Clone();
	}
}
