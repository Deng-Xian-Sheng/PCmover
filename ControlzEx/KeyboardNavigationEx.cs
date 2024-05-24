using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ControlzEx
{
	// Token: 0x02000005 RID: 5
	public sealed class KeyboardNavigationEx
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002428 File Offset: 0x00000628
		private KeyboardNavigationEx()
		{
			Type typeFromHandle = typeof(KeyboardNavigation);
			this._alwaysShowFocusVisual = typeFromHandle.GetProperty("AlwaysShowFocusVisual", BindingFlags.Static | BindingFlags.NonPublic);
			this._showFocusVisual = typeFromHandle.GetMethod("ShowFocusVisual", BindingFlags.Static | BindingFlags.NonPublic);
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000246C File Offset: 0x0000066C
		internal static KeyboardNavigationEx Instance
		{
			get
			{
				KeyboardNavigationEx result;
				if ((result = KeyboardNavigationEx._instance) == null)
				{
					result = (KeyboardNavigationEx._instance = new KeyboardNavigationEx());
				}
				return result;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002482 File Offset: 0x00000682
		internal void ShowFocusVisualInternal()
		{
			this._showFocusVisual.Invoke(null, null);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002492 File Offset: 0x00000692
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000024A6 File Offset: 0x000006A6
		internal bool AlwaysShowFocusVisualInternal
		{
			get
			{
				return (bool)this._alwaysShowFocusVisual.GetValue(null, null);
			}
			set
			{
				this._alwaysShowFocusVisual.SetValue(null, value, null);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024BC File Offset: 0x000006BC
		public static void Focus(UIElement element)
		{
			UIElement element2 = element;
			if (element2 == null)
			{
				return;
			}
			element2.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate()
			{
				KeyboardNavigationEx instance = KeyboardNavigationEx.Instance;
				bool alwaysShowFocusVisualInternal = instance.AlwaysShowFocusVisualInternal;
				instance.AlwaysShowFocusVisualInternal = true;
				try
				{
					Keyboard.Focus(element);
					instance.ShowFocusVisualInternal();
				}
				finally
				{
					instance.AlwaysShowFocusVisualInternal = alwaysShowFocusVisualInternal;
				}
			}));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024FC File Offset: 0x000006FC
		private static void AlwaysShowFocusVisualPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			UIElement uielement = dependencyObject as UIElement;
			if (uielement != null && args.NewValue != args.OldValue)
			{
				uielement.GotFocus -= KeyboardNavigationEx.FrameworkElementGotFocus;
				if ((bool)args.NewValue)
				{
					uielement.GotFocus += KeyboardNavigationEx.FrameworkElementGotFocus;
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002555 File Offset: 0x00000755
		private static void FrameworkElementGotFocus(object sender, RoutedEventArgs e)
		{
			KeyboardNavigationEx.Focus(sender as UIElement);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002562 File Offset: 0x00000762
		[AttachedPropertyBrowsableForType(typeof(UIElement))]
		public static bool GetAlwaysShowFocusVisual(UIElement element)
		{
			return (bool)element.GetValue(KeyboardNavigationEx.AlwaysShowFocusVisualProperty);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002574 File Offset: 0x00000774
		public static void SetAlwaysShowFocusVisual(UIElement element, bool value)
		{
			element.SetValue(KeyboardNavigationEx.AlwaysShowFocusVisualProperty, value);
		}

		// Token: 0x04000015 RID: 21
		private static KeyboardNavigationEx _instance;

		// Token: 0x04000016 RID: 22
		private readonly PropertyInfo _alwaysShowFocusVisual;

		// Token: 0x04000017 RID: 23
		private readonly MethodInfo _showFocusVisual;

		// Token: 0x04000018 RID: 24
		public static readonly DependencyProperty AlwaysShowFocusVisualProperty = DependencyProperty.RegisterAttached("AlwaysShowFocusVisual", typeof(bool), typeof(KeyboardNavigationEx), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(KeyboardNavigationEx.AlwaysShowFocusVisualPropertyChangedCallback)));
	}
}
