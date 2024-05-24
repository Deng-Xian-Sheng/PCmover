using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x02000597 RID: 1431
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class ValueClassMarshaler
	{
		// Token: 0x060042DC RID: 17116
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertToNative(IntPtr dst, IntPtr src, IntPtr pMT, ref CleanupWorkList pCleanupWorkList);

		// Token: 0x060042DD RID: 17117
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertToManaged(IntPtr dst, IntPtr src, IntPtr pMT);

		// Token: 0x060042DE RID: 17118
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ClearNative(IntPtr dst, IntPtr pMT);
	}
}
