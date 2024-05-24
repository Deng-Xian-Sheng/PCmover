using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000956 RID: 2390
	[SecurityCritical]
	[__DynamicallyInvokable]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	public abstract class SafeHandle : CriticalFinalizerObject, IDisposable
	{
		// Token: 0x060061D0 RID: 25040 RVA: 0x0014EB67 File Offset: 0x0014CD67
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected SafeHandle(IntPtr invalidHandleValue, bool ownsHandle)
		{
			this.handle = invalidHandleValue;
			this._state = 4;
			this._ownsHandle = ownsHandle;
			if (!ownsHandle)
			{
				GC.SuppressFinalize(this);
			}
			this._fullyInitialized = true;
		}

		// Token: 0x060061D1 RID: 25041 RVA: 0x0014EB94 File Offset: 0x0014CD94
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		~SafeHandle()
		{
			this.Dispose(false);
		}

		// Token: 0x060061D2 RID: 25042
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalFinalize();

		// Token: 0x060061D3 RID: 25043 RVA: 0x0014EBC4 File Offset: 0x0014CDC4
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected void SetHandle(IntPtr handle)
		{
			this.handle = handle;
		}

		// Token: 0x060061D4 RID: 25044 RVA: 0x0014EBCD File Offset: 0x0014CDCD
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public IntPtr DangerousGetHandle()
		{
			return this.handle;
		}

		// Token: 0x17001105 RID: 4357
		// (get) Token: 0x060061D5 RID: 25045 RVA: 0x0014EBD5 File Offset: 0x0014CDD5
		[__DynamicallyInvokable]
		public bool IsClosed
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				return (this._state & 1) == 1;
			}
		}

		// Token: 0x17001106 RID: 4358
		// (get) Token: 0x060061D6 RID: 25046
		[__DynamicallyInvokable]
		public abstract bool IsInvalid { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] [__DynamicallyInvokable] get; }

		// Token: 0x060061D7 RID: 25047 RVA: 0x0014EBE2 File Offset: 0x0014CDE2
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x060061D8 RID: 25048 RVA: 0x0014EBEB File Offset: 0x0014CDEB
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060061D9 RID: 25049 RVA: 0x0014EBF4 File Offset: 0x0014CDF4
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.InternalDispose();
				return;
			}
			this.InternalFinalize();
		}

		// Token: 0x060061DA RID: 25050
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void InternalDispose();

		// Token: 0x060061DB RID: 25051
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetHandleAsInvalid();

		// Token: 0x060061DC RID: 25052
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		protected abstract bool ReleaseHandle();

		// Token: 0x060061DD RID: 25053
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DangerousAddRef(ref bool success);

		// Token: 0x060061DE RID: 25054
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DangerousRelease();

		// Token: 0x04002B78 RID: 11128
		protected IntPtr handle;

		// Token: 0x04002B79 RID: 11129
		private int _state;

		// Token: 0x04002B7A RID: 11130
		private bool _ownsHandle;

		// Token: 0x04002B7B RID: 11131
		private bool _fullyInitialized;
	}
}
