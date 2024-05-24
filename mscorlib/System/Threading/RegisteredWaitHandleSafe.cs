using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32;

namespace System.Threading
{
	// Token: 0x0200051C RID: 1308
	internal sealed class RegisteredWaitHandleSafe : CriticalFinalizerObject
	{
		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x06003DC7 RID: 15815 RVA: 0x000E7210 File Offset: 0x000E5410
		private static IntPtr InvalidHandle
		{
			[SecuritySafeCritical]
			get
			{
				return Win32Native.INVALID_HANDLE_VALUE;
			}
		}

		// Token: 0x06003DC8 RID: 15816 RVA: 0x000E7217 File Offset: 0x000E5417
		internal RegisteredWaitHandleSafe()
		{
			this.registeredWaitHandle = RegisteredWaitHandleSafe.InvalidHandle;
		}

		// Token: 0x06003DC9 RID: 15817 RVA: 0x000E722A File Offset: 0x000E542A
		internal IntPtr GetHandle()
		{
			return this.registeredWaitHandle;
		}

		// Token: 0x06003DCA RID: 15818 RVA: 0x000E7232 File Offset: 0x000E5432
		internal void SetHandle(IntPtr handle)
		{
			this.registeredWaitHandle = handle;
		}

		// Token: 0x06003DCB RID: 15819 RVA: 0x000E723C File Offset: 0x000E543C
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal void SetWaitObject(WaitHandle waitObject)
		{
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				this.m_internalWaitObject = waitObject;
				if (waitObject != null)
				{
					this.m_internalWaitObject.SafeWaitHandle.DangerousAddRef(ref this.bReleaseNeeded);
				}
			}
		}

		// Token: 0x06003DCC RID: 15820 RVA: 0x000E7284 File Offset: 0x000E5484
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal bool Unregister(WaitHandle waitObject)
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				bool flag2 = false;
				do
				{
					if (Interlocked.CompareExchange(ref this.m_lock, 1, 0) == 0)
					{
						flag2 = true;
						try
						{
							if (this.ValidHandle())
							{
								flag = RegisteredWaitHandleSafe.UnregisterWaitNative(this.GetHandle(), (waitObject == null) ? null : waitObject.SafeWaitHandle);
								if (flag)
								{
									if (this.bReleaseNeeded)
									{
										this.m_internalWaitObject.SafeWaitHandle.DangerousRelease();
										this.bReleaseNeeded = false;
									}
									this.SetHandle(RegisteredWaitHandleSafe.InvalidHandle);
									this.m_internalWaitObject = null;
									GC.SuppressFinalize(this);
								}
							}
						}
						finally
						{
							this.m_lock = 0;
						}
					}
					Thread.SpinWait(1);
				}
				while (!flag2);
			}
			return flag;
		}

		// Token: 0x06003DCD RID: 15821 RVA: 0x000E7340 File Offset: 0x000E5540
		private bool ValidHandle()
		{
			return this.registeredWaitHandle != RegisteredWaitHandleSafe.InvalidHandle && this.registeredWaitHandle != IntPtr.Zero;
		}

		// Token: 0x06003DCE RID: 15822 RVA: 0x000E7368 File Offset: 0x000E5568
		[SecuritySafeCritical]
		~RegisteredWaitHandleSafe()
		{
			if (Interlocked.CompareExchange(ref this.m_lock, 1, 0) == 0)
			{
				try
				{
					if (this.ValidHandle())
					{
						RegisteredWaitHandleSafe.WaitHandleCleanupNative(this.registeredWaitHandle);
						if (this.bReleaseNeeded)
						{
							this.m_internalWaitObject.SafeWaitHandle.DangerousRelease();
							this.bReleaseNeeded = false;
						}
						this.SetHandle(RegisteredWaitHandleSafe.InvalidHandle);
						this.m_internalWaitObject = null;
					}
				}
				finally
				{
					this.m_lock = 0;
				}
			}
		}

		// Token: 0x06003DCF RID: 15823
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WaitHandleCleanupNative(IntPtr handle);

		// Token: 0x06003DD0 RID: 15824
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UnregisterWaitNative(IntPtr handle, SafeHandle waitObject);

		// Token: 0x04001A08 RID: 6664
		private IntPtr registeredWaitHandle;

		// Token: 0x04001A09 RID: 6665
		private WaitHandle m_internalWaitObject;

		// Token: 0x04001A0A RID: 6666
		private bool bReleaseNeeded;

		// Token: 0x04001A0B RID: 6667
		private volatile int m_lock;
	}
}
