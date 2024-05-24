using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.Internals.Tasks
{
	// Token: 0x020000F4 RID: 244
	internal sealed class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
	{
		// Token: 0x0600072B RID: 1835 RVA: 0x0000BEC8 File Offset: 0x0000A0C8
		public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
		{
			if (maxDegreeOfParallelism < 1)
			{
				throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
			}
			this._maxDegreeOfParallelism = maxDegreeOfParallelism;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
		protected sealed override void QueueTask(Task task)
		{
			LinkedList<Task> tasks = this._tasks;
			lock (tasks)
			{
				this._tasks.AddLast(task);
				if (this._delegatesQueuedOrRunning < this._maxDegreeOfParallelism)
				{
					this._delegatesQueuedOrRunning++;
					this.NotifyThreadPoolOfPendingWork();
				}
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0000BF60 File Offset: 0x0000A160
		private void NotifyThreadPoolOfPendingWork()
		{
			ThreadPool.UnsafeQueueUserWorkItem(delegate(object _)
			{
				LimitedConcurrencyLevelTaskScheduler._currentThreadIsProcessingItems = true;
				try
				{
					for (;;)
					{
						LinkedList<Task> tasks = this._tasks;
						Task value;
						lock (tasks)
						{
							if (this._tasks.Count == 0)
							{
								this._delegatesQueuedOrRunning--;
								break;
							}
							value = this._tasks.First.Value;
							this._tasks.RemoveFirst();
						}
						base.TryExecuteTask(value);
					}
				}
				finally
				{
					LimitedConcurrencyLevelTaskScheduler._currentThreadIsProcessingItems = false;
				}
			}, null);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0000BF75 File Offset: 0x0000A175
		protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
		{
			if (!LimitedConcurrencyLevelTaskScheduler._currentThreadIsProcessingItems)
			{
				return false;
			}
			if (taskWasPreviouslyQueued)
			{
				this.TryDequeue(task);
			}
			return base.TryExecuteTask(task);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0000BF94 File Offset: 0x0000A194
		protected sealed override bool TryDequeue(Task task)
		{
			LinkedList<Task> tasks = this._tasks;
			bool result;
			lock (tasks)
			{
				result = this._tasks.Remove(task);
			}
			return result;
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x0000BFDC File Offset: 0x0000A1DC
		public sealed override int MaximumConcurrencyLevel
		{
			get
			{
				return this._maxDegreeOfParallelism;
			}
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0000BFE4 File Offset: 0x0000A1E4
		protected sealed override IEnumerable<Task> GetScheduledTasks()
		{
			bool flag = false;
			IEnumerable<Task> result;
			try
			{
				Monitor.TryEnter(this._tasks, ref flag);
				if (!flag)
				{
					throw new NotSupportedException();
				}
				result = this._tasks.ToArray<Task>();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(this._tasks);
				}
			}
			return result;
		}

		// Token: 0x0400039B RID: 923
		[ThreadStatic]
		private static bool _currentThreadIsProcessingItems;

		// Token: 0x0400039C RID: 924
		private readonly LinkedList<Task> _tasks = new LinkedList<Task>();

		// Token: 0x0400039D RID: 925
		private readonly int _maxDegreeOfParallelism;

		// Token: 0x0400039E RID: 926
		private int _delegatesQueuedOrRunning;
	}
}
