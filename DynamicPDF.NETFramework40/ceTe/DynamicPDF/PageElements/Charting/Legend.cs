using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A6 RID: 1958
	public class Legend
	{
		// Token: 0x06004F07 RID: 20231 RVA: 0x00279680 File Offset: 0x00278680
		internal Legend(Chart A_0)
		{
			this.e = A_0.Font;
			this.f = A_0.FontSize;
			this.j = A_0.TextColor;
			this.s = new LegendLabelList();
		}

		// Token: 0x06004F08 RID: 20232 RVA: 0x00279780 File Offset: 0x00278780
		internal Legend(float A_0, float A_1, float A_2, float A_3, Chart A_4)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			this.s = new LegendLabelList();
			this.e = A_4.Font;
			this.f = A_4.FontSize;
			this.j = A_4.TextColor;
		}

		// Token: 0x06004F09 RID: 20233 RVA: 0x0027989E File Offset: 0x0027889E
		internal void a(LayOut A_0)
		{
			this.u = A_0;
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06004F0A RID: 20234 RVA: 0x002798A8 File Offset: 0x002788A8
		// (set) Token: 0x06004F0B RID: 20235 RVA: 0x002798C0 File Offset: 0x002788C0
		public Font Font
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
				if (this.s != null)
				{
					for (int i = 0; i < this.s.Count; i++)
					{
						this.s[i].Font = value;
					}
				}
			}
		}

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06004F0C RID: 20236 RVA: 0x00279914 File Offset: 0x00278914
		// (set) Token: 0x06004F0D RID: 20237 RVA: 0x0027992C File Offset: 0x0027892C
		public TextAlign Align
		{
			get
			{
				return this.t;
			}
			set
			{
				this.t = value;
			}
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06004F0E RID: 20238 RVA: 0x00279938 File Offset: 0x00278938
		// (set) Token: 0x06004F0F RID: 20239 RVA: 0x00279950 File Offset: 0x00278950
		public float FontSize
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
				if (this.s != null)
				{
					for (int i = 0; i < this.s.Count; i++)
					{
						this.s[i].FontSize = value;
					}
				}
			}
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06004F10 RID: 20240 RVA: 0x002799A4 File Offset: 0x002789A4
		// (set) Token: 0x06004F11 RID: 20241 RVA: 0x002799BC File Offset: 0x002789BC
		public Color TextColor
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
				if (this.s != null)
				{
					for (int i = 0; i < this.s.Count; i++)
					{
						this.s[i].TextColor = value;
					}
				}
			}
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06004F12 RID: 20242 RVA: 0x00279A10 File Offset: 0x00278A10
		// (set) Token: 0x06004F13 RID: 20243 RVA: 0x00279A28 File Offset: 0x00278A28
		public Color BorderColor
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06004F14 RID: 20244 RVA: 0x00279A34 File Offset: 0x00278A34
		// (set) Token: 0x06004F15 RID: 20245 RVA: 0x00279A4C File Offset: 0x00278A4C
		public Color BackgroundColor
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06004F16 RID: 20246 RVA: 0x00279A58 File Offset: 0x00278A58
		public LegendLabelList LegendLabelList
		{
			get
			{
				return this.s;
			}
		}

		// Token: 0x06004F17 RID: 20247 RVA: 0x00279A70 File Offset: 0x00278A70
		internal int b()
		{
			int num = 0;
			if (this.s != null)
			{
				for (int i = 0; i < this.s.Count; i++)
				{
					LegendLabel legendLabel = this.s[i];
					if (legendLabel.Visible)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06004F18 RID: 20248 RVA: 0x00279AD4 File Offset: 0x00278AD4
		internal void a(float A_0)
		{
			this.c = A_0;
			if (this.s.Count > 0)
			{
				switch (this.u)
				{
				case LayOut.Horizontal:
					for (int i = 0; i < this.s.Count; i++)
					{
						LegendLabel legendLabel = this.s[i];
						PlotAreaElement a_ = legendLabel.a();
						float symbolWidth = this.a(a_, legendLabel.FontSize);
						legendLabel.SymbolWidth = symbolWidth;
						legendLabel.a(legendLabel.RequiredWidth);
					}
					break;
				case LayOut.Vertical:
					for (int i = 0; i < this.s.Count; i++)
					{
						LegendLabel legendLabel = this.s[i];
						PlotAreaElement a_ = legendLabel.a();
						float symbolWidth = this.a(a_, legendLabel.FontSize);
						legendLabel.a(legendLabel.RequiredWidth);
						legendLabel.SymbolWidth = symbolWidth;
					}
					break;
				}
			}
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06004F19 RID: 20249 RVA: 0x00279BD0 File Offset: 0x00278BD0
		public float RequiredWidth
		{
			get
			{
				float num = 0f;
				if (this.s.Count > 0)
				{
					switch (this.u)
					{
					case LayOut.Horizontal:
						for (int i = 0; i < this.s.Count; i++)
						{
							LegendLabel legendLabel = this.s[i];
							PlotAreaElement a_ = legendLabel.a();
							float num2 = this.a(a_, legendLabel.FontSize);
							float num3 = legendLabel.RequiredWidth + num2 + this.q;
							num += num3;
						}
						num += (float)(this.s.Count - 1) * this.LabelSpacing;
						break;
					case LayOut.Vertical:
						for (int i = 0; i < this.s.Count; i++)
						{
							LegendLabel legendLabel = this.s[i];
							PlotAreaElement a_ = legendLabel.a();
							float num2 = this.a(a_, legendLabel.FontSize);
							float num3 = legendLabel.RequiredWidth + num2 + this.l + this.m + this.q;
							if (num < num3)
							{
								num = num3;
							}
						}
						break;
					}
					num = num + this.l + this.m;
				}
				return num;
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06004F1A RID: 20250 RVA: 0x00279D1C File Offset: 0x00278D1C
		// (set) Token: 0x06004F1B RID: 20251 RVA: 0x00279D34 File Offset: 0x00278D34
		public float TopPadding
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06004F1C RID: 20252 RVA: 0x00279D40 File Offset: 0x00278D40
		// (set) Token: 0x06004F1D RID: 20253 RVA: 0x00279D58 File Offset: 0x00278D58
		public float BottomPadding
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06004F1E RID: 20254 RVA: 0x00279D64 File Offset: 0x00278D64
		// (set) Token: 0x06004F1F RID: 20255 RVA: 0x00279D7C File Offset: 0x00278D7C
		public float LeftPadding
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06004F20 RID: 20256 RVA: 0x00279D88 File Offset: 0x00278D88
		// (set) Token: 0x06004F21 RID: 20257 RVA: 0x00279DA0 File Offset: 0x00278DA0
		public float RightPadding
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06004F22 RID: 20258 RVA: 0x00279DAC File Offset: 0x00278DAC
		// (set) Token: 0x06004F23 RID: 20259 RVA: 0x00279DC4 File Offset: 0x00278DC4
		public float LabelSpacing
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06004F24 RID: 20260 RVA: 0x00279DD0 File Offset: 0x00278DD0
		// (set) Token: 0x06004F25 RID: 20261 RVA: 0x00279DE8 File Offset: 0x00278DE8
		public float SymbolSpacing
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06004F26 RID: 20262 RVA: 0x00279DF4 File Offset: 0x00278DF4
		// (set) Token: 0x06004F27 RID: 20263 RVA: 0x00279E0C File Offset: 0x00278E0C
		public bool Visible
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x06004F28 RID: 20264 RVA: 0x00279E18 File Offset: 0x00278E18
		// (set) Token: 0x06004F29 RID: 20265 RVA: 0x00279E30 File Offset: 0x00278E30
		public float X
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06004F2A RID: 20266 RVA: 0x00279E3C File Offset: 0x00278E3C
		// (set) Token: 0x06004F2B RID: 20267 RVA: 0x00279E54 File Offset: 0x00278E54
		public float Y
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

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06004F2C RID: 20268 RVA: 0x00279E60 File Offset: 0x00278E60
		// (set) Token: 0x06004F2D RID: 20269 RVA: 0x00279E78 File Offset: 0x00278E78
		public float BorderWidth
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06004F2E RID: 20270 RVA: 0x00279E84 File Offset: 0x00278E84
		// (set) Token: 0x06004F2F RID: 20271 RVA: 0x00279E9C File Offset: 0x00278E9C
		public LineStyle BorderStyle
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06004F30 RID: 20272 RVA: 0x00279EA8 File Offset: 0x00278EA8
		// (set) Token: 0x06004F31 RID: 20273 RVA: 0x00279EC0 File Offset: 0x00278EC0
		public float Width
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
				if (this.s != null)
				{
					int count = this.s.Count;
					float num = (this.c - this.l - this.m - (float)(count - 1) * this.p) / (float)count;
					float num2 = this.a();
					for (int i = 0; i < count; i++)
					{
						LegendLabel legendLabel = this.s[i];
						PlotAreaElement a_ = legendLabel.a();
						float num3 = this.a(a_, legendLabel.FontSize);
						if (legendLabel != null)
						{
							switch (this.u)
							{
							case LayOut.Horizontal:
								legendLabel.a(num - this.q - num3);
								break;
							case LayOut.Vertical:
								legendLabel.a(this.c - this.l - this.m - this.q - num2);
								break;
							}
						}
						legendLabel.SymbolWidth = num3;
					}
				}
			}
		}

		// Token: 0x06004F32 RID: 20274 RVA: 0x00279FD8 File Offset: 0x00278FD8
		private float a(PlotAreaElement A_0, float A_1)
		{
			float result;
			if (A_0 is LineSeries && ((LineSeries)A_0).Marker != null)
			{
				result = ((LineSeries)A_0).Marker.Size * 4f;
			}
			else if (A_0 is XYScatterSeries && ((XYScatterSeries)A_0).Marker != null)
			{
				result = ((XYScatterSeries)A_0).Marker.Size * 4f;
			}
			else if (A_0 is StackedLineSeriesElement && ((StackedLineSeriesElement)A_0).Marker != null)
			{
				result = ((StackedLineSeriesElement)A_0).Marker.Size * 4f;
			}
			else
			{
				result = A_1 / 10f * 6f;
			}
			return result;
		}

		// Token: 0x06004F33 RID: 20275 RVA: 0x0027A0A4 File Offset: 0x002790A4
		internal void b(float A_0)
		{
			this.d = A_0;
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06004F34 RID: 20276 RVA: 0x0027A0B0 File Offset: 0x002790B0
		// (set) Token: 0x06004F35 RID: 20277 RVA: 0x0027A0C8 File Offset: 0x002790C8
		public float Height
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
				float a_ = (value - this.n - this.o - this.p * (float)(this.b() - 1)) / (float)this.b();
				for (int i = 0; i < this.s.Count; i++)
				{
					LegendLabel legendLabel = this.s[i];
					if (legendLabel != null && legendLabel.Visible)
					{
						switch (this.u)
						{
						case LayOut.Horizontal:
							legendLabel.b(value - this.n - this.o);
							break;
						case LayOut.Vertical:
							legendLabel.b(a_);
							break;
						}
					}
				}
			}
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06004F36 RID: 20278 RVA: 0x0027A180 File Offset: 0x00279180
		public float RequiredHeight
		{
			get
			{
				float num = 0f;
				switch (this.u)
				{
				case LayOut.Horizontal:
				{
					float num2 = 0f;
					for (int i = 0; i < this.s.Count; i++)
					{
						LegendLabel legendLabel = this.s[i];
						if (legendLabel.Visible)
						{
							float num3 = legendLabel.c();
							if (num2 <= num3)
							{
								num2 = num3;
							}
						}
					}
					if (num2 > 0f)
					{
						num = num2 + this.n + this.o;
					}
					break;
				}
				case LayOut.Vertical:
					for (int i = 0; i < this.s.Count; i++)
					{
						LegendLabel legendLabel = this.s[i];
						if (legendLabel.Visible)
						{
							num = num + legendLabel.c() + this.p;
						}
					}
					if (num > 0f)
					{
						num -= this.p;
						num = num + this.n + this.o;
					}
					break;
				}
				return num;
			}
		}

		// Token: 0x06004F37 RID: 20279 RVA: 0x0027A2AC File Offset: 0x002792AC
		private float a()
		{
			float num = 0f;
			for (int i = 0; i < this.s.Count; i++)
			{
				LegendLabel legendLabel = this.s[i];
				if (legendLabel.Visible)
				{
					this.f = legendLabel.FontSize;
					float num2 = this.a(legendLabel.a(), this.f);
					legendLabel.SymbolWidth = num2;
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06004F38 RID: 20280 RVA: 0x0027A340 File Offset: 0x00279340
		internal void a(PageWriter A_0)
		{
			if (this.Visible)
			{
				A_0.SetGraphicsMode();
				if (this.g != null)
				{
					A_0.SetFillColor(this.g);
					A_0.Write_re(this.a, this.b, this.c, this.d);
					A_0.Write_f();
				}
				if (this.h != null)
				{
					A_0.SetLineStyle(this.i);
					A_0.SetLineWidth(this.k);
					A_0.SetStrokeColor(this.h);
					if (this.i != LineStyle.None)
					{
						A_0.Write_re(this.a, this.b, this.c, this.d);
						A_0.Write_S();
					}
				}
				float num = this.a();
				float num2 = this.a;
				for (int i = 0; i < this.s.Count; i++)
				{
					LegendLabel legendLabel = this.s[i];
					if (legendLabel.Visible)
					{
						Font font = legendLabel.Font;
						float fontSize = legendLabel.FontSize;
						float symbolWidth = legendLabel.SymbolWidth;
						float num3 = 0f;
						if (symbolWidth < num)
						{
							num3 = num - symbolWidth;
						}
						float num4 = font.GetBaseLine(fontSize, font.GetDefaultLeading(fontSize));
						float num5;
						if (num4 < symbolWidth)
						{
							num4 = symbolWidth - num4;
							num5 = this.b - num4;
						}
						else
						{
							num4 -= symbolWidth;
							num5 = this.b + num4;
						}
						num4 = font.GetBaseLine(fontSize, font.GetDefaultLeading(fontSize)) / 2f;
						float num6 = 0f;
						if (num3 != 0f)
						{
							num6 = num3 / 2f;
						}
						if (i == 0)
						{
							this.b += this.n;
							num5 += this.n;
						}
						if (this.u == LayOut.Horizontal)
						{
							if (i == 0)
							{
								num2 += this.l;
							}
						}
						else
						{
							num2 = this.a + this.l;
						}
						num2 += num6;
						this.a(A_0, num2, this.b + num4, symbolWidth, legendLabel.a(), num5);
						num2 += this.q + symbolWidth + num3;
						if (this.u == LayOut.Horizontal)
						{
							num2 -= num3;
							legendLabel.a(A_0, num2, this.b);
						}
						else
						{
							legendLabel.a(A_0, this.a + this.l + num + this.q, this.b);
						}
						if (this.u == LayOut.Vertical)
						{
							this.b = this.b + legendLabel.c() + this.p;
						}
						else
						{
							num2 += legendLabel.b() + this.p;
						}
					}
				}
			}
		}

		// Token: 0x06004F39 RID: 20281 RVA: 0x0027A660 File Offset: 0x00279660
		internal void a(PageWriter A_0, float A_1, float A_2, float A_3, PlotAreaElement A_4, float A_5)
		{
			A_0.SetGraphicsMode();
			if (A_4 is LineSeries || A_4 is StackedLineSeriesElement || A_4 is Stacked100PercentLineSeriesElement)
			{
				bool flag = true;
				Marker marker;
				if (A_4 is LineSeries)
				{
					LineSeries lineSeries = (LineSeries)A_4;
					if (lineSeries.LineStyle == LineStyle.None)
					{
						flag = false;
					}
					A_0.SetLineStyle(lineSeries.LineStyle);
					A_0.SetStrokeColor(lineSeries.Color);
					A_0.SetLineWidth(lineSeries.Width);
					marker = lineSeries.Marker;
					if (marker != null && marker.Color == null)
					{
						marker.Color = lineSeries.Color;
					}
				}
				else if (A_4 is StackedLineSeriesElement)
				{
					StackedLineSeriesElement stackedLineSeriesElement = (StackedLineSeriesElement)A_4;
					if (stackedLineSeriesElement.LineStyle == LineStyle.None)
					{
						flag = false;
					}
					A_0.SetLineStyle(stackedLineSeriesElement.LineStyle);
					A_0.SetStrokeColor(stackedLineSeriesElement.Color);
					A_0.SetFillColor(stackedLineSeriesElement.Color);
					A_0.SetLineWidth(stackedLineSeriesElement.Width);
					marker = stackedLineSeriesElement.Marker;
					if (marker != null && marker.Color == null)
					{
						marker.Color = stackedLineSeriesElement.Color;
					}
				}
				else
				{
					Stacked100PercentLineSeriesElement stacked100PercentLineSeriesElement = (Stacked100PercentLineSeriesElement)A_4;
					if (stacked100PercentLineSeriesElement.LineStyle == LineStyle.None)
					{
						flag = false;
					}
					A_0.SetLineStyle(stacked100PercentLineSeriesElement.LineStyle);
					A_0.SetStrokeColor(stacked100PercentLineSeriesElement.Color);
					A_0.SetFillColor(stacked100PercentLineSeriesElement.Color);
					A_0.SetLineWidth(stacked100PercentLineSeriesElement.Width);
					marker = stacked100PercentLineSeriesElement.Marker;
					if (marker != null && marker.Color == null)
					{
						marker.Color = stacked100PercentLineSeriesElement.Color;
					}
				}
				if (flag)
				{
					A_0.Write_m_(A_1, A_2);
					A_0.Write_l_(A_1 + A_3, A_2);
					A_0.Write_S();
				}
				if (marker != null)
				{
					marker.a(A_0, A_1 + A_3 / 2f, A_2);
				}
			}
			else if (A_4 is ColumnSeries || A_4 is BarSeries || A_4 is StackedColumnSeriesElement || A_4 is StackedBarSeriesElement || A_4 is Stacked100PercentColumnSeriesElement || A_4 is Stacked100PercentBarSeriesElement)
			{
				Color color = null;
				if (A_4 is ColumnSeries)
				{
					ColumnSeries columnSeries = (ColumnSeries)A_4;
					A_0.SetFillColor(columnSeries.Color);
					color = columnSeries.BorderColor;
				}
				else if (A_4 is BarSeries)
				{
					BarSeries barSeries = (BarSeries)A_4;
					A_0.SetFillColor(barSeries.Color);
					color = barSeries.BorderColor;
				}
				else if (A_4 is StackedColumnSeriesElement)
				{
					StackedColumnSeriesElement stackedColumnSeriesElement = (StackedColumnSeriesElement)A_4;
					A_0.SetFillColor(stackedColumnSeriesElement.Color);
					color = stackedColumnSeriesElement.BorderColor;
				}
				else if (A_4 is StackedBarSeriesElement)
				{
					StackedBarSeriesElement stackedBarSeriesElement = (StackedBarSeriesElement)A_4;
					A_0.SetFillColor(stackedBarSeriesElement.Color);
					color = stackedBarSeriesElement.BorderColor;
				}
				else if (A_4 is Stacked100PercentBarSeriesElement)
				{
					Stacked100PercentBarSeriesElement stacked100PercentBarSeriesElement = (Stacked100PercentBarSeriesElement)A_4;
					A_0.SetFillColor(stacked100PercentBarSeriesElement.Color);
					color = stacked100PercentBarSeriesElement.BorderColor;
				}
				else if (A_4 is Stacked100PercentColumnSeriesElement)
				{
					Stacked100PercentColumnSeriesElement stacked100PercentColumnSeriesElement = (Stacked100PercentColumnSeriesElement)A_4;
					A_0.SetFillColor(stacked100PercentColumnSeriesElement.Color);
					color = stacked100PercentColumnSeriesElement.BorderColor;
				}
				A_0.Write_re(A_1, A_5, A_3, A_3);
				A_0.Write_f();
				if (color != null)
				{
					A_0.SetLineWidth(1f);
					A_0.SetLineStyle(LineStyle.Solid);
					A_0.SetStrokeColor(color);
					A_0.Write_re(A_1, A_5, A_3, A_3);
					A_0.Write_S();
				}
			}
			else if (A_4 is AreaSeries || A_4 is StackedAreaSeriesElement || A_4 is Stacked100PercentAreaSeriesElement)
			{
				if (A_4 is AreaSeries)
				{
					A_0.SetStrokeColor(((AreaSeries)A_4).Color);
					A_0.SetFillColor(((AreaSeries)A_4).Color);
				}
				else if (A_4 is StackedAreaSeriesElement)
				{
					A_0.SetStrokeColor(((StackedAreaSeriesElement)A_4).Color);
					A_0.SetFillColor(((StackedAreaSeriesElement)A_4).Color);
				}
				else
				{
					A_0.SetStrokeColor(((Stacked100PercentAreaSeriesElement)A_4).Color);
					A_0.SetFillColor(((Stacked100PercentAreaSeriesElement)A_4).Color);
				}
				A_0.SetLineWidth(0f);
				A_0.Write_re(A_1, A_5, A_3, A_3);
				A_0.Write_B();
			}
			else if (A_4 is XYScatterSeries)
			{
				XYScatterSeries xyscatterSeries = (XYScatterSeries)A_4;
				A_0.SetStrokeColor(xyscatterSeries.Color);
				A_0.SetFillColor(xyscatterSeries.Color);
				if (xyscatterSeries.Marker != null && xyscatterSeries.LineDisplay)
				{
					if (xyscatterSeries.LineStyle != LineStyle.None)
					{
						A_0.SetLineStyle(xyscatterSeries.LineStyle);
						A_0.Write_m_(A_1, A_2);
						A_0.Write_l_(A_1 + A_3, A_2);
						A_0.Write_S();
					}
					if (xyscatterSeries.Marker.Color == null)
					{
						xyscatterSeries.Marker.Color = xyscatterSeries.Color;
					}
					xyscatterSeries.Marker.a(A_0, A_1 + A_3 / 2f, A_2);
				}
				else if (xyscatterSeries.Marker != null && !xyscatterSeries.LineDisplay)
				{
					if (xyscatterSeries.Marker.Color == null)
					{
						xyscatterSeries.Marker.Color = xyscatterSeries.Color;
					}
					xyscatterSeries.Marker.a(A_0, A_1 + A_3 / 2f, A_2);
				}
				else if (xyscatterSeries.Marker == null && xyscatterSeries.LineDisplay && xyscatterSeries.LineStyle != LineStyle.None)
				{
					A_0.SetLineStyle(xyscatterSeries.LineStyle);
					A_0.Write_m_(A_1, A_2);
					A_0.Write_l_(A_1 + A_3, A_2);
					A_0.Write_S();
				}
			}
			else if (A_4 is PieSeriesElement)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)A_4;
				A_0.SetFillColor(pieSeriesElement.Color);
				A_0.Write_re(A_1, A_5 + this.k / 2f, A_3, A_3);
				A_0.Write_f();
				if (pieSeriesElement.BorderWidth > 0f)
				{
					A_0.SetLineWidth(pieSeriesElement.BorderWidth);
				}
				A_0.SetLineStyle(LineStyle.Solid);
				pieSeriesElement.a().PlotArea.Series.b(pieSeriesElement);
				A_0.SetStrokeColor(pieSeriesElement.Color);
				A_0.Write_re(A_1, A_5 + this.k / 2f, A_3, A_3);
				A_0.Write_S();
			}
		}

		// Token: 0x04002AC1 RID: 10945
		private float a = -1f;

		// Token: 0x04002AC2 RID: 10946
		private float b = -1f;

		// Token: 0x04002AC3 RID: 10947
		private float c = -1f;

		// Token: 0x04002AC4 RID: 10948
		private float d = -1f;

		// Token: 0x04002AC5 RID: 10949
		private Font e = null;

		// Token: 0x04002AC6 RID: 10950
		private float f = -1f;

		// Token: 0x04002AC7 RID: 10951
		private Color g = null;

		// Token: 0x04002AC8 RID: 10952
		private Color h = null;

		// Token: 0x04002AC9 RID: 10953
		private LineStyle i = LineStyle.Solid;

		// Token: 0x04002ACA RID: 10954
		private Color j = null;

		// Token: 0x04002ACB RID: 10955
		private float k = 1f;

		// Token: 0x04002ACC RID: 10956
		private float l = 5f;

		// Token: 0x04002ACD RID: 10957
		private float m = 5f;

		// Token: 0x04002ACE RID: 10958
		private float n = 5f;

		// Token: 0x04002ACF RID: 10959
		private float o = 5f;

		// Token: 0x04002AD0 RID: 10960
		private float p = 10f;

		// Token: 0x04002AD1 RID: 10961
		private float q = 10f;

		// Token: 0x04002AD2 RID: 10962
		private bool r = true;

		// Token: 0x04002AD3 RID: 10963
		private LegendLabelList s;

		// Token: 0x04002AD4 RID: 10964
		private TextAlign t = TextAlign.Left;

		// Token: 0x04002AD5 RID: 10965
		private LayOut u;
	}
}
