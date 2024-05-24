using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000123 RID: 291
	internal class JumpListItemCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged
	{
		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000D0A RID: 3338 RVA: 0x00030B04 File Offset: 0x0002ED04
		// (remove) Token: 0x06000D0B RID: 3339 RVA: 0x00030B40 File Offset: 0x0002ED40
		public event NotifyCollectionChangedEventHandler CollectionChanged = delegate(object param0, NotifyCollectionChangedEventArgs param1)
		{
		};

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x00030B7C File Offset: 0x0002ED7C
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x00030B93 File Offset: 0x0002ED93
		public bool IsReadOnly { get; set; }

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x00030B9C File Offset: 0x0002ED9C
		public int Count
		{
			get
			{
				return this.items.Count;
			}
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00030BB9 File Offset: 0x0002EDB9
		public void Add(T item)
		{
			this.items.Add(item);
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x00030BE4 File Offset: 0x0002EDE4
		public bool Remove(T item)
		{
			bool flag = this.items.Remove(item);
			if (flag)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, 0));
			}
			return flag;
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00030C27 File Offset: 0x0002EE27
		public void Clear()
		{
			this.items.Clear();
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00030C4C File Offset: 0x0002EE4C
		public bool Contains(T item)
		{
			return this.items.Contains(item);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00030C6A File Offset: 0x0002EE6A
		public void CopyTo(T[] array, int index)
		{
			this.items.CopyTo(array, index);
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x00030C7C File Offset: 0x0002EE7C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x00030CA0 File Offset: 0x0002EEA0
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		// Token: 0x040004F2 RID: 1266
		private List<T> items = new List<T>();
	}
}
