using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.Layout
{
	// Token: 0x020005D2 RID: 1490
	public class LayoutTextArea : RotatingPageElement, ru, rv
	{
		// Token: 0x06003AF6 RID: 15094 RVA: 0x001FA20C File Offset: 0x001F920C
		internal LayoutTextArea(LayoutTextArea A_0) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(32);
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

		// Token: 0x06003AF7 RID: 15095 RVA: 0x001FA36C File Offset: 0x001F936C
		internal LayoutTextArea(RecordBox A_0, string A_1) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(32);
			this.a = A_0.Font.GetTextLines(A_1.ToCharArray(), A_0.Width, A_0.Height, A_0.FontSize);
			this.b = A_0.Splittable;
			this.c = A_0.Align;
			this.d = A_0.VAlign;
			this.e = A_0.TextColor;
			this.i = A_0.TextOutlineColor;
			this.j = A_0.TextOutlineWidth;
			this.f = A_0.Underline;
			this.Angle = A_0.Angle;
			this.h = A_0.nw();
			this.a.Leading = A_0.Leading;
			this.a.AutoLeading = A_0.AutoLeading;
			this.a.CleanParagraphBreaks = A_0.CleanParagraphBreaks;
			this.a.ParagraphIndent = A_0.ParagraphIndent;
			this.a.ParagraphSpacing = A_0.ParagraphSpacing;
		}

		// Token: 0x06003AF8 RID: 15096 RVA: 0x001FA494 File Offset: 0x001F9494
		internal LayoutTextArea(RecordArea A_0, char[] A_1) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(32);
			this.a = A_0.Font.GetTextLines(A_1, A_0.Width, A_0.Height, A_0.FontSize);
			this.b = A_0.Splittable;
			this.c = A_0.Align;
			this.d = A_0.VAlign;
			this.e = A_0.TextColor;
			this.i = A_0.TextOutlineColor;
			this.j = A_0.TextOutlineWidth;
			this.f = A_0.Underline;
			this.Angle = A_0.Angle;
			this.h = A_0.nw();
			this.a.Leading = A_0.Leading;
			this.a.AutoLeading = A_0.AutoLeading;
			this.a.CleanParagraphBreaks = A_0.CleanParagraphBreaks;
			this.a.ParagraphIndent = A_0.ParagraphIndent;
			this.a.ParagraphSpacing = A_0.ParagraphSpacing;
		}

		// Token: 0x06003AF9 RID: 15097 RVA: 0x001FA5B7 File Offset: 0x001F95B7
		internal virtual void nr(char[] A_0)
		{
			this.a.SetText(A_0);
		}

		// Token: 0x06003AFA RID: 15098 RVA: 0x001FA5C8 File Offset: 0x001F95C8
		void rv.a(char[] A_0, bool A_1)
		{
			this.nr(A_0);
			if (A_1)
			{
				this.a.c(true);
			}
		}

		// Token: 0x06003AFB RID: 15099 RVA: 0x001FA5F8 File Offset: 0x001F95F8
		internal TextLineList a()
		{
			return this.a;
		}

		// Token: 0x06003AFC RID: 15100 RVA: 0x001FA610 File Offset: 0x001F9610
		internal override bool fe()
		{
			return this.b;
		}

		// Token: 0x06003AFD RID: 15101 RVA: 0x001FA628 File Offset: 0x001F9628
		internal override short fd()
		{
			return this.h;
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06003AFE RID: 15102 RVA: 0x001FA640 File Offset: 0x001F9640
		// (set) Token: 0x06003AFF RID: 15103 RVA: 0x001FA658 File Offset: 0x001F9658
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

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06003B00 RID: 15104 RVA: 0x001FA664 File Offset: 0x001F9664
		// (set) Token: 0x06003B01 RID: 15105 RVA: 0x001FA67C File Offset: 0x001F967C
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

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06003B02 RID: 15106 RVA: 0x001FA688 File Offset: 0x001F9688
		// (set) Token: 0x06003B03 RID: 15107 RVA: 0x001FA6A0 File Offset: 0x001F96A0
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

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06003B04 RID: 15108 RVA: 0x001FA6AC File Offset: 0x001F96AC
		// (set) Token: 0x06003B05 RID: 15109 RVA: 0x001FA6C4 File Offset: 0x001F96C4
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

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06003B06 RID: 15110 RVA: 0x001FA6D0 File Offset: 0x001F96D0
		// (set) Token: 0x06003B07 RID: 15111 RVA: 0x001FA6E8 File Offset: 0x001F96E8
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06003B08 RID: 15112 RVA: 0x001FA6F4 File Offset: 0x001F96F4
		// (set) Token: 0x06003B09 RID: 15113 RVA: 0x001FA70C File Offset: 0x001F970C
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

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06003B0A RID: 15114 RVA: 0x001FA718 File Offset: 0x001F9718
		// (set) Token: 0x06003B0B RID: 15115 RVA: 0x001FA730 File Offset: 0x001F9730
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

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06003B0C RID: 15116 RVA: 0x001FA73C File Offset: 0x001F973C
		// (set) Token: 0x06003B0D RID: 15117 RVA: 0x001FA75C File Offset: 0x001F975C
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

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06003B0E RID: 15118 RVA: 0x001FA7AC File Offset: 0x001F97AC
		// (set) Token: 0x06003B0F RID: 15119 RVA: 0x001FA7C9 File Offset: 0x001F97C9
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

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06003B10 RID: 15120 RVA: 0x001FA7DC File Offset: 0x001F97DC
		// (set) Token: 0x06003B11 RID: 15121 RVA: 0x001FA7F9 File Offset: 0x001F97F9
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

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06003B12 RID: 15122 RVA: 0x001FA80C File Offset: 0x001F980C
		// (set) Token: 0x06003B13 RID: 15123 RVA: 0x001FA829 File Offset: 0x001F9829
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

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06003B14 RID: 15124 RVA: 0x001FA83C File Offset: 0x001F983C
		// (set) Token: 0x06003B15 RID: 15125 RVA: 0x001FA859 File Offset: 0x001F9859
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

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06003B16 RID: 15126 RVA: 0x001FA86C File Offset: 0x001F986C
		// (set) Token: 0x06003B17 RID: 15127 RVA: 0x001FA889 File Offset: 0x001F9889
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06003B18 RID: 15128 RVA: 0x001FA89C File Offset: 0x001F989C
		// (set) Token: 0x06003B19 RID: 15129 RVA: 0x001FA8B9 File Offset: 0x001F98B9
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

		// Token: 0x06003B1A RID: 15130 RVA: 0x001FA8CC File Offset: 0x001F98CC
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

		// Token: 0x06003B1B RID: 15131 RVA: 0x001FAA28 File Offset: 0x001F9A28
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

		// Token: 0x06003B1C RID: 15132 RVA: 0x001FAC34 File Offset: 0x001F9C34
		internal override byte cb()
		{
			return 69;
		}

		// Token: 0x06003B1D RID: 15133 RVA: 0x001FAC48 File Offset: 0x001F9C48
		void ru.a(acm A_0)
		{
			float requiredHeight = this.a.GetRequiredHeight(0);
			if (requiredHeight > this.Height)
			{
				A_0.a(new x5(this.Y), new x5(this.Y + this.Height), new x5(requiredHeight - this.Height));
				this.a.Height = (this.Height = requiredHeight);
			}
		}

		// Token: 0x06003B1E RID: 15134 RVA: 0x001FACC0 File Offset: 0x001F9CC0
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

		// Token: 0x06003B1F RID: 15135 RVA: 0x001FAD81 File Offset: 0x001F9D81
		internal override void b9(x5 A_0)
		{
			base.a(x5.e(base.l(), A_0));
		}

		// Token: 0x06003B20 RID: 15136 RVA: 0x001FAD98 File Offset: 0x001F9D98
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (!this.b || x5.d(A_0, x5.a(this.a.Leading)))
			{
				result = al1.c;
			}
			else if (x5.c(A_0, x5.a(this.a.GetRequiredHeight(0))))
			{
				result = x5.a(this.a.GetRequiredHeight(0));
			}
			else
			{
				float height = this.a.Height;
				this.a.Height = x5.b(A_0);
				x5 x;
				if (GlobalSettings.UseLegacyTextHeightCalculations)
				{
					x = x5.a((double)((float)this.a.VisibleLineCount * this.a.Leading) + 0.001);
				}
				else
				{
					x = x5.a((double)((float)this.a.VisibleLineCount * this.a.Leading - this.a.Font.GetLineGap(this.a.FontSize)) + 0.001);
				}
				this.a.Height = height;
				result = x;
			}
			return result;
		}

		// Token: 0x06003B21 RID: 15137 RVA: 0x001FAECC File Offset: 0x001F9ECC
		internal override PageElement fb(x5 A_0)
		{
			this.a.Height = x5.b(A_0);
			PageElement result;
			if (this.a.VisibleLineCount < this.a().Count)
			{
				result = new am7(x5.c(), x5.e(x5.a((double)this.Height + 0.001), A_0), this);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003B22 RID: 15138 RVA: 0x001FAF3C File Offset: 0x001F9F3C
		internal override PageElement fc()
		{
			return new LayoutTextArea(this);
		}

		// Token: 0x04001BD5 RID: 7125
		private new TextLineList a;

		// Token: 0x04001BD6 RID: 7126
		private bool b;

		// Token: 0x04001BD7 RID: 7127
		private TextAlign c;

		// Token: 0x04001BD8 RID: 7128
		private new VAlign d = VAlign.Top;

		// Token: 0x04001BD9 RID: 7129
		private Color e;

		// Token: 0x04001BDA RID: 7130
		private bool f;

		// Token: 0x04001BDB RID: 7131
		private bool g;

		// Token: 0x04001BDC RID: 7132
		private short h;

		// Token: 0x04001BDD RID: 7133
		private Color i;

		// Token: 0x04001BDE RID: 7134
		private float j;
	}
}
