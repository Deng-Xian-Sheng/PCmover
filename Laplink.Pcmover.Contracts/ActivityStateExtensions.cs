using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000005 RID: 5
	public static class ActivityStateExtensions
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000024E2 File Offset: 0x000006E2
		public static bool IsDone(this ActivityState state)
		{
			return state == ActivityState.Success || state == ActivityState.Failure;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024EE File Offset: 0x000006EE
		public static bool IsRunning(this ActivityState state)
		{
			return state == ActivityState.Active || state == ActivityState.CancelPending;
		}
	}
}
