using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200006E RID: 110
	public enum SearchConditionOperation
	{
		// Token: 0x0400026C RID: 620
		Implicit,
		// Token: 0x0400026D RID: 621
		Equal,
		// Token: 0x0400026E RID: 622
		NotEqual,
		// Token: 0x0400026F RID: 623
		LessThan,
		// Token: 0x04000270 RID: 624
		GreaterThan,
		// Token: 0x04000271 RID: 625
		LessThanOrEqual,
		// Token: 0x04000272 RID: 626
		GreaterThanOrEqual,
		// Token: 0x04000273 RID: 627
		ValueStartsWith,
		// Token: 0x04000274 RID: 628
		ValueEndsWith,
		// Token: 0x04000275 RID: 629
		ValueContains,
		// Token: 0x04000276 RID: 630
		ValueNotContains,
		// Token: 0x04000277 RID: 631
		DosWildcards,
		// Token: 0x04000278 RID: 632
		WordEqual,
		// Token: 0x04000279 RID: 633
		WordStartsWith,
		// Token: 0x0400027A RID: 634
		ApplicationSpecific
	}
}
