using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008EE RID: 2286
	public class StackedBarValue
	{
		// Token: 0x06005DE3 RID: 24035 RVA: 0x003530B4 File Offset: 0x003520B4
		internal StackedBarValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x06005DE4 RID: 24036 RVA: 0x00353108 File Offset: 0x00352108
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x06005DE5 RID: 24037 RVA: 0x00353120 File Offset: 0x00352120
		// (set) Token: 0x06005DE6 RID: 24038 RVA: 0x00353138 File Offset: 0x00352138
		public Color Color
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

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x06005DE7 RID: 24039 RVA: 0x00353144 File Offset: 0x00352144
		// (set) Token: 0x06005DE8 RID: 24040 RVA: 0x0035315C File Offset: 0x0035215C
		public BarColumnValuePositionDataLabel DataLabel
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x06005DE9 RID: 24041 RVA: 0x00353168 File Offset: 0x00352168
		internal StackedBarSeriesElement b()
		{
			return this.c;
		}

		// Token: 0x06005DEA RID: 24042 RVA: 0x00353180 File Offset: 0x00352180
		internal void a(StackedBarSeriesElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005DEB RID: 24043 RVA: 0x0035318C File Offset: 0x0035218C
		internal float c()
		{
			return this.h;
		}

		// Token: 0x06005DEC RID: 24044 RVA: 0x003531A4 File Offset: 0x003521A4
		internal virtual int it()
		{
			return this.e;
		}

		// Token: 0x06005DED RID: 24045 RVA: 0x003531BC File Offset: 0x003521BC
		internal virtual void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005DEE RID: 24046 RVA: 0x003531C8 File Offset: 0x003521C8
		internal float d()
		{
			return this.j;
		}

		// Token: 0x06005DEF RID: 24047 RVA: 0x003531E0 File Offset: 0x003521E0
		internal float e()
		{
			return this.k;
		}

		// Token: 0x06005DF0 RID: 24048 RVA: 0x003531F8 File Offset: 0x003521F8
		internal void a(PageWriter A_0, StackedBarValue A_1, int A_2, int A_3, int A_4, int A_5)
		{
			this.b(A_1, A_5);
			this.a(A_2, A_4);
			this.a(A_0, A_1, A_3, A_4, A_5);
		}

		// Token: 0x06005DF1 RID: 24049 RVA: 0x00353220 File Offset: 0x00352220
		internal void a(PageWriter A_0, int A_1)
		{
			if (this.d == null && this.c.DataLabel != null)
			{
				this.d = this.c.DataLabel;
			}
			if (this.d != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.d.Prefix);
				if (this.d.ShowValue)
				{
					stringBuilder.Append(this.a.ToString(this.c.ValueFormat));
				}
				if (this.d.ShowPosition)
				{
					if (this.d.ShowValue)
					{
						stringBuilder.Append(this.d.Separator);
					}
					stringBuilder.Append(" " + this.c.e().r().b(A_1));
				}
				if (this.d.ShowSeries)
				{
					if (this.d.ShowPosition || this.d.ShowValue)
					{
						stringBuilder.Append(this.d.Separator);
					}
					stringBuilder.Append(" " + this.c.Name);
				}
				stringBuilder.Append(this.d.Suffix);
				this.d.a(this.c.PlotArea.Chart);
				DataLabelLocation dataLabelLocation = this.d.Location;
				if (dataLabelLocation == DataLabelLocation.Default)
				{
					dataLabelLocation = DataLabelLocation.Middle;
				}
				float num = this.f + this.h;
				float a_ = this.g + this.i / 2f;
				switch (dataLabelLocation)
				{
				case DataLabelLocation.Middle:
					num -= this.h / 2f;
					break;
				case DataLabelLocation.Base:
					num -= this.h;
					break;
				}
				bool a_2 = false;
				if (this.i < 0f)
				{
					a_2 = true;
				}
				this.d.a(A_0, num, a_, stringBuilder.ToString(), true, true, a_2, dataLabelLocation);
			}
		}

		// Token: 0x06005DF2 RID: 24050 RVA: 0x00353460 File Offset: 0x00352460
		internal void a(PageWriter A_0)
		{
			if (this.a >= 0f)
			{
				A_0.Write_re(this.f + this.c.BorderWidth / 2f, this.g + this.c.BorderWidth / 2f, this.h - this.c.BorderWidth, this.i - this.c.BorderWidth);
			}
			else
			{
				A_0.Write_re(this.f - this.c.BorderWidth / 2f, this.g + this.c.BorderWidth / 2f, this.h + this.c.BorderWidth, this.i - this.c.BorderWidth);
			}
			A_0.Write_S();
		}

		// Token: 0x06005DF3 RID: 24051 RVA: 0x00353540 File Offset: 0x00352540
		private void a(PageWriter A_0, StackedBarValue A_1, int A_2, int A_3, int A_4)
		{
			this.i /= (float)A_3;
			if (A_1 != null)
			{
				if (this.c.d().v() < 0f && this.c.d().w() < 0f && this.c.PlotArea.ClipToPlotArea)
				{
					this.a(A_1, A_4);
				}
				this.f += A_1.e();
				if (this.c.PlotArea.ClipToPlotArea)
				{
					this.a(A_1.e());
				}
			}
			else
			{
				if (this.c.d().v() < 0f && this.c.d().w() < 0f && this.c.PlotArea.ClipToPlotArea)
				{
					this.a(A_1, A_4);
				}
				if (this.c.PlotArea.ClipToPlotArea)
				{
					this.a(0f);
				}
			}
			this.k = this.h;
			this.g -= this.i + (float)A_2 * this.i;
			if (this.h != 0f)
			{
				if (this.b == null)
				{
					this.b = this.c.Color;
				}
				A_0.SetFillColor(this.b);
				A_0.Write_re(this.f, this.g, this.h, this.i);
				A_0.Write_f();
			}
			if (A_1 != null)
			{
				this.k += A_1.e();
			}
		}

		// Token: 0x06005DF4 RID: 24052 RVA: 0x0035371C File Offset: 0x0035271C
		private void b(StackedBarValue A_0, int A_1)
		{
			this.h = this.a;
			if (this.c.d().v() > 0f && A_1 == 0 && this.c.PlotArea.ClipToPlotArea)
			{
				if (this.a > this.c.d().v())
				{
					this.h -= this.c.d().v();
					this.h = this.h * this.c.d().g() / this.c.d().t();
				}
				else
				{
					this.h = 0f;
				}
				this.j = this.a;
			}
			else if (this.c.d().v() > 0f && A_1 > 0 && this.c.PlotArea.ClipToPlotArea)
			{
				float num = 0f;
				if (A_0 != null)
				{
					num = A_0.d();
				}
				if (this.c.d().v() >= num)
				{
					this.h -= this.c.d().v() - num;
					if (this.h > 0f)
					{
						this.h = this.h * this.c.d().g() / this.c.d().t();
					}
					else
					{
						this.h = 0f;
					}
				}
				else
				{
					this.h = this.h * this.c.d().g() / this.c.d().t();
				}
				this.j = num + this.a;
			}
			else
			{
				this.h = this.h * this.c.d().g() / this.c.d().t();
			}
		}

		// Token: 0x06005DF5 RID: 24053 RVA: 0x00353944 File Offset: 0x00352944
		private void a(int A_0, int A_1)
		{
			this.i = this.c.e().g();
			float num = this.i / ((float)A_1 + 1.5f);
			float a_;
			if (A_0 == 0)
			{
				a_ = num * 0.75f;
			}
			else
			{
				a_ = num * 1.5f * (float)A_0 + num * 0.75f;
			}
			this.i -= num * 1.5f;
			this.a(A_0, a_);
		}

		// Token: 0x06005DF6 RID: 24054 RVA: 0x003539CC File Offset: 0x003529CC
		private void a(int A_0, float A_1)
		{
			this.f = this.c.PlotArea.X;
			if (this.c.d().v() > 0f && !this.c.PlotArea.ClipToPlotArea)
			{
				this.f -= this.c.d().g() * this.c.d().v() / this.c.d().t();
			}
			else
			{
				this.f += this.c.d().g() * this.c.d().h();
			}
			this.g = this.c.PlotArea.Y + this.c.PlotArea.Height - (this.i * (float)A_0 + A_1 + this.a());
		}

		// Token: 0x06005DF7 RID: 24055 RVA: 0x00353ACC File Offset: 0x00352ACC
		private float a()
		{
			return this.c.e().s() * this.c.e().g() - this.c.e().g() / 2f;
		}

		// Token: 0x06005DF8 RID: 24056 RVA: 0x00353B18 File Offset: 0x00352B18
		private void a(float A_0)
		{
			if (this.a >= 0f)
			{
				if (this.f + this.h > this.c.PlotArea.X + this.c.PlotArea.Width)
				{
					float num = this.f + this.h - (this.c.PlotArea.X + this.c.PlotArea.Width);
					this.h -= num;
					float num2 = A_0 + this.h;
					if ((int)num2 == (int)A_0)
					{
						this.h = 0f;
					}
				}
			}
			else if (this.a < 0f)
			{
				if (this.f + this.h < this.c.PlotArea.X)
				{
					float num = this.c.PlotArea.X - (this.f + this.h);
					this.h += num;
					float num2 = A_0 + this.h;
					if ((int)num2 == (int)A_0)
					{
						this.h = 0f;
					}
				}
			}
		}

		// Token: 0x06005DF9 RID: 24057 RVA: 0x00353C70 File Offset: 0x00352C70
		private void a(StackedBarValue A_0, int A_1)
		{
			this.f += this.c.d().w() * this.c.d().g() / this.c.d().t();
			if (A_1 == 0)
			{
				this.j = this.a;
				if (this.a < this.c.d().w())
				{
					this.h -= this.c.d().w() * this.c.d().g() / this.c.d().t();
				}
				else
				{
					this.h = 0f;
				}
			}
			else if (A_1 > 0)
			{
				if (A_0 != null)
				{
					float num = A_0.d();
					this.j = A_0.d() + this.a;
					if (A_0.c() == 0f && num + this.a < this.c.d().w())
					{
						this.h = (num + this.a) * this.c.d().g() / this.c.d().t() - this.c.d().w() * this.c.d().g() / this.c.d().t();
					}
					else if (A_0.c() == 0f && num + this.a > this.c.d().w())
					{
						this.h = 0f;
					}
				}
				else
				{
					this.j = this.a;
					if (this.a < this.c.d().w())
					{
						this.h -= this.c.d().w() * this.c.d().g() / this.c.d().t();
					}
					else
					{
						this.h = 0f;
					}
				}
			}
		}

		// Token: 0x04003080 RID: 12416
		private float a;

		// Token: 0x04003081 RID: 12417
		private Color b;

		// Token: 0x04003082 RID: 12418
		private StackedBarSeriesElement c;

		// Token: 0x04003083 RID: 12419
		private BarColumnValuePositionDataLabel d;

		// Token: 0x04003084 RID: 12420
		private int e;

		// Token: 0x04003085 RID: 12421
		private float f = 0f;

		// Token: 0x04003086 RID: 12422
		private float g = 0f;

		// Token: 0x04003087 RID: 12423
		private float h = 0f;

		// Token: 0x04003088 RID: 12424
		private float i = 0f;

		// Token: 0x04003089 RID: 12425
		private float j;

		// Token: 0x0400308A RID: 12426
		private float k = 0f;
	}
}
