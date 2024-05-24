using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200048B RID: 1163
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class CollectionBase : IList, ICollection, IEnumerable
	{
		// Token: 0x06003772 RID: 14194 RVA: 0x000D55CC File Offset: 0x000D37CC
		protected CollectionBase()
		{
			this.list = new ArrayList();
		}

		// Token: 0x06003773 RID: 14195 RVA: 0x000D55DF File Offset: 0x000D37DF
		protected CollectionBase(int capacity)
		{
			this.list = new ArrayList(capacity);
		}

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06003774 RID: 14196 RVA: 0x000D55F3 File Offset: 0x000D37F3
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

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06003775 RID: 14197 RVA: 0x000D560E File Offset: 0x000D380E
		protected IList List
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06003776 RID: 14198 RVA: 0x000D5611 File Offset: 0x000D3811
		// (set) Token: 0x06003777 RID: 14199 RVA: 0x000D561E File Offset: 0x000D381E
		[ComVisible(false)]
		public int Capacity
		{
			get
			{
				return this.InnerList.Capacity;
			}
			set
			{
				this.InnerList.Capacity = value;
			}
		}

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06003778 RID: 14200 RVA: 0x000D562C File Offset: 0x000D382C
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.list != null)
				{
					return this.list.Count;
				}
				return 0;
			}
		}

		// Token: 0x06003779 RID: 14201 RVA: 0x000D5643 File Offset: 0x000D3843
		[__DynamicallyInvokable]
		public void Clear()
		{
			this.OnClear();
			this.InnerList.Clear();
			this.OnClearComplete();
		}

		// Token: 0x0600377A RID: 14202 RVA: 0x000D565C File Offset: 0x000D385C
		[__DynamicallyInvokable]
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			object value = this.InnerList[index];
			this.OnValidate(value);
			this.OnRemove(index, value);
			this.InnerList.RemoveAt(index);
			try
			{
				this.OnRemoveComplete(index, value);
			}
			catch
			{
				this.InnerList.Insert(index, value);
				throw;
			}
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x0600377B RID: 14203 RVA: 0x000D56E0 File Offset: 0x000D38E0
		bool IList.IsReadOnly
		{
			get
			{
				return this.InnerList.IsReadOnly;
			}
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x0600377C RID: 14204 RVA: 0x000D56ED File Offset: 0x000D38ED
		bool IList.IsFixedSize
		{
			get
			{
				return this.InnerList.IsFixedSize;
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x0600377D RID: 14205 RVA: 0x000D56FA File Offset: 0x000D38FA
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerList.IsSynchronized;
			}
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x0600377E RID: 14206 RVA: 0x000D5707 File Offset: 0x000D3907
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerList.SyncRoot;
			}
		}

		// Token: 0x0600377F RID: 14207 RVA: 0x000D5714 File Offset: 0x000D3914
		void ICollection.CopyTo(Array array, int index)
		{
			this.InnerList.CopyTo(array, index);
		}

		// Token: 0x1700082B RID: 2091
		object IList.this[int index]
		{
			get
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				return this.InnerList[index];
			}
			set
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
				}
				this.OnValidate(value);
				object obj = this.InnerList[index];
				this.OnSet(index, obj, value);
				this.InnerList[index] = value;
				try
				{
					this.OnSetComplete(index, obj, value);
				}
				catch
				{
					this.InnerList[index] = obj;
					throw;
				}
			}
		}

		// Token: 0x06003782 RID: 14210 RVA: 0x000D57D8 File Offset: 0x000D39D8
		bool IList.Contains(object value)
		{
			return this.InnerList.Contains(value);
		}

		// Token: 0x06003783 RID: 14211 RVA: 0x000D57E8 File Offset: 0x000D39E8
		int IList.Add(object value)
		{
			this.OnValidate(value);
			this.OnInsert(this.InnerList.Count, value);
			int num = this.InnerList.Add(value);
			try
			{
				this.OnInsertComplete(num, value);
			}
			catch
			{
				this.InnerList.RemoveAt(num);
				throw;
			}
			return num;
		}

		// Token: 0x06003784 RID: 14212 RVA: 0x000D5848 File Offset: 0x000D3A48
		void IList.Remove(object value)
		{
			this.OnValidate(value);
			int num = this.InnerList.IndexOf(value);
			if (num < 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RemoveArgNotFound"));
			}
			this.OnRemove(num, value);
			this.InnerList.RemoveAt(num);
			try
			{
				this.OnRemoveComplete(num, value);
			}
			catch
			{
				this.InnerList.Insert(num, value);
				throw;
			}
		}

		// Token: 0x06003785 RID: 14213 RVA: 0x000D58BC File Offset: 0x000D3ABC
		int IList.IndexOf(object value)
		{
			return this.InnerList.IndexOf(value);
		}

		// Token: 0x06003786 RID: 14214 RVA: 0x000D58CC File Offset: 0x000D3ACC
		void IList.Insert(int index, object value)
		{
			if (index < 0 || index > this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			this.OnValidate(value);
			this.OnInsert(index, value);
			this.InnerList.Insert(index, value);
			try
			{
				this.OnInsertComplete(index, value);
			}
			catch
			{
				this.InnerList.RemoveAt(index);
				throw;
			}
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x000D5940 File Offset: 0x000D3B40
		[__DynamicallyInvokable]
		public IEnumerator GetEnumerator()
		{
			return this.InnerList.GetEnumerator();
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x000D594D File Offset: 0x000D3B4D
		protected virtual void OnSet(int index, object oldValue, object newValue)
		{
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x000D594F File Offset: 0x000D3B4F
		protected virtual void OnInsert(int index, object value)
		{
		}

		// Token: 0x0600378A RID: 14218 RVA: 0x000D5951 File Offset: 0x000D3B51
		protected virtual void OnClear()
		{
		}

		// Token: 0x0600378B RID: 14219 RVA: 0x000D5953 File Offset: 0x000D3B53
		protected virtual void OnRemove(int index, object value)
		{
		}

		// Token: 0x0600378C RID: 14220 RVA: 0x000D5955 File Offset: 0x000D3B55
		protected virtual void OnValidate(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
		}

		// Token: 0x0600378D RID: 14221 RVA: 0x000D5965 File Offset: 0x000D3B65
		protected virtual void OnSetComplete(int index, object oldValue, object newValue)
		{
		}

		// Token: 0x0600378E RID: 14222 RVA: 0x000D5967 File Offset: 0x000D3B67
		protected virtual void OnInsertComplete(int index, object value)
		{
		}

		// Token: 0x0600378F RID: 14223 RVA: 0x000D5969 File Offset: 0x000D3B69
		protected virtual void OnClearComplete()
		{
		}

		// Token: 0x06003790 RID: 14224 RVA: 0x000D596B File Offset: 0x000D3B6B
		protected virtual void OnRemoveComplete(int index, object value)
		{
		}

		// Token: 0x040018B1 RID: 6321
		private ArrayList list;
	}
}
