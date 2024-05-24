using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200004F RID: 79
	public static class ScrollViewerHelper
	{
		// Token: 0x06000339 RID: 825 RVA: 0x0000D319 File Offset: 0x0000B519
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ScrollViewer))]
		public static bool GetVerticalScrollBarOnLeftSide(UIElement element)
		{
			return (bool)element.GetValue(ScrollViewerHelper.VerticalScrollBarOnLeftSideProperty);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000D32B File Offset: 0x0000B52B
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ScrollViewer))]
		public static void SetVerticalScrollBarOnLeftSide(UIElement element, bool value)
		{
			element.SetValue(ScrollViewerHelper.VerticalScrollBarOnLeftSideProperty, value);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000D340 File Offset: 0x0000B540
		private static void OnIsHorizontalScrollWheelEnabledPropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer scrollViewer = o as ScrollViewer;
			if (scrollViewer != null && e.NewValue != e.OldValue && e.NewValue is bool)
			{
				scrollViewer.PreviewMouseWheel -= ScrollViewerHelper.ScrollViewerOnPreviewMouseWheel;
				if ((bool)e.NewValue)
				{
					scrollViewer.PreviewMouseWheel += ScrollViewerHelper.ScrollViewerOnPreviewMouseWheel;
				}
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000D3A8 File Offset: 0x0000B5A8
		private static void ScrollViewerOnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer scrollViewer = sender as ScrollViewer;
			if (scrollViewer != null && scrollViewer.HorizontalScrollBarVisibility != ScrollBarVisibility.Disabled)
			{
				if (e.Delta > 0)
				{
					scrollViewer.LineLeft();
				}
				else
				{
					scrollViewer.LineRight();
				}
				e.Handled = true;
			}
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000D3E5 File Offset: 0x0000B5E5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(UIElement))]
		public static bool GetIsHorizontalScrollWheelEnabled(UIElement element)
		{
			return (bool)element.GetValue(ScrollViewerHelper.IsHorizontalScrollWheelEnabledProperty);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000D3F7 File Offset: 0x0000B5F7
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(UIElement))]
		public static void SetIsHorizontalScrollWheelEnabled(UIElement element, bool value)
		{
			element.SetValue(ScrollViewerHelper.IsHorizontalScrollWheelEnabledProperty, value);
		}

		// Token: 0x0400013A RID: 314
		public static readonly DependencyProperty VerticalScrollBarOnLeftSideProperty = DependencyProperty.RegisterAttached("VerticalScrollBarOnLeftSide", typeof(bool), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400013B RID: 315
		public static readonly DependencyProperty IsHorizontalScrollWheelEnabledProperty = DependencyProperty.RegisterAttached("IsHorizontalScrollWheelEnabled", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(false, new PropertyChangedCallback(ScrollViewerHelper.OnIsHorizontalScrollWheelEnabledPropertyChangedCallback)));
	}
}
