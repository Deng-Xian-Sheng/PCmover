using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000092 RID: 146
	public enum UndoActivityPhase
	{
		// Token: 0x040003C5 RID: 965
		Idle,
		// Token: 0x040003C6 RID: 966
		Initializing,
		// Token: 0x040003C7 RID: 967
		ReadingHeader,
		// Token: 0x040003C8 RID: 968
		ProcessingHeader,
		// Token: 0x040003C9 RID: 969
		ProcessingData,
		// Token: 0x040003CA RID: 970
		SavingLog
	}
}
