using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F3 RID: 499
	public enum SubsamplingFormat
	{
		// Token: 0x04000753 RID: 1875
		[EnumMember(Value = "yuv420")]
		Yuv420,
		// Token: 0x04000754 RID: 1876
		[EnumMember(Value = "yuv422")]
		Yuv422,
		// Token: 0x04000755 RID: 1877
		[EnumMember(Value = "yuv444")]
		Yuv444
	}
}
