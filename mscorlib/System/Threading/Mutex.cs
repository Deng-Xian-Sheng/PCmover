﻿using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Threading
{
	// Token: 0x02000501 RID: 1281
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class Mutex : WaitHandle
	{
		// Token: 0x06003C74 RID: 15476 RVA: 0x000E43B4 File Offset: 0x000E25B4
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public Mutex(bool initiallyOwned, string name, out bool createdNew) : this(initiallyOwned, name, out createdNew, null)
		{
		}

		// Token: 0x06003C75 RID: 15477 RVA: 0x000E43C0 File Offset: 0x000E25C0
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public unsafe Mutex(bool initiallyOwned, string name, out bool createdNew, MutexSecurity mutexSecurity)
		{
			if (name != null && 260 < name.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", new object[]
				{
					name
				}));
			}
			Win32Native.SECURITY_ATTRIBUTES security_ATTRIBUTES = null;
			if (mutexSecurity != null)
			{
				security_ATTRIBUTES = new Win32Native.SECURITY_ATTRIBUTES();
				security_ATTRIBUTES.nLength = Marshal.SizeOf<Win32Native.SECURITY_ATTRIBUTES>(security_ATTRIBUTES);
				byte[] securityDescriptorBinaryForm = mutexSecurity.GetSecurityDescriptorBinaryForm();
				byte* ptr = stackalloc byte[(UIntPtr)securityDescriptorBinaryForm.Length];
				Buffer.Memcpy(ptr, 0, securityDescriptorBinaryForm, 0, securityDescriptorBinaryForm.Length);
				security_ATTRIBUTES.pSecurityDescriptor = ptr;
			}
			this.CreateMutexWithGuaranteedCleanup(initiallyOwned, name, out createdNew, security_ATTRIBUTES);
		}

		// Token: 0x06003C76 RID: 15478 RVA: 0x000E4441 File Offset: 0x000E2641
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal Mutex(bool initiallyOwned, string name, out bool createdNew, Win32Native.SECURITY_ATTRIBUTES secAttrs)
		{
			if (name != null && 260 < name.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", new object[]
				{
					name
				}));
			}
			this.CreateMutexWithGuaranteedCleanup(initiallyOwned, name, out createdNew, secAttrs);
		}

		// Token: 0x06003C77 RID: 15479 RVA: 0x000E4480 File Offset: 0x000E2680
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal void CreateMutexWithGuaranteedCleanup(bool initiallyOwned, string name, out bool createdNew, Win32Native.SECURITY_ATTRIBUTES secAttrs)
		{
			RuntimeHelpers.CleanupCode backoutCode = new RuntimeHelpers.CleanupCode(this.MutexCleanupCode);
			Mutex.MutexCleanupInfo mutexCleanupInfo = new Mutex.MutexCleanupInfo(null, false);
			Mutex.MutexTryCodeHelper mutexTryCodeHelper = new Mutex.MutexTryCodeHelper(initiallyOwned, mutexCleanupInfo, name, secAttrs, this);
			RuntimeHelpers.TryCode code = new RuntimeHelpers.TryCode(mutexTryCodeHelper.MutexTryCode);
			RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(code, backoutCode, mutexCleanupInfo);
			createdNew = mutexTryCodeHelper.m_newMutex;
		}

		// Token: 0x06003C78 RID: 15480 RVA: 0x000E44CC File Offset: 0x000E26CC
		[SecurityCritical]
		[PrePrepareMethod]
		private void MutexCleanupCode(object userData, bool exceptionThrown)
		{
			Mutex.MutexCleanupInfo mutexCleanupInfo = (Mutex.MutexCleanupInfo)userData;
			if (!this.hasThreadAffinity)
			{
				if (mutexCleanupInfo.mutexHandle != null && !mutexCleanupInfo.mutexHandle.IsInvalid)
				{
					if (mutexCleanupInfo.inCriticalRegion)
					{
						Win32Native.ReleaseMutex(mutexCleanupInfo.mutexHandle);
					}
					mutexCleanupInfo.mutexHandle.Dispose();
				}
				if (mutexCleanupInfo.inCriticalRegion)
				{
					Thread.EndCriticalRegion();
					Thread.EndThreadAffinity();
				}
			}
		}

		// Token: 0x06003C79 RID: 15481 RVA: 0x000E452E File Offset: 0x000E272E
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public Mutex(bool initiallyOwned, string name) : this(initiallyOwned, name, out Mutex.dummyBool)
		{
		}

		// Token: 0x06003C7A RID: 15482 RVA: 0x000E453D File Offset: 0x000E273D
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public Mutex(bool initiallyOwned) : this(initiallyOwned, null, out Mutex.dummyBool)
		{
		}

		// Token: 0x06003C7B RID: 15483 RVA: 0x000E454C File Offset: 0x000E274C
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public Mutex() : this(false, null, out Mutex.dummyBool)
		{
		}

		// Token: 0x06003C7C RID: 15484 RVA: 0x000E455B File Offset: 0x000E275B
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		private Mutex(SafeWaitHandle handle)
		{
			base.SetHandleInternal(handle);
			this.hasThreadAffinity = true;
		}

		// Token: 0x06003C7D RID: 15485 RVA: 0x000E4571 File Offset: 0x000E2771
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static Mutex OpenExisting(string name)
		{
			return Mutex.OpenExisting(name, MutexRights.Modify | MutexRights.Synchronize);
		}

		// Token: 0x06003C7E RID: 15486 RVA: 0x000E4580 File Offset: 0x000E2780
		[SecurityCritical]
		public static Mutex OpenExisting(string name, MutexRights rights)
		{
			Mutex result;
			switch (Mutex.OpenExistingWorker(name, rights, out result))
			{
			case WaitHandle.OpenExistingResult.NameNotFound:
				throw new WaitHandleCannotBeOpenedException();
			case WaitHandle.OpenExistingResult.PathNotFound:
				__Error.WinIOError(3, name);
				return result;
			case WaitHandle.OpenExistingResult.NameInvalid:
				throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", new object[]
				{
					name
				}));
			default:
				return result;
			}
		}

		// Token: 0x06003C7F RID: 15487 RVA: 0x000E45D7 File Offset: 0x000E27D7
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static bool TryOpenExisting(string name, out Mutex result)
		{
			return Mutex.OpenExistingWorker(name, MutexRights.Modify | MutexRights.Synchronize, out result) == WaitHandle.OpenExistingResult.Success;
		}

		// Token: 0x06003C80 RID: 15488 RVA: 0x000E45E8 File Offset: 0x000E27E8
		[SecurityCritical]
		public static bool TryOpenExisting(string name, MutexRights rights, out Mutex result)
		{
			return Mutex.OpenExistingWorker(name, rights, out result) == WaitHandle.OpenExistingResult.Success;
		}

		// Token: 0x06003C81 RID: 15489 RVA: 0x000E45F8 File Offset: 0x000E27F8
		[SecurityCritical]
		private static WaitHandle.OpenExistingResult OpenExistingWorker(string name, MutexRights rights, out Mutex result)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", Environment.GetResourceString("ArgumentNull_WithParamName"));
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (260 < name.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", new object[]
				{
					name
				}));
			}
			result = null;
			SafeWaitHandle safeWaitHandle = Win32Native.OpenMutex((int)rights, false, name);
			if (safeWaitHandle.IsInvalid)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (2 == lastWin32Error || 123 == lastWin32Error)
				{
					return WaitHandle.OpenExistingResult.NameNotFound;
				}
				if (3 == lastWin32Error)
				{
					return WaitHandle.OpenExistingResult.PathNotFound;
				}
				if (name != null && name.Length != 0 && 6 == lastWin32Error)
				{
					return WaitHandle.OpenExistingResult.NameInvalid;
				}
				__Error.WinIOError(lastWin32Error, name);
			}
			result = new Mutex(safeWaitHandle);
			return WaitHandle.OpenExistingResult.Success;
		}

		// Token: 0x06003C82 RID: 15490 RVA: 0x000E46AF File Offset: 0x000E28AF
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public void ReleaseMutex()
		{
			if (Win32Native.ReleaseMutex(this.safeWaitHandle))
			{
				Thread.EndCriticalRegion();
				Thread.EndThreadAffinity();
				return;
			}
			throw new ApplicationException(Environment.GetResourceString("Arg_SynchronizationLockException"));
		}

		// Token: 0x06003C83 RID: 15491 RVA: 0x000E46DC File Offset: 0x000E28DC
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		private static int CreateMutexHandle(bool initiallyOwned, string name, Win32Native.SECURITY_ATTRIBUTES securityAttribute, out SafeWaitHandle mutexHandle)
		{
			bool flag = false;
			int num;
			do
			{
				mutexHandle = Win32Native.CreateMutex(securityAttribute, initiallyOwned, name);
				num = Marshal.GetLastWin32Error();
				if (!mutexHandle.IsInvalid || num != 5)
				{
					return num;
				}
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					try
					{
					}
					finally
					{
						Thread.BeginThreadAffinity();
						flag = true;
					}
					mutexHandle = Win32Native.OpenMutex(1048577, false, name);
					if (!mutexHandle.IsInvalid)
					{
						num = 183;
					}
					else
					{
						num = Marshal.GetLastWin32Error();
					}
				}
				finally
				{
					if (flag)
					{
						Thread.EndThreadAffinity();
					}
				}
			}
			while (num == 2);
			if (num == 0)
			{
				num = 183;
			}
			return num;
		}

		// Token: 0x06003C84 RID: 15492 RVA: 0x000E4774 File Offset: 0x000E2974
		[SecuritySafeCritical]
		public MutexSecurity GetAccessControl()
		{
			return new MutexSecurity(this.safeWaitHandle, AccessControlSections.Access | AccessControlSections.Owner | AccessControlSections.Group);
		}

		// Token: 0x06003C85 RID: 15493 RVA: 0x000E4785 File Offset: 0x000E2985
		[SecuritySafeCritical]
		public void SetAccessControl(MutexSecurity mutexSecurity)
		{
			if (mutexSecurity == null)
			{
				throw new ArgumentNullException("mutexSecurity");
			}
			mutexSecurity.Persist(this.safeWaitHandle);
		}

		// Token: 0x0400199C RID: 6556
		private static bool dummyBool;

		// Token: 0x02000BEF RID: 3055
		internal class MutexTryCodeHelper
		{
			// Token: 0x06006F5D RID: 28509 RVA: 0x0017FAB3 File Offset: 0x0017DCB3
			[SecurityCritical]
			[PrePrepareMethod]
			internal MutexTryCodeHelper(bool initiallyOwned, Mutex.MutexCleanupInfo cleanupInfo, string name, Win32Native.SECURITY_ATTRIBUTES secAttrs, Mutex mutex)
			{
				this.m_initiallyOwned = initiallyOwned;
				this.m_cleanupInfo = cleanupInfo;
				this.m_name = name;
				this.m_secAttrs = secAttrs;
				this.m_mutex = mutex;
			}

			// Token: 0x06006F5E RID: 28510 RVA: 0x0017FAE0 File Offset: 0x0017DCE0
			[SecurityCritical]
			[PrePrepareMethod]
			internal void MutexTryCode(object userData)
			{
				SafeWaitHandle safeWaitHandle = null;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
				}
				finally
				{
					if (this.m_initiallyOwned)
					{
						this.m_cleanupInfo.inCriticalRegion = true;
						Thread.BeginThreadAffinity();
						Thread.BeginCriticalRegion();
					}
				}
				int num = 0;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
				}
				finally
				{
					num = Mutex.CreateMutexHandle(this.m_initiallyOwned, this.m_name, this.m_secAttrs, out safeWaitHandle);
				}
				if (safeWaitHandle.IsInvalid)
				{
					safeWaitHandle.SetHandleAsInvalid();
					if (this.m_name != null && this.m_name.Length != 0 && 6 == num)
					{
						throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", new object[]
						{
							this.m_name
						}));
					}
					__Error.WinIOError(num, this.m_name);
				}
				this.m_newMutex = (num != 183);
				this.m_mutex.SetHandleInternal(safeWaitHandle);
				this.m_mutex.hasThreadAffinity = true;
			}

			// Token: 0x04003614 RID: 13844
			private bool m_initiallyOwned;

			// Token: 0x04003615 RID: 13845
			private Mutex.MutexCleanupInfo m_cleanupInfo;

			// Token: 0x04003616 RID: 13846
			internal bool m_newMutex;

			// Token: 0x04003617 RID: 13847
			private string m_name;

			// Token: 0x04003618 RID: 13848
			[SecurityCritical]
			private Win32Native.SECURITY_ATTRIBUTES m_secAttrs;

			// Token: 0x04003619 RID: 13849
			private Mutex m_mutex;
		}

		// Token: 0x02000BF0 RID: 3056
		internal class MutexCleanupInfo
		{
			// Token: 0x06006F5F RID: 28511 RVA: 0x0017FBD0 File Offset: 0x0017DDD0
			[SecurityCritical]
			internal MutexCleanupInfo(SafeWaitHandle mutexHandle, bool inCriticalRegion)
			{
				this.mutexHandle = mutexHandle;
				this.inCriticalRegion = inCriticalRegion;
			}

			// Token: 0x0400361A RID: 13850
			[SecurityCritical]
			internal SafeWaitHandle mutexHandle;

			// Token: 0x0400361B RID: 13851
			internal bool inCriticalRegion;
		}
	}
}
