using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000564 RID: 1380
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum TaskContinuationOptions
	{
		// Token: 0x04001B32 RID: 6962
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001B33 RID: 6963
		[__DynamicallyInvokable]
		PreferFairness = 1,
		// Token: 0x04001B34 RID: 6964
		[__DynamicallyInvokable]
		LongRunning = 2,
		// Token: 0x04001B35 RID: 6965
		[__DynamicallyInvokable]
		AttachedToParent = 4,
		// Token: 0x04001B36 RID: 6966
		[__DynamicallyInvokable]
		DenyChildAttach = 8,
		// Token: 0x04001B37 RID: 6967
		[__DynamicallyInvokable]
		HideScheduler = 16,
		// Token: 0x04001B38 RID: 6968
		[__DynamicallyInvokable]
		LazyCancellation = 32,
		// Token: 0x04001B39 RID: 6969
		[__DynamicallyInvokable]
		RunContinuationsAsynchronously = 64,
		// Token: 0x04001B3A RID: 6970
		[__DynamicallyInvokable]
		NotOnRanToCompletion = 65536,
		// Token: 0x04001B3B RID: 6971
		[__DynamicallyInvokable]
		NotOnFaulted = 131072,
		// Token: 0x04001B3C RID: 6972
		[__DynamicallyInvokable]
		NotOnCanceled = 262144,
		// Token: 0x04001B3D RID: 6973
		[__DynamicallyInvokable]
		OnlyOnRanToCompletion = 393216,
		// Token: 0x04001B3E RID: 6974
		[__DynamicallyInvokable]
		OnlyOnFaulted = 327680,
		// Token: 0x04001B3F RID: 6975
		[__DynamicallyInvokable]
		OnlyOnCanceled = 196608,
		// Token: 0x04001B40 RID: 6976
		[__DynamicallyInvokable]
		ExecuteSynchronously = 524288
	}
}
