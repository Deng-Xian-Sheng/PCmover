using System;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x0200056D RID: 1389
	internal abstract class TaskContinuation
	{
		// Token: 0x06004168 RID: 16744
		internal abstract void Run(Task completedTask, bool bCanInlineContinuationTask);

		// Token: 0x06004169 RID: 16745 RVA: 0x000F4408 File Offset: 0x000F2608
		[SecuritySafeCritical]
		protected static void InlineIfPossibleOrElseQueue(Task task, bool needsProtection)
		{
			if (needsProtection)
			{
				if (!task.MarkStarted())
				{
					return;
				}
			}
			else
			{
				task.m_stateFlags |= 65536;
			}
			try
			{
				if (!task.m_taskScheduler.TryRunInline(task, false))
				{
					task.m_taskScheduler.InternalQueueTask(task);
				}
			}
			catch (Exception ex)
			{
				if (!(ex is ThreadAbortException) || (task.m_stateFlags & 134217728) == 0)
				{
					TaskSchedulerException exceptionObject = new TaskSchedulerException(ex);
					task.AddException(exceptionObject);
					task.Finish(false);
				}
			}
		}

		// Token: 0x0600416A RID: 16746
		internal abstract Delegate[] GetDelegateContinuationsForDebugger();
	}
}
