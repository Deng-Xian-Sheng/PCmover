using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000504 RID: 1284
	internal sealed class OverlappedData
	{
		// Token: 0x06003C8A RID: 15498 RVA: 0x000E48B0 File Offset: 0x000E2AB0
		[SecurityCritical]
		internal void ReInitialize()
		{
			this.m_asyncResult = null;
			this.m_iocb = null;
			this.m_iocbHelper = null;
			this.m_overlapped = null;
			this.m_userObject = null;
			this.m_pinSelf = (IntPtr)0;
			this.m_userObjectInternal = (IntPtr)0;
			this.m_AppDomainId = 0;
			this.m_nativeOverlapped.EventHandle = (IntPtr)0;
			this.m_isArray = 0;
			this.m_nativeOverlapped.InternalLow = (IntPtr)0;
			this.m_nativeOverlapped.InternalHigh = (IntPtr)0;
		}

		// Token: 0x06003C8B RID: 15499 RVA: 0x000E493C File Offset: 0x000E2B3C
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal unsafe NativeOverlapped* Pack(IOCompletionCallback iocb, object userData)
		{
			if (!this.m_pinSelf.IsNull())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_Overlapped_Pack"));
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			if (iocb != null)
			{
				this.m_iocbHelper = new _IOCompletionCallback(iocb, ref stackCrawlMark);
				this.m_iocb = iocb;
			}
			else
			{
				this.m_iocbHelper = null;
				this.m_iocb = null;
			}
			this.m_userObject = userData;
			if (this.m_userObject != null)
			{
				if (this.m_userObject.GetType() == typeof(object[]))
				{
					this.m_isArray = 1;
				}
				else
				{
					this.m_isArray = 0;
				}
			}
			return this.AllocateNativeOverlapped();
		}

		// Token: 0x06003C8C RID: 15500 RVA: 0x000E49D4 File Offset: 0x000E2BD4
		[SecurityCritical]
		internal unsafe NativeOverlapped* UnsafePack(IOCompletionCallback iocb, object userData)
		{
			if (!this.m_pinSelf.IsNull())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_Overlapped_Pack"));
			}
			this.m_userObject = userData;
			if (this.m_userObject != null)
			{
				if (this.m_userObject.GetType() == typeof(object[]))
				{
					this.m_isArray = 1;
				}
				else
				{
					this.m_isArray = 0;
				}
			}
			this.m_iocb = iocb;
			this.m_iocbHelper = null;
			return this.AllocateNativeOverlapped();
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x06003C8D RID: 15501 RVA: 0x000E4A4D File Offset: 0x000E2C4D
		// (set) Token: 0x06003C8E RID: 15502 RVA: 0x000E4A5A File Offset: 0x000E2C5A
		[ComVisible(false)]
		internal IntPtr UserHandle
		{
			get
			{
				return this.m_nativeOverlapped.EventHandle;
			}
			set
			{
				this.m_nativeOverlapped.EventHandle = value;
			}
		}

		// Token: 0x06003C8F RID: 15503
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe extern NativeOverlapped* AllocateNativeOverlapped();

		// Token: 0x06003C90 RID: 15504
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern void FreeNativeOverlapped(NativeOverlapped* nativeOverlappedPtr);

		// Token: 0x06003C91 RID: 15505
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern OverlappedData GetOverlappedFromNative(NativeOverlapped* nativeOverlappedPtr);

		// Token: 0x06003C92 RID: 15506
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern void CheckVMForIOPacket(out NativeOverlapped* pOVERLAP, out uint errorCode, out uint numBytes);

		// Token: 0x040019A8 RID: 6568
		internal IAsyncResult m_asyncResult;

		// Token: 0x040019A9 RID: 6569
		[SecurityCritical]
		internal IOCompletionCallback m_iocb;

		// Token: 0x040019AA RID: 6570
		internal _IOCompletionCallback m_iocbHelper;

		// Token: 0x040019AB RID: 6571
		internal Overlapped m_overlapped;

		// Token: 0x040019AC RID: 6572
		private object m_userObject;

		// Token: 0x040019AD RID: 6573
		private IntPtr m_pinSelf;

		// Token: 0x040019AE RID: 6574
		private IntPtr m_userObjectInternal;

		// Token: 0x040019AF RID: 6575
		private int m_AppDomainId;

		// Token: 0x040019B0 RID: 6576
		private byte m_isArray;

		// Token: 0x040019B1 RID: 6577
		private byte m_toBeCleaned;

		// Token: 0x040019B2 RID: 6578
		internal NativeOverlapped m_nativeOverlapped;
	}
}
