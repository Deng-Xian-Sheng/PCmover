using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200022D RID: 557
	public enum AdFrameType
	{
		// Token: 0x0400082A RID: 2090
		[EnumMember(Value = "none")]
		None,
		// Token: 0x0400082B RID: 2091
		[EnumMember(Value = "child")]
		Child,
		// Token: 0x0400082C RID: 2092
		[EnumMember(Value = "root")]
		Root
	}
}
