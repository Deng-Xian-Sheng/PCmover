using System;
using System.Runtime.ConstrainedExecution;

namespace System.StubHelpers
{
	// Token: 0x02000592 RID: 1426
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class WSTRBufferMarshaler
	{
		// Token: 0x060042D0 RID: 17104 RVA: 0x000F9618 File Offset: 0x000F7818
		internal static IntPtr ConvertToNative(string strManaged)
		{
			return IntPtr.Zero;
		}

		// Token: 0x060042D1 RID: 17105 RVA: 0x000F961F File Offset: 0x000F781F
		internal static string ConvertToManaged(IntPtr bstr)
		{
			return null;
		}

		// Token: 0x060042D2 RID: 17106 RVA: 0x000F9622 File Offset: 0x000F7822
		internal static void ClearNative(IntPtr pNative)
		{
		}
	}
}
