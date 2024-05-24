using System;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000137 RID: 311
	[Flags]
	internal enum ThumbButtonOptions
	{
		// Token: 0x04000546 RID: 1350
		Enabled = 0,
		// Token: 0x04000547 RID: 1351
		Disabled = 1,
		// Token: 0x04000548 RID: 1352
		DismissOnClick = 2,
		// Token: 0x04000549 RID: 1353
		NoBackground = 4,
		// Token: 0x0400054A RID: 1354
		Hidden = 8,
		// Token: 0x0400054B RID: 1355
		NonInteractive = 16
	}
}
