using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000688 RID: 1672
	[Guid("b840a2f5-a497-4a6d-9038-cd3ec2fbd222")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumSTORE_CATEGORY
	{
		// Token: 0x06004F5A RID: 20314
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] STORE_CATEGORY[] rgElements);

		// Token: 0x06004F5B RID: 20315
		[SecurityCritical]
		void Skip([In] uint ulElements);

		// Token: 0x06004F5C RID: 20316
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F5D RID: 20317
		[SecurityCritical]
		IEnumSTORE_CATEGORY Clone();
	}
}
