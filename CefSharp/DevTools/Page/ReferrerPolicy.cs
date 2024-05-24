using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000251 RID: 593
	public enum ReferrerPolicy
	{
		// Token: 0x0400091A RID: 2330
		[EnumMember(Value = "noReferrer")]
		NoReferrer,
		// Token: 0x0400091B RID: 2331
		[EnumMember(Value = "noReferrerWhenDowngrade")]
		NoReferrerWhenDowngrade,
		// Token: 0x0400091C RID: 2332
		[EnumMember(Value = "origin")]
		Origin,
		// Token: 0x0400091D RID: 2333
		[EnumMember(Value = "originWhenCrossOrigin")]
		OriginWhenCrossOrigin,
		// Token: 0x0400091E RID: 2334
		[EnumMember(Value = "sameOrigin")]
		SameOrigin,
		// Token: 0x0400091F RID: 2335
		[EnumMember(Value = "strictOrigin")]
		StrictOrigin,
		// Token: 0x04000920 RID: 2336
		[EnumMember(Value = "strictOriginWhenCrossOrigin")]
		StrictOriginWhenCrossOrigin,
		// Token: 0x04000921 RID: 2337
		[EnumMember(Value = "unsafeUrl")]
		UnsafeUrl
	}
}
