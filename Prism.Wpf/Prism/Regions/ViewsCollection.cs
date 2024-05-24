using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Prism.Regions
{
	// Token: 0x02000037 RID: 55
	public class ViewsCollection : IViewsCollection, IEnumerable<object>, IEnumerable, INotifyCollectionChanged
	{
		// Token: 0x06000166 RID: 358 RVA: 0x000048A4 File Offset: 0x00002AA4
		public ViewsCollection(ObservableCollection<ItemMetadata> list, Predicate<ItemMetadata> filter)
		{
			this.subjectCollection = list;
			this.filter = filter;
			this.MonitorAllMetadataItems();
			this.subjectCollection.CollectionChanged += this.SourceCollectionChanged;
			this.UpdateFilteredItemsList();
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000167 RID: 359 RVA: 0x00004900 File Offset: 0x00002B00
		// (remove) Token: 0x06000168 RID: 360 RVA: 0x00004938 File Offset: 0x00002B38
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000496D File Offset: 0x00002B6D
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00004975 File Offset: 0x00002B75
		public Comparison<object> SortComparison
		{
			get
			{
				return this.sort;
			}
			set
			{
				if (this.sort != value)
				{
					this.sort = value;
					this.UpdateFilteredItemsList();
					this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
				}
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600016B RID: 363 RVA: 0x0000499E File Offset: 0x00002B9E
		private IEnumerable<object> FilteredItems
		{
			get
			{
				return this.filteredItems;
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000049A6 File Offset: 0x00002BA6
		public bool Contains(object value)
		{
			return this.FilteredItems.Contains(value);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000049B4 File Offset: 0x00002BB4
		public IEnumerator<object> GetEnumerator()
		{
			return this.FilteredItems.GetEnumerator();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000049C1 File Offset: 0x00002BC1
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000049CC File Offset: 0x00002BCC
		private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			NotifyCollectionChangedEventHandler collectionChanged = this.CollectionChanged;
			if (collectionChanged != null)
			{
				collectionChanged(this, e);
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000049EB File Offset: 0x00002BEB
		private void NotifyReset()
		{
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000049F9 File Offset: 0x00002BF9
		private void ResetAllMonitors()
		{
			this.RemoveAllMetadataMonitors();
			this.MonitorAllMetadataItems();
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00004A08 File Offset: 0x00002C08
		private void MonitorAllMetadataItems()
		{
			foreach (ItemMetadata itemMetadata in this.subjectCollection)
			{
				this.AddMetadataMonitor(itemMetadata, this.filter(itemMetadata));
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00004A64 File Offset: 0x00002C64
		private void RemoveAllMetadataMonitors()
		{
			foreach (KeyValuePair<ItemMetadata, ViewsCollection.MonitorInfo> keyValuePair in this.monitoredItems)
			{
				keyValuePair.Key.MetadataChanged -= this.OnItemMetadataChanged;
			}
			this.monitoredItems.Clear();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00004AD4 File Offset: 0x00002CD4
		private void AddMetadataMonitor(ItemMetadata itemMetadata, bool isInList)
		{
			itemMetadata.MetadataChanged += this.OnItemMetadataChanged;
			this.monitoredItems.Add(itemMetadata, new ViewsCollection.MonitorInfo
			{
				IsInList = isInList
			});
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00004B00 File Offset: 0x00002D00
		private void RemoveMetadataMonitor(ItemMetadata itemMetadata)
		{
			itemMetadata.MetadataChanged -= this.OnItemMetadataChanged;
			this.monitoredItems.Remove(itemMetadata);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00004B24 File Offset: 0x00002D24
		private void OnItemMetadataChanged(object sender, EventArgs e)
		{
			ItemMetadata itemMetadata = (ItemMetadata)sender;
			ViewsCollection.MonitorInfo monitorInfo;
			if (!this.monitoredItems.TryGetValue(itemMetadata, out monitorInfo))
			{
				return;
			}
			if (this.filter(itemMetadata))
			{
				if (!monitorInfo.IsInList)
				{
					monitorInfo.IsInList = true;
					this.UpdateFilteredItemsList();
					this.NotifyAdd(itemMetadata.Item);
					return;
				}
			}
			else
			{
				monitorInfo.IsInList = false;
				this.RemoveFromFilteredList(itemMetadata.Item);
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00004B8C File Offset: 0x00002D8C
		private void SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyCollectionChangedAction action = e.Action;
			if (action != NotifyCollectionChangedAction.Add)
			{
				if (action == NotifyCollectionChangedAction.Remove)
				{
					using (IEnumerator enumerator = e.OldItems.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							ItemMetadata itemMetadata = (ItemMetadata)obj;
							this.RemoveMetadataMonitor(itemMetadata);
							if (this.filter(itemMetadata))
							{
								this.RemoveFromFilteredList(itemMetadata.Item);
							}
						}
						return;
					}
				}
				this.ResetAllMonitors();
				this.UpdateFilteredItemsList();
				this.NotifyReset();
			}
			else
			{
				this.UpdateFilteredItemsList();
				foreach (object obj2 in e.NewItems)
				{
					ItemMetadata itemMetadata2 = (ItemMetadata)obj2;
					bool flag = this.filter(itemMetadata2);
					this.AddMetadataMonitor(itemMetadata2, flag);
					if (flag)
					{
						this.NotifyAdd(itemMetadata2.Item);
					}
				}
				if (this.sort != null)
				{
					this.NotifyReset();
					return;
				}
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00004CA8 File Offset: 0x00002EA8
		private void NotifyAdd(object item)
		{
			int newStartingIndex = this.filteredItems.IndexOf(item);
			this.NotifyAdd(new object[]
			{
				item
			}, newStartingIndex);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00004CD4 File Offset: 0x00002ED4
		private void RemoveFromFilteredList(object item)
		{
			int originalIndex = this.filteredItems.IndexOf(item);
			this.UpdateFilteredItemsList();
			this.NotifyRemove(new object[]
			{
				item
			}, originalIndex);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00004D08 File Offset: 0x00002F08
		private void UpdateFilteredItemsList()
		{
			this.filteredItems = (from i in this.subjectCollection
			where this.filter(i)
			select i.Item).OrderBy((object o) => o, new ViewsCollection.RegionItemComparer(this.SortComparison)).ToList<object>();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00004D8A File Offset: 0x00002F8A
		private void NotifyAdd(IList items, int newStartingIndex)
		{
			if (items.Count > 0)
			{
				this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, newStartingIndex));
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00004DA3 File Offset: 0x00002FA3
		private void NotifyRemove(IList items, int originalIndex)
		{
			if (items.Count > 0)
			{
				this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items, originalIndex));
			}
		}

		// Token: 0x04000042 RID: 66
		private readonly ObservableCollection<ItemMetadata> subjectCollection;

		// Token: 0x04000043 RID: 67
		private readonly Dictionary<ItemMetadata, ViewsCollection.MonitorInfo> monitoredItems = new Dictionary<ItemMetadata, ViewsCollection.MonitorInfo>();

		// Token: 0x04000044 RID: 68
		private readonly Predicate<ItemMetadata> filter;

		// Token: 0x04000045 RID: 69
		private Comparison<object> sort;

		// Token: 0x04000046 RID: 70
		private List<object> filteredItems = new List<object>();

		// Token: 0x02000096 RID: 150
		private class MonitorInfo
		{
			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x06000409 RID: 1033 RVA: 0x0000A139 File Offset: 0x00008339
			// (set) Token: 0x0600040A RID: 1034 RVA: 0x0000A141 File Offset: 0x00008341
			public bool IsInList { get; set; }
		}

		// Token: 0x02000097 RID: 151
		private class RegionItemComparer : Comparer<object>
		{
			// Token: 0x0600040C RID: 1036 RVA: 0x0000A14A File Offset: 0x0000834A
			public RegionItemComparer(Comparison<object> comparer)
			{
				this.comparer = comparer;
			}

			// Token: 0x0600040D RID: 1037 RVA: 0x0000A159 File Offset: 0x00008359
			public override int Compare(object x, object y)
			{
				if (this.comparer == null)
				{
					return 0;
				}
				return this.comparer(x, y);
			}

			// Token: 0x040000E9 RID: 233
			private readonly Comparison<object> comparer;
		}
	}
}
