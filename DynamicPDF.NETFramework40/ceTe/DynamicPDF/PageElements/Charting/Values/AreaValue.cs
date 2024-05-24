using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008CA RID: 2250
	public class AreaValue
	{
		// Token: 0x06005C75 RID: 23669 RVA: 0x00345DD5 File Offset: 0x00344DD5
		internal AreaValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700099B RID: 2459
		// (get) Token: 0x06005C76 RID: 23670 RVA: 0x00345E00 File Offset: 0x00344E00
		// (set) Token: 0x06005C77 RID: 23671 RVA: 0x00345E18 File Offset: 0x00344E18
		public ValuePositionDataLabel DataLabel
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x06005C78 RID: 23672 RVA: 0x00345E24 File Offset: 0x00344E24
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005C79 RID: 23673 RVA: 0x00345E3C File Offset: 0x00344E3C
		internal int b()
		{
			return this.e;
		}

		// Token: 0x06005C7A RID: 23674 RVA: 0x00345E54 File Offset: 0x00344E54
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005C7B RID: 23675 RVA: 0x00345E60 File Offset: 0x00344E60
		internal AreaSeries c()
		{
			return this.b;
		}

		// Token: 0x06005C7C RID: 23676 RVA: 0x00345E78 File Offset: 0x00344E78
		internal void a(AreaSeries A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005C7D RID: 23677 RVA: 0x00345E84 File Offset: 0x00344E84
		internal float d()
		{
			return this.d;
		}

		// Token: 0x06005C7E RID: 23678 RVA: 0x00345E9C File Offset: 0x00344E9C
		internal void a(float A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06005C7F RID: 23679 RVA: 0x00345EA8 File Offset: 0x00344EA8
		internal float e()
		{
			return this.c;
		}

		// Token: 0x06005C80 RID: 23680 RVA: 0x00345EC0 File Offset: 0x00344EC0
		internal void b(float A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005C81 RID: 23681 RVA: 0x00345ECC File Offset: 0x00344ECC
		internal void a(PageWriter A_0, int A_1, int A_2)
		{
			PlotArea plotArea = this.b.PlotArea;
			XAxis xaxis = this.b.m();
			YAxis yaxis = this.b.n();
			float num = xaxis.g();
			float num2 = yaxis.g();
			float num3 = (float)A_1 * num;
			float num4 = this.a * num2 / yaxis.t();
			float num5 = plotArea.Height + plotArea.Y - num4;
			float num6 = plotArea.X + num * xaxis.s() + num3;
			num5 += yaxis.v() * num2 / yaxis.t();
			this.b(num6);
			this.a(num5);
			if (A_1 == 0)
			{
				A_0.Write_m_(plotArea.X + num * xaxis.s(), num5 + num4);
				A_0.Write_l_(num6, num5);
			}
			else
			{
				A_0.Write_l_(num6, num5);
			}
			if (A_1 == A_2 - 1)
			{
				A_0.Write_l_(num6, num5 + num4);
				A_0.Write_l_(num6 - (float)A_1 * num, num5 + num4);
				A_0.Write_f();
			}
		}

		// Token: 0x06005C82 RID: 23682 RVA: 0x00345FF4 File Offset: 0x00344FF4
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005C83 RID: 23683 RVA: 0x0034601C File Offset: 0x0034501C
		internal void a(PageWriter A_0, int A_1, int A_2, AreaValue A_3)
		{
			PlotArea plotArea = this.b.PlotArea;
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			XAxis xaxis = this.b.m();
			YAxis yaxis = this.b.n();
			float num4 = yaxis.v();
			float num5 = xaxis.g();
			float num6 = yaxis.g();
			float num7 = num4;
			float num8 = yaxis.w();
			float num9 = (float)A_1 * num5;
			float num10 = (float)(A_1 + 1) * num5;
			float num11;
			float num12;
			if (num4 > 0f)
			{
				num11 = (this.a - num4) * num6 / yaxis.t();
				num12 = (A_3.Value - num4) * num6 / yaxis.t();
			}
			else
			{
				num11 = this.a * num6 / yaxis.t();
				num12 = A_3.Value * num6 / yaxis.t();
			}
			float num13 = plotArea.Height + plotArea.Y - num11 - num6 * yaxis.h();
			float num14 = plotArea.X + num5 * xaxis.s() + num9;
			float num15 = plotArea.Height + plotArea.Y - num12 - num6 * yaxis.h();
			float num16 = plotArea.X + num5 * xaxis.s() + num10;
			A_3.b(num16);
			A_3.a(num15);
			this.b(num14);
			this.a(num13);
			float num17 = plotArea.Height + plotArea.Y;
			float y = plotArea.Y;
			num = this.a(num14, num13, num16, num15, num, num17);
			if (this.a < num7 && A_3.Value >= num7 && A_3.Value <= num8)
			{
				num3 = 1;
			}
			if (this.a >= num7 && this.a <= num8 && A_3.Value >= num7 && A_3.Value <= num8)
			{
				num3 = 2;
			}
			if (this.a >= num7 && this.a <= num8 && A_3.Value < num7)
			{
				num3 = 3;
			}
			if (this.a < num7 && A_3.Value > num8)
			{
				num3 = 4;
				num2 = this.a(num14, num13, num16, num15, num2, y);
			}
			if (this.a > num8 && A_3.Value < num7)
			{
				num3 = 7;
				num2 = this.a(num14, num13, num16, num15, num2, y);
			}
			if (this.a >= num7 && this.a <= num8 && A_3.Value > num8)
			{
				num2 = this.a(num14, num13, num16, num15, num2, y);
				num3 = 5;
			}
			if (this.a > num8 && A_3.Value >= num7 && A_3.Value <= num8)
			{
				num2 = this.a(num14, num13, num16, num15, num2, y);
				num3 = 6;
			}
			if (A_1 == 0)
			{
				if (this.a > num8)
				{
					A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height);
					A_0.Write_l_(plotArea.X, plotArea.Y);
				}
				else
				{
					A_0.Write_m_(plotArea.X + num5 * xaxis.s(), num13 + num11);
				}
			}
			if (num3 == 1)
			{
				if (A_3.Value == num7)
				{
					A_0.Write_l_(num, num17);
				}
				else
				{
					A_0.Write_l_(plotArea.X, plotArea.Y + plotArea.Height);
					A_0.Write_l_(num, num17);
					A_0.Write_l_(num16, num15);
				}
			}
			else if (num3 == 2)
			{
				A_0.Write_l_(num14, num13);
				A_0.Write_l_(num16, num15);
			}
			else if (num3 == 3)
			{
				A_0.Write_l_(num14, num13);
				A_0.Write_l_(num, num17);
			}
			else if (num3 == 4)
			{
				A_0.Write_l_(num, num17);
				A_0.Write_l_(num2, y);
			}
			else if (num3 == 7)
			{
				A_0.Write_l_(num2, y);
				A_0.Write_l_(num, num17);
			}
			else if (num3 == 5)
			{
				A_0.Write_l_(num14, num13);
				A_0.Write_l_(num2, y);
			}
			else if (num3 == 6)
			{
				if (A_3.Value == num8)
				{
					A_0.Write_l_(num2, y);
				}
				else
				{
					A_0.Write_l_(num2, y);
					A_0.Write_l_(num16, num15);
				}
			}
			if (A_1 == A_2 - 2)
			{
				if (A_3.Value > num8)
				{
					A_0.Write_l_(num16, plotArea.Y);
					A_0.Write_l_(num16, plotArea.Y + plotArea.Height);
					A_0.Write_l_(num16 - (float)(A_1 + 1) * num5, num15 + num12);
					A_0.Write_f();
				}
				else
				{
					A_0.Write_l_(num16, num15 + num12);
					A_0.Write_l_(num16 - (float)(A_1 + 1) * num5, num15 + num12);
					A_0.Write_f();
				}
			}
		}

		// Token: 0x04003005 RID: 12293
		private float a;

		// Token: 0x04003006 RID: 12294
		private AreaSeries b;

		// Token: 0x04003007 RID: 12295
		private float c = 0f;

		// Token: 0x04003008 RID: 12296
		private float d = 0f;

		// Token: 0x04003009 RID: 12297
		private int e;

		// Token: 0x0400300A RID: 12298
		private ValuePositionDataLabel f;
	}
}
