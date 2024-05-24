using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200007F RID: 127
	internal class ct : AreaDimensions
	{
		// Token: 0x060005DB RID: 1499 RVA: 0x000555B8 File Offset: 0x000545B8
		internal ct(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7) : base(new Dimensions(A_1, A_2, A_1 + A_3, A_1 + A_4))
		{
			this.a = A_0;
			double num = (double)(-(double)A_5) * 0.017453292519943295;
			this.b = (float)Math.Cos(num);
			this.c = (float)Math.Sin(num);
			this.d = -this.c;
			this.e = this.b;
			this.f = A_6;
			this.g = A_7;
			this.h = A_4;
			this.i = -num;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00055648 File Offset: 0x00054648
		internal ct(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, float A_8, float A_9, float A_10) : base(new Dimensions(A_1, A_2, A_1 + A_3, A_1 + A_4))
		{
			this.a = A_0;
			this.b = A_5;
			this.c = A_6;
			this.d = A_7;
			this.e = A_8;
			this.f = A_9;
			this.g = A_10;
			this.h = A_4;
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000556AC File Offset: 0x000546AC
		public override float GetPdfY(float y)
		{
			return this.h - y;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x000556C8 File Offset: 0x000546C8
		public override float GetPdfX(float x)
		{
			return x;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x000556DC File Offset: 0x000546DC
		internal override float az()
		{
			return this.f * this.a.az();
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00055700 File Offset: 0x00054700
		internal override float a0()
		{
			return this.g * this.a.a0();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00055724 File Offset: 0x00054724
		internal override AreaDimensions ay()
		{
			return this.a;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0005573C File Offset: 0x0005473C
		internal override float aw(float A_0)
		{
			throw new GeneratorException("GetPageX cannot be used when the dimensions are rotated.");
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00055749 File Offset: 0x00054749
		internal override float ax(float A_0)
		{
			throw new GeneratorException("GetPageY cannot be used when the dimensions are rotated.");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00055758 File Offset: 0x00054758
		internal override void a1(OperatorWriter A_0)
		{
			float num = this.h * this.g;
			float xOffset = num * this.c + this.a.GetPdfX(base.Edge.Left);
			float yOffset = num - num * this.e + this.a.GetPdfY(base.Edge.Top + num);
			A_0.Write_q_(true);
			A_0.Write_cm(xOffset, yOffset);
			A_0.Write_cm(this.b, this.c, this.d, this.e);
			A_0.Write_cm(this.f, 0f, 0f, this.g);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00055805 File Offset: 0x00054805
		internal override void a2(OperatorWriter A_0)
		{
			A_0.Write_Q(true);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00055810 File Offset: 0x00054810
		internal override float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			return base.Body.Left + A_1 * this.az() * (float)Math.Cos(this.i) - A_2 * this.a0() * (float)Math.Sin(this.i);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0005585C File Offset: 0x0005485C
		internal override float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			return base.Body.Top + A_1 * this.az() * (float)Math.Sin(this.i) + A_2 * this.a0() * (float)Math.Cos(this.i);
		}

		// Token: 0x04000321 RID: 801
		private AreaDimensions a;

		// Token: 0x04000322 RID: 802
		private float b;

		// Token: 0x04000323 RID: 803
		private float c;

		// Token: 0x04000324 RID: 804
		private float d;

		// Token: 0x04000325 RID: 805
		private float e;

		// Token: 0x04000326 RID: 806
		private float f;

		// Token: 0x04000327 RID: 807
		private float g;

		// Token: 0x04000328 RID: 808
		private float h;

		// Token: 0x04000329 RID: 809
		private double i;
	}
}
