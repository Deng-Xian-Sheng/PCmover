using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C7 RID: 2247
	public class SeriesList
	{
		// Token: 0x06005C35 RID: 23605 RVA: 0x00344810 File Offset: 0x00343810
		internal SeriesList(PlotArea A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x06005C36 RID: 23606 RVA: 0x003448A4 File Offset: 0x003438A4
		public void Add(SeriesBase series)
		{
			if (!this.a.Contains(series))
			{
				this.a.Add(series);
				series.a(this.b);
				this.a(series);
				this.b(series);
				this.a(series);
				if (series is XYSeries)
				{
					this.a((XYSeries)series);
				}
				if (series is PieSeries)
				{
					((PieSeries)series).Elements.b();
				}
				return;
			}
			throw new GeneratorException("Same Series can't be added more than once.");
		}

		// Token: 0x06005C37 RID: 23607 RVA: 0x00344944 File Offset: 0x00343944
		public void Add(StackedSeries stackedSeries)
		{
			if (!this.a.Contains(stackedSeries))
			{
				this.a.Add(stackedSeries);
				stackedSeries.a(this.b);
				this.a(stackedSeries);
				this.a(stackedSeries);
				this.a(stackedSeries);
				stackedSeries.j();
				return;
			}
			throw new GeneratorException("Same StackedSeries can't be added more than once.");
		}

		// Token: 0x1700098D RID: 2445
		public SeriesBase this[int index]
		{
			get
			{
				return (SeriesBase)this.a[index];
			}
		}

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x06005C39 RID: 23609 RVA: 0x003449D0 File Offset: 0x003439D0
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x06005C3A RID: 23610 RVA: 0x003449F0 File Offset: 0x003439F0
		internal void a(PlotAreaElement A_0)
		{
			if (A_0 is SeriesBase)
			{
				if (A_0.Legend == null)
				{
					if (A_0.PlotArea.Chart.Legends.Count > 0)
					{
						Legend legend = A_0.PlotArea.Chart.Legends[0];
						A_0.Legend = legend;
					}
					else
					{
						A_0.Legend = A_0.PlotArea.Chart.Legends.Add();
					}
				}
			}
			if (!(A_0 is StackedSeries) && !(A_0 is PieSeries))
			{
				Legend legend = A_0.Legend;
				LegendLabel legendLabel = null;
				if (A_0 is LegendXYSeries)
				{
					legendLabel = new LegendLabel(((LegendXYSeries)A_0).Name, legend.Font, legend.FontSize, legend.TextColor, legend.Align);
					((LegendXYSeries)A_0).a(legendLabel);
				}
				else if (A_0 is SeriesElement)
				{
					legendLabel = new LegendLabel(((SeriesElement)A_0).Name, legend.Font, legend.FontSize, legend.TextColor, legend.Align);
					((SeriesElement)A_0).a(legendLabel);
				}
				legendLabel.a(A_0);
				legend.LegendLabelList.a(legendLabel);
			}
		}

		// Token: 0x06005C3B RID: 23611 RVA: 0x00344B4C File Offset: 0x00343B4C
		internal void b(PlotAreaElement A_0)
		{
			if (A_0 is LegendXYSeries)
			{
				if (((LegendXYSeries)A_0).Color == null)
				{
					((LegendXYSeries)A_0).Color = this.n();
				}
				if (A_0 is XYScatterSeries)
				{
					XYScatterSeries xyscatterSeries = (XYScatterSeries)A_0;
					if (xyscatterSeries.Marker == null)
					{
						xyscatterSeries.Marker = this.m();
					}
				}
			}
			else if (A_0 is SeriesElement && !(A_0 is PieSeriesElement))
			{
				if (((SeriesElement)A_0).Color == null)
				{
					((SeriesElement)A_0).Color = this.n();
				}
			}
			else if (A_0 is PieSeries)
			{
				if (((PieSeries)A_0).BorderWidth > 0f && ((PieSeries)A_0).BorderColor == null)
				{
					((PieSeries)A_0).BorderColor = RgbColor.Black;
				}
			}
		}

		// Token: 0x06005C3C RID: 23612 RVA: 0x00344C60 File Offset: 0x00343C60
		internal void a(SeriesBase A_0)
		{
			if (A_0 is IndexedColumnSeries)
			{
				((IndexedColumnSeries)A_0).a(this.d++);
			}
			else if (A_0 is DateTimeColumnSeries)
			{
				((DateTimeColumnSeries)A_0).a(this.e++);
			}
			else if (A_0 is IndexedBarSeries)
			{
				((IndexedBarSeries)A_0).a(this.f++);
			}
			else if (A_0 is DateTimeBarSeries)
			{
				((DateTimeBarSeries)A_0).a(this.g++);
			}
			else if (A_0 is IndexedStackedColumnSeries)
			{
				((IndexedStackedColumnSeries)A_0).a(this.h++);
			}
			else if (A_0 is DateTimeStackedColumnSeries)
			{
				((DateTimeStackedColumnSeries)A_0).a(this.i++);
			}
			else if (A_0 is IndexedStackedBarSeries)
			{
				((IndexedStackedBarSeries)A_0).a(this.k++);
			}
			else if (A_0 is DateTimeStackedBarSeries)
			{
				((DateTimeStackedBarSeries)A_0).a(this.l++);
			}
			else if (A_0 is Indexed100PercentStackedColumnSeries)
			{
				((Indexed100PercentStackedColumnSeries)A_0).a(this.h++);
			}
			else if (A_0 is DateTime100PercentStackedColumnSeries)
			{
				((DateTime100PercentStackedColumnSeries)A_0).a(this.i++);
			}
			else if (A_0 is Indexed100PercentStackedBarSeries)
			{
				((Indexed100PercentStackedBarSeries)A_0).a(this.k++);
			}
			else if (A_0 is DateTime100PercentStackedBarSeries)
			{
				((DateTime100PercentStackedBarSeries)A_0).a(this.l++);
			}
			else if (A_0 is PieSeries)
			{
				PieSeries pieSeries = (PieSeries)A_0;
				float num;
				this.m = (num = this.m) + 1f;
				pieSeries.a((int)num);
			}
		}

		// Token: 0x06005C3D RID: 23613 RVA: 0x00344F0C File Offset: 0x00343F0C
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005C3E RID: 23614 RVA: 0x00344F18 File Offset: 0x00343F18
		internal float a()
		{
			return this.m;
		}

		// Token: 0x06005C3F RID: 23615 RVA: 0x00344F30 File Offset: 0x00343F30
		internal int b()
		{
			return this.d;
		}

		// Token: 0x06005C40 RID: 23616 RVA: 0x00344F48 File Offset: 0x00343F48
		internal int c()
		{
			return this.e;
		}

		// Token: 0x06005C41 RID: 23617 RVA: 0x00344F60 File Offset: 0x00343F60
		internal int d()
		{
			return this.f;
		}

		// Token: 0x06005C42 RID: 23618 RVA: 0x00344F78 File Offset: 0x00343F78
		internal int e()
		{
			return this.g;
		}

		// Token: 0x06005C43 RID: 23619 RVA: 0x00344F90 File Offset: 0x00343F90
		internal int f()
		{
			return this.h;
		}

		// Token: 0x06005C44 RID: 23620 RVA: 0x00344FA8 File Offset: 0x00343FA8
		internal int g()
		{
			return this.i;
		}

		// Token: 0x06005C45 RID: 23621 RVA: 0x00344FC0 File Offset: 0x00343FC0
		internal int h()
		{
			return this.k;
		}

		// Token: 0x06005C46 RID: 23622 RVA: 0x00344FD8 File Offset: 0x00343FD8
		internal int i()
		{
			return this.l;
		}

		// Token: 0x06005C47 RID: 23623 RVA: 0x00344FF0 File Offset: 0x00343FF0
		internal void a(PageWriter A_0)
		{
			if (this.m > 0f)
			{
				this.j();
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				SeriesBase seriesBase = (SeriesBase)this.a[i];
				if (seriesBase.DrawBehindAxis)
				{
					seriesBase.ic(A_0);
				}
			}
			this.b.YAxes.b(A_0);
			this.b.XAxes.b(A_0);
			for (int i = 0; i < this.a.Count; i++)
			{
				SeriesBase seriesBase = (SeriesBase)this.a[i];
				if (!seriesBase.DrawBehindAxis)
				{
					seriesBase.ic(A_0);
				}
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				SeriesBase seriesBase = (SeriesBase)this.a[i];
				seriesBase.ib(A_0);
			}
		}

		// Token: 0x06005C48 RID: 23624 RVA: 0x003450F8 File Offset: 0x003440F8
		internal void j()
		{
			float num = float.MaxValue;
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((SeriesBase)this.a[i]) is PieSeries)
				{
					PieSeries pieSeries = (PieSeries)this.a[i];
					pieSeries.c();
					if (!pieSeries.b() && pieSeries.Radius > 0f && num > pieSeries.Radius)
					{
						num = pieSeries.Radius;
					}
				}
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((SeriesBase)this.a[i]) is PieSeries)
				{
					PieSeries pieSeries = (PieSeries)this.a[i];
					if (!pieSeries.b())
					{
						pieSeries.b(num);
					}
				}
			}
		}

		// Token: 0x06005C49 RID: 23625 RVA: 0x003451FC File Offset: 0x003441FC
		internal void k()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				SeriesBase seriesBase = (SeriesBase)this.a[i];
				if (seriesBase is XYSeries)
				{
					XYSeries xyseries = (XYSeries)seriesBase;
					XAxis xaxis = xyseries.m();
					YAxis yaxis = xyseries.n();
					xaxis.iv(xyseries);
					yaxis.iv(xyseries);
				}
			}
		}

		// Token: 0x06005C4A RID: 23626 RVA: 0x00345278 File Offset: 0x00344278
		internal void a(XYSeries A_0)
		{
			if (A_0.m() != null)
			{
				this.b.XAxes.Add(A_0.m());
			}
			else if (A_0 is BarSeries || A_0 is XYScatterSeries)
			{
				A_0.a(this.b.XAxes.h());
			}
			else if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).g();
			}
			else if (this.b(A_0))
			{
				A_0.a(this.b.XAxes.k());
			}
			else
			{
				A_0.a(this.b.XAxes.i());
			}
			if (A_0.n() != null)
			{
				this.b.YAxes.Add(A_0.n());
			}
			else if (A_0 is BarSeries)
			{
				if (this.b(A_0))
				{
					A_0.a(this.b.YAxes.l());
				}
				else
				{
					A_0.a(this.b.YAxes.k());
				}
			}
			else if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).h();
			}
			else
			{
				A_0.a(this.b.YAxes.j());
			}
			if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).i();
			}
			A_0.m().k();
			if (A_0.m() is NumericXAxis || A_0.m() is PercentageXAxis)
			{
				A_0.m().l();
			}
			A_0.n().k();
			if (A_0.n() is NumericYAxis || A_0.n() is PercentageYAxis)
			{
				A_0.n().l();
			}
			if (A_0 is ColumnSeries || A_0 is StackedColumnSeries || A_0 is Stacked100PercentColumnSeries)
			{
				A_0.m().x();
			}
			if (A_0 is BarSeries || A_0 is StackedBarSeries || A_0 is Stacked100PercentBarSeries)
			{
				A_0.n().x();
			}
		}

		// Token: 0x06005C4B RID: 23627 RVA: 0x003454FC File Offset: 0x003444FC
		internal bool b(XYSeries A_0)
		{
			bool result = false;
			if (A_0 is DateTimeColumnSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeBarSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeLineSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeAreaSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeStackedColumnSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeStackedBarSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeStackedAreaSeries)
			{
				result = true;
			}
			else if (A_0 is DateTimeStackedLineSeries)
			{
				result = true;
			}
			else if (A_0 is DateTime100PercentStackedAreaSeries)
			{
				result = true;
			}
			else if (A_0 is DateTime100PercentStackedLineSeries)
			{
				result = true;
			}
			else if (A_0 is DateTime100PercentStackedBarSeries)
			{
				result = true;
			}
			else if (A_0 is DateTime100PercentStackedColumnSeries)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06005C4C RID: 23628 RVA: 0x00345610 File Offset: 0x00344610
		internal void l()
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((SeriesBase)this.a[i]) is PieSeries)
				{
					if (((PieSeries)this.a[i]).Elements.Count > 0)
					{
						((PieSeries)this.a[i]).Elements.c();
					}
				}
			}
		}

		// Token: 0x06005C4D RID: 23629 RVA: 0x003456A0 File Offset: 0x003446A0
		internal Marker m()
		{
			Marker result = null;
			if (this.j == 0)
			{
				result = Marker.GetCircle(4f);
			}
			else if (this.j == 1)
			{
				result = Marker.GetDiamond(4f);
			}
			else if (this.j == 2)
			{
				result = Marker.GetSquare(4f);
			}
			else if (this.j == 3)
			{
				result = Marker.GetTriangle(4f);
			}
			else if (this.j == 4)
			{
				result = Marker.GetAsterisk(4f);
			}
			else if (this.j == 5)
			{
				result = Marker.GetCross(4f);
			}
			else if (this.j == 6)
			{
				result = Marker.GetPlus(4f);
			}
			else if (this.j == 7)
			{
				result = Marker.GetDash(4f);
			}
			if (this.j++ == 8)
			{
				this.j = 0;
			}
			return result;
		}

		// Token: 0x06005C4E RID: 23630 RVA: 0x003457C8 File Offset: 0x003447C8
		internal Color n()
		{
			byte b = byte.MaxValue;
			byte b2 = byte.MaxValue;
			byte b3 = byte.MaxValue;
			float num = 0f;
			if (this.c < 8)
			{
				num = 0.8f;
			}
			else if (this.c > 7 && this.c < 16)
			{
				num = 0.4f;
			}
			else if (this.c > 15 && this.c < 24)
			{
				num = 1f;
			}
			else if (this.c > 23 && this.c < 32)
			{
				num = 0.6f;
			}
			else if (this.c > 31 && this.c < 40)
			{
				num = 0.2f;
			}
			b = (byte)((float)b * (1f - num));
			b2 = (byte)((float)b2 * (1f - num));
			b3 = (byte)((float)b3 * (1f - num));
			int num2 = this.c % 8;
			byte b4 = (byte)((float)this.n[num2, 0] * num);
			byte b5 = (byte)((float)this.n[num2, 1] * num);
			byte b6 = (byte)((float)this.n[num2, 2] * num);
			this.c++;
			if (this.c == 40)
			{
				this.c = 0;
			}
			return new RgbColor(b4 + b, b5 + b2, b6 + b3);
		}

		// Token: 0x04002FE6 RID: 12262
		private ArrayList a;

		// Token: 0x04002FE7 RID: 12263
		private PlotArea b;

		// Token: 0x04002FE8 RID: 12264
		private int c = 0;

		// Token: 0x04002FE9 RID: 12265
		private int d = 0;

		// Token: 0x04002FEA RID: 12266
		private int e = 0;

		// Token: 0x04002FEB RID: 12267
		private int f = 0;

		// Token: 0x04002FEC RID: 12268
		private int g = 0;

		// Token: 0x04002FED RID: 12269
		private int h = 0;

		// Token: 0x04002FEE RID: 12270
		private int i = 0;

		// Token: 0x04002FEF RID: 12271
		private int j = 0;

		// Token: 0x04002FF0 RID: 12272
		private int k = 0;

		// Token: 0x04002FF1 RID: 12273
		private int l = 0;

		// Token: 0x04002FF2 RID: 12274
		private float m = 0f;

		// Token: 0x04002FF3 RID: 12275
		private byte[,] n = new byte[,]
		{
			{
				0,
				128,
				128
			},
			{
				128,
				0,
				128
			},
			{
				218,
				165,
				32
			},
			{
				byte.MaxValue,
				69,
				0
			},
			{
				0,
				100,
				0
			},
			{
				byte.MaxValue,
				20,
				147
			},
			{
				25,
				20,
				245
			},
			{
				200,
				0,
				0
			}
		};
	}
}
