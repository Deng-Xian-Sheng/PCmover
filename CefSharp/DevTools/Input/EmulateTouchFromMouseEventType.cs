using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x0200033A RID: 826
	public enum EmulateTouchFromMouseEventType
	{
		// Token: 0x04000D5B RID: 3419
		[EnumMember(Value = "mousePressed")]
		MousePressed,
		// Token: 0x04000D5C RID: 3420
		[EnumMember(Value = "mouseReleased")]
		MouseReleased,
		// Token: 0x04000D5D RID: 3421
		[EnumMember(Value = "mouseMoved")]
		MouseMoved,
		// Token: 0x04000D5E RID: 3422
		[EnumMember(Value = "mouseWheel")]
		MouseWheel
	}
}
