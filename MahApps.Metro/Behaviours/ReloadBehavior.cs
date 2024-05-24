using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B8 RID: 184
	public static class ReloadBehavior
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x00026E5B File Offset: 0x0002505B
		[Category("MahApps.Metro")]
		public static bool GetOnDataContextChanged(MetroContentControl element)
		{
			return (bool)element.GetValue(ReloadBehavior.OnDataContextChangedProperty);
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00026E6D File Offset: 0x0002506D
		[Category("MahApps.Metro")]
		public static void SetOnDataContextChanged(MetroContentControl element, bool value)
		{
			element.SetValue(ReloadBehavior.OnDataContextChangedProperty, value);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00026E80 File Offset: 0x00025080
		private static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((MetroContentControl)d).DataContextChanged -= ReloadBehavior.ReloadDataContextChanged;
			((MetroContentControl)d).DataContextChanged += ReloadBehavior.ReloadDataContextChanged;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00026EB0 File Offset: 0x000250B0
		private static void ReloadDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			((MetroContentControl)sender).Reload();
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00026EBD File Offset: 0x000250BD
		[Category("MahApps.Metro")]
		public static bool GetOnSelectedTabChanged(ContentControl element)
		{
			return (bool)element.GetValue(ReloadBehavior.OnSelectedTabChangedProperty);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00026ECF File Offset: 0x000250CF
		[Category("MahApps.Metro")]
		public static void SetOnSelectedTabChanged(ContentControl element, bool value)
		{
			element.SetValue(ReloadBehavior.OnSelectedTabChangedProperty, value);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00026EE2 File Offset: 0x000250E2
		private static void OnSelectedTabChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ContentControl)d).Loaded -= ReloadBehavior.ReloadLoaded;
			((ContentControl)d).Loaded += ReloadBehavior.ReloadLoaded;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00026F14 File Offset: 0x00025114
		private static void ReloadLoaded(object sender, RoutedEventArgs e)
		{
			ContentControl contentControl = (ContentControl)sender;
			TabControl tabControl = contentControl.TryFindParent<TabControl>();
			if (tabControl == null)
			{
				return;
			}
			ReloadBehavior.SetMetroContentControl(tabControl, contentControl);
			tabControl.SelectionChanged -= ReloadBehavior.ReloadSelectionChanged;
			tabControl.SelectionChanged += ReloadBehavior.ReloadSelectionChanged;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00026F5E File Offset: 0x0002515E
		private static void ReloadSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.OriginalSource != sender)
			{
				return;
			}
			ContentControl metroContentControl = ReloadBehavior.GetMetroContentControl((TabControl)sender);
			MetroContentControl metroContentControl2 = metroContentControl as MetroContentControl;
			if (metroContentControl2 != null)
			{
				metroContentControl2.Reload();
			}
			TransitioningContentControl transitioningContentControl = metroContentControl as TransitioningContentControl;
			if (transitioningContentControl == null)
			{
				return;
			}
			transitioningContentControl.ReloadTransition();
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00026F95 File Offset: 0x00025195
		[Category("MahApps.Metro")]
		public static void SetMetroContentControl(UIElement element, ContentControl value)
		{
			element.SetValue(ReloadBehavior.MetroContentControlProperty, value);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00026FA3 File Offset: 0x000251A3
		[Category("MahApps.Metro")]
		public static ContentControl GetMetroContentControl(UIElement element)
		{
			return (ContentControl)element.GetValue(ReloadBehavior.MetroContentControlProperty);
		}

		// Token: 0x0400046A RID: 1130
		public static readonly DependencyProperty OnDataContextChangedProperty = DependencyProperty.RegisterAttached("OnDataContextChanged", typeof(bool), typeof(ReloadBehavior), new PropertyMetadata(new PropertyChangedCallback(ReloadBehavior.OnDataContextChanged)));

		// Token: 0x0400046B RID: 1131
		public static readonly DependencyProperty OnSelectedTabChangedProperty = DependencyProperty.RegisterAttached("OnSelectedTabChanged", typeof(bool), typeof(ReloadBehavior), new PropertyMetadata(new PropertyChangedCallback(ReloadBehavior.OnSelectedTabChanged)));

		// Token: 0x0400046C RID: 1132
		public static readonly DependencyProperty MetroContentControlProperty = DependencyProperty.RegisterAttached("MetroContentControl", typeof(ContentControl), typeof(ReloadBehavior), new PropertyMetadata(null));
	}
}
