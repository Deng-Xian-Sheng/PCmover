using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F1 RID: 2289
	internal struct AsyncMethodBuilderCore
	{
		// Token: 0x06005E2A RID: 24106 RVA: 0x0014AEE4 File Offset: 0x001490E4
		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			if (stateMachine == null)
			{
				throw new ArgumentNullException("stateMachine");
			}
			if (this.m_stateMachine != null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("AsyncMethodBuilder_InstanceNotInitialized"));
			}
			this.m_stateMachine = stateMachine;
		}

		// Token: 0x06005E2B RID: 24107 RVA: 0x0014AF14 File Offset: 0x00149114
		[SecuritySafeCritical]
		internal Action GetCompletionAction(Task taskForTracing, ref AsyncMethodBuilderCore.MoveNextRunner runnerToInitialize)
		{
			Debugger.NotifyOfCrossThreadDependency();
			ExecutionContext executionContext = ExecutionContext.FastCapture();
			Action action;
			AsyncMethodBuilderCore.MoveNextRunner moveNextRunner;
			if (executionContext != null && executionContext.IsPreAllocatedDefault)
			{
				action = this.m_defaultContextAction;
				if (action != null)
				{
					return action;
				}
				moveNextRunner = new AsyncMethodBuilderCore.MoveNextRunner(executionContext, this.m_stateMachine);
				action = new Action(moveNextRunner.Run);
				if (taskForTracing != null)
				{
					action = (this.m_defaultContextAction = this.OutputAsyncCausalityEvents(taskForTracing, action));
				}
				else
				{
					this.m_defaultContextAction = action;
				}
			}
			else
			{
				moveNextRunner = new AsyncMethodBuilderCore.MoveNextRunner(executionContext, this.m_stateMachine);
				action = new Action(moveNextRunner.Run);
				if (taskForTracing != null)
				{
					action = this.OutputAsyncCausalityEvents(taskForTracing, action);
				}
			}
			if (this.m_stateMachine == null)
			{
				runnerToInitialize = moveNextRunner;
			}
			return action;
		}

		// Token: 0x06005E2C RID: 24108 RVA: 0x0014AFB0 File Offset: 0x001491B0
		private Action OutputAsyncCausalityEvents(Task innerTask, Action continuation)
		{
			return AsyncMethodBuilderCore.CreateContinuationWrapper(continuation, delegate
			{
				AsyncCausalityTracer.TraceSynchronousWorkStart(CausalityTraceLevel.Required, innerTask.Id, CausalitySynchronousWork.Execution);
				continuation();
				AsyncCausalityTracer.TraceSynchronousWorkCompletion(CausalityTraceLevel.Required, CausalitySynchronousWork.Execution);
			}, innerTask);
		}

		// Token: 0x06005E2D RID: 24109 RVA: 0x0014AFF0 File Offset: 0x001491F0
		internal void PostBoxInitialization(IAsyncStateMachine stateMachine, AsyncMethodBuilderCore.MoveNextRunner runner, Task builtTask)
		{
			if (builtTask != null)
			{
				if (AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationCreation(CausalityTraceLevel.Required, builtTask.Id, "Async: " + stateMachine.GetType().Name, 0UL);
				}
				if (Task.s_asyncDebuggingEnabled)
				{
					Task.AddToActiveTasks(builtTask);
				}
			}
			this.m_stateMachine = stateMachine;
			this.m_stateMachine.SetStateMachine(this.m_stateMachine);
			runner.m_stateMachine = this.m_stateMachine;
		}

		// Token: 0x06005E2E RID: 24110 RVA: 0x0014B05C File Offset: 0x0014925C
		internal static void ThrowAsync(Exception exception, SynchronizationContext targetContext)
		{
			ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
			if (targetContext != null)
			{
				try
				{
					targetContext.Post(delegate(object state)
					{
						((ExceptionDispatchInfo)state).Throw();
					}, exceptionDispatchInfo);
					return;
				}
				catch (Exception ex)
				{
					exceptionDispatchInfo = ExceptionDispatchInfo.Capture(new AggregateException(new Exception[]
					{
						exception,
						ex
					}));
				}
			}
			if (!WindowsRuntimeMarshal.ReportUnhandledError(exceptionDispatchInfo.SourceException))
			{
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					((ExceptionDispatchInfo)state).Throw();
				}, exceptionDispatchInfo);
			}
		}

		// Token: 0x06005E2F RID: 24111 RVA: 0x0014B0FC File Offset: 0x001492FC
		internal static Action CreateContinuationWrapper(Action continuation, Action invokeAction, Task innerTask = null)
		{
			return new Action(new AsyncMethodBuilderCore.ContinuationWrapper(continuation, invokeAction, innerTask).Invoke);
		}

		// Token: 0x06005E30 RID: 24112 RVA: 0x0014B114 File Offset: 0x00149314
		internal static Action TryGetStateMachineForDebugger(Action action)
		{
			object target = action.Target;
			AsyncMethodBuilderCore.MoveNextRunner moveNextRunner = target as AsyncMethodBuilderCore.MoveNextRunner;
			if (moveNextRunner != null)
			{
				return new Action(moveNextRunner.m_stateMachine.MoveNext);
			}
			AsyncMethodBuilderCore.ContinuationWrapper continuationWrapper = target as AsyncMethodBuilderCore.ContinuationWrapper;
			if (continuationWrapper != null)
			{
				return AsyncMethodBuilderCore.TryGetStateMachineForDebugger(continuationWrapper.m_continuation);
			}
			return action;
		}

		// Token: 0x06005E31 RID: 24113 RVA: 0x0014B15C File Offset: 0x0014935C
		internal static Task TryGetContinuationTask(Action action)
		{
			if (action != null)
			{
				AsyncMethodBuilderCore.ContinuationWrapper continuationWrapper = action.Target as AsyncMethodBuilderCore.ContinuationWrapper;
				if (continuationWrapper != null)
				{
					return continuationWrapper.m_innerTask;
				}
			}
			return null;
		}

		// Token: 0x04002A4C RID: 10828
		internal IAsyncStateMachine m_stateMachine;

		// Token: 0x04002A4D RID: 10829
		internal Action m_defaultContextAction;

		// Token: 0x02000C8D RID: 3213
		internal sealed class MoveNextRunner
		{
			// Token: 0x060070EB RID: 28907 RVA: 0x00184E26 File Offset: 0x00183026
			[SecurityCritical]
			internal MoveNextRunner(ExecutionContext context, IAsyncStateMachine stateMachine)
			{
				this.m_context = context;
				this.m_stateMachine = stateMachine;
			}

			// Token: 0x060070EC RID: 28908 RVA: 0x00184E3C File Offset: 0x0018303C
			[SecuritySafeCritical]
			internal void Run()
			{
				if (this.m_context != null)
				{
					try
					{
						ContextCallback contextCallback = AsyncMethodBuilderCore.MoveNextRunner.s_invokeMoveNext;
						if (contextCallback == null)
						{
							contextCallback = (AsyncMethodBuilderCore.MoveNextRunner.s_invokeMoveNext = new ContextCallback(AsyncMethodBuilderCore.MoveNextRunner.InvokeMoveNext));
						}
						ExecutionContext.Run(this.m_context, contextCallback, this.m_stateMachine, true);
						return;
					}
					finally
					{
						this.m_context.Dispose();
					}
				}
				this.m_stateMachine.MoveNext();
			}

			// Token: 0x060070ED RID: 28909 RVA: 0x00184EAC File Offset: 0x001830AC
			[SecurityCritical]
			private static void InvokeMoveNext(object stateMachine)
			{
				((IAsyncStateMachine)stateMachine).MoveNext();
			}

			// Token: 0x04003839 RID: 14393
			private readonly ExecutionContext m_context;

			// Token: 0x0400383A RID: 14394
			internal IAsyncStateMachine m_stateMachine;

			// Token: 0x0400383B RID: 14395
			[SecurityCritical]
			private static ContextCallback s_invokeMoveNext;
		}

		// Token: 0x02000C8E RID: 3214
		private class ContinuationWrapper
		{
			// Token: 0x060070EE RID: 28910 RVA: 0x00184EB9 File Offset: 0x001830B9
			internal ContinuationWrapper(Action continuation, Action invokeAction, Task innerTask)
			{
				if (innerTask == null)
				{
					innerTask = AsyncMethodBuilderCore.TryGetContinuationTask(continuation);
				}
				this.m_continuation = continuation;
				this.m_innerTask = innerTask;
				this.m_invokeAction = invokeAction;
			}

			// Token: 0x060070EF RID: 28911 RVA: 0x00184EE1 File Offset: 0x001830E1
			internal void Invoke()
			{
				this.m_invokeAction();
			}

			// Token: 0x0400383C RID: 14396
			internal readonly Action m_continuation;

			// Token: 0x0400383D RID: 14397
			private readonly Action m_invokeAction;

			// Token: 0x0400383E RID: 14398
			internal readonly Task m_innerTask;
		}
	}
}
