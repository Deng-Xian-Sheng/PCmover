using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000569 RID: 1385
	internal sealed class ContinuationTaskFromTask : Task
	{
		// Token: 0x06004160 RID: 16736 RVA: 0x000F41A0 File Offset: 0x000F23A0
		public ContinuationTaskFromTask(Task antecedent, Delegate action, object state, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, ref StackCrawlMark stackMark) : base(action, state, Task.InternalCurrentIfAttached(creationOptions), default(CancellationToken), creationOptions, internalOptions, null)
		{
			this.m_antecedent = antecedent;
			base.PossiblyCaptureContext(ref stackMark);
		}

		// Token: 0x06004161 RID: 16737 RVA: 0x000F41DC File Offset: 0x000F23DC
		internal override void InnerInvoke()
		{
			Task antecedent = this.m_antecedent;
			this.m_antecedent = null;
			antecedent.NotifyDebuggerOfWaitCompletionIfNecessary();
			Action<Task> action = this.m_action as Action<Task>;
			if (action != null)
			{
				action(antecedent);
				return;
			}
			Action<Task, object> action2 = this.m_action as Action<Task, object>;
			if (action2 != null)
			{
				action2(antecedent, this.m_stateObject);
				return;
			}
		}

		// Token: 0x04001B4B RID: 6987
		private Task m_antecedent;
	}
}
