using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x02000576 RID: 1398
	[DebuggerDisplay("Id={Id}")]
	[DebuggerTypeProxy(typeof(TaskScheduler.SystemThreadingTasks_TaskSchedulerDebugView))]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	public abstract class TaskScheduler
	{
		// Token: 0x060041FC RID: 16892
		[SecurityCritical]
		[__DynamicallyInvokable]
		protected internal abstract void QueueTask(Task task);

		// Token: 0x060041FD RID: 16893
		[SecurityCritical]
		[__DynamicallyInvokable]
		protected abstract bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued);

		// Token: 0x060041FE RID: 16894
		[SecurityCritical]
		[__DynamicallyInvokable]
		protected abstract IEnumerable<Task> GetScheduledTasks();

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x060041FF RID: 16895 RVA: 0x000F604E File Offset: 0x000F424E
		[__DynamicallyInvokable]
		public virtual int MaximumConcurrencyLevel
		{
			[__DynamicallyInvokable]
			get
			{
				return int.MaxValue;
			}
		}

		// Token: 0x06004200 RID: 16896 RVA: 0x000F6058 File Offset: 0x000F4258
		[SecuritySafeCritical]
		internal bool TryRunInline(Task task, bool taskWasPreviouslyQueued)
		{
			TaskScheduler executingTaskScheduler = task.ExecutingTaskScheduler;
			if (executingTaskScheduler != this && executingTaskScheduler != null)
			{
				return executingTaskScheduler.TryRunInline(task, taskWasPreviouslyQueued);
			}
			StackGuard currentStackGuard;
			if (executingTaskScheduler == null || task.m_action == null || task.IsDelegateInvoked || task.IsCanceled || !(currentStackGuard = Task.CurrentStackGuard).TryBeginInliningScope())
			{
				return false;
			}
			bool flag = false;
			try
			{
				task.FireTaskScheduledIfNeeded(this);
				flag = this.TryExecuteTaskInline(task, taskWasPreviouslyQueued);
			}
			finally
			{
				currentStackGuard.EndInliningScope();
			}
			if (flag && !task.IsDelegateInvoked && !task.IsCanceled)
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskScheduler_InconsistentStateAfterTryExecuteTaskInline"));
			}
			return flag;
		}

		// Token: 0x06004201 RID: 16897 RVA: 0x000F60F8 File Offset: 0x000F42F8
		[SecurityCritical]
		[__DynamicallyInvokable]
		protected internal virtual bool TryDequeue(Task task)
		{
			return false;
		}

		// Token: 0x06004202 RID: 16898 RVA: 0x000F60FB File Offset: 0x000F42FB
		internal virtual void NotifyWorkItemProgress()
		{
		}

		// Token: 0x170009CA RID: 2506
		// (get) Token: 0x06004203 RID: 16899 RVA: 0x000F60FD File Offset: 0x000F42FD
		internal virtual bool RequiresAtomicStartTransition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06004204 RID: 16900 RVA: 0x000F6100 File Offset: 0x000F4300
		[SecurityCritical]
		internal void InternalQueueTask(Task task)
		{
			task.FireTaskScheduledIfNeeded(this);
			this.QueueTask(task);
		}

		// Token: 0x06004205 RID: 16901 RVA: 0x000F6111 File Offset: 0x000F4311
		[__DynamicallyInvokable]
		protected TaskScheduler()
		{
			if (Debugger.IsAttached)
			{
				this.AddToActiveTaskSchedulers();
			}
		}

		// Token: 0x06004206 RID: 16902 RVA: 0x000F6128 File Offset: 0x000F4328
		private void AddToActiveTaskSchedulers()
		{
			ConditionalWeakTable<TaskScheduler, object> conditionalWeakTable = TaskScheduler.s_activeTaskSchedulers;
			if (conditionalWeakTable == null)
			{
				Interlocked.CompareExchange<ConditionalWeakTable<TaskScheduler, object>>(ref TaskScheduler.s_activeTaskSchedulers, new ConditionalWeakTable<TaskScheduler, object>(), null);
				conditionalWeakTable = TaskScheduler.s_activeTaskSchedulers;
			}
			conditionalWeakTable.Add(this, null);
		}

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06004207 RID: 16903 RVA: 0x000F615D File Offset: 0x000F435D
		[__DynamicallyInvokable]
		public static TaskScheduler Default
		{
			[__DynamicallyInvokable]
			get
			{
				return TaskScheduler.s_defaultTaskScheduler;
			}
		}

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x06004208 RID: 16904 RVA: 0x000F6164 File Offset: 0x000F4364
		[__DynamicallyInvokable]
		public static TaskScheduler Current
		{
			[__DynamicallyInvokable]
			get
			{
				TaskScheduler internalCurrent = TaskScheduler.InternalCurrent;
				return internalCurrent ?? TaskScheduler.Default;
			}
		}

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x06004209 RID: 16905 RVA: 0x000F6184 File Offset: 0x000F4384
		internal static TaskScheduler InternalCurrent
		{
			get
			{
				Task internalCurrent = Task.InternalCurrent;
				if (internalCurrent == null || (internalCurrent.CreationOptions & TaskCreationOptions.HideScheduler) != TaskCreationOptions.None)
				{
					return null;
				}
				return internalCurrent.ExecutingTaskScheduler;
			}
		}

		// Token: 0x0600420A RID: 16906 RVA: 0x000F61AD File Offset: 0x000F43AD
		[__DynamicallyInvokable]
		public static TaskScheduler FromCurrentSynchronizationContext()
		{
			return new SynchronizationContextTaskScheduler();
		}

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x0600420B RID: 16907 RVA: 0x000F61B4 File Offset: 0x000F43B4
		[__DynamicallyInvokable]
		public int Id
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_taskSchedulerId == 0)
				{
					int num;
					do
					{
						num = Interlocked.Increment(ref TaskScheduler.s_taskSchedulerIdCounter);
					}
					while (num == 0);
					Interlocked.CompareExchange(ref this.m_taskSchedulerId, num, 0);
				}
				return this.m_taskSchedulerId;
			}
		}

		// Token: 0x0600420C RID: 16908 RVA: 0x000F61F1 File Offset: 0x000F43F1
		[SecurityCritical]
		[__DynamicallyInvokable]
		protected bool TryExecuteTask(Task task)
		{
			if (task.ExecutingTaskScheduler != this)
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskScheduler_ExecuteTask_WrongTaskScheduler"));
			}
			return task.ExecuteEntry(true);
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x0600420D RID: 16909 RVA: 0x000F6214 File Offset: 0x000F4414
		// (remove) Token: 0x0600420E RID: 16910 RVA: 0x000F626C File Offset: 0x000F446C
		[__DynamicallyInvokable]
		public static event EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException
		{
			[SecurityCritical]
			[__DynamicallyInvokable]
			add
			{
				if (value != null)
				{
					RuntimeHelpers.PrepareContractedDelegate(value);
					object unobservedTaskExceptionLockObject = TaskScheduler._unobservedTaskExceptionLockObject;
					lock (unobservedTaskExceptionLockObject)
					{
						TaskScheduler._unobservedTaskException = (EventHandler<UnobservedTaskExceptionEventArgs>)Delegate.Combine(TaskScheduler._unobservedTaskException, value);
					}
				}
			}
			[SecurityCritical]
			[__DynamicallyInvokable]
			remove
			{
				object unobservedTaskExceptionLockObject = TaskScheduler._unobservedTaskExceptionLockObject;
				lock (unobservedTaskExceptionLockObject)
				{
					TaskScheduler._unobservedTaskException = (EventHandler<UnobservedTaskExceptionEventArgs>)Delegate.Remove(TaskScheduler._unobservedTaskException, value);
				}
			}
		}

		// Token: 0x0600420F RID: 16911 RVA: 0x000F62BC File Offset: 0x000F44BC
		internal static void PublishUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs ueea)
		{
			object unobservedTaskExceptionLockObject = TaskScheduler._unobservedTaskExceptionLockObject;
			lock (unobservedTaskExceptionLockObject)
			{
				EventHandler<UnobservedTaskExceptionEventArgs> unobservedTaskException = TaskScheduler._unobservedTaskException;
				if (unobservedTaskException != null)
				{
					unobservedTaskException(sender, ueea);
				}
			}
		}

		// Token: 0x06004210 RID: 16912 RVA: 0x000F6308 File Offset: 0x000F4508
		[SecurityCritical]
		internal Task[] GetScheduledTasksForDebugger()
		{
			IEnumerable<Task> scheduledTasks = this.GetScheduledTasks();
			if (scheduledTasks == null)
			{
				return null;
			}
			Task[] array = scheduledTasks as Task[];
			if (array == null)
			{
				array = new List<Task>(scheduledTasks).ToArray();
			}
			foreach (Task task in array)
			{
				int id = task.Id;
			}
			return array;
		}

		// Token: 0x06004211 RID: 16913 RVA: 0x000F6358 File Offset: 0x000F4558
		[SecurityCritical]
		internal static TaskScheduler[] GetTaskSchedulersForDebugger()
		{
			if (TaskScheduler.s_activeTaskSchedulers == null)
			{
				return new TaskScheduler[]
				{
					TaskScheduler.s_defaultTaskScheduler
				};
			}
			ICollection<TaskScheduler> keys = TaskScheduler.s_activeTaskSchedulers.Keys;
			if (!keys.Contains(TaskScheduler.s_defaultTaskScheduler))
			{
				keys.Add(TaskScheduler.s_defaultTaskScheduler);
			}
			TaskScheduler[] array = new TaskScheduler[keys.Count];
			keys.CopyTo(array, 0);
			foreach (TaskScheduler taskScheduler in array)
			{
				int id = taskScheduler.Id;
			}
			return array;
		}

		// Token: 0x04001B66 RID: 7014
		private static ConditionalWeakTable<TaskScheduler, object> s_activeTaskSchedulers;

		// Token: 0x04001B67 RID: 7015
		private static readonly TaskScheduler s_defaultTaskScheduler = new ThreadPoolTaskScheduler();

		// Token: 0x04001B68 RID: 7016
		internal static int s_taskSchedulerIdCounter;

		// Token: 0x04001B69 RID: 7017
		private volatile int m_taskSchedulerId;

		// Token: 0x04001B6A RID: 7018
		private static EventHandler<UnobservedTaskExceptionEventArgs> _unobservedTaskException;

		// Token: 0x04001B6B RID: 7019
		private static readonly object _unobservedTaskExceptionLockObject = new object();

		// Token: 0x02000C21 RID: 3105
		internal sealed class SystemThreadingTasks_TaskSchedulerDebugView
		{
			// Token: 0x06006FFB RID: 28667 RVA: 0x00182566 File Offset: 0x00180766
			public SystemThreadingTasks_TaskSchedulerDebugView(TaskScheduler scheduler)
			{
				this.m_taskScheduler = scheduler;
			}

			// Token: 0x1700132C RID: 4908
			// (get) Token: 0x06006FFC RID: 28668 RVA: 0x00182575 File Offset: 0x00180775
			public int Id
			{
				get
				{
					return this.m_taskScheduler.Id;
				}
			}

			// Token: 0x1700132D RID: 4909
			// (get) Token: 0x06006FFD RID: 28669 RVA: 0x00182582 File Offset: 0x00180782
			public IEnumerable<Task> ScheduledTasks
			{
				[SecurityCritical]
				get
				{
					return this.m_taskScheduler.GetScheduledTasks();
				}
			}

			// Token: 0x040036D0 RID: 14032
			private readonly TaskScheduler m_taskScheduler;
		}
	}
}
