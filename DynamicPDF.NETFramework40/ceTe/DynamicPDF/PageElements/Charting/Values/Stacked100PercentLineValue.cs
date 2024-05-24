using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008DC RID: 2268
	public class Stacked100PercentLineValue
	{
		// Token: 0x06005D56 RID: 23894 RVA: 0x0034E086 File Offset: 0x0034D086
		internal Stacked100PercentLineValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06005D57 RID: 23895 RVA: 0x0034E098 File Offset: 0x0034D098
		// (set) Token: 0x06005D58 RID: 23896 RVA: 0x0034E0B0 File Offset: 0x0034D0B0
		public PercentageDataLabel DataLabel
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06005D59 RID: 23897 RVA: 0x0034E0BC File Offset: 0x0034D0BC
		internal int b()
		{
			return this.f;
		}

		// Token: 0x06005D5A RID: 23898 RVA: 0x0034E0D4 File Offset: 0x0034D0D4
		internal void a(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06005D5B RID: 23899 RVA: 0x0034E0E0 File Offset: 0x0034D0E0
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D5C RID: 23900 RVA: 0x0034E0F8 File Offset: 0x0034D0F8
		internal float c()
		{
			return this.d;
		}

		// Token: 0x06005D5D RID: 23901 RVA: 0x0034E110 File Offset: 0x0034D110
		internal float d()
		{
			return this.e;
		}

		// Token: 0x06005D5E RID: 23902 RVA: 0x0034E128 File Offset: 0x0034D128
		internal Stacked100PercentLineSeriesElement e()
		{
			Stacked100PercentLineSeriesElement result;
			if (this.c != null)
			{
				result = this.c;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005D5F RID: 23903 RVA: 0x0034E151 File Offset: 0x0034D151
		internal void a(Stacked100PercentLineSeriesElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005D60 RID: 23904 RVA: 0x0034E15C File Offset: 0x0034D15C
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005D61 RID: 23905 RVA: 0x0034E184 File Offset: 0x0034D184
		internal void a(PageWriter A_0, int A_1, Stacked100PercentLineValue A_2, float A_3, float A_4, float A_5, float A_6)
		{
			PlotArea plotArea = this.c.PlotArea;
			XAxis xaxis = this.c.d();
			YAxis yaxis = this.c.e();
			float num = (float)A_1 * xaxis.g();
			float num2 = yaxis.g() * 100f / yaxis.t() * (A_5 / A_3);
			float num3 = plotArea.Height + plotArea.Y - num2;
			num3 += yaxis.g() * yaxis.v() / yaxis.t();
			float x = plotArea.X + xaxis.g() * xaxis.s() + num;
			this.d = num3;
			this.e = x;
			if (A_2 != null)
			{
				float num4 = (float)(A_1 + 1) * xaxis.g();
				float num5 = yaxis.g() * 100f / yaxis.t() * (A_6 / A_4);
				float num6 = plotArea.Height + plotArea.Y - num5;
				num6 += yaxis.g() * yaxis.v() / yaxis.t();
				float x2 = plotArea.X + xaxis.g() * xaxis.s() + num4;
				A_2.d = num6;
				A_2.e = x2;
				if (this.c.LineStyle != LineStyle.None)
				{
					A_0.Write_m_(x, num3);
					A_0.Write_l_(x2, num6);
				}
			}
		}

		// Token: 0x06005D62 RID: 23906 RVA: 0x0034E30C File Offset: 0x0034D30C
		internal void a(PageWriter A_0, int A_1, Stacked100PercentLineValue A_2, float A_3, float A_4, float A_5, float A_6, bool A_7, char A_8, char A_9)
		{
			float num = 0f;
			float num2 = 0f;
			PlotArea plotArea = this.c.PlotArea;
			XAxis xaxis = this.c.d();
			YAxis yaxis = this.c.e();
			float num3 = yaxis.g() * yaxis.w() / yaxis.t();
			float num4 = yaxis.g() * yaxis.v() / yaxis.t();
			int num5 = 0;
			float num6 = (float)A_1 * xaxis.g();
			float num7 = yaxis.g() * 100f / yaxis.t() * (A_5 / A_3);
			float num8 = plotArea.Height + plotArea.Y - num7;
			num8 += yaxis.g() * yaxis.v() / yaxis.t();
			float num9 = plotArea.X + xaxis.g() * xaxis.s() + num6;
			this.d = num8;
			this.e = num9;
			if (A_2 != null)
			{
				float num10 = (float)(A_1 + 1) * xaxis.g();
				float num11 = yaxis.g() * 100f / yaxis.t() * (A_6 / A_4);
				float num12 = plotArea.Height + plotArea.Y - num11;
				num12 += yaxis.g() * yaxis.v() / yaxis.t();
				float num13 = plotArea.X + xaxis.g() * xaxis.s() + num10;
				A_2.d = num12;
				A_2.e = num13;
				float num14 = plotArea.Height + plotArea.Y;
				float y = plotArea.Y;
				num = this.a(num9, num8, num13, num12, num, num14);
				if (num7 < num4 && num11 >= num4 && num11 <= num3)
				{
					num5 = 1;
				}
				if (num7 >= num4 && num7 <= num3 && num11 >= num4 && num11 <= num3)
				{
					num5 = 2;
				}
				if (num7 >= num4 && num7 <= num3 && num11 < num4)
				{
					num5 = 3;
				}
				if (num7 < num4 && num11 > num3)
				{
					num5 = 4;
					num2 = this.a(num9, num8, num13, num12, num2, y);
				}
				if (num7 > num3 && num11 < num4)
				{
					num5 = 7;
					num2 = this.a(num9, num8, num13, num12, num2, y);
				}
				if (num7 >= num4 && num7 <= num3 && num11 > num3)
				{
					num2 = this.a(num9, num8, num13, num12, num2, y);
					num5 = 5;
				}
				if (num7 > num3 && num11 >= num4 && num11 <= num3)
				{
					num2 = this.a(num9, num8, num13, num12, num2, y);
					num5 = 6;
				}
				if (this.c.LineStyle != LineStyle.None)
				{
					if (num5 == 1)
					{
						A_7 = true;
						if (A_6 == num4)
						{
							A_0.Write_m_(num, num14);
						}
						else
						{
							A_0.Write_m_(num, num14);
							A_0.Write_l_(num13, num12);
						}
					}
					else if (num5 == 2)
					{
						if (A_7)
						{
							if (A_8 == 'm')
							{
								A_0.Write_m_(num9, num8);
							}
							else
							{
								A_0.Write_l_(num9, num8);
							}
						}
						if (A_9 == 'm')
						{
							A_0.Write_m_(num13, num12);
						}
						else
						{
							A_0.Write_l_(num13, num12);
						}
					}
					else if (num5 == 3)
					{
						if (A_7)
						{
							if (A_8 == 'm')
							{
								A_0.Write_m_(num9, num8);
							}
							else
							{
								A_0.Write_l_(num9, num8);
							}
						}
						if (A_9 == 'm')
						{
							A_0.Write_m_(num, num14);
						}
						else
						{
							A_0.Write_l_(num, num14);
						}
					}
					else if (num5 == 4)
					{
						A_0.Write_m_(num, num14);
						A_0.Write_l_(num2, y);
					}
					else if (num5 == 7)
					{
						A_0.Write_m_(num2, y);
						A_0.Write_l_(num, num14);
					}
					else if (num5 == 5)
					{
						if (A_7)
						{
							if (A_8 == 'm')
							{
								A_0.Write_m_(num9, num8);
							}
							else
							{
								A_0.Write_l_(num9, num8);
							}
						}
						if (A_9 == 'm')
						{
							A_0.Write_m_(num2, y);
						}
						else
						{
							A_0.Write_l_(num2, y);
						}
					}
					else if (num5 == 6)
					{
						if (A_6 == num3)
						{
							A_0.Write_m_(num2, y);
						}
						else
						{
							A_0.Write_m_(num2, y);
							A_0.Write_l_(num13, num12);
						}
					}
				}
			}
		}

		// Token: 0x04003057 RID: 12375
		private float a;

		// Token: 0x04003058 RID: 12376
		private PercentageDataLabel b;

		// Token: 0x04003059 RID: 12377
		private Stacked100PercentLineSeriesElement c;

		// Token: 0x0400305A RID: 12378
		private float d;

		// Token: 0x0400305B RID: 12379
		private float e;

		// Token: 0x0400305C RID: 12380
		private int f;
	}
}
