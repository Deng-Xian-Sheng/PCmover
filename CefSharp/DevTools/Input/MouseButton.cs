using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000331 RID: 817
	public enum MouseButton
	{
		// Token: 0x04000D35 RID: 3381
		[EnumMember(Value = "none")]
		None,
		// Token: 0x04000D36 RID: 3382
		[EnumMember(Value = "left")]
		Left,
		// Token: 0x04000D37 RID: 3383
		[EnumMember(Value = "middle")]
		Middle,
		// Token: 0x04000D38 RID: 3384
		[EnumMember(Value = "right")]
		Right,
		// Token: 0x04000D39 RID: 3385
		[EnumMember(Value = "back")]
		Back,
		// Token: 0x04000D3A RID: 3386
		[EnumMember(Value = "forward")]
		Forward
	}
}
