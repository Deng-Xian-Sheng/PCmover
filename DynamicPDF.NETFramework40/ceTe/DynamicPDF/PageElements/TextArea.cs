using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000743 RID: 1859
	public class TextArea : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06004B5A RID: 19290 RVA: 0x002643E0 File Offset: 0x002633E0
		public TextArea(string text, float x, float y, float width, float height) : this(text, x, y, width, height, TextArea.m, 12f, TextAlign.Left, TextArea.n)
		{
		}

		// Token: 0x06004B5B RID: 19291 RVA: 0x00264410 File Offset: 0x00263410
		public TextArea(string text, float x, float y, float width, float height, Font font) : this(text, x, y, width, height, font, 12f, TextAlign.Left, TextArea.n)
		{
		}

		// Token: 0x06004B5C RID: 19292 RVA: 0x0026443C File Offset: 0x0026343C
		public TextArea(string text, float x, float y, float width, float height, Font font, float fontSize) : this(text, x, y, width, height, font, fontSize, TextAlign.Left, TextArea.n)
		{
		}

		// Token: 0x06004B5D RID: 19293 RVA: 0x00264464 File Offset: 0x00263464
		public TextArea(string text, float x, float y, float width, float height, Font font, float fontSize, TextAlign align) : this(text, x, y, width, height, font, fontSize, align, TextArea.n)
		{
		}

		// Token: 0x06004B5E RID: 19294 RVA: 0x0026448C File Offset: 0x0026348C
		public TextArea(string text, float x, float y, float width, float height, Font font, float fontSize, Color textColor) : this(text, x, y, width, height, font, fontSize, TextAlign.Left, textColor)
		{
		}

		// Token: 0x06004B5F RID: 19295 RVA: 0x002644B0 File Offset: 0x002634B0
		public TextArea(string text, float x, float y, float width, float height, Font font, float fontSize, TextAlign align, Color textColor)
		{
			this.d = VAlign.Top;
			this.e = false;
			this.h = 1f;
			this.i = false;
			this.k = false;
			this.l = false;
			base..ctor(x, y, height);
			this.j = font.GetTextLines(text.ToCharArray(), width, height, fontSize);
			this.c = align;
			this.TextColor = textColor;
		}

		// Token: 0x06004B60 RID: 19296 RVA: 0x00264524 File Offset: 0x00263524
		internal TextArea(TextArea A_0, float A_1, float A_2, float A_3, TextLineList A_4)
		{
			this.d = VAlign.Top;
			this.e = false;
			this.h = 1f;
			this.i = false;
			this.k = false;
			this.l = false;
			base..ctor(A_1, A_2, A_3);
			this.j = A_4;
			this.c = A_0.c;
			this.f = A_0.f;
			this.g = A_0.g;
			this.h = A_0.h;
			this.d = A_0.d;
			this.Angle = A_0.Angle;
			this.i = A_0.i;
			this.e = A_0.e;
			this.l = A_0.l;
			this.k = A_0.k;
			this.j.b(A_0.j.f());
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06004B61 RID: 19297 RVA: 0x00264604 File Offset: 0x00263604
		// (set) Token: 0x06004B62 RID: 19298 RVA: 0x0026461C File Offset: 0x0026361C
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

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06004B63 RID: 19299 RVA: 0x00264628 File Offset: 0x00263628
		// (set) Token: 0x06004B64 RID: 19300 RVA: 0x00264640 File Offset: 0x00263640
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

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06004B65 RID: 19301 RVA: 0x0026464C File Offset: 0x0026364C
		// (set) Token: 0x06004B66 RID: 19302 RVA: 0x00264664 File Offset: 0x00263664
		public bool Underline
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

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06004B67 RID: 19303 RVA: 0x00264670 File Offset: 0x00263670
		// (set) Token: 0x06004B68 RID: 19304 RVA: 0x00264688 File Offset: 0x00263688
		public bool Strikethrough
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

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06004B69 RID: 19305 RVA: 0x00264694 File Offset: 0x00263694
		// (set) Token: 0x06004B6A RID: 19306 RVA: 0x002646AC File Offset: 0x002636AC
		public bool RightToLeft
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

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06004B6B RID: 19307 RVA: 0x002646B8 File Offset: 0x002636B8
		// (set) Token: 0x06004B6C RID: 19308 RVA: 0x002646D5 File Offset: 0x002636D5
		public string Text
		{
			get
			{
				return this.j.GetText();
			}
			set
			{
				this.j.SetText(value);
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06004B6D RID: 19309 RVA: 0x002646E8 File Offset: 0x002636E8
		// (set) Token: 0x06004B6E RID: 19310 RVA: 0x00264700 File Offset: 0x00263700
		public Color TextColor
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

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06004B6F RID: 19311 RVA: 0x0026470C File Offset: 0x0026370C
		// (set) Token: 0x06004B70 RID: 19312 RVA: 0x00264724 File Offset: 0x00263724
		public Color TextOutlineColor
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

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06004B71 RID: 19313 RVA: 0x00264730 File Offset: 0x00263730
		// (set) Token: 0x06004B72 RID: 19314 RVA: 0x00264748 File Offset: 0x00263748
		public float TextOutlineWidth
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

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06004B73 RID: 19315 RVA: 0x00264754 File Offset: 0x00263754
		// (set) Token: 0x06004B74 RID: 19316 RVA: 0x00264774 File Offset: 0x00263774
		public Font Font
		{
			get
			{
				return this.j.Font;
			}
			set
			{
				this.j.Font = value;
				if (value is OpenTypeFont && ((OpenTypeFont)value).UseCharacterShaping)
				{
					this.j = value.a(this.j);
				}
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06004B75 RID: 19317 RVA: 0x002647C4 File Offset: 0x002637C4
		// (set) Token: 0x06004B76 RID: 19318 RVA: 0x002647E1 File Offset: 0x002637E1
		public float FontSize
		{
			get
			{
				return this.j.FontSize;
			}
			set
			{
				this.j.FontSize = value;
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06004B77 RID: 19319 RVA: 0x002647F4 File Offset: 0x002637F4
		// (set) Token: 0x06004B78 RID: 19320 RVA: 0x00264811 File Offset: 0x00263811
		public float Leading
		{
			get
			{
				return this.j.Leading;
			}
			set
			{
				this.j.Leading = value;
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06004B79 RID: 19321 RVA: 0x00264824 File Offset: 0x00263824
		// (set) Token: 0x06004B7A RID: 19322 RVA: 0x00264841 File Offset: 0x00263841
		public bool AutoLeading
		{
			get
			{
				return this.j.AutoLeading;
			}
			set
			{
				this.j.AutoLeading = value;
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06004B7B RID: 19323 RVA: 0x00264854 File Offset: 0x00263854
		// (set) Token: 0x06004B7C RID: 19324 RVA: 0x00264871 File Offset: 0x00263871
		public float ParagraphSpacing
		{
			get
			{
				return this.j.ParagraphSpacing;
			}
			set
			{
				this.j.ParagraphSpacing = value;
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06004B7D RID: 19325 RVA: 0x00264884 File Offset: 0x00263884
		// (set) Token: 0x06004B7E RID: 19326 RVA: 0x002648A1 File Offset: 0x002638A1
		public float ParagraphIndent
		{
			get
			{
				return this.j.ParagraphIndent;
			}
			set
			{
				this.j.ParagraphIndent = value;
			}
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06004B7F RID: 19327 RVA: 0x002648B4 File Offset: 0x002638B4
		// (set) Token: 0x06004B80 RID: 19328 RVA: 0x002648D1 File Offset: 0x002638D1
		public bool CleanParagraphBreaks
		{
			get
			{
				return this.j.CleanParagraphBreaks;
			}
			set
			{
				this.j.CleanParagraphBreaks = value;
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06004B81 RID: 19329 RVA: 0x002648E4 File Offset: 0x002638E4
		// (set) Token: 0x06004B82 RID: 19330 RVA: 0x00264901 File Offset: 0x00263901
		public float Width
		{
			get
			{
				return this.j.Width;
			}
			set
			{
				this.j.Width = value;
			}
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06004B83 RID: 19331 RVA: 0x00264914 File Offset: 0x00263914
		// (set) Token: 0x06004B84 RID: 19332 RVA: 0x0026492C File Offset: 0x0026392C
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				this.j.Height = value;
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06004B85 RID: 19333 RVA: 0x00264944 File Offset: 0x00263944
		// (set) Token: 0x06004B86 RID: 19334 RVA: 0x0026495C File Offset: 0x0026395C
		public bool KerningEnabled
		{
			get
			{
				return this.k;
			}
			set
			{
				if (this.k != value)
				{
					if (value)
					{
						if (!(this.j is agb))
						{
							this.j = this.Font.b(this.j);
						}
					}
					else
					{
						this.j = this.Font.a(this.j);
					}
					this.k = value;
				}
				this.j.d(value);
			}
		}

		// Token: 0x06004B87 RID: 19335 RVA: 0x002649E0 File Offset: 0x002639E0
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				writer.SetTextMode();
				this.j.g();
				this.a(writer);
			}
			else
			{
				switch (this.d)
				{
				case VAlign.Top:
					this.j.ja(writer, base.X, base.Y, this.c, this.f, this.g, this.h, this.e, this.i, this.l);
					break;
				case VAlign.Center:
				{
					float a_ = base.Y + base.Height / 2f - this.j.GetTextHeight() / 2f;
					this.j.ja(writer, base.X, a_, this.c, this.f, this.g, this.h, this.e, this.i, this.l);
					break;
				}
				case VAlign.Bottom:
				{
					float a_2 = base.Y + base.Height - this.j.GetTextHeight();
					this.j.ja(writer, base.X, a_2, this.c, this.f, this.g, this.h, this.e, this.i, this.l);
					break;
				}
				}
			}
		}

		// Token: 0x06004B88 RID: 19336 RVA: 0x00264B4C File Offset: 0x00263B4C
		private void a(PageWriter A_0)
		{
			AttributeTypeList a_ = null;
			AttributeClassList a_2 = null;
			StructureElement structureElement = null;
			if (this.j.l())
			{
				if (this.Tag == null)
				{
					structureElement = new StructureElement(TagType.Paragraph, true);
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, this);
					structureElement.AttributeLists.Add(attributeObject);
					if (this.e)
					{
						a_ = structureElement.s();
					}
					structureElement.Order = this.TagOrder;
					if (A_0.k() != null)
					{
						structureElement.Parent = A_0.k();
					}
				}
				else if (this.Tag.g())
				{
					structureElement = (StructureElement)this.Tag;
					structureElement.a(A_0, this, A_0.Document.j());
					a_ = structureElement.s();
					a_2 = structureElement.t();
					if (A_0.k() != null)
					{
						structureElement.Parent = A_0.k();
					}
				}
				else
				{
					this.Tag.e(A_0, this);
					this.j.e(false);
				}
			}
			else if (this.Tag == null)
			{
				new StructureElement(TagType.Paragraph, true)
				{
					Order = this.TagOrder
				}.e(A_0, this);
			}
			else
			{
				this.Tag.e(A_0, this);
			}
			switch (this.d)
			{
			case VAlign.Top:
				this.j.jc(A_0, base.X, base.Y, this.c, this.f, this.g, this.h, this.e, this.i, this.l, structureElement, a_, a_2);
				break;
			case VAlign.Center:
			{
				float a_3 = base.Y + base.Height / 2f - this.j.GetTextHeight() / 2f;
				this.j.jc(A_0, base.X, a_3, this.c, this.f, this.g, this.h, this.e, this.i, this.l, structureElement, a_, a_2);
				break;
			}
			case VAlign.Bottom:
			{
				float a_4 = base.Y + base.Height - this.j.GetTextHeight();
				this.j.jc(A_0, base.X, a_4, this.c, this.f, this.g, this.h, this.e, this.i, this.l, structureElement, a_, a_2);
				break;
			}
			}
			if (!this.j.l() && !this.e)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06004B89 RID: 19337 RVA: 0x00264E28 File Offset: 0x00263E28
		internal TextLineList a()
		{
			return this.j;
		}

		// Token: 0x06004B8A RID: 19338 RVA: 0x00264E40 File Offset: 0x00263E40
		internal override byte cb()
		{
			return 65;
		}

		// Token: 0x06004B8B RID: 19339 RVA: 0x00264E54 File Offset: 0x00263E54
		public float GetRequiredHeight()
		{
			return this.j.GetRequiredHeight(0);
		}

		// Token: 0x06004B8C RID: 19340 RVA: 0x00264E74 File Offset: 0x00263E74
		public float GetTextHeight()
		{
			return this.j.GetTextHeight();
		}

		// Token: 0x06004B8D RID: 19341 RVA: 0x00264E94 File Offset: 0x00263E94
		public string GetOverflowText()
		{
			return this.j.GetOverflowText();
		}

		// Token: 0x06004B8E RID: 19342 RVA: 0x00264EB4 File Offset: 0x00263EB4
		public TextArea GetOverflowTextArea()
		{
			return this.GetOverflowTextArea(base.X, base.Y, this.Width, this.Height);
		}

		// Token: 0x06004B8F RID: 19343 RVA: 0x00264EE4 File Offset: 0x00263EE4
		public TextArea GetOverflowTextArea(float x, float y)
		{
			return this.GetOverflowTextArea(x, y, this.Width, this.Height);
		}

		// Token: 0x06004B90 RID: 19344 RVA: 0x00264F0C File Offset: 0x00263F0C
		public TextArea GetOverflowTextArea(float x, float y, float width, float height)
		{
			TextLineList overflow = this.j.GetOverflow(width, height);
			TextArea result;
			if (overflow == null)
			{
				result = null;
			}
			else
			{
				result = new TextArea(this, x, y, height, overflow)
				{
					Tag = this.Tag,
					TagOrder = this.TagOrder
				};
			}
			return result;
		}

		// Token: 0x06004B91 RID: 19345 RVA: 0x00264F64 File Offset: 0x00263F64
		public bool HasOverflowText()
		{
			return this.j.HasOverflow();
		}

		// Token: 0x06004B92 RID: 19346 RVA: 0x00264F84 File Offset: 0x00263F84
		public KerningValues GetKerningValues()
		{
			if (!this.k)
			{
				throw new GeneratorException("Kerning is not enabled");
			}
			KerningValues result;
			if (!(this.j is agb))
			{
				this.j.b(true);
				result = ((ac6)this.j).a(this.i);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06004B93 RID: 19347 RVA: 0x00264FE8 File Offset: 0x00263FE8
		public int GetVisibleLineCount()
		{
			this.j.g();
			return this.j.VisibleLineCount;
		}

		// Token: 0x06004B94 RID: 19348 RVA: 0x00265014 File Offset: 0x00264014
		public float GetLineTextWidth(int lineIndex)
		{
			this.j.g();
			return this.j.i9(lineIndex);
		}

		// Token: 0x040028BD RID: 10429
		private new const float a = 12f;

		// Token: 0x040028BE RID: 10430
		private const TextAlign b = TextAlign.Left;

		// Token: 0x040028BF RID: 10431
		private TextAlign c;

		// Token: 0x040028C0 RID: 10432
		private new VAlign d;

		// Token: 0x040028C1 RID: 10433
		private bool e;

		// Token: 0x040028C2 RID: 10434
		private Color f;

		// Token: 0x040028C3 RID: 10435
		private Color g;

		// Token: 0x040028C4 RID: 10436
		private float h;

		// Token: 0x040028C5 RID: 10437
		private bool i;

		// Token: 0x040028C6 RID: 10438
		private TextLineList j;

		// Token: 0x040028C7 RID: 10439
		private bool k;

		// Token: 0x040028C8 RID: 10440
		private bool l;

		// Token: 0x040028C9 RID: 10441
		private static Font m = Font.Helvetica;

		// Token: 0x040028CA RID: 10442
		private static Color n = Grayscale.Black;
	}
}
