using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000046 RID: 70
	public static class ListenActivityPhaseExtensions
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00003034 File Offset: 0x00001234
		public static bool IsIdle(this ListenActivityPhase phase)
		{
			return phase == ListenActivityPhase.WaitingForConnection || phase == ListenActivityPhase.WaitingForCommand;
		}
	}
}
