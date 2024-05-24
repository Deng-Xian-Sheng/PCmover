using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003BD RID: 957
	public enum StyleSheetOrigin
	{
		// Token: 0x04000F00 RID: 3840
		[EnumMember(Value = "injected")]
		Injected,
		// Token: 0x04000F01 RID: 3841
		[EnumMember(Value = "user-agent")]
		UserAgent,
		// Token: 0x04000F02 RID: 3842
		[EnumMember(Value = "inspector")]
		Inspector,
		// Token: 0x04000F03 RID: 3843
		[EnumMember(Value = "regular")]
		Regular
	}
}
