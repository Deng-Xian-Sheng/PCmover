using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000749 RID: 1865
	public class UnorderedListStyle
	{
		// Token: 0x06004BBF RID: 19391 RVA: 0x00265BFC File Offset: 0x00264BFC
		private UnorderedListStyle(int A_0, Font A_1)
		{
			this.j = string.Concat((char)A_0);
			this.g = A_1;
		}

		// Token: 0x06004BC0 RID: 19392 RVA: 0x00265C20 File Offset: 0x00264C20
		public UnorderedListStyle(string type, Font font)
		{
			this.i = type;
			this.g = font;
		}

		// Token: 0x06004BC1 RID: 19393 RVA: 0x00265C39 File Offset: 0x00264C39
		private UnorderedListStyle(int A_0)
		{
			this.j = string.Concat((char)A_0);
		}

		// Token: 0x06004BC2 RID: 19394 RVA: 0x00265C58 File Offset: 0x00264C58
		internal string a()
		{
			return this.j;
		}

		// Token: 0x06004BC3 RID: 19395 RVA: 0x00265C70 File Offset: 0x00264C70
		internal void a(PageWriter A_0, float A_1, float A_2, ListItem A_3, UnorderedListStyle A_4)
		{
			A_0.SetTextMode();
			if (A_0.Document.Tag != null)
			{
				DocumentWriter documentWriter = A_0.DocumentWriter;
				documentWriter.i(documentWriter.ae() + 1);
				A_3.BulletTag.f(A_0, A_3, A_1, A_2);
			}
			Color textOutlineColor = A_3.TextOutlineColor;
			float textOutlineWidth = A_3.TextOutlineWidth;
			Color textColor = A_3.TextColor;
			if (textOutlineColor != null && textOutlineWidth > 0f)
			{
				if (textColor != null)
				{
					A_0.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
					A_0.SetStrokeColor(textOutlineColor);
					A_0.SetFillColor(textColor);
				}
				else
				{
					A_0.SetTextRenderingMode(TextRenderingMode.Stroke);
					A_0.SetStrokeColor(textOutlineColor);
				}
				A_0.SetLineWidth(textOutlineWidth);
			}
			else if (textColor != null)
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Fill);
				A_0.SetFillColor(textColor);
			}
			else
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Invisible);
			}
			if (A_3.BulletSize == 0f)
			{
				this.h = A_3.FontSize;
			}
			else
			{
				this.h = A_3.BulletSize;
			}
			A_0.SetFont(this.g, this.h);
			switch (A_3.BulletAlign)
			{
			case Align.Center:
				if (this.i == null)
				{
					if (!A_3.RightToLeft)
					{
						A_1 = A_1 + A_3.BulletAreaWidth / 2f - this.g.GetTextWidth(A_4.a(), this.h) / 2f;
					}
					else
					{
						A_1 = A_1 - A_3.BulletAreaWidth / 2f + this.g.GetTextWidth(A_4.a(), this.h) / 2f;
					}
				}
				else if (!A_3.RightToLeft)
				{
					A_1 = A_1 + A_3.BulletAreaWidth / 2f - this.g.GetTextWidth(this.i, this.h) / 2f;
				}
				else
				{
					A_1 = A_1 - A_3.BulletAreaWidth / 2f + this.g.GetTextWidth(this.i, this.h) / 2f;
				}
				break;
			case Align.Right:
				if (this.i == null)
				{
					if (!A_3.RightToLeft)
					{
						A_1 = A_1 + A_3.BulletAreaWidth - this.g.GetTextWidth(A_4.a(), this.h);
					}
					else
					{
						A_1 = A_1 - A_3.BulletAreaWidth + this.g.GetTextWidth(A_4.a(), this.h);
					}
				}
				else if (!A_3.RightToLeft)
				{
					A_1 = A_1 + A_3.BulletAreaWidth - this.g.GetTextWidth(this.i, this.h);
				}
				else
				{
					A_1 = A_1 - A_3.BulletAreaWidth + this.g.GetTextWidth(this.i, this.h);
				}
				break;
			}
			float y = A_2 + A_3.Font.GetBaseLine(A_3.FontSize, A_3.Leading) - (A_3.Font.GetAscender(A_3.FontSize) - this.g.GetAscender(this.h) * 2.95f / 3f) * 0.43f;
			if (A_3.RightToLeft)
			{
				A_1 = A_1 + A_3.LeftIndent + A_3.RightIndent + A_3.h();
				if (this.i != null)
				{
					A_0.Write_Tm(A_1 - this.g.GetTextWidth(this.i, this.h), y);
				}
				else
				{
					A_0.Write_Tm(A_1 - this.g.GetTextWidth(A_4.a(), this.h), y);
				}
			}
			else
			{
				A_0.Write_Tm(A_1, y);
			}
			if (this.i == null)
			{
				A_0.b(A_4.a().ToCharArray(), 0, A_4.a().Length, A_3.RightToLeft);
			}
			else
			{
				A_0.b(this.i.ToCharArray(), 0, this.i.Length, A_3.RightToLeft);
			}
			if (A_0.Document.Tag != null)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x040028E3 RID: 10467
		private const int a = 42;

		// Token: 0x040028E4 RID: 10468
		private const int b = 97;

		// Token: 0x040028E5 RID: 10469
		private const int c = 45;

		// Token: 0x040028E6 RID: 10470
		private const int d = 98;

		// Token: 0x040028E7 RID: 10471
		private const int e = 100;

		// Token: 0x040028E8 RID: 10472
		private const int f = 0;

		// Token: 0x040028E9 RID: 10473
		private Font g;

		// Token: 0x040028EA RID: 10474
		private float h;

		// Token: 0x040028EB RID: 10475
		private string i;

		// Token: 0x040028EC RID: 10476
		private string j;

		// Token: 0x040028ED RID: 10477
		public static readonly UnorderedListStyle None = new UnorderedListStyle(0);

		// Token: 0x040028EE RID: 10478
		public static readonly UnorderedListStyle Asterisk = new UnorderedListStyle(42, Font.Helvetica);

		// Token: 0x040028EF RID: 10479
		public static readonly UnorderedListStyle Circle = new UnorderedListStyle(97, Font.CeTeBullets);

		// Token: 0x040028F0 RID: 10480
		public static readonly UnorderedListStyle Dash = new UnorderedListStyle(45, Font.Helvetica);

		// Token: 0x040028F1 RID: 10481
		public static readonly UnorderedListStyle Disc = new UnorderedListStyle(98, Font.CeTeBullets);

		// Token: 0x040028F2 RID: 10482
		public static readonly UnorderedListStyle Square = new UnorderedListStyle(100, Font.CeTeBullets);
	}
}
