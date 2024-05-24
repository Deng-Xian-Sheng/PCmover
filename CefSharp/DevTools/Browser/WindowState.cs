using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F0 RID: 1008
	public enum WindowState
	{
		// Token: 0x04000F96 RID: 3990
		[EnumMember(Value = "normal")]
		Normal,
		// Token: 0x04000F97 RID: 3991
		[EnumMember(Value = "minimized")]
		Minimized,
		// Token: 0x04000F98 RID: 3992
		[EnumMember(Value = "maximized")]
		Maximized,
		// Token: 0x04000F99 RID: 3993
		[EnumMember(Value = "fullscreen")]
		Fullscreen
	}
}
