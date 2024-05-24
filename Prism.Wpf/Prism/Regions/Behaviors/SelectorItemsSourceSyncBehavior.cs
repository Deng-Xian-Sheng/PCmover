using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Prism.Properties;

namespace Prism.Regions.Behaviors
{
	// Token: 0x02000042 RID: 66
	public class SelectorItemsSourceSyncBehavior : RegionBehavior, IHostAwareRegionBehavior, IRegionBehavior
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00005A0C File Offset: 0x00003C0C
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00005A14 File Offset: 0x00003C14
		public DependencyObject HostControl
		{
			get
			{
				return this.hostControl;
			}
			set
			{
				this.hostControl = (value as Selector);
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00005A24 File Offset: 0x00003C24
		protected override void OnAttach()
		{
			if (this.hostControl.ItemsSource != null || BindingOperations.GetBinding(this.hostControl, ItemsControl.ItemsSourceProperty) != null)
			{
				throw new InvalidOperationException(Resources.ItemsControlHasItemsSourceException);
			}
			this.SynchronizeItems();
			this.hostControl.SelectionChanged += this.HostControlSelectionChanged;
			base.Region.ActiveViews.CollectionChanged += this.ActiveViews_CollectionChanged;
			base.Region.Views.CollectionChanged += this.Views_CollectionChanged;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00005ABC File Offset: 0x00003CBC
		private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				int newStartingIndex = e.NewStartingIndex;
				using (IEnumerator enumerator = e.NewItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object insertItem = enumerator.Current;
						this.hostControl.Items.Insert(newStartingIndex++, insertItem);
					}
					return;
				}
			}
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (object removeItem in e.OldItems)
				{
					this.hostControl.Items.Remove(removeItem);
				}
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00005B88 File Offset: 0x00003D88
		private void SynchronizeItems()
		{
			List<object> list = new List<object>();
			foreach (object item in ((IEnumerable)this.hostControl.Items))
			{
				list.Add(item);
			}
			foreach (object newItem in base.Region.Views)
			{
				this.hostControl.Items.Add(newItem);
			}
			foreach (object view in list)
			{
				base.Region.Add(view);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00005C80 File Offset: 0x00003E80
		private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (this.updatingActiveViewsInHostControlSelectionChanged)
			{
				return;
			}
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				if (this.hostControl.SelectedItem != null && this.hostControl.SelectedItem != e.NewItems[0] && base.Region.ActiveViews.Contains(this.hostControl.SelectedItem))
				{
					base.Region.Deactivate(this.hostControl.SelectedItem);
				}
				this.hostControl.SelectedItem = e.NewItems[0];
				return;
			}
			if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems.Contains(this.hostControl.SelectedItem))
			{
				this.hostControl.SelectedItem = null;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00005D3C File Offset: 0x00003F3C
		private void HostControlSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.updatingActiveViewsInHostControlSelectionChanged = true;
				if (e.OriginalSource == sender)
				{
					foreach (object obj in e.RemovedItems)
					{
						if (base.Region.Views.Contains(obj) && base.Region.ActiveViews.Contains(obj))
						{
							base.Region.Deactivate(obj);
						}
					}
					foreach (object obj2 in e.AddedItems)
					{
						if (base.Region.Views.Contains(obj2) && !base.Region.ActiveViews.Contains(obj2))
						{
							base.Region.Activate(obj2);
						}
					}
				}
			}
			finally
			{
				this.updatingActiveViewsInHostControlSelectionChanged = false;
			}
		}

		// Token: 0x0400005A RID: 90
		public static readonly string BehaviorKey = "SelectorItemsSourceSyncBehavior";

		// Token: 0x0400005B RID: 91
		private bool updatingActiveViewsInHostControlSelectionChanged;

		// Token: 0x0400005C RID: 92
		private Selector hostControl;
	}
}
