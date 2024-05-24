using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000183 RID: 387
	public class JumpListCustomCategory
	{
		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x00034654 File Offset: 0x00032854
		// (set) Token: 0x06000EFD RID: 3837 RVA: 0x0003466B File Offset: 0x0003286B
		internal JumpListItemCollection<IJumpListItem> JumpListItems { get; private set; }

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x00034674 File Offset: 0x00032874
		// (set) Token: 0x06000EFF RID: 3839 RVA: 0x0003468C File Offset: 0x0003288C
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (value != this.name)
				{
					this.name = value;
					this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
				}
			}
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x000346CC File Offset: 0x000328CC
		public void AddJumpListItems(params IJumpListItem[] items)
		{
			if (items != null)
			{
				foreach (IJumpListItem item in items)
				{
					this.JumpListItems.Add(item);
				}
			}
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06000F01 RID: 3841 RVA: 0x0003470C File Offset: 0x0003290C
		// (remove) Token: 0x06000F02 RID: 3842 RVA: 0x00034748 File Offset: 0x00032948
		internal event NotifyCollectionChangedEventHandler CollectionChanged = delegate(object param0, NotifyCollectionChangedEventArgs param1)
		{
		};

		// Token: 0x06000F03 RID: 3843 RVA: 0x00034788 File Offset: 0x00032988
		public JumpListCustomCategory(string categoryName)
		{
			this.Name = categoryName;
			this.JumpListItems = new JumpListItemCollection<IJumpListItem>();
			this.JumpListItems.CollectionChanged += this.OnJumpListCollectionChanged;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x000347EF File Offset: 0x000329EF
		internal void OnJumpListCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			this.CollectionChanged(this, args);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x0003482C File Offset: 0x00032A2C
		internal void RemoveJumpListItem(string path)
		{
			List<IJumpListItem> list = new List<IJumpListItem>(from i in this.JumpListItems
			where string.Equals(path, i.Path, StringComparison.OrdinalIgnoreCase)
			select i);
			for (int j = 0; j < list.Count; j++)
			{
				this.JumpListItems.Remove(list[j]);
			}
		}

		// Token: 0x04000663 RID: 1635
		private string name;
	}
}
