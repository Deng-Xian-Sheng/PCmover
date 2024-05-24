using System;

namespace RestSharp
{
	// Token: 0x02000007 RID: 7
	public enum ParameterType
	{
		// Token: 0x04000007 RID: 7
		Cookie,
		// Token: 0x04000008 RID: 8
		GetOrPost,
		// Token: 0x04000009 RID: 9
		UrlSegment,
		// Token: 0x0400000A RID: 10
		HttpHeader,
		// Token: 0x0400000B RID: 11
		RequestBody,
		// Token: 0x0400000C RID: 12
		QueryString,
		// Token: 0x0400000D RID: 13
		QueryStringWithoutEncode
	}
}
