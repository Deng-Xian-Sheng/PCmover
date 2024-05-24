using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000680 RID: 1664
	[Guid("f9fd4090-93db-45c0-af87-624940f19cff")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_DEPLOYMENT_METADATA
	{
		// Token: 0x06004F2E RID: 20270
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] IDefinitionAppId[] AppIds);

		// Token: 0x06004F2F RID: 20271
		[SecurityCritical]
		void Skip([In] uint celt);

		// Token: 0x06004F30 RID: 20272
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F31 RID: 20273
		[SecurityCritical]
		IEnumSTORE_DEPLOYMENT_METADATA Clone();
	}
}
