using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002DA RID: 730
	public enum CrossOriginEmbedderPolicyValue
	{
		// Token: 0x04000C0C RID: 3084
		[EnumMember(Value = "None")]
		None,
		// Token: 0x04000C0D RID: 3085
		[EnumMember(Value = "Credentialless")]
		Credentialless,
		// Token: 0x04000C0E RID: 3086
		[EnumMember(Value = "RequireCorp")]
		RequireCorp
	}
}
