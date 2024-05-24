using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C4 RID: 708
	public enum CookieBlockedReason
	{
		// Token: 0x04000B9D RID: 2973
		[EnumMember(Value = "SecureOnly")]
		SecureOnly,
		// Token: 0x04000B9E RID: 2974
		[EnumMember(Value = "NotOnPath")]
		NotOnPath,
		// Token: 0x04000B9F RID: 2975
		[EnumMember(Value = "DomainMismatch")]
		DomainMismatch,
		// Token: 0x04000BA0 RID: 2976
		[EnumMember(Value = "SameSiteStrict")]
		SameSiteStrict,
		// Token: 0x04000BA1 RID: 2977
		[EnumMember(Value = "SameSiteLax")]
		SameSiteLax,
		// Token: 0x04000BA2 RID: 2978
		[EnumMember(Value = "SameSiteUnspecifiedTreatedAsLax")]
		SameSiteUnspecifiedTreatedAsLax,
		// Token: 0x04000BA3 RID: 2979
		[EnumMember(Value = "SameSiteNoneInsecure")]
		SameSiteNoneInsecure,
		// Token: 0x04000BA4 RID: 2980
		[EnumMember(Value = "UserPreferences")]
		UserPreferences,
		// Token: 0x04000BA5 RID: 2981
		[EnumMember(Value = "UnknownError")]
		UnknownError,
		// Token: 0x04000BA6 RID: 2982
		[EnumMember(Value = "SchemefulSameSiteStrict")]
		SchemefulSameSiteStrict,
		// Token: 0x04000BA7 RID: 2983
		[EnumMember(Value = "SchemefulSameSiteLax")]
		SchemefulSameSiteLax,
		// Token: 0x04000BA8 RID: 2984
		[EnumMember(Value = "SchemefulSameSiteUnspecifiedTreatedAsLax")]
		SchemefulSameSiteUnspecifiedTreatedAsLax,
		// Token: 0x04000BA9 RID: 2985
		[EnumMember(Value = "SamePartyFromCrossPartyContext")]
		SamePartyFromCrossPartyContext,
		// Token: 0x04000BAA RID: 2986
		[EnumMember(Value = "NameValuePairExceedsMaxSize")]
		NameValuePairExceedsMaxSize
	}
}
