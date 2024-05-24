using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAuthn
{
	// Token: 0x0200019F RID: 415
	public enum AuthenticatorProtocol
	{
		// Token: 0x0400065B RID: 1627
		[EnumMember(Value = "u2f")]
		U2f,
		// Token: 0x0400065C RID: 1628
		[EnumMember(Value = "ctap2")]
		Ctap2
	}
}
