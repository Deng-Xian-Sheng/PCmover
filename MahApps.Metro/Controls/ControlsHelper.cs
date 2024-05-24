using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000044 RID: 68
	public static class ControlsHelper
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x0000C22B File Offset: 0x0000A42B
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		public static Visibility GetDisabledVisualElementVisibility(UIElement element)
		{
			return (Visibility)element.GetValue(ControlsHelper.DisabledVisualElementVisibilityProperty);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000C23D File Offset: 0x0000A43D
		public static void SetDisabledVisualElementVisibility(UIElement element, Visibility value)
		{
			element.SetValue(ControlsHelper.DisabledVisualElementVisibilityProperty, value);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000C250 File Offset: 0x0000A450
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ContentControl))]
		[AttachedPropertyBrowsableForType(typeof(DropDownButton))]
		[AttachedPropertyBrowsableForType(typeof(WindowCommands))]
		public static CharacterCasing GetContentCharacterCasing(UIElement element)
		{
			return (CharacterCasing)element.GetValue(ControlsHelper.ContentCharacterCasingProperty);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000C262 File Offset: 0x0000A462
		public static void SetContentCharacterCasing(UIElement element, CharacterCasing value)
		{
			element.SetValue(ControlsHelper.ContentCharacterCasingProperty, value);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000C275 File Offset: 0x0000A475
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(HeaderedContentControl))]
		[AttachedPropertyBrowsableForType(typeof(Flyout))]
		public static double GetHeaderFontSize(UIElement element)
		{
			return (double)element.GetValue(ControlsHelper.HeaderFontSizeProperty);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000C287 File Offset: 0x0000A487
		public static void SetHeaderFontSize(UIElement element, double value)
		{
			element.SetValue(ControlsHelper.HeaderFontSizeProperty, value);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000C29A File Offset: 0x0000A49A
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(HeaderedContentControl))]
		[AttachedPropertyBrowsableForType(typeof(Flyout))]
		public static FontStretch GetHeaderFontStretch(UIElement element)
		{
			return (FontStretch)element.GetValue(ControlsHelper.HeaderFontStretchProperty);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000C2AC File Offset: 0x0000A4AC
		public static void SetHeaderFontStretch(UIElement element, FontStretch value)
		{
			element.SetValue(ControlsHelper.HeaderFontStretchProperty, value);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000C2BF File Offset: 0x0000A4BF
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(HeaderedContentControl))]
		[AttachedPropertyBrowsableForType(typeof(Flyout))]
		public static FontWeight GetHeaderFontWeight(UIElement element)
		{
			return (FontWeight)element.GetValue(ControlsHelper.HeaderFontWeightProperty);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000C2D1 File Offset: 0x0000A4D1
		public static void SetHeaderFontWeight(UIElement element, FontWeight value)
		{
			element.SetValue(ControlsHelper.HeaderFontWeightProperty, value);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000C2E4 File Offset: 0x0000A4E4
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(HeaderedContentControl))]
		[AttachedPropertyBrowsableForType(typeof(Flyout))]
		public static Thickness GetHeaderMargin(UIElement element)
		{
			return (Thickness)element.GetValue(ControlsHelper.HeaderMarginProperty);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000C2F6 File Offset: 0x0000A4F6
		public static void SetHeaderMargin(UIElement element, Thickness value)
		{
			element.SetValue(ControlsHelper.HeaderMarginProperty, value);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000C309 File Offset: 0x0000A509
		[Category("MahApps.Metro")]
		[Obsolete("This property will be deleted in the next release. You should use TextBoxHelper.ButtonWidth instead.")]
		public static double GetButtonWidth(DependencyObject obj)
		{
			return (double)obj.GetValue(ControlsHelper.ButtonWidthProperty);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000C31B File Offset: 0x0000A51B
		[Obsolete("This property will be deleted in the next release. You should use TextBoxHelper.ButtonWidth instead.")]
		public static void SetButtonWidth(DependencyObject obj, double value)
		{
			obj.SetValue(ControlsHelper.ButtonWidthProperty, value);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000C32E File Offset: 0x0000A52E
		public static void SetFocusBorderBrush(DependencyObject obj, Brush value)
		{
			obj.SetValue(ControlsHelper.FocusBorderBrushProperty, value);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000C33C File Offset: 0x0000A53C
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		[AttachedPropertyBrowsableForType(typeof(CheckBox))]
		[AttachedPropertyBrowsableForType(typeof(RadioButton))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static Brush GetFocusBorderBrush(DependencyObject obj)
		{
			return (Brush)obj.GetValue(ControlsHelper.FocusBorderBrushProperty);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000C34E File Offset: 0x0000A54E
		public static void SetMouseOverBorderBrush(DependencyObject obj, Brush value)
		{
			obj.SetValue(ControlsHelper.MouseOverBorderBrushProperty, value);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000C35C File Offset: 0x0000A55C
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		[AttachedPropertyBrowsableForType(typeof(CheckBox))]
		[AttachedPropertyBrowsableForType(typeof(RadioButton))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(Tile))]
		public static Brush GetMouseOverBorderBrush(DependencyObject obj)
		{
			return (Brush)obj.GetValue(ControlsHelper.MouseOverBorderBrushProperty);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000C36E File Offset: 0x0000A56E
		[Category("MahApps.Metro")]
		public static CornerRadius GetCornerRadius(UIElement element)
		{
			return (CornerRadius)element.GetValue(ControlsHelper.CornerRadiusProperty);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000C380 File Offset: 0x0000A580
		public static void SetCornerRadius(UIElement element, CornerRadius value)
		{
			element.SetValue(ControlsHelper.CornerRadiusProperty, value);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000C393 File Offset: 0x0000A593
		public static bool GetIsReadOnly(UIElement element)
		{
			return (bool)element.GetValue(ControlsHelper.IsReadOnlyProperty);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000C3A5 File Offset: 0x0000A5A5
		public static void SetIsReadOnly(UIElement element, bool value)
		{
			element.SetValue(ControlsHelper.IsReadOnlyProperty, value);
		}

		// Token: 0x0400010D RID: 269
		public static readonly DependencyProperty DisabledVisualElementVisibilityProperty = DependencyProperty.RegisterAttached("DisabledVisualElementVisibility", typeof(Visibility), typeof(ControlsHelper), new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400010E RID: 270
		public static readonly DependencyProperty ContentCharacterCasingProperty = DependencyProperty.RegisterAttached("ContentCharacterCasing", typeof(CharacterCasing), typeof(ControlsHelper), new FrameworkPropertyMetadata(CharacterCasing.Normal, FrameworkPropertyMetadataOptions.AffectsMeasure), (object value) => CharacterCasing.Normal <= (CharacterCasing)value && (CharacterCasing)value <= CharacterCasing.Upper);

		// Token: 0x0400010F RID: 271
		public static readonly DependencyProperty HeaderFontSizeProperty = DependencyProperty.RegisterAttached("HeaderFontSize", typeof(double), typeof(ControlsHelper), new FrameworkPropertyMetadata(SystemFonts.MessageFontSize)
		{
			Inherits = true
		});

		// Token: 0x04000110 RID: 272
		public static readonly DependencyProperty HeaderFontStretchProperty = DependencyProperty.RegisterAttached("HeaderFontStretch", typeof(FontStretch), typeof(ControlsHelper), new UIPropertyMetadata(FontStretches.Normal));

		// Token: 0x04000111 RID: 273
		public static readonly DependencyProperty HeaderFontWeightProperty = DependencyProperty.RegisterAttached("HeaderFontWeight", typeof(FontWeight), typeof(ControlsHelper), new UIPropertyMetadata(FontWeights.Normal));

		// Token: 0x04000112 RID: 274
		public static readonly DependencyProperty HeaderMarginProperty = DependencyProperty.RegisterAttached("HeaderMargin", typeof(Thickness), typeof(ControlsHelper), new UIPropertyMetadata(default(Thickness)));

		// Token: 0x04000113 RID: 275
		[Obsolete("This property will be deleted in the next release. You should use TextBoxHelper.ButtonWidth instead.")]
		public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.RegisterAttached("ButtonWidth", typeof(double), typeof(ControlsHelper), new FrameworkPropertyMetadata(22.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = o as UIElement;
			if (uielement != null && e.OldValue != e.NewValue && e.NewValue is double)
			{
				TextBoxHelper.SetButtonWidth(uielement, (double)e.NewValue);
			}
		}));

		// Token: 0x04000114 RID: 276
		public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.RegisterAttached("FocusBorderBrush", typeof(Brush), typeof(ControlsHelper), new FrameworkPropertyMetadata(Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000115 RID: 277
		public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.RegisterAttached("MouseOverBorderBrush", typeof(Brush), typeof(ControlsHelper), new FrameworkPropertyMetadata(Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000116 RID: 278
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ControlsHelper), new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000117 RID: 279
		public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.RegisterAttached("IsReadOnly", typeof(bool), typeof(ControlsHelper), new FrameworkPropertyMetadata(false));
	}
}
