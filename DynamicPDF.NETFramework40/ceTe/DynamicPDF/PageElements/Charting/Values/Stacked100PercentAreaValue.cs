using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D0 RID: 2256
	public class Stacked100PercentAreaValue
	{
		// Token: 0x06005CD0 RID: 23760 RVA: 0x003490E0 File Offset: 0x003480E0
		internal Stacked100PercentAreaValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x06005CD1 RID: 23761 RVA: 0x0034914C File Offset: 0x0034814C
		// (set) Token: 0x06005CD2 RID: 23762 RVA: 0x00349164 File Offset: 0x00348164
		public PercentageDataLabel DataLabel
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x06005CD3 RID: 23763 RVA: 0x00349170 File Offset: 0x00348170
		internal float b()
		{
			return this.h;
		}

		// Token: 0x06005CD4 RID: 23764 RVA: 0x00349188 File Offset: 0x00348188
		internal void a(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06005CD5 RID: 23765 RVA: 0x00349194 File Offset: 0x00348194
		internal float c()
		{
			return this.i;
		}

		// Token: 0x06005CD6 RID: 23766 RVA: 0x003491AC File Offset: 0x003481AC
		internal void b(float A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06005CD7 RID: 23767 RVA: 0x003491B8 File Offset: 0x003481B8
		internal float d()
		{
			return this.j;
		}

		// Token: 0x06005CD8 RID: 23768 RVA: 0x003491D0 File Offset: 0x003481D0
		internal void c(float A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06005CD9 RID: 23769 RVA: 0x003491DC File Offset: 0x003481DC
		internal float e()
		{
			return this.k;
		}

		// Token: 0x06005CDA RID: 23770 RVA: 0x003491F4 File Offset: 0x003481F4
		internal void d(float A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06005CDB RID: 23771 RVA: 0x00349200 File Offset: 0x00348200
		internal int f()
		{
			return this.g;
		}

		// Token: 0x06005CDC RID: 23772 RVA: 0x00349218 File Offset: 0x00348218
		internal void a(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06005CDD RID: 23773 RVA: 0x00349224 File Offset: 0x00348224
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005CDE RID: 23774 RVA: 0x0034923C File Offset: 0x0034823C
		internal Stacked100PercentAreaSeriesElement g()
		{
			return this.b;
		}

		// Token: 0x06005CDF RID: 23775 RVA: 0x00349254 File Offset: 0x00348254
		internal void a(Stacked100PercentAreaSeriesElement A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005CE0 RID: 23776 RVA: 0x00349260 File Offset: 0x00348260
		internal float h()
		{
			return this.f;
		}

		// Token: 0x06005CE1 RID: 23777 RVA: 0x00349278 File Offset: 0x00348278
		internal void e(float A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06005CE2 RID: 23778 RVA: 0x00349284 File Offset: 0x00348284
		internal float i()
		{
			return this.e;
		}

		// Token: 0x06005CE3 RID: 23779 RVA: 0x0034929C File Offset: 0x0034829C
		internal void f(float A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005CE4 RID: 23780 RVA: 0x003492A8 File Offset: 0x003482A8
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005CE5 RID: 23781 RVA: 0x003492D0 File Offset: 0x003482D0
		internal void a(PageWriter A_0, PlotArea A_1, int A_2, int A_3, Stacked100PercentAreaValue A_4, Stacked100PercentAreaSeriesElement A_5, float A_6, float A_7)
		{
			YAxis yaxis = this.b.e();
			XAxis xaxis = this.b.d();
			float num = xaxis.g();
			float num2 = yaxis.g();
			float num3 = num2 * 100f / yaxis.t() * (A_7 / A_6);
			float num4 = A_1.X + num * xaxis.s() + num * (float)A_2;
			float num5 = A_1.Height + A_1.Y - num3 - this.b.e().g() * this.b.e().h();
			if (yaxis.v() > 0f)
			{
				float num6 = yaxis.v() * num2 / yaxis.t();
				num5 += num6;
			}
			this.d = num3;
			this.f(num4);
			this.e(num5);
			if (A_2 == 0)
			{
				if (A_4 == null)
				{
					A_0.Write_m_(A_1.X + num * xaxis.s(), num5 + num3);
					A_0.Write_l_(num4, num5);
				}
				else
				{
					A_0.Write_m_(A_4.i(), A_4.h());
					A_0.Write_l_(num4, num5);
				}
			}
			else
			{
				A_0.Write_l_(num4, num5);
			}
			if (A_2 == A_3 - 1)
			{
				if (A_4 == null)
				{
					A_0.Write_l_(num4, num5 + num3);
					A_0.Write_l_(num4 - (float)A_2 * num, num5 + num3);
				}
				else
				{
					A_0.Write_l_(num4, num5 + (num3 - A_4.d));
					ArrayList arrayList = A_5.a().f();
					for (int i = arrayList.Count - 1; i > 0; i--)
					{
						Stacked100PercentAreaValue stacked100PercentAreaValue = (Stacked100PercentAreaValue)arrayList[i - 1];
						num5 = stacked100PercentAreaValue.h();
						num4 = stacked100PercentAreaValue.i();
						if (i != 1)
						{
							A_0.Write_l_(num4, num5);
						}
						else
						{
							A_0.Write_l_(num4, num5);
						}
					}
				}
				A_0.Write_f();
			}
		}

		// Token: 0x06005CE6 RID: 23782 RVA: 0x00349504 File Offset: 0x00348504
		internal void a(PageWriter A_0, int A_1, float A_2, float A_3, float A_4, float A_5, int A_6, Stacked100PercentAreaValue A_7, Stacked100PercentAreaValue A_8, Stacked100PercentAreaSeriesElement A_9, Stacked100PercentAreaValue A_10, float A_11)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			PlotArea plotArea = this.b.PlotArea;
			XAxis xaxis = this.b.d();
			YAxis yaxis = this.b.e();
			float num4 = yaxis.v();
			float num5 = yaxis.w();
			float num6 = xaxis.g();
			float num7 = yaxis.g();
			float num8 = num7 * num4 / yaxis.t();
			float num9 = (float)A_1 * num6;
			float num10 = (float)(A_1 + 1) * num6;
			float num11 = num7 * 100f / yaxis.t() * (A_4 / A_2);
			float num12 = num7 * 100f / yaxis.t() * (A_5 / A_3);
			if (yaxis.v() > 0f)
			{
				num11 -= num8;
				num12 -= num8;
			}
			A_4 = A_4 / A_2 * 100f;
			A_5 = A_5 / A_3 * 100f;
			float num13 = plotArea.Height + plotArea.Y - num11 - num7 * yaxis.h();
			float num14 = plotArea.X + num6 * xaxis.s() + num9;
			float num15 = plotArea.Height + plotArea.Y - num12 - num7 * yaxis.h();
			float num16 = plotArea.X + num6 * xaxis.s() + num10;
			A_7.f(num16);
			A_7.e(num15);
			this.f(num14);
			this.e(num13);
			float num17 = plotArea.Height + plotArea.Y;
			float y = plotArea.Y;
			num = this.a(num14, num13, num16, num15, num, num17);
			if (A_4 < num4 && A_5 >= num4 && A_5 <= num5)
			{
				num3 = 1;
			}
			if (A_4 >= num4 && A_4 <= num5 && A_5 >= num4 && A_5 <= num5)
			{
				num3 = 2;
			}
			if (A_4 >= num4 && A_4 <= num5 && A_5 < num4)
			{
				num3 = 3;
			}
			if (A_4 < num4 && A_5 > num5)
			{
				num3 = 4;
				num2 = this.a(num14, num13, num16, num15, num2, y);
			}
			if (A_4 > num5 && A_5 < num4)
			{
				num3 = 7;
				num2 = this.a(num14, num13, num16, num15, num2, y);
			}
			if (A_4 >= num4 && A_4 <= num5 && A_5 > num5)
			{
				num2 = this.a(num14, num13, num16, num15, num2, y);
				num3 = 5;
			}
			if (A_4 > num5 && A_5 >= num4 && A_5 <= num5)
			{
				num2 = this.a(num14, num13, num16, num15, num2, y);
				num3 = 6;
			}
			if (A_1 == 0)
			{
				if (A_4 > num5)
				{
					if (A_9 == null)
					{
						if (num4 < 0f && num5 >= 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + num7 * Math.Abs(num5) / yaxis.t());
							A_0.Write_l_(plotArea.X, plotArea.Y);
						}
						else if (num4 < 0f && num5 < 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y);
						}
					}
					else if (A_8.b() != 0f && A_8.c() != 0f)
					{
						A_0.Write_m_(A_8.b(), A_8.c());
					}
					else
					{
						A_0.Write_m_(A_8.i(), A_8.h());
						A_0.Write_m_(plotArea.X, plotArea.Y);
					}
				}
				else if (A_4 <= num5 && A_4 >= num4)
				{
					if (A_9 == null)
					{
						if (num5 < 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num7 * yaxis.h() + num7 * Math.Abs(num5) / yaxis.t());
						}
						else
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num7 * yaxis.h());
						}
					}
					else if (A_8.b() != 0f && A_8.c() != 0f)
					{
						if (num5 < 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num7 * yaxis.h() + num7 * Math.Abs(num5) / yaxis.t());
						}
						else
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height);
						}
					}
					else if (A_8.h() < plotArea.Y)
					{
						A_0.Write_m_(plotArea.X, plotArea.Y);
					}
					else if (A_8.h() > plotArea.Y + plotArea.Height)
					{
						A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height);
					}
					else
					{
						A_0.Write_m_(A_8.i(), A_8.h());
					}
				}
				else
				{
					A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num7 * yaxis.h());
					A_0.Write_l_(plotArea.X, plotArea.Y + plotArea.Height);
				}
			}
			if (num3 == 1)
			{
				if (A_5 == num4)
				{
					A_0.Write_l_(num, num17);
				}
				else
				{
					A_0.Write_l_(num, num17);
					A_0.Write_l_(num16, num15);
				}
				if (this.b() == 0f)
				{
					this.a(num);
					this.b(num17);
				}
				else
				{
					this.c(num);
					this.d(num17);
				}
			}
			else if (num3 == 2)
			{
				if (A_1 == 0)
				{
					A_0.Write_l_(num14, num13);
					A_0.Write_l_(num16, num15);
				}
				else
				{
					A_0.Write_l_(num16, num15);
				}
			}
			else if (num3 == 3)
			{
				if (A_1 == 0)
				{
					A_0.Write_l_(num14, num13);
					A_0.Write_l_(num, num17);
				}
				else
				{
					A_0.Write_l_(num, num17);
				}
				if (A_7.b() == 0f)
				{
					A_7.a(num);
					A_7.b(num17);
				}
				else
				{
					A_7.c(num);
					A_7.d(num17);
				}
			}
			else if (num3 == 4)
			{
				A_0.Write_l_(num, num17);
				A_0.Write_l_(num2, y);
				this.a(num);
				this.b(num17);
				if (A_7.b() == 0f && A_7.c() == 0f)
				{
					A_7.a(num2);
					A_7.b(y);
				}
				else
				{
					A_7.c(num2);
					A_7.d(y);
				}
			}
			else if (num3 == 7)
			{
				A_0.Write_l_(num2, y);
				A_0.Write_l_(num, num17);
				this.a(num2);
				this.b(y);
				if (A_7.b() == 0f && A_7.c() == 0f)
				{
					A_7.a(num);
					A_7.b(num17);
				}
				else
				{
					A_7.c(num);
					A_7.d(num17);
				}
			}
			else if (num3 == 5)
			{
				if (A_1 == 0)
				{
					A_0.Write_l_(num14, num13);
					A_0.Write_l_(num2, y);
				}
				else
				{
					A_0.Write_l_(num2, y);
				}
				if (A_7.b() == 0f && A_7.c() == 0f)
				{
					A_7.a(num2);
					A_7.b(y);
				}
				else
				{
					A_7.c(num2);
					A_7.d(y);
				}
			}
			else if (num3 == 6)
			{
				if (A_5 == num5)
				{
					A_0.Write_l_(num2, y);
				}
				else
				{
					A_0.Write_l_(num2, y);
					A_0.Write_l_(num16, num15);
				}
				if (this.b() == 0f && this.c() == 0f)
				{
					this.a(num2);
					this.b(y);
				}
				else
				{
					this.c(num2);
					this.d(y);
				}
			}
			if (A_1 == A_6 - 2)
			{
				if (num4 < 0f && (num5 <= 0f || num5 > 0f) && A_5 < num4)
				{
					A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
				}
				if (num13 < plotArea.Y && num15 < plotArea.Y)
				{
					A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
				}
				if (A_7.b() != 0f && A_7.c() != 0f)
				{
					if (A_9 == null)
					{
						if (A_5 > num5)
						{
							if (num4 < 0f && num5 >= 0f)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + num7 * Math.Abs(num5) / yaxis.t());
							}
							else if (num4 < 0f && num5 < 0f)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
							}
						}
						else if (A_5 < num4)
						{
							A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
							A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height - num7 * yaxis.h());
						}
					}
					else
					{
						ArrayList arrayList = A_9.a().f();
						A_8 = (Stacked100PercentAreaValue)arrayList[arrayList.Count - 1];
						if (A_5 > num5)
						{
							if (A_8.b() == 0f && A_8.c() == 0f)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
							}
							else
							{
								A_0.Write_l_(A_8.b(), A_8.c());
							}
						}
						else if (A_5 < num4)
						{
							A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
						}
					}
				}
				else if (A_9 == null)
				{
					if (num4 < 0f && num5 < 0f)
					{
						A_0.Write_l_(num16, plotArea.Y);
					}
					else
					{
						A_0.Write_l_(num16, num15 + num12);
					}
				}
				else
				{
					ArrayList arrayList = A_9.a().f();
					A_8 = (Stacked100PercentAreaValue)arrayList[arrayList.Count - 1];
					if (A_5 <= num5 && A_5 >= num4)
					{
						if ((A_8.b() != 0f && A_8.c() != 0f) || A_8.h() < plotArea.Y)
						{
							if (A_5 - A_7.Value < num4)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
							}
							else if (A_5 - A_7.Value > num5)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
							}
						}
					}
				}
				if (A_9 != null)
				{
					ArrayList arrayList = A_9.a().f();
					for (int i = arrayList.Count - 1; i >= 0; i--)
					{
						Stacked100PercentAreaValue stacked100PercentAreaValue = (Stacked100PercentAreaValue)arrayList[i];
						if (stacked100PercentAreaValue.b() == 0f && stacked100PercentAreaValue.c() == 0f)
						{
							num14 = stacked100PercentAreaValue.i();
							num13 = stacked100PercentAreaValue.h();
						}
						else
						{
							num14 = stacked100PercentAreaValue.b();
							num13 = stacked100PercentAreaValue.c();
						}
						if (stacked100PercentAreaValue.d() != 0f && stacked100PercentAreaValue.e() != 0f)
						{
							A_0.Write_l_(stacked100PercentAreaValue.d(), stacked100PercentAreaValue.e());
						}
						if (i == arrayList.Count - 1)
						{
							if (stacked100PercentAreaValue.h() > plotArea.Y + plotArea.Height && A_5 <= num5 && A_5 >= num4)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
							}
						}
						if (num13 <= plotArea.Y + plotArea.Height && num13 >= plotArea.Y)
						{
							A_0.Write_l_(num14, num13);
							if (i == 0)
							{
								float num18 = A_11 - A_10.Value;
								if (A_11 < num18 && num18 > num5 && A_11 <= num5 && A_11 >= num4)
								{
									if (stacked100PercentAreaValue.b() != 0f && stacked100PercentAreaValue.c() != 0f)
									{
										A_0.Write_l_(plotArea.X, plotArea.Y);
										A_0.Write_l_(A_10.i(), A_10.h());
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04003027 RID: 12327
		private float a;

		// Token: 0x04003028 RID: 12328
		private Stacked100PercentAreaSeriesElement b;

		// Token: 0x04003029 RID: 12329
		private PercentageDataLabel c;

		// Token: 0x0400302A RID: 12330
		private float d = 0f;

		// Token: 0x0400302B RID: 12331
		private float e = 0f;

		// Token: 0x0400302C RID: 12332
		private float f = 0f;

		// Token: 0x0400302D RID: 12333
		private int g;

		// Token: 0x0400302E RID: 12334
		private float h = 0f;

		// Token: 0x0400302F RID: 12335
		private float i = 0f;

		// Token: 0x04003030 RID: 12336
		private float j = 0f;

		// Token: 0x04003031 RID: 12337
		private float k = 0f;
	}
}
