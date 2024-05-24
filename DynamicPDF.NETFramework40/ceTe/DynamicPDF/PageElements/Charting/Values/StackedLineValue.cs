using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F6 RID: 2294
	public class StackedLineValue
	{
		// Token: 0x06005E39 RID: 24121 RVA: 0x00355F2A File Offset: 0x00354F2A
		internal StackedLineValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06005E3A RID: 24122 RVA: 0x00355F3C File Offset: 0x00354F3C
		// (set) Token: 0x06005E3B RID: 24123 RVA: 0x00355F54 File Offset: 0x00354F54
		public ValuePositionDataLabel DataLabel
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

		// Token: 0x06005E3C RID: 24124 RVA: 0x00355F60 File Offset: 0x00354F60
		internal int b()
		{
			return this.f;
		}

		// Token: 0x06005E3D RID: 24125 RVA: 0x00355F78 File Offset: 0x00354F78
		internal void a(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06005E3E RID: 24126 RVA: 0x00355F84 File Offset: 0x00354F84
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005E3F RID: 24127 RVA: 0x00355F9C File Offset: 0x00354F9C
		internal float c()
		{
			return this.d;
		}

		// Token: 0x06005E40 RID: 24128 RVA: 0x00355FB4 File Offset: 0x00354FB4
		internal float d()
		{
			return this.e;
		}

		// Token: 0x06005E41 RID: 24129 RVA: 0x00355FCC File Offset: 0x00354FCC
		internal StackedLineSeriesElement e()
		{
			StackedLineSeriesElement result;
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

		// Token: 0x06005E42 RID: 24130 RVA: 0x00355FF5 File Offset: 0x00354FF5
		internal void a(StackedLineSeriesElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005E43 RID: 24131 RVA: 0x00356000 File Offset: 0x00355000
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005E44 RID: 24132 RVA: 0x00356028 File Offset: 0x00355028
		internal void a(PageWriter A_0, int A_1, StackedLineValue A_2, float A_3, float A_4, bool A_5)
		{
			PlotArea plotArea = this.c.PlotArea;
			XAxis xaxis = this.c.d();
			YAxis yaxis = this.c.e();
			float num = (float)A_1 * xaxis.g();
			float num2 = (A_3 - yaxis.v()) * yaxis.g() / yaxis.t();
			float y = plotArea.Height + plotArea.Y - num2;
			float x = plotArea.X + xaxis.g() * xaxis.s() + num;
			this.d = y;
			this.e = x;
			if (A_2 != null)
			{
				float num3 = (float)(A_1 + 1) * xaxis.g();
				float num4 = (A_4 - yaxis.v()) * yaxis.g() / yaxis.t();
				float y2 = plotArea.Height + plotArea.Y - num4;
				float x2 = plotArea.X + xaxis.g() * xaxis.s() + num3;
				A_2.d = y2;
				A_2.e = x2;
				if (this.c.LineStyle != LineStyle.None)
				{
					if (A_5)
					{
						A_0.Write_m_(x, y);
					}
					A_0.Write_l_(x2, y2);
				}
			}
		}

		// Token: 0x06005E45 RID: 24133 RVA: 0x00356188 File Offset: 0x00355188
		internal void a(PageWriter A_0, int A_1, StackedLineValue A_2, float A_3, float A_4, bool A_5, char A_6, char A_7)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			PlotArea plotArea = this.c.PlotArea;
			XAxis xaxis = this.c.d();
			YAxis yaxis = this.c.e();
			float num4 = yaxis.v();
			float num5 = yaxis.w();
			float num6 = (float)A_1 * xaxis.g();
			float num7 = (A_3 - yaxis.v()) * yaxis.g() / yaxis.t();
			float num8 = plotArea.Height + plotArea.Y - num7;
			float num9 = plotArea.X + xaxis.g() * xaxis.s() + num6;
			this.d = num8;
			this.e = num9;
			if (A_2 != null)
			{
				float num10 = (float)(A_1 + 1) * xaxis.g();
				float num11 = (A_4 - yaxis.v()) * yaxis.g() / yaxis.t();
				float num12 = plotArea.Height + plotArea.Y - num11;
				float num13 = plotArea.X + xaxis.g() * xaxis.s() + num10;
				A_2.d = num12;
				A_2.e = num13;
				float num14 = plotArea.Height + plotArea.Y;
				float y = plotArea.Y;
				num = this.a(num9, num8, num13, num12, num, num14);
				if (A_3 < num4 && A_4 >= num4 && A_4 <= num5)
				{
					num3 = 1;
				}
				if (A_3 >= num4 && A_3 <= num5 && A_4 >= num4 && A_4 <= num5)
				{
					num3 = 2;
				}
				if (A_3 >= num4 && A_3 <= num5 && A_4 < num4)
				{
					num3 = 3;
				}
				if (A_3 < num4 && A_4 > num5)
				{
					num3 = 4;
					num2 = this.a(num9, num8, num13, num12, num2, y);
				}
				if (A_3 > num5 && A_4 < num4)
				{
					num3 = 7;
					num2 = this.a(num9, num8, num13, num12, num2, y);
				}
				if (A_3 >= num4 && A_3 <= num5 && A_4 > num5)
				{
					num2 = this.a(num9, num8, num13, num12, num2, y);
					num3 = 5;
				}
				if (A_3 > num5 && A_4 >= num4 && A_4 <= num5)
				{
					num2 = this.a(num9, num8, num13, num12, num2, y);
					num3 = 6;
				}
				if (this.c.LineStyle != LineStyle.None)
				{
					if (num3 == 1)
					{
						A_5 = true;
						if (A_4 == num4)
						{
							A_0.Write_m_(num, num14);
						}
						else
						{
							A_0.Write_m_(num, num14);
							A_0.Write_l_(num13, num12);
						}
					}
					else if (num3 == 2)
					{
						if (A_5)
						{
							if (A_6 == 'm')
							{
								A_0.Write_m_(num9, num8);
							}
							else
							{
								A_0.Write_l_(num9, num8);
							}
						}
						if (A_7 == 'm')
						{
							A_0.Write_m_(num13, num12);
						}
						else
						{
							A_0.Write_l_(num13, num12);
						}
					}
					else if (num3 == 3)
					{
						if (A_5)
						{
							if (A_6 == 'm')
							{
								A_0.Write_m_(num9, num8);
							}
							else
							{
								A_0.Write_l_(num9, num8);
							}
						}
						if (A_7 == 'm')
						{
							A_0.Write_m_(num, num14);
						}
						else
						{
							A_0.Write_l_(num, num14);
						}
					}
					else if (num3 == 4)
					{
						A_0.Write_m_(num, num14);
						A_0.Write_l_(num2, y);
					}
					else if (num3 == 7)
					{
						A_0.Write_m_(num2, y);
						A_0.Write_l_(num, num14);
					}
					else if (num3 == 5)
					{
						if (A_5)
						{
							if (A_6 == 'm')
							{
								A_0.Write_m_(num9, num8);
							}
							else
							{
								A_0.Write_l_(num9, num8);
							}
						}
						if (A_7 == 'm')
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
						if (A_4 == num5)
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

		// Token: 0x0400309E RID: 12446
		private float a;

		// Token: 0x0400309F RID: 12447
		private ValuePositionDataLabel b;

		// Token: 0x040030A0 RID: 12448
		private StackedLineSeriesElement c;

		// Token: 0x040030A1 RID: 12449
		private float d;

		// Token: 0x040030A2 RID: 12450
		private float e;

		// Token: 0x040030A3 RID: 12451
		private int f;
	}
}
