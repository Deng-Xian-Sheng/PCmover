using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200056E RID: 1390
	internal class StandardTaskContinuation : TaskContinuation
	{
		// Token: 0x0600416C RID: 16748 RVA: 0x000F44A0 File Offset: 0x000F26A0
		internal StandardTaskContinuation(Task task, TaskContinuationOptions options, TaskScheduler scheduler)
		{
			this.m_task = task;
			this.m_options = options;
			this.m_taskScheduler = scheduler;
			if (AsyncCausalityTracer.LoggingOn)
			{
				AsyncCausalityTracer.TraceOperationCreation(CausalityTraceLevel.Required, this.m_task.Id, "Task.ContinueWith: " + ((Delegate)task.m_action).Method.Name, 0UL);
			}
			if (Task.s_asyncDebuggingEnabled)
			{
				Task.AddToActiveTasks(this.m_task);
			}
		}

		// Token: 0x0600416D RID: 16749 RVA: 0x000F4514 File Offset: 0x000F2714
		internal override void Run(Task completedTask, bool bCanInlineContinuationTask)
		{
			TaskContinuationOptions options = this.m_options;
			bool flag = completedTask.IsRanToCompletion ? ((options & TaskContinuationOptions.NotOnRanToCompletion) == TaskContinuationOptions.None) : (completedTask.IsCanceled ? ((options & TaskContinuationOptions.NotOnCanceled) == TaskContinuationOptions.None) : ((options & TaskContinuationOptions.NotOnFaulted) == TaskContinuationOptions.None));
			Task task = this.m_task;
			if (flag)
			{
				if (!task.IsCanceled && AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationRelation(CausalityTraceLevel.Important, task.Id, CausalityRelation.AssignDelegate);
				}
				task.m_taskScheduler = this.m_taskScheduler;
				if (bCanInlineContinuationTask && (options & TaskContinuationOptions.ExecuteSynchronously) != TaskContinuationOptions.None)
				{
					TaskContinuation.InlineIfPossibleOrElseQueue(task, true);
					return;
				}
				try
				{
					task.ScheduleAndStart(true);
					return;
				}
				catch (TaskSchedulerException)
				{
					return;
				}
			}
			task.InternalCancel(false);
		}

		// Token: 0x0600416E RID: 16750 RVA: 0x000F45C8 File Offset: 0x000F27C8
		internal override Delegate[] GetDelegateContinuationsForDebugger()
		{
			if (this.m_task.m_action == null)
			{
				return this.m_task.GetDelegateContinuationsForDebugger();
			}
			return new Delegate[]
			{
				this.m_task.m_action as Delegate
			};
		}

		// Token: 0x04001B4F RID: 6991
		internal readonly Task m_task;

		// Token: 0x04001B50 RID: 6992
		internal readonly TaskContinuationOptions m_options;

		// Token: 0x04001B51 RID: 6993
		private readonly TaskScheduler m_taskScheduler;
	}
}
