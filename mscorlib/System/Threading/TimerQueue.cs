using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.NetCore;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
	// Token: 0x0200052D RID: 1325
	internal class TimerQueue
	{
		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x06003E2F RID: 15919 RVA: 0x000E7BE2 File Offset: 0x000E5DE2
		public static TimerQueue Instance
		{
			get
			{
				return TimerQueue.s_queue;
			}
		}

		// Token: 0x06003E30 RID: 15920 RVA: 0x000E7BE9 File Offset: 0x000E5DE9
		private TimerQueue()
		{
		}

		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x06003E31 RID: 15921 RVA: 0x000E7BF4 File Offset: 0x000E5DF4
		private static int TickCount
		{
			[SecuritySafeCritical]
			get
			{
				if (!Environment.IsWindows8OrAbove)
				{
					return Environment.TickCount;
				}
				ulong num;
				if (!Win32Native.QueryUnbiasedInterruptTime(out num))
				{
					throw Marshal.GetExceptionForHR(Marshal.GetLastWin32Error());
				}
				return (int)((uint)(num / 10000UL));
			}
		}

		// Token: 0x06003E32 RID: 15922 RVA: 0x000E7C30 File Offset: 0x000E5E30
		[SecuritySafeCritical]
		private bool EnsureAppDomainTimerFiresBy(uint requestedDuration)
		{
			uint num = Math.Min(requestedDuration, 268435455U);
			if (this.m_isAppDomainTimerScheduled)
			{
				uint num2 = (uint)(TimerQueue.TickCount - this.m_currentAppDomainTimerStartTicks);
				if (num2 >= this.m_currentAppDomainTimerDuration)
				{
					return true;
				}
				uint num3 = this.m_currentAppDomainTimerDuration - num2;
				if (num >= num3)
				{
					return true;
				}
			}
			if (this.m_pauseTicks != 0)
			{
				return true;
			}
			if (this.m_appDomainTimer == null || this.m_appDomainTimer.IsInvalid)
			{
				this.m_appDomainTimer = TimerQueue.CreateAppDomainTimer(num, 0);
				if (!this.m_appDomainTimer.IsInvalid)
				{
					this.m_isAppDomainTimerScheduled = true;
					this.m_currentAppDomainTimerStartTicks = TimerQueue.TickCount;
					this.m_currentAppDomainTimerDuration = num;
					return true;
				}
				return false;
			}
			else
			{
				if (TimerQueue.ChangeAppDomainTimer(this.m_appDomainTimer, num))
				{
					this.m_isAppDomainTimerScheduled = true;
					this.m_currentAppDomainTimerStartTicks = TimerQueue.TickCount;
					this.m_currentAppDomainTimerDuration = num;
					return true;
				}
				return false;
			}
		}

		// Token: 0x06003E33 RID: 15923 RVA: 0x000E7CFA File Offset: 0x000E5EFA
		[SecuritySafeCritical]
		internal static void AppDomainTimerCallback(int id)
		{
			if (Timer.UseNetCoreTimer)
			{
				TimerQueue.AppDomainTimerCallback(id);
				return;
			}
			TimerQueue.Instance.FireNextTimers();
		}

		// Token: 0x06003E34 RID: 15924
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern TimerQueue.AppDomainTimerSafeHandle CreateAppDomainTimer(uint dueTime, int id);

		// Token: 0x06003E35 RID: 15925
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern bool ChangeAppDomainTimer(TimerQueue.AppDomainTimerSafeHandle handle, uint dueTime);

		// Token: 0x06003E36 RID: 15926
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern bool DeleteAppDomainTimer(IntPtr handle);

		// Token: 0x06003E37 RID: 15927 RVA: 0x000E7D14 File Offset: 0x000E5F14
		[SecurityCritical]
		internal void Pause()
		{
			lock (this)
			{
				if (this.m_appDomainTimer != null && !this.m_appDomainTimer.IsInvalid)
				{
					this.m_appDomainTimer.Dispose();
					this.m_appDomainTimer = null;
					this.m_isAppDomainTimerScheduled = false;
					this.m_pauseTicks = TimerQueue.TickCount;
				}
			}
		}

		// Token: 0x06003E38 RID: 15928 RVA: 0x000E7D84 File Offset: 0x000E5F84
		[SecurityCritical]
		internal void Resume()
		{
			lock (this)
			{
				try
				{
				}
				finally
				{
					int pauseTicks = this.m_pauseTicks;
					this.m_pauseTicks = 0;
					int tickCount = TimerQueue.TickCount;
					int num = tickCount - pauseTicks;
					bool flag2 = false;
					uint num2 = uint.MaxValue;
					for (TimerQueueTimer timerQueueTimer = this.m_timers; timerQueueTimer != null; timerQueueTimer = timerQueueTimer.m_next)
					{
						uint num3;
						if (timerQueueTimer.m_startTicks <= pauseTicks)
						{
							num3 = (uint)(pauseTicks - timerQueueTimer.m_startTicks);
						}
						else
						{
							num3 = (uint)(tickCount - timerQueueTimer.m_startTicks);
						}
						timerQueueTimer.m_dueTime = ((timerQueueTimer.m_dueTime > num3) ? (timerQueueTimer.m_dueTime - num3) : 0U);
						timerQueueTimer.m_startTicks = tickCount;
						if (timerQueueTimer.m_dueTime < num2)
						{
							flag2 = true;
							num2 = timerQueueTimer.m_dueTime;
						}
					}
					if (flag2)
					{
						this.EnsureAppDomainTimerFiresBy(num2);
					}
				}
			}
		}

		// Token: 0x06003E39 RID: 15929 RVA: 0x000E7E70 File Offset: 0x000E6070
		private void FireNextTimers()
		{
			TimerQueueTimer timerQueueTimer = null;
			lock (this)
			{
				try
				{
				}
				finally
				{
					this.m_isAppDomainTimerScheduled = false;
					bool flag2 = false;
					uint num = uint.MaxValue;
					int tickCount = TimerQueue.TickCount;
					TimerQueueTimer timerQueueTimer2 = this.m_timers;
					while (timerQueueTimer2 != null)
					{
						uint num2 = (uint)(tickCount - timerQueueTimer2.m_startTicks);
						if (num2 >= timerQueueTimer2.m_dueTime)
						{
							TimerQueueTimer next = timerQueueTimer2.m_next;
							if (timerQueueTimer2.m_period != 4294967295U)
							{
								timerQueueTimer2.m_startTicks = tickCount;
								timerQueueTimer2.m_dueTime = timerQueueTimer2.m_period;
								if (timerQueueTimer2.m_dueTime < num)
								{
									flag2 = true;
									num = timerQueueTimer2.m_dueTime;
								}
							}
							else
							{
								this.DeleteTimer(timerQueueTimer2);
							}
							if (timerQueueTimer == null)
							{
								timerQueueTimer = timerQueueTimer2;
							}
							else
							{
								TimerQueue.QueueTimerCompletion(timerQueueTimer2);
							}
							timerQueueTimer2 = next;
						}
						else
						{
							uint num3 = timerQueueTimer2.m_dueTime - num2;
							if (num3 < num)
							{
								flag2 = true;
								num = num3;
							}
							timerQueueTimer2 = timerQueueTimer2.m_next;
						}
					}
					if (flag2)
					{
						this.EnsureAppDomainTimerFiresBy(num);
					}
				}
			}
			if (timerQueueTimer != null)
			{
				timerQueueTimer.Fire();
			}
		}

		// Token: 0x06003E3A RID: 15930 RVA: 0x000E7F8C File Offset: 0x000E618C
		[SecuritySafeCritical]
		private static void QueueTimerCompletion(TimerQueueTimer timer)
		{
			WaitCallback waitCallback = TimerQueue.s_fireQueuedTimerCompletion;
			if (waitCallback == null)
			{
				waitCallback = (TimerQueue.s_fireQueuedTimerCompletion = new WaitCallback(TimerQueue.FireQueuedTimerCompletion));
			}
			ThreadPool.UnsafeQueueUserWorkItem(waitCallback, timer);
		}

		// Token: 0x06003E3B RID: 15931 RVA: 0x000E7FBD File Offset: 0x000E61BD
		private static void FireQueuedTimerCompletion(object state)
		{
			((TimerQueueTimer)state).Fire();
		}

		// Token: 0x06003E3C RID: 15932 RVA: 0x000E7FCC File Offset: 0x000E61CC
		public bool UpdateTimer(TimerQueueTimer timer, uint dueTime, uint period)
		{
			if (timer.m_dueTime == 4294967295U)
			{
				timer.m_next = this.m_timers;
				timer.m_prev = null;
				if (timer.m_next != null)
				{
					timer.m_next.m_prev = timer;
				}
				this.m_timers = timer;
			}
			timer.m_dueTime = dueTime;
			timer.m_period = ((period == 0U) ? uint.MaxValue : period);
			timer.m_startTicks = TimerQueue.TickCount;
			return this.EnsureAppDomainTimerFiresBy(dueTime);
		}

		// Token: 0x06003E3D RID: 15933 RVA: 0x000E8038 File Offset: 0x000E6238
		public void DeleteTimer(TimerQueueTimer timer)
		{
			if (timer.m_dueTime != 4294967295U)
			{
				if (timer.m_next != null)
				{
					timer.m_next.m_prev = timer.m_prev;
				}
				if (timer.m_prev != null)
				{
					timer.m_prev.m_next = timer.m_next;
				}
				if (this.m_timers == timer)
				{
					this.m_timers = timer.m_next;
				}
				timer.m_dueTime = uint.MaxValue;
				timer.m_period = uint.MaxValue;
				timer.m_startTicks = 0;
				timer.m_prev = null;
				timer.m_next = null;
			}
		}

		// Token: 0x04001A2A RID: 6698
		private static TimerQueue s_queue = new TimerQueue();

		// Token: 0x04001A2B RID: 6699
		[SecurityCritical]
		private TimerQueue.AppDomainTimerSafeHandle m_appDomainTimer;

		// Token: 0x04001A2C RID: 6700
		private bool m_isAppDomainTimerScheduled;

		// Token: 0x04001A2D RID: 6701
		private int m_currentAppDomainTimerStartTicks;

		// Token: 0x04001A2E RID: 6702
		private uint m_currentAppDomainTimerDuration;

		// Token: 0x04001A2F RID: 6703
		private TimerQueueTimer m_timers;

		// Token: 0x04001A30 RID: 6704
		private volatile int m_pauseTicks;

		// Token: 0x04001A31 RID: 6705
		private static WaitCallback s_fireQueuedTimerCompletion;

		// Token: 0x02000BF7 RID: 3063
		[SecurityCritical]
		internal class AppDomainTimerSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
		{
			// Token: 0x06006F7D RID: 28541 RVA: 0x0018060F File Offset: 0x0017E80F
			public AppDomainTimerSafeHandle() : base(true)
			{
			}

			// Token: 0x06006F7E RID: 28542 RVA: 0x00180618 File Offset: 0x0017E818
			[SecurityCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			protected override bool ReleaseHandle()
			{
				return TimerQueue.DeleteAppDomainTimer(this.handle);
			}
		}
	}
}
