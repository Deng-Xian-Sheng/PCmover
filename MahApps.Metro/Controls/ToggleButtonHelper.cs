using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000056 RID: 86
	public static class ToggleButtonHelper
	{
		// Token: 0x060003C2 RID: 962 RVA: 0x0000F2BC File Offset: 0x0000D4BC
		[AttachedPropertyBrowsableForType(typeof(ToggleButton))]
		[AttachedPropertyBrowsableForType(typeof(RadioButton))]
		[Category("MahApps.Metro")]
		public static FlowDirection GetContentDirection(UIElement element)
		{
			return (FlowDirection)element.GetValue(ToggleButtonHelper.ContentDirectionProperty);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0000F2CE File Offset: 0x0000D4CE
		public static void SetContentDirection(UIElement element, FlowDirection value)
		{
			element.SetValue(ToggleButtonHelper.ContentDirectionProperty, value);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
		private static void ContentDirectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (!(d is ToggleButton))
			{
				throw new InvalidOperationException("The property 'ContentDirection' may only be set on ToggleButton elements.");
			}
		}

		// Token: 0x0400017B RID: 379
		public static readonly DependencyProperty ContentDirectionProperty = DependencyProperty.RegisterAttached("ContentDirection", typeof(FlowDirection), typeof(ToggleButtonHelper), new FrameworkPropertyMetadata(FlowDirection.LeftToRight, new PropertyChangedCallback(ToggleButtonHelper.ContentDirectionPropertyChanged)));
	}
}
