using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B9 RID: 1977
	public class XAxisLabel : AxisLabel
	{
		// Token: 0x060050B6 RID: 20662 RVA: 0x002830C3 File Offset: 0x002820C3
		internal XAxisLabel(string A_0) : base(A_0)
		{
		}

		// Token: 0x060050B7 RID: 20663 RVA: 0x002830CF File Offset: 0x002820CF
		internal XAxisLabel(string A_0, Font A_1, float A_2, Color A_3) : base(A_0, A_1, A_2, A_3)
		{
		}

		// Token: 0x060050B8 RID: 20664 RVA: 0x002830E0 File Offset: 0x002820E0
		internal void a(PageWriter A_0, PlotArea A_1, XAxis A_2, float A_3, int A_4, float A_5, float A_6, bool A_7)
		{
			TextLineList textLineList = base.e();
			Font font = base.Font;
			float fontSize = base.FontSize;
			float num = -A_6;
			if (A_4 < -360 || A_4 > 360)
			{
				A_4 %= 360;
			}
			if (A_4 < 0)
			{
				A_4 += 360;
			}
			textLineList = font.GetTextLines(base.Text.ToCharArray(), base.b(), base.c(), fontSize);
			if (textLineList.Width > base.Font.GetTextWidth(base.Text.ToCharArray(), fontSize) && textLineList.Count == 1)
			{
				textLineList.Width = base.Font.GetTextWidth(base.Text.ToCharArray(), fontSize);
				textLineList.Height = textLineList.GetRequiredHeight(0);
			}
			else
			{
				textLineList.Height = textLineList.GetRequiredHeight(0);
			}
			if (!A_7)
			{
				textLineList.Height = textLineList.GetTextHeight(1);
			}
			float num2 = this.a(A_1, A_2, A_3);
			float num3 = 0f;
			if (A_2.LabelPosition == XAxisLabelPosition.Automatic)
			{
				if (A_2.AnchorType == XAxisAnchorType.Floating || A_2.AnchorType == XAxisAnchorType.Bottom)
				{
					A_2.LabelPosition = XAxisLabelPosition.BelowXAxis;
				}
				else if (A_2.AnchorType == XAxisAnchorType.Top)
				{
					A_2.LabelPosition = XAxisLabelPosition.AboveXAxis;
				}
			}
			switch (A_2.LabelPosition)
			{
			case XAxisLabelPosition.BelowPlotArea:
				num3 = this.d(A_1, A_2);
				break;
			case XAxisLabelPosition.AbovePlotArea:
				num3 = this.c(A_1, A_2);
				break;
			case XAxisLabelPosition.BelowXAxis:
				num3 = this.b(A_1, A_2);
				break;
			case XAxisLabelPosition.AboveXAxis:
				num3 = this.a(A_1, A_2);
				break;
			case XAxisLabelPosition.Automatic:
				num3 = this.e(A_1, A_2);
				break;
			}
			if (A_2.LabelPosition == XAxisLabelPosition.BelowPlotArea || A_2.LabelPosition == XAxisLabelPosition.BelowXAxis)
			{
				if (A_4 == 90)
				{
					num2 += textLineList.GetTextHeight() / 2f;
				}
				else if (A_4 == 180)
				{
					num2 += textLineList.Width / 2f;
					num3 += textLineList.Height;
				}
				else if (A_4 == 270)
				{
					num2 -= textLineList.GetTextHeight() / 2f;
					num3 += textLineList.Width;
				}
				else if (A_4 == 360 || A_4 == 0)
				{
					num2 -= textLineList.Width / 2f;
				}
				else if (A_4 < 90 && A_4 > 0)
				{
					num2 += (1f - A_5) * (base.Font.GetDescender(fontSize) * -1f);
				}
				else if (A_4 > 90 && A_4 < 180)
				{
					num3 += A_5 * -1f * textLineList.Height;
					num2 += num * textLineList.Height;
					num2 -= (1f - -1f * A_5) * (base.Font.GetDescender(fontSize) * -1f);
					num3 -= (1f - -1f * A_6) * (base.Font.GetDescender(fontSize) * -1f);
				}
				else if (A_4 > 180 && A_4 < 270)
				{
					num3 += (float)((double)(-1f * A_5) * ((double)textLineList.Height * 1.1));
					num2 += -1f * A_5 * textLineList.Width;
					num3 += A_6 * textLineList.Width;
					num2 -= (float)((double)(A_6 * font.GetAscender(fontSize)) * 1.5);
				}
				else if (A_4 > 270 && A_4 < 360)
				{
					num3 += A_6 * textLineList.Width;
					num2 -= A_5 * textLineList.Width;
					num2 -= 1f - A_5;
					num3 -= (float)((double)(1f - A_6) * ((double)(-1f * font.GetDescender(fontSize)) * 1.5));
				}
			}
			else if (A_2.LabelPosition == XAxisLabelPosition.AbovePlotArea || A_2.LabelPosition == XAxisLabelPosition.AboveXAxis)
			{
				num3 += textLineList.Height;
				if (A_4 == 90)
				{
					num2 += textLineList.Height / 2f;
					num3 -= textLineList.Width + 1f;
				}
				else if (A_4 == 180)
				{
					num2 += textLineList.Width / 2f;
				}
				else if (A_4 == 270)
				{
					num2 -= textLineList.Height / 2f;
					num3 -= 1f;
				}
				else if (A_4 == 360 || A_4 == 0)
				{
					num2 -= textLineList.Width / 2f;
					num3 -= textLineList.Height + 1.5f;
				}
				else if (A_4 < 90 && A_4 > 0)
				{
					num2 -= A_5 * textLineList.Width;
					num3 -= -1f * A_6 * textLineList.Width;
					num2 += -1f * A_6 * textLineList.Height;
					num3 -= (float)((double)A_5 * ((double)textLineList.Height * 1.2));
				}
				else if (A_4 > 90 && A_4 < 180)
				{
					num3 -= num * (textLineList.Width + 1f);
					num2 += -1f * A_5 * textLineList.Width;
					num2 += (float)((double)((1f + A_5) * (-1f * font.GetDescender(fontSize))) * 1.6);
					num3 += (1f + A_6) * (-1f * font.GetDescender(fontSize));
				}
				else if (A_4 > 180 && A_4 < 270)
				{
					num2 -= (1f + A_5) * (-1f * font.GetDescender(fontSize)) / 2f;
					num3 -= (1f + A_5) * (-1f * font.GetDescender(fontSize)) / 2f;
				}
				else if (A_4 > 270 && A_4 < 360)
				{
					num3 -= A_5 * textLineList.Height + A_6 * (-1f * font.GetDescender(fontSize)) / 2f;
					num2 -= A_6 * textLineList.Height - A_6 * (-1f * font.GetDescender(fontSize));
				}
			}
			A_0.SetDimensionsSimpleRotate(num2, num3, A_5, A_6, num, A_5);
			textLineList.ja(A_0, num2, num3, TextAlign.Left, base.TextColor, null, 0f, false, false, false);
			A_0.ResetDimensions();
		}

		// Token: 0x060050B9 RID: 20665 RVA: 0x00283874 File Offset: 0x00282874
		private float a(PlotArea A_0, XAxis A_1, float A_2)
		{
			return A_0.X + A_1.s() * A_1.g() + A_1.g() * A_2;
		}

		// Token: 0x060050BA RID: 20666 RVA: 0x002838A4 File Offset: 0x002828A4
		private float e(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y - base.c() - A_1.b(A_1.AnchorType) - A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x060050BB RID: 20667 RVA: 0x00283920 File Offset: 0x00282920
		private float d(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y + A_0.Height + A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x060050BC RID: 20668 RVA: 0x00283990 File Offset: 0x00282990
		private float c(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
				result = A_0.Y - base.c() - A_1.LabelOffset;
				break;
			case XAxisAnchorType.Top:
			case XAxisAnchorType.Floating:
				result = A_0.Y - base.c() - A_1.b(A_1.AnchorType) - A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x060050BD RID: 20669 RVA: 0x00283A00 File Offset: 0x00282A00
		private float b(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
				result = A_0.Y + A_0.Height + A_1.b(A_1.AnchorType) + A_1.LabelOffset - A_1.Offset;
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y + A_1.b(A_1.AnchorType) + A_1.LabelOffset - A_1.Offset;
				break;
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height - A_1.Offset * (A_0.j().g() / A_0.j().t()) - A_0.j().h() * A_0.j().g() - A_0.j().s() * A_0.j().g() + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x060050BE RID: 20670 RVA: 0x00283AFC File Offset: 0x00282AFC
		private float a(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
				result = A_0.Y + A_0.Height - base.c() - A_1.b(A_1.AnchorType) - A_1.LabelOffset - A_1.Offset;
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y - base.c() - A_1.b(A_1.AnchorType) - A_1.LabelOffset - A_1.Offset;
				break;
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height - A_1.Offset * (A_0.j().g() / A_0.j().t()) - A_0.j().h() * A_0.j().g() - A_0.j().s() * A_0.j().g() - A_1.b(A_1.AnchorType) - A_1.LabelOffset - base.c();
				break;
			}
			return result;
		}
	}
}
