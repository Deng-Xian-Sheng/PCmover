using System;

namespace System.Runtime
{
	// Token: 0x02000715 RID: 1813
	[__DynamicallyInvokable]
	[Serializable]
	public enum GCLatencyMode
	{
		// Token: 0x040023EF RID: 9199
		[__DynamicallyInvokable]
		Batch,
		// Token: 0x040023F0 RID: 9200
		[__DynamicallyInvokable]
		Interactive,
		// Token: 0x040023F1 RID: 9201
		[__DynamicallyInvokable]
		LowLatency,
		// Token: 0x040023F2 RID: 9202
		[__DynamicallyInvokable]
		SustainedLowLatency,
		// Token: 0x040023F3 RID: 9203
		NoGCRegion
	}
}
