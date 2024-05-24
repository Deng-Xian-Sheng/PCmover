using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000025 RID: 37
	public sealed class ClipBorder : Decorator
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00003DCC File Offset: 0x00001FCC
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00003DDE File Offset: 0x00001FDE
		public Thickness BorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(ClipBorder.BorderThicknessProperty);
			}
			set
			{
				base.SetValue(ClipBorder.BorderThicknessProperty, value);
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003DF1 File Offset: 0x00001FF1
		private static bool OnValidateThickness(object value)
		{
			return ((Thickness)value).IsValid(false, false, false, false);
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00003E02 File Offset: 0x00002002
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00003E14 File Offset: 0x00002014
		public Thickness Padding
		{
			get
			{
				return (Thickness)base.GetValue(ClipBorder.PaddingProperty);
			}
			set
			{
				base.SetValue(ClipBorder.PaddingProperty, value);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00003E27 File Offset: 0x00002027
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00003E39 File Offset: 0x00002039
		public CornerRadius CornerRadius
		{
			get
			{
				return (CornerRadius)base.GetValue(ClipBorder.CornerRadiusProperty);
			}
			set
			{
				base.SetValue(ClipBorder.CornerRadiusProperty, value);
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003E4C File Offset: 0x0000204C
		private static bool OnValidateCornerRadius(object value)
		{
			return ((CornerRadius)value).IsValid(false, false, false, false);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003E5D File Offset: 0x0000205D
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003E6F File Offset: 0x0000206F
		public Brush BorderBrush
		{
			get
			{
				return (Brush)base.GetValue(ClipBorder.BorderBrushProperty);
			}
			set
			{
				base.SetValue(ClipBorder.BorderBrushProperty, value);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00003E7D File Offset: 0x0000207D
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00003E8F File Offset: 0x0000208F
		public Brush Background
		{
			get
			{
				return (Brush)base.GetValue(ClipBorder.BackgroundProperty);
			}
			set
			{
				base.SetValue(ClipBorder.BackgroundProperty, value);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00003E9D File Offset: 0x0000209D
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00003EAF File Offset: 0x000020AF
		public bool OptimizeClipRendering
		{
			get
			{
				return (bool)base.GetValue(ClipBorder.OptimizeClipRenderingProperty);
			}
			set
			{
				base.SetValue(ClipBorder.OptimizeClipRenderingProperty, value);
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003EC4 File Offset: 0x000020C4
		protected override Size MeasureOverride(Size constraint)
		{
			UIElement child = this.Child;
			Size result = default(Size);
			Size size = this.BorderThickness.CollapseThickness();
			Size size2 = this.Padding.CollapseThickness();
			if (child != null)
			{
				Size size3 = new Size(size.Width + size2.Width, size.Height + size2.Height);
				Size availableSize = new Size(Math.Max(0.0, constraint.Width - size3.Width), Math.Max(0.0, constraint.Height - size3.Height));
				child.Measure(availableSize);
				Size desiredSize = child.DesiredSize;
				result.Width = desiredSize.Width + size3.Width;
				result.Height = desiredSize.Height + size3.Height;
			}
			else
			{
				result = new Size(size.Width + size2.Width, size.Height + size2.Height);
			}
			return result;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003FC8 File Offset: 0x000021C8
		protected override Size ArrangeOverride(Size finalSize)
		{
			Thickness borderThickness = this.BorderThickness;
			Rect rect = new Rect(finalSize);
			Rect rect2 = rect.Deflate(borderThickness);
			CornerRadius cornerRadius = this.CornerRadius;
			Thickness padding = this.Padding;
			Rect finalRect = rect2.Deflate(padding);
			if (!rect.Width.IsZero() && !rect.Height.IsZero())
			{
				ClipBorder.BorderInfo borderInfo = new ClipBorder.BorderInfo(cornerRadius, borderThickness, default(Thickness), true);
				StreamGeometry streamGeometry = new StreamGeometry();
				using (StreamGeometryContext streamGeometryContext = streamGeometry.Open())
				{
					ClipBorder.GenerateGeometry(streamGeometryContext, rect, borderInfo);
				}
				streamGeometry.Freeze();
				this._borderGeometryCache = streamGeometry;
			}
			else
			{
				this._borderGeometryCache = null;
			}
			if (!rect2.Width.IsZero() && !rect2.Height.IsZero())
			{
				ClipBorder.BorderInfo borderInfo2 = new ClipBorder.BorderInfo(cornerRadius, borderThickness, default(Thickness), false);
				StreamGeometry streamGeometry2 = new StreamGeometry();
				using (StreamGeometryContext streamGeometryContext2 = streamGeometry2.Open())
				{
					ClipBorder.GenerateGeometry(streamGeometryContext2, rect2, borderInfo2);
				}
				streamGeometry2.Freeze();
				this._backgroundGeometryCache = streamGeometry2;
			}
			else
			{
				this._backgroundGeometryCache = null;
			}
			UIElement child = this.Child;
			if (child != null)
			{
				child.Arrange(finalRect);
				StreamGeometry streamGeometry3 = new StreamGeometry();
				ClipBorder.BorderInfo borderInfo3 = new ClipBorder.BorderInfo(cornerRadius, borderThickness, padding, false);
				using (StreamGeometryContext streamGeometryContext3 = streamGeometry3.Open())
				{
					ClipBorder.GenerateGeometry(streamGeometryContext3, new Rect(0.0, 0.0, finalRect.Width, finalRect.Height), borderInfo3);
				}
				streamGeometry3.Freeze();
				child.Clip = streamGeometry3;
			}
			return finalSize;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000418C File Offset: 0x0000238C
		protected override void OnRender(DrawingContext dc)
		{
			Thickness borderThickness = this.BorderThickness;
			Brush borderBrush = this.BorderBrush;
			Brush background = this.Background;
			StreamGeometry borderGeometryCache = this._borderGeometryCache;
			StreamGeometry backgroundGeometryCache = this._backgroundGeometryCache;
			if (this.OptimizeClipRendering)
			{
				dc.DrawGeometry(borderBrush, null, borderGeometryCache);
				return;
			}
			if (borderBrush == null || borderThickness.IsZero() || background == null)
			{
				if (borderBrush != null && !borderThickness.IsZero())
				{
					if (borderGeometryCache != null && backgroundGeometryCache != null)
					{
						Geometry outlinedPathGeometry = borderGeometryCache.GetOutlinedPathGeometry();
						PathGeometry outlinedPathGeometry2 = backgroundGeometryCache.GetOutlinedPathGeometry();
						PathGeometry geometry = Geometry.Combine(outlinedPathGeometry, outlinedPathGeometry2, GeometryCombineMode.Exclude, null);
						dc.DrawGeometry(borderBrush, null, geometry);
					}
					else
					{
						dc.DrawGeometry(borderBrush, null, borderGeometryCache);
					}
				}
				if (background != null)
				{
					dc.DrawGeometry(background, null, backgroundGeometryCache);
				}
				return;
			}
			if (borderBrush.IsEqualTo(background))
			{
				dc.DrawGeometry(borderBrush, null, borderGeometryCache);
				return;
			}
			if (borderBrush.IsOpaqueSolidColorBrush() && background.IsOpaqueSolidColorBrush())
			{
				dc.DrawGeometry(borderBrush, null, borderGeometryCache);
				dc.DrawGeometry(background, null, backgroundGeometryCache);
				return;
			}
			if (borderBrush.IsOpaqueSolidColorBrush())
			{
				if (borderGeometryCache == null || backgroundGeometryCache == null)
				{
					return;
				}
				Geometry outlinedPathGeometry3 = borderGeometryCache.GetOutlinedPathGeometry();
				PathGeometry outlinedPathGeometry4 = backgroundGeometryCache.GetOutlinedPathGeometry();
				PathGeometry geometry2 = Geometry.Combine(outlinedPathGeometry3, outlinedPathGeometry4, GeometryCombineMode.Exclude, null);
				dc.DrawGeometry(background, null, borderGeometryCache);
				dc.DrawGeometry(borderBrush, null, geometry2);
				return;
			}
			else
			{
				if (borderGeometryCache == null || backgroundGeometryCache == null)
				{
					return;
				}
				Geometry outlinedPathGeometry5 = borderGeometryCache.GetOutlinedPathGeometry();
				PathGeometry outlinedPathGeometry6 = backgroundGeometryCache.GetOutlinedPathGeometry();
				PathGeometry geometry3 = Geometry.Combine(outlinedPathGeometry5, outlinedPathGeometry6, GeometryCombineMode.Exclude, null);
				dc.DrawGeometry(borderBrush, null, geometry3);
				dc.DrawGeometry(background, null, backgroundGeometryCache);
				return;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000042E0 File Offset: 0x000024E0
		private static void GenerateGeometry(StreamGeometryContext ctx, Rect rect, ClipBorder.BorderInfo borderInfo)
		{
			Point point = new Point(borderInfo.LeftTop, 0.0);
			Point point2 = new Point(rect.Width - borderInfo.RightTop, 0.0);
			Point point3 = new Point(rect.Width, borderInfo.TopRight);
			Point point4 = new Point(rect.Width, rect.Height - borderInfo.BottomRight);
			Point point5 = new Point(rect.Width - borderInfo.RightBottom, rect.Height);
			Point point6 = new Point(borderInfo.LeftBottom, rect.Height);
			Point point7 = new Point(0.0, rect.Height - borderInfo.BottomLeft);
			Point point8 = new Point(0.0, borderInfo.TopLeft);
			if (point.X > point2.X)
			{
				double x = borderInfo.LeftTop / (borderInfo.LeftTop + borderInfo.RightTop) * rect.Width;
				point.X = x;
				point2.X = x;
			}
			if (point3.Y > point4.Y)
			{
				double y = borderInfo.TopRight / (borderInfo.TopRight + borderInfo.BottomRight) * rect.Height;
				point3.Y = y;
				point4.Y = y;
			}
			if (point6.X > point5.X)
			{
				double x2 = borderInfo.LeftBottom / (borderInfo.LeftBottom + borderInfo.RightBottom) * rect.Width;
				point5.X = x2;
				point6.X = x2;
			}
			if (point8.Y > point7.Y)
			{
				double y2 = borderInfo.TopLeft / (borderInfo.TopLeft + borderInfo.BottomLeft) * rect.Height;
				point7.Y = y2;
				point8.Y = y2;
			}
			double x3 = rect.TopLeft.X;
			double y3 = rect.TopLeft.Y;
			Vector vector = new Vector(x3, y3);
			point += vector;
			point2 += vector;
			point3 += vector;
			point4 += vector;
			point5 += vector;
			point6 += vector;
			point7 += vector;
			point8 += vector;
			ctx.BeginFigure(point, true, true);
			ctx.LineTo(point2, true, false);
			double num = rect.TopRight.X - point2.X;
			double num2 = point3.Y - rect.TopRight.Y;
			if (!num.IsZero() || !num2.IsZero())
			{
				ctx.ArcTo(point3, new Size(num, num2), 0.0, false, SweepDirection.Clockwise, true, false);
			}
			ctx.LineTo(point4, true, false);
			num = rect.BottomRight.X - point5.X;
			num2 = rect.BottomRight.Y - point4.Y;
			if (!num.IsZero() || !num2.IsZero())
			{
				ctx.ArcTo(point5, new Size(num, num2), 0.0, false, SweepDirection.Clockwise, true, false);
			}
			ctx.LineTo(point6, true, false);
			num = point6.X - rect.BottomLeft.X;
			num2 = rect.BottomLeft.Y - point7.Y;
			if (!num.IsZero() || !num2.IsZero())
			{
				ctx.ArcTo(point7, new Size(num, num2), 0.0, false, SweepDirection.Clockwise, true, false);
			}
			ctx.LineTo(point8, true, false);
			num = point.X - rect.TopLeft.X;
			num2 = point8.Y - rect.TopLeft.Y;
			if (!num.IsZero() || !num2.IsZero())
			{
				ctx.ArcTo(point, new Size(num, num2), 0.0, false, SweepDirection.Clockwise, true, false);
			}
		}

		// Token: 0x04000031 RID: 49
		private StreamGeometry _backgroundGeometryCache;

		// Token: 0x04000032 RID: 50
		private StreamGeometry _borderGeometryCache;

		// Token: 0x04000033 RID: 51
		public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(ClipBorder), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ClipBorder.OnValidateThickness));

		// Token: 0x04000034 RID: 52
		public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(ClipBorder), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ClipBorder.OnValidateThickness));

		// Token: 0x04000035 RID: 53
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ClipBorder), new FrameworkPropertyMetadata(default(CornerRadius), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ClipBorder.OnValidateCornerRadius));

		// Token: 0x04000036 RID: 54
		public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(ClipBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

		// Token: 0x04000037 RID: 55
		public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ClipBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

		// Token: 0x04000038 RID: 56
		public static readonly DependencyProperty OptimizeClipRenderingProperty = DependencyProperty.Register("OptimizeClipRendering", typeof(bool), typeof(ClipBorder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x020000CE RID: 206
		private struct BorderInfo
		{
			// Token: 0x06000A75 RID: 2677 RVA: 0x000284D4 File Offset: 0x000266D4
			internal BorderInfo(CornerRadius corners, Thickness borders, Thickness padding, bool isOuterBorder)
			{
				double num = 0.5 * borders.Left + padding.Left;
				double num2 = 0.5 * borders.Top + padding.Top;
				double num3 = 0.5 * borders.Right + padding.Right;
				double num4 = 0.5 * borders.Bottom + padding.Bottom;
				if (!isOuterBorder)
				{
					this.LeftTop = Math.Max(0.0, corners.TopLeft - num);
					this.TopLeft = Math.Max(0.0, corners.TopLeft - num2);
					this.TopRight = Math.Max(0.0, corners.TopRight - num2);
					this.RightTop = Math.Max(0.0, corners.TopRight - num3);
					this.RightBottom = Math.Max(0.0, corners.BottomRight - num3);
					this.BottomRight = Math.Max(0.0, corners.BottomRight - num4);
					this.BottomLeft = Math.Max(0.0, corners.BottomLeft - num4);
					this.LeftBottom = Math.Max(0.0, corners.BottomLeft - num);
					return;
				}
				if (corners.TopLeft.IsZero())
				{
					this.LeftTop = (this.TopLeft = 0.0);
				}
				else
				{
					this.LeftTop = corners.TopLeft + num;
					this.TopLeft = corners.TopLeft + num2;
				}
				if (corners.TopRight.IsZero())
				{
					this.TopRight = (this.RightTop = 0.0);
				}
				else
				{
					this.TopRight = corners.TopRight + num2;
					this.RightTop = corners.TopRight + num3;
				}
				if (corners.BottomRight.IsZero())
				{
					this.RightBottom = (this.BottomRight = 0.0);
				}
				else
				{
					this.RightBottom = corners.BottomRight + num3;
					this.BottomRight = corners.BottomRight + num4;
				}
				if (corners.BottomLeft.IsZero())
				{
					this.BottomLeft = (this.LeftBottom = 0.0);
					return;
				}
				this.BottomLeft = corners.BottomLeft + num4;
				this.LeftBottom = corners.BottomLeft + num;
			}

			// Token: 0x04000492 RID: 1170
			internal readonly double LeftTop;

			// Token: 0x04000493 RID: 1171
			internal readonly double TopLeft;

			// Token: 0x04000494 RID: 1172
			internal readonly double TopRight;

			// Token: 0x04000495 RID: 1173
			internal readonly double RightTop;

			// Token: 0x04000496 RID: 1174
			internal readonly double RightBottom;

			// Token: 0x04000497 RID: 1175
			internal readonly double BottomRight;

			// Token: 0x04000498 RID: 1176
			internal readonly double BottomLeft;

			// Token: 0x04000499 RID: 1177
			internal readonly double LeftBottom;
		}
	}
}
