using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000336 RID: 822
	public enum DispatchKeyEventType
	{
		// Token: 0x04000D49 RID: 3401
		[EnumMember(Value = "keyDown")]
		KeyDown,
		// Token: 0x04000D4A RID: 3402
		[EnumMember(Value = "keyUp")]
		KeyUp,
		// Token: 0x04000D4B RID: 3403
		[EnumMember(Value = "rawKeyDown")]
		RawKeyDown,
		// Token: 0x04000D4C RID: 3404
		[EnumMember(Value = "char")]
		Char
	}
}
