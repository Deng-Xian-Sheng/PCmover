using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Performance
{
	// Token: 0x0200022B RID: 555
	public enum EnableTimeDomain
	{
		// Token: 0x04000826 RID: 2086
		[EnumMember(Value = "timeTicks")]
		TimeTicks,
		// Token: 0x04000827 RID: 2087
		[EnumMember(Value = "threadTicks")]
		ThreadTicks
	}
}
