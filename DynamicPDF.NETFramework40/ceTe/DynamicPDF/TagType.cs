using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200065E RID: 1630
	public abstract class TagType
	{
		// Token: 0x06003D93 RID: 15763 RVA: 0x00215B48 File Offset: 0x00214B48
		internal static MarkedContentTagType a()
		{
			return (TagType.@as == null) ? (TagType.@as = new MarkedContentTagType("Artifact")) : TagType.@as;
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06003D94 RID: 15764 RVA: 0x00215B7C File Offset: 0x00214B7C
		public static StandardTagType Paragraph
		{
			get
			{
				return (TagType.a == null) ? (TagType.a = new StandardTagType("P")) : TagType.a;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06003D95 RID: 15765 RVA: 0x00215BB0 File Offset: 0x00214BB0
		public static StandardTagType Heading
		{
			get
			{
				return (TagType.b == null) ? (TagType.b = new StandardTagType("H")) : TagType.b;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06003D96 RID: 15766 RVA: 0x00215BE4 File Offset: 0x00214BE4
		public static StandardTagType HeadingLevel1
		{
			get
			{
				return (TagType.c == null) ? (TagType.c = new StandardTagType("H1")) : TagType.c;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06003D97 RID: 15767 RVA: 0x00215C18 File Offset: 0x00214C18
		public static StandardTagType HeadingLevel2
		{
			get
			{
				return (TagType.d == null) ? (TagType.d = new StandardTagType("H2")) : TagType.d;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06003D98 RID: 15768 RVA: 0x00215C4C File Offset: 0x00214C4C
		public static StandardTagType HeadingLevel3
		{
			get
			{
				return (TagType.e == null) ? (TagType.e = new StandardTagType("H3")) : TagType.e;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06003D99 RID: 15769 RVA: 0x00215C80 File Offset: 0x00214C80
		public static StandardTagType HeadingLevel4
		{
			get
			{
				return (TagType.f == null) ? (TagType.f = new StandardTagType("H4")) : TagType.f;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06003D9A RID: 15770 RVA: 0x00215CB4 File Offset: 0x00214CB4
		public static StandardTagType HeadingLevel5
		{
			get
			{
				return (TagType.g == null) ? (TagType.g = new StandardTagType("H5")) : TagType.g;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06003D9B RID: 15771 RVA: 0x00215CE8 File Offset: 0x00214CE8
		public static StandardTagType HeadingLevel6
		{
			get
			{
				return (TagType.h == null) ? (TagType.h = new StandardTagType("H6")) : TagType.h;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06003D9C RID: 15772 RVA: 0x00215D1C File Offset: 0x00214D1C
		public static StandardTagType Figure
		{
			get
			{
				return (TagType.ap == null) ? (TagType.ap = new StandardTagType("Figure")) : TagType.ap;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06003D9D RID: 15773 RVA: 0x00215D50 File Offset: 0x00214D50
		public static StandardTagType Table
		{
			get
			{
				return (TagType.i == null) ? (TagType.i = new StandardTagType("Table")) : TagType.i;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06003D9E RID: 15774 RVA: 0x00215D84 File Offset: 0x00214D84
		public static StandardTagType Document
		{
			get
			{
				return (TagType.k == null) ? (TagType.k = new StandardTagType("Document")) : TagType.k;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06003D9F RID: 15775 RVA: 0x00215DB8 File Offset: 0x00214DB8
		public static StandardTagType Part
		{
			get
			{
				return (TagType.l == null) ? (TagType.l = new StandardTagType("Part")) : TagType.l;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06003DA0 RID: 15776 RVA: 0x00215DEC File Offset: 0x00214DEC
		public static StandardTagType Article
		{
			get
			{
				return (TagType.m == null) ? (TagType.m = new StandardTagType("Art")) : TagType.m;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06003DA1 RID: 15777 RVA: 0x00215E20 File Offset: 0x00214E20
		public static StandardTagType Section
		{
			get
			{
				return (TagType.n == null) ? (TagType.n = new StandardTagType("Sect")) : TagType.n;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06003DA2 RID: 15778 RVA: 0x00215E54 File Offset: 0x00214E54
		public static StandardTagType Division
		{
			get
			{
				return (TagType.o == null) ? (TagType.o = new StandardTagType("Div")) : TagType.o;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06003DA3 RID: 15779 RVA: 0x00215E88 File Offset: 0x00214E88
		public static StandardTagType BlockQuotation
		{
			get
			{
				return (TagType.p == null) ? (TagType.p = new StandardTagType("BlockQuote")) : TagType.p;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06003DA4 RID: 15780 RVA: 0x00215EBC File Offset: 0x00214EBC
		public static StandardTagType Caption
		{
			get
			{
				return (TagType.q == null) ? (TagType.q = new StandardTagType("Caption")) : TagType.q;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06003DA5 RID: 15781 RVA: 0x00215EF0 File Offset: 0x00214EF0
		public static StandardTagType TableOfContent
		{
			get
			{
				return (TagType.r == null) ? (TagType.r = new StandardTagType("TOC")) : TagType.r;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06003DA6 RID: 15782 RVA: 0x00215F24 File Offset: 0x00214F24
		public static StandardTagType TableOfContentItem
		{
			get
			{
				return (TagType.s == null) ? (TagType.s = new StandardTagType("TOCI")) : TagType.s;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06003DA7 RID: 15783 RVA: 0x00215F58 File Offset: 0x00214F58
		public static StandardTagType Index
		{
			get
			{
				return (TagType.t == null) ? (TagType.t = new StandardTagType("Index")) : TagType.t;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06003DA8 RID: 15784 RVA: 0x00215F8C File Offset: 0x00214F8C
		public static StandardTagType NonStructuralElement
		{
			get
			{
				return (TagType.u == null) ? (TagType.u = new StandardTagType("NonStruct")) : TagType.u;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06003DA9 RID: 15785 RVA: 0x00215FC0 File Offset: 0x00214FC0
		public static StandardTagType Private
		{
			get
			{
				return (TagType.v == null) ? (TagType.v = new StandardTagType("Private")) : TagType.v;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06003DAA RID: 15786 RVA: 0x00215FF4 File Offset: 0x00214FF4
		public static StandardTagType List
		{
			get
			{
				return (TagType.w == null) ? (TagType.w = new StandardTagType("L")) : TagType.w;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06003DAB RID: 15787 RVA: 0x00216028 File Offset: 0x00215028
		public static StandardTagType ListItem
		{
			get
			{
				return (TagType.x == null) ? (TagType.x = new StandardTagType("LI")) : TagType.x;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06003DAC RID: 15788 RVA: 0x0021605C File Offset: 0x0021505C
		public static StandardTagType Label
		{
			get
			{
				return (TagType.y == null) ? (TagType.y = new StandardTagType("Lbl")) : TagType.y;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06003DAD RID: 15789 RVA: 0x00216090 File Offset: 0x00215090
		public static StandardTagType ListBody
		{
			get
			{
				return (TagType.z == null) ? (TagType.z = new StandardTagType("LBody")) : TagType.z;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06003DAE RID: 15790 RVA: 0x002160C4 File Offset: 0x002150C4
		public static StandardTagType TableRow
		{
			get
			{
				return (TagType.aa == null) ? (TagType.aa = new StandardTagType("TR")) : TagType.aa;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06003DAF RID: 15791 RVA: 0x002160F8 File Offset: 0x002150F8
		public static StandardTagType TableHeader
		{
			get
			{
				return (TagType.j == null) ? (TagType.j = new StandardTagType("TH")) : TagType.j;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06003DB0 RID: 15792 RVA: 0x0021612C File Offset: 0x0021512C
		public static StandardTagType TableDataCell
		{
			get
			{
				return (TagType.ab == null) ? (TagType.ab = new StandardTagType("TD")) : TagType.ab;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06003DB1 RID: 15793 RVA: 0x00216160 File Offset: 0x00215160
		public static StandardTagType TableHeaderRowGroup
		{
			get
			{
				return (TagType.ac == null) ? (TagType.ac = new StandardTagType("THead")) : TagType.ac;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06003DB2 RID: 15794 RVA: 0x00216194 File Offset: 0x00215194
		public static StandardTagType TableBodyRowGroup
		{
			get
			{
				return (TagType.ad == null) ? (TagType.ad = new StandardTagType("TBody")) : TagType.ad;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06003DB3 RID: 15795 RVA: 0x002161C8 File Offset: 0x002151C8
		public static StandardTagType TableFooterRowGroup
		{
			get
			{
				return (TagType.ae == null) ? (TagType.ae = new StandardTagType("TFoot")) : TagType.ae;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06003DB4 RID: 15796 RVA: 0x002161FC File Offset: 0x002151FC
		public static StandardTagType Span
		{
			get
			{
				return (TagType.af == null) ? (TagType.af = new StandardTagType("Span")) : TagType.af;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06003DB5 RID: 15797 RVA: 0x00216230 File Offset: 0x00215230
		public static StandardTagType Quotation
		{
			get
			{
				return (TagType.ag == null) ? (TagType.ag = new StandardTagType("Quote")) : TagType.ag;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06003DB6 RID: 15798 RVA: 0x00216264 File Offset: 0x00215264
		public static StandardTagType Note
		{
			get
			{
				return (TagType.ah == null) ? (TagType.ah = new StandardTagType("Note")) : TagType.ah;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06003DB7 RID: 15799 RVA: 0x00216298 File Offset: 0x00215298
		public static StandardTagType Reference
		{
			get
			{
				return (TagType.ai == null) ? (TagType.ai = new StandardTagType("Reference")) : TagType.ai;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06003DB8 RID: 15800 RVA: 0x002162CC File Offset: 0x002152CC
		public static StandardTagType BibliographyEntry
		{
			get
			{
				return (TagType.aj == null) ? (TagType.aj = new StandardTagType("BibEntry")) : TagType.aj;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06003DB9 RID: 15801 RVA: 0x00216300 File Offset: 0x00215300
		public static StandardTagType Code
		{
			get
			{
				return (TagType.ak == null) ? (TagType.ak = new StandardTagType("Code")) : TagType.ak;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06003DBA RID: 15802 RVA: 0x00216334 File Offset: 0x00215334
		public static StandardTagType Link
		{
			get
			{
				return (TagType.al == null) ? (TagType.al = new StandardTagType("Link")) : TagType.al;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06003DBB RID: 15803 RVA: 0x00216368 File Offset: 0x00215368
		public static StandardTagType Annotation
		{
			get
			{
				return (TagType.am == null) ? (TagType.am = new StandardTagType("Annot")) : TagType.am;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06003DBC RID: 15804 RVA: 0x0021639C File Offset: 0x0021539C
		public static StandardTagType Ruby
		{
			get
			{
				return (TagType.an == null) ? (TagType.an = new StandardTagType("Ruby")) : TagType.an;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06003DBD RID: 15805 RVA: 0x002163D0 File Offset: 0x002153D0
		public static StandardTagType Warichu
		{
			get
			{
				return (TagType.ao == null) ? (TagType.ao = new StandardTagType("Warichu")) : TagType.ao;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06003DBE RID: 15806 RVA: 0x00216404 File Offset: 0x00215404
		public static StandardTagType Formula
		{
			get
			{
				return (TagType.aq == null) ? (TagType.aq = new StandardTagType("Formula")) : TagType.aq;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06003DBF RID: 15807 RVA: 0x00216438 File Offset: 0x00215438
		public static StandardTagType Form
		{
			get
			{
				return (TagType.ar == null) ? (TagType.ar = new StandardTagType("Form")) : TagType.ar;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06003DC0 RID: 15808 RVA: 0x0021646C File Offset: 0x0021546C
		public static StandardTagType Html
		{
			get
			{
				return (TagType.at == null) ? (TagType.at = new StandardTagType("HTML")) : TagType.at;
			}
		}

		// Token: 0x06003DC1 RID: 15809 RVA: 0x002164A0 File Offset: 0x002154A0
		internal virtual bool b3()
		{
			return false;
		}

		// Token: 0x06003DC2 RID: 15810 RVA: 0x002164B4 File Offset: 0x002154B4
		internal static StandardTagType a(string A_0)
		{
			switch (A_0)
			{
			case "Annot":
				return TagType.Annotation;
			case "Art":
				return TagType.Article;
			case "BibEntry":
				return TagType.BibliographyEntry;
			case "BlockQuote":
				return TagType.BlockQuotation;
			case "Caption":
				return TagType.Caption;
			case "Code":
				return TagType.Code;
			case "Div":
				return TagType.Division;
			case "Document":
				return TagType.Document;
			case "Figure":
				return TagType.Figure;
			case "Form":
				return TagType.Form;
			case "Formula":
				return TagType.Formula;
			case "H":
				return TagType.Heading;
			case "H1":
				return TagType.HeadingLevel1;
			case "H2":
				return TagType.HeadingLevel2;
			case "H3":
				return TagType.HeadingLevel3;
			case "H4":
				return TagType.HeadingLevel4;
			case "H5":
				return TagType.HeadingLevel5;
			case "H6":
				return TagType.HeadingLevel6;
			case "Index":
				return TagType.Index;
			case "Lbl":
				return TagType.Label;
			case "Link":
				return TagType.Link;
			case "L":
				return TagType.List;
			case "LBody":
				return TagType.ListBody;
			case "LI":
				return TagType.ListItem;
			case "NonStruct":
				return TagType.NonStructuralElement;
			case "Note":
				return TagType.Note;
			case "P":
				return TagType.Paragraph;
			case "Part":
				return TagType.Part;
			case "Private":
				return TagType.Private;
			case "Quote":
				return TagType.Quotation;
			case "Reference":
				return TagType.Reference;
			case "Ruby":
				return TagType.Ruby;
			case "Sect":
				return TagType.Section;
			case "Span":
				return TagType.Span;
			case "Table":
				return TagType.Table;
			case "TBody":
				return TagType.TableBodyRowGroup;
			case "TD":
				return TagType.TableDataCell;
			case "TFoot":
				return TagType.TableFooterRowGroup;
			case "TH":
				return TagType.TableHeader;
			case "THead":
				return TagType.TableHeaderRowGroup;
			case "TOC":
				return TagType.TableOfContent;
			case "TOCI":
				return TagType.TableOfContentItem;
			case "TR":
				return TagType.TableRow;
			case "Warichu":
				return TagType.Warichu;
			case "Html":
				return TagType.Html;
			}
			return new StandardTagType(A_0);
		}

		// Token: 0x04002132 RID: 8498
		private static StandardTagType a = null;

		// Token: 0x04002133 RID: 8499
		private static StandardTagType b = null;

		// Token: 0x04002134 RID: 8500
		private static StandardTagType c = null;

		// Token: 0x04002135 RID: 8501
		private static StandardTagType d = null;

		// Token: 0x04002136 RID: 8502
		private static StandardTagType e = null;

		// Token: 0x04002137 RID: 8503
		private static StandardTagType f = null;

		// Token: 0x04002138 RID: 8504
		private static StandardTagType g = null;

		// Token: 0x04002139 RID: 8505
		private static StandardTagType h = null;

		// Token: 0x0400213A RID: 8506
		private static StandardTagType i = null;

		// Token: 0x0400213B RID: 8507
		private static StandardTagType j = null;

		// Token: 0x0400213C RID: 8508
		private static StandardTagType k = null;

		// Token: 0x0400213D RID: 8509
		private static StandardTagType l = null;

		// Token: 0x0400213E RID: 8510
		private static StandardTagType m = null;

		// Token: 0x0400213F RID: 8511
		private static StandardTagType n = null;

		// Token: 0x04002140 RID: 8512
		private static StandardTagType o = null;

		// Token: 0x04002141 RID: 8513
		private static StandardTagType p = null;

		// Token: 0x04002142 RID: 8514
		private static StandardTagType q = null;

		// Token: 0x04002143 RID: 8515
		private static StandardTagType r = null;

		// Token: 0x04002144 RID: 8516
		private static StandardTagType s = null;

		// Token: 0x04002145 RID: 8517
		private static StandardTagType t = null;

		// Token: 0x04002146 RID: 8518
		private static StandardTagType u = null;

		// Token: 0x04002147 RID: 8519
		private static StandardTagType v = null;

		// Token: 0x04002148 RID: 8520
		private static StandardTagType w = null;

		// Token: 0x04002149 RID: 8521
		private static StandardTagType x = null;

		// Token: 0x0400214A RID: 8522
		private static StandardTagType y = null;

		// Token: 0x0400214B RID: 8523
		private static StandardTagType z = null;

		// Token: 0x0400214C RID: 8524
		private static StandardTagType aa = null;

		// Token: 0x0400214D RID: 8525
		private static StandardTagType ab = null;

		// Token: 0x0400214E RID: 8526
		private static StandardTagType ac = null;

		// Token: 0x0400214F RID: 8527
		private static StandardTagType ad = null;

		// Token: 0x04002150 RID: 8528
		private static StandardTagType ae = null;

		// Token: 0x04002151 RID: 8529
		private static StandardTagType af = null;

		// Token: 0x04002152 RID: 8530
		private static StandardTagType ag = null;

		// Token: 0x04002153 RID: 8531
		private static StandardTagType ah = null;

		// Token: 0x04002154 RID: 8532
		private static StandardTagType ai = null;

		// Token: 0x04002155 RID: 8533
		private static StandardTagType aj = null;

		// Token: 0x04002156 RID: 8534
		private static StandardTagType ak = null;

		// Token: 0x04002157 RID: 8535
		private static StandardTagType al = null;

		// Token: 0x04002158 RID: 8536
		private static StandardTagType am = null;

		// Token: 0x04002159 RID: 8537
		private static StandardTagType an = null;

		// Token: 0x0400215A RID: 8538
		private static StandardTagType ao = null;

		// Token: 0x0400215B RID: 8539
		private static StandardTagType ap = null;

		// Token: 0x0400215C RID: 8540
		private static StandardTagType aq = null;

		// Token: 0x0400215D RID: 8541
		private static StandardTagType ar = null;

		// Token: 0x0400215E RID: 8542
		private static MarkedContentTagType @as = null;

		// Token: 0x0400215F RID: 8543
		private static StandardTagType at = null;
	}
}
