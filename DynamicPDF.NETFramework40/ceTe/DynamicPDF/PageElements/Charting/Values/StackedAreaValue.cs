using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008EA RID: 2282
	public class StackedAreaValue
	{
		// Token: 0x06005DB4 RID: 23988 RVA: 0x00351044 File Offset: 0x00350044
		internal StackedAreaValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x06005DB5 RID: 23989 RVA: 0x003510B0 File Offset: 0x003500B0
		// (set) Token: 0x06005DB6 RID: 23990 RVA: 0x003510C8 File Offset: 0x003500C8
		public ValuePositionDataLabel DataLabel
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

		// Token: 0x06005DB7 RID: 23991 RVA: 0x003510D4 File Offset: 0x003500D4
		internal float b()
		{
			return this.h;
		}

		// Token: 0x06005DB8 RID: 23992 RVA: 0x003510EC File Offset: 0x003500EC
		internal void a(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06005DB9 RID: 23993 RVA: 0x003510F8 File Offset: 0x003500F8
		internal float c()
		{
			return this.i;
		}

		// Token: 0x06005DBA RID: 23994 RVA: 0x00351110 File Offset: 0x00350110
		internal void b(float A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06005DBB RID: 23995 RVA: 0x0035111C File Offset: 0x0035011C
		internal float d()
		{
			return this.j;
		}

		// Token: 0x06005DBC RID: 23996 RVA: 0x00351134 File Offset: 0x00350134
		internal void c(float A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06005DBD RID: 23997 RVA: 0x00351140 File Offset: 0x00350140
		internal float e()
		{
			return this.k;
		}

		// Token: 0x06005DBE RID: 23998 RVA: 0x00351158 File Offset: 0x00350158
		internal void d(float A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06005DBF RID: 23999 RVA: 0x00351164 File Offset: 0x00350164
		internal int f()
		{
			return this.g;
		}

		// Token: 0x06005DC0 RID: 24000 RVA: 0x0035117C File Offset: 0x0035017C
		internal void a(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x06005DC1 RID: 24001 RVA: 0x00351188 File Offset: 0x00350188
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005DC2 RID: 24002 RVA: 0x003511A0 File Offset: 0x003501A0
		internal StackedAreaSeriesElement g()
		{
			return this.b;
		}

		// Token: 0x06005DC3 RID: 24003 RVA: 0x003511B8 File Offset: 0x003501B8
		internal void a(StackedAreaSeriesElement A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005DC4 RID: 24004 RVA: 0x003511C4 File Offset: 0x003501C4
		internal float h()
		{
			return this.f;
		}

		// Token: 0x06005DC5 RID: 24005 RVA: 0x003511DC File Offset: 0x003501DC
		internal void e(float A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06005DC6 RID: 24006 RVA: 0x003511E8 File Offset: 0x003501E8
		internal float i()
		{
			return this.e;
		}

		// Token: 0x06005DC7 RID: 24007 RVA: 0x00351200 File Offset: 0x00350200
		internal void f(float A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005DC8 RID: 24008 RVA: 0x0035120C File Offset: 0x0035020C
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005DC9 RID: 24009 RVA: 0x00351234 File Offset: 0x00350234
		internal void a(PageWriter A_0, int A_1, int A_2, StackedAreaValue A_3, StackedAreaSeriesElement A_4, float A_5, float A_6, StackedAreaValue A_7, StackedAreaValue A_8, float A_9)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			PlotArea plotArea = this.b.PlotArea;
			XAxis xaxis = this.b.d();
			YAxis yaxis = this.b.e();
			float num4 = yaxis.v();
			float num5 = yaxis.w();
			float num6 = yaxis.g();
			float num7 = xaxis.g();
			float num8 = num4 - yaxis.s() * num6;
			float num9 = num5 + yaxis.s() * num6;
			float num10 = (float)A_1 * num7;
			float num11 = (float)(A_1 + 1) * num7;
			float num12;
			float num13;
			if (num4 > 0f)
			{
				num12 = (A_5 - num4) * num6 / yaxis.t();
				num13 = (A_6 - num4) * num6 / yaxis.t();
			}
			else
			{
				num12 = A_5 * num6 / yaxis.t();
				num13 = A_6 * num6 / yaxis.t();
			}
			float num14 = plotArea.Height + plotArea.Y - num12 - num6 * yaxis.h();
			float num15 = plotArea.X + num7 * xaxis.s() + num10;
			float num16 = plotArea.Height + plotArea.Y - num13 - num6 * yaxis.h();
			float num17 = plotArea.X + num7 * xaxis.s() + num11;
			A_3.f(num17);
			A_3.e(num16);
			this.f(num15);
			this.e(num14);
			float num18 = plotArea.Height + plotArea.Y;
			float y = plotArea.Y;
			num = this.a(num15, num14, num17, num16, num, num18);
			if (A_5 < num8 && A_6 >= num8 && A_6 <= num9)
			{
				num3 = 1;
			}
			if (A_5 >= num8 && A_5 <= num9 && A_6 >= num8 && A_6 <= num9)
			{
				num3 = 2;
			}
			if (A_5 >= num8 && A_5 <= num9 && A_6 < num8)
			{
				num3 = 3;
			}
			if (A_5 < num8 && A_6 > num9)
			{
				num3 = 4;
				num2 = this.a(num15, num14, num17, num16, num2, y);
			}
			if (A_5 > num9 && A_6 < num8)
			{
				num3 = 7;
				num2 = this.a(num15, num14, num17, num16, num2, y);
			}
			if (A_5 >= num8 && A_5 <= num9 && A_6 > num9)
			{
				num2 = this.a(num15, num14, num17, num16, num2, y);
				num3 = 5;
			}
			if (A_5 > num9 && A_6 >= num8 && A_6 <= num9)
			{
				num2 = this.a(num15, num14, num17, num16, num2, y);
				num3 = 6;
			}
			if (A_1 == 0)
			{
				if (A_5 > num9)
				{
					if (A_4 == null)
					{
						if (num8 < 0f && num9 >= 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + num6 * Math.Abs(num5) / yaxis.t());
							A_0.Write_l_(plotArea.X, plotArea.Y);
						}
						else if (num8 < 0f && num9 < 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y);
						}
					}
					else if (A_7.b() != 0f && A_7.c() != 0f)
					{
						A_0.Write_m_(A_7.b(), A_7.c());
					}
					else
					{
						A_0.Write_m_(A_7.i(), A_7.h());
						A_0.Write_m_(plotArea.X, plotArea.Y);
					}
				}
				else if (A_5 <= num9 && A_5 >= num8)
				{
					if (A_4 == null)
					{
						if (this.b.e().w() < 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num6 * yaxis.h() + this.b.e().g() * Math.Abs(this.b.e().w()) / this.b.e().t());
						}
						else
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num6 * yaxis.h());
						}
					}
					else if (A_7.b() != 0f && A_7.c() != 0f)
					{
						if (num5 < 0f)
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num6 * yaxis.h() + num6 * Math.Abs(num5) / yaxis.t());
						}
						else
						{
							A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height);
						}
					}
					else if (A_7.h() < plotArea.Y)
					{
						A_0.Write_m_(plotArea.X, plotArea.Y);
					}
					else if (A_7.h() > plotArea.Y + plotArea.Height)
					{
						A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height);
					}
					else
					{
						A_0.Write_m_(A_7.i(), A_7.h());
					}
				}
				else
				{
					A_0.Write_m_(plotArea.X, plotArea.Y + plotArea.Height - num6 * yaxis.h());
					A_0.Write_l_(plotArea.X, plotArea.Y + plotArea.Height);
				}
			}
			if (num3 == 1)
			{
				if (A_6 == num8)
				{
					A_0.Write_l_(num, num18);
				}
				else
				{
					A_0.Write_l_(num, num18);
					A_0.Write_l_(num17, num16);
				}
				if (this.b() == 0f)
				{
					this.a(num);
					this.b(num18);
				}
				else
				{
					this.c(num);
					this.d(num18);
				}
			}
			else if (num3 == 2)
			{
				if (A_1 == 0)
				{
					A_0.Write_l_(num15, num14);
					A_0.Write_l_(num17, num16);
				}
				else
				{
					A_0.Write_l_(num17, num16);
				}
			}
			else if (num3 == 3)
			{
				if (A_1 == 0)
				{
					A_0.Write_l_(num15, num14);
					A_0.Write_l_(num, num18);
				}
				else
				{
					A_0.Write_l_(num, num18);
				}
				if (A_3.b() == 0f)
				{
					A_3.a(num);
					A_3.b(num18);
				}
				else
				{
					A_3.c(num);
					A_3.d(num18);
				}
			}
			else if (num3 == 4)
			{
				A_0.Write_l_(num, num18);
				A_0.Write_l_(num2, y);
				this.a(num);
				this.b(num18);
				if (A_3.b() == 0f && A_3.c() == 0f)
				{
					A_3.a(num2);
					A_3.b(y);
				}
				else
				{
					A_3.c(num2);
					A_3.d(y);
				}
			}
			else if (num3 == 7)
			{
				A_0.Write_l_(num2, y);
				A_0.Write_l_(num, num18);
				this.a(num2);
				this.b(y);
				if (A_3.b() == 0f && A_3.c() == 0f)
				{
					A_3.a(num);
					A_3.b(num18);
				}
				else
				{
					A_3.c(num);
					A_3.d(num18);
				}
			}
			else if (num3 == 5)
			{
				if (A_1 == 0)
				{
					A_0.Write_l_(num15, num14);
					A_0.Write_l_(num2, y);
				}
				else
				{
					A_0.Write_l_(num2, y);
				}
				if (A_3.b() == 0f && A_3.c() == 0f)
				{
					A_3.a(num2);
					A_3.b(y);
				}
				else
				{
					A_3.c(num2);
					A_3.d(y);
				}
			}
			else if (num3 == 6)
			{
				if (A_6 == num9)
				{
					A_0.Write_l_(num2, y);
				}
				else
				{
					A_0.Write_l_(num2, y);
					A_0.Write_l_(num17, num16);
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
			if (A_1 == A_2 - 2)
			{
				if (num4 < 0f && num5 <= 0f && A_5 < num8)
				{
					A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
				}
				if (num14 < plotArea.Y && num16 < plotArea.Y)
				{
					A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
				}
				if (A_3.b() != 0f && A_3.c() != 0f)
				{
					if (A_4 == null)
					{
						if (A_6 > num9)
						{
							if (num8 < 0f && num9 >= 0f)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + num6 * Math.Abs(num5) / yaxis.t());
							}
							else if (num8 < 0f && num9 < 0f)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
							}
						}
						else if (A_6 < num8)
						{
							A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
							A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height - num6 * yaxis.h());
						}
					}
					else
					{
						ArrayList arrayList = A_4.a().f();
						A_7 = (StackedAreaValue)arrayList[arrayList.Count - 1];
						if (A_6 > num9)
						{
							if (A_7.b() == 0f && A_7.c() == 0f)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
							}
							else
							{
								A_0.Write_l_(A_7.b(), A_7.c());
							}
						}
						else if (A_6 < num8)
						{
							A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
						}
					}
				}
				else if (A_4 == null)
				{
					if (this.b.e().v() < 0f && this.b.e().w() < 0f)
					{
						A_0.Write_l_(num17, plotArea.Y);
					}
					else
					{
						A_0.Write_l_(num17, num16 + num13);
					}
				}
				else
				{
					ArrayList arrayList = A_4.a().f();
					A_7 = (StackedAreaValue)arrayList[arrayList.Count - 1];
					if (A_6 <= num9 && A_6 >= num8)
					{
						if ((A_7.b() != 0f && A_7.c() != 0f) || A_7.h() < plotArea.Y)
						{
							if (A_6 - A_3.Value < num8)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
							}
							else if (A_6 - A_3.Value > num9)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y);
							}
						}
					}
				}
				if (A_4 != null)
				{
					ArrayList arrayList = A_4.a().f();
					for (int i = arrayList.Count - 1; i >= 0; i--)
					{
						StackedAreaValue stackedAreaValue = (StackedAreaValue)arrayList[i];
						if (stackedAreaValue.b() == 0f && stackedAreaValue.c() == 0f)
						{
							num15 = stackedAreaValue.i();
							num14 = stackedAreaValue.h();
						}
						else
						{
							num15 = stackedAreaValue.b();
							num14 = stackedAreaValue.c();
						}
						if (stackedAreaValue.d() != 0f && stackedAreaValue.e() != 0f)
						{
							A_0.Write_l_(stackedAreaValue.d(), stackedAreaValue.e());
						}
						if (i == arrayList.Count - 1)
						{
							if (stackedAreaValue.h() > plotArea.Y + plotArea.Height && A_6 <= num9 && A_6 >= num8)
							{
								A_0.Write_l_(plotArea.X + plotArea.Width, plotArea.Y + plotArea.Height);
							}
						}
						if ((int)num14 <= (int)(plotArea.Y + plotArea.Height) && (int)num14 >= (int)plotArea.Y)
						{
							A_0.Write_l_(num15, num14);
							if (i == 0)
							{
								float num19 = A_9 - A_8.Value;
								if (A_9 < num19 && num19 > num9 && A_9 <= num9 && A_9 >= num8)
								{
									if (stackedAreaValue.b() != 0f && stackedAreaValue.c() != 0f)
									{
										A_0.Write_l_(plotArea.X, plotArea.Y);
										A_0.Write_l_(A_8.i(), A_8.h());
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06005DCA RID: 24010 RVA: 0x003522B8 File Offset: 0x003512B8
		internal void a(PageWriter A_0, PlotArea A_1, int A_2, int A_3, StackedAreaValue A_4, StackedAreaSeriesElement A_5, float A_6)
		{
			XAxis xaxis = this.b.d();
			YAxis yaxis = this.b.e();
			float num = xaxis.g();
			float num2 = yaxis.g();
			float num3 = A_6 * num2 / yaxis.t();
			float num4 = A_1.X + num * xaxis.s() + num * (float)A_2;
			float num5 = A_1.Height + A_1.Y - num3 - num2 * yaxis.h();
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
						StackedAreaValue stackedAreaValue = (StackedAreaValue)arrayList[i - 1];
						num4 = stackedAreaValue.i();
						num5 = stackedAreaValue.h();
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

		// Token: 0x04003070 RID: 12400
		private float a;

		// Token: 0x04003071 RID: 12401
		private StackedAreaSeriesElement b;

		// Token: 0x04003072 RID: 12402
		private ValuePositionDataLabel c;

		// Token: 0x04003073 RID: 12403
		private float d = 0f;

		// Token: 0x04003074 RID: 12404
		private float e = 0f;

		// Token: 0x04003075 RID: 12405
		private float f = 0f;

		// Token: 0x04003076 RID: 12406
		private int g;

		// Token: 0x04003077 RID: 12407
		private float h = 0f;

		// Token: 0x04003078 RID: 12408
		private float i = 0f;

		// Token: 0x04003079 RID: 12409
		private float j = 0f;

		// Token: 0x0400307A RID: 12410
		private float k = 0f;
	}
}
