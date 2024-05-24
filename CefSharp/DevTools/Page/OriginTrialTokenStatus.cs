using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000237 RID: 567
	public enum OriginTrialTokenStatus
	{
		// Token: 0x0400088D RID: 2189
		[EnumMember(Value = "Success")]
		Success,
		// Token: 0x0400088E RID: 2190
		[EnumMember(Value = "NotSupported")]
		NotSupported,
		// Token: 0x0400088F RID: 2191
		[EnumMember(Value = "Insecure")]
		Insecure,
		// Token: 0x04000890 RID: 2192
		[EnumMember(Value = "Expired")]
		Expired,
		// Token: 0x04000891 RID: 2193
		[EnumMember(Value = "WrongOrigin")]
		WrongOrigin,
		// Token: 0x04000892 RID: 2194
		[EnumMember(Value = "InvalidSignature")]
		InvalidSignature,
		// Token: 0x04000893 RID: 2195
		[EnumMember(Value = "Malformed")]
		Malformed,
		// Token: 0x04000894 RID: 2196
		[EnumMember(Value = "WrongVersion")]
		WrongVersion,
		// Token: 0x04000895 RID: 2197
		[EnumMember(Value = "FeatureDisabled")]
		FeatureDisabled,
		// Token: 0x04000896 RID: 2198
		[EnumMember(Value = "TokenDisabled")]
		TokenDisabled,
		// Token: 0x04000897 RID: 2199
		[EnumMember(Value = "FeatureDisabledForUser")]
		FeatureDisabledForUser,
		// Token: 0x04000898 RID: 2200
		[EnumMember(Value = "UnknownTrial")]
		UnknownTrial
	}
}
