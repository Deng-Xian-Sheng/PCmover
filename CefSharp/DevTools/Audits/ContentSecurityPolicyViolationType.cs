using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000418 RID: 1048
	public enum ContentSecurityPolicyViolationType
	{
		// Token: 0x04001057 RID: 4183
		[EnumMember(Value = "kInlineViolation")]
		KInlineViolation,
		// Token: 0x04001058 RID: 4184
		[EnumMember(Value = "kEvalViolation")]
		KEvalViolation,
		// Token: 0x04001059 RID: 4185
		[EnumMember(Value = "kURLViolation")]
		KURLViolation,
		// Token: 0x0400105A RID: 4186
		[EnumMember(Value = "kTrustedTypesSinkViolation")]
		KTrustedTypesSinkViolation,
		// Token: 0x0400105B RID: 4187
		[EnumMember(Value = "kTrustedTypesPolicyViolation")]
		KTrustedTypesPolicyViolation,
		// Token: 0x0400105C RID: 4188
		[EnumMember(Value = "kWasmEvalViolation")]
		KWasmEvalViolation
	}
}
