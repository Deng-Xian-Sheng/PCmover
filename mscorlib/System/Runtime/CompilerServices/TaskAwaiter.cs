﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F5 RID: 2293
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct TaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
	{
		// Token: 0x06005E36 RID: 24118 RVA: 0x0014B183 File Offset: 0x00149383
		internal TaskAwaiter(Task task)
		{
			this.m_task = task;
		}

		// Token: 0x1700102E RID: 4142
		// (get) Token: 0x06005E37 RID: 24119 RVA: 0x0014B18C File Offset: 0x0014938C
		[__DynamicallyInvokable]
		public bool IsCompleted
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_task.IsCompleted;
			}
		}

		// Token: 0x06005E38 RID: 24120 RVA: 0x0014B199 File Offset: 0x00149399
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public void OnCompleted(Action continuation)
		{
			TaskAwaiter.OnCompletedInternal(this.m_task, continuation, true, true);
		}

		// Token: 0x06005E39 RID: 24121 RVA: 0x0014B1A9 File Offset: 0x001493A9
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void UnsafeOnCompleted(Action continuation)
		{
			TaskAwaiter.OnCompletedInternal(this.m_task, continuation, true, false);
		}

		// Token: 0x06005E3A RID: 24122 RVA: 0x0014B1B9 File Offset: 0x001493B9
		[__DynamicallyInvokable]
		public void GetResult()
		{
			TaskAwaiter.ValidateEnd(this.m_task);
		}

		// Token: 0x06005E3B RID: 24123 RVA: 0x0014B1C6 File Offset: 0x001493C6
		internal static void ValidateEnd(Task task)
		{
			if (task.IsWaitNotificationEnabledOrNotRanToCompletion)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
		}

		// Token: 0x06005E3C RID: 24124 RVA: 0x0014B1D8 File Offset: 0x001493D8
		private static void HandleNonSuccessAndDebuggerNotification(Task task)
		{
			if (!task.IsCompleted)
			{
				bool flag = task.InternalWait(-1, default(CancellationToken));
			}
			task.NotifyDebuggerOfWaitCompletionIfNecessary();
			if (!task.IsRanToCompletion)
			{
				TaskAwaiter.ThrowForNonSuccess(task);
			}
		}

		// Token: 0x06005E3D RID: 24125 RVA: 0x0014B214 File Offset: 0x00149414
		private static void ThrowForNonSuccess(Task task)
		{
			TaskStatus status = task.Status;
			if (status == TaskStatus.Canceled)
			{
				ExceptionDispatchInfo cancellationExceptionDispatchInfo = task.GetCancellationExceptionDispatchInfo();
				if (cancellationExceptionDispatchInfo != null)
				{
					cancellationExceptionDispatchInfo.Throw();
				}
				throw new TaskCanceledException(task);
			}
			if (status != TaskStatus.Faulted)
			{
				return;
			}
			ReadOnlyCollection<ExceptionDispatchInfo> exceptionDispatchInfos = task.GetExceptionDispatchInfos();
			if (exceptionDispatchInfos.Count > 0)
			{
				exceptionDispatchInfos[0].Throw();
				return;
			}
			throw task.Exception;
		}

		// Token: 0x06005E3E RID: 24126 RVA: 0x0014B26C File Offset: 0x0014946C
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OnCompletedInternal(Task task, Action continuation, bool continueOnCapturedContext, bool flowExecutionContext)
		{
			if (continuation == null)
			{
				throw new ArgumentNullException("continuation");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			if (TplEtwProvider.Log.IsEnabled() || Task.s_asyncDebuggingEnabled)
			{
				continuation = TaskAwaiter.OutputWaitEtwEvents(task, continuation);
			}
			task.SetContinuationForAwait(continuation, continueOnCapturedContext, flowExecutionContext, ref stackCrawlMark);
		}

		// Token: 0x06005E3F RID: 24127 RVA: 0x0014B2B0 File Offset: 0x001494B0
		private static Action OutputWaitEtwEvents(Task task, Action continuation)
		{
			if (Task.s_asyncDebuggingEnabled)
			{
				Task.AddToActiveTasks(task);
			}
			TplEtwProvider etwLog = TplEtwProvider.Log;
			if (etwLog.IsEnabled())
			{
				Task internalCurrent = Task.InternalCurrent;
				Task task2 = AsyncMethodBuilderCore.TryGetContinuationTask(continuation);
				etwLog.TaskWaitBegin((internalCurrent != null) ? internalCurrent.m_taskScheduler.Id : TaskScheduler.Default.Id, (internalCurrent != null) ? internalCurrent.Id : 0, task.Id, TplEtwProvider.TaskWaitBehavior.Asynchronous, (task2 != null) ? task2.Id : 0, Thread.GetDomainID());
			}
			return AsyncMethodBuilderCore.CreateContinuationWrapper(continuation, delegate
			{
				if (Task.s_asyncDebuggingEnabled)
				{
					Task.RemoveFromActiveTasks(task.Id);
				}
				Guid currentThreadActivityId = default(Guid);
				bool flag = etwLog.IsEnabled();
				if (flag)
				{
					Task internalCurrent2 = Task.InternalCurrent;
					etwLog.TaskWaitEnd((internalCurrent2 != null) ? internalCurrent2.m_taskScheduler.Id : TaskScheduler.Default.Id, (internalCurrent2 != null) ? internalCurrent2.Id : 0, task.Id);
					if (etwLog.TasksSetActivityIds && (task.Options & (TaskCreationOptions)1024) != TaskCreationOptions.None)
					{
						EventSource.SetCurrentThreadActivityId(TplEtwProvider.CreateGuidForTaskID(task.Id), out currentThreadActivityId);
					}
				}
				continuation();
				if (flag)
				{
					etwLog.TaskWaitContinuationComplete(task.Id);
					if (etwLog.TasksSetActivityIds && (task.Options & (TaskCreationOptions)1024) != TaskCreationOptions.None)
					{
						EventSource.SetCurrentThreadActivityId(currentThreadActivityId);
					}
				}
			}, null);
		}

		// Token: 0x04002A4E RID: 10830
		private readonly Task m_task;
	}
}
