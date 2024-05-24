using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007BF RID: 1983
	public class YAxisLabel : AxisLabel
	{
		// Token: 0x0600510B RID: 20747 RVA: 0x00286733 File Offset: 0x00285733
		internal YAxisLabel(string A_0) : base(A_0)
		{
		}

		// Token: 0x0600510C RID: 20748 RVA: 0x0028673F File Offset: 0x0028573F
		internal YAxisLabel(string A_0, Font A_1, float A_2, Color A_3) : base(A_0, A_1, A_2, A_3)
		{
		}

		// Token: 0x0600510D RID: 20749 RVA: 0x00286750 File Offset: 0x00285750
		private float a(PlotArea A_0, YAxis A_1, float A_2)
		{
			return A_0.Y + A_0.Height - A_1.s() * A_1.g() - A_1.g() * A_2 - base.c() / 2f;
		}

		// Token: 0x0600510E RID: 20750 RVA: 0x00286794 File Offset: 0x00285794
		private float e(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
			case YAxisAnchorType.Floating:
				result = A_0.X - (base.b() + A_1.b(A_1.AnchorType) + A_1.LabelOffset);
				break;
			case YAxisAnchorType.Right:
				result = A_0.X + A_0.Width + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x0600510F RID: 20751 RVA: 0x00286810 File Offset: 0x00285810
		private float d(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
			case YAxisAnchorType.Floating:
				result = A_0.X - (base.b() + A_1.LabelOffset + A_1.b(A_1.AnchorType));
				break;
			case YAxisAnchorType.Right:
				result = A_0.X - (base.b() + A_1.LabelOffset);
				break;
			}
			return result;
		}

		// Token: 0x06005110 RID: 20752 RVA: 0x00286880 File Offset: 0x00285880
		private float c(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
				result = A_0.X + A_0.Width + A_1.LabelOffset;
				break;
			case YAxisAnchorType.Right:
			case YAxisAnchorType.Floating:
				result = A_0.X + A_0.Width + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x06005111 RID: 20753 RVA: 0x002868F0 File Offset: 0x002858F0
		private float b(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
				result = A_0.X + A_1.Offset - (base.b() + A_1.b(A_1.AnchorType) + A_1.LabelOffset);
				break;
			case YAxisAnchorType.Right:
				result = A_0.X + A_0.Width + A_1.Offset - (base.b() + A_1.b(A_1.AnchorType) + A_1.LabelOffset);
				break;
			case YAxisAnchorType.Floating:
				result = A_0.X + A_1.Offset * (A_0.i().g() / A_0.i().t()) + A_0.i().h() * A_0.i().g() + A_0.i().s() * A_0.i().g() - (base.b() + A_1.b(A_1.AnchorType) + A_1.LabelOffset);
				break;
			}
			return result;
		}

		// Token: 0x06005112 RID: 20754 RVA: 0x002869FC File Offset: 0x002859FC
		private float a(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
				result = A_0.X + A_1.Offset + (A_1.b(A_1.AnchorType) + A_1.LabelOffset);
				break;
			case YAxisAnchorType.Right:
				result = A_0.X + A_0.Width + A_1.Offset + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			case YAxisAnchorType.Floating:
				result = A_0.X + A_1.Offset * (A_0.i().g() / A_0.i().t()) + A_0.i().h() * A_0.i().g() + A_0.i().s() * A_0.i().g() + A_1.b(A_1.AnchorType) + A_1.LabelOffset;
				break;
			}
			return result;
		}

		// Token: 0x06005113 RID: 20755 RVA: 0x00286AF4 File Offset: 0x00285AF4
		internal void a(PageWriter A_0, PlotArea A_1, YAxis A_2, float A_3)
		{
			TextLineList textLineList = base.e();
			float a_ = this.a(A_1, A_2, A_3);
			float a_2 = 0f;
			if (A_2.LabelPosition == YAxisLabelPosition.Automatic)
			{
				if (A_2.AnchorType == YAxisAnchorType.Floating || A_2.AnchorType == YAxisAnchorType.Left)
				{
					A_2.LabelPosition = YAxisLabelPosition.LeftOfYAxis;
				}
				else if (A_2.AnchorType == YAxisAnchorType.Right)
				{
					A_2.LabelPosition = YAxisLabelPosition.RightOfYAxis;
				}
			}
			switch (A_2.LabelPosition)
			{
			case YAxisLabelPosition.LeftOfPlotArea:
				a_2 = this.d(A_1, A_2);
				break;
			case YAxisLabelPosition.RightOfPlotArea:
				a_2 = this.c(A_1, A_2);
				break;
			case YAxisLabelPosition.LeftOfYAxis:
				a_2 = this.b(A_1, A_2);
				break;
			case YAxisLabelPosition.RightOfYAxis:
				a_2 = this.a(A_1, A_2);
				break;
			case YAxisLabelPosition.Automatic:
				a_2 = this.e(A_1, A_2);
				break;
			}
			textLineList = base.Font.GetTextLines(base.Text.ToCharArray(), base.b(), base.c(), base.FontSize);
			textLineList.ja(A_0, a_2, a_, TextAlign.Center, base.TextColor, null, 0f, false, false, false);
		}
	}
}
