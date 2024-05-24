using System;
using System.Collections.Generic;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x02000579 RID: 1401
	internal sealed class ThreadPoolTaskScheduler : TaskScheduler
	{
		// Token: 0x0600421E RID: 16926 RVA: 0x000F64A4 File Offset: 0x000F46A4
		internal ThreadPoolTaskScheduler()
		{
			int id = base.Id;
		}

		// Token: 0x0600421F RID: 16927 RVA: 0x000F64C0 File Offset: 0x000F46C0
		private static void LongRunningThreadWork(object obj)
		{
			Task task = obj as Task;
			task.ExecuteEntry(false);
		}

		// Token: 0x06004220 RID: 16928 RVA: 0x000F64DC File Offset: 0x000F46DC
		[SecurityCritical]
		protected internal override void QueueTask(Task task)
		{
			if ((task.Options & TaskCreationOptions.LongRunning) != TaskCreationOptions.None)
			{
				new Thread(ThreadPoolTaskScheduler.s_longRunningThreadWork)
				{
					IsBackground = true
				}.Start(task);
				return;
			}
			bool forceGlobal = (task.Options & TaskCreationOptions.PreferFairness) > TaskCreationOptions.None;
			ThreadPool.UnsafeQueueCustomWorkItem(task, forceGlobal);
		}

		// Token: 0x06004221 RID: 16929 RVA: 0x000F6520 File Offset: 0x000F4720
		[SecurityCritical]
		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
		{
			if (taskWasPreviouslyQueued && !ThreadPool.TryPopCustomWorkItem(task))
			{
				return false;
			}
			bool result = false;
			try
			{
				result = task.ExecuteEntry(false);
			}
			finally
			{
				if (taskWasPreviouslyQueued)
				{
					this.NotifyWorkItemProgress();
				}
			}
			return result;
		}

		// Token: 0x06004222 RID: 16930 RVA: 0x000F6564 File Offset: 0x000F4764
		[SecurityCritical]
		protected internal override bool TryDequeue(Task task)
		{
			return ThreadPool.TryPopCustomWorkItem(task);
		}

		// Token: 0x06004223 RID: 16931 RVA: 0x000F656C File Offset: 0x000F476C
		[SecurityCritical]
		protected override IEnumerable<Task> GetScheduledTasks()
		{
			return this.FilterTasksFromWorkItems(ThreadPool.GetQueuedWorkItems());
		}

		// Token: 0x06004224 RID: 16932 RVA: 0x000F6579 File Offset: 0x000F4779
		private IEnumerable<Task> FilterTasksFromWorkItems(IEnumerable<IThreadPoolWorkItem> tpwItems)
		{
			foreach (IThreadPoolWorkItem threadPoolWorkItem in tpwItems)
			{
				if (threadPoolWorkItem is Task)
				{
					yield return (Task)threadPoolWorkItem;
				}
			}
			IEnumerator<IThreadPoolWorkItem> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06004225 RID: 16933 RVA: 0x000F6589 File Offset: 0x000F4789
		internal override void NotifyWorkItemProgress()
		{
			ThreadPool.NotifyWorkItemProgress();
		}

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06004226 RID: 16934 RVA: 0x000F6590 File Offset: 0x000F4790
		internal override bool RequiresAtomicStartTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x04001B70 RID: 7024
		private static readonly ParameterizedThreadStart s_longRunningThreadWork = new ParameterizedThreadStart(ThreadPoolTaskScheduler.LongRunningThreadWork);
	}
}
