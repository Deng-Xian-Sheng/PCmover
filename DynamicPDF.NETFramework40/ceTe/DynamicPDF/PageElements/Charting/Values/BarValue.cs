using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008CC RID: 2252
	public class BarValue
	{
		// Token: 0x06005C90 RID: 23696 RVA: 0x00346EA3 File Offset: 0x00345EA3
		internal BarValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x06005C91 RID: 23697 RVA: 0x00346EE4 File Offset: 0x00345EE4
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x06005C92 RID: 23698 RVA: 0x00346EFC File Offset: 0x00345EFC
		// (set) Token: 0x06005C93 RID: 23699 RVA: 0x00346F14 File Offset: 0x00345F14
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

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x06005C94 RID: 23700 RVA: 0x00346F20 File Offset: 0x00345F20
		// (set) Token: 0x06005C95 RID: 23701 RVA: 0x00346F38 File Offset: 0x00345F38
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

		// Token: 0x06005C96 RID: 23702 RVA: 0x00346F44 File Offset: 0x00345F44
		internal BarSeries d()
		{
			return this.c;
		}

		// Token: 0x06005C97 RID: 23703 RVA: 0x00346F5C File Offset: 0x00345F5C
		internal void a(BarSeries A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005C98 RID: 23704 RVA: 0x00346F68 File Offset: 0x00345F68
		internal float e()
		{
			return this.h;
		}

		// Token: 0x06005C99 RID: 23705 RVA: 0x00346F80 File Offset: 0x00345F80
		internal virtual int ir()
		{
			return this.e;
		}

		// Token: 0x06005C9A RID: 23706 RVA: 0x00346F98 File Offset: 0x00345F98
		internal virtual void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005C9B RID: 23707 RVA: 0x00346FA4 File Offset: 0x00345FA4
		internal void a(PageWriter A_0, int A_1, int A_2, int A_3)
		{
			this.c();
			this.a(A_1, A_3);
			this.i /= (float)A_3;
			this.g -= this.i + (float)A_2 * this.i;
			if (this.c.m().v() < 0f && this.c.m().w() < 0f && this.c.PlotArea.ClipToPlotArea)
			{
				this.a();
			}
			if (this.c.PlotArea.ClipToPlotArea)
			{
				this.a(0f);
			}
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
		}

		// Token: 0x06005C9C RID: 23708 RVA: 0x003470CC File Offset: 0x003460CC
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
					stringBuilder.Append(" " + this.c.n().r().b(A_1));
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
				float num = this.f + this.h;
				float a_ = this.g + this.i / 2f;
				switch (this.d.Location)
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
				this.d.a(A_0, num, a_, stringBuilder.ToString(), true, false, a_2, this.d.Location);
			}
		}

		// Token: 0x06005C9D RID: 23709 RVA: 0x00347300 File Offset: 0x00346300
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

		// Token: 0x06005C9E RID: 23710 RVA: 0x003473E0 File Offset: 0x003463E0
		private void c()
		{
			this.h = this.a;
			if (this.c.m().v() > 0f && this.c.PlotArea.ClipToPlotArea)
			{
				if (this.a > this.c.m().v())
				{
					this.h -= this.c.m().v();
				}
				else
				{
					this.h = 0f;
				}
			}
			this.h = this.h * this.c.m().g() / this.c.m().t();
		}

		// Token: 0x06005C9F RID: 23711 RVA: 0x003474A8 File Offset: 0x003464A8
		private void a(int A_0, int A_1)
		{
			this.i = this.c.n().g();
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

		// Token: 0x06005CA0 RID: 23712 RVA: 0x00347530 File Offset: 0x00346530
		private void a(int A_0, float A_1)
		{
			this.f = this.c.PlotArea.X;
			if (this.c.m().v() > 0f && !this.c.PlotArea.ClipToPlotArea)
			{
				this.f -= this.c.m().g() * this.c.m().v() / this.c.m().t();
			}
			else
			{
				this.f += this.c.m().g() * this.c.m().h();
			}
			this.g = this.c.PlotArea.Y + this.c.PlotArea.Height - (this.i * (float)A_0 + A_1 + this.b());
		}

		// Token: 0x06005CA1 RID: 23713 RVA: 0x00347630 File Offset: 0x00346630
		private float b()
		{
			return this.c.n().s() * this.c.n().g() - this.c.n().g() / 2f;
		}

		// Token: 0x06005CA2 RID: 23714 RVA: 0x0034767C File Offset: 0x0034667C
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

		// Token: 0x06005CA3 RID: 23715 RVA: 0x003477D8 File Offset: 0x003467D8
		private void a()
		{
			if (this.a < this.c.m().w())
			{
				this.h -= this.c.m().w() * this.c.m().g() / this.c.m().t();
				this.f += this.c.m().w() * this.c.m().g() / this.c.m().t();
			}
			else
			{
				this.h = 0f;
			}
		}

		// Token: 0x0400300F RID: 12303
		private float a;

		// Token: 0x04003010 RID: 12304
		private Color b;

		// Token: 0x04003011 RID: 12305
		private BarSeries c;

		// Token: 0x04003012 RID: 12306
		private BarColumnValuePositionDataLabel d;

		// Token: 0x04003013 RID: 12307
		private int e;

		// Token: 0x04003014 RID: 12308
		private float f = 0f;

		// Token: 0x04003015 RID: 12309
		private float g = 0f;

		// Token: 0x04003016 RID: 12310
		private float h = 0f;

		// Token: 0x04003017 RID: 12311
		private float i = 0f;
	}
}
