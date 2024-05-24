using System;

namespace CefSharp
{
	// Token: 0x02000033 RID: 51
	[Flags]
	public enum ContextMenuType
	{
		// Token: 0x040001BF RID: 447
		None = 0,
		// Token: 0x040001C0 RID: 448
		Page = 1,
		// Token: 0x040001C1 RID: 449
		Frame = 2,
		// Token: 0x040001C2 RID: 450
		Link = 4,
		// Token: 0x040001C3 RID: 451
		Media = 8,
		// Token: 0x040001C4 RID: 452
		Selection = 16,
		// Token: 0x040001C5 RID: 453
		Editable = 32
	}
}
