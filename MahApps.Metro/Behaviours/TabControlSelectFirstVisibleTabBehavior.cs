using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000BB RID: 187
	public class TabControlSelectFirstVisibleTabBehavior : Behavior<TabControl>
	{
		// Token: 0x06000A20 RID: 2592 RVA: 0x00027393 File Offset: 0x00025593
		protected override void OnAttached()
		{
			base.AssociatedObject.SelectionChanged += this.OnSelectionChanged;
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x000273AC File Offset: 0x000255AC
		private void OnSelectionChanged(object sender, SelectionChangedEventArgs args)
		{
			List<TabItem> list = base.AssociatedObject.Items.Cast<TabItem>().ToList<TabItem>();
			TabItem tabItem = base.AssociatedObject.SelectedItem as TabItem;
			if (tabItem != null && tabItem.Visibility == Visibility.Visible)
			{
				return;
			}
			TabItem tabItem2 = list.FirstOrDefault((TabItem t) => t.Visibility == Visibility.Visible);
			if (tabItem2 != null)
			{
				base.AssociatedObject.SelectedIndex = list.IndexOf(tabItem2);
				return;
			}
			base.AssociatedObject.SelectedItem = null;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00027434 File Offset: 0x00025634
		protected override void OnDetaching()
		{
			base.AssociatedObject.SelectionChanged -= this.OnSelectionChanged;
		}
	}
}
