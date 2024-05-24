using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002BA RID: 698
	public enum TrustTokenOperationType
	{
		// Token: 0x04000B44 RID: 2884
		[EnumMember(Value = "Issuance")]
		Issuance,
		// Token: 0x04000B45 RID: 2885
		[EnumMember(Value = "Redemption")]
		Redemption,
		// Token: 0x04000B46 RID: 2886
		[EnumMember(Value = "Signing")]
		Signing
	}
}
