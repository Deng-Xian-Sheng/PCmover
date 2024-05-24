using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200042D RID: 1069
	internal struct SessionMask
	{
		// Token: 0x0600355A RID: 13658 RVA: 0x000CEFBB File Offset: 0x000CD1BB
		public SessionMask(SessionMask m)
		{
			this.m_mask = m.m_mask;
		}

		// Token: 0x0600355B RID: 13659 RVA: 0x000CEFC9 File Offset: 0x000CD1C9
		public SessionMask(uint mask = 0U)
		{
			this.m_mask = (mask & 15U);
		}

		// Token: 0x0600355C RID: 13660 RVA: 0x000CEFD5 File Offset: 0x000CD1D5
		public bool IsEqualOrSupersetOf(SessionMask m)
		{
			return (this.m_mask | m.m_mask) == this.m_mask;
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x0600355D RID: 13661 RVA: 0x000CEFEC File Offset: 0x000CD1EC
		public static SessionMask All
		{
			get
			{
				return new SessionMask(15U);
			}
		}

		// Token: 0x0600355E RID: 13662 RVA: 0x000CEFF5 File Offset: 0x000CD1F5
		public static SessionMask FromId(int perEventSourceSessionId)
		{
			return new SessionMask(1U << perEventSourceSessionId);
		}

		// Token: 0x0600355F RID: 13663 RVA: 0x000CF002 File Offset: 0x000CD202
		public ulong ToEventKeywords()
		{
			return (ulong)this.m_mask << 44;
		}

		// Token: 0x06003560 RID: 13664 RVA: 0x000CF00E File Offset: 0x000CD20E
		public static SessionMask FromEventKeywords(ulong m)
		{
			return new SessionMask((uint)(m >> 44));
		}

		// Token: 0x170007F3 RID: 2035
		public bool this[int perEventSourceSessionId]
		{
			get
			{
				return ((ulong)this.m_mask & (ulong)(1L << (perEventSourceSessionId & 31))) > 0UL;
			}
			set
			{
				if (value)
				{
					this.m_mask |= 1U << perEventSourceSessionId;
					return;
				}
				this.m_mask &= ~(1U << perEventSourceSessionId);
			}
		}

		// Token: 0x06003563 RID: 13667 RVA: 0x000CF05C File Offset: 0x000CD25C
		public static SessionMask operator |(SessionMask m1, SessionMask m2)
		{
			return new SessionMask(m1.m_mask | m2.m_mask);
		}

		// Token: 0x06003564 RID: 13668 RVA: 0x000CF070 File Offset: 0x000CD270
		public static SessionMask operator &(SessionMask m1, SessionMask m2)
		{
			return new SessionMask(m1.m_mask & m2.m_mask);
		}

		// Token: 0x06003565 RID: 13669 RVA: 0x000CF084 File Offset: 0x000CD284
		public static SessionMask operator ^(SessionMask m1, SessionMask m2)
		{
			return new SessionMask(m1.m_mask ^ m2.m_mask);
		}

		// Token: 0x06003566 RID: 13670 RVA: 0x000CF098 File Offset: 0x000CD298
		public static SessionMask operator ~(SessionMask m)
		{
			return new SessionMask(15U & ~m.m_mask);
		}

		// Token: 0x06003567 RID: 13671 RVA: 0x000CF0A9 File Offset: 0x000CD2A9
		public static explicit operator ulong(SessionMask m)
		{
			return (ulong)m.m_mask;
		}

		// Token: 0x06003568 RID: 13672 RVA: 0x000CF0B2 File Offset: 0x000CD2B2
		public static explicit operator uint(SessionMask m)
		{
			return m.m_mask;
		}

		// Token: 0x040017B7 RID: 6071
		private uint m_mask;

		// Token: 0x040017B8 RID: 6072
		internal const int SHIFT_SESSION_TO_KEYWORD = 44;

		// Token: 0x040017B9 RID: 6073
		internal const uint MASK = 15U;

		// Token: 0x040017BA RID: 6074
		internal const uint MAX = 4U;
	}
}
