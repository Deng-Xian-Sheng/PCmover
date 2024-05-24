using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200048D RID: 1165
	[ComVisible(true)]
	[Serializable]
	public abstract class ReadOnlyCollectionBase : ICollection, IEnumerable
	{
		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x060037AE RID: 14254 RVA: 0x000D5BD3 File Offset: 0x000D3DD3
		protected ArrayList InnerList
		{
			get
			{
				if (this.list == null)
				{
					this.list = new ArrayList();
				}
				return this.list;
			}
		}

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x060037AF RID: 14255 RVA: 0x000D5BEE File Offset: 0x000D3DEE
		public virtual int Count
		{
			get
			{
				return this.InnerList.Count;
			}
		}

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x060037B0 RID: 14256 RVA: 0x000D5BFB File Offset: 0x000D3DFB
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerList.IsSynchronized;
			}
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x060037B1 RID: 14257 RVA: 0x000D5C08 File Offset: 0x000D3E08
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerList.SyncRoot;
			}
		}

		// Token: 0x060037B2 RID: 14258 RVA: 0x000D5C15 File Offset: 0x000D3E15
		void ICollection.CopyTo(Array array, int index)
		{
			this.InnerList.CopyTo(array, index);
		}

		// Token: 0x060037B3 RID: 14259 RVA: 0x000D5C24 File Offset: 0x000D3E24
		public virtual IEnumerator GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		// Token: 0x040018B3 RID: 6323
		private ArrayList list;
	}
}
