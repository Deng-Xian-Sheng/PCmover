using System;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000DD RID: 221
	[Flags]
	public enum PropertyViewOptions
	{
		// Token: 0x04000415 RID: 1045
		None = 0,
		// Token: 0x04000416 RID: 1046
		CenterAlign = 1,
		// Token: 0x04000417 RID: 1047
		RightAlign = 2,
		// Token: 0x04000418 RID: 1048
		BeginNewGroup = 4,
		// Token: 0x04000419 RID: 1049
		FillArea = 8,
		// Token: 0x0400041A RID: 1050
		SortDescending = 16,
		// Token: 0x0400041B RID: 1051
		ShowOnlyIfPresent = 32,
		// Token: 0x0400041C RID: 1052
		ShowByDefault = 64,
		// Token: 0x0400041D RID: 1053
		ShowInPrimaryList = 128,
		// Token: 0x0400041E RID: 1054
		ShowInSecondaryList = 256,
		// Token: 0x0400041F RID: 1055
		HideLabel = 512,
		// Token: 0x04000420 RID: 1056
		Hidden = 2048,
		// Token: 0x04000421 RID: 1057
		CanWrap = 4096,
		// Token: 0x04000422 RID: 1058
		MaskAll = 1023
	}
}
