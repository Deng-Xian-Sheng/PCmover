using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x020000A4 RID: 164
	internal static class TabbedThumbnailNativeMethods
	{
		// Token: 0x06000550 RID: 1360
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetIconicThumbnail(IntPtr hwnd, IntPtr hbitmap, uint flags);

		// Token: 0x06000551 RID: 1361
		[DllImport("dwmapi.dll")]
		internal static extern int DwmInvalidateIconicBitmaps(IntPtr hwnd);

		// Token: 0x06000552 RID: 1362
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbitmap, ref NativePoint ptClient, uint flags);

		// Token: 0x06000553 RID: 1363
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbitmap, IntPtr ptClient, uint flags);

		// Token: 0x06000554 RID: 1364
		[DllImport("dwmapi.dll")]
		internal static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttributeToSet, IntPtr pvAttributeValue, uint cbAttribute);

		// Token: 0x06000555 RID: 1365
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowRect(IntPtr hwnd, ref NativeRect rect);

		// Token: 0x06000556 RID: 1366
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetClientRect(IntPtr hwnd, ref NativeRect rect);

		// Token: 0x06000557 RID: 1367 RVA: 0x00012858 File Offset: 0x00010A58
		internal static bool GetClientSize(IntPtr hwnd, out Size size)
		{
			NativeRect nativeRect = default(NativeRect);
			bool result;
			if (!TabbedThumbnailNativeMethods.GetClientRect(hwnd, ref nativeRect))
			{
				size = new Size(-1, -1);
				result = false;
			}
			else
			{
				size = new Size(nativeRect.Right, nativeRect.Bottom);
				result = true;
			}
			return result;
		}

		// Token: 0x06000558 RID: 1368
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool ClientToScreen(IntPtr hwnd, ref NativePoint point);

		// Token: 0x06000559 RID: 1369
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool StretchBlt(IntPtr hDestDC, int destX, int destY, int destWidth, int destHeight, IntPtr hSrcDC, int srcX, int srcY, int srcWidth, int srcHeight, uint operation);

		// Token: 0x0600055A RID: 1370
		[DllImport("user32.dll")]
		internal static extern IntPtr GetWindowDC(IntPtr hwnd);

		// Token: 0x0600055B RID: 1371
		[DllImport("user32.dll")]
		internal static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x0600055C RID: 1372
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr ChangeWindowMessageFilter(uint message, uint dwFlag);

		// Token: 0x0600055D RID: 1373 RVA: 0x000128AC File Offset: 0x00010AAC
		internal static void SetIconicThumbnail(IntPtr hwnd, IntPtr hBitmap)
		{
			int num = TabbedThumbnailNativeMethods.DwmSetIconicThumbnail(hwnd, hBitmap, 1U);
			if (num != 0)
			{
				throw Marshal.GetExceptionForHR(num);
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x000128D4 File Offset: 0x00010AD4
		internal static void SetPeekBitmap(IntPtr hwnd, IntPtr bitmap, bool displayFrame)
		{
			int num = TabbedThumbnailNativeMethods.DwmSetIconicLivePreviewBitmap(hwnd, bitmap, IntPtr.Zero, displayFrame ? 1U : 0U);
			if (num != 0)
			{
				throw Marshal.GetExceptionForHR(num);
			}
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00012908 File Offset: 0x00010B08
		internal static void SetPeekBitmap(IntPtr hwnd, IntPtr bitmap, Point offset, bool displayFrame)
		{
			NativePoint nativePoint = new NativePoint(offset.X, offset.Y);
			int num = TabbedThumbnailNativeMethods.DwmSetIconicLivePreviewBitmap(hwnd, bitmap, ref nativePoint, displayFrame ? 1U : 0U);
			if (num != 0)
			{
				Exception exceptionForHR = Marshal.GetExceptionForHR(num);
				if (!(exceptionForHR is ArgumentException))
				{
					throw exceptionForHR;
				}
			}
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0001296C File Offset: 0x00010B6C
		internal static void EnableCustomWindowPreview(IntPtr hwnd, bool enable)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(4);
			Marshal.WriteInt32(intPtr, enable ? 1 : 0);
			try
			{
				int num = TabbedThumbnailNativeMethods.DwmSetWindowAttribute(hwnd, 10U, intPtr, 4U);
				if (num != 0)
				{
					throw Marshal.GetExceptionForHR(num);
				}
				num = TabbedThumbnailNativeMethods.DwmSetWindowAttribute(hwnd, 7U, intPtr, 4U);
				if (num != 0)
				{
					throw Marshal.GetExceptionForHR(num);
				}
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x04000329 RID: 809
		internal const int DisplayFrame = 1;

		// Token: 0x0400032A RID: 810
		internal const int ForceIconicRepresentation = 7;

		// Token: 0x0400032B RID: 811
		internal const int HasIconicBitmap = 10;

		// Token: 0x0400032C RID: 812
		internal const uint WmDwmSendIconicThumbnail = 803U;

		// Token: 0x0400032D RID: 813
		internal const uint WmDwmSendIconicLivePreviewBitmap = 806U;

		// Token: 0x0400032E RID: 814
		internal const uint WaActive = 1U;

		// Token: 0x0400032F RID: 815
		internal const uint WaClickActive = 2U;

		// Token: 0x04000330 RID: 816
		internal const int ScClose = 61536;

		// Token: 0x04000331 RID: 817
		internal const int ScMaximize = 61488;

		// Token: 0x04000332 RID: 818
		internal const int ScMinimize = 61472;

		// Token: 0x04000333 RID: 819
		internal const uint MsgfltAdd = 1U;

		// Token: 0x04000334 RID: 820
		internal const uint MsgfltRemove = 2U;
	}
}
