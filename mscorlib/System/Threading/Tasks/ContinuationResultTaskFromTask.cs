using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200056A RID: 1386
	internal sealed class ContinuationResultTaskFromTask<TResult> : Task<TResult>
	{
		// Token: 0x06004162 RID: 16738 RVA: 0x000F4234 File Offset: 0x000F2434
		public ContinuationResultTaskFromTask(Task antecedent, Delegate function, object state, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, ref StackCrawlMark stackMark) : base(function, state, Task.InternalCurrentIfAttached(creationOptions), default(CancellationToken), creationOptions, internalOptions, null)
		{
			this.m_antecedent = antecedent;
			base.PossiblyCaptureContext(ref stackMark);
		}

		// Token: 0x06004163 RID: 16739 RVA: 0x000F4270 File Offset: 0x000F2470
		internal override void InnerInvoke()
		{
			Task antecedent = this.m_antecedent;
			this.m_antecedent = null;
			antecedent.NotifyDebuggerOfWaitCompletionIfNecessary();
			Func<Task, TResult> func = this.m_action as Func<Task, TResult>;
			if (func != null)
			{
				this.m_result = func(antecedent);
				return;
			}
			Func<Task, object, TResult> func2 = this.m_action as Func<Task, object, TResult>;
			if (func2 != null)
			{
				this.m_result = func2(antecedent, this.m_stateObject);
				return;
			}
		}

		// Token: 0x04001B4C RID: 6988
		private Task m_antecedent;
	}
}
