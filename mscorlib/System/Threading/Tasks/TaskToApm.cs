using System;
using System.IO;

namespace System.Threading.Tasks
{
	// Token: 0x02000588 RID: 1416
	internal static class TaskToApm
	{
		// Token: 0x0600429D RID: 17053 RVA: 0x000F83F4 File Offset: 0x000F65F4
		public static IAsyncResult Begin(Task task, AsyncCallback callback, object state)
		{
			IAsyncResult asyncResult;
			if (task.IsCompleted)
			{
				asyncResult = new TaskToApm.TaskWrapperAsyncResult(task, state, true);
				if (callback != null)
				{
					callback(asyncResult);
				}
			}
			else
			{
				IAsyncResult asyncResult3;
				if (task.AsyncState != state)
				{
					IAsyncResult asyncResult2 = new TaskToApm.TaskWrapperAsyncResult(task, state, false);
					asyncResult3 = asyncResult2;
				}
				else
				{
					asyncResult3 = task;
				}
				asyncResult = asyncResult3;
				if (callback != null)
				{
					TaskToApm.InvokeCallbackWhenTaskCompletes(task, callback, asyncResult);
				}
			}
			return asyncResult;
		}

		// Token: 0x0600429E RID: 17054 RVA: 0x000F8444 File Offset: 0x000F6644
		public static void End(IAsyncResult asyncResult)
		{
			TaskToApm.TaskWrapperAsyncResult taskWrapperAsyncResult = asyncResult as TaskToApm.TaskWrapperAsyncResult;
			Task task;
			if (taskWrapperAsyncResult != null)
			{
				task = taskWrapperAsyncResult.Task;
			}
			else
			{
				task = (asyncResult as Task);
			}
			if (task == null)
			{
				__Error.WrongAsyncResult();
			}
			task.GetAwaiter().GetResult();
		}

		// Token: 0x0600429F RID: 17055 RVA: 0x000F8484 File Offset: 0x000F6684
		public static TResult End<TResult>(IAsyncResult asyncResult)
		{
			TaskToApm.TaskWrapperAsyncResult taskWrapperAsyncResult = asyncResult as TaskToApm.TaskWrapperAsyncResult;
			Task<TResult> task;
			if (taskWrapperAsyncResult != null)
			{
				task = (taskWrapperAsyncResult.Task as Task<TResult>);
			}
			else
			{
				task = (asyncResult as Task<TResult>);
			}
			if (task == null)
			{
				__Error.WrongAsyncResult();
			}
			return task.GetAwaiter().GetResult();
		}

		// Token: 0x060042A0 RID: 17056 RVA: 0x000F84C8 File Offset: 0x000F66C8
		private static void InvokeCallbackWhenTaskCompletes(Task antecedent, AsyncCallback callback, IAsyncResult asyncResult)
		{
			antecedent.ConfigureAwait(false).GetAwaiter().OnCompleted(delegate
			{
				callback(asyncResult);
			});
		}

		// Token: 0x02000C32 RID: 3122
		private sealed class TaskWrapperAsyncResult : IAsyncResult
		{
			// Token: 0x0600702D RID: 28717 RVA: 0x00182BF6 File Offset: 0x00180DF6
			internal TaskWrapperAsyncResult(Task task, object state, bool completedSynchronously)
			{
				this.Task = task;
				this.m_state = state;
				this.m_completedSynchronously = completedSynchronously;
			}

			// Token: 0x1700133A RID: 4922
			// (get) Token: 0x0600702E RID: 28718 RVA: 0x00182C13 File Offset: 0x00180E13
			object IAsyncResult.AsyncState
			{
				get
				{
					return this.m_state;
				}
			}

			// Token: 0x1700133B RID: 4923
			// (get) Token: 0x0600702F RID: 28719 RVA: 0x00182C1B File Offset: 0x00180E1B
			bool IAsyncResult.CompletedSynchronously
			{
				get
				{
					return this.m_completedSynchronously;
				}
			}

			// Token: 0x1700133C RID: 4924
			// (get) Token: 0x06007030 RID: 28720 RVA: 0x00182C23 File Offset: 0x00180E23
			bool IAsyncResult.IsCompleted
			{
				get
				{
					return this.Task.IsCompleted;
				}
			}

			// Token: 0x1700133D RID: 4925
			// (get) Token: 0x06007031 RID: 28721 RVA: 0x00182C30 File Offset: 0x00180E30
			WaitHandle IAsyncResult.AsyncWaitHandle
			{
				get
				{
					return ((IAsyncResult)this.Task).AsyncWaitHandle;
				}
			}

			// Token: 0x0400371A RID: 14106
			internal readonly Task Task;

			// Token: 0x0400371B RID: 14107
			private readonly object m_state;

			// Token: 0x0400371C RID: 14108
			private readonly bool m_completedSynchronously;
		}
	}
}
