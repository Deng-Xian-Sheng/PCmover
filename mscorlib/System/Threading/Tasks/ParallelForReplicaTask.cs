using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000561 RID: 1377
	internal class ParallelForReplicaTask : Task
	{
		// Token: 0x0600414D RID: 16717 RVA: 0x000F3DA0 File Offset: 0x000F1FA0
		internal ParallelForReplicaTask(Action<object> taskReplicaDelegate, object stateObject, Task parentTask, TaskScheduler taskScheduler, TaskCreationOptions creationOptionsForReplica, InternalTaskOptions internalOptionsForReplica) : base(taskReplicaDelegate, stateObject, parentTask, default(CancellationToken), creationOptionsForReplica, internalOptionsForReplica, taskScheduler)
		{
		}

		// Token: 0x170009BE RID: 2494
		// (get) Token: 0x0600414E RID: 16718 RVA: 0x000F3DC5 File Offset: 0x000F1FC5
		// (set) Token: 0x0600414F RID: 16719 RVA: 0x000F3DCD File Offset: 0x000F1FCD
		internal override object SavedStateForNextReplica
		{
			get
			{
				return this.m_stateForNextReplica;
			}
			set
			{
				this.m_stateForNextReplica = value;
			}
		}

		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x06004150 RID: 16720 RVA: 0x000F3DD6 File Offset: 0x000F1FD6
		// (set) Token: 0x06004151 RID: 16721 RVA: 0x000F3DDE File Offset: 0x000F1FDE
		internal override object SavedStateFromPreviousReplica
		{
			get
			{
				return this.m_stateFromPreviousReplica;
			}
			set
			{
				this.m_stateFromPreviousReplica = value;
			}
		}

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06004152 RID: 16722 RVA: 0x000F3DE7 File Offset: 0x000F1FE7
		// (set) Token: 0x06004153 RID: 16723 RVA: 0x000F3DEF File Offset: 0x000F1FEF
		internal override Task HandedOverChildReplica
		{
			get
			{
				return this.m_handedOverChildReplica;
			}
			set
			{
				this.m_handedOverChildReplica = value;
			}
		}

		// Token: 0x04001B1C RID: 6940
		internal object m_stateForNextReplica;

		// Token: 0x04001B1D RID: 6941
		internal object m_stateFromPreviousReplica;

		// Token: 0x04001B1E RID: 6942
		internal Task m_handedOverChildReplica;
	}
}
