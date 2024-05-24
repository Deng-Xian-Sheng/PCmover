using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ControlzEx.Windows.Shell;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200006C RID: 108
	internal static class MetroWindowHelpers
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x000144CC File Offset: 0x000126CC
		public static void SetIsHitTestVisibleInChromeProperty<T>(this MetroWindow window, string name, bool hitTestVisible = true) where T : class
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			IInputElement inputElement = window.GetPart<T>(name) as IInputElement;
			if (WindowChrome.GetIsHitTestVisibleInChrome(inputElement) != hitTestVisible)
			{
				WindowChrome.SetIsHitTestVisibleInChrome(inputElement, hitTestVisible);
			}
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001450C File Offset: 0x0001270C
		public static void SetWindowChromeResizeGripDirection(this MetroWindow window, string name, ResizeGripDirection direction)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			IInputElement inputElement = window.GetPart(name) as IInputElement;
			if (WindowChrome.GetResizeGripDirection(inputElement) != direction)
			{
				WindowChrome.SetResizeGripDirection(inputElement, direction);
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00014544 File Offset: 0x00012744
		public static void HandleWindowCommandsForFlyouts(this MetroWindow window, IEnumerable<Flyout> flyouts, Brush resetBrush = null)
		{
			IEnumerable<Flyout> source = from x in flyouts
			where x.IsOpen
			select x;
			if (!source.Any((Flyout x) => x.Position != Position.Bottom))
			{
				if (resetBrush == null)
				{
					window.ResetAllWindowCommandsBrush();
				}
				else
				{
					window.ChangeAllWindowCommandsBrush(resetBrush, Position.Top);
				}
			}
			Flyout flyout = (from x in source
			where x.Position == Position.Top
			select x).OrderByDescending(new Func<Flyout, int>(Panel.GetZIndex)).FirstOrDefault<Flyout>();
			if (flyout != null)
			{
				window.UpdateWindowCommandsForFlyout(flyout);
				return;
			}
			Flyout flyout2 = (from x in source
			where x.Position == Position.Left
			select x).OrderByDescending(new Func<Flyout, int>(Panel.GetZIndex)).FirstOrDefault<Flyout>();
			if (flyout2 != null)
			{
				window.UpdateWindowCommandsForFlyout(flyout2);
			}
			Flyout flyout3 = (from x in source
			where x.Position == Position.Right
			select x).OrderByDescending(new Func<Flyout, int>(Panel.GetZIndex)).FirstOrDefault<Flyout>();
			if (flyout3 != null)
			{
				window.UpdateWindowCommandsForFlyout(flyout3);
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00014684 File Offset: 0x00012884
		public static void ResetAllWindowCommandsBrush(this MetroWindow window)
		{
			window.ChangeAllWindowCommandsBrush(window.OverrideDefaultWindowCommandsBrush, Position.Top);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00014693 File Offset: 0x00012893
		public static void UpdateWindowCommandsForFlyout(this MetroWindow window, Flyout flyout)
		{
			window.ChangeAllWindowCommandsBrush(flyout.Foreground, flyout.Position);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x000146A8 File Offset: 0x000128A8
		private static void InvokeActionOnWindowCommands(this MetroWindow window, Action<Control> action1, Action<Control> action2 = null, Position position = Position.Top)
		{
			if (window.LeftWindowCommandsPresenter == null || window.RightWindowCommandsPresenter == null || window.WindowButtonCommands == null)
			{
				return;
			}
			if (position == Position.Left || position == Position.Top)
			{
				action1(window.LeftWindowCommands);
			}
			if (position == Position.Right || position == Position.Top)
			{
				action1(window.RightWindowCommands);
				if (action2 == null)
				{
					action1(window.WindowButtonCommands);
					return;
				}
				action2(window.WindowButtonCommands);
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00014714 File Offset: 0x00012914
		private static void ChangeAllWindowCommandsBrush(this MetroWindow window, Brush brush, Position position = Position.Top)
		{
			if (brush == null)
			{
				window.InvokeActionOnWindowCommands(delegate(Control x)
				{
					x.SetValue(WindowCommands.ThemeProperty, Theme.Light);
				}, delegate(Control x)
				{
					x.SetValue(WindowButtonCommands.ThemeProperty, Theme.Light);
				}, position);
				window.InvokeActionOnWindowCommands(delegate(Control x)
				{
					x.ClearValue(Control.ForegroundProperty);
				}, null, position);
				return;
			}
			Color color = ((SolidColorBrush)brush).Color;
			float num = (float)color.R / 255f;
			float num2 = (float)color.G / 255f;
			float num3 = (float)color.B / 255f;
			float num4 = num;
			float num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 < num5)
			{
				num5 = num3;
			}
			if ((double)((num4 + num5) / 2f) > 0.1)
			{
				window.InvokeActionOnWindowCommands(delegate(Control x)
				{
					x.SetValue(WindowCommands.ThemeProperty, Theme.Light);
				}, delegate(Control x)
				{
					x.SetValue(WindowButtonCommands.ThemeProperty, Theme.Light);
				}, position);
			}
			else
			{
				window.InvokeActionOnWindowCommands(delegate(Control x)
				{
					x.SetValue(WindowCommands.ThemeProperty, Theme.Dark);
				}, delegate(Control x)
				{
					x.SetValue(WindowButtonCommands.ThemeProperty, Theme.Dark);
				}, position);
			}
			window.InvokeActionOnWindowCommands(delegate(Control x)
			{
				x.SetValue(Control.ForegroundProperty, brush);
			}, null, position);
		}
	}
}
