using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000073 RID: 115
	[TemplatePart(Name = "PART_Scroll", Type = typeof(ScrollViewer))]
	[TemplatePart(Name = "PART_Headers", Type = typeof(ListView))]
	[TemplatePart(Name = "PART_Mediator", Type = typeof(ScrollViewerOffsetMediator))]
	public class Pivot : ItemsControl
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00016A1C File Offset: 0x00014C1C
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x00016A2E File Offset: 0x00014C2E
		public DataTemplate HeaderTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(Pivot.HeaderTemplateProperty);
			}
			set
			{
				base.SetValue(Pivot.HeaderTemplateProperty, value);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00016A3C File Offset: 0x00014C3C
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x00016A4E File Offset: 0x00014C4E
		public string Header
		{
			get
			{
				return (string)base.GetValue(Pivot.HeaderProperty);
			}
			set
			{
				base.SetValue(Pivot.HeaderProperty, value);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x00016A5C File Offset: 0x00014C5C
		// (set) Token: 0x060005C8 RID: 1480 RVA: 0x00016A6E File Offset: 0x00014C6E
		public int SelectedIndex
		{
			get
			{
				return (int)base.GetValue(Pivot.SelectedIndexProperty);
			}
			set
			{
				base.SetValue(Pivot.SelectedIndexProperty, value);
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060005C9 RID: 1481 RVA: 0x00016A81 File Offset: 0x00014C81
		// (remove) Token: 0x060005CA RID: 1482 RVA: 0x00016A8F File Offset: 0x00014C8F
		public event RoutedEventHandler SelectionChanged
		{
			add
			{
				base.AddHandler(Pivot.SelectionChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(Pivot.SelectionChangedEvent, value);
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00016AA0 File Offset: 0x00014CA0
		public void GoToItem(PivotItem item)
		{
			if (item == null || item == this.selectedItem)
			{
				return;
			}
			double num = 0.0;
			for (int i = 0; i < base.Items.Count; i++)
			{
				if (base.Items[i] == item)
				{
					this.internalIndex = i;
					break;
				}
				num += ((PivotItem)base.Items[i]).ActualWidth;
			}
			this.mediator.HorizontalOffset = this.scroller.HorizontalOffset;
			Storyboard storyboard = this.mediator.Resources["Storyboard1"] as Storyboard;
			((EasingDoubleKeyFrame)this.mediator.FindName("edkf")).Value = num;
			storyboard.Completed -= this.sb_Completed;
			storyboard.Completed += this.sb_Completed;
			storyboard.Begin();
			base.RaiseEvent(new RoutedEventArgs(Pivot.SelectionChangedEvent));
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00016B8F File Offset: 0x00014D8F
		private void sb_Completed(object sender, EventArgs e)
		{
			this.SelectedIndex = this.internalIndex;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00016BA0 File Offset: 0x00014DA0
		static Pivot()
		{
			Pivot.SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Pivot));
			Pivot.HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(Pivot), new PropertyMetadata(null));
			Pivot.HeaderTemplateProperty = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(Pivot));
			Pivot.SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(Pivot), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Pivot.SelectedItemChanged)));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Pivot), new FrameworkPropertyMetadata(typeof(Pivot)));
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00016C80 File Offset: 0x00014E80
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.scroller = (ScrollViewer)base.GetTemplateChild("PART_Scroll");
			this.headers = (ListView)base.GetTemplateChild("PART_Headers");
			this.mediator = (base.GetTemplateChild("PART_Mediator") as ScrollViewerOffsetMediator);
			if (this.scroller != null)
			{
				this.scroller.ScrollChanged += this.scroller_ScrollChanged;
				this.scroller.PreviewMouseWheel += this.scroller_MouseWheel;
			}
			if (this.headers != null)
			{
				this.headers.SelectionChanged += this.headers_SelectionChanged;
			}
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00016D2A File Offset: 0x00014F2A
		private void scroller_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			this.scroller.ScrollToHorizontalOffset(this.scroller.HorizontalOffset + (double)(-(double)e.Delta));
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00016D4B File Offset: 0x00014F4B
		private void headers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.GoToItem((PivotItem)this.headers.SelectedItem);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00016D64 File Offset: 0x00014F64
		private void scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			double num = 0.0;
			int i = 0;
			while (i < base.Items.Count)
			{
				PivotItem pivotItem = (PivotItem)base.Items[i];
				double actualWidth = pivotItem.ActualWidth;
				if (e.HorizontalOffset <= num + actualWidth - 1.0)
				{
					this.selectedItem = pivotItem;
					if (this.headers.SelectedItem != this.selectedItem)
					{
						this.headers.SelectedItem = this.selectedItem;
						this.internalIndex = i;
						this.SelectedIndex = i;
						base.RaiseEvent(new RoutedEventArgs(Pivot.SelectionChangedEvent));
						return;
					}
					break;
				}
				else
				{
					num += actualWidth;
					i++;
				}
			}
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00016E14 File Offset: 0x00015014
		private static void SelectedItemChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue != e.OldValue)
			{
				Pivot pivot = (Pivot)dependencyObject;
				int num = (int)e.NewValue;
				if (pivot.internalIndex != pivot.SelectedIndex && num >= 0 && num < pivot.Items.Count)
				{
					PivotItem item = (PivotItem)pivot.Items[num];
					pivot.headers.SelectedItem = item;
					pivot.GoToItem(item);
				}
			}
		}

		// Token: 0x0400023D RID: 573
		private ScrollViewer scroller;

		// Token: 0x0400023E RID: 574
		private ListView headers;

		// Token: 0x0400023F RID: 575
		private PivotItem selectedItem;

		// Token: 0x04000240 RID: 576
		private ScrollViewerOffsetMediator mediator;

		// Token: 0x04000241 RID: 577
		internal int internalIndex;

		// Token: 0x04000243 RID: 579
		public static readonly DependencyProperty HeaderProperty;

		// Token: 0x04000244 RID: 580
		public static readonly DependencyProperty HeaderTemplateProperty;

		// Token: 0x04000245 RID: 581
		public static readonly DependencyProperty SelectedIndexProperty;
	}
}
