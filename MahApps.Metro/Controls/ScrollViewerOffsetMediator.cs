using System;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000081 RID: 129
	public class ScrollViewerOffsetMediator : FrameworkElement
	{
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0001C0A1 File Offset: 0x0001A2A1
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0001C0B3 File Offset: 0x0001A2B3
		public ScrollViewer ScrollViewer
		{
			get
			{
				return (ScrollViewer)base.GetValue(ScrollViewerOffsetMediator.ScrollViewerProperty);
			}
			set
			{
				base.SetValue(ScrollViewerOffsetMediator.ScrollViewerProperty, value);
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0001C0C1 File Offset: 0x0001A2C1
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0001C0D3 File Offset: 0x0001A2D3
		public double HorizontalOffset
		{
			get
			{
				return (double)base.GetValue(ScrollViewerOffsetMediator.HorizontalOffsetProperty);
			}
			set
			{
				base.SetValue(ScrollViewerOffsetMediator.HorizontalOffsetProperty, value);
			}
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001C0E8 File Offset: 0x0001A2E8
		private static void OnScrollViewerChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewerOffsetMediator scrollViewerOffsetMediator = (ScrollViewerOffsetMediator)o;
			ScrollViewer scrollViewer = (ScrollViewer)e.NewValue;
			if (scrollViewer != null)
			{
				scrollViewer.ScrollToHorizontalOffset(scrollViewerOffsetMediator.HorizontalOffset);
			}
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0001C118 File Offset: 0x0001A318
		private static void OnHorizontalOffsetChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewerOffsetMediator scrollViewerOffsetMediator = (ScrollViewerOffsetMediator)o;
			if (scrollViewerOffsetMediator.ScrollViewer != null)
			{
				scrollViewerOffsetMediator.ScrollViewer.ScrollToHorizontalOffset((double)e.NewValue);
			}
		}

		// Token: 0x040002B8 RID: 696
		public static readonly DependencyProperty ScrollViewerProperty = DependencyProperty.Register("ScrollViewer", typeof(ScrollViewer), typeof(ScrollViewerOffsetMediator), new PropertyMetadata(null, new PropertyChangedCallback(ScrollViewerOffsetMediator.OnScrollViewerChanged)));

		// Token: 0x040002B9 RID: 697
		public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(ScrollViewerOffsetMediator), new PropertyMetadata(0.0, new PropertyChangedCallback(ScrollViewerOffsetMediator.OnHorizontalOffsetChanged)));
	}
}
