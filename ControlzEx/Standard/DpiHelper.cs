using System;
using System.Windows;
using System.Windows.Media;

namespace ControlzEx.Standard
{
	// Token: 0x0200001A RID: 26
	internal static class DpiHelper
	{
		// Token: 0x0600013B RID: 315 RVA: 0x00007555 File Offset: 0x00005755
		public static Point LogicalPixelsToDevice(Point logicalPoint, double dpiScaleX, double dpiScaleY)
		{
			DpiHelper._transformToDevice = Matrix.Identity;
			DpiHelper._transformToDevice.Scale(dpiScaleX, dpiScaleY);
			return DpiHelper._transformToDevice.Transform(logicalPoint);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00007578 File Offset: 0x00005778
		public static Point DevicePixelsToLogical(Point devicePoint, double dpiScaleX, double dpiScaleY)
		{
			DpiHelper._transformToDip = Matrix.Identity;
			DpiHelper._transformToDip.Scale(1.0 / dpiScaleX, 1.0 / dpiScaleY);
			return DpiHelper._transformToDip.Transform(devicePoint);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000075B0 File Offset: 0x000057B0
		public static Rect LogicalRectToDevice(Rect logicalRectangle, double dpiScaleX, double dpiScaleY)
		{
			Point point = DpiHelper.LogicalPixelsToDevice(new Point(logicalRectangle.Left, logicalRectangle.Top), dpiScaleX, dpiScaleY);
			Point point2 = DpiHelper.LogicalPixelsToDevice(new Point(logicalRectangle.Right, logicalRectangle.Bottom), dpiScaleX, dpiScaleY);
			return new Rect(point, point2);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000075F8 File Offset: 0x000057F8
		public static Rect DeviceRectToLogical(Rect deviceRectangle, double dpiScaleX, double dpiScaleY)
		{
			Point point = DpiHelper.DevicePixelsToLogical(new Point(deviceRectangle.Left, deviceRectangle.Top), dpiScaleX, dpiScaleY);
			Point point2 = DpiHelper.DevicePixelsToLogical(new Point(deviceRectangle.Right, deviceRectangle.Bottom), dpiScaleX, dpiScaleY);
			return new Rect(point, point2);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00007640 File Offset: 0x00005840
		public static Size LogicalSizeToDevice(Size logicalSize, double dpiScaleX, double dpiScaleY)
		{
			Point point = DpiHelper.LogicalPixelsToDevice(new Point(logicalSize.Width, logicalSize.Height), dpiScaleX, dpiScaleY);
			return new Size
			{
				Width = point.X,
				Height = point.Y
			};
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00007690 File Offset: 0x00005890
		public static Size DeviceSizeToLogical(Size deviceSize, double dpiScaleX, double dpiScaleY)
		{
			Point point = DpiHelper.DevicePixelsToLogical(new Point(deviceSize.Width, deviceSize.Height), dpiScaleX, dpiScaleY);
			return new Size(point.X, point.Y);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000076CC File Offset: 0x000058CC
		public static Thickness LogicalThicknessToDevice(Thickness logicalThickness, double dpiScaleX, double dpiScaleY)
		{
			Point point = DpiHelper.LogicalPixelsToDevice(new Point(logicalThickness.Left, logicalThickness.Top), dpiScaleX, dpiScaleY);
			Point point2 = DpiHelper.LogicalPixelsToDevice(new Point(logicalThickness.Right, logicalThickness.Bottom), dpiScaleX, dpiScaleY);
			return new Thickness(point.X, point.Y, point2.X, point2.Y);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00007730 File Offset: 0x00005930
		public static double TransformToDeviceY(Visual visual, double y, double dpiScaleY)
		{
			PresentationSource presentationSource = PresentationSource.FromVisual(visual);
			if (((presentationSource != null) ? presentationSource.CompositionTarget : null) != null)
			{
				return y * presentationSource.CompositionTarget.TransformToDevice.M22;
			}
			return DpiHelper.TransformToDeviceY(y, dpiScaleY);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00007770 File Offset: 0x00005970
		public static double TransformToDeviceX(Visual visual, double x, double dpiScaleX)
		{
			PresentationSource presentationSource = PresentationSource.FromVisual(visual);
			if (((presentationSource != null) ? presentationSource.CompositionTarget : null) != null)
			{
				return x * presentationSource.CompositionTarget.TransformToDevice.M11;
			}
			return DpiHelper.TransformToDeviceX(x, dpiScaleX);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000077AF File Offset: 0x000059AF
		public static double TransformToDeviceY(double y, double dpiScaleY)
		{
			return y * dpiScaleY / 96.0;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000077AF File Offset: 0x000059AF
		public static double TransformToDeviceX(double x, double dpiScaleX)
		{
			return x * dpiScaleX / 96.0;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000077BE File Offset: 0x000059BE
		public static DpiScale GetDpi(Visual visual)
		{
			return VisualTreeHelper.GetDpi(visual);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000077C6 File Offset: 0x000059C6
		internal static DpiScale GetDpi(this Window window)
		{
			return DpiHelper.GetDpi(window);
		}

		// Token: 0x040000C9 RID: 201
		[ThreadStatic]
		private static Matrix _transformToDevice;

		// Token: 0x040000CA RID: 202
		[ThreadStatic]
		private static Matrix _transformToDip;
	}
}
