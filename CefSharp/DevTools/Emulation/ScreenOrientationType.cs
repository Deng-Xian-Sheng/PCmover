using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x0200034F RID: 847
	public enum ScreenOrientationType
	{
		// Token: 0x04000D94 RID: 3476
		[EnumMember(Value = "portraitPrimary")]
		PortraitPrimary,
		// Token: 0x04000D95 RID: 3477
		[EnumMember(Value = "portraitSecondary")]
		PortraitSecondary,
		// Token: 0x04000D96 RID: 3478
		[EnumMember(Value = "landscapePrimary")]
		LandscapePrimary,
		// Token: 0x04000D97 RID: 3479
		[EnumMember(Value = "landscapeSecondary")]
		LandscapeSecondary
	}
}
