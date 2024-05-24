using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000238 RID: 568
	public enum OriginTrialStatus
	{
		// Token: 0x0400089A RID: 2202
		[EnumMember(Value = "Enabled")]
		Enabled,
		// Token: 0x0400089B RID: 2203
		[EnumMember(Value = "ValidTokenNotProvided")]
		ValidTokenNotProvided,
		// Token: 0x0400089C RID: 2204
		[EnumMember(Value = "OSNotSupported")]
		OSNotSupported,
		// Token: 0x0400089D RID: 2205
		[EnumMember(Value = "TrialNotAllowed")]
		TrialNotAllowed
	}
}
