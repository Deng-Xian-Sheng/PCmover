using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000416 RID: 1046
	public enum HeavyAdReason
	{
		// Token: 0x04001050 RID: 4176
		[EnumMember(Value = "NetworkTotalLimit")]
		NetworkTotalLimit,
		// Token: 0x04001051 RID: 4177
		[EnumMember(Value = "CpuTotalLimit")]
		CpuTotalLimit,
		// Token: 0x04001052 RID: 4178
		[EnumMember(Value = "CpuPeakLimit")]
		CpuPeakLimit
	}
}
