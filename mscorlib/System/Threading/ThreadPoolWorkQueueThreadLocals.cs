using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x0200051B RID: 1307
	internal sealed class ThreadPoolWorkQueueThreadLocals
	{
		// Token: 0x06003DC4 RID: 15812 RVA: 0x000E7122 File Offset: 0x000E5322
		public ThreadPoolWorkQueueThreadLocals(ThreadPoolWorkQueue tpq)
		{
			this.workQueue = tpq;
			this.workStealingQueue = new ThreadPoolWorkQueue.WorkStealingQueue();
			ThreadPoolWorkQueue.allThreadQueues.Add(this.workStealingQueue);
		}

		// Token: 0x06003DC5 RID: 15813 RVA: 0x000E7164 File Offset: 0x000E5364
		[SecurityCritical]
		private void CleanUp()
		{
			if (this.workStealingQueue != null)
			{
				if (this.workQueue != null)
				{
					bool flag = false;
					while (!flag)
					{
						try
						{
						}
						finally
						{
							IThreadPoolWorkItem callback = null;
							if (this.workStealingQueue.LocalPop(out callback))
							{
								this.workQueue.Enqueue(callback, true);
							}
							else
							{
								flag = true;
							}
						}
					}
				}
				ThreadPoolWorkQueue.allThreadQueues.Remove(this.workStealingQueue);
			}
		}

		// Token: 0x06003DC6 RID: 15814 RVA: 0x000E71D0 File Offset: 0x000E53D0
		[SecuritySafeCritical]
		~ThreadPoolWorkQueueThreadLocals()
		{
			if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload())
			{
				this.CleanUp();
			}
		}

		// Token: 0x04001A04 RID: 6660
		[ThreadStatic]
		[SecurityCritical]
		public static ThreadPoolWorkQueueThreadLocals threadLocals;

		// Token: 0x04001A05 RID: 6661
		public readonly ThreadPoolWorkQueue workQueue;

		// Token: 0x04001A06 RID: 6662
		public readonly ThreadPoolWorkQueue.WorkStealingQueue workStealingQueue;

		// Token: 0x04001A07 RID: 6663
		public readonly Random random = new Random(Thread.CurrentThread.ManagedThreadId);
	}
}
