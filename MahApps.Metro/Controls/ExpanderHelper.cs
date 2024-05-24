using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000048 RID: 72
	public static class ExpanderHelper
	{
		// Token: 0x06000307 RID: 775 RVA: 0x0000CBA7 File Offset: 0x0000ADA7
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Expander))]
		public static Style GetHeaderUpStyle(UIElement element)
		{
			return (Style)element.GetValue(ExpanderHelper.HeaderUpStyleProperty);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000CBB9 File Offset: 0x0000ADB9
		public static void SetHeaderUpStyle(UIElement element, Style value)
		{
			element.SetValue(ExpanderHelper.HeaderUpStyleProperty, value);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000CBC7 File Offset: 0x0000ADC7
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Expander))]
		public static Style GetHeaderDownStyle(UIElement element)
		{
			return (Style)element.GetValue(ExpanderHelper.HeaderDownStyleProperty);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000CBD9 File Offset: 0x0000ADD9
		public static void SetHeaderDownStyle(UIElement element, Style value)
		{
			element.SetValue(ExpanderHelper.HeaderDownStyleProperty, value);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000CBE7 File Offset: 0x0000ADE7
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Expander))]
		public static Style GetHeaderLeftStyle(UIElement element)
		{
			return (Style)element.GetValue(ExpanderHelper.HeaderLeftStyleProperty);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000CBF9 File Offset: 0x0000ADF9
		public static void SetHeaderLeftStyle(UIElement element, Style value)
		{
			element.SetValue(ExpanderHelper.HeaderLeftStyleProperty, value);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000CC07 File Offset: 0x0000AE07
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Expander))]
		public static Style GetHeaderRightStyle(UIElement element)
		{
			return (Style)element.GetValue(ExpanderHelper.HeaderRightStyleProperty);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000CC19 File Offset: 0x0000AE19
		public static void SetHeaderRightStyle(UIElement element, Style value)
		{
			element.SetValue(ExpanderHelper.HeaderRightStyleProperty, value);
		}

		// Token: 0x0400011F RID: 287
		public static readonly DependencyProperty HeaderUpStyleProperty = DependencyProperty.RegisterAttached("HeaderUpStyle", typeof(Style), typeof(ExpanderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000120 RID: 288
		public static readonly DependencyProperty HeaderDownStyleProperty = DependencyProperty.RegisterAttached("HeaderDownStyle", typeof(Style), typeof(ExpanderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000121 RID: 289
		public static readonly DependencyProperty HeaderLeftStyleProperty = DependencyProperty.RegisterAttached("HeaderLeftStyle", typeof(Style), typeof(ExpanderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000122 RID: 290
		public static readonly DependencyProperty HeaderRightStyleProperty = DependencyProperty.RegisterAttached("HeaderRightStyle", typeof(Style), typeof(ExpanderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
	}
}
