using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200054C RID: 1356
	internal class SystemThreadingTasks_FutureDebugView<TResult>
	{
		// Token: 0x06003FC4 RID: 16324 RVA: 0x000ECF3F File Offset: 0x000EB13F
		public SystemThreadingTasks_FutureDebugView(Task<TResult> task)
		{
			this.m_task = task;
		}

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06003FC5 RID: 16325 RVA: 0x000ECF50 File Offset: 0x000EB150
		public TResult Result
		{
			get
			{
				if (this.m_task.Status != TaskStatus.RanToCompletion)
				{
					return default(TResult);
				}
				return this.m_task.Result;
			}
		}

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06003FC6 RID: 16326 RVA: 0x000ECF80 File Offset: 0x000EB180
		public object AsyncState
		{
			get
			{
				return this.m_task.AsyncState;
			}
		}

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06003FC7 RID: 16327 RVA: 0x000ECF8D File Offset: 0x000EB18D
		public TaskCreationOptions CreationOptions
		{
			get
			{
				return this.m_task.CreationOptions;
			}
		}

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06003FC8 RID: 16328 RVA: 0x000ECF9A File Offset: 0x000EB19A
		public Exception Exception
		{
			get
			{
				return this.m_task.Exception;
			}
		}

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06003FC9 RID: 16329 RVA: 0x000ECFA7 File Offset: 0x000EB1A7
		public int Id
		{
			get
			{
				return this.m_task.Id;
			}
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06003FCA RID: 16330 RVA: 0x000ECFB4 File Offset: 0x000EB1B4
		public bool CancellationPending
		{
			get
			{
				return this.m_task.Status == TaskStatus.WaitingToRun && this.m_task.CancellationToken.IsCancellationRequested;
			}
		}

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x06003FCB RID: 16331 RVA: 0x000ECFE4 File Offset: 0x000EB1E4
		public TaskStatus Status
		{
			get
			{
				return this.m_task.Status;
			}
		}

		// Token: 0x04001ABA RID: 6842
		private Task<TResult> m_task;
	}
}
