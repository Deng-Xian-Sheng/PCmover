using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000026 RID: 38
	public static class Utils
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00004864 File Offset: 0x00002A64
		public static bool IsCloseTo(this double value1, double value2)
		{
			if (value1 == value2)
			{
				return true;
			}
			double num = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.220446049250313E-16;
			double num2 = value1 - value2;
			return -num < num2 && num > num2;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000048A8 File Offset: 0x00002AA8
		public static bool IsLessThan(double value1, double value2)
		{
			return value1 < value2 && !value1.IsCloseTo(value2);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000048BA File Offset: 0x00002ABA
		public static bool IsGreaterThan(this double value1, double value2)
		{
			return value1 > value2 && !value1.IsCloseTo(value2);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000048CC File Offset: 0x00002ACC
		public static bool IsOne(this double value)
		{
			return Math.Abs(value - 1.0) < 2.220446049250313E-15;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000048E9 File Offset: 0x00002AE9
		public static bool IsZero(this double value)
		{
			return Math.Abs(value) < 2.220446049250313E-15;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000048FC File Offset: 0x00002AFC
		public static bool IsCloseTo(this Point point1, Point point2)
		{
			return point1.X.IsCloseTo(point2.X) && point1.Y.IsCloseTo(point2.Y);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004928 File Offset: 0x00002B28
		public static bool IsCloseTo(this Size size1, Size size2)
		{
			return size1.Width.IsCloseTo(size2.Width) && size1.Height.IsCloseTo(size2.Height);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004954 File Offset: 0x00002B54
		public static bool IsCloseTo(this Vector vector1, Vector vector2)
		{
			return vector1.X.IsCloseTo(vector2.X) && vector1.Y.IsCloseTo(vector2.Y);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004980 File Offset: 0x00002B80
		public static bool IsCloseTo(this Rect rect1, Rect rect2)
		{
			if (rect1.IsEmpty)
			{
				return rect2.IsEmpty;
			}
			return !rect2.IsEmpty && rect1.X.IsCloseTo(rect2.X) && rect1.Y.IsCloseTo(rect2.Y) && rect1.Height.IsCloseTo(rect2.Height) && rect1.Width.IsCloseTo(rect2.Width);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000049FC File Offset: 0x00002BFC
		public static bool IsNaN(double value)
		{
			Utils.NanUnion nanUnion = new Utils.NanUnion
			{
				DoubleValue = value
			};
			ulong num = nanUnion.UintValue & 18442240474082181120UL;
			ulong num2 = nanUnion.UintValue & 4503599627370495UL;
			return (num == 9218868437227405312UL || num == 18442240474082181120UL) && num2 > 0UL;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004A5C File Offset: 0x00002C5C
		public static double RoundLayoutValue(double value, double dpiScale)
		{
			double num;
			if (!dpiScale.IsCloseTo(1.0))
			{
				num = Math.Round(value * dpiScale) / dpiScale;
				if (Utils.IsNaN(num) || double.IsInfinity(num) || num.IsCloseTo(1.7976931348623157E+308))
				{
					num = value;
				}
			}
			else
			{
				num = Math.Round(value);
			}
			return num;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public static bool IsValid(this Thickness thick, bool allowNegative, bool allowNaN, bool allowPositiveInfinity, bool allowNegativeInfinity)
		{
			return (allowNegative || (thick.Left >= 0.0 && thick.Right >= 0.0 && thick.Top >= 0.0 && thick.Bottom >= 0.0)) && (allowNaN || (!Utils.IsNaN(thick.Left) && !Utils.IsNaN(thick.Right) && !Utils.IsNaN(thick.Top) && !Utils.IsNaN(thick.Bottom))) && (allowPositiveInfinity || (!double.IsPositiveInfinity(thick.Left) && !double.IsPositiveInfinity(thick.Right) && !double.IsPositiveInfinity(thick.Top) && !double.IsPositiveInfinity(thick.Bottom))) && (allowNegativeInfinity || (!double.IsNegativeInfinity(thick.Left) && !double.IsNegativeInfinity(thick.Right) && !double.IsNegativeInfinity(thick.Top) && !double.IsNegativeInfinity(thick.Bottom)));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004BC7 File Offset: 0x00002DC7
		public static Size CollapseThickness(this Thickness thick)
		{
			return new Size(thick.Left + thick.Right, thick.Top + thick.Bottom);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004BEC File Offset: 0x00002DEC
		public static bool IsZero(this Thickness thick)
		{
			return thick.Left.IsZero() && thick.Top.IsZero() && thick.Right.IsZero() && thick.Bottom.IsZero();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004C28 File Offset: 0x00002E28
		public static bool IsUniform(this Thickness thick)
		{
			return thick.Left.IsCloseTo(thick.Top) && thick.Left.IsCloseTo(thick.Right) && thick.Left.IsCloseTo(thick.Bottom);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004C74 File Offset: 0x00002E74
		public static bool IsValid(this CornerRadius corner, bool allowNegative, bool allowNaN, bool allowPositiveInfinity, bool allowNegativeInfinity)
		{
			return (allowNegative || (corner.TopLeft >= 0.0 && corner.TopRight >= 0.0 && corner.BottomLeft >= 0.0 && corner.BottomRight >= 0.0)) && (allowNaN || (!Utils.IsNaN(corner.TopLeft) && !Utils.IsNaN(corner.TopRight) && !Utils.IsNaN(corner.BottomLeft) && !Utils.IsNaN(corner.BottomRight))) && (allowPositiveInfinity || (!double.IsPositiveInfinity(corner.TopLeft) && !double.IsPositiveInfinity(corner.TopRight) && !double.IsPositiveInfinity(corner.BottomLeft) && !double.IsPositiveInfinity(corner.BottomRight))) && (allowNegativeInfinity || (!double.IsNegativeInfinity(corner.TopLeft) && !double.IsNegativeInfinity(corner.TopRight) && !double.IsNegativeInfinity(corner.BottomLeft) && !double.IsNegativeInfinity(corner.BottomRight)));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004D87 File Offset: 0x00002F87
		public static bool IsZero(this CornerRadius corner)
		{
			return corner.TopLeft.IsZero() && corner.TopRight.IsZero() && corner.BottomRight.IsZero() && corner.BottomLeft.IsZero();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004DC4 File Offset: 0x00002FC4
		public static bool IsUniform(this CornerRadius corner)
		{
			double topLeft = corner.TopLeft;
			return topLeft.IsCloseTo(corner.TopRight) && topLeft.IsCloseTo(corner.BottomLeft) && topLeft.IsCloseTo(corner.BottomRight);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004E08 File Offset: 0x00003008
		public static Rect Deflate(this Rect rect, Thickness thick)
		{
			return new Rect(rect.Left + thick.Left, rect.Top + thick.Top, Math.Max(0.0, rect.Width - thick.Left - thick.Right), Math.Max(0.0, rect.Height - thick.Top - thick.Bottom));
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004E84 File Offset: 0x00003084
		public static Rect Inflate(this Rect rect, Thickness thick)
		{
			return new Rect(rect.Left - thick.Left, rect.Top - thick.Top, Math.Max(0.0, rect.Width + thick.Left + thick.Right), Math.Max(0.0, rect.Height + thick.Top + thick.Bottom));
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004F00 File Offset: 0x00003100
		public static bool IsOpaqueSolidColorBrush(this Brush brush)
		{
			SolidColorBrush solidColorBrush = brush as SolidColorBrush;
			byte? b = (solidColorBrush != null) ? new byte?(solidColorBrush.Color.A) : null;
			return ((b != null) ? new int?((int)b.GetValueOrDefault()) : null) == 255;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004F74 File Offset: 0x00003174
		public static bool IsEqualTo(this Brush brush, Brush otherBrush)
		{
			if (brush.GetType() != otherBrush.GetType())
			{
				return false;
			}
			if (brush == otherBrush)
			{
				return true;
			}
			SolidColorBrush solidColorBrush = brush as SolidColorBrush;
			SolidColorBrush solidColorBrush2 = otherBrush as SolidColorBrush;
			if (solidColorBrush != null && solidColorBrush2 != null)
			{
				return solidColorBrush.Color == solidColorBrush2.Color && solidColorBrush.Opacity.IsCloseTo(solidColorBrush2.Opacity);
			}
			LinearGradientBrush linearGradientBrush = brush as LinearGradientBrush;
			LinearGradientBrush linearGradientBrush2 = otherBrush as LinearGradientBrush;
			if (linearGradientBrush != null && linearGradientBrush2 != null)
			{
				bool flag = linearGradientBrush.ColorInterpolationMode == linearGradientBrush2.ColorInterpolationMode && linearGradientBrush.EndPoint == linearGradientBrush2.EndPoint && linearGradientBrush.MappingMode == linearGradientBrush2.MappingMode && linearGradientBrush.Opacity.IsCloseTo(linearGradientBrush2.Opacity) && linearGradientBrush.StartPoint == linearGradientBrush2.StartPoint && linearGradientBrush.SpreadMethod == linearGradientBrush2.SpreadMethod && linearGradientBrush.GradientStops.Count == linearGradientBrush2.GradientStops.Count;
				if (!flag)
				{
					return false;
				}
				for (int i = 0; i < linearGradientBrush.GradientStops.Count; i++)
				{
					flag = (linearGradientBrush.GradientStops[i].Color == linearGradientBrush2.GradientStops[i].Color && linearGradientBrush.GradientStops[i].Offset.IsCloseTo(linearGradientBrush2.GradientStops[i].Offset));
					if (!flag)
					{
						break;
					}
				}
				return flag;
			}
			else
			{
				RadialGradientBrush radialGradientBrush = brush as RadialGradientBrush;
				RadialGradientBrush radialGradientBrush2 = otherBrush as RadialGradientBrush;
				if (radialGradientBrush == null || radialGradientBrush2 == null)
				{
					ImageBrush imageBrush = brush as ImageBrush;
					ImageBrush imageBrush2 = otherBrush as ImageBrush;
					return imageBrush != null && imageBrush2 != null && (imageBrush.AlignmentX == imageBrush2.AlignmentX && imageBrush.AlignmentY == imageBrush2.AlignmentY && imageBrush.Opacity.IsCloseTo(imageBrush2.Opacity) && imageBrush.Stretch == imageBrush2.Stretch && imageBrush.TileMode == imageBrush2.TileMode && imageBrush.Viewbox == imageBrush2.Viewbox && imageBrush.ViewboxUnits == imageBrush2.ViewboxUnits && imageBrush.Viewport == imageBrush2.Viewport && imageBrush.ViewportUnits == imageBrush2.ViewportUnits) && imageBrush.ImageSource == imageBrush2.ImageSource;
				}
				bool flag2 = radialGradientBrush.ColorInterpolationMode == radialGradientBrush2.ColorInterpolationMode && radialGradientBrush.GradientOrigin == radialGradientBrush2.GradientOrigin && radialGradientBrush.MappingMode == radialGradientBrush2.MappingMode && radialGradientBrush.Opacity.IsCloseTo(radialGradientBrush2.Opacity) && radialGradientBrush.RadiusX.IsCloseTo(radialGradientBrush2.RadiusX) && radialGradientBrush.RadiusY.IsCloseTo(radialGradientBrush2.RadiusY) && radialGradientBrush.SpreadMethod == radialGradientBrush2.SpreadMethod && radialGradientBrush.GradientStops.Count == radialGradientBrush2.GradientStops.Count;
				if (!flag2)
				{
					return false;
				}
				for (int j = 0; j < radialGradientBrush.GradientStops.Count; j++)
				{
					flag2 = (radialGradientBrush.GradientStops[j].Color == radialGradientBrush2.GradientStops[j].Color && radialGradientBrush.GradientStops[j].Offset.IsCloseTo(radialGradientBrush2.GradientStops[j].Offset));
					if (!flag2)
					{
						break;
					}
				}
				return flag2;
			}
		}

		// Token: 0x04000039 RID: 57
		internal const double DBL_EPSILON = 2.220446049250313E-16;

		// Token: 0x0400003A RID: 58
		internal const float FLT_MIN = 1.1754944E-38f;

		// Token: 0x020000CF RID: 207
		[StructLayout(LayoutKind.Explicit)]
		private struct NanUnion
		{
			// Token: 0x0400049A RID: 1178
			[FieldOffset(0)]
			internal double DoubleValue;

			// Token: 0x0400049B RID: 1179
			[FieldOffset(0)]
			internal ulong UintValue;
		}
	}
}
