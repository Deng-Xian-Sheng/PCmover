using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200007B RID: 123
	internal class cp : AreaDimensions
	{
		// Token: 0x060005AC RID: 1452 RVA: 0x00054EE3 File Offset: 0x00053EE3
		internal cp(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5, float A_6) : base(new Dimensions(A_1, A_2, A_1 + A_3 * A_5, A_2 + A_4 * A_6))
		{
			this.a = A_0;
			this.b = A_5;
			this.c = A_6;
			this.d = A_4;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00054F24 File Offset: 0x00053F24
		public override float GetPdfY(float y)
		{
			return this.d - y;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00054F40 File Offset: 0x00053F40
		public override float GetPdfX(float x)
		{
			return x;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00054F54 File Offset: 0x00053F54
		internal override float az()
		{
			return this.b * this.a.az();
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00054F78 File Offset: 0x00053F78
		internal override float a0()
		{
			return this.c * this.a.a0();
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00054F9C File Offset: 0x00053F9C
		internal override AreaDimensions ay()
		{
			return this.a;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00054FB4 File Offset: 0x00053FB4
		internal override float aw(float A_0)
		{
			return this.a.aw(base.Edge.Left) + A_0 * this.b;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00054FE8 File Offset: 0x00053FE8
		internal override float ax(float A_0)
		{
			return this.a.ax(base.Edge.Top) - A_0 * this.c;
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0005501C File Offset: 0x0005401C
		internal override void a1(OperatorWriter A_0)
		{
			A_0.Write_q_(true);
			A_0.Write_cm(this.a.GetPdfX(base.Edge.Left), this.a.GetPdfY(base.Edge.Bottom));
			A_0.Write_cm(this.b, 0f, 0f, this.c);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00055082 File Offset: 0x00054082
		internal override void a2(OperatorWriter A_0)
		{
			A_0.Write_Q(true);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x00055090 File Offset: 0x00054090
		internal override float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			return this.aw(A_1) - A_0.LeftMargin;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000550B0 File Offset: 0x000540B0
		internal override float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			return A_0.Height - this.ax(A_2) - A_0.TopMargin;
		}

		// Token: 0x0400030F RID: 783
		private AreaDimensions a;

		// Token: 0x04000310 RID: 784
		private float b;

		// Token: 0x04000311 RID: 785
		private float c;

		// Token: 0x04000312 RID: 786
		private float d;
	}
}
