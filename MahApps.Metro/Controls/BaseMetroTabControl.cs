using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000064 RID: 100
	public abstract class BaseMetroTabControl : TabControl
	{
		// Token: 0x0600045E RID: 1118 RVA: 0x00011181 File Offset: 0x0000F381
		public BaseMetroTabControl()
		{
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x00011189 File Offset: 0x0000F389
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x0001119B File Offset: 0x0000F39B
		public Thickness TabStripMargin
		{
			get
			{
				return (Thickness)base.GetValue(BaseMetroTabControl.TabStripMarginProperty);
			}
			set
			{
				base.SetValue(BaseMetroTabControl.TabStripMarginProperty, value);
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000111AE File Offset: 0x0000F3AE
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is TabItem;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000111B9 File Offset: 0x0000F3B9
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new MetroTabItem();
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000111C0 File Offset: 0x0000F3C0
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			if (element != item)
			{
				element.SetValue(FrameworkElement.DataContextProperty, item);
			}
			base.PrepareContainerForItemOverride(element, item);
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x000111DA File Offset: 0x0000F3DA
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x000111EC File Offset: 0x0000F3EC
		public ICommand CloseTabCommand
		{
			get
			{
				return (ICommand)base.GetValue(BaseMetroTabControl.CloseTabCommandProperty);
			}
			set
			{
				base.SetValue(BaseMetroTabControl.CloseTabCommandProperty, value);
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000466 RID: 1126 RVA: 0x000111FC File Offset: 0x0000F3FC
		// (remove) Token: 0x06000467 RID: 1127 RVA: 0x00011234 File Offset: 0x0000F434
		public event BaseMetroTabControl.TabItemClosingEventHandler TabItemClosingEvent;

		// Token: 0x06000468 RID: 1128 RVA: 0x0001126C File Offset: 0x0000F46C
		internal bool RaiseTabItemClosingEvent(MetroTabItem closingItem)
		{
			BaseMetroTabControl.TabItemClosingEventHandler tabItemClosingEvent = this.TabItemClosingEvent;
			if (tabItemClosingEvent != null)
			{
				foreach (BaseMetroTabControl.TabItemClosingEventHandler tabItemClosingEventHandler in tabItemClosingEvent.GetInvocationList().OfType<BaseMetroTabControl.TabItemClosingEventHandler>())
				{
					BaseMetroTabControl.TabItemClosingEventArgs tabItemClosingEventArgs = new BaseMetroTabControl.TabItemClosingEventArgs(closingItem);
					tabItemClosingEventHandler(this, tabItemClosingEventArgs);
					if (tabItemClosingEventArgs.Cancel)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000112E0 File Offset: 0x0000F4E0
		internal void CloseThisTabItem(MetroTabItem tabItem)
		{
			if (tabItem == null)
			{
				throw new ArgumentNullException("tabItem");
			}
			if (this.CloseTabCommand != null)
			{
				object parameter = tabItem.CloseTabCommandParameter ?? tabItem;
				if (this.CloseTabCommand.CanExecute(parameter))
				{
					this.CloseTabCommand.Execute(parameter);
					return;
				}
			}
			else
			{
				if (this.RaiseTabItemClosingEvent(tabItem))
				{
					return;
				}
				if (base.ItemsSource == null)
				{
					tabItem.ClearStyle();
					base.Items.Remove(tabItem);
					return;
				}
				IList list = base.ItemsSource as IList;
				if (list == null)
				{
					return;
				}
				object obj = list.OfType<object>().FirstOrDefault((object item) => tabItem == item || tabItem.DataContext == item);
				if (obj != null)
				{
					tabItem.ClearStyle();
					list.Remove(obj);
				}
			}
		}

		// Token: 0x040001A2 RID: 418
		public static readonly DependencyProperty TabStripMarginProperty = DependencyProperty.Register("TabStripMargin", typeof(Thickness), typeof(BaseMetroTabControl), new PropertyMetadata(new Thickness(0.0)));

		// Token: 0x040001A3 RID: 419
		public static readonly DependencyProperty CloseTabCommandProperty = DependencyProperty.Register("CloseTabCommand", typeof(ICommand), typeof(BaseMetroTabControl), new PropertyMetadata(null));

		// Token: 0x020000EB RID: 235
		// (Invoke) Token: 0x06000AE0 RID: 2784
		public delegate void TabItemClosingEventHandler(object sender, BaseMetroTabControl.TabItemClosingEventArgs e);

		// Token: 0x020000EC RID: 236
		public class TabItemClosingEventArgs : CancelEventArgs
		{
			// Token: 0x06000AE3 RID: 2787 RVA: 0x00029708 File Offset: 0x00027908
			internal TabItemClosingEventArgs(MetroTabItem item)
			{
				this.ClosingTabItem = item;
			}

			// Token: 0x17000216 RID: 534
			// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00029717 File Offset: 0x00027917
			// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x0002971F File Offset: 0x0002791F
			public MetroTabItem ClosingTabItem { get; private set; }
		}
	}
}
