using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x020001A1 RID: 417
	public enum AuthenticatorTransport
	{
		// Token: 0x04000661 RID: 1633
		[EnumMember(Value = "usb")]
		Usb,
		// Token: 0x04000662 RID: 1634
		[EnumMember(Value = "nfc")]
		Nfc,
		// Token: 0x04000663 RID: 1635
		[EnumMember(Value = "ble")]
		Ble,
		// Token: 0x04000664 RID: 1636
		[EnumMember(Value = "cable")]
		Cable,
		// Token: 0x04000665 RID: 1637
		[EnumMember(Value = "internal")]
		Internal
	}
}
