using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B3 RID: 691
	public enum CertificateTransparencyCompliance
	{
		// Token: 0x04000B07 RID: 2823
		[EnumMember(Value = "unknown")]
		Unknown,
		// Token: 0x04000B08 RID: 2824
		[EnumMember(Value = "not-compliant")]
		NotCompliant,
		// Token: 0x04000B09 RID: 2825
		[EnumMember(Value = "compliant")]
		Compliant
	}
}
