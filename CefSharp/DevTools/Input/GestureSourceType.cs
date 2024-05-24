using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000330 RID: 816
	public enum GestureSourceType
	{
		// Token: 0x04000D31 RID: 3377
		[EnumMember(Value = "default")]
		Default,
		// Token: 0x04000D32 RID: 3378
		[EnumMember(Value = "touch")]
		Touch,
		// Token: 0x04000D33 RID: 3379
		[EnumMember(Value = "mouse")]
		Mouse
	}
}
