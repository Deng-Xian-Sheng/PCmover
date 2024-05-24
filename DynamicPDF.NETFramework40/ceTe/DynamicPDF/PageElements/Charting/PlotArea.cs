using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007AB RID: 1963
	public class PlotArea
	{
		// Token: 0x06004F7B RID: 20347 RVA: 0x0027BD68 File Offset: 0x0027AD68
		internal PlotArea(float A_0, float A_1, float A_2, float A_3)
		{
			this.g = A_0;
			this.h = A_1;
			this.i = A_2;
			this.j = A_3;
			this.a = new SeriesList(this);
			this.b = new XAxisList(this);
			this.c = new YAxisList(this);
			this.f = new TitleList(this.Chart);
			this.e = new TitleList(this.Chart);
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x06004F7C RID: 20348 RVA: 0x0027BDE8 File Offset: 0x0027ADE8
		// (set) Token: 0x06004F7D RID: 20349 RVA: 0x0027BE00 File Offset: 0x0027AE00
		public float X
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

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06004F7E RID: 20350 RVA: 0x0027BE0C File Offset: 0x0027AE0C
		// (set) Token: 0x06004F7F RID: 20351 RVA: 0x0027BE24 File Offset: 0x0027AE24
		public float Y
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

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06004F80 RID: 20352 RVA: 0x0027BE30 File Offset: 0x0027AE30
		// (set) Token: 0x06004F81 RID: 20353 RVA: 0x0027BE48 File Offset: 0x0027AE48
		public float Width
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

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06004F82 RID: 20354 RVA: 0x0027BE54 File Offset: 0x0027AE54
		// (set) Token: 0x06004F83 RID: 20355 RVA: 0x0027BE6C File Offset: 0x0027AE6C
		public float Height
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

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06004F84 RID: 20356 RVA: 0x0027BE78 File Offset: 0x0027AE78
		public SeriesList Series
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06004F85 RID: 20357 RVA: 0x0027BE90 File Offset: 0x0027AE90
		public XAxisList XAxes
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06004F86 RID: 20358 RVA: 0x0027BEA8 File Offset: 0x0027AEA8
		public YAxisList YAxes
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06004F87 RID: 20359 RVA: 0x0027BEC0 File Offset: 0x0027AEC0
		public Chart Chart
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x06004F88 RID: 20360 RVA: 0x0027BED8 File Offset: 0x0027AED8
		internal void a(Chart A_0)
		{
			this.d = A_0;
			this.e.a(A_0);
			this.f.a(A_0);
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06004F89 RID: 20361 RVA: 0x0027BEFC File Offset: 0x0027AEFC
		// (set) Token: 0x06004F8A RID: 20362 RVA: 0x0027BF14 File Offset: 0x0027AF14
		public Color BackgroundColor
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

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x06004F8B RID: 20363 RVA: 0x0027BF20 File Offset: 0x0027AF20
		public TitleList TopTitles
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x06004F8C RID: 20364 RVA: 0x0027BF38 File Offset: 0x0027AF38
		public TitleList BottomTitles
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06004F8D RID: 20365 RVA: 0x0027BF50 File Offset: 0x0027AF50
		// (set) Token: 0x06004F8E RID: 20366 RVA: 0x0027BF68 File Offset: 0x0027AF68
		public bool ClipToPlotArea
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

		// Token: 0x06004F8F RID: 20367 RVA: 0x0027BF74 File Offset: 0x0027AF74
		internal float a()
		{
			return this.m + this.n;
		}

		// Token: 0x06004F90 RID: 20368 RVA: 0x0027BF94 File Offset: 0x0027AF94
		internal float b()
		{
			return this.p + this.o;
		}

		// Token: 0x06004F91 RID: 20369 RVA: 0x0027BFB4 File Offset: 0x0027AFB4
		internal float c()
		{
			return this.n;
		}

		// Token: 0x06004F92 RID: 20370 RVA: 0x0027BFCC File Offset: 0x0027AFCC
		internal float d()
		{
			return this.o;
		}

		// Token: 0x06004F93 RID: 20371 RVA: 0x0027BFE4 File Offset: 0x0027AFE4
		internal float e()
		{
			return this.m;
		}

		// Token: 0x06004F94 RID: 20372 RVA: 0x0027BFFC File Offset: 0x0027AFFC
		internal float f()
		{
			return this.p;
		}

		// Token: 0x06004F95 RID: 20373 RVA: 0x0027C014 File Offset: 0x0027B014
		internal float g()
		{
			return this.q;
		}

		// Token: 0x06004F96 RID: 20374 RVA: 0x0027C02C File Offset: 0x0027B02C
		internal float h()
		{
			return this.r;
		}

		// Token: 0x06004F97 RID: 20375 RVA: 0x0027C044 File Offset: 0x0027B044
		internal XAxis i()
		{
			return this.t;
		}

		// Token: 0x06004F98 RID: 20376 RVA: 0x0027C05C File Offset: 0x0027B05C
		internal YAxis j()
		{
			return this.s;
		}

		// Token: 0x06004F99 RID: 20377 RVA: 0x0027C074 File Offset: 0x0027B074
		internal void k()
		{
			this.t = this.b.g();
		}

		// Token: 0x06004F9A RID: 20378 RVA: 0x0027C088 File Offset: 0x0027B088
		internal void l()
		{
			this.s = this.c.i();
		}

		// Token: 0x06004F9B RID: 20379 RVA: 0x0027C09C File Offset: 0x0027B09C
		internal void m()
		{
			this.q = 0f;
			this.r = 0f;
			for (int i = 0; i < this.c.Count; i++)
			{
				YAxis yaxis = this.c[i];
				float num = yaxis.m() + yaxis.n();
				if (this.q < num)
				{
					this.q = num;
				}
				float num2 = yaxis.o() + yaxis.p();
				if (this.r < num2)
				{
					this.r = num2;
				}
			}
		}

		// Token: 0x06004F9C RID: 20380 RVA: 0x0027C148 File Offset: 0x0027B148
		internal void n()
		{
			this.m = 0f;
			this.p = 0f;
			for (int i = 0; i < this.b.Count; i++)
			{
				XAxis xaxis = this.b[i];
				float num = xaxis.n();
				if (this.m < num)
				{
					this.m = num;
				}
				float num2 = xaxis.p();
				if (this.p < num2)
				{
					this.p = num2;
				}
			}
		}

		// Token: 0x06004F9D RID: 20381 RVA: 0x0027C1E8 File Offset: 0x0027B1E8
		internal void o()
		{
			this.n = 0f;
			this.o = 0f;
			for (int i = 0; i < this.b.Count; i++)
			{
				XAxis xaxis = this.b[i];
				float num = xaxis.m();
				if (this.n < num)
				{
					this.n = num;
				}
				float num2 = xaxis.o();
				if (this.o < num2)
				{
					this.o = num2;
				}
			}
		}

		// Token: 0x06004F9E RID: 20382 RVA: 0x0027C288 File Offset: 0x0027B288
		public void Draw(PageWriter writer)
		{
			if (this.k != null)
			{
				writer.SetGraphicsMode();
				writer.SetFillColor(this.k);
				writer.Write_re(this.g, this.h, this.i, this.j);
				writer.Write_f();
			}
			if (!this.d.AutoLayout)
			{
				this.a.k();
				this.l();
				this.k();
			}
			this.c.f();
			this.b.d();
			this.m();
			this.n();
			this.o();
			this.a(writer);
			this.c.a(writer);
			this.b.a(writer);
			this.a.a(writer);
			this.c.c(writer);
			this.b.c(writer);
		}

		// Token: 0x06004F9F RID: 20383 RVA: 0x0027C380 File Offset: 0x0027B380
		private void a(PageWriter A_0)
		{
			if (this.e != null)
			{
				this.e.a(A_0, this, acl.a, this.a());
			}
			if (this.f != null)
			{
				this.f.b(A_0, this, acl.b, this.b());
			}
		}

		// Token: 0x04002AF1 RID: 10993
		private SeriesList a;

		// Token: 0x04002AF2 RID: 10994
		private XAxisList b;

		// Token: 0x04002AF3 RID: 10995
		private YAxisList c;

		// Token: 0x04002AF4 RID: 10996
		private Chart d;

		// Token: 0x04002AF5 RID: 10997
		private TitleList e;

		// Token: 0x04002AF6 RID: 10998
		private TitleList f;

		// Token: 0x04002AF7 RID: 10999
		private float g;

		// Token: 0x04002AF8 RID: 11000
		private float h;

		// Token: 0x04002AF9 RID: 11001
		private float i;

		// Token: 0x04002AFA RID: 11002
		private float j;

		// Token: 0x04002AFB RID: 11003
		private Color k;

		// Token: 0x04002AFC RID: 11004
		private bool l = true;

		// Token: 0x04002AFD RID: 11005
		private float m;

		// Token: 0x04002AFE RID: 11006
		private float n;

		// Token: 0x04002AFF RID: 11007
		private float o;

		// Token: 0x04002B00 RID: 11008
		private float p;

		// Token: 0x04002B01 RID: 11009
		private float q;

		// Token: 0x04002B02 RID: 11010
		private float r;

		// Token: 0x04002B03 RID: 11011
		private YAxis s;

		// Token: 0x04002B04 RID: 11012
		private XAxis t;
	}
}
