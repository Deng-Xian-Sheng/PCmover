using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Principal
{
	// Token: 0x02000330 RID: 816
	[ComVisible(true)]
	public class WindowsImpersonationContext : IDisposable
	{
		// Token: 0x060028E2 RID: 10466 RVA: 0x00096BC0 File Offset: 0x00094DC0
		[SecurityCritical]
		private WindowsImpersonationContext()
		{
		}

		// Token: 0x060028E3 RID: 10467 RVA: 0x00096BD4 File Offset: 0x00094DD4
		[SecurityCritical]
		internal WindowsImpersonationContext(SafeAccessTokenHandle safeTokenHandle, WindowsIdentity wi, bool isImpersonating, FrameSecurityDescriptor fsd)
		{
			if (safeTokenHandle.IsInvalid)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidImpersonationToken"));
			}
			if (isImpersonating)
			{
				if (!Win32Native.DuplicateHandle(Win32Native.GetCurrentProcess(), safeTokenHandle, Win32Native.GetCurrentProcess(), ref this.m_safeTokenHandle, 0U, true, 2U))
				{
					throw new SecurityException(Win32Native.GetMessage(Marshal.GetLastWin32Error()));
				}
				this.m_wi = wi;
			}
			this.m_fsd = fsd;
		}

		// Token: 0x060028E4 RID: 10468 RVA: 0x00096C48 File Offset: 0x00094E48
		[SecuritySafeCritical]
		public void Undo()
		{
			if (this.m_safeTokenHandle.IsInvalid)
			{
				int num = Win32.RevertToSelf();
				if (num < 0)
				{
					Environment.FailFast(Win32Native.GetMessage(num));
				}
			}
			else
			{
				int num = Win32.RevertToSelf();
				if (num < 0)
				{
					Environment.FailFast(Win32Native.GetMessage(num));
				}
				num = Win32.ImpersonateLoggedOnUser(this.m_safeTokenHandle);
				if (num < 0)
				{
					throw new SecurityException(Win32Native.GetMessage(num));
				}
			}
			WindowsIdentity.UpdateThreadWI(this.m_wi);
			if (this.m_fsd != null)
			{
				this.m_fsd.SetTokenHandles(null, null);
			}
		}

		// Token: 0x060028E5 RID: 10469 RVA: 0x00096CCC File Offset: 0x00094ECC
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[HandleProcessCorruptedStateExceptions]
		internal bool UndoNoThrow()
		{
			bool result = false;
			try
			{
				int num;
				if (this.m_safeTokenHandle.IsInvalid)
				{
					num = Win32.RevertToSelf();
					if (num < 0)
					{
						Environment.FailFast(Win32Native.GetMessage(num));
					}
				}
				else
				{
					num = Win32.RevertToSelf();
					if (num >= 0)
					{
						num = Win32.ImpersonateLoggedOnUser(this.m_safeTokenHandle);
					}
					else
					{
						Environment.FailFast(Win32Native.GetMessage(num));
					}
				}
				result = (num >= 0);
				if (this.m_fsd != null)
				{
					this.m_fsd.SetTokenHandles(null, null);
				}
			}
			catch (Exception exception)
			{
				if (!AppContextSwitches.UseLegacyExecutionContextBehaviorUponUndoFailure)
				{
					Environment.FailFast(Environment.GetResourceString("ExecutionContext_UndoFailed"), exception);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060028E6 RID: 10470 RVA: 0x00096D70 File Offset: 0x00094F70
		[SecuritySafeCritical]
		[ComVisible(false)]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && this.m_safeTokenHandle != null && !this.m_safeTokenHandle.IsClosed)
			{
				this.Undo();
				this.m_safeTokenHandle.Dispose();
			}
		}

		// Token: 0x060028E7 RID: 10471 RVA: 0x00096D9B File Offset: 0x00094F9B
		[ComVisible(false)]
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x04001078 RID: 4216
		[SecurityCritical]
		private SafeAccessTokenHandle m_safeTokenHandle = SafeAccessTokenHandle.InvalidHandle;

		// Token: 0x04001079 RID: 4217
		private WindowsIdentity m_wi;

		// Token: 0x0400107A RID: 4218
		private FrameSecurityDescriptor m_fsd;
	}
}
