using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x0200054B RID: 1355
	[DebuggerTypeProxy(typeof(SystemThreadingTasks_FutureDebugView<>))]
	[DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}, Result = {DebuggerDisplayResultDescription}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class Task<TResult> : Task
	{
		// Token: 0x06003F8B RID: 16267 RVA: 0x000EC5A5 File Offset: 0x000EA7A5
		internal Task()
		{
		}

		// Token: 0x06003F8C RID: 16268 RVA: 0x000EC5AD File Offset: 0x000EA7AD
		internal Task(object state, TaskCreationOptions options) : base(state, options, true)
		{
		}

		// Token: 0x06003F8D RID: 16269 RVA: 0x000EC5B8 File Offset: 0x000EA7B8
		internal Task(TResult result) : base(false, TaskCreationOptions.None, default(CancellationToken))
		{
			this.m_result = result;
		}

		// Token: 0x06003F8E RID: 16270 RVA: 0x000EC5DD File Offset: 0x000EA7DD
		internal Task(bool canceled, TResult result, TaskCreationOptions creationOptions, CancellationToken ct) : base(canceled, creationOptions, ct)
		{
			if (!canceled)
			{
				this.m_result = result;
			}
		}

		// Token: 0x06003F8F RID: 16271 RVA: 0x000EC5F4 File Offset: 0x000EA7F4
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<TResult> function) : this(function, null, default(CancellationToken), TaskCreationOptions.None, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F90 RID: 16272 RVA: 0x000EC620 File Offset: 0x000EA820
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<TResult> function, CancellationToken cancellationToken) : this(function, null, cancellationToken, TaskCreationOptions.None, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F91 RID: 16273 RVA: 0x000EC644 File Offset: 0x000EA844
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<TResult> function, TaskCreationOptions creationOptions) : this(function, Task.InternalCurrentIfAttached(creationOptions), default(CancellationToken), creationOptions, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F92 RID: 16274 RVA: 0x000EC674 File Offset: 0x000EA874
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : this(function, Task.InternalCurrentIfAttached(creationOptions), cancellationToken, creationOptions, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F93 RID: 16275 RVA: 0x000EC69C File Offset: 0x000EA89C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<object, TResult> function, object state) : this(function, state, null, default(CancellationToken), TaskCreationOptions.None, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F94 RID: 16276 RVA: 0x000EC6C8 File Offset: 0x000EA8C8
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken) : this(function, state, null, cancellationToken, TaskCreationOptions.None, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F95 RID: 16277 RVA: 0x000EC6EC File Offset: 0x000EA8EC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<object, TResult> function, object state, TaskCreationOptions creationOptions) : this(function, state, Task.InternalCurrentIfAttached(creationOptions), default(CancellationToken), creationOptions, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F96 RID: 16278 RVA: 0x000EC720 File Offset: 0x000EA920
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : this(function, state, Task.InternalCurrentIfAttached(creationOptions), cancellationToken, creationOptions, InternalTaskOptions.None, null)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			base.PossiblyCaptureContext(ref stackCrawlMark);
		}

		// Token: 0x06003F97 RID: 16279 RVA: 0x000EC74B File Offset: 0x000EA94B
		internal Task(Func<TResult> valueSelector, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler, ref StackCrawlMark stackMark) : this(valueSelector, parent, cancellationToken, creationOptions, internalOptions, scheduler)
		{
			base.PossiblyCaptureContext(ref stackMark);
		}

		// Token: 0x06003F98 RID: 16280 RVA: 0x000EC764 File Offset: 0x000EA964
		internal Task(Func<TResult> valueSelector, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler) : base(valueSelector, null, parent, cancellationToken, creationOptions, internalOptions, scheduler)
		{
			if ((internalOptions & InternalTaskOptions.SelfReplicating) != InternalTaskOptions.None)
			{
				throw new ArgumentOutOfRangeException("creationOptions", Environment.GetResourceString("TaskT_ctor_SelfReplicating"));
			}
		}

		// Token: 0x06003F99 RID: 16281 RVA: 0x000EC795 File Offset: 0x000EA995
		internal Task(Func<object, TResult> valueSelector, object state, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler, ref StackCrawlMark stackMark) : this(valueSelector, state, parent, cancellationToken, creationOptions, internalOptions, scheduler)
		{
			base.PossiblyCaptureContext(ref stackMark);
		}

		// Token: 0x06003F9A RID: 16282 RVA: 0x000EC7B0 File Offset: 0x000EA9B0
		internal Task(Delegate valueSelector, object state, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler) : base(valueSelector, state, parent, cancellationToken, creationOptions, internalOptions, scheduler)
		{
			if ((internalOptions & InternalTaskOptions.SelfReplicating) != InternalTaskOptions.None)
			{
				throw new ArgumentOutOfRangeException("creationOptions", Environment.GetResourceString("TaskT_ctor_SelfReplicating"));
			}
		}

		// Token: 0x06003F9B RID: 16283 RVA: 0x000EC7E4 File Offset: 0x000EA9E4
		internal static Task<TResult> StartNew(Task parent, Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler, ref StackCrawlMark stackMark)
		{
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			if ((internalOptions & InternalTaskOptions.SelfReplicating) != InternalTaskOptions.None)
			{
				throw new ArgumentOutOfRangeException("creationOptions", Environment.GetResourceString("TaskT_ctor_SelfReplicating"));
			}
			Task<TResult> task = new Task<TResult>(function, parent, cancellationToken, creationOptions, internalOptions | InternalTaskOptions.QueuedByRuntime, scheduler, ref stackMark);
			task.ScheduleAndStart(false);
			return task;
		}

		// Token: 0x06003F9C RID: 16284 RVA: 0x000EC84C File Offset: 0x000EAA4C
		internal static Task<TResult> StartNew(Task parent, Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler, ref StackCrawlMark stackMark)
		{
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			if ((internalOptions & InternalTaskOptions.SelfReplicating) != InternalTaskOptions.None)
			{
				throw new ArgumentOutOfRangeException("creationOptions", Environment.GetResourceString("TaskT_ctor_SelfReplicating"));
			}
			Task<TResult> task = new Task<TResult>(function, state, parent, cancellationToken, creationOptions, internalOptions | InternalTaskOptions.QueuedByRuntime, scheduler, ref stackMark);
			task.ScheduleAndStart(false);
			return task;
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06003F9D RID: 16285 RVA: 0x000EC8B8 File Offset: 0x000EAAB8
		private string DebuggerDisplayResultDescription
		{
			get
			{
				if (!base.IsRanToCompletion)
				{
					return Environment.GetResourceString("TaskT_DebuggerNoResult");
				}
				TResult result = this.m_result;
				return ((result != null) ? result.ToString() : null) ?? "";
			}
		}

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06003F9E RID: 16286 RVA: 0x000EC900 File Offset: 0x000EAB00
		private string DebuggerDisplayMethodDescription
		{
			get
			{
				Delegate @delegate = (Delegate)this.m_action;
				if (@delegate == null)
				{
					return "{null}";
				}
				return @delegate.Method.ToString();
			}
		}

		// Token: 0x06003F9F RID: 16287 RVA: 0x000EC930 File Offset: 0x000EAB30
		internal bool TrySetResult(TResult result)
		{
			if (base.IsCompleted)
			{
				return false;
			}
			if (base.AtomicStateUpdate(67108864, 90177536))
			{
				this.m_result = result;
				Interlocked.Exchange(ref this.m_stateFlags, this.m_stateFlags | 16777216);
				Task.ContingentProperties contingentProperties = this.m_contingentProperties;
				if (contingentProperties != null)
				{
					contingentProperties.SetCompleted();
				}
				base.FinishStageThree();
				return true;
			}
			return false;
		}

		// Token: 0x06003FA0 RID: 16288 RVA: 0x000EC998 File Offset: 0x000EAB98
		internal void DangerousSetResult(TResult result)
		{
			if (this.m_parent != null)
			{
				bool flag = this.TrySetResult(result);
				return;
			}
			this.m_result = result;
			this.m_stateFlags |= 16777216;
		}

		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x06003FA1 RID: 16289 RVA: 0x000EC9D3 File Offset: 0x000EABD3
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[__DynamicallyInvokable]
		public TResult Result
		{
			[__DynamicallyInvokable]
			get
			{
				if (!base.IsWaitNotificationEnabledOrNotRanToCompletion)
				{
					return this.m_result;
				}
				return this.GetResultCore(true);
			}
		}

		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x06003FA2 RID: 16290 RVA: 0x000EC9EB File Offset: 0x000EABEB
		internal TResult ResultOnSuccess
		{
			get
			{
				return this.m_result;
			}
		}

		// Token: 0x06003FA3 RID: 16291 RVA: 0x000EC9F4 File Offset: 0x000EABF4
		internal TResult GetResultCore(bool waitCompletionNotification)
		{
			if (!base.IsCompleted)
			{
				base.InternalWait(-1, default(CancellationToken));
			}
			if (waitCompletionNotification)
			{
				base.NotifyDebuggerOfWaitCompletionIfNecessary();
			}
			if (!base.IsRanToCompletion)
			{
				base.ThrowIfExceptional(true);
			}
			return this.m_result;
		}

		// Token: 0x06003FA4 RID: 16292 RVA: 0x000ECA3C File Offset: 0x000EAC3C
		internal bool TrySetException(object exceptionObject)
		{
			bool result = false;
			base.EnsureContingentPropertiesInitialized(true);
			if (base.AtomicStateUpdate(67108864, 90177536))
			{
				base.AddException(exceptionObject);
				base.Finish(false);
				result = true;
			}
			return result;
		}

		// Token: 0x06003FA5 RID: 16293 RVA: 0x000ECA76 File Offset: 0x000EAC76
		internal bool TrySetCanceled(CancellationToken tokenToRecord)
		{
			return this.TrySetCanceled(tokenToRecord, null);
		}

		// Token: 0x06003FA6 RID: 16294 RVA: 0x000ECA80 File Offset: 0x000EAC80
		internal bool TrySetCanceled(CancellationToken tokenToRecord, object cancellationException)
		{
			bool result = false;
			if (base.AtomicStateUpdate(67108864, 90177536))
			{
				base.RecordInternalCancellationRequest(tokenToRecord, cancellationException);
				base.CancellationCleanupLogic();
				result = true;
			}
			return result;
		}

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x06003FA7 RID: 16295 RVA: 0x000ECAB2 File Offset: 0x000EACB2
		[__DynamicallyInvokable]
		public new static TaskFactory<TResult> Factory
		{
			[__DynamicallyInvokable]
			get
			{
				return Task<TResult>.s_Factory;
			}
		}

		// Token: 0x06003FA8 RID: 16296 RVA: 0x000ECABC File Offset: 0x000EACBC
		internal override void InnerInvoke()
		{
			Func<TResult> func = this.m_action as Func<TResult>;
			if (func != null)
			{
				this.m_result = func();
				return;
			}
			Func<object, TResult> func2 = this.m_action as Func<object, TResult>;
			if (func2 != null)
			{
				this.m_result = func2(this.m_stateObject);
				return;
			}
		}

		// Token: 0x06003FA9 RID: 16297 RVA: 0x000ECB07 File Offset: 0x000EAD07
		[__DynamicallyInvokable]
		public new TaskAwaiter<TResult> GetAwaiter()
		{
			return new TaskAwaiter<TResult>(this);
		}

		// Token: 0x06003FAA RID: 16298 RVA: 0x000ECB0F File Offset: 0x000EAD0F
		[__DynamicallyInvokable]
		public new ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext)
		{
			return new ConfiguredTaskAwaitable<TResult>(this, continueOnCapturedContext);
		}

		// Token: 0x06003FAB RID: 16299 RVA: 0x000ECB18 File Offset: 0x000EAD18
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>> continuationAction)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, TaskScheduler.Current, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FAC RID: 16300 RVA: 0x000ECB40 File Offset: 0x000EAD40
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, TaskScheduler.Current, cancellationToken, TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FAD RID: 16301 RVA: 0x000ECB60 File Offset: 0x000EAD60
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, scheduler, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FAE RID: 16302 RVA: 0x000ECB84 File Offset: 0x000EAD84
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskContinuationOptions continuationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, TaskScheduler.Current, default(CancellationToken), continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FAF RID: 16303 RVA: 0x000ECBAC File Offset: 0x000EADAC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>> continuationAction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, scheduler, cancellationToken, continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FB0 RID: 16304 RVA: 0x000ECBC8 File Offset: 0x000EADC8
		internal Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, ref StackCrawlMark stackMark)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			TaskCreationOptions creationOptions;
			InternalTaskOptions internalOptions;
			Task.CreationOptionsFromContinuationOptions(continuationOptions, out creationOptions, out internalOptions);
			Task task = new ContinuationTaskFromResultTask<TResult>(this, continuationAction, null, creationOptions, internalOptions, ref stackMark);
			base.ContinueWithCore(task, scheduler, cancellationToken, continuationOptions);
			return task;
		}

		// Token: 0x06003FB1 RID: 16305 RVA: 0x000ECC18 File Offset: 0x000EAE18
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, state, TaskScheduler.Current, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FB2 RID: 16306 RVA: 0x000ECC40 File Offset: 0x000EAE40
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, state, TaskScheduler.Current, cancellationToken, TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FB3 RID: 16307 RVA: 0x000ECC60 File Offset: 0x000EAE60
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, state, scheduler, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FB4 RID: 16308 RVA: 0x000ECC84 File Offset: 0x000EAE84
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskContinuationOptions continuationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, state, TaskScheduler.Current, default(CancellationToken), continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FB5 RID: 16309 RVA: 0x000ECCAC File Offset: 0x000EAEAC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith(continuationAction, state, scheduler, cancellationToken, continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FB6 RID: 16310 RVA: 0x000ECCCC File Offset: 0x000EAECC
		internal Task ContinueWith(Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, ref StackCrawlMark stackMark)
		{
			if (continuationAction == null)
			{
				throw new ArgumentNullException("continuationAction");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			TaskCreationOptions creationOptions;
			InternalTaskOptions internalOptions;
			Task.CreationOptionsFromContinuationOptions(continuationOptions, out creationOptions, out internalOptions);
			Task task = new ContinuationTaskFromResultTask<TResult>(this, continuationAction, state, creationOptions, internalOptions, ref stackMark);
			base.ContinueWithCore(task, scheduler, cancellationToken, continuationOptions);
			return task;
		}

		// Token: 0x06003FB7 RID: 16311 RVA: 0x000ECD1C File Offset: 0x000EAF1C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, TaskScheduler.Current, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FB8 RID: 16312 RVA: 0x000ECD44 File Offset: 0x000EAF44
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, TaskScheduler.Current, cancellationToken, TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FB9 RID: 16313 RVA: 0x000ECD64 File Offset: 0x000EAF64
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, scheduler, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FBA RID: 16314 RVA: 0x000ECD88 File Offset: 0x000EAF88
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, TaskScheduler.Current, default(CancellationToken), continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FBB RID: 16315 RVA: 0x000ECDB0 File Offset: 0x000EAFB0
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, scheduler, cancellationToken, continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FBC RID: 16316 RVA: 0x000ECDCC File Offset: 0x000EAFCC
		internal Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, ref StackCrawlMark stackMark)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			TaskCreationOptions creationOptions;
			InternalTaskOptions internalOptions;
			Task.CreationOptionsFromContinuationOptions(continuationOptions, out creationOptions, out internalOptions);
			Task<TNewResult> task = new ContinuationResultTaskFromResultTask<TResult, TNewResult>(this, continuationFunction, null, creationOptions, internalOptions, ref stackMark);
			base.ContinueWithCore(task, scheduler, cancellationToken, continuationOptions);
			return task;
		}

		// Token: 0x06003FBD RID: 16317 RVA: 0x000ECE1C File Offset: 0x000EB01C
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, state, TaskScheduler.Current, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FBE RID: 16318 RVA: 0x000ECE44 File Offset: 0x000EB044
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, state, TaskScheduler.Current, cancellationToken, TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FBF RID: 16319 RVA: 0x000ECE64 File Offset: 0x000EB064
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, state, scheduler, default(CancellationToken), TaskContinuationOptions.None, ref stackCrawlMark);
		}

		// Token: 0x06003FC0 RID: 16320 RVA: 0x000ECE88 File Offset: 0x000EB088
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskContinuationOptions continuationOptions)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, state, TaskScheduler.Current, default(CancellationToken), continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FC1 RID: 16321 RVA: 0x000ECEB0 File Offset: 0x000EB0B0
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return this.ContinueWith<TNewResult>(continuationFunction, state, scheduler, cancellationToken, continuationOptions, ref stackCrawlMark);
		}

		// Token: 0x06003FC2 RID: 16322 RVA: 0x000ECED0 File Offset: 0x000EB0D0
		internal Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, ref StackCrawlMark stackMark)
		{
			if (continuationFunction == null)
			{
				throw new ArgumentNullException("continuationFunction");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			TaskCreationOptions creationOptions;
			InternalTaskOptions internalOptions;
			Task.CreationOptionsFromContinuationOptions(continuationOptions, out creationOptions, out internalOptions);
			Task<TNewResult> task = new ContinuationResultTaskFromResultTask<TResult, TNewResult>(this, continuationFunction, state, creationOptions, internalOptions, ref stackMark);
			base.ContinueWithCore(task, scheduler, cancellationToken, continuationOptions);
			return task;
		}

		// Token: 0x04001AB7 RID: 6839
		internal TResult m_result;

		// Token: 0x04001AB8 RID: 6840
		private static readonly TaskFactory<TResult> s_Factory = new TaskFactory<TResult>();

		// Token: 0x04001AB9 RID: 6841
		internal static readonly Func<Task<Task>, Task<TResult>> TaskWhenAnyCast = (Task<Task> completed) => (Task<TResult>)completed.Result;
	}
}
