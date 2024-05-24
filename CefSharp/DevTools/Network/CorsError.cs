using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B5 RID: 693
	public enum CorsError
	{
		// Token: 0x04000B18 RID: 2840
		[EnumMember(Value = "DisallowedByMode")]
		DisallowedByMode,
		// Token: 0x04000B19 RID: 2841
		[EnumMember(Value = "InvalidResponse")]
		InvalidResponse,
		// Token: 0x04000B1A RID: 2842
		[EnumMember(Value = "WildcardOriginNotAllowed")]
		WildcardOriginNotAllowed,
		// Token: 0x04000B1B RID: 2843
		[EnumMember(Value = "MissingAllowOriginHeader")]
		MissingAllowOriginHeader,
		// Token: 0x04000B1C RID: 2844
		[EnumMember(Value = "MultipleAllowOriginValues")]
		MultipleAllowOriginValues,
		// Token: 0x04000B1D RID: 2845
		[EnumMember(Value = "InvalidAllowOriginValue")]
		InvalidAllowOriginValue,
		// Token: 0x04000B1E RID: 2846
		[EnumMember(Value = "AllowOriginMismatch")]
		AllowOriginMismatch,
		// Token: 0x04000B1F RID: 2847
		[EnumMember(Value = "InvalidAllowCredentials")]
		InvalidAllowCredentials,
		// Token: 0x04000B20 RID: 2848
		[EnumMember(Value = "CorsDisabledScheme")]
		CorsDisabledScheme,
		// Token: 0x04000B21 RID: 2849
		[EnumMember(Value = "PreflightInvalidStatus")]
		PreflightInvalidStatus,
		// Token: 0x04000B22 RID: 2850
		[EnumMember(Value = "PreflightDisallowedRedirect")]
		PreflightDisallowedRedirect,
		// Token: 0x04000B23 RID: 2851
		[EnumMember(Value = "PreflightWildcardOriginNotAllowed")]
		PreflightWildcardOriginNotAllowed,
		// Token: 0x04000B24 RID: 2852
		[EnumMember(Value = "PreflightMissingAllowOriginHeader")]
		PreflightMissingAllowOriginHeader,
		// Token: 0x04000B25 RID: 2853
		[EnumMember(Value = "PreflightMultipleAllowOriginValues")]
		PreflightMultipleAllowOriginValues,
		// Token: 0x04000B26 RID: 2854
		[EnumMember(Value = "PreflightInvalidAllowOriginValue")]
		PreflightInvalidAllowOriginValue,
		// Token: 0x04000B27 RID: 2855
		[EnumMember(Value = "PreflightAllowOriginMismatch")]
		PreflightAllowOriginMismatch,
		// Token: 0x04000B28 RID: 2856
		[EnumMember(Value = "PreflightInvalidAllowCredentials")]
		PreflightInvalidAllowCredentials,
		// Token: 0x04000B29 RID: 2857
		[EnumMember(Value = "PreflightMissingAllowExternal")]
		PreflightMissingAllowExternal,
		// Token: 0x04000B2A RID: 2858
		[EnumMember(Value = "PreflightInvalidAllowExternal")]
		PreflightInvalidAllowExternal,
		// Token: 0x04000B2B RID: 2859
		[EnumMember(Value = "PreflightMissingAllowPrivateNetwork")]
		PreflightMissingAllowPrivateNetwork,
		// Token: 0x04000B2C RID: 2860
		[EnumMember(Value = "PreflightInvalidAllowPrivateNetwork")]
		PreflightInvalidAllowPrivateNetwork,
		// Token: 0x04000B2D RID: 2861
		[EnumMember(Value = "InvalidAllowMethodsPreflightResponse")]
		InvalidAllowMethodsPreflightResponse,
		// Token: 0x04000B2E RID: 2862
		[EnumMember(Value = "InvalidAllowHeadersPreflightResponse")]
		InvalidAllowHeadersPreflightResponse,
		// Token: 0x04000B2F RID: 2863
		[EnumMember(Value = "MethodDisallowedByPreflightResponse")]
		MethodDisallowedByPreflightResponse,
		// Token: 0x04000B30 RID: 2864
		[EnumMember(Value = "HeaderDisallowedByPreflightResponse")]
		HeaderDisallowedByPreflightResponse,
		// Token: 0x04000B31 RID: 2865
		[EnumMember(Value = "RedirectContainsCredentials")]
		RedirectContainsCredentials,
		// Token: 0x04000B32 RID: 2866
		[EnumMember(Value = "InsecurePrivateNetwork")]
		InsecurePrivateNetwork,
		// Token: 0x04000B33 RID: 2867
		[EnumMember(Value = "InvalidPrivateNetworkAccess")]
		InvalidPrivateNetworkAccess,
		// Token: 0x04000B34 RID: 2868
		[EnumMember(Value = "UnexpectedPrivateNetworkAccess")]
		UnexpectedPrivateNetworkAccess,
		// Token: 0x04000B35 RID: 2869
		[EnumMember(Value = "NoCorsRedirectModeNotFollow")]
		NoCorsRedirectModeNotFollow
	}
}
