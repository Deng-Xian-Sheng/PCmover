using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002AF RID: 687
	public enum RequestReferrerPolicy
	{
		// Token: 0x04000ADC RID: 2780
		[EnumMember(Value = "unsafe-url")]
		UnsafeUrl,
		// Token: 0x04000ADD RID: 2781
		[EnumMember(Value = "no-referrer-when-downgrade")]
		NoReferrerWhenDowngrade,
		// Token: 0x04000ADE RID: 2782
		[EnumMember(Value = "no-referrer")]
		NoReferrer,
		// Token: 0x04000ADF RID: 2783
		[EnumMember(Value = "origin")]
		Origin,
		// Token: 0x04000AE0 RID: 2784
		[EnumMember(Value = "origin-when-cross-origin")]
		OriginWhenCrossOrigin,
		// Token: 0x04000AE1 RID: 2785
		[EnumMember(Value = "same-origin")]
		SameOrigin,
		// Token: 0x04000AE2 RID: 2786
		[EnumMember(Value = "strict-origin")]
		StrictOrigin,
		// Token: 0x04000AE3 RID: 2787
		[EnumMember(Value = "strict-origin-when-cross-origin")]
		StrictOriginWhenCrossOrigin
	}
}
