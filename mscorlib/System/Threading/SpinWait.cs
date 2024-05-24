using System;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x02000537 RID: 1335
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct SpinWait
	{
		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x06003EB5 RID: 16053 RVA: 0x000E978B File Offset: 0x000E798B
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x06003EB6 RID: 16054 RVA: 0x000E9793 File Offset: 0x000E7993
		[__DynamicallyInvokable]
		public bool NextSpinWillYield
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_count > 10 || PlatformHelper.IsSingleProcessor;
			}
		}

		// Token: 0x06003EB7 RID: 16055 RVA: 0x000E97A8 File Offset: 0x000E79A8
		[__DynamicallyInvokable]
		public void SpinOnce()
		{
			if (this.NextSpinWillYield)
			{
				CdsSyncEtwBCLProvider.Log.SpinWait_NextSpinWillYield();
				int num = (this.m_count >= 10) ? (this.m_count - 10) : this.m_count;
				if (num % 20 == 19)
				{
					Thread.Sleep(1);
				}
				else if (num % 5 == 4)
				{
					Thread.Sleep(0);
				}
				else
				{
					Thread.Yield();
				}
			}
			else
			{
				Thread.SpinWait(4 << this.m_count);
			}
			this.m_count = ((this.m_count == int.MaxValue) ? 10 : (this.m_count + 1));
		}

		// Token: 0x06003EB8 RID: 16056 RVA: 0x000E9838 File Offset: 0x000E7A38
		[__DynamicallyInvokable]
		public void Reset()
		{
			this.m_count = 0;
		}

		// Token: 0x06003EB9 RID: 16057 RVA: 0x000E9841 File Offset: 0x000E7A41
		[__DynamicallyInvokable]
		public static void SpinUntil(Func<bool> condition)
		{
			SpinWait.SpinUntil(condition, -1);
		}

		// Token: 0x06003EBA RID: 16058 RVA: 0x000E984C File Offset: 0x000E7A4C
		[__DynamicallyInvokable]
		public static bool SpinUntil(Func<bool> condition, TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, Environment.GetResourceString("SpinWait_SpinUntil_TimeoutWrong"));
			}
			return SpinWait.SpinUntil(condition, (int)timeout.TotalMilliseconds);
		}

		// Token: 0x06003EBB RID: 16059 RVA: 0x000E989C File Offset: 0x000E7A9C
		[__DynamicallyInvokable]
		public static bool SpinUntil(Func<bool> condition, int millisecondsTimeout)
		{
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout", millisecondsTimeout, Environment.GetResourceString("SpinWait_SpinUntil_TimeoutWrong"));
			}
			if (condition == null)
			{
				throw new ArgumentNullException("condition", Environment.GetResourceString("SpinWait_SpinUntil_ArgumentNull"));
			}
			uint num = 0U;
			if (millisecondsTimeout != 0 && millisecondsTimeout != -1)
			{
				num = TimeoutHelper.GetTime();
			}
			SpinWait spinWait = default(SpinWait);
			while (!condition())
			{
				if (millisecondsTimeout == 0)
				{
					return false;
				}
				spinWait.SpinOnce();
				if (millisecondsTimeout != -1 && spinWait.NextSpinWillYield && (long)millisecondsTimeout <= (long)((ulong)(TimeoutHelper.GetTime() - num)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04001A5B RID: 6747
		internal const int YIELD_THRESHOLD = 10;

		// Token: 0x04001A5C RID: 6748
		internal const int SLEEP_0_EVERY_HOW_MANY_TIMES = 5;

		// Token: 0x04001A5D RID: 6749
		internal const int SLEEP_1_EVERY_HOW_MANY_TIMES = 20;

		// Token: 0x04001A5E RID: 6750
		private int m_count;
	}
}
