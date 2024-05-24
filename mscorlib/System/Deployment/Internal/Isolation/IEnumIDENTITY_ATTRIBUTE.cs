using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000690 RID: 1680
	[Guid("9cdaae75-246e-4b00-a26d-b9aec137a3eb")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IEnumIDENTITY_ATTRIBUTE
	{
		// Token: 0x06004F83 RID: 20355
		[SecurityCritical]
		uint Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] IDENTITY_ATTRIBUTE[] rgAttributes);

		// Token: 0x06004F84 RID: 20356
		[SecurityCritical]
		IntPtr CurrentIntoBuffer([In] IntPtr Available, [MarshalAs(UnmanagedType.LPArray)] [Out] byte[] Data);

		// Token: 0x06004F85 RID: 20357
		[SecurityCritical]
		void Skip([In] uint celt);

		// Token: 0x06004F86 RID: 20358
		[SecurityCritical]
		void Reset();

		// Token: 0x06004F87 RID: 20359
		[SecurityCritical]
		IEnumIDENTITY_ATTRIBUTE Clone();
	}
}
