using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x0200021D RID: 541
	public enum CertificateErrorAction
	{
		// Token: 0x040007FE RID: 2046
		[EnumMember(Value = "continue")]
		Continue,
		// Token: 0x040007FF RID: 2047
		[EnumMember(Value = "cancel")]
		Cancel
	}
}
