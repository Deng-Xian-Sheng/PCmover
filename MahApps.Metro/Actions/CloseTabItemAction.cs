using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Actions
{
	// Token: 0x020000BF RID: 191
	public class CloseTabItemAction : CommandTriggerAction
	{
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x00027F58 File Offset: 0x00026158
		private TabItem AssociatedTabItem
		{
			get
			{
				TabItem result;
				if ((result = this.associatedTabItem) == null)
				{
					result = (this.associatedTabItem = base.AssociatedObject.TryFindParent<TabItem>());
				}
				return result;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x00027F83 File Offset: 0x00026183
		// (set) Token: 0x06000A40 RID: 2624 RVA: 0x00027F95 File Offset: 0x00026195
		[Obsolete("This property will be deleted in the next release.")]
		public TabControl TabControl
		{
			get
			{
				return (TabControl)base.GetValue(CloseTabItemAction.TabControlProperty);
			}
			set
			{
				base.SetValue(CloseTabItemAction.TabControlProperty, value);
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00027FA3 File Offset: 0x000261A3
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x00027FB5 File Offset: 0x000261B5
		[Obsolete("This property will be deleted in the next release.")]
		public TabItem TabItem
		{
			get
			{
				return (TabItem)base.GetValue(CloseTabItemAction.TabItemProperty);
			}
			set
			{
				base.SetValue(CloseTabItemAction.TabItemProperty, value);
			}
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00027FC4 File Offset: 0x000261C4
		protected override void Invoke(object parameter)
		{
			if (base.AssociatedObject == null || (base.AssociatedObject != null && !base.AssociatedObject.IsEnabled))
			{
				return;
			}
			TabControl tabControl = base.AssociatedObject.TryFindParent<TabControl>();
			TabItem tabItem = this.AssociatedTabItem;
			if (tabControl == null || tabItem == null)
			{
				return;
			}
			ICommand command = base.Command;
			if (command != null)
			{
				object commandParameter = this.GetCommandParameter();
				if (command.CanExecute(commandParameter))
				{
					command.Execute(commandParameter);
				}
			}
			if (tabControl is MetroTabControl && tabItem is MetroTabItem)
			{
				tabControl.BeginInvoke(delegate
				{
					((MetroTabControl)tabControl).CloseThisTabItem((MetroTabItem)tabItem);
				}, DispatcherPriority.Background);
				return;
			}
			Func<object, bool> <>9__2;
			Action invokeAction = delegate()
			{
				if (tabControl.ItemsSource == null)
				{
					tabItem.ClearStyle();
					tabControl.Items.Remove(tabItem);
					return;
				}
				IList list = tabControl.ItemsSource as IList;
				if (list == null)
				{
					return;
				}
				IEnumerable<object> source = list.OfType<object>();
				Func<object, bool> predicate;
				if ((predicate = <>9__2) == null)
				{
					predicate = (<>9__2 = ((object item) => tabItem == item || tabItem.DataContext == item));
				}
				object obj = source.FirstOrDefault(predicate);
				if (obj != null)
				{
					tabItem.ClearStyle();
					list.Remove(obj);
				}
			};
			this.BeginInvoke(invokeAction, DispatcherPriority.Background);
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0002808C File Offset: 0x0002628C
		protected override object GetCommandParameter()
		{
			return base.CommandParameter ?? this.AssociatedTabItem;
		}

		// Token: 0x0400047A RID: 1146
		private TabItem associatedTabItem;

		// Token: 0x0400047B RID: 1147
		[Obsolete("This property will be deleted in the next release.")]
		public static readonly DependencyProperty TabControlProperty = DependencyProperty.Register("TabControl", typeof(TabControl), typeof(CloseTabItemAction), new PropertyMetadata(null));

		// Token: 0x0400047C RID: 1148
		[Obsolete("This property will be deleted in the next release.")]
		public static readonly DependencyProperty TabItemProperty = DependencyProperty.Register("TabItem", typeof(TabItem), typeof(CloseTabItemAction), new PropertyMetadata(null));
	}
}
