using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008F2 RID: 2290
	public class StackedColumnValue
	{
		// Token: 0x06005E0E RID: 24078 RVA: 0x003547A0 File Offset: 0x003537A0
		internal StackedColumnValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06005E0F RID: 24079 RVA: 0x003547F4 File Offset: 0x003537F4
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06005E10 RID: 24080 RVA: 0x0035480C File Offset: 0x0035380C
		// (set) Token: 0x06005E11 RID: 24081 RVA: 0x00354824 File Offset: 0x00353824
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

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06005E12 RID: 24082 RVA: 0x00354830 File Offset: 0x00353830
		// (set) Token: 0x06005E13 RID: 24083 RVA: 0x00354848 File Offset: 0x00353848
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

		// Token: 0x06005E14 RID: 24084 RVA: 0x00354854 File Offset: 0x00353854
		internal StackedColumnSeriesElement b()
		{
			return this.c;
		}

		// Token: 0x06005E15 RID: 24085 RVA: 0x0035486C File Offset: 0x0035386C
		internal void a(StackedColumnSeriesElement A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005E16 RID: 24086 RVA: 0x00354878 File Offset: 0x00353878
		internal virtual int iu()
		{
			return this.e;
		}

		// Token: 0x06005E17 RID: 24087 RVA: 0x00354890 File Offset: 0x00353890
		internal virtual void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005E18 RID: 24088 RVA: 0x0035489C File Offset: 0x0035389C
		internal float c()
		{
			return this.h;
		}

		// Token: 0x06005E19 RID: 24089 RVA: 0x003548B4 File Offset: 0x003538B4
		internal float d()
		{
			return this.j;
		}

		// Token: 0x06005E1A RID: 24090 RVA: 0x003548CC File Offset: 0x003538CC
		internal float e()
		{
			return this.k;
		}

		// Token: 0x06005E1B RID: 24091 RVA: 0x003548E4 File Offset: 0x003538E4
		internal void a(PageWriter A_0, StackedColumnValue A_1, int A_2, int A_3, int A_4, int A_5)
		{
			this.b(A_1, A_5);
			this.a(A_2, A_4);
			this.a(A_0, A_1, A_3, A_4, A_5);
		}

		// Token: 0x06005E1C RID: 24092 RVA: 0x0035490C File Offset: 0x0035390C
		private void a(PageWriter A_0, StackedColumnValue A_1, int A_2, int A_3, int A_4)
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

		// Token: 0x06005E1D RID: 24093 RVA: 0x00354A78 File Offset: 0x00353A78
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

		// Token: 0x06005E1E RID: 24094 RVA: 0x00354B58 File Offset: 0x00353B58
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
					stringBuilder.Append(" " + this.c.d().r().b(A_1));
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

		// Token: 0x06005E1F RID: 24095 RVA: 0x00354DC4 File Offset: 0x00353DC4
		private void b(StackedColumnValue A_0, int A_1)
		{
			this.h = this.a;
			if (this.c.e().v() > 0f && A_1 == 0 && this.c.PlotArea.ClipToPlotArea)
			{
				if (this.a > this.c.e().v())
				{
					this.h -= this.c.e().v();
					this.h = this.h * this.c.e().g() / this.c.e().t();
				}
				else
				{
					this.h = 0f;
				}
				this.j = this.a;
			}
			else if (this.c.e().v() > 0f && A_1 > 0 && this.c.PlotArea.ClipToPlotArea)
			{
				float num = 0f;
				if (A_0 != null)
				{
					num = A_0.d();
				}
				if (this.c.e().v() >= num)
				{
					this.h -= this.c.e().v() - num;
					if (this.h > 0f)
					{
						this.h = this.h * this.c.e().g() / this.c.e().t();
					}
					else
					{
						this.h = 0f;
					}
				}
				else
				{
					this.h = this.h * this.c.e().g() / this.c.e().t();
				}
				this.j = num + this.a;
			}
			else
			{
				this.h = this.h * this.c.e().g() / this.c.e().t();
			}
		}

		// Token: 0x06005E20 RID: 24096 RVA: 0x00354FEC File Offset: 0x00353FEC
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

		// Token: 0x06005E21 RID: 24097 RVA: 0x00355074 File Offset: 0x00354074
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

		// Token: 0x06005E22 RID: 24098 RVA: 0x00355174 File Offset: 0x00354174
		private float a()
		{
			return this.c.d().s() * this.c.d().g() - this.c.d().g() / 2f;
		}

		// Token: 0x06005E23 RID: 24099 RVA: 0x003551C0 File Offset: 0x003541C0
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
					if ((int)num2 == (int)A_0)
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
					if ((int)num2 == (int)A_0)
					{
						this.h = 0f;
					}
				}
			}
		}

		// Token: 0x06005E24 RID: 24100 RVA: 0x00355338 File Offset: 0x00354338
		private void a(StackedColumnValue A_0, int A_1)
		{
			if (A_1 == 0)
			{
				this.j = this.a;
				if (this.a < this.c.e().w())
				{
					this.h -= this.c.e().w() * this.c.e().g() / this.c.e().t();
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
					if (A_0.c() == 0f && num + this.a < this.c.e().w())
					{
						this.h = (num + this.a) * this.c.e().g() / this.c.e().t() - this.c.e().w() * this.c.e().g() / this.c.e().t();
					}
					else if (A_0.c() == 0f && num + this.a > this.c.e().w())
					{
						this.h = 0f;
					}
				}
				else
				{
					this.j = this.a;
					if (this.a < this.c.e().w())
					{
						this.h -= this.c.e().w() * this.c.e().g() / this.c.e().t();
					}
					else
					{
						this.h = 0f;
					}
				}
			}
			if (A_0 != null && (float)((int)A_0.g) == (float)((int)this.c.PlotArea.Y) + this.c.PlotArea.Height)
			{
				this.g = this.c.PlotArea.Y + this.c.PlotArea.Height;
				this.h = 0f;
			}
			else if (this.g > this.c.PlotArea.Y + this.c.PlotArea.Height)
			{
				float num2 = this.g - (this.c.PlotArea.Y + this.c.PlotArea.Height);
				this.g -= num2;
				if (this.h != 0f)
				{
					this.h += num2;
				}
			}
		}

		// Token: 0x0400308F RID: 12431
		private float a;

		// Token: 0x04003090 RID: 12432
		private Color b;

		// Token: 0x04003091 RID: 12433
		private StackedColumnSeriesElement c;

		// Token: 0x04003092 RID: 12434
		private BarColumnValuePositionDataLabel d;

		// Token: 0x04003093 RID: 12435
		private int e;

		// Token: 0x04003094 RID: 12436
		private float f = 0f;

		// Token: 0x04003095 RID: 12437
		private float g = 0f;

		// Token: 0x04003096 RID: 12438
		private float h = 0f;

		// Token: 0x04003097 RID: 12439
		private float i = 0f;

		// Token: 0x04003098 RID: 12440
		private float j;

		// Token: 0x04003099 RID: 12441
		private float k = 0f;
	}
}
