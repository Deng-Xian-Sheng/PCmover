using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D4 RID: 724
	public enum PrivateNetworkRequestPolicy
	{
		// Token: 0x04000BF3 RID: 3059
		[EnumMember(Value = "Allow")]
		Allow,
		// Token: 0x04000BF4 RID: 3060
		[EnumMember(Value = "BlockFromInsecureToMorePrivate")]
		BlockFromInsecureToMorePrivate,
		// Token: 0x04000BF5 RID: 3061
		[EnumMember(Value = "WarnFromInsecureToMorePrivate")]
		WarnFromInsecureToMorePrivate,
		// Token: 0x04000BF6 RID: 3062
		[EnumMember(Value = "PreflightBlock")]
		PreflightBlock,
		// Token: 0x04000BF7 RID: 3063
		[EnumMember(Value = "PreflightWarn")]
		PreflightWarn
	}
}
