using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000050 RID: 80
	public static class PcmoverStateExtensions
	{
		// Token: 0x06000230 RID: 560 RVA: 0x0000331B File Offset: 0x0000151B
		public static bool CanInitialize(this PcmoverState state)
		{
			return state == PcmoverState.idle;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00003321 File Offset: 0x00001521
		public static bool CanShutdown(this PcmoverState state)
		{
			return state == PcmoverState.initialized;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00003327 File Offset: 0x00001527
		public static bool IsActive(this PcmoverState state)
		{
			return state == PcmoverState.initInProgress || state == PcmoverState.initialized;
		}
	}
}
