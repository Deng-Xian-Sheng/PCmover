using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000284 RID: 644
	public enum CaptureScreenshotFormat
	{
		// Token: 0x04000A12 RID: 2578
		[EnumMember(Value = "jpeg")]
		Jpeg,
		// Token: 0x04000A13 RID: 2579
		[EnumMember(Value = "png")]
		Png,
		// Token: 0x04000A14 RID: 2580
		[EnumMember(Value = "webp")]
		Webp
	}
}
