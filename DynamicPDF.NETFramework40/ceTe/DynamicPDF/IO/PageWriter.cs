using System;
using System.Text;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x020006DF RID: 1759
	public class PageWriter : OperatorWriter
	{
		// Token: 0x060043CD RID: 17357 RVA: 0x002314F4 File Offset: 0x002304F4
		internal PageWriter(Page A_0, PageResources A_1, DocumentWriter A_2, zh A_3, int A_4, int A_5) : base(A_2, A_3, A_0.Dimensions)
		{
			this.g = A_0;
			this.h = A_1;
			this.j = A_4;
			this.k = A_5;
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060043CE RID: 17358 RVA: 0x00231558 File Offset: 0x00230558
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.PageContents;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060043CF RID: 17359 RVA: 0x0023156C File Offset: 0x0023056C
		public int SectionPageNumber
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060043D0 RID: 17360 RVA: 0x00231584 File Offset: 0x00230584
		public int PageNumber
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060043D1 RID: 17361 RVA: 0x0023159C File Offset: 0x0023059C
		public Page Page
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060043D2 RID: 17362 RVA: 0x002315B4 File Offset: 0x002305B4
		public PageResources Resources
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060043D3 RID: 17363 RVA: 0x002315CC File Offset: 0x002305CC
		public PageAnnotationList Annotations
		{
			get
			{
				return this.i;
			}
		}

		// Token: 0x060043D4 RID: 17364 RVA: 0x002315E4 File Offset: 0x002305E4
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			if (base.t().o())
			{
				writer.WriteName(Resource.c);
				writer.WriteName(Resource.d);
			}
			writer.WriteName(Resource.e);
			writer.ai(base.t().s());
			writer.WriteDictionaryClose();
			writer.ac(base.t());
			writer.WriteEndObject();
			base.a(null);
		}

		// Token: 0x060043D5 RID: 17365 RVA: 0x00231670 File Offset: 0x00230670
		public void SetStrokeColorSpace(ColorSpace colorSpace)
		{
			if (base.q().StrokeColorSpace != colorSpace)
			{
				this.Write_CS(colorSpace);
			}
		}

		// Token: 0x060043D6 RID: 17366 RVA: 0x0023169C File Offset: 0x0023069C
		public void SetFillColorSpace(ColorSpace colorSpace)
		{
			if (base.q().FillColorSpace != colorSpace)
			{
				this.Write_cs_(colorSpace);
			}
		}

		// Token: 0x060043D7 RID: 17367 RVA: 0x002316C8 File Offset: 0x002306C8
		public override void Write_Do(Resource xObject)
		{
			br br = base.s().b(17);
			this.h.XObjects.Add(xObject, this);
			br.a(32);
			br.a(68);
			br.a(111);
			br.a(10);
		}

		// Token: 0x060043D8 RID: 17368 RVA: 0x0023171C File Offset: 0x0023071C
		public void Write_cs_(ColorSpace colorSpace)
		{
			colorSpace.DrawName(this);
			br br = base.s().b(4);
			br.a(32);
			br.a(99);
			br.a(115);
			br.a(10);
			base.q().FillColorSpace = colorSpace;
		}

		// Token: 0x060043D9 RID: 17369 RVA: 0x00231770 File Offset: 0x00230770
		public void Write_CS(ColorSpace colorSpace)
		{
			colorSpace.DrawName(this);
			br br = base.s().b(4);
			br.a(32);
			br.a(67);
			br.a(83);
			br.a(10);
			base.q().StrokeColorSpace = colorSpace;
		}

		// Token: 0x060043DA RID: 17370 RVA: 0x002317C4 File Offset: 0x002307C4
		public void Write_scn_(SpotColor tint)
		{
			br br = base.s().b(10);
			br.b(tint.Tint);
			br.a(32);
			br.a(115);
			br.a(99);
			br.a(110);
			br.a(10);
			base.q().FillColor = tint;
		}

		// Token: 0x060043DB RID: 17371 RVA: 0x00231828 File Offset: 0x00230828
		public void Write_scn_(Gradient pattern)
		{
			br br = base.s().b(18);
			this.h.Patterns.Add(pattern.GetResource(this), this);
			br.a(32);
			br.a(115);
			br.a(99);
			br.a(110);
			br.a(10);
			base.q().FillColor = pattern;
		}

		// Token: 0x060043DC RID: 17372 RVA: 0x00231898 File Offset: 0x00230898
		public void Write_SCN(SpotColor tint)
		{
			br br = base.s().b(10);
			br.b(tint.Tint);
			br.a(32);
			br.a(83);
			br.a(67);
			br.a(78);
			br.a(10);
			base.q().StrokeColor = tint;
		}

		// Token: 0x060043DD RID: 17373 RVA: 0x002318FC File Offset: 0x002308FC
		public void Write_SCN(Gradient pattern)
		{
			br br = base.s().b(18);
			this.h.Patterns.Add(pattern.GetResource(this), this);
			br.a(32);
			br.a(83);
			br.a(67);
			br.a(78);
			br.a(10);
			base.q().StrokeColor = pattern;
		}

		// Token: 0x060043DE RID: 17374 RVA: 0x0023196C File Offset: 0x0023096C
		public override void Write_Tf(Font font, float fontSize)
		{
			if (font is IFontSubsettable)
			{
				base.DocumentWriter.SetFontSubsetter((IFontSubsettable)font);
			}
			else
			{
				base.DocumentWriter.ClearFontSubsetter();
			}
			br br = base.s().b(27);
			this.h.Fonts.Add(font, this);
			br.a(32);
			br.c(fontSize);
			br.a(32);
			br.a(84);
			br.a(102);
			br.a(10);
			base.q().Font = font;
			base.q().FontSize = fontSize;
		}

		// Token: 0x060043DF RID: 17375 RVA: 0x00231A20 File Offset: 0x00230A20
		public void Write_gs(Resource extGState)
		{
			br br = base.s().b(18);
			this.h.ExtGStates.Add(extGState, this);
			br.a(32);
			br.a(103);
			br.a(115);
			br.a(10);
		}

		// Token: 0x060043E0 RID: 17376 RVA: 0x00231A74 File Offset: 0x00230A74
		public override void Write_m_(float x, float y)
		{
			if (this.l != null)
			{
				this.l.a(this);
				this.l.b(x, y);
			}
			base.Write_m_(x, y);
		}

		// Token: 0x060043E1 RID: 17377 RVA: 0x00231AB8 File Offset: 0x00230AB8
		public override void Write_l_(float x, float y)
		{
			if (this.l != null)
			{
				this.l.a(this);
				this.l.b(x, y);
			}
			base.Write_l_(x, y);
		}

		// Token: 0x060043E2 RID: 17378 RVA: 0x00231AFC File Offset: 0x00230AFC
		public override void Write_c(float x1, float y1, float x2, float y2, float x3, float y3)
		{
			if (this.l != null)
			{
				this.l.a(this);
				this.l.a(x1, y1, x2, y2, x3, y3);
			}
			base.Write_c(x1, y1, x2, y2, x3, y3);
		}

		// Token: 0x060043E3 RID: 17379 RVA: 0x00231B4C File Offset: 0x00230B4C
		public override void Write_v(float x2, float y2, float x3, float y3)
		{
			if (this.l != null)
			{
				this.l.a(this);
				this.l.b(x3, y3);
			}
			base.Write_v(x2, y2, x3, y3);
		}

		// Token: 0x060043E4 RID: 17380 RVA: 0x00231B94 File Offset: 0x00230B94
		public override void Write_y(float x1, float y1, float x3, float y3)
		{
			if (this.l != null)
			{
				this.l.a(this);
				this.l.b(x3, y3);
			}
			base.Write_y(x1, y1, x3, y3);
		}

		// Token: 0x060043E5 RID: 17381 RVA: 0x00231BDC File Offset: 0x00230BDC
		public override void Write_re(float x, float y, float width, float height)
		{
			if (this.l != null)
			{
				this.l.a(this);
				this.l.b(x, y);
				this.l.b(x + width, y + height);
				this.l.c(x, y + height);
			}
			base.Write_re(x, y, width, height);
		}

		// Token: 0x060043E6 RID: 17382 RVA: 0x00231C44 File Offset: 0x00230C44
		public override void Write_s_()
		{
			if (this.l != null)
			{
				this.l.e();
			}
			base.Write_s_();
		}

		// Token: 0x060043E7 RID: 17383 RVA: 0x00231C74 File Offset: 0x00230C74
		public override void Write_S()
		{
			if (this.l != null)
			{
				this.l.e();
			}
			base.Write_S();
		}

		// Token: 0x060043E8 RID: 17384 RVA: 0x00231CA4 File Offset: 0x00230CA4
		public override void Write_fx()
		{
			if (this.l != null)
			{
				this.l.d();
			}
			base.Write_fx();
		}

		// Token: 0x060043E9 RID: 17385 RVA: 0x00231CD4 File Offset: 0x00230CD4
		public override void Write_f()
		{
			if (this.l != null)
			{
				this.l.d();
			}
			base.Write_f();
		}

		// Token: 0x060043EA RID: 17386 RVA: 0x00231D04 File Offset: 0x00230D04
		public override void Write_BI()
		{
			if (this.l != null)
			{
				this.l.a(this);
			}
			base.Write_BI();
		}

		// Token: 0x060043EB RID: 17387 RVA: 0x00231D38 File Offset: 0x00230D38
		public override void Write_EI()
		{
			if (this.l != null)
			{
				this.l.d();
			}
			base.Write_EI();
		}

		// Token: 0x060043EC RID: 17388 RVA: 0x00231D68 File Offset: 0x00230D68
		public override void Write_B()
		{
			if (this.l != null)
			{
				this.l.f();
			}
			base.Write_B();
		}

		// Token: 0x060043ED RID: 17389 RVA: 0x00231D98 File Offset: 0x00230D98
		public override void Write_b_()
		{
			if (this.l != null)
			{
				this.l.f();
			}
			base.Write_b_();
		}

		// Token: 0x060043EE RID: 17390 RVA: 0x00231DC8 File Offset: 0x00230DC8
		public override void Write_Bx()
		{
			if (this.l != null)
			{
				this.l.f();
			}
			base.Write_Bx();
		}

		// Token: 0x060043EF RID: 17391 RVA: 0x00231DF8 File Offset: 0x00230DF8
		public override void Write_bx_()
		{
			if (this.l != null)
			{
				this.l.f();
			}
			base.Write_bx_();
		}

		// Token: 0x060043F0 RID: 17392 RVA: 0x00231E28 File Offset: 0x00230E28
		public override void Write_G(Grayscale color)
		{
			if (this.l != null)
			{
				this.l = this.l.c();
			}
			base.Write_G(color);
		}

		// Token: 0x060043F1 RID: 17393 RVA: 0x00231E5C File Offset: 0x00230E5C
		public override void Write_g_(Grayscale color)
		{
			if (this.l != null)
			{
				this.l = this.l.b();
			}
			base.Write_g_(color);
		}

		// Token: 0x060043F2 RID: 17394 RVA: 0x00231E90 File Offset: 0x00230E90
		public override void Write_RG(RgbColor color)
		{
			if (this.l != null)
			{
				this.l = this.l.c();
			}
			base.Write_RG(color);
		}

		// Token: 0x060043F3 RID: 17395 RVA: 0x00231EC4 File Offset: 0x00230EC4
		public override void Write_rg_(RgbColor color)
		{
			if (this.l != null)
			{
				this.l = this.l.b();
			}
			base.Write_rg_(color);
		}

		// Token: 0x060043F4 RID: 17396 RVA: 0x00231EF8 File Offset: 0x00230EF8
		public override void Write_K(CmykColor color)
		{
			if (this.l != null)
			{
				this.l = this.l.c();
			}
			base.Write_K(color);
		}

		// Token: 0x060043F5 RID: 17397 RVA: 0x00231F2C File Offset: 0x00230F2C
		public override void Write_k_(CmykColor color)
		{
			if (this.l != null)
			{
				this.l = this.l.b();
			}
			base.Write_k_(color);
		}

		// Token: 0x060043F6 RID: 17398 RVA: 0x00231F60 File Offset: 0x00230F60
		internal new void a(float A_0, float A_1, float A_2, float A_3, int A_4, int A_5, byte[] A_6)
		{
			if (this.l != null)
			{
				this.l.b(A_0, A_1);
				this.l.b(A_0 + A_2, A_1 + A_3);
			}
			base.Write_q_();
			base.Write_cm(A_2, 0f, 0f, A_3, base.Dimensions.GetPdfX(A_0), base.Dimensions.GetPdfY(A_1));
			this.Write_BI();
			base.WriteName(87);
			base.WriteSpace();
			base.Write(A_4);
			base.WriteName(72);
			base.WriteSpace();
			base.Write(A_5);
			base.Write(PageWriter.f);
			base.WriteSpace();
			base.Write(PageWriter.e);
			base.Write(PageWriter.d);
			base.WriteNewLine();
			base.Write_ID();
			base.Write(A_6);
			base.WriteNewLine();
			this.Write_EI();
			base.Write_Q();
		}

		// Token: 0x060043F7 RID: 17399 RVA: 0x00232064 File Offset: 0x00231064
		internal new cj e()
		{
			return this.l;
		}

		// Token: 0x060043F8 RID: 17400 RVA: 0x0023207C File Offset: 0x0023107C
		internal new void a(cj A_0)
		{
			this.l = A_0;
		}

		// Token: 0x060043F9 RID: 17401 RVA: 0x00232086 File Offset: 0x00231086
		internal new void f()
		{
			base.u();
			this.c();
			base.y();
			base.v();
		}

		// Token: 0x060043FA RID: 17402 RVA: 0x002320A8 File Offset: 0x002310A8
		internal new void i()
		{
			bool flag = base.Document.Tag != null && this.Page.ha();
			string text = aae.a(base.Document.h());
			float width = PageWriter.b + Font.Helvetica.GetTextWidth(text, 10f);
			base.SetGraphicsMode();
			if (flag)
			{
				Tag.Artifact.e(this, null);
			}
			base.SetFillColor(new CmykColor(0.25f, 0.1424f, 0f, 0.0926f));
			base.SetLineWidth(0f);
			this.Write_re(12f - base.Dimensions.LeftMargin, 12f - base.Dimensions.TopMargin, width, 10.25f);
			this.Write_f();
			if (flag)
			{
				Tag.a(this);
			}
			base.SetTextMode();
			StructureElement structureElement = null;
			if (flag)
			{
				structureElement = new StructureElement(new NamedTagType("Evaluation_Info", TagType.Paragraph));
				if (this.k() != null)
				{
					structureElement.Parent = this.k();
				}
				structureElement.e(this, null);
			}
			base.SetFont(Font.Helvetica, 10f);
			base.SetFillColor(new Grayscale(0.25f));
			base.Write_Tm(1f, 0f, 0f, 1f, 12f - base.Dimensions.LeftMargin, 20f - base.Dimensions.TopMargin);
			base.Write_Tj_(PageWriter.a, false);
			base.Write_Tj_(text.ToCharArray(), false);
			string str = aae.b(base.Document.h());
			string url = "http://www.DynamicPDF.com/dplic/?d=" + str;
			Link link = new Link(12f - base.Dimensions.LeftMargin, 12f - base.Dimensions.TopMargin, width, 10f, new UrlAction(url));
			if (flag)
			{
				link.Tag = structureElement;
				Tag.a(this);
			}
			link.a(this);
			if (flag)
			{
				Tag.Artifact.e(this, null);
			}
			base.Write_Tm(1f, 0f, 0f, 1f, 12f - base.Dimensions.LeftMargin, base.Dimensions.Body.Bottom - 12f);
			base.Write_Tj_(Document.a(), false);
			if (flag)
			{
				Tag.a(this);
			}
			this.a();
		}

		// Token: 0x060043FB RID: 17403 RVA: 0x00232350 File Offset: 0x00231350
		private new void c()
		{
			bool flag = base.Document.Tag != null && this.Page.ha();
			float num = base.Dimensions.Width * 0.6f / 1000f;
			float num2 = base.Dimensions.Height * 0.6f / 954f;
			float num3 = (num > num2) ? num2 : num;
			float xOffset = (base.Dimensions.Width - num3 * 1000f) / 2f + base.Dimensions.Edge.Left;
			float yOffset = (base.Dimensions.Height - num3 * 954f) / 2f + base.Dimensions.Edge.Bottom - base.Dimensions.Height;
			base.SetGraphicsMode();
			if (flag)
			{
				base.WriteName(PageWriter.c);
				base.WriteSpace();
				base.ab();
			}
			base.Write_q_(false);
			base.Write_cm(xOffset, yOffset);
			base.Write_cm(num3, 0f, 0f, num3);
			base.Write(Encoding.ASCII.GetBytes("4 w\n"));
			this.Write_Do(zi.a());
			base.Write_Q(false);
			if (base.Document.Tag != null && flag)
			{
				base.z();
			}
		}

		// Token: 0x060043FC RID: 17404 RVA: 0x002324BC File Offset: 0x002314BC
		private new int a(int A_0, byte[] A_1, int A_2)
		{
			if (A_0 < 0)
			{
				A_0 = -A_0;
				A_1[A_2++] = 45;
			}
			int i;
			if (A_0 < 10)
			{
				i = 1;
			}
			else if (A_0 < 100)
			{
				i = 10;
			}
			else if (A_0 < 1000)
			{
				i = 100;
			}
			else if (A_0 < 10000)
			{
				i = 1000;
			}
			else if (A_0 < 1000000)
			{
				i = 100000;
			}
			else
			{
				i = 1000000000;
			}
			bool flag = false;
			while (i >= 1)
			{
				int num = (int)((byte)(A_0 / i));
				if (flag || num > 0)
				{
					A_1[A_2++] = (byte)(num + 48);
					flag = true;
				}
				A_0 -= num * i;
				i /= 10;
			}
			if (!flag)
			{
				A_1[A_2++] = 48;
			}
			return A_2;
		}

		// Token: 0x060043FD RID: 17405 RVA: 0x002325BC File Offset: 0x002315BC
		internal new int b(float A_0, byte[] A_1, int A_2)
		{
			int i = (int)(A_0 * 1000f);
			bool flag = false;
			if (i < 0)
			{
				i = -i;
				A_1[A_2++] = 45;
			}
			int j;
			if (i < 10)
			{
				j = 1;
			}
			else if (i < 100)
			{
				j = 10;
			}
			else if (i < 1000)
			{
				j = 100;
			}
			else if (i < 10000)
			{
				j = 1000;
			}
			else if (i < 1000000)
			{
				j = 100000;
			}
			else
			{
				if (i >= 100000000)
				{
					throw new Exception("Maximum Float Value Exceeded.");
				}
				j = 10000000;
			}
			while (j >= 1000)
			{
				int num = i / j;
				if (flag || num > 0)
				{
					A_1[A_2++] = (byte)(num + 48);
					flag = true;
				}
				i -= num * j;
				j /= 10;
			}
			if (i > 0)
			{
				A_1[A_2++] = 46;
			}
			while (i > 0)
			{
				int num = i / j;
				A_1[A_2++] = (byte)(num + 48);
				flag = true;
				i -= num * j;
				j /= 10;
			}
			if (!flag)
			{
				A_1[A_2++] = 48;
			}
			return A_2;
		}

		// Token: 0x060043FE RID: 17406 RVA: 0x00232728 File Offset: 0x00231728
		private new int a(float A_0, byte[] A_1, int A_2)
		{
			int i = (int)(A_0 * 100f);
			bool flag = false;
			if (i < 0)
			{
				i = -i;
				A_1[A_2++] = 45;
			}
			int j;
			if (i < 10)
			{
				j = 1;
			}
			else if (i < 100)
			{
				j = 10;
			}
			else if (i < 1000)
			{
				j = 100;
			}
			else if (i < 10000)
			{
				j = 1000;
			}
			else if (i < 1000000)
			{
				j = 100000;
			}
			else
			{
				if (i >= 100000000)
				{
					throw new Exception("Maximum Float Value Exceeded.");
				}
				j = 10000000;
			}
			while (j >= 100)
			{
				int num = i / j;
				if (flag || num > 0)
				{
					A_1[A_2++] = (byte)(num + 48);
					flag = true;
				}
				i -= num * j;
				j /= 10;
			}
			if (i > 0)
			{
				A_1[A_2++] = 46;
			}
			while (i > 0)
			{
				int num = i / j;
				A_1[A_2++] = (byte)(num + 48);
				flag = true;
				i -= num * j;
				j /= 10;
			}
			if (!flag)
			{
				A_1[A_2++] = 48;
			}
			return A_2;
		}

		// Token: 0x060043FF RID: 17407 RVA: 0x00232890 File Offset: 0x00231890
		private new void a()
		{
			bool flag = base.Document.Tag != null && this.Page.ha();
			float num = base.Dimensions.Width * 0.6f / 1000f;
			float num2 = base.Dimensions.Height * 0.6f / 954f;
			float num3 = (num > num2) ? num2 : num;
			float xOffset = (base.Dimensions.Width - num3 * 1000f) / 2f + base.Dimensions.Edge.Left;
			float yOffset = (base.Dimensions.Height - num3 * 954f) / 2f + base.Dimensions.Edge.Bottom - base.Dimensions.Height;
			base.SetGraphicsMode();
			if (flag)
			{
				Tag.Artifact.e(this, null);
			}
			base.Write_q_(false);
			base.Write_cm(xOffset, yOffset);
			base.Write_cm(num3, 0f, 0f, num3);
			base.Write(Encoding.ASCII.GetBytes(".8 w\n"));
			this.Write_Do(zi.a());
			base.Write_Q(false);
			if (flag)
			{
				Tag.a(this);
			}
		}

		// Token: 0x06004400 RID: 17408 RVA: 0x002329D8 File Offset: 0x002319D8
		internal int j()
		{
			return this.m;
		}

		// Token: 0x06004401 RID: 17409 RVA: 0x002329F0 File Offset: 0x002319F0
		internal new void a(int A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06004402 RID: 17410 RVA: 0x002329FC File Offset: 0x002319FC
		internal StructureElement k()
		{
			return this.o;
		}

		// Token: 0x06004403 RID: 17411 RVA: 0x00232A14 File Offset: 0x00231A14
		internal new void a(StructureElement A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06004404 RID: 17412 RVA: 0x00232A20 File Offset: 0x00231A20
		internal bool l()
		{
			return this.n;
		}

		// Token: 0x06004405 RID: 17413 RVA: 0x00232A38 File Offset: 0x00231A38
		internal new void a(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06004406 RID: 17414 RVA: 0x00232A44 File Offset: 0x00231A44
		internal afe m()
		{
			return this.p;
		}

		// Token: 0x06004407 RID: 17415 RVA: 0x00232A5C File Offset: 0x00231A5C
		internal new void a(afe A_0)
		{
			this.p = A_0;
		}

		// Token: 0x040025D8 RID: 9688
		private new static readonly char[] a = "Evaluating unlicensed DynamicPDF feature. Click here for details. ".ToCharArray();

		// Token: 0x040025D9 RID: 9689
		private new static readonly float b = Font.Helvetica.GetTextWidth(PageWriter.a, 10f);

		// Token: 0x040025DA RID: 9690
		private new static byte[] c = new byte[]
		{
			65,
			114,
			116,
			105,
			102,
			97,
			99,
			116
		};

		// Token: 0x040025DB RID: 9691
		private new static byte[] d = new byte[]
		{
			47,
			66,
			80,
			67,
			32,
			49
		};

		// Token: 0x040025DC RID: 9692
		private new static byte[] e = new byte[]
		{
			116,
			114,
			117,
			101
		};

		// Token: 0x040025DD RID: 9693
		private new static byte[] f = new byte[]
		{
			47,
			73,
			77
		};

		// Token: 0x040025DE RID: 9694
		private new Page g;

		// Token: 0x040025DF RID: 9695
		private new PageResources h;

		// Token: 0x040025E0 RID: 9696
		private new PageAnnotationList i = new PageAnnotationList();

		// Token: 0x040025E1 RID: 9697
		private int j;

		// Token: 0x040025E2 RID: 9698
		private int k;

		// Token: 0x040025E3 RID: 9699
		private cj l = null;

		// Token: 0x040025E4 RID: 9700
		private int m = -1;

		// Token: 0x040025E5 RID: 9701
		private bool n = false;

		// Token: 0x040025E6 RID: 9702
		private StructureElement o = null;

		// Token: 0x040025E7 RID: 9703
		private afe p;
	}
}
