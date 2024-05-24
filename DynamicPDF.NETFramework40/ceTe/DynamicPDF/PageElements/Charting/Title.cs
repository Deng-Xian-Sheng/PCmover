using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007B0 RID: 1968
	public class Title
	{
		// Token: 0x06004FD4 RID: 20436 RVA: 0x0027CCD0 File Offset: 0x0027BCD0
		public Title(string title)
		{
			this.a = title;
		}

		// Token: 0x06004FD5 RID: 20437 RVA: 0x0027CD38 File Offset: 0x0027BD38
		public Title(string title, Color textColor)
		{
			this.a = title;
			this.d = textColor;
		}

		// Token: 0x06004FD6 RID: 20438 RVA: 0x0027CDA8 File Offset: 0x0027BDA8
		public Title(string title, Font font, float fontSize)
		{
			this.a = title;
			this.b = font;
			this.c = fontSize;
		}

		// Token: 0x06004FD7 RID: 20439 RVA: 0x0027CE1C File Offset: 0x0027BE1C
		public Title(string title, Font font, float fontSize, Color textColor)
		{
			this.a = title;
			this.b = font;
			this.c = fontSize;
			this.d = textColor;
		}

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06004FD8 RID: 20440 RVA: 0x0027CE98 File Offset: 0x0027BE98
		// (set) Token: 0x06004FD9 RID: 20441 RVA: 0x0027CEB0 File Offset: 0x0027BEB0
		public string Titles
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

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06004FDA RID: 20442 RVA: 0x0027CEBC File Offset: 0x0027BEBC
		// (set) Token: 0x06004FDB RID: 20443 RVA: 0x0027CED4 File Offset: 0x0027BED4
		public Align Align
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

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06004FDC RID: 20444 RVA: 0x0027CEE0 File Offset: 0x0027BEE0
		// (set) Token: 0x06004FDD RID: 20445 RVA: 0x0027CEF8 File Offset: 0x0027BEF8
		public Font Font
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

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06004FDE RID: 20446 RVA: 0x0027CF04 File Offset: 0x0027BF04
		// (set) Token: 0x06004FDF RID: 20447 RVA: 0x0027CF1C File Offset: 0x0027BF1C
		public float FontSize
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06004FE0 RID: 20448 RVA: 0x0027CF28 File Offset: 0x0027BF28
		// (set) Token: 0x06004FE1 RID: 20449 RVA: 0x0027CF40 File Offset: 0x0027BF40
		public Color TextColor
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

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06004FE2 RID: 20450 RVA: 0x0027CF4C File Offset: 0x0027BF4C
		// (set) Token: 0x06004FE3 RID: 20451 RVA: 0x0027CF64 File Offset: 0x0027BF64
		public float Width
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

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06004FE4 RID: 20452 RVA: 0x0027CF70 File Offset: 0x0027BF70
		// (set) Token: 0x06004FE5 RID: 20453 RVA: 0x0027CF88 File Offset: 0x0027BF88
		public float Height
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

		// Token: 0x06004FE6 RID: 20454 RVA: 0x0027CF94 File Offset: 0x0027BF94
		internal float a()
		{
			float result;
			if (this.h == 1000000f)
			{
				this.e = this.b.GetTextLines(this.a.ToCharArray(), this.g, this.h, this.c);
				this.h = this.e.GetRequiredHeight(0);
				result = this.h + this.j + this.k;
			}
			else
			{
				result = this.h + this.j + this.k;
			}
			return result;
		}

		// Token: 0x06004FE7 RID: 20455 RVA: 0x0027D028 File Offset: 0x0027C028
		internal void a(Chart A_0)
		{
			if (this.b == null)
			{
				this.b = A_0.Font;
			}
			if (this.c <= 0f)
			{
				this.c = A_0.FontSize;
			}
			if (this.d == null)
			{
				this.d = A_0.TextColor;
			}
		}

		// Token: 0x06004FE8 RID: 20456 RVA: 0x0027D08C File Offset: 0x0027C08C
		internal void a(PageWriter A_0, Chart A_1, acl A_2, float A_3, bool A_4)
		{
			float width;
			if (this.g == 1000000f)
			{
				width = A_1.Width - A_1.LeftPadding - A_1.RightPadding - this.m - this.l;
			}
			else
			{
				width = this.g - A_1.LeftPadding - A_1.RightPadding - this.m - this.l;
			}
			this.e = this.b.GetTextLines(this.a.ToCharArray(), width, this.h, this.c);
			switch (this.i)
			{
			case Align.Left:
				if (A_2 == acl.e)
				{
					if (A_4)
					{
						this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.TopPadding + A_3, TextAlign.Left, this.d, null, 0f, false, false, false);
					}
					else
					{
						this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.TopPadding + A_3 + this.j, TextAlign.Left, this.d, null, 0f, false, false, false);
					}
				}
				else if (A_4)
				{
					this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.Height - (A_3 + this.h + A_1.BottomPadding), TextAlign.Left, this.d, null, 0f, false, false, false);
				}
				else
				{
					this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.Height - (A_3 + this.h + A_1.BottomPadding + this.k), TextAlign.Left, this.d, null, 0f, false, false, false);
				}
				break;
			case Align.Center:
				if (A_2 == acl.e)
				{
					if (A_4)
					{
						this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.TopPadding + A_3, TextAlign.Center, this.d, null, 0f, false, false, false);
					}
					else
					{
						this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.TopPadding + A_3 + this.j, TextAlign.Center, this.d, null, 0f, false, false, false);
					}
				}
				else if (A_4)
				{
					this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.Height - (A_3 + this.h + A_1.BottomPadding), TextAlign.Center, this.d, null, 0f, false, false, false);
				}
				else
				{
					this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.Height - (A_3 + this.h + A_1.BottomPadding + this.k), TextAlign.Center, this.d, null, 0f, false, false, false);
				}
				break;
			case Align.Right:
				if (A_2 == acl.e)
				{
					if (A_4)
					{
						this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.TopPadding + A_3, TextAlign.Right, this.d, null, 0f, false, false, false);
					}
					else
					{
						this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.TopPadding + A_3 + this.j, TextAlign.Right, this.d, null, 0f, false, false, false);
					}
				}
				else if (A_4)
				{
					this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.Height - (A_3 + this.h + A_1.BottomPadding), TextAlign.Right, this.d, null, 0f, false, false, false);
				}
				else
				{
					this.e.ja(A_0, A_1.X + A_1.LeftPadding + this.m, A_1.Y + A_1.Height - (A_3 + this.h + A_1.BottomPadding + this.k), TextAlign.Right, this.d, null, 0f, false, false, false);
				}
				break;
			}
		}

		// Token: 0x06004FE9 RID: 20457 RVA: 0x0027D560 File Offset: 0x0027C560
		private void b(PageWriter A_0, float A_1, float A_2, float A_3)
		{
			TextAlign a_ = TextAlign.Center;
			if (this.g == 1000000f)
			{
				this.e = this.b.GetTextLines(this.a.ToCharArray(), A_3 - this.m - this.l, this.h, this.c);
			}
			else
			{
				this.e = this.b.GetTextLines(this.a.ToCharArray(), this.g - this.m - this.l, this.h, this.c);
			}
			if (this.i == Align.Left)
			{
				a_ = TextAlign.Left;
			}
			if (this.i == Align.Right)
			{
				a_ = TextAlign.Right;
			}
			if (this.i == Align.Center)
			{
				a_ = TextAlign.Center;
			}
			this.e.ja(A_0, A_1, A_2, a_, this.d, null, 0f, false, false, false);
		}

		// Token: 0x06004FEA RID: 20458 RVA: 0x0027D650 File Offset: 0x0027C650
		private void a(PageWriter A_0, float A_1, float A_2, float A_3)
		{
			TextAlign align = TextAlign.Center;
			if (this.i == Align.Left)
			{
				align = TextAlign.Left;
			}
			if (this.i == Align.Right)
			{
				align = TextAlign.Right;
			}
			if (this.i == Align.Center)
			{
				align = TextAlign.Center;
			}
			if (this.g == 1000000f)
			{
				this.f = new Label(this.a, A_1, A_2, A_3 - this.m - this.l, this.h, this.b, this.c, align, this.d);
			}
			else
			{
				this.f = new Label(this.a, A_1, A_2, this.g - this.m - this.l, this.h, this.b, this.c, align, this.d);
			}
			this.f.Angle = 270f;
			this.f.Draw(A_0);
		}

		// Token: 0x06004FEB RID: 20459 RVA: 0x0027D748 File Offset: 0x0027C748
		internal void a(PageWriter A_0, PlotArea A_1, acl A_2, float A_3, float A_4)
		{
			if (this.h == 1000000f)
			{
				this.h = this.a();
			}
			switch (A_2)
			{
			case acl.a:
			{
				float a_ = A_1.X + this.m;
				float num = A_1.Y - A_3 - this.h - this.k;
				num -= A_4;
				this.b(A_0, a_, num, A_1.Width);
				break;
			}
			case acl.b:
			{
				float a_ = A_1.X + this.m;
				float num = A_1.Y + A_1.Height + A_3 + this.j;
				num += A_4;
				this.b(A_0, a_, num, A_1.Width);
				break;
			}
			}
		}

		// Token: 0x06004FEC RID: 20460 RVA: 0x0027D810 File Offset: 0x0027C810
		internal void a(PageWriter A_0, PlotArea A_1, XAxis A_2, float A_3)
		{
			float a_ = A_1.X + this.m;
			float num = 0f;
			switch (A_2.TitlePosition)
			{
			case XAxisTitlePosition.BelowPlotArea:
				num = A_1.Y + A_1.Height + A_2.o() + this.j;
				num += A_3;
				break;
			case XAxisTitlePosition.AbovePlotArea:
				num = A_1.Y - A_2.m() - this.h - this.k;
				num -= A_3;
				break;
			case XAxisTitlePosition.BelowXAxis:
				num = this.b(A_1, A_2) + this.j;
				num += A_3;
				break;
			case XAxisTitlePosition.AboveXAxis:
				num = this.a(A_1, A_2) - this.k - this.h;
				num -= A_3;
				break;
			case XAxisTitlePosition.Automatic:
				num = this.c(A_1, A_2);
				if (A_2.AnchorType == XAxisAnchorType.Top)
				{
					num = num - A_3 - this.k;
				}
				else
				{
					num = num + A_3 + this.j;
				}
				break;
			}
			this.b(A_0, a_, num, A_1.Width);
		}

		// Token: 0x06004FED RID: 20461 RVA: 0x0027D91C File Offset: 0x0027C91C
		internal void a(PageWriter A_0, PlotArea A_1, YAxis A_2, float A_3)
		{
			float a_ = A_1.Y + A_1.Height - this.m;
			float num = 0f;
			switch (A_2.TitlePosition)
			{
			case YAxisTitlePosition.LeftOfPlotArea:
				num = A_1.X - A_2.m() - this.h - this.k;
				num -= A_3;
				break;
			case YAxisTitlePosition.RightOfPlotArea:
				num = A_1.X + A_1.Width + A_2.o() + this.k;
				num += A_3;
				break;
			case YAxisTitlePosition.LeftOfYAxis:
				num = this.b(A_1, A_2) - this.k;
				num -= A_3;
				break;
			case YAxisTitlePosition.RightOfYAxis:
				num = this.a(A_1, A_2) + this.k;
				num += A_3;
				break;
			case YAxisTitlePosition.Automatic:
				num = this.c(A_1, A_2);
				if (A_2.AnchorType == YAxisAnchorType.Right)
				{
					num = num + A_3 + this.k;
				}
				else
				{
					num = num - A_3 - this.k;
				}
				break;
			}
			this.a(A_0, num, a_, A_1.Height);
		}

		// Token: 0x06004FEE RID: 20462 RVA: 0x0027DA28 File Offset: 0x0027CA28
		private float c(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height + A_1.o();
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y - A_1.m() - this.h;
				break;
			}
			return result;
		}

		// Token: 0x06004FEF RID: 20463 RVA: 0x0027DA8C File Offset: 0x0027CA8C
		private float b(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
				result = A_0.Y + A_0.Height + A_1.q() - A_1.Offset;
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y + A_1.q() - A_1.Offset;
				break;
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height - A_1.Offset * (A_0.j().g() / A_0.j().t()) - A_0.j().h() * A_0.j().g() - A_0.j().s() * A_0.j().g() + A_1.q();
				break;
			}
			return result;
		}

		// Token: 0x06004FF0 RID: 20464 RVA: 0x0027DB60 File Offset: 0x0027CB60
		private float a(PlotArea A_0, XAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case XAxisAnchorType.Bottom:
				result = A_0.Y + A_0.Height - A_1.q() - this.h - A_1.Offset;
				break;
			case XAxisAnchorType.Top:
				result = A_0.Y - A_1.q() - this.h - A_1.Offset;
				break;
			case XAxisAnchorType.Floating:
				result = A_0.Y + A_0.Height - A_1.Offset * (A_0.j().g() / A_0.j().t()) - A_0.j().h() * A_0.j().g() - A_0.j().s() * A_0.j().g() - A_1.q() - this.h;
				break;
			}
			return result;
		}

		// Token: 0x06004FF1 RID: 20465 RVA: 0x0027DC4C File Offset: 0x0027CC4C
		private float c(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
			case YAxisAnchorType.Floating:
				result = A_0.X - A_1.m() - this.h;
				break;
			case YAxisAnchorType.Right:
				result = A_0.X + A_0.Width + A_1.o();
				break;
			}
			return result;
		}

		// Token: 0x06004FF2 RID: 20466 RVA: 0x0027DCB0 File Offset: 0x0027CCB0
		private float b(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
				result = A_0.X + A_1.Offset - (this.h + A_1.q());
				break;
			case YAxisAnchorType.Right:
				result = A_0.X + A_0.Width + A_1.Offset - (this.h + A_1.q());
				break;
			case YAxisAnchorType.Floating:
				result = A_0.X + A_1.Offset * (A_0.i().g() / A_0.i().t()) + A_0.i().h() * A_0.i().g() + A_0.i().s() * A_0.i().g() - (this.h + A_1.q());
				break;
			}
			return result;
		}

		// Token: 0x06004FF3 RID: 20467 RVA: 0x0027DD94 File Offset: 0x0027CD94
		private float a(PlotArea A_0, YAxis A_1)
		{
			float result = 0f;
			switch (A_1.AnchorType)
			{
			case YAxisAnchorType.Left:
				result = A_0.X + A_1.Offset + A_1.q();
				break;
			case YAxisAnchorType.Right:
				result = A_0.X + A_0.Width + A_1.Offset + A_1.q();
				break;
			case YAxisAnchorType.Floating:
				result = A_0.X + A_1.Offset * (A_0.i().g() / A_0.i().t()) + A_0.i().h() * A_0.i().g() + A_0.i().s() * A_0.i().g() + A_1.q();
				break;
			}
			return result;
		}

		// Token: 0x04002B1B RID: 11035
		private string a;

		// Token: 0x04002B1C RID: 11036
		private Font b;

		// Token: 0x04002B1D RID: 11037
		private float c;

		// Token: 0x04002B1E RID: 11038
		private Color d;

		// Token: 0x04002B1F RID: 11039
		private TextLineList e;

		// Token: 0x04002B20 RID: 11040
		private Label f;

		// Token: 0x04002B21 RID: 11041
		private float g = 1000000f;

		// Token: 0x04002B22 RID: 11042
		private float h = 1000000f;

		// Token: 0x04002B23 RID: 11043
		private Align i = Align.Center;

		// Token: 0x04002B24 RID: 11044
		private float j = 2f;

		// Token: 0x04002B25 RID: 11045
		private float k = 2f;

		// Token: 0x04002B26 RID: 11046
		private float l = 0f;

		// Token: 0x04002B27 RID: 11047
		private float m = 0f;
	}
}
