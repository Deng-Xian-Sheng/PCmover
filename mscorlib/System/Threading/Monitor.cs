using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x02000500 RID: 1280
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public static class Monitor
	{
		// Token: 0x06003C5B RID: 15451
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Enter(object obj);

		// Token: 0x06003C5C RID: 15452 RVA: 0x000E4244 File Offset: 0x000E2444
		[__DynamicallyInvokable]
		public static void Enter(object obj, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnter(obj, ref lockTaken);
		}

		// Token: 0x06003C5D RID: 15453 RVA: 0x000E4256 File Offset: 0x000E2456
		private static void ThrowLockTakenException()
		{
			throw new ArgumentException(Environment.GetResourceString("Argument_MustBeFalse"), "lockTaken");
		}

		// Token: 0x06003C5E RID: 15454
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReliableEnter(object obj, ref bool lockTaken);

		// Token: 0x06003C5F RID: 15455
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Exit(object obj);

		// Token: 0x06003C60 RID: 15456 RVA: 0x000E426C File Offset: 0x000E246C
		[__DynamicallyInvokable]
		public static bool TryEnter(object obj)
		{
			bool result = false;
			Monitor.TryEnter(obj, 0, ref result);
			return result;
		}

		// Token: 0x06003C61 RID: 15457 RVA: 0x000E4285 File Offset: 0x000E2485
		[__DynamicallyInvokable]
		public static void TryEnter(object obj, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnterTimeout(obj, 0, ref lockTaken);
		}

		// Token: 0x06003C62 RID: 15458 RVA: 0x000E4298 File Offset: 0x000E2498
		[__DynamicallyInvokable]
		public static bool TryEnter(object obj, int millisecondsTimeout)
		{
			bool result = false;
			Monitor.TryEnter(obj, millisecondsTimeout, ref result);
			return result;
		}

		// Token: 0x06003C63 RID: 15459 RVA: 0x000E42B4 File Offset: 0x000E24B4
		private static int MillisecondsTimeoutFromTimeSpan(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return (int)num;
		}

		// Token: 0x06003C64 RID: 15460 RVA: 0x000E42EF File Offset: 0x000E24EF
		[__DynamicallyInvokable]
		public static bool TryEnter(object obj, TimeSpan timeout)
		{
			return Monitor.TryEnter(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout));
		}

		// Token: 0x06003C65 RID: 15461 RVA: 0x000E42FD File Offset: 0x000E24FD
		[__DynamicallyInvokable]
		public static void TryEnter(object obj, int millisecondsTimeout, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnterTimeout(obj, millisecondsTimeout, ref lockTaken);
		}

		// Token: 0x06003C66 RID: 15462 RVA: 0x000E4310 File Offset: 0x000E2510
		[__DynamicallyInvokable]
		public static void TryEnter(object obj, TimeSpan timeout, ref bool lockTaken)
		{
			if (lockTaken)
			{
				Monitor.ThrowLockTakenException();
			}
			Monitor.ReliableEnterTimeout(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout), ref lockTaken);
		}

		// Token: 0x06003C67 RID: 15463
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReliableEnterTimeout(object obj, int timeout, ref bool lockTaken);

		// Token: 0x06003C68 RID: 15464 RVA: 0x000E4328 File Offset: 0x000E2528
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static bool IsEntered(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return Monitor.IsEnteredNative(obj);
		}

		// Token: 0x06003C69 RID: 15465
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsEnteredNative(object obj);

		// Token: 0x06003C6A RID: 15466
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ObjWait(bool exitContext, int millisecondsTimeout, object obj);

		// Token: 0x06003C6B RID: 15467 RVA: 0x000E433E File Offset: 0x000E253E
		[SecuritySafeCritical]
		public static bool Wait(object obj, int millisecondsTimeout, bool exitContext)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return Monitor.ObjWait(exitContext, millisecondsTimeout, obj);
		}

		// Token: 0x06003C6C RID: 15468 RVA: 0x000E4356 File Offset: 0x000E2556
		public static bool Wait(object obj, TimeSpan timeout, bool exitContext)
		{
			return Monitor.Wait(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout), exitContext);
		}

		// Token: 0x06003C6D RID: 15469 RVA: 0x000E4365 File Offset: 0x000E2565
		[__DynamicallyInvokable]
		public static bool Wait(object obj, int millisecondsTimeout)
		{
			return Monitor.Wait(obj, millisecondsTimeout, false);
		}

		// Token: 0x06003C6E RID: 15470 RVA: 0x000E436F File Offset: 0x000E256F
		[__DynamicallyInvokable]
		public static bool Wait(object obj, TimeSpan timeout)
		{
			return Monitor.Wait(obj, Monitor.MillisecondsTimeoutFromTimeSpan(timeout), false);
		}

		// Token: 0x06003C6F RID: 15471 RVA: 0x000E437E File Offset: 0x000E257E
		[__DynamicallyInvokable]
		public static bool Wait(object obj)
		{
			return Monitor.Wait(obj, -1, false);
		}

		// Token: 0x06003C70 RID: 15472
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ObjPulse(object obj);

		// Token: 0x06003C71 RID: 15473 RVA: 0x000E4388 File Offset: 0x000E2588
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void Pulse(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Monitor.ObjPulse(obj);
		}

		// Token: 0x06003C72 RID: 15474
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ObjPulseAll(object obj);

		// Token: 0x06003C73 RID: 15475 RVA: 0x000E439E File Offset: 0x000E259E
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void PulseAll(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Monitor.ObjPulseAll(obj);
		}
	}
}
