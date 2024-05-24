using System;
using System.ComponentModel;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000057 RID: 87
	public static class VisibilityHelper
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x0000F344 File Offset: 0x0000D544
		private static void IsVisibleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = d as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			frameworkElement.Visibility = (((bool?)e.NewValue == true) ? Visibility.Visible : Visibility.Collapsed);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000F38B File Offset: 0x0000D58B
		public static void SetIsVisible(DependencyObject element, bool? value)
		{
			element.SetValue(VisibilityHelper.IsVisibleProperty, value);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000F39E File Offset: 0x0000D59E
		[Category("MahApps.Metro")]
		public static bool? GetIsVisible(DependencyObject element)
		{
			return (bool?)element.GetValue(VisibilityHelper.IsVisibleProperty);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000F3B0 File Offset: 0x0000D5B0
		private static void IsCollapsedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = d as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			frameworkElement.Visibility = (((bool?)e.NewValue == true) ? Visibility.Collapsed : Visibility.Visible);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000F3F7 File Offset: 0x0000D5F7
		public static void SetIsCollapsed(DependencyObject element, bool? value)
		{
			element.SetValue(VisibilityHelper.IsCollapsedProperty, value);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000F40A File Offset: 0x0000D60A
		[Category("MahApps.Metro")]
		public static bool? GetIsCollapsed(DependencyObject element)
		{
			return (bool?)element.GetValue(VisibilityHelper.IsCollapsedProperty);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000F41C File Offset: 0x0000D61C
		private static void IsHiddenChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = d as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			frameworkElement.Visibility = (((bool?)e.NewValue == true) ? Visibility.Hidden : Visibility.Visible);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000F463 File Offset: 0x0000D663
		public static void SetIsHidden(DependencyObject element, bool? value)
		{
			element.SetValue(VisibilityHelper.IsHiddenProperty, value);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000F476 File Offset: 0x0000D676
		[Category("MahApps.Metro")]
		public static bool? GetIsHidden(DependencyObject element)
		{
			return (bool?)element.GetValue(VisibilityHelper.IsHiddenProperty);
		}

		// Token: 0x0400017C RID: 380
		public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.RegisterAttached("IsVisible", typeof(bool?), typeof(VisibilityHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(VisibilityHelper.IsVisibleChangedCallback)));

		// Token: 0x0400017D RID: 381
		public static readonly DependencyProperty IsCollapsedProperty = DependencyProperty.RegisterAttached("IsCollapsed", typeof(bool?), typeof(VisibilityHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(VisibilityHelper.IsCollapsedChangedCallback)));

		// Token: 0x0400017E RID: 382
		public static readonly DependencyProperty IsHiddenProperty = DependencyProperty.RegisterAttached("IsHidden", typeof(bool?), typeof(VisibilityHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(VisibilityHelper.IsHiddenChangedCallback)));
	}
}
