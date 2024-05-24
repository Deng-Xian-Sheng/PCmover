using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200041D RID: 1053
	public enum TwaQualityEnforcementViolationType
	{
		// Token: 0x0400106F RID: 4207
		[EnumMember(Value = "kHttpError")]
		KHttpError,
		// Token: 0x04001070 RID: 4208
		[EnumMember(Value = "kUnavailableOffline")]
		KUnavailableOffline,
		// Token: 0x04001071 RID: 4209
		[EnumMember(Value = "kDigitalAssetLinks")]
		KDigitalAssetLinks
	}
}
