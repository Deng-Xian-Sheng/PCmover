using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x02000599 RID: 1433
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	[FriendAccessAllowed]
	internal static class InterfaceMarshaler
	{
		// Token: 0x060042E1 RID: 17121
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr ConvertToNative(object objSrc, IntPtr itfMT, IntPtr classMT, int flags);

		// Token: 0x060042E2 RID: 17122
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object ConvertToManaged(IntPtr pUnk, IntPtr itfMT, IntPtr classMT, int flags);

		// Token: 0x060042E3 RID: 17123
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall")]
		internal static extern void ClearNative(IntPtr pUnk);

		// Token: 0x060042E4 RID: 17124
		[FriendAccessAllowed]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object ConvertToManagedWithoutUnboxing(IntPtr pNative);
	}
}
