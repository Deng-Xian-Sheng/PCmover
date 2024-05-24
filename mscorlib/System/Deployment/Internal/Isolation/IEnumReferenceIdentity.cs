using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000692 RID: 1682
	[Guid("b30352cf-23da-4577-9b3f-b4e6573be53b")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumReferenceIdentity
	{
		// Token: 0x06004F8C RID: 20364
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] IReferenceIdentity[] ReferenceIdentity);

		// Token: 0x06004F8D RID: 20365
		[SecurityCritical]
		void Skip(uint celt);

		// Token: 0x06004F8E RID: 20366
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F8F RID: 20367
		[SecurityCritical]
		IEnumReferenceIdentity Clone();
	}
}
