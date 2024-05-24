using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002A7 RID: 679
	public enum ErrorReason
	{
		// Token: 0x04000A9E RID: 2718
		[EnumMember(Value = "Failed")]
		Failed,
		// Token: 0x04000A9F RID: 2719
		[EnumMember(Value = "Aborted")]
		Aborted,
		// Token: 0x04000AA0 RID: 2720
		[EnumMember(Value = "TimedOut")]
		TimedOut,
		// Token: 0x04000AA1 RID: 2721
		[EnumMember(Value = "AccessDenied")]
		AccessDenied,
		// Token: 0x04000AA2 RID: 2722
		[EnumMember(Value = "ConnectionClosed")]
		ConnectionClosed,
		// Token: 0x04000AA3 RID: 2723
		[EnumMember(Value = "ConnectionReset")]
		ConnectionReset,
		// Token: 0x04000AA4 RID: 2724
		[EnumMember(Value = "ConnectionRefused")]
		ConnectionRefused,
		// Token: 0x04000AA5 RID: 2725
		[EnumMember(Value = "ConnectionAborted")]
		ConnectionAborted,
		// Token: 0x04000AA6 RID: 2726
		[EnumMember(Value = "ConnectionFailed")]
		ConnectionFailed,
		// Token: 0x04000AA7 RID: 2727
		[EnumMember(Value = "NameNotResolved")]
		NameNotResolved,
		// Token: 0x04000AA8 RID: 2728
		[EnumMember(Value = "InternetDisconnected")]
		InternetDisconnected,
		// Token: 0x04000AA9 RID: 2729
		[EnumMember(Value = "AddressUnreachable")]
		AddressUnreachable,
		// Token: 0x04000AAA RID: 2730
		[EnumMember(Value = "BlockedByClient")]
		BlockedByClient,
		// Token: 0x04000AAB RID: 2731
		[EnumMember(Value = "BlockedByResponse")]
		BlockedByResponse
	}
}
