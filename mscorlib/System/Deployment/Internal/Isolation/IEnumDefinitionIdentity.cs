using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000691 RID: 1681
	[Guid("f3549d9c-fc73-4793-9c00-1cd204254c0c")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumDefinitionIdentity
	{
		// Token: 0x06004F88 RID: 20360
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] IDefinitionIdentity[] DefinitionIdentity);

		// Token: 0x06004F89 RID: 20361
		[SecurityCritical]
		void Skip([In] uint celt);

		// Token: 0x06004F8A RID: 20362
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F8B RID: 20363
		[SecurityCritical]
		IEnumDefinitionIdentity Clone();
	}
}
