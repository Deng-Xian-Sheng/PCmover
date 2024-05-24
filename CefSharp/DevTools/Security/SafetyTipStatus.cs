using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000218 RID: 536
	public enum SafetyTipStatus
	{
		// Token: 0x040007E7 RID: 2023
		[EnumMember(Value = "badReputation")]
		BadReputation,
		// Token: 0x040007E8 RID: 2024
		[EnumMember(Value = "lookalike")]
		Lookalike
	}
}
