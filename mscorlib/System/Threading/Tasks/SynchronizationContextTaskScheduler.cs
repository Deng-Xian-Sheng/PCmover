using System;
using System.Collections.Generic;
using System.Security;

namespace System.Threading.Tasks
{
	// Token: 0x02000577 RID: 1399
	internal sealed class SynchronizationContextTaskScheduler : TaskScheduler
	{
		// Token: 0x06004213 RID: 16915 RVA: 0x000F63E8 File Offset: 0x000F45E8
		internal SynchronizationContextTaskScheduler()
		{
			SynchronizationContext synchronizationContext = SynchronizationContext.Current;
			if (synchronizationContext == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskScheduler_FromCurrentSynchronizationContext_NoCurrent"));
			}
			this.m_synchronizationContext = synchronizationContext;
		}

		// Token: 0x06004214 RID: 16916 RVA: 0x000F641B File Offset: 0x000F461B
		[SecurityCritical]
		protected internal override void QueueTask(Task task)
		{
			this.m_synchronizationContext.Post(SynchronizationContextTaskScheduler.s_postCallback, task);
		}

		// Token: 0x06004215 RID: 16917 RVA: 0x000F642E File Offset: 0x000F462E
		[SecurityCritical]
		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
		{
			return SynchronizationContext.Current == this.m_synchronizationContext && base.TryExecuteTask(task);
		}

		// Token: 0x06004216 RID: 16918 RVA: 0x000F6446 File Offset: 0x000F4646
		[SecurityCritical]
		protected override IEnumerable<Task> GetScheduledTasks()
		{
			return null;
		}

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06004217 RID: 16919 RVA: 0x000F6449 File Offset: 0x000F4649
		public override int MaximumConcurrencyLevel
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06004218 RID: 16920 RVA: 0x000F644C File Offset: 0x000F464C
		private static void PostCallback(object obj)
		{
			Task task = (Task)obj;
			task.ExecuteEntry(true);
		}

		// Token: 0x04001B6C RID: 7020
		private SynchronizationContext m_synchronizationContext;

		// Token: 0x04001B6D RID: 7021
		private static SendOrPostCallback s_postCallback = new SendOrPostCallback(SynchronizationContextTaskScheduler.PostCallback);
	}
}
