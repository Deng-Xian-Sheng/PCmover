using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000052 RID: 82
	public static class TabControlHelper
	{
		// Token: 0x06000361 RID: 865 RVA: 0x0000DAAD File Offset: 0x0000BCAD
		public static void ClearStyle(this TabItem tabItem)
		{
			if (tabItem == null)
			{
				return;
			}
			tabItem.Template = null;
			tabItem.Style = null;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000DAC1 File Offset: 0x0000BCC1
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static bool GetCloseButtonEnabled(UIElement element)
		{
			return (bool)element.GetValue(TabControlHelper.CloseButtonEnabledProperty);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000DAD3 File Offset: 0x0000BCD3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetCloseButtonEnabled(UIElement element, bool value)
		{
			element.SetValue(TabControlHelper.CloseButtonEnabledProperty, value);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000DAE6 File Offset: 0x0000BCE6
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static ICommand GetCloseTabCommand(UIElement element)
		{
			return (ICommand)element.GetValue(TabControlHelper.CloseTabCommandProperty);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetCloseTabCommand(UIElement element, ICommand value)
		{
			element.SetValue(TabControlHelper.CloseTabCommandProperty, value);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000DB06 File Offset: 0x0000BD06
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static object GetCloseTabCommandParameter(UIElement element)
		{
			return element.GetValue(TabControlHelper.CloseTabCommandParameterProperty);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000DB13 File Offset: 0x0000BD13
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetCloseTabCommandParameter(UIElement element, object value)
		{
			element.SetValue(TabControlHelper.CloseTabCommandParameterProperty, value);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000DB21 File Offset: 0x0000BD21
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[Obsolete("This property will be deleted in the next release. You should now use the Underlined attached property.")]
		public static bool GetIsUnderlined(UIElement element)
		{
			return (bool)element.GetValue(TabControlHelper.IsUnderlinedProperty);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000DB33 File Offset: 0x0000BD33
		[Obsolete("This property will be deleted in the next release. You should now use the Underlined attached property.")]
		public static void SetIsUnderlined(UIElement element, bool value)
		{
			element.SetValue(TabControlHelper.IsUnderlinedProperty, value);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000DB46 File Offset: 0x0000BD46
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		public static UnderlinedType GetUnderlined(UIElement element)
		{
			return (UnderlinedType)element.GetValue(TabControlHelper.UnderlinedProperty);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000DB58 File Offset: 0x0000BD58
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		public static void SetUnderlined(UIElement element, UnderlinedType value)
		{
			element.SetValue(TabControlHelper.UnderlinedProperty, value);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000DB6B File Offset: 0x0000BD6B
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static Brush GetUnderlineBrush(UIElement element)
		{
			return (Brush)element.GetValue(TabControlHelper.UnderlineBrushProperty);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000DB7D File Offset: 0x0000BD7D
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetUnderlineBrush(UIElement element, Brush value)
		{
			element.SetValue(TabControlHelper.UnderlineBrushProperty, value);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000DB8B File Offset: 0x0000BD8B
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static Brush GetUnderlineSelectedBrush(UIElement element)
		{
			return (Brush)element.GetValue(TabControlHelper.UnderlineSelectedBrushProperty);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000DB9D File Offset: 0x0000BD9D
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetUnderlineSelectedBrush(UIElement element, Brush value)
		{
			element.SetValue(TabControlHelper.UnderlineSelectedBrushProperty, value);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000DBAB File Offset: 0x0000BDAB
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static Brush GetUnderlineMouseOverBrush(UIElement element)
		{
			return (Brush)element.GetValue(TabControlHelper.UnderlineMouseOverBrushProperty);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000DBBD File Offset: 0x0000BDBD
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetUnderlineMouseOverBrush(UIElement element, Brush value)
		{
			element.SetValue(TabControlHelper.UnderlineMouseOverBrushProperty, value);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000DBCB File Offset: 0x0000BDCB
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static Brush GetUnderlineMouseOverSelectedBrush(UIElement element)
		{
			return (Brush)element.GetValue(TabControlHelper.UnderlineMouseOverSelectedBrushProperty);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000DBDD File Offset: 0x0000BDDD
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TabControl))]
		[AttachedPropertyBrowsableForType(typeof(TabItem))]
		public static void SetUnderlineMouseOverSelectedBrush(UIElement element, Brush value)
		{
			element.SetValue(TabControlHelper.UnderlineMouseOverSelectedBrushProperty, value);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000DBEB File Offset: 0x0000BDEB
		[Category("MahApps.Metro")]
		public static TransitionType GetTransition(DependencyObject obj)
		{
			return (TransitionType)obj.GetValue(TabControlHelper.TransitionProperty);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000DBFD File Offset: 0x0000BDFD
		public static void SetTransition(DependencyObject obj, TransitionType value)
		{
			obj.SetValue(TabControlHelper.TransitionProperty, value);
		}

		// Token: 0x0400014F RID: 335
		public static readonly DependencyProperty CloseButtonEnabledProperty = DependencyProperty.RegisterAttached("CloseButtonEnabled", typeof(bool), typeof(TabControlHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000150 RID: 336
		public static readonly DependencyProperty CloseTabCommandProperty = DependencyProperty.RegisterAttached("CloseTabCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(null));

		// Token: 0x04000151 RID: 337
		public static readonly DependencyProperty CloseTabCommandParameterProperty = DependencyProperty.RegisterAttached("CloseTabCommandParameter", typeof(object), typeof(TabControlHelper), new PropertyMetadata(null));

		// Token: 0x04000152 RID: 338
		[Obsolete("This property will be deleted in the next release. You should now use the Underlined attached property.")]
		public static readonly DependencyProperty IsUnderlinedProperty = DependencyProperty.RegisterAttached("IsUnderlined", typeof(bool), typeof(TabControlHelper), new PropertyMetadata(false, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = o as UIElement;
			if (uielement != null && e.OldValue != e.NewValue && e.NewValue is bool)
			{
				TabControlHelper.SetUnderlined(uielement, ((bool)e.NewValue) ? UnderlinedType.TabItems : UnderlinedType.None);
			}
		}));

		// Token: 0x04000153 RID: 339
		public static readonly DependencyProperty UnderlinedProperty = DependencyProperty.RegisterAttached("Underlined", typeof(UnderlinedType), typeof(TabControlHelper), new PropertyMetadata(UnderlinedType.None));

		// Token: 0x04000154 RID: 340
		public static readonly DependencyProperty UnderlineBrushProperty = DependencyProperty.RegisterAttached("UnderlineBrush", typeof(Brush), typeof(TabControlHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000155 RID: 341
		public static readonly DependencyProperty UnderlineSelectedBrushProperty = DependencyProperty.RegisterAttached("UnderlineSelectedBrush", typeof(Brush), typeof(TabControlHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000156 RID: 342
		public static readonly DependencyProperty UnderlineMouseOverBrushProperty = DependencyProperty.RegisterAttached("UnderlineMouseOverBrush", typeof(Brush), typeof(TabControlHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000157 RID: 343
		public static readonly DependencyProperty UnderlineMouseOverSelectedBrushProperty = DependencyProperty.RegisterAttached("UnderlineMouseOverSelectedBrush", typeof(Brush), typeof(TabControlHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000158 RID: 344
		public static readonly DependencyProperty TransitionProperty = DependencyProperty.RegisterAttached("Transition", typeof(TransitionType), typeof(TabControlHelper), new FrameworkPropertyMetadata(TransitionType.Default, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
	}
}
