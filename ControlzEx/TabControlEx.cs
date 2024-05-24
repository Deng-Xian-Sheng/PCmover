using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ControlzEx
{
	// Token: 0x0200000A RID: 10
	[TemplatePart(Name = "PART_ItemsHolder", Type = typeof(Panel))]
	public class TabControlEx : TabControl
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002DDA File Offset: 0x00000FDA
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002DEC File Offset: 0x00000FEC
		public Visibility ChildContentVisibility
		{
			get
			{
				return (Visibility)base.GetValue(TabControlEx.ChildContentVisibilityProperty);
			}
			set
			{
				base.SetValue(TabControlEx.ChildContentVisibilityProperty, value);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002DFF File Offset: 0x00000FFF
		public TabControlEx()
		{
			base.ItemContainerGenerator.StatusChanged += this.ItemContainerGenerator_StatusChanged;
			base.Loaded += this.TabControlEx_Loaded;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002E30 File Offset: 0x00001030
		private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
		{
			if (base.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
			{
				base.ItemContainerGenerator.StatusChanged -= this.ItemContainerGenerator_StatusChanged;
				this.UpdateSelectedItem();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002E5D File Offset: 0x0000105D
		private void TabControlEx_Loaded(object sender, RoutedEventArgs e)
		{
			this.UpdateSelectedItem();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002E65 File Offset: 0x00001065
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._itemsHolder = (base.GetTemplateChild("PART_ItemsHolder") as Panel);
			this.UpdateSelectedItem();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002E8C File Offset: 0x0000108C
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			if (this._itemsHolder == null)
			{
				return;
			}
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
			case NotifyCollectionChangedAction.Remove:
				if (e.OldItems != null)
				{
					foreach (object data in e.OldItems)
					{
						ContentPresenter contentPresenter = this.FindChildContentPresenter(data);
						if (contentPresenter != null)
						{
							this._itemsHolder.Children.Remove(contentPresenter);
						}
					}
				}
				this.UpdateSelectedItem();
				return;
			case NotifyCollectionChangedAction.Replace:
				throw new NotImplementedException("Replace not implemented yet");
			case NotifyCollectionChangedAction.Move:
				return;
			case NotifyCollectionChangedAction.Reset:
				this._itemsHolder.Children.Clear();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002F58 File Offset: 0x00001158
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			base.OnSelectionChanged(e);
			this.UpdateSelectedItem();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002F68 File Offset: 0x00001168
		private void UpdateSelectedItem()
		{
			if (this._itemsHolder == null)
			{
				return;
			}
			TabItem selectedTabItem = this.GetSelectedTabItem();
			if (selectedTabItem != null)
			{
				this.CreateChildContentPresenter(selectedTabItem);
			}
			foreach (object obj in this._itemsHolder.Children)
			{
				ContentPresenter contentPresenter = (ContentPresenter)obj;
				contentPresenter.Visibility = ((contentPresenter.Tag as TabItem).IsSelected ? Visibility.Visible : this.ChildContentVisibility);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002FFC File Offset: 0x000011FC
		private ContentPresenter CreateChildContentPresenter(object item)
		{
			if (item == null)
			{
				return null;
			}
			ContentPresenter contentPresenter = this.FindChildContentPresenter(item);
			if (contentPresenter != null)
			{
				return contentPresenter;
			}
			TabItem tabItem = item as TabItem;
			contentPresenter = new ContentPresenter();
			contentPresenter.Content = ((tabItem != null) ? tabItem.Content : item);
			contentPresenter.ContentTemplate = base.SelectedContentTemplate;
			contentPresenter.ContentTemplateSelector = base.SelectedContentTemplateSelector;
			contentPresenter.ContentStringFormat = base.SelectedContentStringFormat;
			contentPresenter.Visibility = this.ChildContentVisibility;
			contentPresenter.Tag = (tabItem ?? base.ItemContainerGenerator.ContainerFromItem(item));
			this._itemsHolder.Children.Add(contentPresenter);
			return contentPresenter;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003094 File Offset: 0x00001294
		private ContentPresenter FindChildContentPresenter(object data)
		{
			if (data is TabItem)
			{
				data = ((TabItem)data).Content;
			}
			if (data == null)
			{
				return null;
			}
			if (this._itemsHolder == null)
			{
				return null;
			}
			foreach (object obj in this._itemsHolder.Children)
			{
				ContentPresenter contentPresenter = (ContentPresenter)obj;
				if (contentPresenter.Content == data)
				{
					return contentPresenter;
				}
			}
			return null;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003120 File Offset: 0x00001320
		protected TabItem GetSelectedTabItem()
		{
			object selectedItem = base.SelectedItem;
			if (selectedItem == null)
			{
				return null;
			}
			TabItem tabItem = selectedItem as TabItem;
			if (tabItem == null)
			{
				tabItem = (base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) as TabItem);
			}
			return tabItem;
		}

		// Token: 0x04000028 RID: 40
		public static readonly DependencyProperty ChildContentVisibilityProperty = DependencyProperty.Register("ChildContentVisibility", typeof(Visibility), typeof(TabControlEx), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x04000029 RID: 41
		private Panel _itemsHolder;
	}
}
