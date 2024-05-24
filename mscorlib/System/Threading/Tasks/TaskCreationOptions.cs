using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000562 RID: 1378
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum TaskCreationOptions
	{
		// Token: 0x04001B20 RID: 6944
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001B21 RID: 6945
		[__DynamicallyInvokable]
		PreferFairness = 1,
		// Token: 0x04001B22 RID: 6946
		[__DynamicallyInvokable]
		LongRunning = 2,
		// Token: 0x04001B23 RID: 6947
		[__DynamicallyInvokable]
		AttachedToParent = 4,
		// Token: 0x04001B24 RID: 6948
		[__DynamicallyInvokable]
		DenyChildAttach = 8,
		// Token: 0x04001B25 RID: 6949
		[__DynamicallyInvokable]
		HideScheduler = 16,
		// Token: 0x04001B26 RID: 6950
		[__DynamicallyInvokable]
		RunContinuationsAsynchronously = 64
	}
}
