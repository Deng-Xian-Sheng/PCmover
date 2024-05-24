using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200007C RID: 124
	internal class cq : AreaDimensions
	{
		// Token: 0x060005B8 RID: 1464 RVA: 0x000550D7 File Offset: 0x000540D7
		internal cq(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4) : base(cq.a(A_0, A_1, A_2, A_3, A_4))
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00055104 File Offset: 0x00054104
		internal override float az()
		{
			return this.a.az();
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00055124 File Offset: 0x00054124
		internal override float a0()
		{
			return this.a.a0();
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00055144 File Offset: 0x00054144
		internal override AreaDimensions ay()
		{
			return this.a;
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0005515C File Offset: 0x0005415C
		internal override float aw(float A_0)
		{
			return this.a.aw(A_0) + this.b;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00055184 File Offset: 0x00054184
		internal override float ax(float A_0)
		{
			return this.a.ax(A_0) - this.c;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000551A9 File Offset: 0x000541A9
		internal override void a1(OperatorWriter A_0)
		{
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x000551AC File Offset: 0x000541AC
		internal override void a2(OperatorWriter A_0)
		{
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x000551B0 File Offset: 0x000541B0
		private static Dimensions a(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float pdfX = A_0.GetPdfX(A_1);
			float pdfY = A_0.GetPdfY(A_2);
			float top = pdfY - A_4;
			float right = pdfX + A_3;
			return new Dimensions(pdfX, top, right, pdfY);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x000551E8 File Offset: 0x000541E8
		internal override float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			float result;
			if (this.ay() is PageDimensions)
			{
				A_1 = (result = A_1 + (base.Body.Left - A_0.LeftMargin));
			}
			else
			{
				result = this.ay().a3(A_0, this.b + A_1, this.c + A_2);
			}
			return result;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00055248 File Offset: 0x00054248
		internal override float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			float result;
			if (this.ay() is PageDimensions)
			{
				A_2 = (result = A_2 + (A_0.Height - A_0.TopMargin - base.Body.Bottom));
			}
			else
			{
				result = this.ay().a4(A_0, this.b + A_1, this.c + A_2);
			}
			return result;
		}

		// Token: 0x04000313 RID: 787
		private AreaDimensions a;

		// Token: 0x04000314 RID: 788
		private float b;

		// Token: 0x04000315 RID: 789
		private float c;
	}
}
