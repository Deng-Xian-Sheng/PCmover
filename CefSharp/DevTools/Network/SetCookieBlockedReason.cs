using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C3 RID: 707
	public enum SetCookieBlockedReason
	{
		// Token: 0x04000B8A RID: 2954
		[EnumMember(Value = "SecureOnly")]
		SecureOnly,
		// Token: 0x04000B8B RID: 2955
		[EnumMember(Value = "SameSiteStrict")]
		SameSiteStrict,
		// Token: 0x04000B8C RID: 2956
		[EnumMember(Value = "SameSiteLax")]
		SameSiteLax,
		// Token: 0x04000B8D RID: 2957
		[EnumMember(Value = "SameSiteUnspecifiedTreatedAsLax")]
		SameSiteUnspecifiedTreatedAsLax,
		// Token: 0x04000B8E RID: 2958
		[EnumMember(Value = "SameSiteNoneInsecure")]
		SameSiteNoneInsecure,
		// Token: 0x04000B8F RID: 2959
		[EnumMember(Value = "UserPreferences")]
		UserPreferences,
		// Token: 0x04000B90 RID: 2960
		[EnumMember(Value = "SyntaxError")]
		SyntaxError,
		// Token: 0x04000B91 RID: 2961
		[EnumMember(Value = "SchemeNotSupported")]
		SchemeNotSupported,
		// Token: 0x04000B92 RID: 2962
		[EnumMember(Value = "OverwriteSecure")]
		OverwriteSecure,
		// Token: 0x04000B93 RID: 2963
		[EnumMember(Value = "InvalidDomain")]
		InvalidDomain,
		// Token: 0x04000B94 RID: 2964
		[EnumMember(Value = "InvalidPrefix")]
		InvalidPrefix,
		// Token: 0x04000B95 RID: 2965
		[EnumMember(Value = "UnknownError")]
		UnknownError,
		// Token: 0x04000B96 RID: 2966
		[EnumMember(Value = "SchemefulSameSiteStrict")]
		SchemefulSameSiteStrict,
		// Token: 0x04000B97 RID: 2967
		[EnumMember(Value = "SchemefulSameSiteLax")]
		SchemefulSameSiteLax,
		// Token: 0x04000B98 RID: 2968
		[EnumMember(Value = "SchemefulSameSiteUnspecifiedTreatedAsLax")]
		SchemefulSameSiteUnspecifiedTreatedAsLax,
		// Token: 0x04000B99 RID: 2969
		[EnumMember(Value = "SamePartyFromCrossPartyContext")]
		SamePartyFromCrossPartyContext,
		// Token: 0x04000B9A RID: 2970
		[EnumMember(Value = "SamePartyConflictsWithOtherAttributes")]
		SamePartyConflictsWithOtherAttributes,
		// Token: 0x04000B9B RID: 2971
		[EnumMember(Value = "NameValuePairExceedsMaxSize")]
		NameValuePairExceedsMaxSize
	}
}
