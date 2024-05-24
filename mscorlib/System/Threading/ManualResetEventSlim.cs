using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x02000542 RID: 1346
	[ComVisible(false)]
	[DebuggerDisplay("Set = {IsSet}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class ManualResetEventSlim : IDisposable
	{
		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x06003F1B RID: 16155 RVA: 0x000EAF6C File Offset: 0x000E916C
		[__DynamicallyInvokable]
		public WaitHandle WaitHandle
		{
			[__DynamicallyInvokable]
			get
			{
				this.ThrowIfDisposed();
				if (this.m_eventObj == null)
				{
					this.LazyInitializeEvent();
				}
				return this.m_eventObj;
			}
		}

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x06003F1C RID: 16156 RVA: 0x000EAF8D File Offset: 0x000E918D
		// (set) Token: 0x06003F1D RID: 16157 RVA: 0x000EAFA4 File Offset: 0x000E91A4
		[__DynamicallyInvokable]
		public bool IsSet
		{
			[__DynamicallyInvokable]
			get
			{
				return ManualResetEventSlim.ExtractStatePortion(this.m_combinedState, int.MinValue) != 0;
			}
			private set
			{
				this.UpdateStateAtomically((value ? 1 : 0) << 31, int.MinValue);
			}
		}

		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06003F1E RID: 16158 RVA: 0x000EAFBB File Offset: 0x000E91BB
		// (set) Token: 0x06003F1F RID: 16159 RVA: 0x000EAFD1 File Offset: 0x000E91D1
		[__DynamicallyInvokable]
		public int SpinCount
		{
			[__DynamicallyInvokable]
			get
			{
				return ManualResetEventSlim.ExtractStatePortionAndShiftRight(this.m_combinedState, 1073217536, 19);
			}
			private set
			{
				this.m_combinedState = ((this.m_combinedState & -1073217537) | value << 19);
			}
		}

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06003F20 RID: 16160 RVA: 0x000EAFEE File Offset: 0x000E91EE
		// (set) Token: 0x06003F21 RID: 16161 RVA: 0x000EB003 File Offset: 0x000E9203
		private int Waiters
		{
			get
			{
				return ManualResetEventSlim.ExtractStatePortionAndShiftRight(this.m_combinedState, 524287, 0);
			}
			set
			{
				if (value >= 524287)
				{
					throw new InvalidOperationException(string.Format(Environment.GetResourceString("ManualResetEventSlim_ctor_TooManyWaiters"), 524287));
				}
				this.UpdateStateAtomically(value, 524287);
			}
		}

		// Token: 0x06003F22 RID: 16162 RVA: 0x000EB038 File Offset: 0x000E9238
		[__DynamicallyInvokable]
		public ManualResetEventSlim() : this(false)
		{
		}

		// Token: 0x06003F23 RID: 16163 RVA: 0x000EB041 File Offset: 0x000E9241
		[__DynamicallyInvokable]
		public ManualResetEventSlim(bool initialState)
		{
			this.Initialize(initialState, 10);
		}

		// Token: 0x06003F24 RID: 16164 RVA: 0x000EB054 File Offset: 0x000E9254
		[__DynamicallyInvokable]
		public ManualResetEventSlim(bool initialState, int spinCount)
		{
			if (spinCount < 0)
			{
				throw new ArgumentOutOfRangeException("spinCount");
			}
			if (spinCount > 2047)
			{
				throw new ArgumentOutOfRangeException("spinCount", string.Format(Environment.GetResourceString("ManualResetEventSlim_ctor_SpinCountOutOfRange"), 2047));
			}
			this.Initialize(initialState, spinCount);
		}

		// Token: 0x06003F25 RID: 16165 RVA: 0x000EB0AA File Offset: 0x000E92AA
		private void Initialize(bool initialState, int spinCount)
		{
			this.m_combinedState = (initialState ? int.MinValue : 0);
			this.SpinCount = (PlatformHelper.IsSingleProcessor ? 1 : spinCount);
		}

		// Token: 0x06003F26 RID: 16166 RVA: 0x000EB0D0 File Offset: 0x000E92D0
		private void EnsureLockObjectCreated()
		{
			if (this.m_lock != null)
			{
				return;
			}
			object value = new object();
			Interlocked.CompareExchange(ref this.m_lock, value, null);
		}

		// Token: 0x06003F27 RID: 16167 RVA: 0x000EB0FC File Offset: 0x000E92FC
		private bool LazyInitializeEvent()
		{
			bool isSet = this.IsSet;
			ManualResetEvent manualResetEvent = new ManualResetEvent(isSet);
			if (Interlocked.CompareExchange<ManualResetEvent>(ref this.m_eventObj, manualResetEvent, null) != null)
			{
				manualResetEvent.Close();
				return false;
			}
			bool isSet2 = this.IsSet;
			if (isSet2 != isSet)
			{
				ManualResetEvent obj = manualResetEvent;
				lock (obj)
				{
					if (this.m_eventObj == manualResetEvent)
					{
						manualResetEvent.Set();
					}
				}
			}
			return true;
		}

		// Token: 0x06003F28 RID: 16168 RVA: 0x000EB178 File Offset: 0x000E9378
		[__DynamicallyInvokable]
		public void Set()
		{
			this.Set(false);
		}

		// Token: 0x06003F29 RID: 16169 RVA: 0x000EB184 File Offset: 0x000E9384
		private void Set(bool duringCancellation)
		{
			this.IsSet = true;
			if (this.Waiters > 0)
			{
				object @lock = this.m_lock;
				lock (@lock)
				{
					Monitor.PulseAll(this.m_lock);
				}
			}
			ManualResetEvent eventObj = this.m_eventObj;
			if (eventObj != null && !duringCancellation)
			{
				ManualResetEvent obj = eventObj;
				lock (obj)
				{
					if (this.m_eventObj != null)
					{
						this.m_eventObj.Set();
					}
				}
			}
		}

		// Token: 0x06003F2A RID: 16170 RVA: 0x000EB22C File Offset: 0x000E942C
		[__DynamicallyInvokable]
		public void Reset()
		{
			this.ThrowIfDisposed();
			if (this.m_eventObj != null)
			{
				this.m_eventObj.Reset();
			}
			this.IsSet = false;
		}

		// Token: 0x06003F2B RID: 16171 RVA: 0x000EB254 File Offset: 0x000E9454
		[__DynamicallyInvokable]
		public void Wait()
		{
			this.Wait(-1, default(CancellationToken));
		}

		// Token: 0x06003F2C RID: 16172 RVA: 0x000EB272 File Offset: 0x000E9472
		[__DynamicallyInvokable]
		public void Wait(CancellationToken cancellationToken)
		{
			this.Wait(-1, cancellationToken);
		}

		// Token: 0x06003F2D RID: 16173 RVA: 0x000EB280 File Offset: 0x000E9480
		[__DynamicallyInvokable]
		public bool Wait(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout");
			}
			return this.Wait((int)num, default(CancellationToken));
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x000EB2C0 File Offset: 0x000E94C0
		[__DynamicallyInvokable]
		public bool Wait(TimeSpan timeout, CancellationToken cancellationToken)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout");
			}
			return this.Wait((int)num, cancellationToken);
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x000EB2F8 File Offset: 0x000E94F8
		[__DynamicallyInvokable]
		public bool Wait(int millisecondsTimeout)
		{
			return this.Wait(millisecondsTimeout, default(CancellationToken));
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x000EB318 File Offset: 0x000E9518
		[__DynamicallyInvokable]
		public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken)
		{
			this.ThrowIfDisposed();
			cancellationToken.ThrowIfCancellationRequested();
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout");
			}
			if (!this.IsSet)
			{
				if (millisecondsTimeout == 0)
				{
					return false;
				}
				uint startTime = 0U;
				bool flag = false;
				int num = millisecondsTimeout;
				if (millisecondsTimeout != -1)
				{
					startTime = TimeoutHelper.GetTime();
					flag = true;
				}
				int num2 = 10;
				int num3 = 5;
				int num4 = 20;
				int spinCount = this.SpinCount;
				for (int i = 0; i < spinCount; i++)
				{
					if (this.IsSet)
					{
						return true;
					}
					if (i < num2)
					{
						if (i == num2 / 2)
						{
							Thread.Yield();
						}
						else
						{
							Thread.SpinWait(4 << i);
						}
					}
					else if (i % num4 == 0)
					{
						Thread.Sleep(1);
					}
					else if (i % num3 == 0)
					{
						Thread.Sleep(0);
					}
					else
					{
						Thread.Yield();
					}
					if (i >= 100 && i % 10 == 0)
					{
						cancellationToken.ThrowIfCancellationRequested();
					}
				}
				this.EnsureLockObjectCreated();
				using (cancellationToken.InternalRegisterWithoutEC(ManualResetEventSlim.s_cancellationTokenCallback, this))
				{
					object @lock = this.m_lock;
					lock (@lock)
					{
						while (!this.IsSet)
						{
							cancellationToken.ThrowIfCancellationRequested();
							if (flag)
							{
								num = TimeoutHelper.UpdateTimeOut(startTime, millisecondsTimeout);
								if (num <= 0)
								{
									return false;
								}
							}
							this.Waiters++;
							if (this.IsSet)
							{
								int waiters = this.Waiters;
								this.Waiters = waiters - 1;
								return true;
							}
							try
							{
								if (!Monitor.Wait(this.m_lock, num))
								{
									return false;
								}
							}
							finally
							{
								this.Waiters--;
							}
						}
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x06003F31 RID: 16177 RVA: 0x000EB4D8 File Offset: 0x000E96D8
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003F32 RID: 16178 RVA: 0x000EB4E8 File Offset: 0x000E96E8
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			if ((this.m_combinedState & 1073741824) != 0)
			{
				return;
			}
			this.m_combinedState |= 1073741824;
			if (disposing)
			{
				ManualResetEvent eventObj = this.m_eventObj;
				if (eventObj != null)
				{
					ManualResetEvent obj = eventObj;
					lock (obj)
					{
						eventObj.Close();
						this.m_eventObj = null;
					}
				}
			}
		}

		// Token: 0x06003F33 RID: 16179 RVA: 0x000EB564 File Offset: 0x000E9764
		private void ThrowIfDisposed()
		{
			if ((this.m_combinedState & 1073741824) != 0)
			{
				throw new ObjectDisposedException(Environment.GetResourceString("ManualResetEventSlim_Disposed"));
			}
		}

		// Token: 0x06003F34 RID: 16180 RVA: 0x000EB588 File Offset: 0x000E9788
		private static void CancellationTokenCallback(object obj)
		{
			ManualResetEventSlim manualResetEventSlim = obj as ManualResetEventSlim;
			object @lock = manualResetEventSlim.m_lock;
			lock (@lock)
			{
				Monitor.PulseAll(manualResetEventSlim.m_lock);
			}
		}

		// Token: 0x06003F35 RID: 16181 RVA: 0x000EB5D8 File Offset: 0x000E97D8
		private void UpdateStateAtomically(int newBits, int updateBitsMask)
		{
			SpinWait spinWait = default(SpinWait);
			for (;;)
			{
				int combinedState = this.m_combinedState;
				int value = (combinedState & ~updateBitsMask) | newBits;
				if (Interlocked.CompareExchange(ref this.m_combinedState, value, combinedState) == combinedState)
				{
					break;
				}
				spinWait.SpinOnce();
			}
		}

		// Token: 0x06003F36 RID: 16182 RVA: 0x000EB616 File Offset: 0x000E9816
		private static int ExtractStatePortionAndShiftRight(int state, int mask, int rightBitShiftCount)
		{
			return (int)((uint)(state & mask) >> rightBitShiftCount);
		}

		// Token: 0x06003F37 RID: 16183 RVA: 0x000EB620 File Offset: 0x000E9820
		private static int ExtractStatePortion(int state, int mask)
		{
			return state & mask;
		}

		// Token: 0x04001A83 RID: 6787
		private const int DEFAULT_SPIN_SP = 1;

		// Token: 0x04001A84 RID: 6788
		private const int DEFAULT_SPIN_MP = 10;

		// Token: 0x04001A85 RID: 6789
		private volatile object m_lock;

		// Token: 0x04001A86 RID: 6790
		private volatile ManualResetEvent m_eventObj;

		// Token: 0x04001A87 RID: 6791
		private volatile int m_combinedState;

		// Token: 0x04001A88 RID: 6792
		private const int SignalledState_BitMask = -2147483648;

		// Token: 0x04001A89 RID: 6793
		private const int SignalledState_ShiftCount = 31;

		// Token: 0x04001A8A RID: 6794
		private const int Dispose_BitMask = 1073741824;

		// Token: 0x04001A8B RID: 6795
		private const int SpinCountState_BitMask = 1073217536;

		// Token: 0x04001A8C RID: 6796
		private const int SpinCountState_ShiftCount = 19;

		// Token: 0x04001A8D RID: 6797
		private const int SpinCountState_MaxValue = 2047;

		// Token: 0x04001A8E RID: 6798
		private const int NumWaitersState_BitMask = 524287;

		// Token: 0x04001A8F RID: 6799
		private const int NumWaitersState_ShiftCount = 0;

		// Token: 0x04001A90 RID: 6800
		private const int NumWaitersState_MaxValue = 524287;

		// Token: 0x04001A91 RID: 6801
		private static Action<object> s_cancellationTokenCallback = new Action<object>(ManualResetEventSlim.CancellationTokenCallback);
	}
}
