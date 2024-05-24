using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002A6 RID: 678
	public enum ResourceType
	{
		// Token: 0x04000A8C RID: 2700
		[EnumMember(Value = "Document")]
		Document,
		// Token: 0x04000A8D RID: 2701
		[EnumMember(Value = "Stylesheet")]
		Stylesheet,
		// Token: 0x04000A8E RID: 2702
		[EnumMember(Value = "Image")]
		Image,
		// Token: 0x04000A8F RID: 2703
		[EnumMember(Value = "Media")]
		Media,
		// Token: 0x04000A90 RID: 2704
		[EnumMember(Value = "Font")]
		Font,
		// Token: 0x04000A91 RID: 2705
		[EnumMember(Value = "Script")]
		Script,
		// Token: 0x04000A92 RID: 2706
		[EnumMember(Value = "TextTrack")]
		TextTrack,
		// Token: 0x04000A93 RID: 2707
		[EnumMember(Value = "XHR")]
		XHR,
		// Token: 0x04000A94 RID: 2708
		[EnumMember(Value = "Fetch")]
		Fetch,
		// Token: 0x04000A95 RID: 2709
		[EnumMember(Value = "EventSource")]
		EventSource,
		// Token: 0x04000A96 RID: 2710
		[EnumMember(Value = "WebSocket")]
		WebSocket,
		// Token: 0x04000A97 RID: 2711
		[EnumMember(Value = "Manifest")]
		Manifest,
		// Token: 0x04000A98 RID: 2712
		[EnumMember(Value = "SignedExchange")]
		SignedExchange,
		// Token: 0x04000A99 RID: 2713
		[EnumMember(Value = "Ping")]
		Ping,
		// Token: 0x04000A9A RID: 2714
		[EnumMember(Value = "CSPViolationReport")]
		CSPViolationReport,
		// Token: 0x04000A9B RID: 2715
		[EnumMember(Value = "Preflight")]
		Preflight,
		// Token: 0x04000A9C RID: 2716
		[EnumMember(Value = "Other")]
		Other
	}
}
