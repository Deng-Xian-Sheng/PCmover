using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002CA RID: 714
	public enum AuthChallengeResponseResponse
	{
		// Token: 0x04000BC6 RID: 3014
		[EnumMember(Value = "Default")]
		Default,
		// Token: 0x04000BC7 RID: 3015
		[EnumMember(Value = "CancelAuth")]
		CancelAuth,
		// Token: 0x04000BC8 RID: 3016
		[EnumMember(Value = "ProvideCredentials")]
		ProvideCredentials
	}
}
