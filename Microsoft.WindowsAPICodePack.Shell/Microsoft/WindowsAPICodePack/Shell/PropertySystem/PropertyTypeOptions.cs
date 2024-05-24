using System;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000DC RID: 220
	[Flags]
	public enum PropertyTypeOptions
	{
		// Token: 0x04000407 RID: 1031
		None = 0,
		// Token: 0x04000408 RID: 1032
		MultipleValues = 1,
		// Token: 0x04000409 RID: 1033
		IsInnate = 2,
		// Token: 0x0400040A RID: 1034
		IsGroup = 4,
		// Token: 0x0400040B RID: 1035
		CanGroupBy = 8,
		// Token: 0x0400040C RID: 1036
		CanStackBy = 16,
		// Token: 0x0400040D RID: 1037
		IsTreeProperty = 32,
		// Token: 0x0400040E RID: 1038
		IncludeInFullTextQuery = 64,
		// Token: 0x0400040F RID: 1039
		IsViewable = 128,
		// Token: 0x04000410 RID: 1040
		IsQueryable = 256,
		// Token: 0x04000411 RID: 1041
		CanBePurged = 512,
		// Token: 0x04000412 RID: 1042
		IsSystemProperty = -2147483648,
		// Token: 0x04000413 RID: 1043
		MaskAll = -2147483137
	}
}
