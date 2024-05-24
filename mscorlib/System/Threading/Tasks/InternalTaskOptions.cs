using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000563 RID: 1379
	[Flags]
	[Serializable]
	internal enum InternalTaskOptions
	{
		// Token: 0x04001B28 RID: 6952
		None = 0,
		// Token: 0x04001B29 RID: 6953
		InternalOptionsMask = 65280,
		// Token: 0x04001B2A RID: 6954
		ChildReplica = 256,
		// Token: 0x04001B2B RID: 6955
		ContinuationTask = 512,
		// Token: 0x04001B2C RID: 6956
		PromiseTask = 1024,
		// Token: 0x04001B2D RID: 6957
		SelfReplicating = 2048,
		// Token: 0x04001B2E RID: 6958
		LazyCancellation = 4096,
		// Token: 0x04001B2F RID: 6959
		QueuedByRuntime = 8192,
		// Token: 0x04001B30 RID: 6960
		DoNotDispose = 16384
	}
}
