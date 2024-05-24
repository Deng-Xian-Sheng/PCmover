using System;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x0200055E RID: 1374
	internal sealed class CompletionActionInvoker : IThreadPoolWorkItem
	{
		// Token: 0x06004140 RID: 16704 RVA: 0x000F3C75 File Offset: 0x000F1E75
		internal CompletionActionInvoker(ITaskCompletionAction action, Task completingTask)
		{
			this.m_action = action;
			this.m_completingTask = completingTask;
		}

		// Token: 0x06004141 RID: 16705 RVA: 0x000F3C8B File Offset: 0x000F1E8B
		[SecurityCritical]
		public void ExecuteWorkItem()
		{
			this.m_action.Invoke(this.m_completingTask);
		}

		// Token: 0x06004142 RID: 16706 RVA: 0x000F3C9E File Offset: 0x000F1E9E
		[SecurityCritical]
		public void MarkAborted(ThreadAbortException tae)
		{
		}

		// Token: 0x04001B18 RID: 6936
		private readonly ITaskCompletionAction m_action;

		// Token: 0x04001B19 RID: 6937
		private readonly Task m_completingTask;
	}
}
