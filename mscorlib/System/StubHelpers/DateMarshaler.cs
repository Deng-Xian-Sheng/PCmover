using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System.StubHelpers
{
	// Token: 0x02000598 RID: 1432
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class DateMarshaler
	{
		// Token: 0x060042DF RID: 17119
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern double ConvertToNative(DateTime managedDate);

		// Token: 0x060042E0 RID: 17120
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern long ConvertToManaged(double nativeDate);
	}
}
