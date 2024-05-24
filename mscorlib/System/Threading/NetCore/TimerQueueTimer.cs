using System;
using System.Diagnostics.Tracing;
using System.Security;
using Microsoft.Win32;

namespace System.Threading.NetCore
{
	// Token: 0x0200058A RID: 1418
	internal sealed class TimerQueueTimer : IThreadPoolWorkItem
	{
		// Token: 0x060042B2 RID: 17074 RVA: 0x000F8CC4 File Offset: 0x000F6EC4
		[SecuritySafeCritical]
		internal TimerQueueTimer(TimerCallback timerCallback, object state, uint dueTime, uint period, bool flowExecutionContext, ref StackCrawlMark stackMark)
		{
			this.m_timerCallback = timerCallback;
			this.m_state = state;
			this.m_dueTime = uint.MaxValue;
			this.m_period = uint.MaxValue;
			if (flowExecutionContext)
			{
				this.m_executionContext = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx | ExecutionContext.CaptureOptions.OptimizeDefaultCase);
			}
			this.m_associatedTimerQueue = TimerQueue.Instances[Thread.GetCurrentProcessorId() % TimerQueue.Instances.Length];
			if (dueTime != 4294967295U)
			{
				this.Change(dueTime, period);
			}
		}

		// Token: 0x060042B3 RID: 17075 RVA: 0x000F8D2C File Offset: 0x000F6F2C
		internal bool Change(uint dueTime, uint period)
		{
			TimerQueue associatedTimerQueue = this.m_associatedTimerQueue;
			bool result;
			lock (associatedTimerQueue)
			{
				if (this.m_canceled)
				{
					throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_Generic"));
				}
				try
				{
				}
				finally
				{
					this.m_period = period;
					if (dueTime == 4294967295U)
					{
						this.m_associatedTimerQueue.DeleteTimer(this);
						result = true;
					}
					else
					{
						if (FrameworkEventSource.IsInitialized && FrameworkEventSource.Log.IsEnabled(EventLevel.Informational, (EventKeywords)16L))
						{
							FrameworkEventSource.Log.ThreadTransferSendObj(this, 1, string.Empty, true);
						}
						result = this.m_associatedTimerQueue.UpdateTimer(this, dueTime, period);
					}
				}
			}
			return result;
		}

		// Token: 0x060042B4 RID: 17076 RVA: 0x000F8DE4 File Offset: 0x000F6FE4
		public void Close()
		{
			TimerQueue associatedTimerQueue = this.m_associatedTimerQueue;
			lock (associatedTimerQueue)
			{
				try
				{
				}
				finally
				{
					if (!this.m_canceled)
					{
						this.m_canceled = true;
						this.m_associatedTimerQueue.DeleteTimer(this);
					}
				}
			}
		}

		// Token: 0x060042B5 RID: 17077 RVA: 0x000F8E4C File Offset: 0x000F704C
		public bool Close(WaitHandle toSignal)
		{
			bool flag = false;
			TimerQueue associatedTimerQueue = this.m_associatedTimerQueue;
			bool result;
			lock (associatedTimerQueue)
			{
				try
				{
				}
				finally
				{
					if (this.m_canceled)
					{
						result = false;
					}
					else
					{
						this.m_canceled = true;
						this.m_notifyWhenNoCallbacksRunning = toSignal;
						this.m_associatedTimerQueue.DeleteTimer(this);
						flag = (this.m_callbacksRunning == 0);
						result = true;
					}
				}
			}
			if (flag)
			{
				this.SignalNoCallbacksRunning();
			}
			return result;
		}

		// Token: 0x060042B6 RID: 17078 RVA: 0x000F8ED8 File Offset: 0x000F70D8
		[SecurityCritical]
		void IThreadPoolWorkItem.ExecuteWorkItem()
		{
			this.Fire();
		}

		// Token: 0x060042B7 RID: 17079 RVA: 0x000F8EE0 File Offset: 0x000F70E0
		[SecurityCritical]
		void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae)
		{
		}

		// Token: 0x060042B8 RID: 17080 RVA: 0x000F8EE4 File Offset: 0x000F70E4
		internal void Fire()
		{
			bool flag = false;
			TimerQueue associatedTimerQueue = this.m_associatedTimerQueue;
			lock (associatedTimerQueue)
			{
				try
				{
				}
				finally
				{
					flag = this.m_canceled;
					if (!flag)
					{
						this.m_callbacksRunning++;
					}
				}
			}
			if (flag)
			{
				return;
			}
			this.CallCallback();
			bool flag3 = false;
			TimerQueue associatedTimerQueue2 = this.m_associatedTimerQueue;
			lock (associatedTimerQueue2)
			{
				try
				{
				}
				finally
				{
					this.m_callbacksRunning--;
					if (this.m_canceled && this.m_callbacksRunning == 0 && this.m_notifyWhenNoCallbacksRunning != null)
					{
						flag3 = true;
					}
				}
			}
			if (flag3)
			{
				this.SignalNoCallbacksRunning();
			}
		}

		// Token: 0x060042B9 RID: 17081 RVA: 0x000F8FC4 File Offset: 0x000F71C4
		[SecuritySafeCritical]
		internal void SignalNoCallbacksRunning()
		{
			Win32Native.SetEvent(this.m_notifyWhenNoCallbacksRunning.SafeWaitHandle);
		}

		// Token: 0x060042BA RID: 17082 RVA: 0x000F8FDC File Offset: 0x000F71DC
		[SecuritySafeCritical]
		internal void CallCallback()
		{
			if (FrameworkEventSource.IsInitialized && FrameworkEventSource.Log.IsEnabled(EventLevel.Informational, (EventKeywords)16L))
			{
				FrameworkEventSource.Log.ThreadTransferReceiveObj(this, 1, string.Empty);
			}
			ExecutionContext executionContext = this.m_executionContext;
			if (executionContext == null)
			{
				this.m_timerCallback(this.m_state);
				return;
			}
			ExecutionContext executionContext2;
			executionContext = (executionContext2 = (executionContext.IsPreAllocatedDefault ? executionContext : executionContext.CreateCopy()));
			try
			{
				if (TimerQueueTimer.s_callCallbackInContext == null)
				{
					TimerQueueTimer.s_callCallbackInContext = new ContextCallback(TimerQueueTimer.CallCallbackInContext);
				}
				ExecutionContext.Run(executionContext, TimerQueueTimer.s_callCallbackInContext, this, true);
			}
			finally
			{
				if (executionContext2 != null)
				{
					((IDisposable)executionContext2).Dispose();
				}
			}
		}

		// Token: 0x060042BB RID: 17083 RVA: 0x000F9088 File Offset: 0x000F7288
		[SecurityCritical]
		private static void CallCallbackInContext(object state)
		{
			TimerQueueTimer timerQueueTimer = (TimerQueueTimer)state;
			timerQueueTimer.m_timerCallback(timerQueueTimer.m_state);
		}

		// Token: 0x04001BC1 RID: 7105
		private readonly TimerQueue m_associatedTimerQueue;

		// Token: 0x04001BC2 RID: 7106
		internal TimerQueueTimer m_next;

		// Token: 0x04001BC3 RID: 7107
		internal TimerQueueTimer m_prev;

		// Token: 0x04001BC4 RID: 7108
		internal bool m_short;

		// Token: 0x04001BC5 RID: 7109
		internal long m_startTicks;

		// Token: 0x04001BC6 RID: 7110
		internal uint m_dueTime;

		// Token: 0x04001BC7 RID: 7111
		internal uint m_period;

		// Token: 0x04001BC8 RID: 7112
		private readonly TimerCallback m_timerCallback;

		// Token: 0x04001BC9 RID: 7113
		private readonly object m_state;

		// Token: 0x04001BCA RID: 7114
		private readonly ExecutionContext m_executionContext;

		// Token: 0x04001BCB RID: 7115
		private int m_callbacksRunning;

		// Token: 0x04001BCC RID: 7116
		private volatile bool m_canceled;

		// Token: 0x04001BCD RID: 7117
		private volatile WaitHandle m_notifyWhenNoCallbacksRunning;

		// Token: 0x04001BCE RID: 7118
		[SecurityCritical]
		private static ContextCallback s_callCallbackInContext;
	}
}
