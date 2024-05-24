using System;
using System.Windows;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000098 RID: 152
	public static class WinApiHelper
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x000217E8 File Offset: 0x0001F9E8
		public static Point GetRelativeMousePosition(IntPtr hWnd)
		{
			if (hWnd == IntPtr.Zero)
			{
				return default(Point);
			}
			POINT physicalCursorPos = WinApiHelper.GetPhysicalCursorPos();
			NativeMethods.ScreenToClient(hWnd, ref physicalCursorPos);
			return new Point((double)physicalCursorPos.X, (double)physicalCursorPos.Y);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00021830 File Offset: 0x0001FA30
		public static bool TryGetRelativeMousePosition(IntPtr hWnd, out Point point)
		{
			POINT point2 = default(POINT);
			bool flag = hWnd != IntPtr.Zero && NativeMethods.TryGetPhysicalCursorPos(out point2);
			if (flag)
			{
				NativeMethods.ScreenToClient(hWnd, ref point2);
				point = new Point((double)point2.X, (double)point2.Y);
				return flag;
			}
			point = default(Point);
			return flag;
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0002188C File Offset: 0x0001FA8C
		internal static POINT GetPhysicalCursorPos()
		{
			POINT physicalCursorPos;
			try
			{
				physicalCursorPos = NativeMethods.GetPhysicalCursorPos();
			}
			catch (Exception innerException)
			{
				throw new MahAppsException("Uups, this should not happen! Sorry for this exception! Is this maybe happend on a virtual machine or via remote desktop? Please let us know, thx.", innerException);
			}
			return physicalCursorPos;
		}
	}
}
