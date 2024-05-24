using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200025D RID: 605
	public enum FrameDetachedReason
	{
		// Token: 0x040009B8 RID: 2488
		[EnumMember(Value = "remove")]
		Remove,
		// Token: 0x040009B9 RID: 2489
		[EnumMember(Value = "swap")]
		Swap
	}
}
