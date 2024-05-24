using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000337 RID: 823
	public enum DispatchMouseEventType
	{
		// Token: 0x04000D4E RID: 3406
		[EnumMember(Value = "mousePressed")]
		MousePressed,
		// Token: 0x04000D4F RID: 3407
		[EnumMember(Value = "mouseReleased")]
		MouseReleased,
		// Token: 0x04000D50 RID: 3408
		[EnumMember(Value = "mouseMoved")]
		MouseMoved,
		// Token: 0x04000D51 RID: 3409
		[EnumMember(Value = "mouseWheel")]
		MouseWheel
	}
}
