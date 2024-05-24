using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200069B RID: 1691
	public class FontFamily
	{
		// Token: 0x0600402F RID: 16431 RVA: 0x00220F72 File Offset: 0x0021FF72
		public FontFamily(string name, Font regular, Font bold, Font italic, Font boldItalic)
		{
			this.f = name;
			this.g = regular;
			this.h = bold;
			this.i = italic;
			this.j = boldItalic;
		}

		// Token: 0x06004030 RID: 16432 RVA: 0x00220FA2 File Offset: 0x0021FFA2
		public FontFamily(string name, Font font) : this(name, font, font, font, font)
		{
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06004031 RID: 16433 RVA: 0x00220FB4 File Offset: 0x0021FFB4
		public string Name
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06004032 RID: 16434 RVA: 0x00220FCC File Offset: 0x0021FFCC
		public Font Regular
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06004033 RID: 16435 RVA: 0x00220FE4 File Offset: 0x0021FFE4
		public Font Bold
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06004034 RID: 16436 RVA: 0x00220FFC File Offset: 0x0021FFFC
		public Font Italic
		{
			get
			{
				return this.i;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06004035 RID: 16437 RVA: 0x00221014 File Offset: 0x00220014
		public Font BoldItalic
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06004036 RID: 16438 RVA: 0x0022102C File Offset: 0x0022002C
		public static FontFamily Courier
		{
			get
			{
				FontFamily.e();
				return FontFamily.c;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06004037 RID: 16439 RVA: 0x0022104C File Offset: 0x0022004C
		public static FontFamily Helvetica
		{
			get
			{
				FontFamily.d();
				return FontFamily.a;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06004038 RID: 16440 RVA: 0x0022106C File Offset: 0x0022006C
		public static FontFamily Times
		{
			get
			{
				FontFamily.c();
				return FontFamily.b;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06004039 RID: 16441 RVA: 0x0022108C File Offset: 0x0022008C
		public static FontFamily Symbol
		{
			get
			{
				FontFamily.b();
				return FontFamily.d;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x0600403A RID: 16442 RVA: 0x002210AC File Offset: 0x002200AC
		public static FontFamily ZapfDingbats
		{
			get
			{
				FontFamily.a();
				return FontFamily.e;
			}
		}

		// Token: 0x0600403B RID: 16443 RVA: 0x002210CC File Offset: 0x002200CC
		private static void e()
		{
			if (FontFamily.c == null)
			{
				FontFamily.c = new FontFamily("Courier", Font.Courier, Font.CourierBold, Font.CourierOblique, Font.CourierBoldOblique);
			}
		}

		// Token: 0x0600403C RID: 16444 RVA: 0x00221110 File Offset: 0x00220110
		private static void d()
		{
			if (FontFamily.a == null)
			{
				FontFamily.a = new FontFamily("Helvetica", Font.Helvetica, Font.HelveticaBold, Font.HelveticaOblique, Font.HelveticaBoldOblique);
			}
		}

		// Token: 0x0600403D RID: 16445 RVA: 0x00221154 File Offset: 0x00220154
		private static void c()
		{
			if (FontFamily.b == null)
			{
				FontFamily.b = new FontFamily("Times", Font.TimesRoman, Font.TimesBold, Font.TimesItalic, Font.TimesBoldItalic);
			}
		}

		// Token: 0x0600403E RID: 16446 RVA: 0x00221198 File Offset: 0x00220198
		private static void b()
		{
			if (FontFamily.d == null)
			{
				FontFamily.d = new FontFamily("Symbol", Font.Symbol, Font.Symbol, Font.Symbol, Font.Symbol);
			}
		}

		// Token: 0x0600403F RID: 16447 RVA: 0x002211DC File Offset: 0x002201DC
		private static void a()
		{
			if (FontFamily.e == null)
			{
				FontFamily.e = new FontFamily("ZapfDingbats", Font.ZapfDingbats, Font.ZapfDingbats, Font.ZapfDingbats, Font.ZapfDingbats);
			}
		}

		// Token: 0x0400239F RID: 9119
		private static FontFamily a;

		// Token: 0x040023A0 RID: 9120
		private static FontFamily b;

		// Token: 0x040023A1 RID: 9121
		private static FontFamily c;

		// Token: 0x040023A2 RID: 9122
		private static FontFamily d;

		// Token: 0x040023A3 RID: 9123
		private static FontFamily e;

		// Token: 0x040023A4 RID: 9124
		private string f;

		// Token: 0x040023A5 RID: 9125
		private Font g;

		// Token: 0x040023A6 RID: 9126
		private Font h;

		// Token: 0x040023A7 RID: 9127
		private Font i;

		// Token: 0x040023A8 RID: 9128
		private Font j;
	}
}
