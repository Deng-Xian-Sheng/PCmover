using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002A8 RID: 680
	public enum ConnectionType
	{
		// Token: 0x04000AAD RID: 2733
		[EnumMember(Value = "none")]
		None,
		// Token: 0x04000AAE RID: 2734
		[EnumMember(Value = "cellular2g")]
		Cellular2g,
		// Token: 0x04000AAF RID: 2735
		[EnumMember(Value = "cellular3g")]
		Cellular3g,
		// Token: 0x04000AB0 RID: 2736
		[EnumMember(Value = "cellular4g")]
		Cellular4g,
		// Token: 0x04000AB1 RID: 2737
		[EnumMember(Value = "bluetooth")]
		Bluetooth,
		// Token: 0x04000AB2 RID: 2738
		[EnumMember(Value = "ethernet")]
		Ethernet,
		// Token: 0x04000AB3 RID: 2739
		[EnumMember(Value = "wifi")]
		Wifi,
		// Token: 0x04000AB4 RID: 2740
		[EnumMember(Value = "wimax")]
		Wimax,
		// Token: 0x04000AB5 RID: 2741
		[EnumMember(Value = "other")]
		Other
	}
}
