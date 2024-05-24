using System;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000947 RID: 2375
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public struct GCHandle
	{
		// Token: 0x0600607A RID: 24698 RVA: 0x0014C1E2 File Offset: 0x0014A3E2
		[SecuritySafeCritical]
		static GCHandle()
		{
			if (GCHandle.s_probeIsActive)
			{
				GCHandle.s_cookieTable = new GCHandleCookieTable();
			}
		}

		// Token: 0x0600607B RID: 24699 RVA: 0x0014C205 File Offset: 0x0014A405
		[SecurityCritical]
		internal GCHandle(object value, GCHandleType type)
		{
			if (type > GCHandleType.Pinned)
			{
				throw new ArgumentOutOfRangeException("type", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
			this.m_handle = GCHandle.InternalAlloc(value, type);
			if (type == GCHandleType.Pinned)
			{
				this.SetIsPinned();
			}
		}

		// Token: 0x0600607C RID: 24700 RVA: 0x0014C237 File Offset: 0x0014A437
		[SecurityCritical]
		internal GCHandle(IntPtr handle)
		{
			GCHandle.InternalCheckDomain(handle);
			this.m_handle = handle;
		}

		// Token: 0x0600607D RID: 24701 RVA: 0x0014C246 File Offset: 0x0014A446
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static GCHandle Alloc(object value)
		{
			return new GCHandle(value, GCHandleType.Normal);
		}

		// Token: 0x0600607E RID: 24702 RVA: 0x0014C24F File Offset: 0x0014A44F
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static GCHandle Alloc(object value, GCHandleType type)
		{
			return new GCHandle(value, type);
		}

		// Token: 0x0600607F RID: 24703 RVA: 0x0014C258 File Offset: 0x0014A458
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void Free()
		{
			IntPtr handle = this.m_handle;
			if (handle != IntPtr.Zero && Interlocked.CompareExchange(ref this.m_handle, IntPtr.Zero, handle) == handle)
			{
				if (GCHandle.s_probeIsActive)
				{
					GCHandle.s_cookieTable.RemoveHandleIfPresent(handle);
				}
				GCHandle.InternalFree((IntPtr)((long)handle & -2L));
				return;
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_HandleIsNotInitialized"));
		}

		// Token: 0x170010F9 RID: 4345
		// (get) Token: 0x06006080 RID: 24704 RVA: 0x0014C2CC File Offset: 0x0014A4CC
		// (set) Token: 0x06006081 RID: 24705 RVA: 0x0014C2FB File Offset: 0x0014A4FB
		[__DynamicallyInvokable]
		public object Target
		{
			[SecurityCritical]
			[__DynamicallyInvokable]
			get
			{
				if (this.m_handle == IntPtr.Zero)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_HandleIsNotInitialized"));
				}
				return GCHandle.InternalGet(this.GetHandleValue());
			}
			[SecurityCritical]
			[__DynamicallyInvokable]
			set
			{
				if (this.m_handle == IntPtr.Zero)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_HandleIsNotInitialized"));
				}
				GCHandle.InternalSet(this.GetHandleValue(), value, this.IsPinned());
			}
		}

		// Token: 0x06006082 RID: 24706 RVA: 0x0014C334 File Offset: 0x0014A534
		[SecurityCritical]
		public IntPtr AddrOfPinnedObject()
		{
			if (this.IsPinned())
			{
				return GCHandle.InternalAddrOfPinnedObject(this.GetHandleValue());
			}
			if (this.m_handle == IntPtr.Zero)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_HandleIsNotInitialized"));
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_HandleIsNotPinned"));
		}

		// Token: 0x170010FA RID: 4346
		// (get) Token: 0x06006083 RID: 24707 RVA: 0x0014C386 File Offset: 0x0014A586
		[__DynamicallyInvokable]
		public bool IsAllocated
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_handle != IntPtr.Zero;
			}
		}

		// Token: 0x06006084 RID: 24708 RVA: 0x0014C398 File Offset: 0x0014A598
		[SecurityCritical]
		public static explicit operator GCHandle(IntPtr value)
		{
			return GCHandle.FromIntPtr(value);
		}

		// Token: 0x06006085 RID: 24709 RVA: 0x0014C3A0 File Offset: 0x0014A5A0
		[SecurityCritical]
		public static GCHandle FromIntPtr(IntPtr value)
		{
			if (value == IntPtr.Zero)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_HandleIsNotInitialized"));
			}
			IntPtr intPtr = value;
			if (GCHandle.s_probeIsActive)
			{
				intPtr = GCHandle.s_cookieTable.GetHandle(value);
				if (IntPtr.Zero == intPtr)
				{
					Mda.FireInvalidGCHandleCookieProbe(value);
					return new GCHandle(IntPtr.Zero);
				}
			}
			return new GCHandle(intPtr);
		}

		// Token: 0x06006086 RID: 24710 RVA: 0x0014C407 File Offset: 0x0014A607
		public static explicit operator IntPtr(GCHandle value)
		{
			return GCHandle.ToIntPtr(value);
		}

		// Token: 0x06006087 RID: 24711 RVA: 0x0014C40F File Offset: 0x0014A60F
		public static IntPtr ToIntPtr(GCHandle value)
		{
			if (GCHandle.s_probeIsActive)
			{
				return GCHandle.s_cookieTable.FindOrAddHandle(value.m_handle);
			}
			return value.m_handle;
		}

		// Token: 0x06006088 RID: 24712 RVA: 0x0014C433 File Offset: 0x0014A633
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_handle.GetHashCode();
		}

		// Token: 0x06006089 RID: 24713 RVA: 0x0014C440 File Offset: 0x0014A640
		[__DynamicallyInvokable]
		public override bool Equals(object o)
		{
			if (o == null || !(o is GCHandle))
			{
				return false;
			}
			GCHandle gchandle = (GCHandle)o;
			return this.m_handle == gchandle.m_handle;
		}

		// Token: 0x0600608A RID: 24714 RVA: 0x0014C472 File Offset: 0x0014A672
		[__DynamicallyInvokable]
		public static bool operator ==(GCHandle a, GCHandle b)
		{
			return a.m_handle == b.m_handle;
		}

		// Token: 0x0600608B RID: 24715 RVA: 0x0014C485 File Offset: 0x0014A685
		[__DynamicallyInvokable]
		public static bool operator !=(GCHandle a, GCHandle b)
		{
			return a.m_handle != b.m_handle;
		}

		// Token: 0x0600608C RID: 24716 RVA: 0x0014C498 File Offset: 0x0014A698
		internal IntPtr GetHandleValue()
		{
			return new IntPtr((long)this.m_handle & -2L);
		}

		// Token: 0x0600608D RID: 24717 RVA: 0x0014C4AE File Offset: 0x0014A6AE
		internal bool IsPinned()
		{
			return ((long)this.m_handle & 1L) != 0L;
		}

		// Token: 0x0600608E RID: 24718 RVA: 0x0014C4C2 File Offset: 0x0014A6C2
		internal void SetIsPinned()
		{
			this.m_handle = new IntPtr((long)this.m_handle | 1L);
		}

		// Token: 0x0600608F RID: 24719
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr InternalAlloc(object value, GCHandleType type);

		// Token: 0x06006090 RID: 24720
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalFree(IntPtr handle);

		// Token: 0x06006091 RID: 24721
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object InternalGet(IntPtr handle);

		// Token: 0x06006092 RID: 24722
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalSet(IntPtr handle, object value, bool isPinned);

		// Token: 0x06006093 RID: 24723
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object InternalCompareExchange(IntPtr handle, object value, object oldValue, bool isPinned);

		// Token: 0x06006094 RID: 24724
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr InternalAddrOfPinnedObject(IntPtr handle);

		// Token: 0x06006095 RID: 24725
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalCheckDomain(IntPtr handle);

		// Token: 0x06006096 RID: 24726
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern GCHandleType InternalGetHandleType(IntPtr handle);

		// Token: 0x04002B3E RID: 11070
		private const GCHandleType MaxHandleType = GCHandleType.Pinned;

		// Token: 0x04002B3F RID: 11071
		private IntPtr m_handle;

		// Token: 0x04002B40 RID: 11072
		private static volatile GCHandleCookieTable s_cookieTable;

		// Token: 0x04002B41 RID: 11073
		private static volatile bool s_probeIsActive = Mda.IsInvalidGCHandleCookieProbeEnabled();
	}
}
