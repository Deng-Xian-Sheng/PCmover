using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008CE RID: 2254
	public class ColumnValue
	{
		// Token: 0x06005CB0 RID: 23728 RVA: 0x00347FB5 File Offset: 0x00346FB5
		internal ColumnValue(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06005CB1 RID: 23729 RVA: 0x00347FF4 File Offset: 0x00346FF4
		public float Value
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06005CB2 RID: 23730 RVA: 0x0034800C File Offset: 0x0034700C
		// (set) Token: 0x06005CB3 RID: 23731 RVA: 0x00348024 File Offset: 0x00347024
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

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06005CB4 RID: 23732 RVA: 0x00348030 File Offset: 0x00347030
		// (set) Token: 0x06005CB5 RID: 23733 RVA: 0x00348048 File Offset: 0x00347048
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

		// Token: 0x06005CB6 RID: 23734 RVA: 0x00348054 File Offset: 0x00347054
		internal ColumnSeries d()
		{
			return this.c;
		}

		// Token: 0x06005CB7 RID: 23735 RVA: 0x0034806C File Offset: 0x0034706C
		internal void a(ColumnSeries A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005CB8 RID: 23736 RVA: 0x00348078 File Offset: 0x00347078
		internal virtual int @is()
		{
			return this.e;
		}

		// Token: 0x06005CB9 RID: 23737 RVA: 0x00348090 File Offset: 0x00347090
		internal virtual void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005CBA RID: 23738 RVA: 0x0034809C File Offset: 0x0034709C
		internal float e()
		{
			return this.i;
		}

		// Token: 0x06005CBB RID: 23739 RVA: 0x003480B4 File Offset: 0x003470B4
		internal void a(PageWriter A_0, int A_1, int A_2, int A_3)
		{
			this.c();
			this.a(A_1, A_3);
			this.h /= (float)A_3;
			this.f += (float)A_2 * this.h;
			float a_ = this.g;
			this.g -= this.i;
			if (this.c.n().v() < 0f && this.c.n().w() < 0f && this.c.PlotArea.ClipToPlotArea)
			{
				this.a();
			}
			if (this.c.PlotArea.ClipToPlotArea)
			{
				this.a(a_);
			}
			if (this.i != 0f)
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

		// Token: 0x06005CBC RID: 23740 RVA: 0x003481EC File Offset: 0x003471EC
		internal void a(PageWriter A_0)
		{
			if (this.a >= 0f)
			{
				A_0.Write_re(this.f + this.c.BorderWidth / 2f, this.g + this.c.BorderWidth / 2f, this.h - this.c.BorderWidth, this.i - this.c.BorderWidth);
			}
			else
			{
				A_0.Write_re(this.f + this.c.BorderWidth / 2f, this.g - this.c.BorderWidth / 2f, this.h - this.c.BorderWidth, this.i + this.c.BorderWidth);
			}
			A_0.Write_S();
		}

		// Token: 0x06005CBD RID: 23741 RVA: 0x003482CC File Offset: 0x003472CC
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
					stringBuilder.Append(" " + this.c.m().r().b(A_1));
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
				float a_ = this.f + this.h / 2f;
				float a_2 = this.g;
				switch (this.d.Location)
				{
				case DataLabelLocation.Middle:
					a_ = this.f + this.h / 2f;
					a_2 = this.g + this.i / 2f;
					break;
				case DataLabelLocation.Base:
					a_ = this.f + this.h / 2f;
					a_2 = this.g + this.i;
					break;
				}
				bool a_3 = false;
				if (this.i < 0f)
				{
					a_3 = true;
				}
				this.d.a(A_0, a_, a_2, stringBuilder.ToString(), false, false, a_3, this.d.Location);
			}
		}

		// Token: 0x06005CBE RID: 23742 RVA: 0x0034852C File Offset: 0x0034752C
		private void c()
		{
			this.i = this.a;
			if (this.c.n().v() > 0f && this.c.PlotArea.ClipToPlotArea)
			{
				if (this.a > this.c.n().v())
				{
					this.i -= this.c.n().v();
				}
				else
				{
					this.i = 0f;
				}
			}
			this.i = this.i * this.c.n().g() / this.c.n().t();
		}

		// Token: 0x06005CBF RID: 23743 RVA: 0x003485F4 File Offset: 0x003475F4
		private void a(int A_0, int A_1)
		{
			this.h = this.c.m().g();
			float num = this.h / ((float)A_1 + 1.5f);
			float a_;
			if (A_0 == 0)
			{
				a_ = num * 0.75f;
			}
			else
			{
				a_ = (float)A_0 * num * 1.5f + num * 0.75f;
			}
			this.h -= num * 1.5f;
			this.a(A_0, a_);
		}

		// Token: 0x06005CC0 RID: 23744 RVA: 0x0034867C File Offset: 0x0034767C
		private void a(int A_0, float A_1)
		{
			this.f = this.c.PlotArea.X + this.h * (float)A_0 + A_1 + this.b();
			this.g = this.c.PlotArea.Y + this.c.PlotArea.Height;
			if (this.c.n().v() > 0f && !this.c.PlotArea.ClipToPlotArea)
			{
				this.g += this.c.n().g() * this.c.n().v() / this.c.n().t();
			}
			else
			{
				this.g -= this.c.n().g() * this.c.n().h();
			}
		}

		// Token: 0x06005CC1 RID: 23745 RVA: 0x0034877C File Offset: 0x0034777C
		private float b()
		{
			return this.c.m().s() * this.c.m().g() - this.c.m().g() / 2f;
		}

		// Token: 0x06005CC2 RID: 23746 RVA: 0x003487C8 File Offset: 0x003477C8
		private void a(float A_0)
		{
			if (this.a >= 0f)
			{
				if (this.g < this.c.PlotArea.Y)
				{
					float num = this.c.PlotArea.Y - this.g;
					this.g += num;
					this.i -= num;
					if (this.i < 0f)
					{
						this.i = 0f;
					}
					float num2 = this.g;
					if ((int)num2 == (int)A_0)
					{
						this.i = 0f;
					}
				}
			}
			else if (this.a < 0f)
			{
				if (this.g > this.c.PlotArea.Y + this.c.PlotArea.Height)
				{
					float num = this.g - (this.c.PlotArea.Y + this.c.PlotArea.Height);
					this.g -= num;
					this.i += num;
					float num2 = this.g;
					if ((int)num2 == (int)A_0)
					{
						this.i = 0f;
					}
				}
			}
		}

		// Token: 0x06005CC3 RID: 23747 RVA: 0x00348940 File Offset: 0x00347940
		private void a()
		{
			if (this.a < this.c.n().w())
			{
				this.i -= this.c.n().w() * this.c.n().g() / this.c.n().t();
			}
			else
			{
				this.i = 0f;
			}
		}

		// Token: 0x0400301B RID: 12315
		private float a;

		// Token: 0x0400301C RID: 12316
		private Color b;

		// Token: 0x0400301D RID: 12317
		private ColumnSeries c;

		// Token: 0x0400301E RID: 12318
		private BarColumnValuePositionDataLabel d;

		// Token: 0x0400301F RID: 12319
		private int e;

		// Token: 0x04003020 RID: 12320
		private float f = 0f;

		// Token: 0x04003021 RID: 12321
		private float g = 0f;

		// Token: 0x04003022 RID: 12322
		private float h = 0f;

		// Token: 0x04003023 RID: 12323
		private float i = 0f;
	}
}
