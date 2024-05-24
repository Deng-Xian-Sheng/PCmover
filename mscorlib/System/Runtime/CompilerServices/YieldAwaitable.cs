using System;
using System.Diagnostics.Tracing;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F9 RID: 2297
	[__DynamicallyInvokable]
	public struct YieldAwaitable
	{
		// Token: 0x06005E49 RID: 24137 RVA: 0x0014B3F0 File Offset: 0x001495F0
		[__DynamicallyInvokable]
		public YieldAwaitable.YieldAwaiter GetAwaiter()
		{
			return default(YieldAwaitable.YieldAwaiter);
		}

		// Token: 0x02000C94 RID: 3220
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public struct YieldAwaiter : ICriticalNotifyCompletion, INotifyCompletion
		{
			// Token: 0x17001362 RID: 4962
			// (get) Token: 0x06007102 RID: 28930 RVA: 0x00185105 File Offset: 0x00183305
			[__DynamicallyInvokable]
			public bool IsCompleted
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			// Token: 0x06007103 RID: 28931 RVA: 0x00185108 File Offset: 0x00183308
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			public void OnCompleted(Action continuation)
			{
				YieldAwaitable.YieldAwaiter.QueueContinuation(continuation, true);
			}

			// Token: 0x06007104 RID: 28932 RVA: 0x00185111 File Offset: 0x00183311
			[SecurityCritical]
			[__DynamicallyInvokable]
			public void UnsafeOnCompleted(Action continuation)
			{
				YieldAwaitable.YieldAwaiter.QueueContinuation(continuation, false);
			}

			// Token: 0x06007105 RID: 28933 RVA: 0x0018511C File Offset: 0x0018331C
			[SecurityCritical]
			private static void QueueContinuation(Action continuation, bool flowContext)
			{
				if (continuation == null)
				{
					throw new ArgumentNullException("continuation");
				}
				if (TplEtwProvider.Log.IsEnabled())
				{
					continuation = YieldAwaitable.YieldAwaiter.OutputCorrelationEtwEvent(continuation);
				}
				SynchronizationContext currentNoFlow = SynchronizationContext.CurrentNoFlow;
				if (currentNoFlow != null && currentNoFlow.GetType() != typeof(SynchronizationContext))
				{
					currentNoFlow.Post(YieldAwaitable.YieldAwaiter.s_sendOrPostCallbackRunAction, continuation);
					return;
				}
				TaskScheduler taskScheduler = TaskScheduler.Current;
				if (taskScheduler != TaskScheduler.Default)
				{
					Task.Factory.StartNew(continuation, default(CancellationToken), TaskCreationOptions.PreferFairness, taskScheduler);
					return;
				}
				if (flowContext)
				{
					ThreadPool.QueueUserWorkItem(YieldAwaitable.YieldAwaiter.s_waitCallbackRunAction, continuation);
					return;
				}
				ThreadPool.UnsafeQueueUserWorkItem(YieldAwaitable.YieldAwaiter.s_waitCallbackRunAction, continuation);
			}

			// Token: 0x06007106 RID: 28934 RVA: 0x001851BC File Offset: 0x001833BC
			private static Action OutputCorrelationEtwEvent(Action continuation)
			{
				int continuationId = Task.NewId();
				Task internalCurrent = Task.InternalCurrent;
				TplEtwProvider.Log.AwaitTaskContinuationScheduled(TaskScheduler.Current.Id, (internalCurrent != null) ? internalCurrent.Id : 0, continuationId);
				return AsyncMethodBuilderCore.CreateContinuationWrapper(continuation, delegate
				{
					TplEtwProvider log = TplEtwProvider.Log;
					log.TaskWaitContinuationStarted(continuationId);
					Guid currentThreadActivityId = default(Guid);
					if (log.TasksSetActivityIds)
					{
						EventSource.SetCurrentThreadActivityId(TplEtwProvider.CreateGuidForTaskID(continuationId), out currentThreadActivityId);
					}
					continuation();
					if (log.TasksSetActivityIds)
					{
						EventSource.SetCurrentThreadActivityId(currentThreadActivityId);
					}
					log.TaskWaitContinuationComplete(continuationId);
				}, null);
			}

			// Token: 0x06007107 RID: 28935 RVA: 0x00185225 File Offset: 0x00183425
			private static void RunAction(object state)
			{
				((Action)state)();
			}

			// Token: 0x06007108 RID: 28936 RVA: 0x00185232 File Offset: 0x00183432
			[__DynamicallyInvokable]
			public void GetResult()
			{
			}

			// Token: 0x0400384B RID: 14411
			private static readonly WaitCallback s_waitCallbackRunAction = new WaitCallback(YieldAwaitable.YieldAwaiter.RunAction);

			// Token: 0x0400384C RID: 14412
			private static readonly SendOrPostCallback s_sendOrPostCallbackRunAction = new SendOrPostCallback(YieldAwaitable.YieldAwaiter.RunAction);
		}
	}
}
