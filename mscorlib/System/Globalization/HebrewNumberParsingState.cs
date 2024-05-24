using System;

namespace System.Globalization
{
	// Token: 0x020003DD RID: 989
	internal enum HebrewNumberParsingState
	{
		// Token: 0x04001687 RID: 5767
		InvalidHebrewNumber,
		// Token: 0x04001688 RID: 5768
		NotHebrewDigit,
		// Token: 0x04001689 RID: 5769
		FoundEndOfHebrewNumber,
		// Token: 0x0400168A RID: 5770
		ContinueParsing
	}
}
