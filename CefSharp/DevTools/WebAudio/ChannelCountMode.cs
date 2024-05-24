using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001AA RID: 426
	public enum ChannelCountMode
	{
		// Token: 0x04000683 RID: 1667
		[EnumMember(Value = "clamped-max")]
		ClampedMax,
		// Token: 0x04000684 RID: 1668
		[EnumMember(Value = "explicit")]
		Explicit,
		// Token: 0x04000685 RID: 1669
		[EnumMember(Value = "max")]
		Max
	}
}
