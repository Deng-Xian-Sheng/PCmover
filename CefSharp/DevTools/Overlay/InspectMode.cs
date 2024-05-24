using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200029E RID: 670
	public enum InspectMode
	{
		// Token: 0x04000A7F RID: 2687
		[EnumMember(Value = "searchForNode")]
		SearchForNode,
		// Token: 0x04000A80 RID: 2688
		[EnumMember(Value = "searchForUAShadowDOM")]
		SearchForUAShadowDOM,
		// Token: 0x04000A81 RID: 2689
		[EnumMember(Value = "captureAreaScreenshot")]
		CaptureAreaScreenshot,
		// Token: 0x04000A82 RID: 2690
		[EnumMember(Value = "showDistances")]
		ShowDistances,
		// Token: 0x04000A83 RID: 2691
		[EnumMember(Value = "none")]
		None
	}
}
