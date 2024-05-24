using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200001E RID: 30
	[Flags]
	public enum MigrationItemsEnabled
	{
		// Token: 0x040000B8 RID: 184
		None = 0,
		// Token: 0x040000B9 RID: 185
		All = 1,
		// Token: 0x040000BA RID: 186
		FilesAndSettings = 2,
		// Token: 0x040000BB RID: 187
		FilesOnly = 4
	}
}
