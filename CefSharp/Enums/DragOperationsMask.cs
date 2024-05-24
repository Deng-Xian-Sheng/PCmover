using System;

namespace CefSharp.Enums
{
	// Token: 0x02000114 RID: 276
	[Flags]
	public enum DragOperationsMask : uint
	{
		// Token: 0x0400041B RID: 1051
		None = 0U,
		// Token: 0x0400041C RID: 1052
		Copy = 1U,
		// Token: 0x0400041D RID: 1053
		Link = 2U,
		// Token: 0x0400041E RID: 1054
		Generic = 4U,
		// Token: 0x0400041F RID: 1055
		Private = 8U,
		// Token: 0x04000420 RID: 1056
		Move = 16U,
		// Token: 0x04000421 RID: 1057
		Delete = 32U,
		// Token: 0x04000422 RID: 1058
		Every = 4294967295U
	}
}
