using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200055F RID: 1375
	internal class SystemThreadingTasks_TaskDebugView
	{
		// Token: 0x06004143 RID: 16707 RVA: 0x000F3CA0 File Offset: 0x000F1EA0
		public SystemThreadingTasks_TaskDebugView(Task task)
		{
			this.m_task = task;
		}

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06004144 RID: 16708 RVA: 0x000F3CAF File Offset: 0x000F1EAF
		public object AsyncState
		{
			get
			{
				return this.m_task.AsyncState;
			}
		}

		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x06004145 RID: 16709 RVA: 0x000F3CBC File Offset: 0x000F1EBC
		public TaskCreationOptions CreationOptions
		{
			get
			{
				return this.m_task.CreationOptions;
			}
		}

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06004146 RID: 16710 RVA: 0x000F3CC9 File Offset: 0x000F1EC9
		public Exception Exception
		{
			get
			{
				return this.m_task.Exception;
			}
		}

		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06004147 RID: 16711 RVA: 0x000F3CD6 File Offset: 0x000F1ED6
		public int Id
		{
			get
			{
				return this.m_task.Id;
			}
		}

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06004148 RID: 16712 RVA: 0x000F3CE4 File Offset: 0x000F1EE4
		public bool CancellationPending
		{
			get
			{
				return this.m_task.Status == TaskStatus.WaitingToRun && this.m_task.CancellationToken.IsCancellationRequested;
			}
		}

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06004149 RID: 16713 RVA: 0x000F3D14 File Offset: 0x000F1F14
		public TaskStatus Status
		{
			get
			{
				return this.m_task.Status;
			}
		}

		// Token: 0x04001B1A RID: 6938
		private Task m_task;
	}
}
