using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x02000571 RID: 1393
	internal class AwaitTaskContinuation : TaskContinuation, IThreadPoolWorkItem
	{
		// Token: 0x06004177 RID: 16759 RVA: 0x000F481C File Offset: 0x000F2A1C
		[SecurityCritical]
		internal AwaitTaskContinuation(Action action, bool flowExecutionContext, ref StackCrawlMark stackMark)
		{
			this.m_action = action;
			if (flowExecutionContext)
			{
				this.m_capturedContext = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx | ExecutionContext.CaptureOptions.OptimizeDefaultCase);
			}
		}

		// Token: 0x06004178 RID: 16760 RVA: 0x000F483B File Offset: 0x000F2A3B
		[SecurityCritical]
		internal AwaitTaskContinuation(Action action, bool flowExecutionContext)
		{
			this.m_action = action;
			if (flowExecutionContext)
			{
				this.m_capturedContext = ExecutionContext.FastCapture();
			}
		}

		// Token: 0x06004179 RID: 16761 RVA: 0x000F4858 File Offset: 0x000F2A58
		protected Task CreateTask(Action<object> action, object state, TaskScheduler scheduler)
		{
			return new Task(action, state, null, default(CancellationToken), TaskCreationOptions.None, InternalTaskOptions.QueuedByRuntime, scheduler)
			{
				CapturedContext = this.m_capturedContext
			};
		}

		// Token: 0x0600417A RID: 16762 RVA: 0x000F488C File Offset: 0x000F2A8C
		[SecuritySafeCritical]
		internal override void Run(Task task, bool canInlineContinuationTask)
		{
			if (canInlineContinuationTask && AwaitTaskContinuation.IsValidLocationForInlining)
			{
				this.RunCallback(AwaitTaskContinuation.GetInvokeActionCallback(), this.m_action, ref Task.t_currentTask);
				return;
			}
			TplEtwProvider log = TplEtwProvider.Log;
			if (log.IsEnabled())
			{
				this.m_continuationId = Task.NewId();
				log.AwaitTaskContinuationScheduled((task.ExecutingTaskScheduler ?? TaskScheduler.Default).Id, task.Id, this.m_continuationId);
			}
			ThreadPool.UnsafeQueueCustomWorkItem(this, false);
		}

		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x0600417B RID: 16763 RVA: 0x000F4900 File Offset: 0x000F2B00
		internal static bool IsValidLocationForInlining
		{
			get
			{
				SynchronizationContext currentNoFlow = SynchronizationContext.CurrentNoFlow;
				if (currentNoFlow != null && currentNoFlow.GetType() != typeof(SynchronizationContext))
				{
					return false;
				}
				TaskScheduler internalCurrent = TaskScheduler.InternalCurrent;
				return internalCurrent == null || internalCurrent == TaskScheduler.Default;
			}
		}

		// Token: 0x0600417C RID: 16764 RVA: 0x000F4944 File Offset: 0x000F2B44
		[SecurityCritical]
		private void ExecuteWorkItemHelper()
		{
			TplEtwProvider log = TplEtwProvider.Log;
			Guid empty = Guid.Empty;
			if (log.TasksSetActivityIds && this.m_continuationId != 0)
			{
				Guid activityId = TplEtwProvider.CreateGuidForTaskID(this.m_continuationId);
				EventSource.SetCurrentThreadActivityId(activityId, out empty);
			}
			try
			{
				if (this.m_capturedContext == null)
				{
					this.m_action();
				}
				else
				{
					try
					{
						ExecutionContext.Run(this.m_capturedContext, AwaitTaskContinuation.GetInvokeActionCallback(), this.m_action, true);
					}
					finally
					{
						this.m_capturedContext.Dispose();
					}
				}
			}
			finally
			{
				if (log.TasksSetActivityIds && this.m_continuationId != 0)
				{
					EventSource.SetCurrentThreadActivityId(empty);
				}
			}
		}

		// Token: 0x0600417D RID: 16765 RVA: 0x000F49F0 File Offset: 0x000F2BF0
		[SecurityCritical]
		void IThreadPoolWorkItem.ExecuteWorkItem()
		{
			if (this.m_capturedContext == null && !TplEtwProvider.Log.IsEnabled())
			{
				this.m_action();
				return;
			}
			this.ExecuteWorkItemHelper();
		}

		// Token: 0x0600417E RID: 16766 RVA: 0x000F4A18 File Offset: 0x000F2C18
		[SecurityCritical]
		void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae)
		{
		}

		// Token: 0x0600417F RID: 16767 RVA: 0x000F4A1A File Offset: 0x000F2C1A
		[SecurityCritical]
		private static void InvokeAction(object state)
		{
			((Action)state)();
		}

		// Token: 0x06004180 RID: 16768 RVA: 0x000F4A28 File Offset: 0x000F2C28
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static ContextCallback GetInvokeActionCallback()
		{
			ContextCallback contextCallback = AwaitTaskContinuation.s_invokeActionCallback;
			if (contextCallback == null)
			{
				contextCallback = (AwaitTaskContinuation.s_invokeActionCallback = new ContextCallback(AwaitTaskContinuation.InvokeAction));
			}
			return contextCallback;
		}

		// Token: 0x06004181 RID: 16769 RVA: 0x000F4A54 File Offset: 0x000F2C54
		[SecurityCritical]
		protected void RunCallback(ContextCallback callback, object state, ref Task currentTask)
		{
			Task task = currentTask;
			try
			{
				if (task != null)
				{
					currentTask = null;
				}
				if (this.m_capturedContext == null)
				{
					callback(state);
				}
				else
				{
					ExecutionContext.Run(this.m_capturedContext, callback, state, true);
				}
			}
			catch (Exception exc)
			{
				AwaitTaskContinuation.ThrowAsyncIfNecessary(exc);
			}
			finally
			{
				if (task != null)
				{
					currentTask = task;
				}
				if (this.m_capturedContext != null)
				{
					this.m_capturedContext.Dispose();
				}
			}
		}

		// Token: 0x06004182 RID: 16770 RVA: 0x000F4ACC File Offset: 0x000F2CCC
		[SecurityCritical]
		internal static void RunOrScheduleAction(Action action, bool allowInlining, ref Task currentTask)
		{
			if (!allowInlining || !AwaitTaskContinuation.IsValidLocationForInlining)
			{
				AwaitTaskContinuation.UnsafeScheduleAction(action, currentTask);
				return;
			}
			Task task = currentTask;
			try
			{
				if (task != null)
				{
					currentTask = null;
				}
				action();
			}
			catch (Exception exc)
			{
				AwaitTaskContinuation.ThrowAsyncIfNecessary(exc);
			}
			finally
			{
				if (task != null)
				{
					currentTask = task;
				}
			}
		}

		// Token: 0x06004183 RID: 16771 RVA: 0x000F4B2C File Offset: 0x000F2D2C
		[SecurityCritical]
		internal static void UnsafeScheduleAction(Action action, Task task)
		{
			AwaitTaskContinuation awaitTaskContinuation = new AwaitTaskContinuation(action, false);
			TplEtwProvider log = TplEtwProvider.Log;
			if (log.IsEnabled() && task != null)
			{
				awaitTaskContinuation.m_continuationId = Task.NewId();
				log.AwaitTaskContinuationScheduled((task.ExecutingTaskScheduler ?? TaskScheduler.Default).Id, task.Id, awaitTaskContinuation.m_continuationId);
			}
			ThreadPool.UnsafeQueueCustomWorkItem(awaitTaskContinuation, false);
		}

		// Token: 0x06004184 RID: 16772 RVA: 0x000F4B8C File Offset: 0x000F2D8C
		protected static void ThrowAsyncIfNecessary(Exception exc)
		{
			if (!(exc is ThreadAbortException) && !(exc is AppDomainUnloadedException) && !WindowsRuntimeMarshal.ReportUnhandledError(exc))
			{
				ExceptionDispatchInfo state = ExceptionDispatchInfo.Capture(exc);
				ThreadPool.QueueUserWorkItem(delegate(object s)
				{
					((ExceptionDispatchInfo)s).Throw();
				}, state);
			}
		}

		// Token: 0x06004185 RID: 16773 RVA: 0x000F4BDE File Offset: 0x000F2DDE
		internal override Delegate[] GetDelegateContinuationsForDebugger()
		{
			return new Delegate[]
			{
				AsyncMethodBuilderCore.TryGetStateMachineForDebugger(this.m_action)
			};
		}

		// Token: 0x04001B56 RID: 6998
		private readonly ExecutionContext m_capturedContext;

		// Token: 0x04001B57 RID: 6999
		protected readonly Action m_action;

		// Token: 0x04001B58 RID: 7000
		protected int m_continuationId;

		// Token: 0x04001B59 RID: 7001
		[SecurityCritical]
		private static ContextCallback s_invokeActionCallback;
	}
}
