using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200007E RID: 126
	internal class cs : AreaDimensions
	{
		// Token: 0x060005D0 RID: 1488 RVA: 0x000553CC File Offset: 0x000543CC
		internal cs(AreaDimensions A_0, float A_1, float A_2, float A_3) : base(new Dimensions(-A_1, 0f, 0f, A_2))
		{
			this.a = A_0;
			double num = (double)(-(double)A_3) * 0.017453292519943295;
			this.b = (float)Math.Cos(num);
			this.c = (float)Math.Sin(num);
			this.d = -this.c;
			this.e = this.b;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00055440 File Offset: 0x00054440
		internal cs(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5, float A_6) : base(new Dimensions(-A_1, 0f, 0f, A_2))
		{
			this.a = A_0;
			this.b = A_3;
			this.c = A_4;
			this.d = A_5;
			this.e = A_6;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00055490 File Offset: 0x00054490
		internal override float az()
		{
			return this.a.az();
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x000554B0 File Offset: 0x000544B0
		internal override float a0()
		{
			return this.a.a0();
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x000554D0 File Offset: 0x000544D0
		internal override AreaDimensions ay()
		{
			return this.a;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x000554E8 File Offset: 0x000544E8
		internal override float aw(float A_0)
		{
			throw new GeneratorException("GetPageX cannot be used when the dimensions are rotated.");
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x000554F5 File Offset: 0x000544F5
		internal override float ax(float A_0)
		{
			throw new GeneratorException("GetPageX cannot be used when the dimensions are rotated.");
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00055504 File Offset: 0x00054504
		internal override void a1(OperatorWriter A_0)
		{
			A_0.Write_q_(true);
			A_0.Write_cm(this.a.GetPdfX(-base.Edge.Left), this.a.GetPdfY(base.Edge.Bottom));
			A_0.Write_cm(this.b, this.c, this.d, this.e);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0005556D File Offset: 0x0005456D
		internal override void a2(OperatorWriter A_0)
		{
			A_0.Write_Q(true);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00055578 File Offset: 0x00054578
		internal override float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			return this.ay().a3(A_0, A_1, A_2);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00055598 File Offset: 0x00054598
		internal override float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			return this.ay().a4(A_0, A_1, A_2);
		}

		// Token: 0x0400031C RID: 796
		private AreaDimensions a;

		// Token: 0x0400031D RID: 797
		private float b;

		// Token: 0x0400031E RID: 798
		private float c;

		// Token: 0x0400031F RID: 799
		private float d;

		// Token: 0x04000320 RID: 800
		private float e;
	}
}
