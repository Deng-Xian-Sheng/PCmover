using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004FC RID: 1276
	public class HostExecutionContextManager
	{
		// Token: 0x06003C43 RID: 15427
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HostSecurityManagerPresent();

		// Token: 0x06003C44 RID: 15428
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int ReleaseHostSecurityContext(IntPtr context);

		// Token: 0x06003C45 RID: 15429
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int CloneHostSecurityContext(SafeHandle context, SafeHandle clonedContext);

		// Token: 0x06003C46 RID: 15430
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int CaptureHostSecurityContext(SafeHandle capturedContext);

		// Token: 0x06003C47 RID: 15431
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int SetHostSecurityContext(SafeHandle context, bool fReturnPrevious, SafeHandle prevContext);

		// Token: 0x06003C48 RID: 15432 RVA: 0x000E3F7C File Offset: 0x000E217C
		[SecurityCritical]
		internal static bool CheckIfHosted()
		{
			if (!HostExecutionContextManager._fIsHostedChecked)
			{
				HostExecutionContextManager._fIsHosted = HostExecutionContextManager.HostSecurityManagerPresent();
				HostExecutionContextManager._fIsHostedChecked = true;
			}
			return HostExecutionContextManager._fIsHosted;
		}

		// Token: 0x06003C49 RID: 15433 RVA: 0x000E3FA4 File Offset: 0x000E21A4
		[SecuritySafeCritical]
		public virtual HostExecutionContext Capture()
		{
			HostExecutionContext result = null;
			if (HostExecutionContextManager.CheckIfHosted())
			{
				IUnknownSafeHandle unknownSafeHandle = new IUnknownSafeHandle();
				result = new HostExecutionContext(unknownSafeHandle);
				HostExecutionContextManager.CaptureHostSecurityContext(unknownSafeHandle);
			}
			return result;
		}

		// Token: 0x06003C4A RID: 15434 RVA: 0x000E3FD0 File Offset: 0x000E21D0
		[SecurityCritical]
		public virtual object SetHostExecutionContext(HostExecutionContext hostExecutionContext)
		{
			if (hostExecutionContext == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotNewCaptureContext"));
			}
			HostExecutionContextSwitcher hostExecutionContextSwitcher = new HostExecutionContextSwitcher();
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			hostExecutionContextSwitcher.executionContext = mutableExecutionContext;
			hostExecutionContextSwitcher.currentHostContext = hostExecutionContext;
			hostExecutionContextSwitcher.previousHostContext = null;
			if (HostExecutionContextManager.CheckIfHosted() && hostExecutionContext.State is IUnknownSafeHandle)
			{
				IUnknownSafeHandle unknownSafeHandle = new IUnknownSafeHandle();
				hostExecutionContextSwitcher.previousHostContext = new HostExecutionContext(unknownSafeHandle);
				IUnknownSafeHandle context = (IUnknownSafeHandle)hostExecutionContext.State;
				HostExecutionContextManager.SetHostSecurityContext(context, true, unknownSafeHandle);
			}
			mutableExecutionContext.HostExecutionContext = hostExecutionContext;
			return hostExecutionContextSwitcher;
		}

		// Token: 0x06003C4B RID: 15435 RVA: 0x000E405C File Offset: 0x000E225C
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public virtual void Revert(object previousState)
		{
			HostExecutionContextSwitcher hostExecutionContextSwitcher = previousState as HostExecutionContextSwitcher;
			if (hostExecutionContextSwitcher == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotOverrideSetWithoutRevert"));
			}
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			if (mutableExecutionContext != hostExecutionContextSwitcher.executionContext)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotUseSwitcherOtherThread"));
			}
			hostExecutionContextSwitcher.executionContext = null;
			HostExecutionContext hostExecutionContext = mutableExecutionContext.HostExecutionContext;
			if (hostExecutionContext != hostExecutionContextSwitcher.currentHostContext)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotUseSwitcherOtherThread"));
			}
			HostExecutionContext previousHostContext = hostExecutionContextSwitcher.previousHostContext;
			if (HostExecutionContextManager.CheckIfHosted() && previousHostContext != null && previousHostContext.State is IUnknownSafeHandle)
			{
				IUnknownSafeHandle context = (IUnknownSafeHandle)previousHostContext.State;
				HostExecutionContextManager.SetHostSecurityContext(context, false, null);
			}
			mutableExecutionContext.HostExecutionContext = previousHostContext;
		}

		// Token: 0x06003C4C RID: 15436 RVA: 0x000E410C File Offset: 0x000E230C
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static HostExecutionContext CaptureHostExecutionContext()
		{
			HostExecutionContext result = null;
			HostExecutionContextManager currentHostExecutionContextManager = HostExecutionContextManager.GetCurrentHostExecutionContextManager();
			if (currentHostExecutionContextManager != null)
			{
				result = currentHostExecutionContextManager.Capture();
			}
			return result;
		}

		// Token: 0x06003C4D RID: 15437 RVA: 0x000E412C File Offset: 0x000E232C
		[SecurityCritical]
		internal static object SetHostExecutionContextInternal(HostExecutionContext hostContext)
		{
			HostExecutionContextManager currentHostExecutionContextManager = HostExecutionContextManager.GetCurrentHostExecutionContextManager();
			object result = null;
			if (currentHostExecutionContextManager != null)
			{
				result = currentHostExecutionContextManager.SetHostExecutionContext(hostContext);
			}
			return result;
		}

		// Token: 0x06003C4E RID: 15438 RVA: 0x000E4150 File Offset: 0x000E2350
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static HostExecutionContextManager GetCurrentHostExecutionContextManager()
		{
			AppDomainManager currentAppDomainManager = AppDomainManager.CurrentAppDomainManager;
			if (currentAppDomainManager != null)
			{
				return currentAppDomainManager.HostExecutionContextManager;
			}
			return null;
		}

		// Token: 0x06003C4F RID: 15439 RVA: 0x000E416E File Offset: 0x000E236E
		internal static HostExecutionContextManager GetInternalHostExecutionContextManager()
		{
			if (HostExecutionContextManager._hostExecutionContextManager == null)
			{
				HostExecutionContextManager._hostExecutionContextManager = new HostExecutionContextManager();
			}
			return HostExecutionContextManager._hostExecutionContextManager;
		}

		// Token: 0x04001995 RID: 6549
		private static volatile bool _fIsHostedChecked;

		// Token: 0x04001996 RID: 6550
		private static volatile bool _fIsHosted;

		// Token: 0x04001997 RID: 6551
		private static HostExecutionContextManager _hostExecutionContextManager;
	}
}
