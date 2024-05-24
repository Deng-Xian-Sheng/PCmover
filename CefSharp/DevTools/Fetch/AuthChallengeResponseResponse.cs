using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C6 RID: 454
	public enum AuthChallengeResponseResponse
	{
		// Token: 0x040006DA RID: 1754
		[EnumMember(Value = "Default")]
		Default,
		// Token: 0x040006DB RID: 1755
		[EnumMember(Value = "CancelAuth")]
		CancelAuth,
		// Token: 0x040006DC RID: 1756
		[EnumMember(Value = "ProvideCredentials")]
		ProvideCredentials
	}
}
