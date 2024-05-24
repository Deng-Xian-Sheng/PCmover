using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000506 RID: 1286
	public sealed class PreAllocatedOverlapped : IDisposable, IDeferredDisposable
	{
		// Token: 0x06003CAA RID: 15530 RVA: 0x000E4CBB File Offset: 0x000E2EBB
		[CLSCompliant(false)]
		[SecuritySafeCritical]
		public PreAllocatedOverlapped(IOCompletionCallback callback, object state, object pinData)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			this._overlapped = new ThreadPoolBoundHandleOverlapped(callback, state, pinData, this);
		}

		// Token: 0x06003CAB RID: 15531 RVA: 0x000E4CE0 File Offset: 0x000E2EE0
		internal bool AddRef()
		{
			return this._lifetime.AddRef(this);
		}

		// Token: 0x06003CAC RID: 15532 RVA: 0x000E4CEE File Offset: 0x000E2EEE
		[SecurityCritical]
		internal void Release()
		{
			this._lifetime.Release(this);
		}

		// Token: 0x06003CAD RID: 15533 RVA: 0x000E4CFC File Offset: 0x000E2EFC
		public void Dispose()
		{
			this._lifetime.Dispose(this);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003CAE RID: 15534 RVA: 0x000E4D10 File Offset: 0x000E2F10
		~PreAllocatedOverlapped()
		{
			if (!Environment.HasShutdownStarted)
			{
				this.Dispose();
			}
		}

		// Token: 0x06003CAF RID: 15535 RVA: 0x000E4D44 File Offset: 0x000E2F44
		[SecurityCritical]
		unsafe void IDeferredDisposable.OnFinalRelease(bool disposed)
		{
			if (this._overlapped != null)
			{
				if (disposed)
				{
					Overlapped.Free(this._overlapped._nativeOverlapped);
					return;
				}
				this._overlapped._boundHandle = null;
				this._overlapped._completed = false;
				*this._overlapped._nativeOverlapped = default(NativeOverlapped);
			}
		}

		// Token: 0x040019B5 RID: 6581
		[SecurityCritical]
		internal readonly ThreadPoolBoundHandleOverlapped _overlapped;

		// Token: 0x040019B6 RID: 6582
		private DeferredDisposableLifetime<PreAllocatedOverlapped> _lifetime;
	}
}
