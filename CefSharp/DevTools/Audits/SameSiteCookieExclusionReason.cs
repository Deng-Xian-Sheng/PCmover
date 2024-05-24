using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200040C RID: 1036
	public enum SameSiteCookieExclusionReason
	{
		// Token: 0x04001002 RID: 4098
		[EnumMember(Value = "ExcludeSameSiteUnspecifiedTreatedAsLax")]
		ExcludeSameSiteUnspecifiedTreatedAsLax,
		// Token: 0x04001003 RID: 4099
		[EnumMember(Value = "ExcludeSameSiteNoneInsecure")]
		ExcludeSameSiteNoneInsecure,
		// Token: 0x04001004 RID: 4100
		[EnumMember(Value = "ExcludeSameSiteLax")]
		ExcludeSameSiteLax,
		// Token: 0x04001005 RID: 4101
		[EnumMember(Value = "ExcludeSameSiteStrict")]
		ExcludeSameSiteStrict,
		// Token: 0x04001006 RID: 4102
		[EnumMember(Value = "ExcludeInvalidSameParty")]
		ExcludeInvalidSameParty,
		// Token: 0x04001007 RID: 4103
		[EnumMember(Value = "ExcludeSamePartyCrossPartyContext")]
		ExcludeSamePartyCrossPartyContext
	}
}
