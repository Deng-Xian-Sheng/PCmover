using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000505 RID: 1285
	[ComVisible(true)]
	public class Overlapped
	{
		// Token: 0x06003C94 RID: 15508 RVA: 0x000E4A70 File Offset: 0x000E2C70
		public Overlapped()
		{
			this.m_overlappedData = (OverlappedData)Overlapped.s_overlappedDataCache.Allocate();
			this.m_overlappedData.m_overlapped = this;
		}

		// Token: 0x06003C95 RID: 15509 RVA: 0x000E4A9C File Offset: 0x000E2C9C
		public Overlapped(int offsetLo, int offsetHi, IntPtr hEvent, IAsyncResult ar)
		{
			this.m_overlappedData = (OverlappedData)Overlapped.s_overlappedDataCache.Allocate();
			this.m_overlappedData.m_overlapped = this;
			this.m_overlappedData.m_nativeOverlapped.OffsetLow = offsetLo;
			this.m_overlappedData.m_nativeOverlapped.OffsetHigh = offsetHi;
			this.m_overlappedData.UserHandle = hEvent;
			this.m_overlappedData.m_asyncResult = ar;
		}

		// Token: 0x06003C96 RID: 15510 RVA: 0x000E4B0B File Offset: 0x000E2D0B
		[Obsolete("This constructor is not 64-bit compatible.  Use the constructor that takes an IntPtr for the event handle.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public Overlapped(int offsetLo, int offsetHi, int hEvent, IAsyncResult ar) : this(offsetLo, offsetHi, new IntPtr(hEvent), ar)
		{
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x06003C97 RID: 15511 RVA: 0x000E4B1D File Offset: 0x000E2D1D
		// (set) Token: 0x06003C98 RID: 15512 RVA: 0x000E4B2A File Offset: 0x000E2D2A
		public IAsyncResult AsyncResult
		{
			get
			{
				return this.m_overlappedData.m_asyncResult;
			}
			set
			{
				this.m_overlappedData.m_asyncResult = value;
			}
		}

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x06003C99 RID: 15513 RVA: 0x000E4B38 File Offset: 0x000E2D38
		// (set) Token: 0x06003C9A RID: 15514 RVA: 0x000E4B4A File Offset: 0x000E2D4A
		public int OffsetLow
		{
			get
			{
				return this.m_overlappedData.m_nativeOverlapped.OffsetLow;
			}
			set
			{
				this.m_overlappedData.m_nativeOverlapped.OffsetLow = value;
			}
		}

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x06003C9B RID: 15515 RVA: 0x000E4B5D File Offset: 0x000E2D5D
		// (set) Token: 0x06003C9C RID: 15516 RVA: 0x000E4B6F File Offset: 0x000E2D6F
		public int OffsetHigh
		{
			get
			{
				return this.m_overlappedData.m_nativeOverlapped.OffsetHigh;
			}
			set
			{
				this.m_overlappedData.m_nativeOverlapped.OffsetHigh = value;
			}
		}

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x06003C9D RID: 15517 RVA: 0x000E4B84 File Offset: 0x000E2D84
		// (set) Token: 0x06003C9E RID: 15518 RVA: 0x000E4BA4 File Offset: 0x000E2DA4
		[Obsolete("This property is not 64-bit compatible.  Use EventHandleIntPtr instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public int EventHandle
		{
			get
			{
				return this.m_overlappedData.UserHandle.ToInt32();
			}
			set
			{
				this.m_overlappedData.UserHandle = new IntPtr(value);
			}
		}

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x06003C9F RID: 15519 RVA: 0x000E4BB7 File Offset: 0x000E2DB7
		// (set) Token: 0x06003CA0 RID: 15520 RVA: 0x000E4BC4 File Offset: 0x000E2DC4
		[ComVisible(false)]
		public IntPtr EventHandleIntPtr
		{
			get
			{
				return this.m_overlappedData.UserHandle;
			}
			set
			{
				this.m_overlappedData.UserHandle = value;
			}
		}

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x06003CA1 RID: 15521 RVA: 0x000E4BD2 File Offset: 0x000E2DD2
		internal _IOCompletionCallback iocbHelper
		{
			get
			{
				return this.m_overlappedData.m_iocbHelper;
			}
		}

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x06003CA2 RID: 15522 RVA: 0x000E4BDF File Offset: 0x000E2DDF
		internal IOCompletionCallback UserCallback
		{
			[SecurityCritical]
			get
			{
				return this.m_overlappedData.m_iocb;
			}
		}

		// Token: 0x06003CA3 RID: 15523 RVA: 0x000E4BEC File Offset: 0x000E2DEC
		[SecurityCritical]
		[Obsolete("This method is not safe.  Use Pack (iocb, userData) instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		[CLSCompliant(false)]
		public unsafe NativeOverlapped* Pack(IOCompletionCallback iocb)
		{
			return this.Pack(iocb, null);
		}

		// Token: 0x06003CA4 RID: 15524 RVA: 0x000E4BF6 File Offset: 0x000E2DF6
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe NativeOverlapped* Pack(IOCompletionCallback iocb, object userData)
		{
			return this.m_overlappedData.Pack(iocb, userData);
		}

		// Token: 0x06003CA5 RID: 15525 RVA: 0x000E4C05 File Offset: 0x000E2E05
		[SecurityCritical]
		[Obsolete("This method is not safe.  Use UnsafePack (iocb, userData) instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
		[CLSCompliant(false)]
		public unsafe NativeOverlapped* UnsafePack(IOCompletionCallback iocb)
		{
			return this.UnsafePack(iocb, null);
		}

		// Token: 0x06003CA6 RID: 15526 RVA: 0x000E4C0F File Offset: 0x000E2E0F
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe NativeOverlapped* UnsafePack(IOCompletionCallback iocb, object userData)
		{
			return this.m_overlappedData.UnsafePack(iocb, userData);
		}

		// Token: 0x06003CA7 RID: 15527 RVA: 0x000E4C20 File Offset: 0x000E2E20
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe static Overlapped Unpack(NativeOverlapped* nativeOverlappedPtr)
		{
			if (nativeOverlappedPtr == null)
			{
				throw new ArgumentNullException("nativeOverlappedPtr");
			}
			return OverlappedData.GetOverlappedFromNative(nativeOverlappedPtr).m_overlapped;
		}

		// Token: 0x06003CA8 RID: 15528 RVA: 0x000E4C4C File Offset: 0x000E2E4C
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe static void Free(NativeOverlapped* nativeOverlappedPtr)
		{
			if (nativeOverlappedPtr == null)
			{
				throw new ArgumentNullException("nativeOverlappedPtr");
			}
			Overlapped overlapped = OverlappedData.GetOverlappedFromNative(nativeOverlappedPtr).m_overlapped;
			OverlappedData.FreeNativeOverlapped(nativeOverlappedPtr);
			OverlappedData overlappedData = overlapped.m_overlappedData;
			overlapped.m_overlappedData = null;
			overlappedData.ReInitialize();
			Overlapped.s_overlappedDataCache.Free(overlappedData);
		}

		// Token: 0x040019B3 RID: 6579
		private OverlappedData m_overlappedData;

		// Token: 0x040019B4 RID: 6580
		private static PinnableBufferCache s_overlappedDataCache = new PinnableBufferCache("System.Threading.OverlappedData", () => new OverlappedData());
	}
}
