using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A3 RID: 1955
	public class Chart : RotatingPageElement
	{
		// Token: 0x06004EC7 RID: 20167 RVA: 0x0027735F File Offset: 0x0027635F
		public Chart(float x, float y, float width, float height) : this(x, y, width, height, Chart.n, Chart.o, Chart.p)
		{
			base.d(3);
		}

		// Token: 0x06004EC8 RID: 20168 RVA: 0x00277388 File Offset: 0x00276388
		public Chart(float x, float y, float width, float height, Font font, float fontSize, Color textColor) : base(x, y, height)
		{
			this.l = width;
			this.e = font;
			this.f = fontSize;
			this.g = textColor;
			this.a = new PlotAreaList(this);
			this.b = new TitleList(this);
			this.c = new TitleList(this);
			this.d = new LegendList(this);
			this.v = width;
			base.d(3);
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x06004EC9 RID: 20169 RVA: 0x00277454 File Offset: 0x00276454
		// (set) Token: 0x06004ECA RID: 20170 RVA: 0x0027746C File Offset: 0x0027646C
		public override float X
		{
			get
			{
				return base.X;
			}
			set
			{
				base.X = value;
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x06004ECB RID: 20171 RVA: 0x00277478 File Offset: 0x00276478
		// (set) Token: 0x06004ECC RID: 20172 RVA: 0x00277490 File Offset: 0x00276490
		public override float Y
		{
			get
			{
				return base.Y;
			}
			set
			{
				base.Y = value;
			}
		}

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x06004ECD RID: 20173 RVA: 0x0027749C File Offset: 0x0027649C
		// (set) Token: 0x06004ECE RID: 20174 RVA: 0x002774B4 File Offset: 0x002764B4
		public float Width
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

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06004ECF RID: 20175 RVA: 0x002774C0 File Offset: 0x002764C0
		// (set) Token: 0x06004ED0 RID: 20176 RVA: 0x002774D8 File Offset: 0x002764D8
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06004ED1 RID: 20177 RVA: 0x002774E4 File Offset: 0x002764E4
		public PlotArea PrimaryPlotArea
		{
			get
			{
				return this.a.a();
			}
		}

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06004ED2 RID: 20178 RVA: 0x00277504 File Offset: 0x00276504
		// (set) Token: 0x06004ED3 RID: 20179 RVA: 0x0027751C File Offset: 0x0027651C
		public float LeftPadding
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

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06004ED4 RID: 20180 RVA: 0x00277528 File Offset: 0x00276528
		// (set) Token: 0x06004ED5 RID: 20181 RVA: 0x00277540 File Offset: 0x00276540
		public float RightPadding
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

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06004ED6 RID: 20182 RVA: 0x0027754C File Offset: 0x0027654C
		// (set) Token: 0x06004ED7 RID: 20183 RVA: 0x00277564 File Offset: 0x00276564
		public float TopPadding
		{
			get
			{
				return this.s;
			}
			set
			{
				this.s = value;
			}
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06004ED8 RID: 20184 RVA: 0x00277570 File Offset: 0x00276570
		// (set) Token: 0x06004ED9 RID: 20185 RVA: 0x00277588 File Offset: 0x00276588
		public float BottomPadding
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

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06004EDA RID: 20186 RVA: 0x00277594 File Offset: 0x00276594
		// (set) Token: 0x06004EDB RID: 20187 RVA: 0x002775AC File Offset: 0x002765AC
		public float ChartLegendSpacing
		{
			get
			{
				return this.u;
			}
			set
			{
				this.u = value;
			}
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x06004EDC RID: 20188 RVA: 0x002775B8 File Offset: 0x002765B8
		public TitleList FooterTitles
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x06004EDD RID: 20189 RVA: 0x002775D0 File Offset: 0x002765D0
		public TitleList HeaderTitles
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x06004EDE RID: 20190 RVA: 0x002775E8 File Offset: 0x002765E8
		public PlotAreaList PlotAreas
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x06004EDF RID: 20191 RVA: 0x00277600 File Offset: 0x00276600
		public LegendList Legends
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x06004EE0 RID: 20192 RVA: 0x00277618 File Offset: 0x00276618
		// (set) Token: 0x06004EE1 RID: 20193 RVA: 0x00277630 File Offset: 0x00276630
		public Font Font
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x06004EE2 RID: 20194 RVA: 0x0027763C File Offset: 0x0027663C
		// (set) Token: 0x06004EE3 RID: 20195 RVA: 0x00277654 File Offset: 0x00276654
		public float FontSize
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06004EE4 RID: 20196 RVA: 0x00277660 File Offset: 0x00276660
		public Color TextColor
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06004EE5 RID: 20197 RVA: 0x00277678 File Offset: 0x00276678
		// (set) Token: 0x06004EE6 RID: 20198 RVA: 0x00277690 File Offset: 0x00276690
		public Color BackgroundColor
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

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06004EE7 RID: 20199 RVA: 0x0027769C File Offset: 0x0027669C
		// (set) Token: 0x06004EE8 RID: 20200 RVA: 0x002776B4 File Offset: 0x002766B4
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

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06004EE9 RID: 20201 RVA: 0x002776C0 File Offset: 0x002766C0
		// (set) Token: 0x06004EEA RID: 20202 RVA: 0x002776D8 File Offset: 0x002766D8
		public float BorderWidth
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06004EEB RID: 20203 RVA: 0x002776E4 File Offset: 0x002766E4
		// (set) Token: 0x06004EEC RID: 20204 RVA: 0x002776FC File Offset: 0x002766FC
		public bool AutoLayout
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

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06004EED RID: 20205 RVA: 0x00277708 File Offset: 0x00276708
		// (set) Token: 0x06004EEE RID: 20206 RVA: 0x00277720 File Offset: 0x00276720
		public LineStyle BorderStyle
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

		// Token: 0x06004EEF RID: 20207 RVA: 0x0027772C File Offset: 0x0027672C
		protected override void DrawRotated(PageWriter writer)
		{
			if (this.AutoLayout)
			{
				this.Layout();
			}
			else
			{
				this.a.b();
			}
			writer.SetGraphicsMode();
			TagOptions tagOptions = null;
			if (writer.Document.Tag != null)
			{
				if (this.Tag == null)
				{
					StructureElement structureElement = new StructureElement(TagType.Figure, true);
					structureElement.Order = this.TagOrder;
					structureElement.e(writer, this);
					string text = null;
					if (this.c != null && this.c.Count != 0)
					{
						if (this.c.Count == 1)
						{
							text = this.c[0].Titles;
						}
						else
						{
							text = this.c[0].Titles;
							for (int i = 1; i < this.c.Count; i++)
							{
								text = text + " : " + this.c[i].Titles;
							}
						}
					}
					else if (this.b != null && this.b.Count != 0)
					{
						if (this.b.Count == 1)
						{
							text = this.b[0].Titles;
						}
						else
						{
							text = this.b[0].Titles;
							for (int i = 1; i < this.b.Count; i++)
							{
								text = text + " : " + this.b[i].Titles;
							}
						}
					}
					structureElement.Title = text;
				}
				else
				{
					this.Tag.e(writer, this);
				}
				tagOptions = writer.Document.Tag;
				writer.Document.Tag = null;
			}
			if (this.i != null)
			{
				writer.SetFillColor(this.i);
				writer.Write_re(this.X, this.Y, this.l, this.Height);
				writer.Write_f();
			}
			if (this.h != null && this.k != LineStyle.None)
			{
				writer.SetLineStyle(this.k);
				writer.SetStrokeColor(this.h);
				writer.SetLineWidth(this.j);
				writer.Write_re(this.X, this.Y, this.l, this.Height);
				writer.Write_S();
			}
			if (this.c != null)
			{
				this.c.a(writer, acl.e);
			}
			if (this.b != null)
			{
				this.b.a(writer, acl.f);
			}
			this.d.a(writer);
			this.a.a(writer);
			if (tagOptions != null)
			{
				writer.Document.Tag = tagOptions;
				Tag.a(writer);
			}
		}

		// Token: 0x06004EF0 RID: 20208 RVA: 0x00277A54 File Offset: 0x00276A54
		public void Layout()
		{
			this.a.b();
			this.a();
			if (this.a.Count > 0)
			{
				this.e();
			}
		}

		// Token: 0x06004EF1 RID: 20209 RVA: 0x00277A94 File Offset: 0x00276A94
		private void e()
		{
			float num = 0f;
			float num2 = 0f;
			float[] array = new float[this.a.Count];
			float[] array2 = new float[this.a.Count];
			float num3 = this.Height;
			array[0] += this.Y + this.s;
			num3 -= this.s;
			num3 -= this.t;
			if (this.c != null)
			{
				float num4 = this.c.a();
				num3 -= num4;
				array[0] += num4;
			}
			if (this.b != null)
			{
				float num5 = this.b.a();
				num3 -= num5;
			}
			if ((this.d.Placement == LegendPlacement.TopCenter || this.d.Placement == LegendPlacement.TopLeft || this.d.Placement == LegendPlacement.TopRight) && this.d.Layout == LayOut.Horizontal)
			{
				array[0] += this.w;
				num3 -= this.w;
				num3 -= this.u;
				array[0] += this.u;
			}
			else if ((this.d.Placement == LegendPlacement.BottomCenter || this.d.Placement == LegendPlacement.BottomLeft || this.d.Placement == LegendPlacement.BottomRight) && this.d.Layout == LayOut.Horizontal)
			{
				num3 -= this.w;
				num3 -= this.u;
			}
			else if (this.d.Placement == LegendPlacement.TopCenter && this.d.Layout == LayOut.Vertical)
			{
				array[0] += this.w;
				num3 -= this.w;
				num3 -= this.u;
				array[0] += this.u;
			}
			else if (this.d.Placement == LegendPlacement.BottomCenter && this.d.Layout == LayOut.Vertical)
			{
				num3 -= this.w;
				num3 -= this.u;
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = this.a[i];
				plotArea.Width = this.v;
				plotArea.Height = num3 / (float)this.a.Count;
				plotArea.Series.k();
				plotArea.l();
				plotArea.k();
				plotArea.YAxes.f();
				float num6 = 0f;
				float num7 = 0f;
				plotArea.m();
				num6 += plotArea.g();
				num7 += plotArea.h();
				if (num2 < num6)
				{
					num2 = num6;
				}
				if (num < num7)
				{
					num = num7;
				}
				float num8 = 0f;
				if (plotArea.TopTitles != null)
				{
					for (int j = 0; j < plotArea.TopTitles.Count; j++)
					{
						Title title = plotArea.TopTitles[j];
						num8 += title.a();
					}
					num3 -= num8;
					array[i] += num8;
				}
				float num9 = 0f;
				if (plotArea.BottomTitles != null)
				{
					for (int j = 0; j < plotArea.BottomTitles.Count; j++)
					{
						Title title = plotArea.BottomTitles[j];
						num9 += title.a();
					}
					num3 -= num9;
					array2[i] += num9;
				}
				plotArea.n();
				if (i == 0 && num8 == 0f && plotArea.a() == 0f)
				{
					float num10 = plotArea.YAxes.g();
					num3 -= num10;
					array[i] += num10;
				}
				if (i == this.a.Count - 1 && num9 == 0f && plotArea.b() == 0f)
				{
					float num11 = plotArea.YAxes.h();
					num3 -= num11;
					array2[i] += num11;
				}
				num3 -= plotArea.e();
				array[i] += plotArea.e();
				num3 -= plotArea.f();
				array2[i] += plotArea.f();
			}
			if (num2 == 0f)
			{
				num2 = this.a.d();
			}
			float num12 = this.v;
			for (int i = 0; i < this.a.Count; i++)
			{
				PlotArea plotArea = this.a[i];
				float num13;
				do
				{
					num13 = 0f;
					plotArea.Width = num12;
					plotArea.XAxes.d();
					plotArea.o();
					float num14 = num2;
					float num15 = num;
					if (num2 < this.a.d())
					{
						num14 = this.a.d();
					}
					if (num < this.a.c())
					{
						num15 = this.a.c();
					}
					float num16 = num12 + num14 + num15;
					if (num16 > this.v)
					{
						num13 = num16 - this.v;
					}
					num12 = num12 - num13 - 1f;
				}
				while (num13 > 0f);
				num3 -= plotArea.c();
				array[i] += plotArea.c();
				num3 -= plotArea.d();
				array2[i] += plotArea.d();
			}
			float num17;
			if (this.a.d() > num2)
			{
				num17 = this.a.d() + this.q + this.X;
			}
			else
			{
				num17 = num2 + this.q + this.X;
			}
			if (this.d.Placement == LegendPlacement.LeftCenter || (this.d.Placement == LegendPlacement.TopLeft && this.d.Layout == LayOut.Vertical) || (this.d.Placement == LegendPlacement.BottomLeft && this.d.Layout == LayOut.Vertical))
			{
				num17 = num17 + (this.l - this.v - this.q - this.u - this.r) + this.u;
			}
			this.a.a(num17, array, array2, num12, num3 / (float)this.a.Count);
		}

		// Token: 0x06004EF2 RID: 20210 RVA: 0x0027826C File Offset: 0x0027726C
		private float d()
		{
			float num = 0f;
			for (int i = 0; i < this.d.Count; i++)
			{
				Legend legend = this.d[i];
				if (legend.Visible)
				{
					num += legend.RequiredWidth;
				}
			}
			return num;
		}

		// Token: 0x06004EF3 RID: 20211 RVA: 0x002782C8 File Offset: 0x002772C8
		private float c()
		{
			float num = 0f;
			for (int i = 0; i < this.d.Count; i++)
			{
				Legend legend = this.d[i];
				if (legend.Visible && legend.b() > 0)
				{
					float requiredHeight = legend.RequiredHeight;
					if (num < requiredHeight)
					{
						num = requiredHeight;
					}
				}
			}
			return num;
		}

		// Token: 0x06004EF4 RID: 20212 RVA: 0x0027834C File Offset: 0x0027734C
		private float b()
		{
			float num = 0f;
			for (int i = 0; i < this.d.Count; i++)
			{
				Legend legend = this.d[i];
				if (legend.Visible && legend.b() > 0)
				{
					float requiredWidth = legend.RequiredWidth;
					if (num < requiredWidth)
					{
						num = requiredWidth;
					}
				}
			}
			return num;
		}

		// Token: 0x06004EF5 RID: 20213 RVA: 0x002783D0 File Offset: 0x002773D0
		private void a(float A_0)
		{
			for (int i = 0; i < this.d.Count; i++)
			{
				Legend legend = this.d[i];
				if (legend.Visible && legend.b() > 0)
				{
					legend.Width = A_0;
				}
			}
		}

		// Token: 0x06004EF6 RID: 20214 RVA: 0x0027842C File Offset: 0x0027742C
		private void a()
		{
			if (this.d.a() > 0)
			{
				float num = this.Width - this.q - this.r - this.u;
				float num2 = this.Height - this.s - this.t - this.ChartLegendSpacing;
				float num3 = 0f;
				int num4 = this.d.a();
				switch (this.d.Layout)
				{
				case LayOut.Horizontal:
					switch (this.d.Placement)
					{
					case LegendPlacement.TopCenter:
					case LegendPlacement.BottomCenter:
					{
						float num5 = this.d();
						num5 += (float)((num4 - 1) * 10);
						float num6 = this.Width - this.q - this.r;
						if (num5 < num6)
						{
							for (int i = 0; i < this.d.Count; i++)
							{
								Legend legend = this.d[i];
								if (legend.Visible && legend.b() > 0)
								{
									legend.a(legend.RequiredWidth);
									num3 += legend.Width;
								}
							}
						}
						else
						{
							float num7 = (num6 - (float)((num4 - 1) * 10)) / (float)num4;
							for (int i = 0; i < this.d.Count; i++)
							{
								Legend legend = this.d[i];
								if (legend.Visible && legend.b() > 0)
								{
									legend.Width = num7;
									num3 += legend.Width;
								}
							}
						}
						this.v = this.Width - this.q - this.r;
						float num8 = this.c();
						float num9 = num2 / 10f * 3.5f;
						if (num8 < num9)
						{
							this.w = num8;
						}
						else
						{
							this.w = num9;
						}
						break;
					}
					case LegendPlacement.TopRight:
					case LegendPlacement.TopLeft:
					case LegendPlacement.BottomLeft:
					case LegendPlacement.BottomRight:
					{
						float num10 = this.d();
						num10 += (float)((num4 - 1) * 10);
						if (num10 < num + this.u)
						{
							for (int i = 0; i < this.d.Count; i++)
							{
								Legend legend = this.d[i];
								if (legend.Visible && legend.b() > 0)
								{
									legend.a(legend.RequiredWidth);
								}
							}
						}
						else
						{
							float num7 = (num + this.u - (float)((num4 - 1) * 10)) / (float)num4;
							this.a(num7);
						}
						this.v = num + this.u;
						float num11 = this.c();
						float num12 = num2 / 10f * 3.5f;
						if (num11 < num12)
						{
							this.w = num11;
						}
						else
						{
							this.w = num12;
						}
						break;
					}
					case LegendPlacement.LeftCenter:
					case LegendPlacement.RightCenter:
					{
						float num5 = this.d();
						num5 += (float)((num4 - 1) * 10);
						float num6;
						switch (num4)
						{
						case 1:
							num6 = num / 10f * 3.5f;
							goto IL_127;
						case 2:
							num6 = num / 10f * 4f;
							goto IL_127;
						}
						num6 = num / 10f * 4.5f;
						IL_127:
						if (num5 < num6)
						{
							this.a(num5);
							this.v = num - num5;
						}
						else
						{
							float num7 = (num6 - (float)((num4 - 1) * 10)) / (float)num4;
							this.a(num7);
							this.v = num - num6;
						}
						break;
					}
					}
					break;
				case LayOut.Vertical:
					switch (this.d.Placement)
					{
					case LegendPlacement.TopCenter:
					case LegendPlacement.BottomCenter:
					{
						float num13 = this.Width - this.q - this.RightPadding;
						for (int i = 0; i < this.d.Count; i++)
						{
							Legend legend = this.d[i];
							if (legend.Visible && legend.b() > 0)
							{
								float requiredWidth = legend.RequiredWidth;
								if (requiredWidth < num13)
								{
									legend.a(requiredWidth);
								}
								else
								{
									legend.Width = num13;
								}
							}
						}
						this.v = num13;
						float num14 = 0f;
						for (int i = 0; i < this.d.Count; i++)
						{
							Legend legend = this.d[i];
							if (legend.Visible && legend.b() > 0)
							{
								float requiredHeight = legend.RequiredHeight;
								num14 += requiredHeight + 10f;
								legend.Height = requiredHeight;
							}
						}
						float num9;
						switch (num4)
						{
						case 1:
							num9 = num2 / 10f * 3.5f;
							goto IL_794;
						case 2:
							num9 = num2 / 10f * 4f;
							goto IL_794;
						}
						num9 = num2 / 10f * 4.5f;
						IL_794:
						if (num14 < num9)
						{
							this.w = num14;
						}
						else
						{
							this.w = num9;
						}
						break;
					}
					case LegendPlacement.TopRight:
					case LegendPlacement.TopLeft:
					case LegendPlacement.BottomLeft:
					case LegendPlacement.BottomRight:
					{
						float num15 = this.b();
						float num6 = num / 10f * 3.5f;
						if (num15 < num6)
						{
							this.a(num15);
							this.v = num - num15;
						}
						else
						{
							this.a(num6);
							this.v = num - num6;
						}
						for (int i = 0; i < this.d.Count; i++)
						{
							Legend legend = this.d[i];
							if (legend.Visible && legend.b() > 0)
							{
								this.w += legend.RequiredHeight + 10f;
								legend.b(legend.RequiredHeight);
							}
						}
						break;
					}
					case LegendPlacement.LeftCenter:
					case LegendPlacement.RightCenter:
					{
						float num16 = num / 10f * 3.5f;
						float num15 = this.b();
						if (num15 < num16)
						{
							for (int i = 0; i < this.d.Count; i++)
							{
								Legend legend = this.d[i];
								if (legend.Visible && legend.b() > 0)
								{
									legend.Width = num15;
									this.w += legend.RequiredHeight;
								}
							}
							this.v = num - num15;
						}
						else
						{
							for (int i = 0; i < this.d.Count; i++)
							{
								Legend legend = this.d[i];
								if (legend.Visible && legend.b() > 0)
								{
									legend.Width = num16;
									this.w += legend.RequiredHeight;
								}
							}
							this.v = num - num16;
						}
						break;
					}
					}
					break;
				}
				float num17 = 0f;
				float num18;
				if (((this.d.Placement == LegendPlacement.BottomCenter || this.d.Placement == LegendPlacement.BottomLeft || this.d.Placement == LegendPlacement.BottomRight) && (this.d.Layout == LayOut.Horizontal || this.d.Layout == LayOut.Vertical)) || (this.d.Placement == LegendPlacement.BottomCenter && this.d.Layout == LayOut.Vertical))
				{
					num18 = this.Y + this.Height - this.b.a() - this.t;
				}
				else
				{
					num18 = this.Y + this.c.a() + this.s;
				}
				float num19 = 10f;
				float num20 = this.Y + this.u + this.s + this.c.a() + (this.Height - this.w - this.s - this.t - this.c.a() - this.b.a() - this.u);
				float num21 = this.Y + this.Height - this.w - this.t - this.b.a();
				if (num21 < this.Y)
				{
					num21 = this.Y + this.s;
				}
				for (int i = 0; i < this.d.Count; i++)
				{
					Legend legend = this.d[i];
					if (legend.Visible && legend.b() > 0)
					{
						switch (this.d.Layout)
						{
						case LayOut.Horizontal:
							switch (this.d.Placement)
							{
							case LegendPlacement.TopCenter:
							{
								legend.Y = num18;
								float num22 = (this.Width - this.q - this.r - num3) / (float)(num4 + 1);
								if (num22 < 0f)
								{
									num22 = 0f;
								}
								legend.X = this.X + this.q + num22 + num17;
								num17 += num22 + legend.Width;
								break;
							}
							case LegendPlacement.TopRight:
								legend = this.d[this.d.a() - 1 - i];
								legend.X = this.X + this.Width - this.r - num17 - legend.Width;
								legend.Y = this.Y + this.c.a() + this.s;
								num17 += num19 + legend.Width;
								break;
							case LegendPlacement.TopLeft:
								legend.X = this.X + this.r + num17;
								legend.Y = this.Y + this.c.a() + this.s;
								num17 += legend.Width + num19;
								break;
							case LegendPlacement.LeftCenter:
							{
								float num23 = (this.Height - (this.s + this.t + this.c.a() + this.b.a())) / 2f;
								legend.X = this.X + this.q + num17;
								legend.Y = this.Y + this.s + this.c.a() + num23 - legend.RequiredHeight / 2f;
								num17 = num17 + legend.Width + 10f;
								break;
							}
							case LegendPlacement.RightCenter:
							{
								float num23 = (this.Height - (this.s + this.t + this.c.a() + this.b.a())) / 2f;
								legend.X = this.X + this.v + this.q + num17 + this.u;
								legend.Y = this.Y + this.s + this.c.a() + num23 - legend.RequiredHeight / 2f;
								num17 = num17 + legend.Width + 10f;
								break;
							}
							case LegendPlacement.BottomCenter:
							{
								legend.Y = num18 - this.w;
								float num22 = (this.Width - this.q - this.r - num3) / (float)(num4 + 1);
								legend.X = this.X + this.q + num22 + num17;
								num17 += num22 + legend.Width;
								break;
							}
							case LegendPlacement.BottomLeft:
								legend.X = this.X + this.q + num17;
								legend.Y = this.Y + this.Height - this.t - this.b.a() - this.w;
								num17 += legend.Width + num19;
								break;
							case LegendPlacement.BottomRight:
								legend = this.d[this.d.a() - 1 - i];
								legend.X = this.X + this.Width - this.r - num17 - legend.Width;
								legend.Y = this.Y + this.Height - this.b.a() - this.t - this.w;
								num17 += num19 + legend.Width;
								break;
							}
							break;
						case LayOut.Vertical:
							switch (this.d.Placement)
							{
							case LegendPlacement.TopCenter:
							{
								legend.Y = num18;
								float num22 = (this.Width - this.q - this.r - legend.Width) / 2f;
								legend.X = this.X + this.q + num22;
								num18 += legend.Height + num19;
								break;
							}
							case LegendPlacement.TopRight:
								legend.X = this.X + this.v + this.u + this.q;
								legend.Y = num18;
								num18 += legend.Height + num19;
								break;
							case LegendPlacement.TopLeft:
								legend.X = this.X + this.r;
								legend.Y = num18;
								num18 += legend.Height + num19;
								break;
							case LegendPlacement.LeftCenter:
							{
								float num24 = (this.Height - (this.s + this.t + this.c.a() + this.b.a() + this.w)) / (float)(num4 + 1);
								if (num24 < 0f)
								{
									num24 = 0f;
								}
								if (i == 0)
								{
									num18 += num24;
								}
								legend.X = this.X + this.q;
								legend.Y = num18;
								num18 = num18 + legend.Height + num24;
								break;
							}
							case LegendPlacement.RightCenter:
							{
								float num24 = (this.Height - (this.s + this.t + this.c.a() + this.b.a() + this.w)) / (float)(num4 + 1);
								if (num24 < 0f)
								{
									num24 = 0f;
								}
								legend.X = this.X + this.v + this.q + this.u;
								if (i == 0)
								{
									num18 += num24;
								}
								legend.Y = num18;
								num18 = num18 + legend.Height + num24;
								break;
							}
							case LegendPlacement.BottomCenter:
							{
								legend.Y = num20;
								float num22 = (this.Width - this.q - this.r - legend.Width) / 2f;
								legend.X = this.X + this.q + num22;
								num20 += legend.Height + 10f;
								break;
							}
							case LegendPlacement.BottomLeft:
								legend.X = this.X + this.r;
								legend.Y = num21;
								num21 += legend.Height + 10f;
								break;
							case LegendPlacement.BottomRight:
								legend.X = this.X + this.v + this.u + this.q;
								legend.Y = num21;
								num21 += legend.Height + 10f;
								break;
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x06004EF7 RID: 20215 RVA: 0x002794F0 File Offset: 0x002784F0
		internal override byte cb()
		{
			return 68;
		}

		// Token: 0x04002A9D RID: 10909
		private new PlotAreaList a;

		// Token: 0x04002A9E RID: 10910
		private TitleList b;

		// Token: 0x04002A9F RID: 10911
		private TitleList c;

		// Token: 0x04002AA0 RID: 10912
		private new LegendList d;

		// Token: 0x04002AA1 RID: 10913
		private Font e;

		// Token: 0x04002AA2 RID: 10914
		private float f;

		// Token: 0x04002AA3 RID: 10915
		private Color g;

		// Token: 0x04002AA4 RID: 10916
		private Color h;

		// Token: 0x04002AA5 RID: 10917
		private Color i;

		// Token: 0x04002AA6 RID: 10918
		private float j;

		// Token: 0x04002AA7 RID: 10919
		private LineStyle k = LineStyle.Solid;

		// Token: 0x04002AA8 RID: 10920
		private float l;

		// Token: 0x04002AA9 RID: 10921
		private bool m = true;

		// Token: 0x04002AAA RID: 10922
		private static Font n = Font.Helvetica;

		// Token: 0x04002AAB RID: 10923
		private new static float o = 12f;

		// Token: 0x04002AAC RID: 10924
		private static Color p = Grayscale.Black;

		// Token: 0x04002AAD RID: 10925
		private float q = 5f;

		// Token: 0x04002AAE RID: 10926
		private float r = 5f;

		// Token: 0x04002AAF RID: 10927
		private float s = 5f;

		// Token: 0x04002AB0 RID: 10928
		private float t = 5f;

		// Token: 0x04002AB1 RID: 10929
		private float u = 5f;

		// Token: 0x04002AB2 RID: 10930
		private float v;

		// Token: 0x04002AB3 RID: 10931
		private float w = 0f;
	}
}
