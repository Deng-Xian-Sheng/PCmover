using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200004A RID: 74
	public static class ItemHelper
	{
		// Token: 0x06000313 RID: 787 RVA: 0x0000CD30 File Offset: 0x0000AF30
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetActiveSelectionBackgroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.ActiveSelectionBackgroundBrushProperty);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000CD42 File Offset: 0x0000AF42
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetActiveSelectionBackgroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.ActiveSelectionBackgroundBrushProperty, value);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000CD50 File Offset: 0x0000AF50
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetActiveSelectionForegroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.ActiveSelectionForegroundBrushProperty);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000CD62 File Offset: 0x0000AF62
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetActiveSelectionForegroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.ActiveSelectionForegroundBrushProperty, value);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000CD70 File Offset: 0x0000AF70
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetSelectedBackgroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.SelectedBackgroundBrushProperty);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000CD82 File Offset: 0x0000AF82
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetSelectedBackgroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.SelectedBackgroundBrushProperty, value);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000CD90 File Offset: 0x0000AF90
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetSelectedForegroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.SelectedForegroundBrushProperty);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000CDA2 File Offset: 0x0000AFA2
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetSelectedForegroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.SelectedForegroundBrushProperty, value);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000CDB0 File Offset: 0x0000AFB0
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetHoverBackgroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.HoverBackgroundBrushProperty);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000CDC2 File Offset: 0x0000AFC2
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetHoverBackgroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.HoverBackgroundBrushProperty, value);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetHoverSelectedBackgroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.HoverSelectedBackgroundBrushProperty);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000CDE2 File Offset: 0x0000AFE2
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetHoverSelectedBackgroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.HoverSelectedBackgroundBrushProperty, value);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000CDF0 File Offset: 0x0000AFF0
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetDisabledSelectedBackgroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.DisabledSelectedBackgroundBrushProperty);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000CE02 File Offset: 0x0000B002
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetDisabledSelectedBackgroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.DisabledSelectedBackgroundBrushProperty, value);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000CE10 File Offset: 0x0000B010
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetDisabledSelectedForegroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.DisabledSelectedForegroundBrushProperty);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000CE22 File Offset: 0x0000B022
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetDisabledSelectedForegroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.DisabledSelectedForegroundBrushProperty, value);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000CE30 File Offset: 0x0000B030
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetDisabledBackgroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.DisabledBackgroundBrushProperty);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000CE42 File Offset: 0x0000B042
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetDisabledBackgroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.DisabledBackgroundBrushProperty, value);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000CE50 File Offset: 0x0000B050
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static Brush GetDisabledForegroundBrush(UIElement element)
		{
			return (Brush)element.GetValue(ItemHelper.DisabledForegroundBrushProperty);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000CE62 File Offset: 0x0000B062
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ListBoxItem))]
		[AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
		public static void SetDisabledForegroundBrush(UIElement element, Brush value)
		{
			element.SetValue(ItemHelper.DisabledForegroundBrushProperty, value);
		}

		// Token: 0x04000124 RID: 292
		public static readonly DependencyProperty ActiveSelectionBackgroundBrushProperty = DependencyProperty.RegisterAttached("ActiveSelectionBackgroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000125 RID: 293
		public static readonly DependencyProperty ActiveSelectionForegroundBrushProperty = DependencyProperty.RegisterAttached("ActiveSelectionForegroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000126 RID: 294
		public static readonly DependencyProperty SelectedBackgroundBrushProperty = DependencyProperty.RegisterAttached("SelectedBackgroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000127 RID: 295
		public static readonly DependencyProperty SelectedForegroundBrushProperty = DependencyProperty.RegisterAttached("SelectedForegroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000128 RID: 296
		public static readonly DependencyProperty HoverBackgroundBrushProperty = DependencyProperty.RegisterAttached("HoverBackgroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000129 RID: 297
		public static readonly DependencyProperty HoverSelectedBackgroundBrushProperty = DependencyProperty.RegisterAttached("HoverSelectedBackgroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400012A RID: 298
		public static readonly DependencyProperty DisabledSelectedBackgroundBrushProperty = DependencyProperty.RegisterAttached("DisabledSelectedBackgroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400012B RID: 299
		public static readonly DependencyProperty DisabledSelectedForegroundBrushProperty = DependencyProperty.RegisterAttached("DisabledSelectedForegroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400012C RID: 300
		public static readonly DependencyProperty DisabledBackgroundBrushProperty = DependencyProperty.RegisterAttached("DisabledBackgroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400012D RID: 301
		public static readonly DependencyProperty DisabledForegroundBrushProperty = DependencyProperty.RegisterAttached("DisabledForegroundBrush", typeof(Brush), typeof(ItemHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));
	}
}
