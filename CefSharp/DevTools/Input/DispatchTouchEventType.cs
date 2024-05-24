using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000339 RID: 825
	public enum DispatchTouchEventType
	{
		// Token: 0x04000D56 RID: 3414
		[EnumMember(Value = "touchStart")]
		TouchStart,
		// Token: 0x04000D57 RID: 3415
		[EnumMember(Value = "touchEnd")]
		TouchEnd,
		// Token: 0x04000D58 RID: 3416
		[EnumMember(Value = "touchMove")]
		TouchMove,
		// Token: 0x04000D59 RID: 3417
		[EnumMember(Value = "touchCancel")]
		TouchCancel
	}
}
