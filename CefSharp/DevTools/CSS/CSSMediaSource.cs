using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003CB RID: 971
	public enum CSSMediaSource
	{
		// Token: 0x04000F41 RID: 3905
		[EnumMember(Value = "mediaRule")]
		MediaRule,
		// Token: 0x04000F42 RID: 3906
		[EnumMember(Value = "importRule")]
		ImportRule,
		// Token: 0x04000F43 RID: 3907
		[EnumMember(Value = "linkedSheet")]
		LinkedSheet,
		// Token: 0x04000F44 RID: 3908
		[EnumMember(Value = "inlineSheet")]
		InlineSheet
	}
}
