using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000232 RID: 562
	public enum GatedAPIFeatures
	{
		// Token: 0x0400083D RID: 2109
		[EnumMember(Value = "SharedArrayBuffers")]
		SharedArrayBuffers,
		// Token: 0x0400083E RID: 2110
		[EnumMember(Value = "SharedArrayBuffersTransferAllowed")]
		SharedArrayBuffersTransferAllowed,
		// Token: 0x0400083F RID: 2111
		[EnumMember(Value = "PerformanceMeasureMemory")]
		PerformanceMeasureMemory,
		// Token: 0x04000840 RID: 2112
		[EnumMember(Value = "PerformanceProfile")]
		PerformanceProfile
	}
}
