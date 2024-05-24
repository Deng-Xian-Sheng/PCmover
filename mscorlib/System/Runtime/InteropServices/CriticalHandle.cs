using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000944 RID: 2372
	[SecurityCritical]
	[__DynamicallyInvokable]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	public abstract class CriticalHandle : CriticalFinalizerObject, IDisposable
	{
		// Token: 0x06006067 RID: 24679 RVA: 0x0014C01E File Offset: 0x0014A21E
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected CriticalHandle(IntPtr invalidHandleValue)
		{
			this.handle = invalidHandleValue;
			this._isClosed = false;
		}

		// Token: 0x06006068 RID: 24680 RVA: 0x0014C034 File Offset: 0x0014A234
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		~CriticalHandle()
		{
			this.Dispose(false);
		}

		// Token: 0x06006069 RID: 24681 RVA: 0x0014C064 File Offset: 0x0014A264
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private void Cleanup()
		{
			if (this.IsClosed)
			{
				return;
			}
			this._isClosed = true;
			if (this.IsInvalid)
			{
				return;
			}
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (!this.ReleaseHandle())
			{
				this.FireCustomerDebugProbe();
			}
			Marshal.SetLastWin32Error(lastWin32Error);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600606A RID: 24682
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void FireCustomerDebugProbe();

		// Token: 0x0600606B RID: 24683 RVA: 0x0014C0AA File Offset: 0x0014A2AA
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected void SetHandle(IntPtr handle)
		{
			this.handle = handle;
		}

		// Token: 0x170010F6 RID: 4342
		// (get) Token: 0x0600606C RID: 24684 RVA: 0x0014C0B3 File Offset: 0x0014A2B3
		[__DynamicallyInvokable]
		public bool IsClosed
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				return this._isClosed;
			}
		}

		// Token: 0x170010F7 RID: 4343
		// (get) Token: 0x0600606D RID: 24685
		[__DynamicallyInvokable]
		public abstract bool IsInvalid { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] [__DynamicallyInvokable] get; }

		// Token: 0x0600606E RID: 24686 RVA: 0x0014C0BB File Offset: 0x0014A2BB
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x0600606F RID: 24687 RVA: 0x0014C0C4 File Offset: 0x0014A2C4
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06006070 RID: 24688 RVA: 0x0014C0CD File Offset: 0x0014A2CD
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			this.Cleanup();
		}

		// Token: 0x06006071 RID: 24689 RVA: 0x0014C0D5 File Offset: 0x0014A2D5
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void SetHandleAsInvalid()
		{
			this._isClosed = true;
			GC.SuppressFinalize(this);
		}

		// Token: 0x06006072 RID: 24690
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected abstract bool ReleaseHandle();

		// Token: 0x04002B37 RID: 11063
		protected IntPtr handle;

		// Token: 0x04002B38 RID: 11064
		private bool _isClosed;
	}
}
