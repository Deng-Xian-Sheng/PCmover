using System;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000045 RID: 69
	internal static class WindowUtilities
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000AB44 File Offset: 0x00008D44
		internal static Point GetParentOffsetOfChild(IntPtr hwnd, IntPtr hwndParent)
		{
			NativePoint nativePoint = default(NativePoint);
			TabbedThumbnailNativeMethods.ClientToScreen(hwnd, ref nativePoint);
			NativePoint nativePoint2 = default(NativePoint);
			TabbedThumbnailNativeMethods.ClientToScreen(hwndParent, ref nativePoint2);
			Point result = new Point(nativePoint.X - nativePoint2.X, nativePoint.Y - nativePoint2.Y);
			return result;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		internal static Size GetNonClientArea(IntPtr hwnd)
		{
			NativePoint nativePoint = default(NativePoint);
			TabbedThumbnailNativeMethods.ClientToScreen(hwnd, ref nativePoint);
			NativeRect nativeRect = default(NativeRect);
			TabbedThumbnailNativeMethods.GetWindowRect(hwnd, ref nativeRect);
			return new Size(nativePoint.X - nativeRect.Left, nativePoint.Y - nativeRect.Top);
		}
	}
}
