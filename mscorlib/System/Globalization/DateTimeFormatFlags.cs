using System;

namespace System.Globalization
{
	// Token: 0x020003AD RID: 941
	[Flags]
	internal enum DateTimeFormatFlags
	{
		// Token: 0x0400136A RID: 4970
		None = 0,
		// Token: 0x0400136B RID: 4971
		UseGenitiveMonth = 1,
		// Token: 0x0400136C RID: 4972
		UseLeapYearMonth = 2,
		// Token: 0x0400136D RID: 4973
		UseSpacesInMonthNames = 4,
		// Token: 0x0400136E RID: 4974
		UseHebrewRule = 8,
		// Token: 0x0400136F RID: 4975
		UseSpacesInDayNames = 16,
		// Token: 0x04001370 RID: 4976
		UseDigitPrefixInTokens = 32,
		// Token: 0x04001371 RID: 4977
		NotInitialized = -1
	}
}
