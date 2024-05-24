using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000433 RID: 1075
	public enum AnimationType
	{
		// Token: 0x040010EE RID: 4334
		[EnumMember(Value = "CSSTransition")]
		CSSTransition,
		// Token: 0x040010EF RID: 4335
		[EnumMember(Value = "CSSAnimation")]
		CSSAnimation,
		// Token: 0x040010F0 RID: 4336
		[EnumMember(Value = "WebAnimation")]
		WebAnimation
	}
}
