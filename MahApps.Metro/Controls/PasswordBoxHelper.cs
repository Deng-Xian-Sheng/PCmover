using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200004D RID: 77
	public class PasswordBoxHelper
	{
		// Token: 0x06000328 RID: 808 RVA: 0x0000D02B File Offset: 0x0000B22B
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static object GetCapsLockIcon(PasswordBox element)
		{
			return element.GetValue(PasswordBoxHelper.CapsLockIconProperty);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000D038 File Offset: 0x0000B238
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static void SetCapsLockIcon(PasswordBox element, object value)
		{
			element.SetValue(PasswordBoxHelper.CapsLockIconProperty, value);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000D048 File Offset: 0x0000B248
		private static void ShowCapslockWarningChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue != e.OldValue)
			{
				PasswordBox passwordBox = (PasswordBox)d;
				passwordBox.KeyDown -= new KeyEventHandler(PasswordBoxHelper.RefreshCapslockStatus);
				passwordBox.GotFocus -= PasswordBoxHelper.RefreshCapslockStatus;
				passwordBox.PreviewGotKeyboardFocus -= new KeyboardFocusChangedEventHandler(PasswordBoxHelper.RefreshCapslockStatus);
				passwordBox.LostFocus -= PasswordBoxHelper.HandlePasswordBoxLostFocus;
				if (e.NewValue != null)
				{
					passwordBox.KeyDown += new KeyEventHandler(PasswordBoxHelper.RefreshCapslockStatus);
					passwordBox.GotFocus += PasswordBoxHelper.RefreshCapslockStatus;
					passwordBox.PreviewGotKeyboardFocus += new KeyboardFocusChangedEventHandler(PasswordBoxHelper.RefreshCapslockStatus);
					passwordBox.LostFocus += PasswordBoxHelper.HandlePasswordBoxLostFocus;
				}
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000D108 File Offset: 0x0000B308
		private static void RefreshCapslockStatus(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = PasswordBoxHelper.FindCapsLockIndicator((Control)sender);
			if (frameworkElement != null)
			{
				frameworkElement.Visibility = (Keyboard.IsKeyToggled(Key.Capital) ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000D138 File Offset: 0x0000B338
		private static void HandlePasswordBoxLostFocus(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = PasswordBoxHelper.FindCapsLockIndicator((Control)sender);
			if (frameworkElement != null)
			{
				frameworkElement.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000D15B File Offset: 0x0000B35B
		private static FrameworkElement FindCapsLockIndicator(Control pb)
		{
			object obj;
			if (pb == null)
			{
				obj = null;
			}
			else
			{
				ControlTemplate template = pb.Template;
				obj = ((template != null) ? template.FindName("PART_CapsLockIndicator", pb) : null);
			}
			return obj as FrameworkElement;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000D180 File Offset: 0x0000B380
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static object GetCapsLockWarningToolTip(PasswordBox element)
		{
			return element.GetValue(PasswordBoxHelper.CapsLockWarningToolTipProperty);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000D18D File Offset: 0x0000B38D
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static void SetCapsLockWarningToolTip(PasswordBox element, object value)
		{
			element.SetValue(PasswordBoxHelper.CapsLockWarningToolTipProperty, value);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000D19B File Offset: 0x0000B39B
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static object GetRevealButtonContent(DependencyObject d)
		{
			return d.GetValue(PasswordBoxHelper.RevealButtonContentProperty);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000D1A8 File Offset: 0x0000B3A8
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static void SetRevealButtonContent(DependencyObject obj, object value)
		{
			obj.SetValue(PasswordBoxHelper.RevealButtonContentProperty, value);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000D1B6 File Offset: 0x0000B3B6
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static DataTemplate GetRevealButtonContentTemplate(DependencyObject d)
		{
			return (DataTemplate)d.GetValue(PasswordBoxHelper.RevealButtonContentTemplateProperty);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000D1C8 File Offset: 0x0000B3C8
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static void SetRevealButtonContentTemplate(DependencyObject obj, DataTemplate value)
		{
			obj.SetValue(PasswordBoxHelper.RevealButtonContentTemplateProperty, value);
		}

		// Token: 0x04000135 RID: 309
		public static readonly DependencyProperty CapsLockIconProperty = DependencyProperty.RegisterAttached("CapsLockIcon", typeof(object), typeof(PasswordBoxHelper), new PropertyMetadata("!", new PropertyChangedCallback(PasswordBoxHelper.ShowCapslockWarningChanged)));

		// Token: 0x04000136 RID: 310
		public static readonly DependencyProperty CapsLockWarningToolTipProperty = DependencyProperty.RegisterAttached("CapsLockWarningToolTip", typeof(object), typeof(PasswordBoxHelper), new PropertyMetadata("Caps lock is on"));

		// Token: 0x04000137 RID: 311
		public static readonly DependencyProperty RevealButtonContentProperty = DependencyProperty.RegisterAttached("RevealButtonContent", typeof(object), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(null));

		// Token: 0x04000138 RID: 312
		public static readonly DependencyProperty RevealButtonContentTemplateProperty = DependencyProperty.RegisterAttached("RevealButtonContentTemplate", typeof(DataTemplate), typeof(PasswordBoxHelper), new FrameworkPropertyMetadata(null));
	}
}
