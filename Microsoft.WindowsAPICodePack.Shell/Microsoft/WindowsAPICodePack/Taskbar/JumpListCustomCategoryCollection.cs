using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000122 RID: 290
	internal class JumpListCustomCategoryCollection : ICollection<JumpListCustomCategory>, IEnumerable<JumpListCustomCategory>, IEnumerable, INotifyCollectionChanged
	{
		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000CFC RID: 3324 RVA: 0x000308C8 File Offset: 0x0002EAC8
		// (remove) Token: 0x06000CFD RID: 3325 RVA: 0x00030904 File Offset: 0x0002EB04
		public event NotifyCollectionChangedEventHandler CollectionChanged = delegate(object param0, NotifyCollectionChangedEventArgs param1)
		{
		};

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00030940 File Offset: 0x0002EB40
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x00030957 File Offset: 0x0002EB57
		public bool IsReadOnly { get; set; }

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x00030960 File Offset: 0x0002EB60
		public int Count
		{
			get
			{
				return this.categories.Count;
			}
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00030980 File Offset: 0x0002EB80
		public void Add(JumpListCustomCategory category)
		{
			if (category == null)
			{
				throw new ArgumentNullException("category");
			}
			this.categories.Add(category);
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, category));
			category.CollectionChanged += this.CollectionChanged;
			category.JumpListItems.CollectionChanged += this.CollectionChanged;
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x000309E8 File Offset: 0x0002EBE8
		public bool Remove(JumpListCustomCategory category)
		{
			bool flag = this.categories.Remove(category);
			if (flag)
			{
				this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, 0));
			}
			return flag;
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x00030A2B File Offset: 0x0002EC2B
		public void Clear()
		{
			this.categories.Clear();
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00030A50 File Offset: 0x0002EC50
		public bool Contains(JumpListCustomCategory category)
		{
			return this.categories.Contains(category);
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x00030A6E File Offset: 0x0002EC6E
		public void CopyTo(JumpListCustomCategory[] array, int index)
		{
			this.categories.CopyTo(array, index);
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00030A80 File Offset: 0x0002EC80
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.categories.GetEnumerator();
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00030AA4 File Offset: 0x0002ECA4
		IEnumerator<JumpListCustomCategory> IEnumerable<JumpListCustomCategory>.GetEnumerator()
		{
			return this.categories.GetEnumerator();
		}

		// Token: 0x040004EE RID: 1262
		private List<JumpListCustomCategory> categories = new List<JumpListCustomCategory>();
	}
}
