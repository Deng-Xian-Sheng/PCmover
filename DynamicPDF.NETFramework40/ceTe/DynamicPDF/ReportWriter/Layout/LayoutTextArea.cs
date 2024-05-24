using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Layout
{
	// Token: 0x02000874 RID: 2164
	public class LayoutTextArea : RotatingPageElement, ru, rv
	{
		// Token: 0x060057DC RID: 22492 RVA: 0x00331720 File Offset: 0x00330720
		internal LayoutTextArea(LayoutTextArea A_0) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(33);
			this.a = A_0.a.Font.GetTextLines(A_0.a.GetText().ToCharArray(), A_0.a.Width, A_0.a.Height, A_0.a.FontSize);
			this.b = A_0.b;
			this.c = A_0.c;
			this.d = A_0.d;
			this.e = A_0.e;
			this.i = A_0.i;
			this.j = A_0.j;
			this.f = A_0.f;
			this.Angle = A_0.Angle;
			this.h = A_0.h;
			this.a.Leading = A_0.a.Leading;
			this.a.AutoLeading = A_0.a.AutoLeading;
			this.a.CleanParagraphBreaks = A_0.a.CleanParagraphBreaks;
			this.a.ParagraphIndent = A_0.a.ParagraphIndent;
			this.a.ParagraphSpacing = A_0.a.ParagraphSpacing;
		}

		// Token: 0x060057DD RID: 22493 RVA: 0x00331880 File Offset: 0x00330880
		internal LayoutTextArea(RecordBox A_0, string A_1) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(33);
			this.a = A_0.Font.GetTextLines(A_1.ToCharArray(), A_0.Width, A_0.Height, A_0.FontSize);
			this.b = A_0.Splittable;
			this.c = A_0.Align;
			this.d = A_0.VAlign;
			this.e = A_0.TextColor;
			this.i = A_0.TextOutlineColor;
			this.j = A_0.TextOutlineWidth;
			this.f = A_0.Underline;
			this.Angle = A_0.Angle;
			this.h = A_0.gk();
			this.a.Leading = A_0.Leading;
			this.a.AutoLeading = A_0.AutoLeading;
			this.a.CleanParagraphBreaks = A_0.CleanParagraphBreaks;
			this.a.ParagraphIndent = A_0.ParagraphIndent;
			this.a.ParagraphSpacing = A_0.ParagraphSpacing;
		}

		// Token: 0x060057DE RID: 22494 RVA: 0x003319A8 File Offset: 0x003309A8
		internal LayoutTextArea(RecordArea A_0, char[] A_1) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(33);
			this.a = A_0.Font.GetTextLines(A_1, A_0.Width, A_0.Height, A_0.FontSize);
			this.b = A_0.Splittable;
			this.c = A_0.Align;
			this.d = A_0.VAlign;
			this.e = A_0.TextColor;
			this.i = A_0.TextOutlineColor;
			this.j = A_0.TextOutlineWidth;
			this.f = A_0.Underline;
			this.Angle = A_0.Angle;
			this.h = A_0.gk();
			this.a.Leading = A_0.Leading;
			this.a.AutoLeading = A_0.AutoLeading;
			this.a.CleanParagraphBreaks = A_0.CleanParagraphBreaks;
			this.a.ParagraphIndent = A_0.ParagraphIndent;
			this.a.ParagraphSpacing = A_0.ParagraphSpacing;
		}

		// Token: 0x060057DF RID: 22495 RVA: 0x00331ACC File Offset: 0x00330ACC
		void rv.a(char[] A_0, bool A_1)
		{
			this.a.SetText(A_0);
			if (A_1)
			{
				this.a.c(true);
			}
		}

		// Token: 0x060057E0 RID: 22496 RVA: 0x00331B00 File Offset: 0x00330B00
		internal TextLineList a()
		{
			return this.a;
		}

		// Token: 0x060057E1 RID: 22497 RVA: 0x00331B18 File Offset: 0x00330B18
		internal override bool fe()
		{
			return this.b;
		}

		// Token: 0x060057E2 RID: 22498 RVA: 0x00331B30 File Offset: 0x00330B30
		internal override short fd()
		{
			return this.h;
		}

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x060057E3 RID: 22499 RVA: 0x00331B48 File Offset: 0x00330B48
		// (set) Token: 0x060057E4 RID: 22500 RVA: 0x00331B60 File Offset: 0x00330B60
		public TextAlign Align
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

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x060057E5 RID: 22501 RVA: 0x00331B6C File Offset: 0x00330B6C
		// (set) Token: 0x060057E6 RID: 22502 RVA: 0x00331B84 File Offset: 0x00330B84
		public VAlign VAlign
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

		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x060057E7 RID: 22503 RVA: 0x00331B90 File Offset: 0x00330B90
		// (set) Token: 0x060057E8 RID: 22504 RVA: 0x00331BA8 File Offset: 0x00330BA8
		public bool Underline
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

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x060057E9 RID: 22505 RVA: 0x00331BB4 File Offset: 0x00330BB4
		// (set) Token: 0x060057EA RID: 22506 RVA: 0x00331BCC File Offset: 0x00330BCC
		public bool RightToLeft
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

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x060057EB RID: 22507 RVA: 0x00331BD8 File Offset: 0x00330BD8
		// (set) Token: 0x060057EC RID: 22508 RVA: 0x00331BF0 File Offset: 0x00330BF0
		public Color TextColor
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

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x060057ED RID: 22509 RVA: 0x00331BFC File Offset: 0x00330BFC
		// (set) Token: 0x060057EE RID: 22510 RVA: 0x00331C14 File Offset: 0x00330C14
		public Color TextOutlineColor
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

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x060057EF RID: 22511 RVA: 0x00331C20 File Offset: 0x00330C20
		// (set) Token: 0x060057F0 RID: 22512 RVA: 0x00331C38 File Offset: 0x00330C38
		public float TextOutlineWidth
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

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x060057F1 RID: 22513 RVA: 0x00331C44 File Offset: 0x00330C44
		// (set) Token: 0x060057F2 RID: 22514 RVA: 0x00331C64 File Offset: 0x00330C64
		public Font Font
		{
			get
			{
				return this.a.Font;
			}
			set
			{
				this.a.Font = value;
				if (value is OpenTypeFont && ((OpenTypeFont)value).UseCharacterShaping)
				{
					this.a = value.a(this.a);
				}
			}
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x060057F3 RID: 22515 RVA: 0x00331CB4 File Offset: 0x00330CB4
		// (set) Token: 0x060057F4 RID: 22516 RVA: 0x00331CD1 File Offset: 0x00330CD1
		public float FontSize
		{
			get
			{
				return this.a.FontSize;
			}
			set
			{
				this.a.FontSize = value;
			}
		}

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x060057F5 RID: 22517 RVA: 0x00331CE4 File Offset: 0x00330CE4
		// (set) Token: 0x060057F6 RID: 22518 RVA: 0x00331D01 File Offset: 0x00330D01
		public float Leading
		{
			get
			{
				return this.a.Leading;
			}
			set
			{
				this.a.Leading = value;
			}
		}

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x060057F7 RID: 22519 RVA: 0x00331D14 File Offset: 0x00330D14
		// (set) Token: 0x060057F8 RID: 22520 RVA: 0x00331D31 File Offset: 0x00330D31
		public bool AutoLeading
		{
			get
			{
				return this.a.AutoLeading;
			}
			set
			{
				this.a.AutoLeading = value;
			}
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x060057F9 RID: 22521 RVA: 0x00331D44 File Offset: 0x00330D44
		// (set) Token: 0x060057FA RID: 22522 RVA: 0x00331D61 File Offset: 0x00330D61
		public float ParagraphSpacing
		{
			get
			{
				return this.a.ParagraphSpacing;
			}
			set
			{
				this.a.ParagraphSpacing = value;
			}
		}

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x060057FB RID: 22523 RVA: 0x00331D74 File Offset: 0x00330D74
		// (set) Token: 0x060057FC RID: 22524 RVA: 0x00331D91 File Offset: 0x00330D91
		public float ParagraphIndent
		{
			get
			{
				return this.a.ParagraphIndent;
			}
			set
			{
				this.a.ParagraphIndent = value;
			}
		}

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x060057FD RID: 22525 RVA: 0x00331DA4 File Offset: 0x00330DA4
		// (set) Token: 0x060057FE RID: 22526 RVA: 0x00331DC1 File Offset: 0x00330DC1
		public bool CleanParagraphBreaks
		{
			get
			{
				return this.a.CleanParagraphBreaks;
			}
			set
			{
				this.a.CleanParagraphBreaks = value;
			}
		}

		// Token: 0x060057FF RID: 22527 RVA: 0x00331DD4 File Offset: 0x00330DD4
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				writer.SetTextMode();
				this.a.g();
				this.a(writer);
			}
			else
			{
				switch (this.d)
				{
				case VAlign.Top:
					this.a.ja(writer, base.X, base.Y, this.c, this.e, this.i, this.j, this.f, this.g, false);
					break;
				case VAlign.Center:
				{
					float a_ = base.Y + base.Height / 2f - this.a.GetTextHeight() / 2f;
					this.a.ja(writer, base.X, a_, this.c, this.e, this.i, this.j, this.f, this.g, false);
					break;
				}
				case VAlign.Bottom:
				{
					float a_2 = base.Y + base.Height - this.a.GetTextHeight();
					this.a.ja(writer, base.X, a_2, this.c, this.e, this.i, this.j, this.f, this.g, false);
					break;
				}
				}
			}
		}

		// Token: 0x06005800 RID: 22528 RVA: 0x00331F30 File Offset: 0x00330F30
		private void a(PageWriter A_0)
		{
			AttributeTypeList a_ = null;
			AttributeClassList a_2 = null;
			StructureElement structureElement = null;
			if (this.a.l())
			{
				structureElement = new StructureElement(TagType.Paragraph, true);
				AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
				attributeObject.a(A_0, this, null);
				structureElement.AttributeLists.Add(attributeObject);
				if (this.f)
				{
					a_ = structureElement.s();
				}
				structureElement.Order = this.TagOrder;
				if (A_0.k() != null)
				{
					structureElement.Parent = A_0.k();
				}
			}
			else
			{
				new StructureElement(TagType.Paragraph, true)
				{
					Order = this.TagOrder
				}.e(A_0, this);
			}
			switch (this.d)
			{
			case VAlign.Top:
				this.a.jc(A_0, base.X, base.Y, this.c, this.e, this.i, this.j, this.f, this.g, false, structureElement, a_, a_2);
				break;
			case VAlign.Center:
			{
				float a_3 = base.Y + base.Height / 2f - this.a.GetTextHeight() / 2f;
				this.a.jc(A_0, base.X, a_3, this.c, this.e, this.i, this.j, this.f, this.g, false, structureElement, a_, a_2);
				break;
			}
			case VAlign.Bottom:
			{
				float a_4 = base.Y + base.Height - this.a.GetTextHeight();
				this.a.jc(A_0, base.X, a_4, this.c, this.e, this.i, this.j, this.f, this.g, false, structureElement, a_, a_2);
				break;
			}
			}
			if (!this.a.l() && !this.f)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06005801 RID: 22529 RVA: 0x0033213C File Offset: 0x0033113C
		internal override byte cb()
		{
			return 69;
		}

		// Token: 0x06005802 RID: 22530 RVA: 0x00332150 File Offset: 0x00331150
		void ru.a(acm A_0)
		{
			float requiredHeight = this.a.GetRequiredHeight(0);
			if (requiredHeight > this.Height)
			{
				A_0.a(new x5(this.Y), new x5(this.Y + this.Height), new x5(requiredHeight - this.Height));
				this.a.Height = (this.Height = requiredHeight);
			}
		}

		// Token: 0x06005803 RID: 22531 RVA: 0x003321C8 File Offset: 0x003311C8
		internal override void b6(acw A_0)
		{
			if (!this.b || this.a.VisibleLineCount == 1)
			{
				base.b6(A_0);
			}
			else
			{
				int num = this.a.j();
				if (this.a.VisibleLineCount == num)
				{
					base.b6(A_0);
				}
				else
				{
					x5 a_ = x5.a(this.a.GetTextHeight(num) + this.Y);
					int lineCount = this.a.k();
					x5 a_2 = x5.a(this.a.GetTextHeight(lineCount) + this.Y);
					A_0.a(this.b7(), a_, a_2);
				}
			}
		}

		// Token: 0x06005804 RID: 22532 RVA: 0x00332289 File Offset: 0x00331289
		internal override void b9(x5 A_0)
		{
			base.a(x5.e(base.l(), A_0));
		}

		// Token: 0x06005805 RID: 22533 RVA: 0x003322A0 File Offset: 0x003312A0
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (!this.b || x5.d(A_0, x5.a(this.a.Leading)))
			{
				result = w0.c;
			}
			else if (x5.c(A_0, x5.a((float)this.a.Count * this.a.Leading)))
			{
				result = x5.a((double)((float)this.a.Count * this.a.Leading) + 0.001);
			}
			else
			{
				float height = this.a.Height;
				this.a.Height = x5.b(A_0);
				x5 x = x5.a((double)((float)this.a.VisibleLineCount * this.a.Leading) + 0.001);
				this.a.Height = height;
				result = x;
			}
			return result;
		}

		// Token: 0x06005806 RID: 22534 RVA: 0x0033239C File Offset: 0x0033139C
		internal override PageElement fb(x5 A_0)
		{
			this.a.Height = x5.b(A_0);
			PageElement result;
			if (this.a.VisibleLineCount < this.a().Count)
			{
				result = new xy(x5.c(), x5.e(x5.a((double)this.Height + 0.001), A_0), this);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005807 RID: 22535 RVA: 0x0033240C File Offset: 0x0033140C
		internal override PageElement fc()
		{
			return new LayoutTextArea(this);
		}

		// Token: 0x04002EB0 RID: 11952
		private new TextLineList a;

		// Token: 0x04002EB1 RID: 11953
		private bool b;

		// Token: 0x04002EB2 RID: 11954
		private TextAlign c;

		// Token: 0x04002EB3 RID: 11955
		private new VAlign d = VAlign.Top;

		// Token: 0x04002EB4 RID: 11956
		private Color e;

		// Token: 0x04002EB5 RID: 11957
		private bool f;

		// Token: 0x04002EB6 RID: 11958
		private bool g;

		// Token: 0x04002EB7 RID: 11959
		private short h;

		// Token: 0x04002EB8 RID: 11960
		private Color i;

		// Token: 0x04002EB9 RID: 11961
		private float j;
	}
}
