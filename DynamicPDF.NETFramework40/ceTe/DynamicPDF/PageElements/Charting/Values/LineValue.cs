using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E6 RID: 2278
	public class LineValue
	{
		// Token: 0x06005D90 RID: 23952 RVA: 0x0034F98A File Offset: 0x0034E98A
		internal LineValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005D91 RID: 23953 RVA: 0x0034F99C File Offset: 0x0034E99C
		internal int b()
		{
			return this.e;
		}

		// Token: 0x06005D92 RID: 23954 RVA: 0x0034F9B4 File Offset: 0x0034E9B4
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x06005D93 RID: 23955 RVA: 0x0034F9C0 File Offset: 0x0034E9C0
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D94 RID: 23956 RVA: 0x0034F9D8 File Offset: 0x0034E9D8
		internal float c()
		{
			return this.c;
		}

		// Token: 0x06005D95 RID: 23957 RVA: 0x0034F9F0 File Offset: 0x0034E9F0
		internal void a(float A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005D96 RID: 23958 RVA: 0x0034F9FC File Offset: 0x0034E9FC
		internal float d()
		{
			return this.d;
		}

		// Token: 0x06005D97 RID: 23959 RVA: 0x0034FA14 File Offset: 0x0034EA14
		internal void b(float A_0)
		{
			this.d = A_0;
		}

		// Token: 0x170009C3 RID: 2499
		// (get) Token: 0x06005D98 RID: 23960 RVA: 0x0034FA20 File Offset: 0x0034EA20
		// (set) Token: 0x06005D99 RID: 23961 RVA: 0x0034FA38 File Offset: 0x0034EA38
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

		// Token: 0x06005D9A RID: 23962 RVA: 0x0034FA44 File Offset: 0x0034EA44
		internal LineSeries e()
		{
			LineSeries result;
			if (this.b != null)
			{
				result = this.b;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005D9B RID: 23963 RVA: 0x0034FA6D File Offset: 0x0034EA6D
		internal void a(LineSeries A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005D9C RID: 23964 RVA: 0x0034FA78 File Offset: 0x0034EA78
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005D9D RID: 23965 RVA: 0x0034FAA0 File Offset: 0x0034EAA0
		internal void a(PageWriter A_0, int A_1, LineValue A_2, char A_3, char A_4, bool A_5)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			PlotArea plotArea = this.b.PlotArea;
			XAxis xaxis = this.b.m();
			YAxis yaxis = this.b.n();
			float num4 = xaxis.g();
			float num5 = yaxis.g();
			float num6 = yaxis.v();
			float num7 = yaxis.w();
			float num8 = (float)A_1 * num4;
			float num9 = (float)(A_1 + 1) * num4;
			float num10 = (this.a - num6) * num5 / yaxis.t();
			float num11 = (A_2.Value - num6) * num5 / yaxis.t();
			float num12 = plotArea.Height + plotArea.Y - num10 - num5 * yaxis.s();
			float num13 = plotArea.Height + plotArea.Y - num11 - num5 * yaxis.s();
			float num14 = plotArea.X + num4 * xaxis.s() + num8;
			float num15 = plotArea.X + num4 * xaxis.s() + num9;
			float num16 = plotArea.Height + plotArea.Y;
			float y = plotArea.Y;
			num = this.a(num14, num12, num15, num13, num, num16);
			if (this.a < num6 && A_2.Value >= num6 && A_2.Value <= num7)
			{
				num3 = 1;
			}
			if (this.a >= num6 && this.a <= num7 && A_2.Value >= num6 && A_2.Value <= num7)
			{
				num3 = 2;
			}
			if (this.a >= num6 && this.a <= num7 && A_2.Value < num6)
			{
				num3 = 3;
			}
			if (this.a < num6 && A_2.Value > num7)
			{
				num3 = 4;
				num2 = this.a(num14, num12, num15, num13, num2, y);
			}
			if (this.a > num7 && A_2.Value < num6)
			{
				num3 = 7;
				num2 = this.a(num14, num12, num15, num13, num2, y);
			}
			if (this.a >= num6 && this.a <= num7 && A_2.Value > num7)
			{
				num2 = this.a(num14, num12, num15, num13, num2, y);
				num3 = 5;
			}
			if (this.a > num7 && A_2.Value >= num6 && A_2.Value <= num7)
			{
				num2 = this.a(num14, num12, num15, num13, num2, y);
				num3 = 6;
			}
			this.c = num12;
			this.d = num14;
			A_2.d = num15;
			A_2.c = num13;
			if (this.b.LineStyle != LineStyle.None)
			{
				if (num3 == 1)
				{
					A_5 = true;
					if (A_2.Value == num6)
					{
						A_0.Write_m_(num, num16);
					}
					else
					{
						A_0.Write_m_(num, num16);
						A_0.Write_l_(num15, num13);
					}
				}
				else if (num3 == 2)
				{
					if (A_5)
					{
						if (A_3 == 'm')
						{
							A_0.Write_m_(num14, num12);
						}
						else
						{
							A_0.Write_l_(num14, num12);
						}
					}
					if (A_4 == 'm')
					{
						A_0.Write_m_(num15, num13);
					}
					else
					{
						A_0.Write_l_(num15, num13);
					}
				}
				else if (num3 == 3)
				{
					if (A_5)
					{
						if (A_3 == 'm')
						{
							A_0.Write_m_(num14, num12);
						}
						else
						{
							A_0.Write_l_(num14, num12);
						}
					}
					if (A_4 == 'm')
					{
						A_0.Write_m_(num, num16);
					}
					else
					{
						A_0.Write_l_(num, num16);
					}
				}
				else if (num3 == 4)
				{
					A_0.Write_m_(num, num16);
					A_0.Write_l_(num2, y);
				}
				else if (num3 == 7)
				{
					A_0.Write_m_(num2, y);
					A_0.Write_l_(num, num16);
				}
				else if (num3 == 5)
				{
					if (A_5)
					{
						if (A_3 == 'm')
						{
							A_0.Write_m_(num14, num12);
						}
						else
						{
							A_0.Write_l_(num14, num12);
						}
					}
					if (A_4 == 'm')
					{
						A_0.Write_m_(num2, y);
					}
					else
					{
						A_0.Write_l_(num2, y);
					}
				}
				else if (num3 == 6)
				{
					if (A_2.Value == num7)
					{
						A_0.Write_m_(num2, y);
					}
					else
					{
						A_0.Write_m_(num2, y);
						A_0.Write_l_(num15, num13);
					}
				}
			}
		}

		// Token: 0x06005D9E RID: 23966 RVA: 0x0034FFD8 File Offset: 0x0034EFD8
		internal void a(PageWriter A_0, int A_1, LineValue A_2, bool A_3)
		{
			PlotArea plotArea = this.b.PlotArea;
			XAxis xaxis = this.b.m();
			YAxis yaxis = this.b.n();
			float num = (float)A_1 * xaxis.g();
			float num2 = (float)(A_1 + 1) * xaxis.g();
			float num3 = (this.a - yaxis.v()) * yaxis.g() / yaxis.t();
			float num4 = (A_2.Value - yaxis.v()) * yaxis.g() / yaxis.t();
			float y = plotArea.Height + plotArea.Y - num3;
			float y2 = plotArea.Height + plotArea.Y - num4;
			float x = plotArea.X + xaxis.g() * xaxis.s() + num;
			float x2 = plotArea.X + xaxis.g() * xaxis.s() + num2;
			this.c = y;
			this.d = x;
			A_2.d = x2;
			A_2.c = y2;
			if (this.b.LineStyle != LineStyle.None)
			{
				if (A_3)
				{
					A_0.Write_m_(x, y);
				}
				A_0.Write_l_(x2, y2);
			}
		}

		// Token: 0x04003065 RID: 12389
		private float a;

		// Token: 0x04003066 RID: 12390
		private LineSeries b;

		// Token: 0x04003067 RID: 12391
		private float c;

		// Token: 0x04003068 RID: 12392
		private float d;

		// Token: 0x04003069 RID: 12393
		private int e;

		// Token: 0x0400306A RID: 12394
		private ValuePositionDataLabel f;
	}
}
