using System;
using System.Windows;
using System.Windows.Data;
using ControlzEx.Behaviors;
using ControlzEx.Windows.Shell;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B4 RID: 180
	public class BorderlessWindowBehavior : WindowChromeBehavior
	{
		// Token: 0x060009D7 RID: 2519 RVA: 0x0002614C File Offset: 0x0002434C
		protected override void OnAttached()
		{
			BindingOperations.SetBinding(this, WindowChromeBehavior.IgnoreTaskbarOnMaximizeProperty, new Binding
			{
				Path = new PropertyPath(MetroWindow.IgnoreTaskbarOnMaximizeProperty),
				Source = base.AssociatedObject
			});
			BindingOperations.SetBinding(this, WindowChromeBehavior.ResizeBorderThicknessProperty, new Binding
			{
				Path = new PropertyPath(MetroWindow.ResizeBorderThicknessProperty),
				Source = base.AssociatedObject
			});
			BindingOperations.SetBinding(this, WindowChromeBehavior.GlowBrushProperty, new Binding
			{
				Path = new PropertyPath(MetroWindow.GlowBrushProperty),
				Source = base.AssociatedObject
			});
			base.OnAttached();
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x000261E6 File Offset: 0x000243E6
		protected override void OnDetaching()
		{
			BindingOperations.ClearBinding(this, WindowChromeBehavior.IgnoreTaskbarOnMaximizeProperty);
			BindingOperations.ClearBinding(this, WindowChromeBehavior.ResizeBorderThicknessProperty);
			BindingOperations.ClearBinding(this, WindowChromeBehavior.GlowBrushProperty);
			base.OnDetaching();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00026210 File Offset: 0x00024410
		protected override void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
		{
			MetroWindow metroWindow = sender as MetroWindow;
			if (metroWindow == null)
			{
				return;
			}
			if (metroWindow.ResizeMode != ResizeMode.NoResize)
			{
				metroWindow.SetIsHitTestVisibleInChromeProperty("PART_Icon", true);
				metroWindow.SetWindowChromeResizeGripDirection("WindowResizeGrip", ResizeGripDirection.BottomRight);
			}
		}
	}
}
