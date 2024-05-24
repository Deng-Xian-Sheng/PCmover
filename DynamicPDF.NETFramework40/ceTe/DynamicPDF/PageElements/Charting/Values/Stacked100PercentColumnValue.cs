using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008D8 RID: 2264
	public class Stacked100PercentColumnValue
	{
		// Token: 0x06005D2A RID: 23850 RVA: 0x0034C8CC File Offset: 0x0034B8CC
		internal Stacked100PercentColumnValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06005D2B RID: 23851 RVA: 0x0034C920 File Offset: 0x0034B920
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06005D2C RID: 23852 RVA: 0x0034C938 File Offset: 0x0034B938
		// (set) Token: 0x06005D2D RID: 23853 RVA: 0x0034C950 File Offset: 0x0034B950
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

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06005D2E RID: 23854 RVA: 0x0034C95C File Offset: 0x0034B95C
		// (set) Token: 0x06005D2F RID: 23855 RVA: 0x0034C974 File Offset: 0x0034B974
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

		// Token: 0x06005D30 RID: 23856 RVA: 0x0034C980 File Offset: 0x0034B980
		internal Stacked100PercentColumnSeriesElement b()
		{
			return this.c;
		}

		// Token: 0x06005D31 RID: 23857 RVA: 0x0034C998 File Offset: 0x0034B998
		internal void a(Stacked100PercentColumnSeriesElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005D32 RID: 23858 RVA: 0x0034C9A4 File Offset: 0x0034B9A4
		internal virtual int iq()
		{
			return this.e;
		}

		// Token: 0x06005D33 RID: 23859 RVA: 0x0034C9BC File Offset: 0x0034B9BC
		internal virtual void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005D34 RID: 23860 RVA: 0x0034C9C8 File Offset: 0x0034B9C8
		internal float c()
		{
			return this.h;
		}

		// Token: 0x06005D35 RID: 23861 RVA: 0x0034C9E0 File Offset: 0x0034B9E0
		internal float d()
		{
			return this.j;
		}

		// Token: 0x06005D36 RID: 23862 RVA: 0x0034C9F8 File Offset: 0x0034B9F8
		internal float e()
		{
			return this.k;
		}

		// Token: 0x06005D37 RID: 23863 RVA: 0x0034CA10 File Offset: 0x0034BA10
		internal float f()
		{
			return this.g;
		}

		// Token: 0x06005D38 RID: 23864 RVA: 0x0034CA28 File Offset: 0x0034BA28
		internal void a(PageWriter A_0, Stacked100PercentColumnValue A_1, int A_2, int A_3, int A_4, int A_5, float A_6)
		{
			this.a(A_1, A_5, A_6);
			this.a(A_2, A_4);
			this.a(A_0, A_1, A_3, A_4, A_5);
		}

		// Token: 0x06005D39 RID: 23865 RVA: 0x0034CA50 File Offset: 0x0034BA50
		private void a(PageWriter A_0, Stacked100PercentColumnValue A_1, int A_2, int A_3, int A_4)
		{
			this.i /= (float)A_3;
			this.f += (float)A_2 * this.i;
			if (A_1 != null)
			{
				this.g -= A_1.e();
			}
			float a_ = this.g;
			this.g -= this.h;
			this.k = this.h;
			if (this.c.e().v() < 0f && this.c.e().w() < 0f && this.c.PlotArea.ClipToPlotArea)
			{
				this.a(A_1, A_4);
			}
			else if (this.c.PlotArea.ClipToPlotArea)
			{
				this.a(a_);
			}
			if (this.h != 0f)
			{
				if (this.b == null)
				{
					this.b = this.c.Color;
				}
				A_0.SetFillColor(this.b);
				A_0.Write_re(this.f, this.g, this.i, this.h);
				A_0.Write_f();
			}
			if (A_1 != null)
			{
				this.k += A_1.e();
			}
		}

		// Token: 0x06005D3A RID: 23866 RVA: 0x0034CBBC File Offset: 0x0034BBBC
		internal void a(PageWriter A_0)
		{
			if (this.a >= 0f)
			{
				A_0.Write_re(this.f + this.c.BorderWidth / 2f, this.g + this.c.BorderWidth / 2f, this.i - this.c.BorderWidth, this.h - this.c.BorderWidth);
			}
			else
			{
				A_0.Write_re(this.f + this.c.BorderWidth / 2f, this.g - this.c.BorderWidth / 2f, this.i - this.c.BorderWidth, this.h + this.c.BorderWidth);
			}
			A_0.Write_S();
		}

		// Token: 0x06005D3B RID: 23867 RVA: 0x0034CC9C File Offset: 0x0034BC9C
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
					stringBuilder.Append(" " + this.c.d().r().b(A_1));
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
				float a_ = this.f + this.i / 2f;
				float a_2 = this.g;
				switch (dataLabelLocation)
				{
				case DataLabelLocation.Middle:
					a_ = this.f + this.i / 2f;
					a_2 = this.g + this.h / 2f;
					break;
				case DataLabelLocation.Base:
					a_ = this.f + this.i / 2f;
					a_2 = this.g + this.h;
					break;
				}
				bool a_3 = false;
				if (this.h < 0f)
				{
					a_3 = true;
				}
				this.d.a(A_0, a_, a_2, stringBuilder.ToString(), false, true, a_3, dataLabelLocation);
			}
		}

		// Token: 0x06005D3C RID: 23868 RVA: 0x0034CFC4 File Offset: 0x0034BFC4
		private void a(Stacked100PercentColumnValue A_0, int A_1, float A_2)
		{
			float num = 0f;
			if (this.c.e().v() > 0f && this.c.PlotArea.ClipToPlotArea)
			{
				num = this.c.e().g() * (this.c.e().v() / this.c.e().t());
			}
			this.h = this.c.e().g() * 100f / this.c.e().t() * (this.a / A_2);
			this.l = Math.Abs(this.a) / A_2;
			if (this.c.e().v() > 0f && A_1 == 0 && this.c.PlotArea.ClipToPlotArea)
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
			else if (this.c.e().v() > 0f && A_1 > 0 && this.c.PlotArea.ClipToPlotArea)
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

		// Token: 0x06005D3D RID: 23869 RVA: 0x0034D1E8 File Offset: 0x0034C1E8
		private void a(int A_0, int A_1)
		{
			this.i = this.c.d().g();
			float num = this.i / ((float)A_1 + 1.5f);
			float a_;
			if (A_0 == 0)
			{
				a_ = num * 0.75f;
			}
			else
			{
				a_ = (float)A_0 * num * 1.5f + num * 0.75f;
			}
			this.i -= num * 1.5f;
			this.a(A_0, a_);
		}

		// Token: 0x06005D3E RID: 23870 RVA: 0x0034D270 File Offset: 0x0034C270
		private void a(int A_0, float A_1)
		{
			this.f = this.c.PlotArea.X + this.i * (float)A_0 + A_1 + this.a();
			this.g = this.c.PlotArea.Y + this.c.PlotArea.Height;
			if (this.c.e().v() > 0f && !this.c.PlotArea.ClipToPlotArea)
			{
				this.g += this.c.e().g() * this.c.e().v() / this.c.e().t();
			}
			else
			{
				this.g -= this.c.e().g() * this.c.e().h();
			}
		}

		// Token: 0x06005D3F RID: 23871 RVA: 0x0034D370 File Offset: 0x0034C370
		private float a()
		{
			return this.c.d().s() * this.c.d().g() - this.c.d().g() / 2f;
		}

		// Token: 0x06005D40 RID: 23872 RVA: 0x0034D3BC File Offset: 0x0034C3BC
		private void a(float A_0)
		{
			if (this.a >= 0f)
			{
				if (this.g < this.c.PlotArea.Y)
				{
					float num = this.c.PlotArea.Y - this.g;
					this.g += num;
					this.h -= num;
					if (this.h < 0f)
					{
						this.h = 0f;
					}
					float num2 = this.g;
					float num3 = A_0;
					if ((int)num2 == (int)num3)
					{
						this.h = 0f;
					}
				}
			}
			else if (this.a < 0f)
			{
				if (this.g > this.c.PlotArea.Y + this.c.PlotArea.Height)
				{
					float num = this.g - (this.c.PlotArea.Y + this.c.PlotArea.Height);
					this.g -= num;
					this.h += num;
					float num2 = this.g;
					float num3 = A_0;
					if ((int)num2 == (int)num3)
					{
						this.h = 0f;
					}
				}
			}
		}

		// Token: 0x06005D41 RID: 23873 RVA: 0x0034D538 File Offset: 0x0034C538
		private void a(Stacked100PercentColumnValue A_0, int A_1)
		{
			float num = this.c.e().w() * this.c.e().g() / this.c.e().t();
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
			if (A_0 != null && (int)A_0.f() == (int)(this.c.PlotArea.Y + this.c.PlotArea.Height))
			{
				this.g = this.c.PlotArea.Y + this.c.PlotArea.Height;
				this.h = 0f;
			}
			else if (this.g > this.c.PlotArea.Y + this.c.PlotArea.Height)
			{
				float num3 = this.g - (this.c.PlotArea.Y + this.c.PlotArea.Height);
				this.g -= num3;
				if (this.h != 0f)
				{
					this.h += num3;
				}
			}
		}

		// Token: 0x04003047 RID: 12359
		private float a;

		// Token: 0x04003048 RID: 12360
		private Color b;

		// Token: 0x04003049 RID: 12361
		private Stacked100PercentColumnSeriesElement c;

		// Token: 0x0400304A RID: 12362
		private BarColumnPercentageDataLabel d;

		// Token: 0x0400304B RID: 12363
		private int e;

		// Token: 0x0400304C RID: 12364
		private float f = 0f;

		// Token: 0x0400304D RID: 12365
		private float g = 0f;

		// Token: 0x0400304E RID: 12366
		private float h = 0f;

		// Token: 0x0400304F RID: 12367
		private float i = 0f;

		// Token: 0x04003050 RID: 12368
		private float j;

		// Token: 0x04003051 RID: 12369
		private float k = 0f;

		// Token: 0x04003052 RID: 12370
		private float l;
	}
}
