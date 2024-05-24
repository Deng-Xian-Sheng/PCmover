using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000058 RID: 88
	[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
	public class HotKeyBox : Control
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000F53A File Offset: 0x0000D73A
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000F54C File Offset: 0x0000D74C
		public HotKey HotKey
		{
			get
			{
				return (HotKey)base.GetValue(HotKeyBox.HotKeyProperty);
			}
			set
			{
				base.SetValue(HotKeyBox.HotKeyProperty, value);
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000F55A File Offset: 0x0000D75A
		private static void OnHotKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((HotKeyBox)d).UpdateText();
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x0000F567 File Offset: 0x0000D767
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x0000F579 File Offset: 0x0000D779
		public bool AreModifierKeysRequired
		{
			get
			{
				return (bool)base.GetValue(HotKeyBox.AreModifierKeysRequiredProperty);
			}
			set
			{
				base.SetValue(HotKeyBox.AreModifierKeysRequiredProperty, value);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0000F58C File Offset: 0x0000D78C
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0000F59E File Offset: 0x0000D79E
		[Obsolete("This property will be deleted in the next release. Instead use TextBoxHelper.Watermark attached property.")]
		public string Watermark
		{
			get
			{
				return (string)base.GetValue(HotKeyBox.WatermarkProperty);
			}
			set
			{
				base.SetValue(HotKeyBox.WatermarkProperty, value);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0000F5AC File Offset: 0x0000D7AC
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x0000F5BE File Offset: 0x0000D7BE
		public string Text
		{
			get
			{
				return (string)base.GetValue(HotKeyBox.TextProperty);
			}
			private set
			{
				base.SetValue(HotKeyBox.TextPropertyKey, value);
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000F5CC File Offset: 0x0000D7CC
		static HotKeyBox()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(HotKeyBox), new FrameworkPropertyMetadata(typeof(HotKeyBox)));
			EventManager.RegisterClassHandler(typeof(HotKeyBox), UIElement.GotFocusEvent, new RoutedEventHandler(HotKeyBox.OnGotFocus));
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000F6E8 File Offset: 0x0000D8E8
		private static void OnGotFocus(object sender, RoutedEventArgs e)
		{
			if (!e.Handled)
			{
				HotKeyBox hotKeyBox = (HotKeyBox)sender;
				if (hotKeyBox.Focusable && e.OriginalSource == hotKeyBox)
				{
					TraversalRequest request = new TraversalRequest(((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
					UIElement uielement = Keyboard.FocusedElement as UIElement;
					if (uielement != null)
					{
						uielement.MoveFocus(request);
					}
					else
					{
						hotKeyBox.Focus();
					}
					e.Handled = true;
				}
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000F750 File Offset: 0x0000D950
		public override void OnApplyTemplate()
		{
			if (this._textBox != null)
			{
				this._textBox.PreviewKeyDown -= this.TextBoxOnPreviewKeyDown2;
				this._textBox.GotFocus -= this.TextBoxOnGotFocus;
				this._textBox.LostFocus -= this.TextBoxOnLostFocus;
				this._textBox.TextChanged -= this.TextBoxOnTextChanged;
			}
			base.OnApplyTemplate();
			this._textBox = (base.Template.FindName("PART_TextBox", this) as TextBox);
			if (this._textBox != null)
			{
				this._textBox.PreviewKeyDown += this.TextBoxOnPreviewKeyDown2;
				this._textBox.GotFocus += this.TextBoxOnGotFocus;
				this._textBox.LostFocus += this.TextBoxOnLostFocus;
				this._textBox.TextChanged += this.TextBoxOnTextChanged;
				this.UpdateText();
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000F84D File Offset: 0x0000DA4D
		private void TextBoxOnTextChanged(object sender, TextChangedEventArgs args)
		{
			this._textBox.SelectionStart = this._textBox.Text.Length;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000F86A File Offset: 0x0000DA6A
		private void TextBoxOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
		{
			ComponentDispatcher.ThreadPreprocessMessage += this.ComponentDispatcherOnThreadPreprocessMessage;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000F87D File Offset: 0x0000DA7D
		private void ComponentDispatcherOnThreadPreprocessMessage(ref MSG msg, ref bool handled)
		{
			if (msg.message == 786)
			{
				handled = true;
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000F88F File Offset: 0x0000DA8F
		private void TextBoxOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
		{
			ComponentDispatcher.ThreadPreprocessMessage -= this.ComponentDispatcherOnThreadPreprocessMessage;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
		private void TextBoxOnPreviewKeyDown2(object sender, KeyEventArgs e)
		{
			Key key = (e.Key == Key.System) ? e.SystemKey : e.Key;
			if (key == Key.Tab || key - Key.LWin <= 1 || key - Key.LeftShift <= 5)
			{
				return;
			}
			e.Handled = true;
			ModifierKeys currentModifierKeys = HotKeyBox.GetCurrentModifierKeys();
			if (currentModifierKeys == ModifierKeys.None && key == Key.Back)
			{
				this.HotKey = null;
			}
			else if (currentModifierKeys != ModifierKeys.None || !this.AreModifierKeysRequired)
			{
				this.HotKey = new HotKey(key, currentModifierKeys);
			}
			this.UpdateText();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000F91C File Offset: 0x0000DB1C
		private static ModifierKeys GetCurrentModifierKeys()
		{
			ModifierKeys modifierKeys = ModifierKeys.None;
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				modifierKeys |= ModifierKeys.Control;
			}
			if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
			{
				modifierKeys |= ModifierKeys.Alt;
			}
			if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
			{
				modifierKeys |= ModifierKeys.Shift;
			}
			if (Keyboard.IsKeyDown(Key.LWin) || Keyboard.IsKeyDown(Key.RWin))
			{
				modifierKeys |= ModifierKeys.Windows;
			}
			return modifierKeys;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000F984 File Offset: 0x0000DB84
		private void UpdateText()
		{
			HotKey hotKey = this.HotKey;
			this.Text = ((hotKey == null || hotKey.Key == Key.None) ? string.Empty : hotKey.ToString());
		}

		// Token: 0x0400017F RID: 383
		private const string PART_TextBox = "PART_TextBox";

		// Token: 0x04000180 RID: 384
		public static readonly DependencyProperty HotKeyProperty = DependencyProperty.Register("HotKey", typeof(HotKey), typeof(HotKeyBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(HotKeyBox.OnHotKeyChanged))
		{
			BindsTwoWayByDefault = true
		});

		// Token: 0x04000181 RID: 385
		public static readonly DependencyProperty AreModifierKeysRequiredProperty = DependencyProperty.Register("AreModifierKeysRequired", typeof(bool), typeof(HotKeyBox), new PropertyMetadata(false));

		// Token: 0x04000182 RID: 386
		[Obsolete("This property will be deleted in the next release. Instead use TextBoxHelper.Watermark attached property.")]
		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(string), typeof(HotKeyBox), new PropertyMetadata(null));

		// Token: 0x04000183 RID: 387
		private static readonly DependencyPropertyKey TextPropertyKey = DependencyProperty.RegisterReadOnly("Text", typeof(string), typeof(HotKeyBox), new PropertyMetadata(null));

		// Token: 0x04000184 RID: 388
		public static readonly DependencyProperty TextProperty = HotKeyBox.TextPropertyKey.DependencyProperty;

		// Token: 0x04000185 RID: 389
		private TextBox _textBox;
	}
}
