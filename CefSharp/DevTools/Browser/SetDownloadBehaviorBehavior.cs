using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x02000401 RID: 1025
	public enum SetDownloadBehaviorBehavior
	{
		// Token: 0x04000FE2 RID: 4066
		[EnumMember(Value = "deny")]
		Deny,
		// Token: 0x04000FE3 RID: 4067
		[EnumMember(Value = "allow")]
		Allow,
		// Token: 0x04000FE4 RID: 4068
		[EnumMember(Value = "allowAndName")]
		AllowAndName,
		// Token: 0x04000FE5 RID: 4069
		[EnumMember(Value = "default")]
		Default
	}
}
