using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200040D RID: 1037
	public enum SameSiteCookieWarningReason
	{
		// Token: 0x04001009 RID: 4105
		[EnumMember(Value = "WarnSameSiteUnspecifiedCrossSiteContext")]
		WarnSameSiteUnspecifiedCrossSiteContext,
		// Token: 0x0400100A RID: 4106
		[EnumMember(Value = "WarnSameSiteNoneInsecure")]
		WarnSameSiteNoneInsecure,
		// Token: 0x0400100B RID: 4107
		[EnumMember(Value = "WarnSameSiteUnspecifiedLaxAllowUnsafe")]
		WarnSameSiteUnspecifiedLaxAllowUnsafe,
		// Token: 0x0400100C RID: 4108
		[EnumMember(Value = "WarnSameSiteStrictLaxDowngradeStrict")]
		WarnSameSiteStrictLaxDowngradeStrict,
		// Token: 0x0400100D RID: 4109
		[EnumMember(Value = "WarnSameSiteStrictCrossDowngradeStrict")]
		WarnSameSiteStrictCrossDowngradeStrict,
		// Token: 0x0400100E RID: 4110
		[EnumMember(Value = "WarnSameSiteStrictCrossDowngradeLax")]
		WarnSameSiteStrictCrossDowngradeLax,
		// Token: 0x0400100F RID: 4111
		[EnumMember(Value = "WarnSameSiteLaxCrossDowngradeStrict")]
		WarnSameSiteLaxCrossDowngradeStrict,
		// Token: 0x04001010 RID: 4112
		[EnumMember(Value = "WarnSameSiteLaxCrossDowngradeLax")]
		WarnSameSiteLaxCrossDowngradeLax
	}
}
