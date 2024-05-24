using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000428 RID: 1064
	public enum ClientHintIssueReason
	{
		// Token: 0x040010A7 RID: 4263
		[EnumMember(Value = "MetaTagAllowListInvalidOrigin")]
		MetaTagAllowListInvalidOrigin,
		// Token: 0x040010A8 RID: 4264
		[EnumMember(Value = "MetaTagModifiedHTML")]
		MetaTagModifiedHTML
	}
}
