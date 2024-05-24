using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000003 RID: 3
	public enum ActivityType
	{
		// Token: 0x0400000A RID: 10
		Unknown,
		// Token: 0x0400000B RID: 11
		AppInventory,
		// Token: 0x0400000C RID: 12
		Discovery,
		// Token: 0x0400000D RID: 13
		SaveSnapshot,
		// Token: 0x0400000E RID: 14
		GetSnapshot,
		// Token: 0x0400000F RID: 15
		BuildChangeLists,
		// Token: 0x04000010 RID: 16
		SaveMovingVan,
		// Token: 0x04000011 RID: 17
		Transfer,
		// Token: 0x04000012 RID: 18
		Listen,
		// Token: 0x04000013 RID: 19
		Undo,
		// Token: 0x04000014 RID: 20
		ExpandSnapshot,
		// Token: 0x04000015 RID: 21
		GenerateReports,
		// Token: 0x04000016 RID: 22
		LoadMovingJournal
	}
}
