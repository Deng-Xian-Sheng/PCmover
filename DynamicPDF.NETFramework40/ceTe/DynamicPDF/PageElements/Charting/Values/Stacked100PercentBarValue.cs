using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D4 RID: 2260
	public class Stacked100PercentBarValue
	{
		// Token: 0x06005CFF RID: 23807 RVA: 0x0034B1C0 File Offset: 0x0034A1C0
		internal Stacked100PercentBarValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x06005D00 RID: 23808 RVA: 0x0034B214 File Offset: 0x0034A214
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x06005D01 RID: 23809 RVA: 0x0034B22C File Offset: 0x0034A22C
		// (set) Token: 0x06005D02 RID: 23810 RVA: 0x0034B244 File Offset: 0x0034A244
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

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x06005D03 RID: 23811 RVA: 0x0034B250 File Offset: 0x0034A250
		// (set) Token: 0x06005D04 RID: 23812 RVA: 0x0034B268 File Offset: 0x0034A268
		public BarColumnPercentageDataLabel DataLabel
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

		// Token: 0x06005D05 RID: 23813 RVA: 0x0034B274 File Offset: 0x0034A274
		internal Stacked100PercentBarSeriesElement b()
		{
			return this.c;
		}

		// Token: 0x06005D06 RID: 23814 RVA: 0x0034B28C File Offset: 0x0034A28C
		internal void a(Stacked100PercentBarSeriesElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005D07 RID: 23815 RVA: 0x0034B298 File Offset: 0x0034A298
		internal float c()
		{
			return this.h;
		}

		// Token: 0x06005D08 RID: 23816 RVA: 0x0034B2B0 File Offset: 0x0034A2B0
		internal virtual int ip()
		{
			return this.e;
		}

		// Token: 0x06005D09 RID: 23817 RVA: 0x0034B2C8 File Offset: 0x0034A2C8
		internal virtual void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005D0A RID: 23818 RVA: 0x0034B2D4 File Offset: 0x0034A2D4
		internal float d()
		{
			return this.j;
		}

		// Token: 0x06005D0B RID: 23819 RVA: 0x0034B2EC File Offset: 0x0034A2EC
		internal float e()
		{
			return this.k;
		}

		// Token: 0x06005D0C RID: 23820 RVA: 0x0034B304 File Offset: 0x0034A304
		internal void a(PageWriter A_0, Stacked100PercentBarValue A_1, int A_2, int A_3, int A_4, int A_5, float A_6)
		{
			this.a(A_1, A_5, A_6);
			this.a(A_2, A_4);
			this.a(A_0, A_1, A_3, A_4, A_5);
		}

		// Token: 0x06005D0D RID: 23821 RVA: 0x0034B32C File Offset: 0x0034A32C
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
				if (this.d.ShowPercentage)
				{
					if (this.d.ShowValue)
					{
						stringBuilder.Append(this.d.Separator);
					}
					if (this.c.PercentageFormat.IndexOf('%') != -1)
					{
						stringBuilder.Append(this.l.ToString(this.c.PercentageFormat));
					}
					else
					{
						stringBuilder.Append((100f * this.l).ToString(this.c.PercentageFormat));
					}
				}
				if (this.d.ShowPosition)
				{
					if (this.d.ShowValue || this.d.ShowPercentage)
					{
						stringBuilder.Append(this.d.Separator);
					}
					stringBuilder.Append(" " + this.c.e().r().b(A_1));
				}
				if (this.d.ShowSeries)
				{
					if (this.d.ShowPosition || this.d.ShowValue || this.d.ShowPercentage)
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

		// Token: 0x06005D0E RID: 23822 RVA: 0x0034B628 File Offset: 0x0034A628
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

		// Token: 0x06005D0F RID: 23823 RVA: 0x0034B708 File Offset: 0x0034A708
		private void a(PageWriter A_0, Stacked100PercentBarValue A_1, int A_2, int A_3, int A_4)
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

		// Token: 0x06005D10 RID: 23824 RVA: 0x0034B8E4 File Offset: 0x0034A8E4
		private void a(Stacked100PercentBarValue A_0, int A_1, float A_2)
		{
			float num = 0f;
			if (this.c.d().v() > 0f && this.c.PlotArea.ClipToPlotArea)
			{
				num = this.c.d().g() * (this.c.d().v() / this.c.d().t());
			}
			this.h = this.c.d().g() * 100f / this.c.d().t() * (this.a / A_2);
			this.l = Math.Abs(this.a) / A_2;
			if (this.c.d().v() > 0f && A_1 == 0 && this.c.PlotArea.ClipToPlotArea)
			{
				this.j = this.h;
				if (num > this.h)
				{
					this.h = 0f;
				}
				else
				{
					this.h -= num;
					if (this.h < 0.1f)
					{
						this.h = 0f;
					}
				}
			}
			else if (this.c.d().v() > 0f && A_1 > 0 && this.c.PlotArea.ClipToPlotArea)
			{
				float num2 = 0f;
				if (A_0 != null)
				{
					num2 = A_0.d();
				}
				if (num >= num2)
				{
					this.j = num2 + this.h;
					if (num - num2 > this.h)
					{
						this.h = 0f;
					}
					else
					{
						this.h -= num - num2;
						if (this.h < 0.1f)
						{
							this.h = 0f;
						}
					}
				}
				else
				{
					this.j = num2 + this.h;
				}
			}
		}

		// Token: 0x06005D11 RID: 23825 RVA: 0x0034BB08 File Offset: 0x0034AB08
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

		// Token: 0x06005D12 RID: 23826 RVA: 0x0034BB90 File Offset: 0x0034AB90
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

		// Token: 0x06005D13 RID: 23827 RVA: 0x0034BC90 File Offset: 0x0034AC90
		private float a()
		{
			return this.c.e().s() * this.c.e().g() - this.c.e().g() / 2f;
		}

		// Token: 0x06005D14 RID: 23828 RVA: 0x0034BCDC File Offset: 0x0034ACDC
		private void a(float A_0)
		{
			if (this.a >= 0f)
			{
				if (this.f + this.h > this.c.PlotArea.X + this.c.PlotArea.Width)
				{
					float num = this.f + this.h - (this.c.PlotArea.X + this.c.PlotArea.Width);
					this.h -= num;
					float num2 = A_0 + this.h;
					float num3 = A_0;
					if ((int)num2 == (int)num3)
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
					float num3 = A_0;
					if ((int)num2 == (int)num3)
					{
						this.h = 0f;
					}
				}
			}
		}

		// Token: 0x06005D15 RID: 23829 RVA: 0x0034BE38 File Offset: 0x0034AE38
		private void a(Stacked100PercentBarValue A_0, int A_1)
		{
			this.f += this.c.d().w() * this.c.d().g() / this.c.d().t();
			float num = this.c.d().w() * this.c.d().g() / this.c.d().t();
			if (A_1 == 0)
			{
				this.j = this.h;
				if (this.h < num)
				{
					this.h -= num;
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
					float num2 = A_0.d();
					this.j = A_0.d() + this.h;
					if (A_0.c() == 0f && num2 + this.h < num)
					{
						this.h = num2 + this.h - num;
					}
					else if (A_0.c() == 0f && num2 + this.h > num)
					{
						this.h = 0f;
					}
				}
				else
				{
					this.j = this.h;
					if (this.h < num)
					{
						this.h -= num;
					}
					else
					{
						this.h = 0f;
					}
				}
			}
			if (this.h > -0.1f)
			{
				this.h = 0f;
			}
		}

		// Token: 0x04003037 RID: 12343
		private float a;

		// Token: 0x04003038 RID: 12344
		private Color b;

		// Token: 0x04003039 RID: 12345
		private Stacked100PercentBarSeriesElement c;

		// Token: 0x0400303A RID: 12346
		private BarColumnPercentageDataLabel d;

		// Token: 0x0400303B RID: 12347
		private int e;

		// Token: 0x0400303C RID: 12348
		private float f = 0f;

		// Token: 0x0400303D RID: 12349
		private float g = 0f;

		// Token: 0x0400303E RID: 12350
		private float h = 0f;

		// Token: 0x0400303F RID: 12351
		private float i = 0f;

		// Token: 0x04003040 RID: 12352
		private float j;

		// Token: 0x04003041 RID: 12353
		private float k = 0f;

		// Token: 0x04003042 RID: 12354
		private float l;
	}
}
