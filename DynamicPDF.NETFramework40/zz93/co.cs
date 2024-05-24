using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200007A RID: 122
	internal class co : AreaDimensions
	{
		// Token: 0x0600059F RID: 1439 RVA: 0x00054C3C File Offset: 0x00053C3C
		internal co(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5) : base(new Dimensions(0f, 0f, A_3, A_4))
		{
			this.a = A_0;
			this.h = A_1;
			this.i = A_2;
			double num = (double)(-(double)A_5) * 0.017453292519943295;
			this.b = (float)Math.Cos(num);
			this.c = (float)Math.Sin(num);
			this.d = -this.c;
			this.e = this.b;
			this.f = A_4;
			this.g = -num;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00054CCC File Offset: 0x00053CCC
		internal co(AreaDimensions A_0, float A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, float A_8) : base(new Dimensions(0f, 0f, A_3, A_4))
		{
			this.h = A_1;
			this.i = A_2;
			this.a = A_0;
			this.b = A_5;
			this.c = A_6;
			this.d = A_7;
			this.e = A_8;
			this.f = A_4;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00054D34 File Offset: 0x00053D34
		public override float GetPdfY(float y)
		{
			return this.f - y;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00054D50 File Offset: 0x00053D50
		public override float GetPdfX(float x)
		{
			return x;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00054D64 File Offset: 0x00053D64
		internal override AreaDimensions ay()
		{
			return this.a;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00054D7C File Offset: 0x00053D7C
		internal override float az()
		{
			return this.a.az();
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00054D9C File Offset: 0x00053D9C
		internal override float a0()
		{
			return this.a.a0();
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00054DB9 File Offset: 0x00053DB9
		internal override float aw(float A_0)
		{
			throw new GeneratorException("GetPageX cannot be used when the dimensions are rotated.");
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00054DC6 File Offset: 0x00053DC6
		internal override float ax(float A_0)
		{
			throw new GeneratorException("GetPageY cannot be used when the dimensions are rotated.");
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00054DD4 File Offset: 0x00053DD4
		internal override void a1(OperatorWriter A_0)
		{
			A_0.Write_q_(true);
			float xOffset = this.f * this.c + this.a.GetPdfX(this.h);
			float yOffset = this.f - this.f * this.e + this.a.GetPdfY(this.i + this.f);
			A_0.Write_cm(xOffset, yOffset);
			A_0.Write_cm(this.b, this.c, this.d, this.e);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00054E60 File Offset: 0x00053E60
		internal override void a2(OperatorWriter A_0)
		{
			A_0.Write_Q(true);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00054E6C File Offset: 0x00053E6C
		internal override float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			return base.Body.Left + A_1 * (float)Math.Cos(this.g) - A_2 * (float)Math.Sin(this.g);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00054EA8 File Offset: 0x00053EA8
		internal override float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			return base.Body.Top + A_1 * (float)Math.Sin(this.g) + A_2 * (float)Math.Cos(this.g);
		}

		// Token: 0x04000306 RID: 774
		private AreaDimensions a;

		// Token: 0x04000307 RID: 775
		private float b;

		// Token: 0x04000308 RID: 776
		private float c;

		// Token: 0x04000309 RID: 777
		private float d;

		// Token: 0x0400030A RID: 778
		private float e;

		// Token: 0x0400030B RID: 779
		private float f;

		// Token: 0x0400030C RID: 780
		private double g;

		// Token: 0x0400030D RID: 781
		private float h;

		// Token: 0x0400030E RID: 782
		private float i;
	}
}
