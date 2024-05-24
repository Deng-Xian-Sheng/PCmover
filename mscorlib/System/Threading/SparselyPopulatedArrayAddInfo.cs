using System;

namespace System.Threading
{
	// Token: 0x02000548 RID: 1352
	internal struct SparselyPopulatedArrayAddInfo<T> where T : class
	{
		// Token: 0x06003F6A RID: 16234 RVA: 0x000EC25E File Offset: 0x000EA45E
		internal SparselyPopulatedArrayAddInfo(SparselyPopulatedArrayFragment<T> source, int index)
		{
			this.m_source = source;
			this.m_index = index;
		}

		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x06003F6B RID: 16235 RVA: 0x000EC26E File Offset: 0x000EA46E
		internal SparselyPopulatedArrayFragment<T> Source
		{
			get
			{
				return this.m_source;
			}
		}

		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x06003F6C RID: 16236 RVA: 0x000EC276 File Offset: 0x000EA476
		internal int Index
		{
			get
			{
				return this.m_index;
			}
		}

		// Token: 0x04001AAF RID: 6831
		private SparselyPopulatedArrayFragment<T> m_source;

		// Token: 0x04001AB0 RID: 6832
		private int m_index;
	}
}
