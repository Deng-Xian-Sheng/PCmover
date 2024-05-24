using System;
using System.Diagnostics.Tracing;
using System.Security;
using Microsoft.Win32;

namespace System.Threading
{
	// Token: 0x0200052E RID: 1326
	internal sealed class TimerQueueTimer
	{
		// Token: 0x06003E3F RID: 15935 RVA: 0x000E80C4 File Offset: 0x000E62C4
		[SecurityCritical]
		internal TimerQueueTimer(TimerCallback timerCallback, object state, uint dueTime, uint period, ref StackCrawlMark stackMark)
		{
			this.m_timerCallback = timerCallback;
			this.m_state = state;
			this.m_dueTime = uint.MaxValue;
			this.m_period = uint.MaxValue;
			if (!ExecutionContext.IsFlowSuppressed())
			{
				this.m_executionContext = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx | ExecutionContext.CaptureOptions.OptimizeDefaultCase);
			}
			if (dueTime != 4294967295U)
			{
				this.Change(dueTime, period);
			}
		}

		// Token: 0x06003E40 RID: 15936 RVA: 0x000E8118 File Offset: 0x000E6318
		internal bool Change(uint dueTime, uint period)
		{
			TimerQueue instance = TimerQueue.Instance;
			bool result;
			lock (instance)
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
						TimerQueue.Instance.DeleteTimer(this);
						result = true;
					}
					else
					{
						if (FrameworkEventSource.IsInitialized && FrameworkEventSource.Log.IsEnabled(EventLevel.Informational, (EventKeywords)16L))
						{
							FrameworkEventSource.Log.ThreadTransferSendObj(this, 1, string.Empty, true);
						}
						result = TimerQueue.Instance.UpdateTimer(this, dueTime, period);
					}
				}
			}
			return result;
		}

		// Token: 0x06003E41 RID: 15937 RVA: 0x000E81CC File Offset: 0x000E63CC
		public void Close()
		{
			TimerQueue instance = TimerQueue.Instance;
			lock (instance)
			{
				try
				{
				}
				finally
				{
					if (!this.m_canceled)
					{
						this.m_canceled = true;
						TimerQueue.Instance.DeleteTimer(this);
					}
				}
			}
		}

		// Token: 0x06003E42 RID: 15938 RVA: 0x000E8230 File Offset: 0x000E6430
		public bool Close(WaitHandle toSignal)
		{
			bool flag = false;
			TimerQueue instance = TimerQueue.Instance;
			bool result;
			lock (instance)
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
						TimerQueue.Instance.DeleteTimer(this);
						if (this.m_callbacksRunning == 0)
						{
							flag = true;
						}
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

		// Token: 0x06003E43 RID: 15939 RVA: 0x000E82BC File Offset: 0x000E64BC
		internal void Fire()
		{
			bool flag = false;
			TimerQueue instance = TimerQueue.Instance;
			lock (instance)
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
			TimerQueue instance2 = TimerQueue.Instance;
			lock (instance2)
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

		// Token: 0x06003E44 RID: 15940 RVA: 0x000E839C File Offset: 0x000E659C
		[SecuritySafeCritical]
		internal void SignalNoCallbacksRunning()
		{
			Win32Native.SetEvent(this.m_notifyWhenNoCallbacksRunning.SafeWaitHandle);
		}

		// Token: 0x06003E45 RID: 15941 RVA: 0x000E83B4 File Offset: 0x000E65B4
		[SecuritySafeCritical]
		internal void CallCallback()
		{
			if (FrameworkEventSource.IsInitialized && FrameworkEventSource.Log.IsEnabled(EventLevel.Informational, (EventKeywords)16L))
			{
				FrameworkEventSource.Log.ThreadTransferReceiveObj(this, 1, string.Empty);
			}
			if (this.m_executionContext == null)
			{
				this.m_timerCallback(this.m_state);
				return;
			}
			using (ExecutionContext executionContext = this.m_executionContext.IsPreAllocatedDefault ? this.m_executionContext : this.m_executionContext.CreateCopy())
			{
				ContextCallback contextCallback = TimerQueueTimer.s_callCallbackInContext;
				if (contextCallback == null)
				{
					contextCallback = (TimerQueueTimer.s_callCallbackInContext = new ContextCallback(TimerQueueTimer.CallCallbackInContext));
				}
				ExecutionContext.Run(executionContext, contextCallback, this, true);
			}
		}

		// Token: 0x06003E46 RID: 15942 RVA: 0x000E8468 File Offset: 0x000E6668
		[SecurityCritical]
		private static void CallCallbackInContext(object state)
		{
			TimerQueueTimer timerQueueTimer = (TimerQueueTimer)state;
			timerQueueTimer.m_timerCallback(timerQueueTimer.m_state);
		}

		// Token: 0x04001A32 RID: 6706
		internal TimerQueueTimer m_next;

		// Token: 0x04001A33 RID: 6707
		internal TimerQueueTimer m_prev;

		// Token: 0x04001A34 RID: 6708
		internal int m_startTicks;

		// Token: 0x04001A35 RID: 6709
		internal uint m_dueTime;

		// Token: 0x04001A36 RID: 6710
		internal uint m_period;

		// Token: 0x04001A37 RID: 6711
		private readonly TimerCallback m_timerCallback;

		// Token: 0x04001A38 RID: 6712
		private readonly object m_state;

		// Token: 0x04001A39 RID: 6713
		private readonly ExecutionContext m_executionContext;

		// Token: 0x04001A3A RID: 6714
		private int m_callbacksRunning;

		// Token: 0x04001A3B RID: 6715
		private volatile bool m_canceled;

		// Token: 0x04001A3C RID: 6716
		private volatile WaitHandle m_notifyWhenNoCallbacksRunning;

		// Token: 0x04001A3D RID: 6717
		[SecurityCritical]
		private static ContextCallback s_callCallbackInContext;
	}
}
