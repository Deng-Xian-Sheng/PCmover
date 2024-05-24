using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x0200050F RID: 1295
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class ReaderWriterLock : CriticalFinalizerObject
	{
		// Token: 0x06003CEC RID: 15596 RVA: 0x000E5E96 File Offset: 0x000E4096
		[SecuritySafeCritical]
		public ReaderWriterLock()
		{
			this.PrivateInitialize();
		}

		// Token: 0x06003CED RID: 15597 RVA: 0x000E5EA4 File Offset: 0x000E40A4
		[SecuritySafeCritical]
		~ReaderWriterLock()
		{
			this.PrivateDestruct();
		}

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x06003CEE RID: 15598 RVA: 0x000E5ED0 File Offset: 0x000E40D0
		public bool IsReaderLockHeld
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.PrivateGetIsReaderLockHeld();
			}
		}

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x06003CEF RID: 15599 RVA: 0x000E5ED8 File Offset: 0x000E40D8
		public bool IsWriterLockHeld
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.PrivateGetIsWriterLockHeld();
			}
		}

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x06003CF0 RID: 15600 RVA: 0x000E5EE0 File Offset: 0x000E40E0
		public int WriterSeqNum
		{
			[SecuritySafeCritical]
			get
			{
				return this.PrivateGetWriterSeqNum();
			}
		}

		// Token: 0x06003CF1 RID: 15601
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AcquireReaderLockInternal(int millisecondsTimeout);

		// Token: 0x06003CF2 RID: 15602 RVA: 0x000E5EE8 File Offset: 0x000E40E8
		[SecuritySafeCritical]
		public void AcquireReaderLock(int millisecondsTimeout)
		{
			this.AcquireReaderLockInternal(millisecondsTimeout);
		}

		// Token: 0x06003CF3 RID: 15603 RVA: 0x000E5EF4 File Offset: 0x000E40F4
		[SecuritySafeCritical]
		public void AcquireReaderLock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			this.AcquireReaderLockInternal((int)num);
		}

		// Token: 0x06003CF4 RID: 15604
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AcquireWriterLockInternal(int millisecondsTimeout);

		// Token: 0x06003CF5 RID: 15605 RVA: 0x000E5F35 File Offset: 0x000E4135
		[SecuritySafeCritical]
		public void AcquireWriterLock(int millisecondsTimeout)
		{
			this.AcquireWriterLockInternal(millisecondsTimeout);
		}

		// Token: 0x06003CF6 RID: 15606 RVA: 0x000E5F40 File Offset: 0x000E4140
		[SecuritySafeCritical]
		public void AcquireWriterLock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			this.AcquireWriterLockInternal((int)num);
		}

		// Token: 0x06003CF7 RID: 15607
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ReleaseReaderLockInternal();

		// Token: 0x06003CF8 RID: 15608 RVA: 0x000E5F81 File Offset: 0x000E4181
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void ReleaseReaderLock()
		{
			this.ReleaseReaderLockInternal();
		}

		// Token: 0x06003CF9 RID: 15609
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ReleaseWriterLockInternal();

		// Token: 0x06003CFA RID: 15610 RVA: 0x000E5F89 File Offset: 0x000E4189
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void ReleaseWriterLock()
		{
			this.ReleaseWriterLockInternal();
		}

		// Token: 0x06003CFB RID: 15611 RVA: 0x000E5F94 File Offset: 0x000E4194
		[SecuritySafeCritical]
		public LockCookie UpgradeToWriterLock(int millisecondsTimeout)
		{
			LockCookie result = default(LockCookie);
			this.FCallUpgradeToWriterLock(ref result, millisecondsTimeout);
			return result;
		}

		// Token: 0x06003CFC RID: 15612
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void FCallUpgradeToWriterLock(ref LockCookie result, int millisecondsTimeout);

		// Token: 0x06003CFD RID: 15613 RVA: 0x000E5FB4 File Offset: 0x000E41B4
		public LockCookie UpgradeToWriterLock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.UpgradeToWriterLock((int)num);
		}

		// Token: 0x06003CFE RID: 15614
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void DowngradeFromWriterLockInternal(ref LockCookie lockCookie);

		// Token: 0x06003CFF RID: 15615 RVA: 0x000E5FF5 File Offset: 0x000E41F5
		[SecuritySafeCritical]
		public void DowngradeFromWriterLock(ref LockCookie lockCookie)
		{
			this.DowngradeFromWriterLockInternal(ref lockCookie);
		}

		// Token: 0x06003D00 RID: 15616 RVA: 0x000E6000 File Offset: 0x000E4200
		[SecuritySafeCritical]
		public LockCookie ReleaseLock()
		{
			LockCookie result = default(LockCookie);
			this.FCallReleaseLock(ref result);
			return result;
		}

		// Token: 0x06003D01 RID: 15617
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void FCallReleaseLock(ref LockCookie result);

		// Token: 0x06003D02 RID: 15618
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RestoreLockInternal(ref LockCookie lockCookie);

		// Token: 0x06003D03 RID: 15619 RVA: 0x000E601E File Offset: 0x000E421E
		[SecuritySafeCritical]
		public void RestoreLock(ref LockCookie lockCookie)
		{
			this.RestoreLockInternal(ref lockCookie);
		}

		// Token: 0x06003D04 RID: 15620
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool PrivateGetIsReaderLockHeld();

		// Token: 0x06003D05 RID: 15621
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool PrivateGetIsWriterLockHeld();

		// Token: 0x06003D06 RID: 15622
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int PrivateGetWriterSeqNum();

		// Token: 0x06003D07 RID: 15623
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AnyWritersSince(int seqNum);

		// Token: 0x06003D08 RID: 15624
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void PrivateInitialize();

		// Token: 0x06003D09 RID: 15625
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void PrivateDestruct();

		// Token: 0x040019D3 RID: 6611
		private IntPtr _hWriterEvent;

		// Token: 0x040019D4 RID: 6612
		private IntPtr _hReaderEvent;

		// Token: 0x040019D5 RID: 6613
		private IntPtr _hObjectHandle;

		// Token: 0x040019D6 RID: 6614
		private int _dwState;

		// Token: 0x040019D7 RID: 6615
		private int _dwULockID;

		// Token: 0x040019D8 RID: 6616
		private int _dwLLockID;

		// Token: 0x040019D9 RID: 6617
		private int _dwWriterID;

		// Token: 0x040019DA RID: 6618
		private int _dwWriterSeqNum;

		// Token: 0x040019DB RID: 6619
		private short _wWriterLevel;
	}
}
