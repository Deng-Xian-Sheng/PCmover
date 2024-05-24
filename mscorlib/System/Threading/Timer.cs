using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.NetCore;

namespace System.Threading
{
	// Token: 0x02000530 RID: 1328
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class Timer : MarshalByRefObject, IDisposable
	{
		// Token: 0x06003E4E RID: 15950 RVA: 0x000E8598 File Offset: 0x000E6798
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, int dueTime, int period)
		{
			if (dueTime < -1)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, (uint)dueTime, (uint)period, ref stackCrawlMark);
		}

		// Token: 0x06003E4F RID: 15951 RVA: 0x000E85F0 File Offset: 0x000E67F0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
			long num = (long)dueTime.TotalMilliseconds;
			if (num < -1L)
			{
				throw new ArgumentOutOfRangeException("dueTm", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (num > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("dueTm", Environment.GetResourceString("ArgumentOutOfRange_TimeoutTooLarge"));
			}
			long num2 = (long)period.TotalMilliseconds;
			if (num2 < -1L)
			{
				throw new ArgumentOutOfRangeException("periodTm", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (num2 > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("periodTm", Environment.GetResourceString("ArgumentOutOfRange_PeriodTooLarge"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, (uint)num, (uint)num2, ref stackCrawlMark);
		}

		// Token: 0x06003E50 RID: 15952 RVA: 0x000E8690 File Offset: 0x000E6890
		[CLSCompliant(false)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, uint dueTime, uint period)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, dueTime, period, ref stackCrawlMark);
		}

		// Token: 0x06003E51 RID: 15953 RVA: 0x000E86B4 File Offset: 0x000E68B4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback, object state, long dueTime, long period)
		{
			if (dueTime < -1L)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1L)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (dueTime > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_TimeoutTooLarge"));
			}
			if (period > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_PeriodTooLarge"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, state, (uint)dueTime, (uint)period, ref stackCrawlMark);
		}

		// Token: 0x06003E52 RID: 15954 RVA: 0x000E8744 File Offset: 0x000E6944
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Timer(TimerCallback callback)
		{
			int dueTime = -1;
			int period = -1;
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			this.TimerSetup(callback, this, (uint)dueTime, (uint)period, ref stackCrawlMark);
		}

		// Token: 0x06003E53 RID: 15955 RVA: 0x000E876C File Offset: 0x000E696C
		[SecurityCritical]
		private void TimerSetup(TimerCallback callback, object state, uint dueTime, uint period, ref StackCrawlMark stackMark)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("TimerCallback");
			}
			object timer;
			if (Timer.UseNetCoreTimer)
			{
				timer = new TimerQueueTimer(callback, state, dueTime, period, true, ref stackMark);
			}
			else
			{
				timer = new TimerQueueTimer(callback, state, dueTime, period, ref stackMark);
			}
			this.m_timer = new TimerHolder(timer);
		}

		// Token: 0x06003E54 RID: 15956 RVA: 0x000E87B7 File Offset: 0x000E69B7
		[SecurityCritical]
		internal static void Pause()
		{
			if (Timer.UseNetCoreTimer)
			{
				TimerQueue.PauseAll();
				return;
			}
			TimerQueue.Instance.Pause();
		}

		// Token: 0x06003E55 RID: 15957 RVA: 0x000E87D0 File Offset: 0x000E69D0
		[SecurityCritical]
		internal static void Resume()
		{
			if (Timer.UseNetCoreTimer)
			{
				TimerQueue.ResumeAll();
				return;
			}
			TimerQueue.Instance.Resume();
		}

		// Token: 0x06003E56 RID: 15958 RVA: 0x000E87EC File Offset: 0x000E69EC
		[__DynamicallyInvokable]
		public bool Change(int dueTime, int period)
		{
			if (dueTime < -1)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.m_timer.Change((uint)dueTime, (uint)period);
		}

		// Token: 0x06003E57 RID: 15959 RVA: 0x000E8838 File Offset: 0x000E6A38
		[__DynamicallyInvokable]
		public bool Change(TimeSpan dueTime, TimeSpan period)
		{
			return this.Change((long)dueTime.TotalMilliseconds, (long)period.TotalMilliseconds);
		}

		// Token: 0x06003E58 RID: 15960 RVA: 0x000E8850 File Offset: 0x000E6A50
		[CLSCompliant(false)]
		public bool Change(uint dueTime, uint period)
		{
			return this.m_timer.Change(dueTime, period);
		}

		// Token: 0x06003E59 RID: 15961 RVA: 0x000E8860 File Offset: 0x000E6A60
		public bool Change(long dueTime, long period)
		{
			if (dueTime < -1L)
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (period < -1L)
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			if (dueTime > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("dueTime", Environment.GetResourceString("ArgumentOutOfRange_TimeoutTooLarge"));
			}
			if (period > (long)((ulong)-2))
			{
				throw new ArgumentOutOfRangeException("period", Environment.GetResourceString("ArgumentOutOfRange_PeriodTooLarge"));
			}
			return this.m_timer.Change((uint)dueTime, (uint)period);
		}

		// Token: 0x06003E5A RID: 15962 RVA: 0x000E88E6 File Offset: 0x000E6AE6
		public bool Dispose(WaitHandle notifyObject)
		{
			if (notifyObject == null)
			{
				throw new ArgumentNullException("notifyObject");
			}
			return this.m_timer.Close(notifyObject);
		}

		// Token: 0x06003E5B RID: 15963 RVA: 0x000E8902 File Offset: 0x000E6B02
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.m_timer.Close();
		}

		// Token: 0x06003E5C RID: 15964 RVA: 0x000E890F File Offset: 0x000E6B0F
		internal void KeepRootedWhileScheduled()
		{
			GC.SuppressFinalize(this.m_timer);
		}

		// Token: 0x04001A3F RID: 6719
		internal static readonly bool UseNetCoreTimer = AppContextSwitches.UseNetCoreTimer;

		// Token: 0x04001A40 RID: 6720
		private const uint MAX_SUPPORTED_TIMEOUT = 4294967294U;

		// Token: 0x04001A41 RID: 6721
		private TimerHolder m_timer;
	}
}
