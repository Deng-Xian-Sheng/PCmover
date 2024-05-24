using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003AB RID: 939
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum DateTimeStyles
	{
		// Token: 0x0400135B RID: 4955
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x0400135C RID: 4956
		[__DynamicallyInvokable]
		AllowLeadingWhite = 1,
		// Token: 0x0400135D RID: 4957
		[__DynamicallyInvokable]
		AllowTrailingWhite = 2,
		// Token: 0x0400135E RID: 4958
		[__DynamicallyInvokable]
		AllowInnerWhite = 4,
		// Token: 0x0400135F RID: 4959
		[__DynamicallyInvokable]
		AllowWhiteSpaces = 7,
		// Token: 0x04001360 RID: 4960
		[__DynamicallyInvokable]
		NoCurrentDateDefault = 8,
		// Token: 0x04001361 RID: 4961
		[__DynamicallyInvokable]
		AdjustToUniversal = 16,
		// Token: 0x04001362 RID: 4962
		[__DynamicallyInvokable]
		AssumeLocal = 32,
		// Token: 0x04001363 RID: 4963
		[__DynamicallyInvokable]
		AssumeUniversal = 64,
		// Token: 0x04001364 RID: 4964
		[__DynamicallyInvokable]
		RoundtripKind = 128
	}
}
