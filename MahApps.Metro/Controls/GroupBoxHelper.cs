using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000049 RID: 73
	public static class GroupBoxHelper
	{
		// Token: 0x06000310 RID: 784 RVA: 0x0000CCE1 File Offset: 0x0000AEE1
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(GroupBox))]
		[AttachedPropertyBrowsableForType(typeof(Expander))]
		public static Brush GetHeaderForeground(UIElement element)
		{
			return (Brush)element.GetValue(GroupBoxHelper.HeaderForegroundProperty);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000CCF3 File Offset: 0x0000AEF3
		public static void SetHeaderForeground(UIElement element, Brush value)
		{
			element.SetValue(GroupBoxHelper.HeaderForegroundProperty, value);
		}

		// Token: 0x04000123 RID: 291
		public static readonly DependencyProperty HeaderForegroundProperty = DependencyProperty.RegisterAttached("HeaderForeground", typeof(Brush), typeof(GroupBoxHelper), new UIPropertyMetadata(Brushes.White));
	}
}
