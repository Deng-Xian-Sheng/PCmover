using System;

namespace System.Threading
{
	// Token: 0x02000549 RID: 1353
	internal class SparselyPopulatedArrayFragment<T> where T : class
	{
		// Token: 0x06003F6D RID: 16237 RVA: 0x000EC27E File Offset: 0x000EA47E
		internal SparselyPopulatedArrayFragment(int size) : this(size, null)
		{
		}

		// Token: 0x06003F6E RID: 16238 RVA: 0x000EC288 File Offset: 0x000EA488
		internal SparselyPopulatedArrayFragment(int size, SparselyPopulatedArrayFragment<T> prev)
		{
			this.m_elements = new T[size];
			this.m_freeCount = size;
			this.m_prev = prev;
		}

		// Token: 0x17000964 RID: 2404
		internal T this[int index]
		{
			get
			{
				return Volatile.Read<T>(ref this.m_elements[index]);
			}
		}

		// Token: 0x17000965 RID: 2405
		// (get) Token: 0x06003F70 RID: 16240 RVA: 0x000EC2C1 File Offset: 0x000EA4C1
		internal int Length
		{
			get
			{
				return this.m_elements.Length;
			}
		}

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x06003F71 RID: 16241 RVA: 0x000EC2CB File Offset: 0x000EA4CB
		internal SparselyPopulatedArrayFragment<T> Prev
		{
			get
			{
				return this.m_prev;
			}
		}

		// Token: 0x06003F72 RID: 16242 RVA: 0x000EC2D8 File Offset: 0x000EA4D8
		internal T SafeAtomicRemove(int index, T expectedElement)
		{
			T t = Interlocked.CompareExchange<T>(ref this.m_elements[index], default(T), expectedElement);
			if (t != null)
			{
				this.m_freeCount++;
			}
			return t;
		}

		// Token: 0x04001AB1 RID: 6833
		internal readonly T[] m_elements;

		// Token: 0x04001AB2 RID: 6834
		internal volatile int m_freeCount;

		// Token: 0x04001AB3 RID: 6835
		internal volatile SparselyPopulatedArrayFragment<T> m_next;

		// Token: 0x04001AB4 RID: 6836
		internal volatile SparselyPopulatedArrayFragment<T> m_prev;
	}
}
