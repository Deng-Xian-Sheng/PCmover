using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D8 RID: 728
	public enum CrossOriginOpenerPolicyValue
	{
		// Token: 0x04000C02 RID: 3074
		[EnumMember(Value = "SameOrigin")]
		SameOrigin,
		// Token: 0x04000C03 RID: 3075
		[EnumMember(Value = "SameOriginAllowPopups")]
		SameOriginAllowPopups,
		// Token: 0x04000C04 RID: 3076
		[EnumMember(Value = "UnsafeNone")]
		UnsafeNone,
		// Token: 0x04000C05 RID: 3077
		[EnumMember(Value = "SameOriginPlusCoep")]
		SameOriginPlusCoep,
		// Token: 0x04000C06 RID: 3078
		[EnumMember(Value = "SameOriginAllowPopupsPlusCoep")]
		SameOriginAllowPopupsPlusCoep
	}
}
