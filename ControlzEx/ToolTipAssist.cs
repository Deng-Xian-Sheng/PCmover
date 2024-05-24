using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ControlzEx.Standard;

namespace ControlzEx
{
	// Token: 0x0200000B RID: 11
	public static class ToolTipAssist
	{
		// Token: 0x06000054 RID: 84 RVA: 0x0000318B File Offset: 0x0000138B
		[AttachedPropertyBrowsableForType(typeof(ToolTip))]
		public static bool GetAutoMove(ToolTip element)
		{
			return (bool)element.GetValue(ToolTipAssist.AutoMoveProperty);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000319D File Offset: 0x0000139D
		public static void SetAutoMove(ToolTip element, bool value)
		{
			element.SetValue(ToolTipAssist.AutoMoveProperty, value);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000031B0 File Offset: 0x000013B0
		[AttachedPropertyBrowsableForType(typeof(ToolTip))]
		public static double GetAutoMoveHorizontalOffset(ToolTip element)
		{
			return (double)element.GetValue(ToolTipAssist.AutoMoveHorizontalOffsetProperty);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000031C2 File Offset: 0x000013C2
		public static void SetAutoMoveHorizontalOffset(ToolTip element, double value)
		{
			element.SetValue(ToolTipAssist.AutoMoveHorizontalOffsetProperty, value);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000031D5 File Offset: 0x000013D5
		[AttachedPropertyBrowsableForType(typeof(ToolTip))]
		public static double GetAutoMoveVerticalOffset(ToolTip element)
		{
			return (double)element.GetValue(ToolTipAssist.AutoMoveVerticalOffsetProperty);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000031E7 File Offset: 0x000013E7
		public static void SetAutoMoveVerticalOffset(ToolTip element, double value)
		{
			element.SetValue(ToolTipAssist.AutoMoveVerticalOffsetProperty, value);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000031FC File Offset: 0x000013FC
		private static void AutoMovePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
		{
			ToolTip toolTip = (ToolTip)dependencyObject;
			if (eventArgs.OldValue != eventArgs.NewValue && eventArgs.NewValue != null)
			{
				if ((bool)eventArgs.NewValue)
				{
					toolTip.Opened += ToolTipAssist.ToolTip_Opened;
					toolTip.Closed += ToolTipAssist.ToolTip_Closed;
					return;
				}
				toolTip.Opened -= ToolTipAssist.ToolTip_Opened;
				toolTip.Closed -= ToolTipAssist.ToolTip_Closed;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003280 File Offset: 0x00001480
		private static void ToolTip_Opened(object sender, RoutedEventArgs e)
		{
			ToolTip toolTip = (ToolTip)sender;
			FrameworkElement frameworkElement = toolTip.PlacementTarget as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			ToolTipAssist.MoveToolTip(frameworkElement, toolTip);
			frameworkElement.MouseMove += ToolTipAssist.ToolTipTargetPreviewMouseMove;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000032C0 File Offset: 0x000014C0
		private static void ToolTip_Closed(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = ((ToolTip)sender).PlacementTarget as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			frameworkElement.MouseMove -= ToolTipAssist.ToolTipTargetPreviewMouseMove;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000032F4 File Offset: 0x000014F4
		private static void ToolTipTargetPreviewMouseMove(object sender, MouseEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			ToolTip toolTip = ((frameworkElement != null) ? frameworkElement.ToolTip : null) as ToolTip;
			ToolTipAssist.MoveToolTip(sender as IInputElement, toolTip);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003328 File Offset: 0x00001528
		private static void MoveToolTip(IInputElement target, ToolTip toolTip)
		{
			if (toolTip == null || target == null || toolTip.PlacementTarget == null)
			{
				return;
			}
			toolTip.Placement = PlacementMode.Relative;
			double autoMoveHorizontalOffset = ToolTipAssist.GetAutoMoveHorizontalOffset(toolTip);
			double autoMoveVerticalOffset = ToolTipAssist.GetAutoMoveVerticalOffset(toolTip);
			DpiScale dpi = DpiHelper.GetDpi(toolTip);
			double num = DpiHelper.TransformToDeviceX(toolTip.PlacementTarget, autoMoveHorizontalOffset, dpi.DpiScaleX);
			double num2 = DpiHelper.TransformToDeviceY(toolTip.PlacementTarget, autoMoveVerticalOffset, dpi.DpiScaleY);
			Point position = Mouse.GetPosition(toolTip.PlacementTarget);
			double num3 = position.X + num;
			double num4 = position.Y + num2;
			Point point = toolTip.PlacementTarget.PointToScreen(new Point(0.0, 0.0));
			MONITORINFO monitorinfo = null;
			try
			{
				monitorinfo = MonitorHelper.GetMonitorInfoFromPoint();
			}
			catch (UnauthorizedAccessException)
			{
			}
			if (monitorinfo != null)
			{
				int num5 = Math.Abs(monitorinfo.rcWork.Width);
				int num6 = Math.Abs(monitorinfo.rcWork.Height);
				if (point.X < 0.0)
				{
					point.X = (double)(-(double)monitorinfo.rcWork.Left) + point.X;
				}
				if (point.Y < 0.0)
				{
					point.Y = (double)(-(double)monitorinfo.rcWork.Top) + point.Y;
				}
				double num7 = (double)((int)point.X % num5);
				int num8 = (int)point.Y % num6;
				double num9 = DpiHelper.TransformToDeviceX(toolTip.RenderSize.Width, dpi.DpiScaleX);
				if (num7 + num3 + num9 > (double)num5)
				{
					num3 = position.X - toolTip.RenderSize.Width - 0.5 * num;
				}
				double num10 = DpiHelper.TransformToDeviceY(toolTip.RenderSize.Height, dpi.DpiScaleY);
				if ((double)num8 + num4 + num10 > (double)num6)
				{
					num4 = position.Y - toolTip.RenderSize.Height - 0.5 * num2;
				}
				toolTip.HorizontalOffset = num3;
				toolTip.VerticalOffset = num4;
			}
		}

		// Token: 0x0400002A RID: 42
		public static readonly DependencyProperty AutoMoveProperty = DependencyProperty.RegisterAttached("AutoMove", typeof(bool), typeof(ToolTipAssist), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(ToolTipAssist.AutoMovePropertyChangedCallback)));

		// Token: 0x0400002B RID: 43
		public static readonly DependencyProperty AutoMoveHorizontalOffsetProperty = DependencyProperty.RegisterAttached("AutoMoveHorizontalOffset", typeof(double), typeof(ToolTipAssist), new FrameworkPropertyMetadata(16.0));

		// Token: 0x0400002C RID: 44
		public static readonly DependencyProperty AutoMoveVerticalOffsetProperty = DependencyProperty.RegisterAttached("AutoMoveVerticalOffset", typeof(double), typeof(ToolTipAssist), new FrameworkPropertyMetadata(16.0));
	}
}
