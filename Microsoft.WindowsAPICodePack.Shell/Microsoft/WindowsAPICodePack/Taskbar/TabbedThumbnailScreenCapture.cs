using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200012A RID: 298
	public static class TabbedThumbnailScreenCapture
	{
		// Token: 0x06000D3E RID: 3390 RVA: 0x00031304 File Offset: 0x0002F504
		public static Bitmap GrabWindowBitmap(IntPtr windowHandle, System.Drawing.Size bitmapSize)
		{
			Bitmap result;
			if (bitmapSize.Height <= 0 || bitmapSize.Width <= 0)
			{
				result = null;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = TabbedThumbnailNativeMethods.GetWindowDC(windowHandle);
					System.Drawing.Size size;
					TabbedThumbnailNativeMethods.GetClientSize(windowHandle, out size);
					if (size == System.Drawing.Size.Empty)
					{
						size = new System.Drawing.Size(200, 200);
					}
					System.Drawing.Size size2 = (bitmapSize == System.Drawing.Size.Empty) ? size : bitmapSize;
					Bitmap bitmap = null;
					try
					{
						bitmap = new Bitmap(size2.Width, size2.Height);
						using (Graphics graphics = Graphics.FromImage(bitmap))
						{
							IntPtr hdc = graphics.GetHdc();
							uint operation = 13369376U;
							System.Drawing.Size nonClientArea = WindowUtilities.GetNonClientArea(windowHandle);
							bool flag = TabbedThumbnailNativeMethods.StretchBlt(hdc, 0, 0, bitmap.Width, bitmap.Height, intPtr, nonClientArea.Width, nonClientArea.Height, size.Width, size.Height, operation);
							graphics.ReleaseHdc(hdc);
							if (!flag)
							{
								result = null;
							}
							else
							{
								result = bitmap;
							}
						}
					}
					catch
					{
						if (bitmap != null)
						{
							bitmap.Dispose();
						}
						throw;
					}
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						TabbedThumbnailNativeMethods.ReleaseDC(windowHandle, intPtr);
					}
				}
			}
			return result;
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x000314B8 File Offset: 0x0002F6B8
		public static Bitmap GrabWindowBitmap(UIElement element, int dpiX, int dpiY, int width, int height)
		{
			HwndHost hwndHost = element as HwndHost;
			Bitmap result;
			if (hwndHost != null)
			{
				IntPtr handle = hwndHost.Handle;
				result = TabbedThumbnailScreenCapture.GrabWindowBitmap(handle, new System.Drawing.Size(width, height));
			}
			else
			{
				Rect descendantBounds = VisualTreeHelper.GetDescendantBounds(element);
				if (descendantBounds.Height == 0.0 || descendantBounds.Width == 0.0)
				{
					result = null;
				}
				else
				{
					RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)(descendantBounds.Width * (double)dpiX / 96.0), (int)(descendantBounds.Height * (double)dpiY / 96.0), (double)dpiX, (double)dpiY, PixelFormats.Default);
					DrawingVisual drawingVisual = new DrawingVisual();
					using (DrawingContext drawingContext = drawingVisual.RenderOpen())
					{
						VisualBrush brush = new VisualBrush(element);
						drawingContext.DrawRectangle(brush, null, new Rect(default(System.Windows.Point), descendantBounds.Size));
					}
					renderTargetBitmap.Render(drawingVisual);
					BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
					bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
					Bitmap bitmap;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						bitmapEncoder.Save(memoryStream);
						memoryStream.Position = 0L;
						bitmap = new Bitmap(memoryStream);
					}
					result = (Bitmap)bitmap.GetThumbnailImage(width, height, null, IntPtr.Zero);
				}
			}
			return result;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00031658 File Offset: 0x0002F858
		internal static Bitmap ResizeImageWithAspect(IntPtr originalHBitmap, int newWidth, int maxHeight, bool resizeIfWider)
		{
			Bitmap bitmap = Image.FromHbitmap(originalHBitmap);
			Bitmap result;
			try
			{
				if (resizeIfWider && bitmap.Width <= newWidth)
				{
					newWidth = bitmap.Width;
				}
				int num = bitmap.Height * newWidth / bitmap.Width;
				if (num > maxHeight)
				{
					newWidth = bitmap.Width * maxHeight / bitmap.Height;
					num = maxHeight;
				}
				result = (Bitmap)bitmap.GetThumbnailImage(newWidth, num, null, IntPtr.Zero);
			}
			finally
			{
				bitmap.Dispose();
				bitmap = null;
			}
			return result;
		}
	}
}
