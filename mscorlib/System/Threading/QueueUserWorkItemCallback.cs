using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000522 RID: 1314
	internal sealed class QueueUserWorkItemCallback : IThreadPoolWorkItem
	{
		// Token: 0x06003DE1 RID: 15841 RVA: 0x000E7453 File Offset: 0x000E5653
		[SecurityCritical]
		internal QueueUserWorkItemCallback(WaitCallback waitCallback, object stateObj, bool compressStack, ref StackCrawlMark stackMark)
		{
			this.callback = waitCallback;
			this.state = stateObj;
			if (compressStack && !ExecutionContext.IsFlowSuppressed())
			{
				this.context = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx | ExecutionContext.CaptureOptions.OptimizeDefaultCase);
			}
		}

		// Token: 0x06003DE2 RID: 15842 RVA: 0x000E7481 File Offset: 0x000E5681
		internal QueueUserWorkItemCallback(WaitCallback waitCallback, object stateObj, ExecutionContext ec)
		{
			this.callback = waitCallback;
			this.state = stateObj;
			this.context = ec;
		}

		// Token: 0x06003DE3 RID: 15843 RVA: 0x000E74A0 File Offset: 0x000E56A0
		[SecurityCritical]
		void IThreadPoolWorkItem.ExecuteWorkItem()
		{
			if (this.context == null)
			{
				WaitCallback waitCallback = this.callback;
				this.callback = null;
				waitCallback(this.state);
				return;
			}
			ExecutionContext.Run(this.context, QueueUserWorkItemCallback.ccb, this, true);
		}

		// Token: 0x06003DE4 RID: 15844 RVA: 0x000E74E2 File Offset: 0x000E56E2
		[SecurityCritical]
		void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae)
		{
		}

		// Token: 0x06003DE5 RID: 15845 RVA: 0x000E74E4 File Offset: 0x000E56E4
		[SecurityCritical]
		private static void WaitCallback_Context(object state)
		{
			QueueUserWorkItemCallback queueUserWorkItemCallback = (QueueUserWorkItemCallback)state;
			WaitCallback waitCallback = queueUserWorkItemCallback.callback;
			waitCallback(queueUserWorkItemCallback.state);
		}

		// Token: 0x04001A0D RID: 6669
		private WaitCallback callback;

		// Token: 0x04001A0E RID: 6670
		private ExecutionContext context;

		// Token: 0x04001A0F RID: 6671
		private object state;

		// Token: 0x04001A10 RID: 6672
		[SecurityCritical]
		internal static ContextCallback ccb = new ContextCallback(QueueUserWorkItemCallback.WaitCallback_Context);
	}
}
