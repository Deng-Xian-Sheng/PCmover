using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200055C RID: 1372
	[__DynamicallyInvokable]
	public enum TaskStatus
	{
		// Token: 0x04001AE8 RID: 6888
		[__DynamicallyInvokable]
		Created,
		// Token: 0x04001AE9 RID: 6889
		[__DynamicallyInvokable]
		WaitingForActivation,
		// Token: 0x04001AEA RID: 6890
		[__DynamicallyInvokable]
		WaitingToRun,
		// Token: 0x04001AEB RID: 6891
		[__DynamicallyInvokable]
		Running,
		// Token: 0x04001AEC RID: 6892
		[__DynamicallyInvokable]
		WaitingForChildrenToComplete,
		// Token: 0x04001AED RID: 6893
		[__DynamicallyInvokable]
		RanToCompletion,
		// Token: 0x04001AEE RID: 6894
		[__DynamicallyInvokable]
		Canceled,
		// Token: 0x04001AEF RID: 6895
		[__DynamicallyInvokable]
		Faulted
	}
}
