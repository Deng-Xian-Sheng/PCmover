using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000093 RID: 147
	public enum UndoActivityFailureReason
	{
		// Token: 0x040003CC RID: 972
		None,
		// Token: 0x040003CD RID: 973
		Unknown,
		// Token: 0x040003CE RID: 974
		Cancelled,
		// Token: 0x040003CF RID: 975
		Exception,
		// Token: 0x040003D0 RID: 976
		CreateTask,
		// Token: 0x040003D1 RID: 977
		ReadHeader,
		// Token: 0x040003D2 RID: 978
		ProcessHeader,
		// Token: 0x040003D3 RID: 979
		SerialNumberRequired,
		// Token: 0x040003D4 RID: 980
		ProcessData
	}
}
