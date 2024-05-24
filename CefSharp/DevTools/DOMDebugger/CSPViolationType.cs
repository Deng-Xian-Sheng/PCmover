using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMDebugger
{
	// Token: 0x02000379 RID: 889
	public enum CSPViolationType
	{
		// Token: 0x04000E3F RID: 3647
		[EnumMember(Value = "trustedtype-sink-violation")]
		TrustedtypeSinkViolation,
		// Token: 0x04000E40 RID: 3648
		[EnumMember(Value = "trustedtype-policy-violation")]
		TrustedtypePolicyViolation
	}
}
