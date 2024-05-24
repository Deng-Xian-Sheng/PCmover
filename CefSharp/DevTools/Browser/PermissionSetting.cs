using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F3 RID: 1011
	public enum PermissionSetting
	{
		// Token: 0x04000FB8 RID: 4024
		[EnumMember(Value = "granted")]
		Granted,
		// Token: 0x04000FB9 RID: 4025
		[EnumMember(Value = "denied")]
		Denied,
		// Token: 0x04000FBA RID: 4026
		[EnumMember(Value = "prompt")]
		Prompt
	}
}
