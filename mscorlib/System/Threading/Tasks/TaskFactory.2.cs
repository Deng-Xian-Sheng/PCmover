using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x02000575 RID: 1397
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class TaskFactory
	{
		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x060041A1 RID: 16801 RVA: 0x000F5115 File Offset: 0x000F3315
		private TaskScheduler DefaultScheduler
		{
			get
			{
				if (this.m_defaultScheduler == null)
				{
					return TaskScheduler.Current;
				}
				return this.m_defaultScheduler;
			}
		}

		// Token: 0x060041A2 RID: 16802 RVA: 0x000F512B File Offset: 0x000F332B
		private TaskScheduler GetDefaultScheduler(Task currTask)
		{
			if (this.m_defaultScheduler != null)
			{
				return this.m_defaultScheduler;
			}
			if (currTask != null && (currTask.CreationOptions & TaskCreationOptions.HideScheduler) == TaskCreationOptions.None)
			{
				return currTask.ExecutingTaskScheduler;
			}
			return TaskScheduler.Default;
		}

		// Token: 0x060041A3 RID: 16803 RVA: 0x000F5158 File Offset: 0x000F3358
		[__DynamicallyInvokable]
		public TaskFactory() : this(default(CancellationToken), TaskCreationOptions.None, TaskContinuationOptions.None, null)
		{
		}

		// Token: 0x060041A4 RID: 16804 RVA: 0x000F5177 File Offset: 0x000F3377
		[__DynamicallyInvokable]
		public TaskFactory(CancellationToken cancellationToken) : this(cancellationToken, TaskCreationOptions.None, TaskContinuationOptions.None, null)
		{
		}

		// Token: 0x060041A5 RID: 16805 RVA: 0x000F5184 File Offset: 0x000F3384
		[__DynamicallyInvokable]
		public TaskFactory(TaskScheduler scheduler) : this(default(CancellationToken), TaskCreationOptions.None, TaskContinuationOptions.None, scheduler)
		{
		}

		// Token: 0x060041A6 RID: 16806 RVA: 0x000F51A4 File Offset: 0x000F33A4
		[__DynamicallyInvokable]
		public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions) : this(default(CancellationToken), creationOptions, continuationOptions, null)
		{
		}

		// Token: 0x060041A7 RID: 16807 RVA: 0x000F51C3 File Offset: 0x000F33C3
		[__DynamicallyInvokable]
		public TaskFactory(CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			TaskFactory.CheckMultiTaskContinuationOptions(continuationOptions);
			TaskFactory.CheckCreationOptions(creationOptions);
			this.m_defaultCancellationToken = cancellationToken;
			this.m_defaultScheduler = scheduler;
			this.m_defaultCreationOptions = creationOptions;
			this.m_defaultContinuationOptions = continuationOptions;
		}

		// Token: 0x060041A8 RID: 16808 RVA: 0x000F51F4 File Offset: 0x000F33F4
		internal static void CheckCreationOptions(TaskCreationOptions creationOptions)
		{
			if ((creationOptions & ~(TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent | TaskCreationOptions.DenyChildAttach | TaskCreationOptions.HideScheduler | TaskCreationOptions.RunContinuationsAsynchronously)) != TaskCreationOptions.None)
			{
				throw new ArgumentOutOfRangeException("creationOptions");
			}
		}

		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x060041A9 RID: 16809 RVA: 0x000F5207 File Offset: 0x000F3407
		[__DynamicallyInvokable]
		public CancellationToken CancellationToken
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultCancellationToken;
			}
		}

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x060041AA RID: 16810 RVA: 0x000F520F File Offset: 0x000F340F
		[__DynamicallyInvokable]
		public TaskScheduler Scheduler
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultScheduler;
			}
		}

		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x060041AB RID: 16811 RVA: 0x000F5217 File Offset: 0x000F3417
		[__DynamicallyInvokable]
		public TaskCreationOptions CreationOptions
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultCreationOptions;
			}
		}

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x060041AC RID: 16812 RVA: 0x000F521F File Offset: 0x000F341F
		[__DynamicallyInvokable]
		public TaskContinuationOptions ContinuationOptions
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultContinuationOptions;
			}
		}

		// Token: 0x060041AD RID: 16813 RVA: 0x000F5228 File Offset: 0x000F3428
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action action)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task.InternalStartNew(internalCurrent, action, null, this.m_defaultCancellationToken, this.GetDefaultScheduler(internalCurrent), this.m_defaultCreationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041AE RID: 16814 RVA: 0x000F525C File Offset: 0x000F345C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action action, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task.InternalStartNew(internalCurrent, action, null, cancellationToken, this.GetDefaultScheduler(internalCurrent), this.m_defaultCreationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041AF RID: 16815 RVA: 0x000F528C File Offset: 0x000F348C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action action, TaskCreationOptions creationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task.InternalStartNew(internalCurrent, action, null, this.m_defaultCancellationToken, this.GetDefaultScheduler(internalCurrent), creationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041B0 RID: 16816 RVA: 0x000F52BC File Offset: 0x000F34BC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return Task.InternalStartNew(Task.InternalCurrentIfAttached(creationOptions), action, null, cancellationToken, scheduler, creationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041B1 RID: 16817 RVA: 0x000F52E0 File Offset: 0x000F34E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal Task StartNew(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return Task.InternalStartNew(Task.InternalCurrentIfAttached(creationOptions), action, null, cancellationToken, scheduler, creationOptions, internalOptions, ref stackCrawlMark);
		}

		// Token: 0x060041B2 RID: 16818 RVA: 0x000F5304 File Offset: 0x000F3504
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action<object> action, object state)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task.InternalStartNew(internalCurrent, action, state, this.m_defaultCancellationToken, this.GetDefaultScheduler(internalCurrent), this.m_defaultCreationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041B3 RID: 16819 RVA: 0x000F5338 File Offset: 0x000F3538
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action<object> action, object state, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task.InternalStartNew(internalCurrent, action, state, cancellationToken, this.GetDefaultScheduler(internalCurrent), this.m_defaultCreationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041B4 RID: 16820 RVA: 0x000F5368 File Offset: 0x000F3568
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action<object> action, object state, TaskCreationOptions creationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task.InternalStartNew(internalCurrent, action, state, this.m_defaultCancellationToken, this.GetDefaultScheduler(internalCurrent), creationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041B5 RID: 16821 RVA: 0x000F5398 File Offset: 0x000F3598
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task StartNew(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return Task.InternalStartNew(Task.InternalCurrentIfAttached(creationOptions), action, state, cancellationToken, scheduler, creationOptions, InternalTaskOptions.None, ref stackCrawlMark);
		}

		// Token: 0x060041B6 RID: 16822 RVA: 0x000F53C0 File Offset: 0x000F35C0
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<TResult> function)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task<TResult>.StartNew(internalCurrent, function, this.m_defaultCancellationToken, this.m_defaultCreationOptions, InternalTaskOptions.None, this.GetDefaultScheduler(internalCurrent), ref stackCrawlMark);
		}

		// Token: 0x060041B7 RID: 16823 RVA: 0x000F53F4 File Offset: 0x000F35F4
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<TResult> function, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task<TResult>.StartNew(internalCurrent, function, cancellationToken, this.m_defaultCreationOptions, InternalTaskOptions.None, this.GetDefaultScheduler(internalCurrent), ref stackCrawlMark);
		}

		// Token: 0x060041B8 RID: 16824 RVA: 0x000F5424 File Offset: 0x000F3624
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<TResult> function, TaskCreationOptions creationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task<TResult>.StartNew(internalCurrent, function, this.m_defaultCancellationToken, creationOptions, InternalTaskOptions.None, this.GetDefaultScheduler(internalCurrent), ref stackCrawlMark);
		}

		// Token: 0x060041B9 RID: 16825 RVA: 0x000F5454 File Offset: 0x000F3654
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return Task<TResult>.StartNew(Task.InternalCurrentIfAttached(creationOptions), function, cancellationToken, creationOptions, InternalTaskOptions.None, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041BA RID: 16826 RVA: 0x000F5478 File Offset: 0x000F3678
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task<TResult>.StartNew(internalCurrent, function, state, this.m_defaultCancellationToken, this.m_defaultCreationOptions, InternalTaskOptions.None, this.GetDefaultScheduler(internalCurrent), ref stackCrawlMark);
		}

		// Token: 0x060041BB RID: 16827 RVA: 0x000F54AC File Offset: 0x000F36AC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task<TResult>.StartNew(internalCurrent, function, state, cancellationToken, this.m_defaultCreationOptions, InternalTaskOptions.None, this.GetDefaultScheduler(internalCurrent), ref stackCrawlMark);
		}

		// Token: 0x060041BC RID: 16828 RVA: 0x000F54DC File Offset: 0x000F36DC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, TaskCreationOptions creationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			Task internalCurrent = Task.InternalCurrent;
			return Task<TResult>.StartNew(internalCurrent, function, state, this.m_defaultCancellationToken, creationOptions, InternalTaskOptions.None, this.GetDefaultScheduler(internalCurrent), ref stackCrawlMark);
		}

		// Token: 0x060041BD RID: 16829 RVA: 0x000F550C File Offset: 0x000F370C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return Task<TResult>.StartNew(Task.InternalCurrentIfAttached(creationOptions), function, state, cancellationToken, creationOptions, InternalTaskOptions.None, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041BE RID: 16830 RVA: 0x000F5534 File Offset: 0x000F3734
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.FromAsync(asyncResult, endMethod, this.m_defaultCreationOptions, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041BF RID: 16831 RVA: 0x000F555C File Offset: 0x000F375C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.FromAsync(asyncResult, endMethod, creationOptions, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041C0 RID: 16832 RVA: 0x000F557C File Offset: 0x000F377C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.FromAsync(asyncResult, endMethod, creationOptions, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041C1 RID: 16833 RVA: 0x000F5598 File Offset: 0x000F3798
		private Task FromAsync(IAsyncResult asyncResult, Action<IAsyncResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler, ref StackCrawlMark stackMark)
		{
			return TaskFactory<VoidTaskResult>.FromAsyncImpl(asyncResult, null, endMethod, creationOptions, scheduler, ref stackMark);
		}

		// Token: 0x060041C2 RID: 16834 RVA: 0x000F55A7 File Offset: 0x000F37A7
		[__DynamicallyInvokable]
		public Task FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, object state)
		{
			return this.FromAsync(beginMethod, endMethod, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041C3 RID: 16835 RVA: 0x000F55B8 File Offset: 0x000F37B8
		[__DynamicallyInvokable]
		public Task FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<VoidTaskResult>.FromAsyncImpl(beginMethod, null, endMethod, state, creationOptions);
		}

		// Token: 0x060041C4 RID: 16836 RVA: 0x000F55C5 File Offset: 0x000F37C5
		[__DynamicallyInvokable]
		public Task FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state)
		{
			return this.FromAsync<TArg1>(beginMethod, endMethod, arg1, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041C5 RID: 16837 RVA: 0x000F55D8 File Offset: 0x000F37D8
		[__DynamicallyInvokable]
		public Task FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<VoidTaskResult>.FromAsyncImpl<TArg1>(beginMethod, null, endMethod, arg1, state, creationOptions);
		}

		// Token: 0x060041C6 RID: 16838 RVA: 0x000F55E7 File Offset: 0x000F37E7
		[__DynamicallyInvokable]
		public Task FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state)
		{
			return this.FromAsync<TArg1, TArg2>(beginMethod, endMethod, arg1, arg2, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041C7 RID: 16839 RVA: 0x000F55FC File Offset: 0x000F37FC
		[__DynamicallyInvokable]
		public Task FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<VoidTaskResult>.FromAsyncImpl<TArg1, TArg2>(beginMethod, null, endMethod, arg1, arg2, state, creationOptions);
		}

		// Token: 0x060041C8 RID: 16840 RVA: 0x000F560D File Offset: 0x000F380D
		[__DynamicallyInvokable]
		public Task FromAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state)
		{
			return this.FromAsync<TArg1, TArg2, TArg3>(beginMethod, endMethod, arg1, arg2, arg3, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041C9 RID: 16841 RVA: 0x000F5624 File Offset: 0x000F3824
		[__DynamicallyInvokable]
		public Task FromAsync<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<VoidTaskResult>.FromAsyncImpl<TArg1, TArg2, TArg3>(beginMethod, null, endMethod, arg1, arg2, arg3, state, creationOptions);
		}

		// Token: 0x060041CA RID: 16842 RVA: 0x000F5638 File Offset: 0x000F3838
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.FromAsyncImpl(asyncResult, endMethod, null, this.m_defaultCreationOptions, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041CB RID: 16843 RVA: 0x000F5660 File Offset: 0x000F3860
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.FromAsyncImpl(asyncResult, endMethod, null, creationOptions, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041CC RID: 16844 RVA: 0x000F5680 File Offset: 0x000F3880
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.FromAsyncImpl(asyncResult, endMethod, null, creationOptions, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041CD RID: 16845 RVA: 0x000F569C File Offset: 0x000F389C
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TResult>(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state)
		{
			return TaskFactory<TResult>.FromAsyncImpl(beginMethod, endMethod, null, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041CE RID: 16846 RVA: 0x000F56AD File Offset: 0x000F38AD
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TResult>(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<TResult>.FromAsyncImpl(beginMethod, endMethod, null, state, creationOptions);
		}

		// Token: 0x060041CF RID: 16847 RVA: 0x000F56BA File Offset: 0x000F38BA
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TArg1, TResult>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state)
		{
			return TaskFactory<TResult>.FromAsyncImpl<TArg1>(beginMethod, endMethod, null, arg1, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041D0 RID: 16848 RVA: 0x000F56CD File Offset: 0x000F38CD
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TArg1, TResult>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<TResult>.FromAsyncImpl<TArg1>(beginMethod, endMethod, null, arg1, state, creationOptions);
		}

		// Token: 0x060041D1 RID: 16849 RVA: 0x000F56DC File Offset: 0x000F38DC
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TArg1, TArg2, TResult>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state)
		{
			return TaskFactory<TResult>.FromAsyncImpl<TArg1, TArg2>(beginMethod, endMethod, null, arg1, arg2, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041D2 RID: 16850 RVA: 0x000F56F1 File Offset: 0x000F38F1
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TArg1, TArg2, TResult>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<TResult>.FromAsyncImpl<TArg1, TArg2>(beginMethod, endMethod, null, arg1, arg2, state, creationOptions);
		}

		// Token: 0x060041D3 RID: 16851 RVA: 0x000F5702 File Offset: 0x000F3902
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state)
		{
			return TaskFactory<TResult>.FromAsyncImpl<TArg1, TArg2, TArg3>(beginMethod, endMethod, null, arg1, arg2, arg3, state, this.m_defaultCreationOptions);
		}

		// Token: 0x060041D4 RID: 16852 RVA: 0x000F5719 File Offset: 0x000F3919
		[__DynamicallyInvokable]
		public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions)
		{
			return TaskFactory<TResult>.FromAsyncImpl<TArg1, TArg2, TArg3>(beginMethod, endMethod, null, arg1, arg2, arg3, state, creationOptions);
		}

		// Token: 0x060041D5 RID: 16853 RVA: 0x000F572C File Offset: 0x000F392C
		internal static void CheckFromAsyncOptions(TaskCreationOptions creationOptions, bool hasBeginMethod)
		{
			if (hasBeginMethod)
			{
				if ((creationOptions & TaskCreationOptions.LongRunning) != TaskCreationOptions.None)
				{
					throw new ArgumentOutOfRangeException("creationOptions", Environment.GetResourceString("Task_FromAsync_LongRunning"));
				}
				if ((creationOptions & TaskCreationOptions.PreferFairness) != TaskCreationOptions.None)
				{
					throw new ArgumentOutOfRangeException("creationOptions", Environment.GetResourceString("Task_FromAsync_PreferFairness"));
				}
			}
			if ((creationOptions & ~(TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent | TaskCreationOptions.DenyChildAttach | TaskCreationOptions.HideScheduler)) != TaskCreationOptions.None)
			{
				throw new ArgumentOutOfRangeException("creationOptions");
			}
		}

		// Token: 0x060041D6 RID: 16854 RVA: 0x000F5784 File Offset: 0x000F3984
		internal static Task<Task[]> CommonCWAllLogic(Task[] tasksCopy)
		{
			TaskFactory.CompleteOnCountdownPromise completeOnCountdownPromise = new TaskFactory.CompleteOnCountdownPromise(tasksCopy);
			for (int i = 0; i < tasksCopy.Length; i++)
			{
				if (tasksCopy[i].IsCompleted)
				{
					completeOnCountdownPromise.Invoke(tasksCopy[i]);
				}
				else
				{
					tasksCopy[i].AddCompletionAction(completeOnCountdownPromise);
				}
			}
			return completeOnCountdownPromise;
		}

		// Token: 0x060041D7 RID: 16855 RVA: 0x000F57C8 File Offset: 0x000F39C8
		internal static Task<Task<T>[]> CommonCWAllLogic<T>(Task<T>[] tasksCopy)
		{
			TaskFactory.CompleteOnCountdownPromise<T> completeOnCountdownPromise = new TaskFactory.CompleteOnCountdownPromise<T>(tasksCopy);
			for (int i = 0; i < tasksCopy.Length; i++)
			{
				if (tasksCopy[i].IsCompleted)
				{
					completeOnCountdownPromise.Invoke(tasksCopy[i]);
				}
				else
				{
					tasksCopy[i].AddCompletionAction(completeOnCountdownPromise);
				}
			}
			return completeOnCountdownPromise;
		}

		// Token: 0x060041D8 RID: 16856 RVA: 0x000F580C File Offset: 0x000F3A0C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl(tasks, null, continuationAction, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041D9 RID: 16857 RVA: 0x000F5848 File Offset: 0x000F3A48
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction, CancellationToken cancellationToken)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl(tasks, null, continuationAction, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041DA RID: 16858 RVA: 0x000F587C File Offset: 0x000F3A7C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction, TaskContinuationOptions continuationOptions)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl(tasks, null, continuationAction, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041DB RID: 16859 RVA: 0x000F58B0 File Offset: 0x000F3AB0
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll(Task[] tasks, Action<Task[]> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl(tasks, null, continuationAction, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041DC RID: 16860 RVA: 0x000F58DC File Offset: 0x000F3ADC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, null, continuationAction, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041DD RID: 16861 RVA: 0x000F5918 File Offset: 0x000F3B18
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction, CancellationToken cancellationToken)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, null, continuationAction, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041DE RID: 16862 RVA: 0x000F594C File Offset: 0x000F3B4C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction, TaskContinuationOptions continuationOptions)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, null, continuationAction, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041DF RID: 16863 RVA: 0x000F5980 File Offset: 0x000F3B80
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>[]> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, null, continuationAction, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E0 RID: 16864 RVA: 0x000F59AC File Offset: 0x000F3BAC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl(tasks, continuationFunction, null, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E1 RID: 16865 RVA: 0x000F59E8 File Offset: 0x000F3BE8
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction, CancellationToken cancellationToken)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl(tasks, continuationFunction, null, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E2 RID: 16866 RVA: 0x000F5A1C File Offset: 0x000F3C1C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl(tasks, continuationFunction, null, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E3 RID: 16867 RVA: 0x000F5A50 File Offset: 0x000F3C50
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, Func<Task[], TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl(tasks, continuationFunction, null, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E4 RID: 16868 RVA: 0x000F5A7C File Offset: 0x000F3C7C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, continuationFunction, null, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E5 RID: 16869 RVA: 0x000F5AB8 File Offset: 0x000F3CB8
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, CancellationToken cancellationToken)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, continuationFunction, null, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E6 RID: 16870 RVA: 0x000F5AEC File Offset: 0x000F3CEC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, continuationFunction, null, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E7 RID: 16871 RVA: 0x000F5B20 File Offset: 0x000F3D20
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>[], TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAllImpl<TAntecedentResult>(tasks, continuationFunction, null, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041E8 RID: 16872 RVA: 0x000F5B4C File Offset: 0x000F3D4C
		internal static Task<Task> CommonCWAnyLogic(IList<Task> tasks)
		{
			TaskFactory.CompleteOnInvokePromise completeOnInvokePromise = new TaskFactory.CompleteOnInvokePromise(tasks);
			bool flag = false;
			int count = tasks.Count;
			for (int i = 0; i < count; i++)
			{
				Task task = tasks[i];
				if (task == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Task_MultiTaskContinuation_NullTask"), "tasks");
				}
				if (!flag)
				{
					if (completeOnInvokePromise.IsCompleted)
					{
						flag = true;
					}
					else if (task.IsCompleted)
					{
						completeOnInvokePromise.Invoke(task);
						flag = true;
					}
					else
					{
						task.AddCompletionAction(completeOnInvokePromise);
						if (completeOnInvokePromise.IsCompleted)
						{
							task.RemoveContinuation(completeOnInvokePromise);
						}
					}
				}
			}
			return completeOnInvokePromise;
		}

		// Token: 0x060041E9 RID: 16873 RVA: 0x000F5BD4 File Offset: 0x000F3DD4
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl(tasks, null, continuationAction, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041EA RID: 16874 RVA: 0x000F5C10 File Offset: 0x000F3E10
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction, CancellationToken cancellationToken)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl(tasks, null, continuationAction, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041EB RID: 16875 RVA: 0x000F5C44 File Offset: 0x000F3E44
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction, TaskContinuationOptions continuationOptions)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl(tasks, null, continuationAction, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041EC RID: 16876 RVA: 0x000F5C78 File Offset: 0x000F3E78
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny(Task[] tasks, Action<Task> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl(tasks, null, continuationAction, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041ED RID: 16877 RVA: 0x000F5CA4 File Offset: 0x000F3EA4
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl(tasks, continuationFunction, null, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041EE RID: 16878 RVA: 0x000F5CE0 File Offset: 0x000F3EE0
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction, CancellationToken cancellationToken)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl(tasks, continuationFunction, null, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041EF RID: 16879 RVA: 0x000F5D14 File Offset: 0x000F3F14
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl(tasks, continuationFunction, null, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F0 RID: 16880 RVA: 0x000F5D48 File Offset: 0x000F3F48
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, Func<Task, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl(tasks, continuationFunction, null, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F1 RID: 16881 RVA: 0x000F5D74 File Offset: 0x000F3F74
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			return TaskFactory<TResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, continuationFunction, null, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F2 RID: 16882 RVA: 0x000F5DB0 File Offset: 0x000F3FB0
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, CancellationToken cancellationToken)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, continuationFunction, null, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F3 RID: 16883 RVA: 0x000F5DE4 File Offset: 0x000F3FE4
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, continuationFunction, null, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F4 RID: 16884 RVA: 0x000F5E18 File Offset: 0x000F4018
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, Func<Task<TAntecedentResult>, TResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<TResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, continuationFunction, null, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F5 RID: 16885 RVA: 0x000F5E44 File Offset: 0x000F4044
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, null, continuationAction, this.m_defaultContinuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F6 RID: 16886 RVA: 0x000F5E80 File Offset: 0x000F4080
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction, CancellationToken cancellationToken)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, null, continuationAction, this.m_defaultContinuationOptions, cancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F7 RID: 16887 RVA: 0x000F5EB4 File Offset: 0x000F40B4
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction, TaskContinuationOptions continuationOptions)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, null, continuationAction, continuationOptions, this.m_defaultCancellationToken, this.DefaultScheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F8 RID: 16888 RVA: 0x000F5EE8 File Offset: 0x000F40E8
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, Action<Task<TAntecedentResult>> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TaskFactory<VoidTaskResult>.ContinueWhenAnyImpl<TAntecedentResult>(tasks, null, continuationAction, continuationOptions, cancellationToken, scheduler, ref stackCrawlMark);
		}

		// Token: 0x060041F9 RID: 16889 RVA: 0x000F5F14 File Offset: 0x000F4114
		internal static Task[] CheckMultiContinuationTasksAndCopy(Task[] tasks)
		{
			if (tasks == null)
			{
				throw new ArgumentNullException("tasks");
			}
			if (tasks.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Task_MultiTaskContinuation_EmptyTaskList"), "tasks");
			}
			Task[] array = new Task[tasks.Length];
			for (int i = 0; i < tasks.Length; i++)
			{
				array[i] = tasks[i];
				if (array[i] == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Task_MultiTaskContinuation_NullTask"), "tasks");
				}
			}
			return array;
		}

		// Token: 0x060041FA RID: 16890 RVA: 0x000F5F80 File Offset: 0x000F4180
		internal static Task<TResult>[] CheckMultiContinuationTasksAndCopy<TResult>(Task<TResult>[] tasks)
		{
			if (tasks == null)
			{
				throw new ArgumentNullException("tasks");
			}
			if (tasks.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Task_MultiTaskContinuation_EmptyTaskList"), "tasks");
			}
			Task<TResult>[] array = new Task<TResult>[tasks.Length];
			for (int i = 0; i < tasks.Length; i++)
			{
				array[i] = tasks[i];
				if (array[i] == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Task_MultiTaskContinuation_NullTask"), "tasks");
				}
			}
			return array;
		}

		// Token: 0x060041FB RID: 16891 RVA: 0x000F5FEC File Offset: 0x000F41EC
		internal static void CheckMultiTaskContinuationOptions(TaskContinuationOptions continuationOptions)
		{
			if ((continuationOptions & (TaskContinuationOptions.LongRunning | TaskContinuationOptions.ExecuteSynchronously)) == (TaskContinuationOptions.LongRunning | TaskContinuationOptions.ExecuteSynchronously))
			{
				throw new ArgumentOutOfRangeException("continuationOptions", Environment.GetResourceString("Task_ContinueWith_ESandLR"));
			}
			if ((continuationOptions & ~(TaskContinuationOptions.PreferFairness | TaskContinuationOptions.LongRunning | TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.HideScheduler | TaskContinuationOptions.LazyCancellation | TaskContinuationOptions.NotOnRanToCompletion | TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.ExecuteSynchronously)) != TaskContinuationOptions.None)
			{
				throw new ArgumentOutOfRangeException("continuationOptions");
			}
			if ((continuationOptions & (TaskContinuationOptions.NotOnRanToCompletion | TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.NotOnCanceled)) != TaskContinuationOptions.None)
			{
				throw new ArgumentOutOfRangeException("continuationOptions", Environment.GetResourceString("Task_MultiTaskContinuation_FireOptions"));
			}
		}

		// Token: 0x04001B62 RID: 7010
		private CancellationToken m_defaultCancellationToken;

		// Token: 0x04001B63 RID: 7011
		private TaskScheduler m_defaultScheduler;

		// Token: 0x04001B64 RID: 7012
		private TaskCreationOptions m_defaultCreationOptions;

		// Token: 0x04001B65 RID: 7013
		private TaskContinuationOptions m_defaultContinuationOptions;

		// Token: 0x02000C1E RID: 3102
		private sealed class CompleteOnCountdownPromise : Task<Task[]>, ITaskCompletionAction
		{
			// Token: 0x06006FF3 RID: 28659 RVA: 0x001822F9 File Offset: 0x001804F9
			internal CompleteOnCountdownPromise(Task[] tasksCopy)
			{
				this._tasks = tasksCopy;
				this._count = tasksCopy.Length;
				if (AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationCreation(CausalityTraceLevel.Required, base.Id, "TaskFactory.ContinueWhenAll", 0UL);
				}
				if (Task.s_asyncDebuggingEnabled)
				{
					Task.AddToActiveTasks(this);
				}
			}

			// Token: 0x06006FF4 RID: 28660 RVA: 0x0018233C File Offset: 0x0018053C
			public void Invoke(Task completingTask)
			{
				if (AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationRelation(CausalityTraceLevel.Important, base.Id, CausalityRelation.Join);
				}
				if (completingTask.IsWaitNotificationEnabled)
				{
					base.SetNotificationForWaitCompletion(true);
				}
				if (Interlocked.Decrement(ref this._count) == 0)
				{
					if (AsyncCausalityTracer.LoggingOn)
					{
						AsyncCausalityTracer.TraceOperationCompletion(CausalityTraceLevel.Required, base.Id, AsyncCausalityStatus.Completed);
					}
					if (Task.s_asyncDebuggingEnabled)
					{
						Task.RemoveFromActiveTasks(base.Id);
					}
					base.TrySetResult(this._tasks);
				}
			}

			// Token: 0x1700132A RID: 4906
			// (get) Token: 0x06006FF5 RID: 28661 RVA: 0x001823AC File Offset: 0x001805AC
			internal override bool ShouldNotifyDebuggerOfWaitCompletion
			{
				get
				{
					return base.ShouldNotifyDebuggerOfWaitCompletion && Task.AnyTaskRequiresNotifyDebuggerOfWaitCompletion(this._tasks);
				}
			}

			// Token: 0x040036CA RID: 14026
			private readonly Task[] _tasks;

			// Token: 0x040036CB RID: 14027
			private int _count;
		}

		// Token: 0x02000C1F RID: 3103
		private sealed class CompleteOnCountdownPromise<T> : Task<Task<T>[]>, ITaskCompletionAction
		{
			// Token: 0x06006FF6 RID: 28662 RVA: 0x001823C3 File Offset: 0x001805C3
			internal CompleteOnCountdownPromise(Task<T>[] tasksCopy)
			{
				this._tasks = tasksCopy;
				this._count = tasksCopy.Length;
				if (AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationCreation(CausalityTraceLevel.Required, base.Id, "TaskFactory.ContinueWhenAll<>", 0UL);
				}
				if (Task.s_asyncDebuggingEnabled)
				{
					Task.AddToActiveTasks(this);
				}
			}

			// Token: 0x06006FF7 RID: 28663 RVA: 0x00182404 File Offset: 0x00180604
			public void Invoke(Task completingTask)
			{
				if (AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationRelation(CausalityTraceLevel.Important, base.Id, CausalityRelation.Join);
				}
				if (completingTask.IsWaitNotificationEnabled)
				{
					base.SetNotificationForWaitCompletion(true);
				}
				if (Interlocked.Decrement(ref this._count) == 0)
				{
					if (AsyncCausalityTracer.LoggingOn)
					{
						AsyncCausalityTracer.TraceOperationCompletion(CausalityTraceLevel.Required, base.Id, AsyncCausalityStatus.Completed);
					}
					if (Task.s_asyncDebuggingEnabled)
					{
						Task.RemoveFromActiveTasks(base.Id);
					}
					base.TrySetResult(this._tasks);
				}
			}

			// Token: 0x1700132B RID: 4907
			// (get) Token: 0x06006FF8 RID: 28664 RVA: 0x00182474 File Offset: 0x00180674
			internal override bool ShouldNotifyDebuggerOfWaitCompletion
			{
				get
				{
					if (base.ShouldNotifyDebuggerOfWaitCompletion)
					{
						Task[] tasks = this._tasks;
						return Task.AnyTaskRequiresNotifyDebuggerOfWaitCompletion(tasks);
					}
					return false;
				}
			}

			// Token: 0x040036CC RID: 14028
			private readonly Task<T>[] _tasks;

			// Token: 0x040036CD RID: 14029
			private int _count;
		}

		// Token: 0x02000C20 RID: 3104
		internal sealed class CompleteOnInvokePromise : Task<Task>, ITaskCompletionAction
		{
			// Token: 0x06006FF9 RID: 28665 RVA: 0x00182498 File Offset: 0x00180698
			public CompleteOnInvokePromise(IList<Task> tasks)
			{
				this._tasks = tasks;
				if (AsyncCausalityTracer.LoggingOn)
				{
					AsyncCausalityTracer.TraceOperationCreation(CausalityTraceLevel.Required, base.Id, "TaskFactory.ContinueWhenAny", 0UL);
				}
				if (Task.s_asyncDebuggingEnabled)
				{
					Task.AddToActiveTasks(this);
				}
			}

			// Token: 0x06006FFA RID: 28666 RVA: 0x001824D0 File Offset: 0x001806D0
			public void Invoke(Task completingTask)
			{
				if (Interlocked.CompareExchange(ref this.m_firstTaskAlreadyCompleted, 1, 0) == 0)
				{
					if (AsyncCausalityTracer.LoggingOn)
					{
						AsyncCausalityTracer.TraceOperationRelation(CausalityTraceLevel.Important, base.Id, CausalityRelation.Choice);
						AsyncCausalityTracer.TraceOperationCompletion(CausalityTraceLevel.Required, base.Id, AsyncCausalityStatus.Completed);
					}
					if (Task.s_asyncDebuggingEnabled)
					{
						Task.RemoveFromActiveTasks(base.Id);
					}
					bool flag = base.TrySetResult(completingTask);
					IList<Task> tasks = this._tasks;
					int count = tasks.Count;
					for (int i = 0; i < count; i++)
					{
						Task task = tasks[i];
						if (task != null && !task.IsCompleted)
						{
							task.RemoveContinuation(this);
						}
					}
					this._tasks = null;
				}
			}

			// Token: 0x040036CE RID: 14030
			private IList<Task> _tasks;

			// Token: 0x040036CF RID: 14031
			private int m_firstTaskAlreadyCompleted;
		}
	}
}
