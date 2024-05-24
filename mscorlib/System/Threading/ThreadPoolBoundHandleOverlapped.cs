using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000507 RID: 1287
	[SecurityCritical]
	internal sealed class ThreadPoolBoundHandleOverlapped : Overlapped
	{
		// Token: 0x06003CB0 RID: 15536 RVA: 0x000E4D98 File Offset: 0x000E2F98
		public unsafe ThreadPoolBoundHandleOverlapped(IOCompletionCallback callback, object state, object pinData, PreAllocatedOverlapped preAllocated)
		{
			this._userCallback = callback;
			this._userState = state;
			this._preAllocated = preAllocated;
			this._nativeOverlapped = base.Pack(ThreadPoolBoundHandleOverlapped.s_completionCallback, pinData);
			this._nativeOverlapped->OffsetLow = 0;
			this._nativeOverlapped->OffsetHigh = 0;
		}

		// Token: 0x06003CB1 RID: 15537 RVA: 0x000E4DEC File Offset: 0x000E2FEC
		private unsafe static void CompletionCallback(uint errorCode, uint numBytes, NativeOverlapped* nativeOverlapped)
		{
			ThreadPoolBoundHandleOverlapped threadPoolBoundHandleOverlapped = (ThreadPoolBoundHandleOverlapped)Overlapped.Unpack(nativeOverlapped);
			if (threadPoolBoundHandleOverlapped._completed)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NativeOverlappedReused"));
			}
			threadPoolBoundHandleOverlapped._completed = true;
			if (threadPoolBoundHandleOverlapped._boundHandle == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Argument_NativeOverlappedAlreadyFree"));
			}
			threadPoolBoundHandleOverlapped._userCallback(errorCode, numBytes, nativeOverlapped);
		}

		// Token: 0x040019B7 RID: 6583
		private static readonly IOCompletionCallback s_completionCallback = new IOCompletionCallback(ThreadPoolBoundHandleOverlapped.CompletionCallback);

		// Token: 0x040019B8 RID: 6584
		private readonly IOCompletionCallback _userCallback;

		// Token: 0x040019B9 RID: 6585
		internal readonly object _userState;

		// Token: 0x040019BA RID: 6586
		internal PreAllocatedOverlapped _preAllocated;

		// Token: 0x040019BB RID: 6587
		internal unsafe NativeOverlapped* _nativeOverlapped;

		// Token: 0x040019BC RID: 6588
		internal ThreadPoolBoundHandle _boundHandle;

		// Token: 0x040019BD RID: 6589
		internal bool _completed;
	}
}
