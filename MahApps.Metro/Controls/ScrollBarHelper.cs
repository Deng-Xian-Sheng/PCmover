using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200004E RID: 78
	[Obsolete("This helper class will be deleted in the next release. Instead use the ScrollViewerHelper.")]
	public static class ScrollBarHelper
	{
		// Token: 0x06000336 RID: 822 RVA: 0x0000D2A5 File Offset: 0x0000B4A5
		[Obsolete("This attached property will be deleted in the next release. Instead use ScrollViewerHelper.VerticalScrollBarOnLeftSide attached property.")]
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ScrollViewer))]
		public static bool GetVerticalScrollBarOnLeftSide(ScrollViewer obj)
		{
			return (bool)obj.GetValue(ScrollBarHelper.VerticalScrollBarOnLeftSideProperty);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000D2B7 File Offset: 0x0000B4B7
		[Obsolete("This attached property will be deleted in the next release. Instead use ScrollViewerHelper.VerticalScrollBarOnLeftSide attached property.")]
		public static void SetVerticalScrollBarOnLeftSide(ScrollViewer obj, bool value)
		{
			obj.SetValue(ScrollBarHelper.VerticalScrollBarOnLeftSideProperty, value);
		}

		// Token: 0x04000139 RID: 313
		[Obsolete("This attached property will be deleted in the next release. Instead use ScrollViewerHelper.VerticalScrollBarOnLeftSide attached property.")]
		public static readonly DependencyProperty VerticalScrollBarOnLeftSideProperty = DependencyProperty.RegisterAttached("VerticalScrollBarOnLeftSide", typeof(bool), typeof(ScrollBarHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer scrollViewer = o as ScrollViewer;
			if (scrollViewer != null && e.OldValue != e.NewValue && e.NewValue is bool)
			{
				ScrollViewerHelper.SetVerticalScrollBarOnLeftSide(scrollViewer, (bool)e.NewValue);
			}
		}));
	}
}
