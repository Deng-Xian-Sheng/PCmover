using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x020002AF RID: 687
	public class Label : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06001EC4 RID: 7876 RVA: 0x00136440 File Offset: 0x00135440
		public Label(string text, float x, float y, float width, float height) : this(text, x, y, width, height, Label.l, 12f, TextAlign.Left, Label.m)
		{
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x00136470 File Offset: 0x00135470
		public Label(string text, float x, float y, float width, float height, Font font) : this(text, x, y, width, height, font, 12f, TextAlign.Left, Label.m)
		{
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0013649C File Offset: 0x0013549C
		public Label(string text, float x, float y, float width, float height, Font font, float fontSize) : this(text, x, y, width, height, font, fontSize, TextAlign.Left, Label.m)
		{
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x001364C4 File Offset: 0x001354C4
		public Label(string text, float x, float y, float width, float height, Font font, float fontSize, TextAlign align) : this(text, x, y, width, height, font, fontSize, align, Label.m)
		{
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x001364EC File Offset: 0x001354EC
		public Label(string text, float x, float y, float width, float height, Font font, float fontSize, Color textColor) : this(text, x, y, width, height, font, fontSize, TextAlign.Left, textColor)
		{
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x00136510 File Offset: 0x00135510
		public Label(string text, float x, float y, float width, float height, Font font, float fontSize, TextAlign align, Color textColor)
		{
			this.d = VAlign.Top;
			this.g = 1f;
			this.h = false;
			this.i = false;
			this.j = false;
			base..ctor(x, y, height);
			this.k = font.GetTextLines(text.ToCharArray(), width, height, fontSize);
			this.c = align;
			this.e = textColor;
			base.o();
		}

		// Token: 0x06001ECA RID: 7882 RVA: 0x00136584 File Offset: 0x00135584
		internal Label(char[] A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8)
		{
			this.d = VAlign.Top;
			this.g = 1f;
			this.h = false;
			this.i = false;
			this.j = false;
			base..ctor(A_1, A_2, A_4);
			this.k = A_5.GetTextLines(A_0, A_3, A_4, A_6);
			this.c = A_7;
			this.e = A_8;
			base.o();
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06001ECB RID: 7883 RVA: 0x001365F0 File Offset: 0x001355F0
		// (set) Token: 0x06001ECC RID: 7884 RVA: 0x00136608 File Offset: 0x00135608
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

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06001ECD RID: 7885 RVA: 0x00136614 File Offset: 0x00135614
		// (set) Token: 0x06001ECE RID: 7886 RVA: 0x0013662C File Offset: 0x0013562C
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

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06001ECF RID: 7887 RVA: 0x00136638 File Offset: 0x00135638
		// (set) Token: 0x06001ED0 RID: 7888 RVA: 0x00136650 File Offset: 0x00135650
		public bool Underline
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

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06001ED1 RID: 7889 RVA: 0x0013665C File Offset: 0x0013565C
		// (set) Token: 0x06001ED2 RID: 7890 RVA: 0x00136674 File Offset: 0x00135674
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

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06001ED3 RID: 7891 RVA: 0x00136680 File Offset: 0x00135680
		// (set) Token: 0x06001ED4 RID: 7892 RVA: 0x0013669D File Offset: 0x0013569D
		public string Text
		{
			get
			{
				return this.k.GetText();
			}
			set
			{
				this.k.SetText(value);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06001ED5 RID: 7893 RVA: 0x001366B0 File Offset: 0x001356B0
		// (set) Token: 0x06001ED6 RID: 7894 RVA: 0x001366C8 File Offset: 0x001356C8
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

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06001ED7 RID: 7895 RVA: 0x001366D4 File Offset: 0x001356D4
		// (set) Token: 0x06001ED8 RID: 7896 RVA: 0x001366EC File Offset: 0x001356EC
		public Color TextOutlineColor
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

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06001ED9 RID: 7897 RVA: 0x001366F8 File Offset: 0x001356F8
		// (set) Token: 0x06001EDA RID: 7898 RVA: 0x00136710 File Offset: 0x00135710
		public float TextOutlineWidth
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06001EDB RID: 7899 RVA: 0x0013671C File Offset: 0x0013571C
		// (set) Token: 0x06001EDC RID: 7900 RVA: 0x00136734 File Offset: 0x00135734
		public bool Strikethrough
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

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06001EDD RID: 7901 RVA: 0x00136740 File Offset: 0x00135740
		// (set) Token: 0x06001EDE RID: 7902 RVA: 0x00136760 File Offset: 0x00135760
		public Font Font
		{
			get
			{
				return this.k.Font;
			}
			set
			{
				this.k.Font = value;
				if (value is OpenTypeFont && ((OpenTypeFont)value).UseCharacterShaping)
				{
					this.k = value.a(this.k);
				}
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06001EDF RID: 7903 RVA: 0x001367B0 File Offset: 0x001357B0
		// (set) Token: 0x06001EE0 RID: 7904 RVA: 0x001367CD File Offset: 0x001357CD
		public float FontSize
		{
			get
			{
				return this.k.FontSize;
			}
			set
			{
				this.k.FontSize = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06001EE1 RID: 7905 RVA: 0x001367E0 File Offset: 0x001357E0
		// (set) Token: 0x06001EE2 RID: 7906 RVA: 0x001367FD File Offset: 0x001357FD
		public float Width
		{
			get
			{
				return this.k.Width;
			}
			set
			{
				this.k.Width = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06001EE3 RID: 7907 RVA: 0x00136810 File Offset: 0x00135810
		// (set) Token: 0x06001EE4 RID: 7908 RVA: 0x00136828 File Offset: 0x00135828
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				this.k.Height = value;
			}
		}

		// Token: 0x06001EE5 RID: 7909 RVA: 0x00136840 File Offset: 0x00135840
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				writer.SetTextMode();
				this.k.g();
				this.a(writer);
			}
			else
			{
				switch (this.d)
				{
				case VAlign.Top:
					this.k.ja(writer, base.X, base.Y, this.c, this.e, this.f, this.g, this.h, this.i, this.j);
					break;
				case VAlign.Center:
				{
					float a_ = base.Y + base.Height / 2f - this.k.GetTextHeight() / 2f;
					this.k.ja(writer, base.X, a_, this.c, this.e, this.f, this.g, this.h, this.i, this.j);
					break;
				}
				case VAlign.Bottom:
				{
					float a_2 = base.Y + base.Height - this.k.GetTextHeight();
					this.k.ja(writer, base.X, a_2, this.c, this.e, this.f, this.g, this.h, this.i, this.j);
					break;
				}
				}
			}
		}

		// Token: 0x06001EE6 RID: 7910 RVA: 0x001369AC File Offset: 0x001359AC
		private void a(PageWriter A_0)
		{
			AttributeTypeList a_ = null;
			AttributeClassList a_2 = null;
			StructureElement structureElement = null;
			if (this.k.l())
			{
				if (this.Tag == null)
				{
					structureElement = new StructureElement(TagType.Paragraph, true);
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.a(A_0, this);
					structureElement.AttributeLists.Add(attributeObject);
					if (this.h)
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
					this.k.e(false);
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
				this.k.jc(A_0, base.X, base.Y, this.c, this.e, this.f, this.g, this.h, this.i, this.j, structureElement, a_, a_2);
				break;
			case VAlign.Center:
			{
				float a_3 = base.Y + base.Height / 2f - this.k.GetTextHeight() / 2f;
				this.k.jc(A_0, base.X, a_3, this.c, this.e, this.f, this.g, this.h, this.i, this.j, structureElement, a_, a_2);
				break;
			}
			case VAlign.Bottom:
			{
				float a_4 = base.Y + base.Height - this.k.GetTextHeight();
				this.k.jc(A_0, base.X, a_4, this.c, this.e, this.f, this.g, this.h, this.i, this.j, structureElement, a_, a_2);
				break;
			}
			}
			if (!this.k.l() && !this.h)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06001EE7 RID: 7911 RVA: 0x00136C8C File Offset: 0x00135C8C
		internal TextLineList a()
		{
			return this.k;
		}

		// Token: 0x06001EE8 RID: 7912 RVA: 0x00136CA4 File Offset: 0x00135CA4
		internal override byte cb()
		{
			return 66;
		}

		// Token: 0x04000D99 RID: 3481
		private new const float a = 12f;

		// Token: 0x04000D9A RID: 3482
		private const TextAlign b = TextAlign.Left;

		// Token: 0x04000D9B RID: 3483
		private TextAlign c;

		// Token: 0x04000D9C RID: 3484
		private new VAlign d;

		// Token: 0x04000D9D RID: 3485
		private Color e;

		// Token: 0x04000D9E RID: 3486
		private Color f;

		// Token: 0x04000D9F RID: 3487
		private float g;

		// Token: 0x04000DA0 RID: 3488
		private bool h;

		// Token: 0x04000DA1 RID: 3489
		private bool i;

		// Token: 0x04000DA2 RID: 3490
		private bool j;

		// Token: 0x04000DA3 RID: 3491
		private TextLineList k;

		// Token: 0x04000DA4 RID: 3492
		private static Font l = Font.Helvetica;

		// Token: 0x04000DA5 RID: 3493
		private static Color m = Grayscale.Black;
	}
}
