using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000244 RID: 580
	public enum DialogType
	{
		// Token: 0x040008E2 RID: 2274
		[EnumMember(Value = "alert")]
		Alert,
		// Token: 0x040008E3 RID: 2275
		[EnumMember(Value = "confirm")]
		Confirm,
		// Token: 0x040008E4 RID: 2276
		[EnumMember(Value = "prompt")]
		Prompt,
		// Token: 0x040008E5 RID: 2277
		[EnumMember(Value = "beforeunload")]
		Beforeunload
	}
}
