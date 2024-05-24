using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000503 RID: 1283
	internal class _IOCompletionCallback
	{
		// Token: 0x06003C87 RID: 15495 RVA: 0x000E47B6 File Offset: 0x000E29B6
		[SecurityCritical]
		internal _IOCompletionCallback(IOCompletionCallback ioCompletionCallback, ref StackCrawlMark stackMark)
		{
			this._ioCompletionCallback = ioCompletionCallback;
			this._executionContext = ExecutionContext.Capture(ref stackMark, ExecutionContext.CaptureOptions.IgnoreSyncCtx | ExecutionContext.CaptureOptions.OptimizeDefaultCase);
		}

		// Token: 0x06003C88 RID: 15496 RVA: 0x000E47D4 File Offset: 0x000E29D4
		[SecurityCritical]
		internal static void IOCompletionCallback_Context(object state)
		{
			_IOCompletionCallback iocompletionCallback = (_IOCompletionCallback)state;
			iocompletionCallback._ioCompletionCallback(iocompletionCallback._errorCode, iocompletionCallback._numBytes, iocompletionCallback._pOVERLAP);
		}

		// Token: 0x06003C89 RID: 15497 RVA: 0x000E4808 File Offset: 0x000E2A08
		[SecurityCritical]
		internal unsafe static void PerformIOCompletionCallback(uint errorCode, uint numBytes, NativeOverlapped* pOVERLAP)
		{
			do
			{
				Overlapped overlapped = OverlappedData.GetOverlappedFromNative(pOVERLAP).m_overlapped;
				_IOCompletionCallback iocbHelper = overlapped.iocbHelper;
				if (iocbHelper == null || iocbHelper._executionContext == null || iocbHelper._executionContext.IsDefaultFTContext(true))
				{
					IOCompletionCallback userCallback = overlapped.UserCallback;
					userCallback(errorCode, numBytes, pOVERLAP);
				}
				else
				{
					iocbHelper._errorCode = errorCode;
					iocbHelper._numBytes = numBytes;
					iocbHelper._pOVERLAP = pOVERLAP;
					using (ExecutionContext executionContext = iocbHelper._executionContext.CreateCopy())
					{
						ExecutionContext.Run(executionContext, _IOCompletionCallback._ccb, iocbHelper, true);
					}
				}
				OverlappedData.CheckVMForIOPacket(out pOVERLAP, out errorCode, out numBytes);
			}
			while (pOVERLAP != null);
		}

		// Token: 0x040019A2 RID: 6562
		[SecurityCritical]
		private IOCompletionCallback _ioCompletionCallback;

		// Token: 0x040019A3 RID: 6563
		private ExecutionContext _executionContext;

		// Token: 0x040019A4 RID: 6564
		private uint _errorCode;

		// Token: 0x040019A5 RID: 6565
		private uint _numBytes;

		// Token: 0x040019A6 RID: 6566
		[SecurityCritical]
		private unsafe NativeOverlapped* _pOVERLAP;

		// Token: 0x040019A7 RID: 6567
		internal static ContextCallback _ccb = new ContextCallback(_IOCompletionCallback.IOCompletionCallback_Context);
	}
}
