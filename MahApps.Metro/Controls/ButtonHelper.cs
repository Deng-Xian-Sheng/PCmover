using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000042 RID: 66
	public static class ButtonHelper
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x0000BF8E File Offset: 0x0000A18E
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ButtonBase))]
		[Obsolete("This property will be deleted in the next release. You should use ContentCharacterCasing attached property located in ControlsHelper.")]
		public static bool GetPreserveTextCase(UIElement element)
		{
			return (bool)element.GetValue(ButtonHelper.PreserveTextCaseProperty);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000BFA0 File Offset: 0x0000A1A0
		[Obsolete("This property will be deleted in the next release. You should use ContentCharacterCasing attached property located in ControlsHelper.")]
		public static void SetPreserveTextCase(UIElement element, bool value)
		{
			element.SetValue(ButtonHelper.PreserveTextCaseProperty, value);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000BFB3 File Offset: 0x0000A1B3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ButtonBase))]
		[AttachedPropertyBrowsableForType(typeof(ToggleButton))]
		[Obsolete("This property will be deleted in the next release. You should use CornerRadius attached property located in ControlsHelper.")]
		public static CornerRadius GetCornerRadius(UIElement element)
		{
			return (CornerRadius)element.GetValue(ButtonHelper.CornerRadiusProperty);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000BFC5 File Offset: 0x0000A1C5
		[Obsolete("This property will be deleted in the next release. You should use CornerRadius attached property located in ControlsHelper.")]
		public static void SetCornerRadius(UIElement element, CornerRadius value)
		{
			element.SetValue(ButtonHelper.CornerRadiusProperty, value);
		}

		// Token: 0x04000108 RID: 264
		[Obsolete("This property will be deleted in the next release. You should use ContentCharacterCasing attached property located in ControlsHelper.")]
		public static readonly DependencyProperty PreserveTextCaseProperty = DependencyProperty.RegisterAttached("PreserveTextCase", typeof(bool), typeof(ButtonHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			ButtonBase buttonBase = o as ButtonBase;
			if (buttonBase != null && e.NewValue is bool)
			{
				ControlsHelper.SetContentCharacterCasing(buttonBase, ((bool)e.NewValue) ? CharacterCasing.Normal : CharacterCasing.Upper);
			}
		}));

		// Token: 0x04000109 RID: 265
		[Obsolete("This property will be deleted in the next release. You should use CornerRadius attached property located in ControlsHelper.")]
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonHelper), new FrameworkPropertyMetadata(new CornerRadius(-1.0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = o as UIElement;
			if (uielement != null && e.OldValue != e.NewValue && e.NewValue is CornerRadius)
			{
				ControlsHelper.SetCornerRadius(uielement, (CornerRadius)e.NewValue);
			}
		}));
	}
}
