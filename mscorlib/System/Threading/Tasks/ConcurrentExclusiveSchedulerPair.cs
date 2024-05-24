using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x02000580 RID: 1408
	[DebuggerDisplay("Concurrent={ConcurrentTaskCountForDebugger}, Exclusive={ExclusiveTaskCountForDebugger}, Mode={ModeForDebugger}")]
	[DebuggerTypeProxy(typeof(ConcurrentExclusiveSchedulerPair.DebugView))]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class ConcurrentExclusiveSchedulerPair
	{
		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06004243 RID: 16963 RVA: 0x000F6B64 File Offset: 0x000F4D64
		private static int DefaultMaxConcurrencyLevel
		{
			get
			{
				return Environment.ProcessorCount;
			}
		}

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06004244 RID: 16964 RVA: 0x000F6B6B File Offset: 0x000F4D6B
		private object ValueLock
		{
			get
			{
				return this.m_threadProcessingMapping;
			}
		}

		// Token: 0x06004245 RID: 16965 RVA: 0x000F6B73 File Offset: 0x000F4D73
		[__DynamicallyInvokable]
		public ConcurrentExclusiveSchedulerPair() : this(TaskScheduler.Default, ConcurrentExclusiveSchedulerPair.DefaultMaxConcurrencyLevel, -1)
		{
		}

		// Token: 0x06004246 RID: 16966 RVA: 0x000F6B86 File Offset: 0x000F4D86
		[__DynamicallyInvokable]
		public ConcurrentExclusiveSchedulerPair(TaskScheduler taskScheduler) : this(taskScheduler, ConcurrentExclusiveSchedulerPair.DefaultMaxConcurrencyLevel, -1)
		{
		}

		// Token: 0x06004247 RID: 16967 RVA: 0x000F6B95 File Offset: 0x000F4D95
		[__DynamicallyInvokable]
		public ConcurrentExclusiveSchedulerPair(TaskScheduler taskScheduler, int maxConcurrencyLevel) : this(taskScheduler, maxConcurrencyLevel, -1)
		{
		}

		// Token: 0x06004248 RID: 16968 RVA: 0x000F6BA0 File Offset: 0x000F4DA0
		[__DynamicallyInvokable]
		public ConcurrentExclusiveSchedulerPair(TaskScheduler taskScheduler, int maxConcurrencyLevel, int maxItemsPerTask)
		{
			if (taskScheduler == null)
			{
				throw new ArgumentNullException("taskScheduler");
			}
			if (maxConcurrencyLevel == 0 || maxConcurrencyLevel < -1)
			{
				throw new ArgumentOutOfRangeException("maxConcurrencyLevel");
			}
			if (maxItemsPerTask == 0 || maxItemsPerTask < -1)
			{
				throw new ArgumentOutOfRangeException("maxItemsPerTask");
			}
			this.m_underlyingTaskScheduler = taskScheduler;
			this.m_maxConcurrencyLevel = maxConcurrencyLevel;
			this.m_maxItemsPerTask = maxItemsPerTask;
			int maximumConcurrencyLevel = taskScheduler.MaximumConcurrencyLevel;
			if (maximumConcurrencyLevel > 0 && maximumConcurrencyLevel < this.m_maxConcurrencyLevel)
			{
				this.m_maxConcurrencyLevel = maximumConcurrencyLevel;
			}
			if (this.m_maxConcurrencyLevel == -1)
			{
				this.m_maxConcurrencyLevel = int.MaxValue;
			}
			if (this.m_maxItemsPerTask == -1)
			{
				this.m_maxItemsPerTask = int.MaxValue;
			}
			this.m_exclusiveTaskScheduler = new ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler(this, 1, ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingExclusiveTask);
			this.m_concurrentTaskScheduler = new ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler(this, this.m_maxConcurrencyLevel, ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingConcurrentTasks);
		}

		// Token: 0x06004249 RID: 16969 RVA: 0x000F6C6C File Offset: 0x000F4E6C
		[__DynamicallyInvokable]
		public void Complete()
		{
			object valueLock = this.ValueLock;
			lock (valueLock)
			{
				if (!this.CompletionRequested)
				{
					this.RequestCompletion();
					this.CleanupStateIfCompletingAndQuiesced();
				}
			}
		}

		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x0600424A RID: 16970 RVA: 0x000F6CBC File Offset: 0x000F4EBC
		[__DynamicallyInvokable]
		public Task Completion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.EnsureCompletionStateInitialized().Task;
			}
		}

		// Token: 0x0600424B RID: 16971 RVA: 0x000F6CC9 File Offset: 0x000F4EC9
		private ConcurrentExclusiveSchedulerPair.CompletionState EnsureCompletionStateInitialized()
		{
			return LazyInitializer.EnsureInitialized<ConcurrentExclusiveSchedulerPair.CompletionState>(ref this.m_completionState, () => new ConcurrentExclusiveSchedulerPair.CompletionState());
		}

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x0600424C RID: 16972 RVA: 0x000F6CF5 File Offset: 0x000F4EF5
		private bool CompletionRequested
		{
			get
			{
				return this.m_completionState != null && Volatile.Read(ref this.m_completionState.m_completionRequested);
			}
		}

		// Token: 0x0600424D RID: 16973 RVA: 0x000F6D11 File Offset: 0x000F4F11
		private void RequestCompletion()
		{
			this.EnsureCompletionStateInitialized().m_completionRequested = true;
		}

		// Token: 0x0600424E RID: 16974 RVA: 0x000F6D1F File Offset: 0x000F4F1F
		private void CleanupStateIfCompletingAndQuiesced()
		{
			if (this.ReadyToComplete)
			{
				this.CompleteTaskAsync();
			}
		}

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x0600424F RID: 16975 RVA: 0x000F6D30 File Offset: 0x000F4F30
		private bool ReadyToComplete
		{
			get
			{
				if (!this.CompletionRequested || this.m_processingCount != 0)
				{
					return false;
				}
				ConcurrentExclusiveSchedulerPair.CompletionState completionState = this.EnsureCompletionStateInitialized();
				return (completionState.m_exceptions != null && completionState.m_exceptions.Count > 0) || (this.m_concurrentTaskScheduler.m_tasks.IsEmpty && this.m_exclusiveTaskScheduler.m_tasks.IsEmpty);
			}
		}

		// Token: 0x06004250 RID: 16976 RVA: 0x000F6D94 File Offset: 0x000F4F94
		private void CompleteTaskAsync()
		{
			ConcurrentExclusiveSchedulerPair.CompletionState completionState = this.EnsureCompletionStateInitialized();
			if (!completionState.m_completionQueued)
			{
				completionState.m_completionQueued = true;
				ThreadPool.QueueUserWorkItem(delegate(object state)
				{
					ConcurrentExclusiveSchedulerPair.CompletionState completionState2 = (ConcurrentExclusiveSchedulerPair.CompletionState)state;
					List<Exception> exceptions = completionState2.m_exceptions;
					if (exceptions == null || exceptions.Count <= 0)
					{
						completionState2.TrySetResult(default(VoidTaskResult));
					}
					else
					{
						completionState2.TrySetException(exceptions);
					}
				}, completionState);
			}
		}

		// Token: 0x06004251 RID: 16977 RVA: 0x000F6DE0 File Offset: 0x000F4FE0
		private void FaultWithTask(Task faultedTask)
		{
			ConcurrentExclusiveSchedulerPair.CompletionState completionState = this.EnsureCompletionStateInitialized();
			if (completionState.m_exceptions == null)
			{
				completionState.m_exceptions = new List<Exception>();
			}
			completionState.m_exceptions.AddRange(faultedTask.Exception.InnerExceptions);
			this.RequestCompletion();
		}

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06004252 RID: 16978 RVA: 0x000F6E23 File Offset: 0x000F5023
		[__DynamicallyInvokable]
		public TaskScheduler ConcurrentScheduler
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_concurrentTaskScheduler;
			}
		}

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06004253 RID: 16979 RVA: 0x000F6E2B File Offset: 0x000F502B
		[__DynamicallyInvokable]
		public TaskScheduler ExclusiveScheduler
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_exclusiveTaskScheduler;
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x06004254 RID: 16980 RVA: 0x000F6E33 File Offset: 0x000F5033
		private int ConcurrentTaskCountForDebugger
		{
			get
			{
				return this.m_concurrentTaskScheduler.m_tasks.Count;
			}
		}

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06004255 RID: 16981 RVA: 0x000F6E45 File Offset: 0x000F5045
		private int ExclusiveTaskCountForDebugger
		{
			get
			{
				return this.m_exclusiveTaskScheduler.m_tasks.Count;
			}
		}

		// Token: 0x06004256 RID: 16982 RVA: 0x000F6E58 File Offset: 0x000F5058
		private void ProcessAsyncIfNecessary(bool fairly = false)
		{
			if (this.m_processingCount >= 0)
			{
				bool flag = !this.m_exclusiveTaskScheduler.m_tasks.IsEmpty;
				Task task = null;
				if (this.m_processingCount == 0 && flag)
				{
					this.m_processingCount = -1;
					try
					{
						task = new Task(delegate(object thisPair)
						{
							((ConcurrentExclusiveSchedulerPair)thisPair).ProcessExclusiveTasks();
						}, this, default(CancellationToken), ConcurrentExclusiveSchedulerPair.GetCreationOptionsForTask(fairly));
						task.Start(this.m_underlyingTaskScheduler);
						goto IL_149;
					}
					catch
					{
						this.m_processingCount = 0;
						this.FaultWithTask(task);
						goto IL_149;
					}
				}
				int count = this.m_concurrentTaskScheduler.m_tasks.Count;
				if (count > 0 && !flag && this.m_processingCount < this.m_maxConcurrencyLevel)
				{
					int num = 0;
					while (num < count && this.m_processingCount < this.m_maxConcurrencyLevel)
					{
						this.m_processingCount++;
						try
						{
							task = new Task(delegate(object thisPair)
							{
								((ConcurrentExclusiveSchedulerPair)thisPair).ProcessConcurrentTasks();
							}, this, default(CancellationToken), ConcurrentExclusiveSchedulerPair.GetCreationOptionsForTask(fairly));
							task.Start(this.m_underlyingTaskScheduler);
						}
						catch
						{
							this.m_processingCount--;
							this.FaultWithTask(task);
						}
						num++;
					}
				}
				IL_149:
				this.CleanupStateIfCompletingAndQuiesced();
			}
		}

		// Token: 0x06004257 RID: 16983 RVA: 0x000F6FD0 File Offset: 0x000F51D0
		private void ProcessExclusiveTasks()
		{
			try
			{
				this.m_threadProcessingMapping[Thread.CurrentThread.ManagedThreadId] = ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingExclusiveTask;
				for (int i = 0; i < this.m_maxItemsPerTask; i++)
				{
					Task task;
					if (!this.m_exclusiveTaskScheduler.m_tasks.TryDequeue(out task))
					{
						break;
					}
					if (!task.IsFaulted)
					{
						this.m_exclusiveTaskScheduler.ExecuteTask(task);
					}
				}
			}
			finally
			{
				ConcurrentExclusiveSchedulerPair.ProcessingMode processingMode;
				this.m_threadProcessingMapping.TryRemove(Thread.CurrentThread.ManagedThreadId, out processingMode);
				object valueLock = this.ValueLock;
				lock (valueLock)
				{
					this.m_processingCount = 0;
					this.ProcessAsyncIfNecessary(true);
				}
			}
		}

		// Token: 0x06004258 RID: 16984 RVA: 0x000F7094 File Offset: 0x000F5294
		private void ProcessConcurrentTasks()
		{
			try
			{
				this.m_threadProcessingMapping[Thread.CurrentThread.ManagedThreadId] = ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingConcurrentTasks;
				for (int i = 0; i < this.m_maxItemsPerTask; i++)
				{
					Task task;
					if (!this.m_concurrentTaskScheduler.m_tasks.TryDequeue(out task))
					{
						break;
					}
					if (!task.IsFaulted)
					{
						this.m_concurrentTaskScheduler.ExecuteTask(task);
					}
					if (!this.m_exclusiveTaskScheduler.m_tasks.IsEmpty)
					{
						break;
					}
				}
			}
			finally
			{
				ConcurrentExclusiveSchedulerPair.ProcessingMode processingMode;
				this.m_threadProcessingMapping.TryRemove(Thread.CurrentThread.ManagedThreadId, out processingMode);
				object valueLock = this.ValueLock;
				lock (valueLock)
				{
					if (this.m_processingCount > 0)
					{
						this.m_processingCount--;
					}
					this.ProcessAsyncIfNecessary(true);
				}
			}
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06004259 RID: 16985 RVA: 0x000F7180 File Offset: 0x000F5380
		private ConcurrentExclusiveSchedulerPair.ProcessingMode ModeForDebugger
		{
			get
			{
				if (this.m_completionState != null && this.m_completionState.Task.IsCompleted)
				{
					return ConcurrentExclusiveSchedulerPair.ProcessingMode.Completed;
				}
				ConcurrentExclusiveSchedulerPair.ProcessingMode processingMode = ConcurrentExclusiveSchedulerPair.ProcessingMode.NotCurrentlyProcessing;
				if (this.m_processingCount == -1)
				{
					processingMode |= ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingExclusiveTask;
				}
				if (this.m_processingCount >= 1)
				{
					processingMode |= ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingConcurrentTasks;
				}
				if (this.CompletionRequested)
				{
					processingMode |= ConcurrentExclusiveSchedulerPair.ProcessingMode.Completing;
				}
				return processingMode;
			}
		}

		// Token: 0x0600425A RID: 16986 RVA: 0x000F71D2 File Offset: 0x000F53D2
		[Conditional("DEBUG")]
		internal static void ContractAssertMonitorStatus(object syncObj, bool held)
		{
		}

		// Token: 0x0600425B RID: 16987 RVA: 0x000F71D4 File Offset: 0x000F53D4
		internal static TaskCreationOptions GetCreationOptionsForTask(bool isReplacementReplica = false)
		{
			TaskCreationOptions taskCreationOptions = TaskCreationOptions.DenyChildAttach;
			if (isReplacementReplica)
			{
				taskCreationOptions |= TaskCreationOptions.PreferFairness;
			}
			return taskCreationOptions;
		}

		// Token: 0x04001B89 RID: 7049
		private readonly ConcurrentDictionary<int, ConcurrentExclusiveSchedulerPair.ProcessingMode> m_threadProcessingMapping = new ConcurrentDictionary<int, ConcurrentExclusiveSchedulerPair.ProcessingMode>();

		// Token: 0x04001B8A RID: 7050
		private readonly ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler m_concurrentTaskScheduler;

		// Token: 0x04001B8B RID: 7051
		private readonly ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler m_exclusiveTaskScheduler;

		// Token: 0x04001B8C RID: 7052
		private readonly TaskScheduler m_underlyingTaskScheduler;

		// Token: 0x04001B8D RID: 7053
		private readonly int m_maxConcurrencyLevel;

		// Token: 0x04001B8E RID: 7054
		private readonly int m_maxItemsPerTask;

		// Token: 0x04001B8F RID: 7055
		private int m_processingCount;

		// Token: 0x04001B90 RID: 7056
		private ConcurrentExclusiveSchedulerPair.CompletionState m_completionState;

		// Token: 0x04001B91 RID: 7057
		private const int UNLIMITED_PROCESSING = -1;

		// Token: 0x04001B92 RID: 7058
		private const int EXCLUSIVE_PROCESSING_SENTINEL = -1;

		// Token: 0x04001B93 RID: 7059
		private const int DEFAULT_MAXITEMSPERTASK = -1;

		// Token: 0x02000C24 RID: 3108
		private sealed class CompletionState : TaskCompletionSource<VoidTaskResult>
		{
			// Token: 0x040036DA RID: 14042
			internal bool m_completionRequested;

			// Token: 0x040036DB RID: 14043
			internal bool m_completionQueued;

			// Token: 0x040036DC RID: 14044
			internal List<Exception> m_exceptions;
		}

		// Token: 0x02000C25 RID: 3109
		[DebuggerDisplay("Count={CountForDebugger}, MaxConcurrencyLevel={m_maxConcurrencyLevel}, Id={Id}")]
		[DebuggerTypeProxy(typeof(ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler.DebugView))]
		private sealed class ConcurrentExclusiveTaskScheduler : TaskScheduler
		{
			// Token: 0x06007008 RID: 28680 RVA: 0x00182718 File Offset: 0x00180918
			internal ConcurrentExclusiveTaskScheduler(ConcurrentExclusiveSchedulerPair pair, int maxConcurrencyLevel, ConcurrentExclusiveSchedulerPair.ProcessingMode processingMode)
			{
				this.m_pair = pair;
				this.m_maxConcurrencyLevel = maxConcurrencyLevel;
				this.m_processingMode = processingMode;
				IProducerConsumerQueue<Task> tasks;
				if (processingMode != ConcurrentExclusiveSchedulerPair.ProcessingMode.ProcessingExclusiveTask)
				{
					IProducerConsumerQueue<Task> producerConsumerQueue = new MultiProducerMultiConsumerQueue<Task>();
					tasks = producerConsumerQueue;
				}
				else
				{
					IProducerConsumerQueue<Task> producerConsumerQueue = new SingleProducerSingleConsumerQueue<Task>();
					tasks = producerConsumerQueue;
				}
				this.m_tasks = tasks;
			}

			// Token: 0x17001330 RID: 4912
			// (get) Token: 0x06007009 RID: 28681 RVA: 0x0018275A File Offset: 0x0018095A
			public override int MaximumConcurrencyLevel
			{
				get
				{
					return this.m_maxConcurrencyLevel;
				}
			}

			// Token: 0x0600700A RID: 28682 RVA: 0x00182764 File Offset: 0x00180964
			[SecurityCritical]
			protected internal override void QueueTask(Task task)
			{
				object valueLock = this.m_pair.ValueLock;
				lock (valueLock)
				{
					if (this.m_pair.CompletionRequested)
					{
						throw new InvalidOperationException(base.GetType().Name);
					}
					this.m_tasks.Enqueue(task);
					this.m_pair.ProcessAsyncIfNecessary(false);
				}
			}

			// Token: 0x0600700B RID: 28683 RVA: 0x001827DC File Offset: 0x001809DC
			[SecuritySafeCritical]
			internal void ExecuteTask(Task task)
			{
				base.TryExecuteTask(task);
			}

			// Token: 0x0600700C RID: 28684 RVA: 0x001827E8 File Offset: 0x001809E8
			[SecurityCritical]
			protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
			{
				if (!taskWasPreviouslyQueued && this.m_pair.CompletionRequested)
				{
					return false;
				}
				bool flag = this.m_pair.m_underlyingTaskScheduler == TaskScheduler.Default;
				if (flag && taskWasPreviouslyQueued && !Thread.CurrentThread.IsThreadPoolThread)
				{
					return false;
				}
				ConcurrentExclusiveSchedulerPair.ProcessingMode processingMode;
				if (!this.m_pair.m_threadProcessingMapping.TryGetValue(Thread.CurrentThread.ManagedThreadId, out processingMode) || processingMode != this.m_processingMode)
				{
					return false;
				}
				if (!flag || taskWasPreviouslyQueued)
				{
					return this.TryExecuteTaskInlineOnTargetScheduler(task);
				}
				return base.TryExecuteTask(task);
			}

			// Token: 0x0600700D RID: 28685 RVA: 0x0018286C File Offset: 0x00180A6C
			private bool TryExecuteTaskInlineOnTargetScheduler(Task task)
			{
				Task<bool> task2 = new Task<bool>(ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler.s_tryExecuteTaskShim, Tuple.Create<ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler, Task>(this, task));
				bool result;
				try
				{
					task2.RunSynchronously(this.m_pair.m_underlyingTaskScheduler);
					result = task2.Result;
				}
				catch
				{
					AggregateException exception = task2.Exception;
					throw;
				}
				finally
				{
					task2.Dispose();
				}
				return result;
			}

			// Token: 0x0600700E RID: 28686 RVA: 0x001828D4 File Offset: 0x00180AD4
			[SecuritySafeCritical]
			private static bool TryExecuteTaskShim(object state)
			{
				Tuple<ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler, Task> tuple = (Tuple<ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler, Task>)state;
				return tuple.Item1.TryExecuteTask(tuple.Item2);
			}

			// Token: 0x0600700F RID: 28687 RVA: 0x001828F9 File Offset: 0x00180AF9
			[SecurityCritical]
			protected override IEnumerable<Task> GetScheduledTasks()
			{
				return this.m_tasks;
			}

			// Token: 0x17001331 RID: 4913
			// (get) Token: 0x06007010 RID: 28688 RVA: 0x00182901 File Offset: 0x00180B01
			private int CountForDebugger
			{
				get
				{
					return this.m_tasks.Count;
				}
			}

			// Token: 0x040036DD RID: 14045
			private static readonly Func<object, bool> s_tryExecuteTaskShim = new Func<object, bool>(ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler.TryExecuteTaskShim);

			// Token: 0x040036DE RID: 14046
			private readonly ConcurrentExclusiveSchedulerPair m_pair;

			// Token: 0x040036DF RID: 14047
			private readonly int m_maxConcurrencyLevel;

			// Token: 0x040036E0 RID: 14048
			private readonly ConcurrentExclusiveSchedulerPair.ProcessingMode m_processingMode;

			// Token: 0x040036E1 RID: 14049
			internal readonly IProducerConsumerQueue<Task> m_tasks;

			// Token: 0x02000D0C RID: 3340
			private sealed class DebugView
			{
				// Token: 0x0600721B RID: 29211 RVA: 0x0018954D File Offset: 0x0018774D
				public DebugView(ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler scheduler)
				{
					this.m_taskScheduler = scheduler;
				}

				// Token: 0x17001390 RID: 5008
				// (get) Token: 0x0600721C RID: 29212 RVA: 0x0018955C File Offset: 0x0018775C
				public int MaximumConcurrencyLevel
				{
					get
					{
						return this.m_taskScheduler.m_maxConcurrencyLevel;
					}
				}

				// Token: 0x17001391 RID: 5009
				// (get) Token: 0x0600721D RID: 29213 RVA: 0x00189569 File Offset: 0x00187769
				public IEnumerable<Task> ScheduledTasks
				{
					get
					{
						return this.m_taskScheduler.m_tasks;
					}
				}

				// Token: 0x17001392 RID: 5010
				// (get) Token: 0x0600721E RID: 29214 RVA: 0x00189576 File Offset: 0x00187776
				public ConcurrentExclusiveSchedulerPair SchedulerPair
				{
					get
					{
						return this.m_taskScheduler.m_pair;
					}
				}

				// Token: 0x04003958 RID: 14680
				private readonly ConcurrentExclusiveSchedulerPair.ConcurrentExclusiveTaskScheduler m_taskScheduler;
			}
		}

		// Token: 0x02000C26 RID: 3110
		private sealed class DebugView
		{
			// Token: 0x06007012 RID: 28690 RVA: 0x00182921 File Offset: 0x00180B21
			public DebugView(ConcurrentExclusiveSchedulerPair pair)
			{
				this.m_pair = pair;
			}

			// Token: 0x17001332 RID: 4914
			// (get) Token: 0x06007013 RID: 28691 RVA: 0x00182930 File Offset: 0x00180B30
			public ConcurrentExclusiveSchedulerPair.ProcessingMode Mode
			{
				get
				{
					return this.m_pair.ModeForDebugger;
				}
			}

			// Token: 0x17001333 RID: 4915
			// (get) Token: 0x06007014 RID: 28692 RVA: 0x0018293D File Offset: 0x00180B3D
			public IEnumerable<Task> ScheduledExclusive
			{
				get
				{
					return this.m_pair.m_exclusiveTaskScheduler.m_tasks;
				}
			}

			// Token: 0x17001334 RID: 4916
			// (get) Token: 0x06007015 RID: 28693 RVA: 0x0018294F File Offset: 0x00180B4F
			public IEnumerable<Task> ScheduledConcurrent
			{
				get
				{
					return this.m_pair.m_concurrentTaskScheduler.m_tasks;
				}
			}

			// Token: 0x17001335 RID: 4917
			// (get) Token: 0x06007016 RID: 28694 RVA: 0x00182961 File Offset: 0x00180B61
			public int CurrentlyExecutingTaskCount
			{
				get
				{
					if (this.m_pair.m_processingCount != -1)
					{
						return this.m_pair.m_processingCount;
					}
					return 1;
				}
			}

			// Token: 0x17001336 RID: 4918
			// (get) Token: 0x06007017 RID: 28695 RVA: 0x0018297E File Offset: 0x00180B7E
			public TaskScheduler TargetScheduler
			{
				get
				{
					return this.m_pair.m_underlyingTaskScheduler;
				}
			}

			// Token: 0x040036E2 RID: 14050
			private readonly ConcurrentExclusiveSchedulerPair m_pair;
		}

		// Token: 0x02000C27 RID: 3111
		[Flags]
		private enum ProcessingMode : byte
		{
			// Token: 0x040036E4 RID: 14052
			NotCurrentlyProcessing = 0,
			// Token: 0x040036E5 RID: 14053
			ProcessingExclusiveTask = 1,
			// Token: 0x040036E6 RID: 14054
			ProcessingConcurrentTasks = 2,
			// Token: 0x040036E7 RID: 14055
			Completing = 4,
			// Token: 0x040036E8 RID: 14056
			Completed = 8
		}
	}
}
