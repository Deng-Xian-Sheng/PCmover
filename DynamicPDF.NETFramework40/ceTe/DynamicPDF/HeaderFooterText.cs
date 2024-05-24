using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006BF RID: 1727
	public class HeaderFooterText
	{
		// Token: 0x060042A4 RID: 17060 RVA: 0x0022B987 File Offset: 0x0022A987
		internal HeaderFooterText()
		{
		}

		// Token: 0x060042A5 RID: 17061 RVA: 0x0022B9C4 File Offset: 0x0022A9C4
		internal HeaderFooterText(HeaderFooterText A_0)
		{
			this.a = A_0.Text;
			this.b = A_0.Font;
			this.c = A_0.FontSize;
			this.f = A_0.a();
			this.g = A_0.g;
		}

		// Token: 0x060042A6 RID: 17062 RVA: 0x0022BA48 File Offset: 0x0022AA48
		public HeaderFooterText(string text)
		{
			this.a = text;
			this.f = this.a(text);
		}

		// Token: 0x060042A7 RID: 17063 RVA: 0x0022BAA4 File Offset: 0x0022AAA4
		public HeaderFooterText(string text, Font font, float fontSize)
		{
			this.a = text;
			this.b = font;
			this.c = fontSize;
			this.f = this.a(text);
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060042A8 RID: 17064 RVA: 0x0022BB0C File Offset: 0x0022AB0C
		// (set) Token: 0x060042A9 RID: 17065 RVA: 0x0022BB24 File Offset: 0x0022AB24
		public string Text
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.f = this.a(this.a);
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060042AA RID: 17066 RVA: 0x0022BB40 File Offset: 0x0022AB40
		// (set) Token: 0x060042AB RID: 17067 RVA: 0x0022BB58 File Offset: 0x0022AB58
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

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060042AC RID: 17068 RVA: 0x0022BB64 File Offset: 0x0022AB64
		// (set) Token: 0x060042AD RID: 17069 RVA: 0x0022BB7C File Offset: 0x0022AB7C
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

		// Token: 0x060042AE RID: 17070 RVA: 0x0022BB88 File Offset: 0x0022AB88
		internal bool a()
		{
			return this.f;
		}

		// Token: 0x060042AF RID: 17071 RVA: 0x0022BBA0 File Offset: 0x0022ABA0
		internal void a(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060042B0 RID: 17072 RVA: 0x0022BBAC File Offset: 0x0022ABAC
		internal bool b()
		{
			return this.g;
		}

		// Token: 0x060042B1 RID: 17073 RVA: 0x0022BBC4 File Offset: 0x0022ABC4
		internal void b(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060042B2 RID: 17074 RVA: 0x0022BBD0 File Offset: 0x0022ABD0
		internal void a(PageWriter A_0, PageDimensions A_1, bool A_2, TextAlign A_3)
		{
			float topMargin = A_1.TopMargin;
			float leftMargin = A_1.LeftMargin;
			float rightMargin = A_1.RightMargin;
			float bottomMargin = A_1.BottomMargin;
			float height = A_1.Height;
			float width = A_1.Width;
			this.d = this.b.GetTextLines(this.a.ToCharArray(), width, this.c);
			this.d.g();
			float num = this.d.i9(0);
			float textHeight = this.d.GetTextHeight();
			float num2 = 0f;
			float num3 = 0f;
			switch (A_3)
			{
			case TextAlign.Left:
				if (A_2)
				{
					num2 -= leftMargin / 2f;
					num3 -= topMargin / 2f;
					num3 -= textHeight;
				}
				else
				{
					num3 = height;
					num2 -= leftMargin / 2f;
					num3 -= topMargin + bottomMargin;
					num3 += bottomMargin / 2f;
				}
				break;
			case TextAlign.Center:
				if (A_2)
				{
					num3 -= topMargin / 2f;
					num3 -= textHeight;
				}
				else
				{
					num3 = height;
					num3 -= topMargin + bottomMargin;
					num3 += bottomMargin / 2f;
				}
				this.d.Width = width - (leftMargin + rightMargin);
				break;
			case TextAlign.Right:
				this.d.Width = width - (leftMargin + rightMargin);
				if (A_2)
				{
					num2 = rightMargin / 2f;
					num3 -= topMargin / 2f;
					num3 -= textHeight;
				}
				else
				{
					num3 = height;
					num2 = rightMargin / 2f;
					num3 -= topMargin + bottomMargin;
					num3 += bottomMargin / 2f;
				}
				break;
			}
			this.d.Draw(A_0, num2, num3, A_3, this.e, false, false);
		}

		// Token: 0x060042B3 RID: 17075 RVA: 0x0022BDA8 File Offset: 0x0022ADA8
		internal HeaderFooterText c()
		{
			return new HeaderFooterText(this);
		}

		// Token: 0x060042B4 RID: 17076 RVA: 0x0022BDC0 File Offset: 0x0022ADC0
		private bool a(string A_0)
		{
			return A_0 != null && (A_0.Contains("%%CP") || A_0.Contains("%%TP") || A_0.Contains("%%SP") || A_0.Contains("%%ST") || A_0.Contains("%%PR"));
		}

		// Token: 0x04002511 RID: 9489
		private string a;

		// Token: 0x04002512 RID: 9490
		private Font b = Font.TimesRoman;

		// Token: 0x04002513 RID: 9491
		private float c = 12f;

		// Token: 0x04002514 RID: 9492
		private TextLineList d;

		// Token: 0x04002515 RID: 9493
		private Color e = Grayscale.Black;

		// Token: 0x04002516 RID: 9494
		private bool f = false;

		// Token: 0x04002517 RID: 9495
		private bool g = false;
	}
}
