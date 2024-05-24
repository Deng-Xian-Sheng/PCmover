using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000230 RID: 560
	public enum SecureContextType
	{
		// Token: 0x04000834 RID: 2100
		[EnumMember(Value = "Secure")]
		Secure,
		// Token: 0x04000835 RID: 2101
		[EnumMember(Value = "SecureLocalhost")]
		SecureLocalhost,
		// Token: 0x04000836 RID: 2102
		[EnumMember(Value = "InsecureScheme")]
		InsecureScheme,
		// Token: 0x04000837 RID: 2103
		[EnumMember(Value = "InsecureAncestor")]
		InsecureAncestor
	}
}
