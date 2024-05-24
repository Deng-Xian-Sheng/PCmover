using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System.StubHelpers
{
	// Token: 0x02000596 RID: 1430
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class ObjectMarshaler
	{
		// Token: 0x060042D9 RID: 17113
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ConvertToNative(object objSrc, IntPtr pDstVariant);

		// Token: 0x060042DA RID: 17114
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object ConvertToManaged(IntPtr pSrcVariant);

		// Token: 0x060042DB RID: 17115
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ClearNative(IntPtr pVariant);
	}
}
