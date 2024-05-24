using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x02000594 RID: 1428
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class DateTimeOffsetMarshaler
	{
		// Token: 0x060042D3 RID: 17107 RVA: 0x000F9624 File Offset: 0x000F7824
		[SecurityCritical]
		internal static void ConvertToNative(ref DateTimeOffset managedDTO, out DateTimeNative dateTime)
		{
			long utcTicks = managedDTO.UtcTicks;
			dateTime.UniversalTime = utcTicks - 504911232000000000L;
		}

		// Token: 0x060042D4 RID: 17108 RVA: 0x000F964C File Offset: 0x000F784C
		[SecurityCritical]
		internal static void ConvertToManaged(out DateTimeOffset managedLocalDTO, ref DateTimeNative nativeTicks)
		{
			long ticks = 504911232000000000L + nativeTicks.UniversalTime;
			DateTimeOffset dateTimeOffset = new DateTimeOffset(ticks, TimeSpan.Zero);
			managedLocalDTO = dateTimeOffset.ToLocalTime(true);
		}

		// Token: 0x04001BD1 RID: 7121
		private const long ManagedUtcTicksAtNativeZero = 504911232000000000L;
	}
}
