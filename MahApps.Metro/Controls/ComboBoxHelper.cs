using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000043 RID: 67
	public class ComboBoxHelper
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0000C074 File Offset: 0x0000A274
		private static void OnEnableVirtualizationWithGroupingChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			ComboBox comboBox = dependencyObject as ComboBox;
			if (comboBox != null && e.NewValue != e.OldValue)
			{
				comboBox.SetCurrentValue(VirtualizingStackPanel.IsVirtualizingProperty, e.NewValue);
				comboBox.SetCurrentValue(VirtualizingPanel.IsVirtualizingWhenGroupingProperty, e.NewValue);
				comboBox.SetCurrentValue(ScrollViewer.CanContentScrollProperty, e.NewValue);
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000C0D1 File Offset: 0x0000A2D1
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static void SetEnableVirtualizationWithGrouping(DependencyObject obj, bool value)
		{
			obj.SetValue(ComboBoxHelper.EnableVirtualizationWithGroupingProperty, value);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000C0E4 File Offset: 0x0000A2E4
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static bool GetEnableVirtualizationWithGrouping(DependencyObject obj)
		{
			return (bool)obj.GetValue(ComboBoxHelper.EnableVirtualizationWithGroupingProperty);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000C0F6 File Offset: 0x0000A2F6
		private static bool ValidateMaxLength(object value)
		{
			return (int)value >= 0;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000C104 File Offset: 0x0000A304
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static int GetMaxLength(UIElement obj)
		{
			return (int)obj.GetValue(ComboBoxHelper.MaxLengthProperty);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000C116 File Offset: 0x0000A316
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static void SetMaxLength(UIElement obj, int value)
		{
			obj.SetValue(ComboBoxHelper.MaxLengthProperty, value);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000C129 File Offset: 0x0000A329
		private static bool ValidateCharacterCasing(object value)
		{
			return CharacterCasing.Normal <= (CharacterCasing)value && (CharacterCasing)value <= CharacterCasing.Upper;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000C142 File Offset: 0x0000A342
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static CharacterCasing GetCharacterCasing(UIElement obj)
		{
			return (CharacterCasing)obj.GetValue(ComboBoxHelper.CharacterCasingProperty);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000C154 File Offset: 0x0000A354
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static void SetCharacterCasing(UIElement obj, CharacterCasing value)
		{
			obj.SetValue(ComboBoxHelper.CharacterCasingProperty, value);
		}

		// Token: 0x0400010A RID: 266
		public static readonly DependencyProperty EnableVirtualizationWithGroupingProperty = DependencyProperty.RegisterAttached("EnableVirtualizationWithGrouping", typeof(bool), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(ComboBoxHelper.OnEnableVirtualizationWithGroupingChanged)));

		// Token: 0x0400010B RID: 267
		public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.RegisterAttached("MaxLength", typeof(int), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(0), new ValidateValueCallback(ComboBoxHelper.ValidateMaxLength));

		// Token: 0x0400010C RID: 268
		public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.RegisterAttached("CharacterCasing", typeof(CharacterCasing), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(CharacterCasing.Normal), new ValidateValueCallback(ComboBoxHelper.ValidateCharacterCasing));
	}
}
