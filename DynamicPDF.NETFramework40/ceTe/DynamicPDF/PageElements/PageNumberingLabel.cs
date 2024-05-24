using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x020002AD RID: 685
	public class PageNumberingLabel : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06001E9A RID: 7834 RVA: 0x00135D00 File Offset: 0x00134D00
		public PageNumberingLabel(string text, float x, float y, float width, float height) : this(text, x, y, width, height, PageNumberingLabel.p, 12f, TextAlign.Left, PageNumberingLabel.q)
		{
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x00135D30 File Offset: 0x00134D30
		public PageNumberingLabel(string text, float x, float y, float width, float height, Font font) : this(text, x, y, width, height, font, 12f, TextAlign.Left, PageNumberingLabel.q)
		{
		}

		// Token: 0x06001E9C RID: 7836 RVA: 0x00135D5C File Offset: 0x00134D5C
		public PageNumberingLabel(string text, float x, float y, float width, float height, Font font, float fontSize) : this(text, x, y, width, height, font, fontSize, TextAlign.Left, PageNumberingLabel.q)
		{
		}

		// Token: 0x06001E9D RID: 7837 RVA: 0x00135D84 File Offset: 0x00134D84
		public PageNumberingLabel(string text, float x, float y, float width, float height, Font font, float fontSize, TextAlign align) : this(text, x, y, width, height, font, fontSize, align, PageNumberingLabel.q)
		{
		}

		// Token: 0x06001E9E RID: 7838 RVA: 0x00135DAC File Offset: 0x00134DAC
		public PageNumberingLabel(string text, float x, float y, float width, float height, Font font, float fontSize, Color textColor) : this(text, x, y, width, height, font, fontSize, TextAlign.Left, textColor)
		{
		}

		// Token: 0x06001E9F RID: 7839 RVA: 0x00135DD0 File Offset: 0x00134DD0
		public PageNumberingLabel(string text, float x, float y, float width, float height, Font font, float fontSize, TextAlign align, Color textColor) : base(x, y, height)
		{
			this.c = text;
			this.e = width;
			this.f = font;
			this.g = fontSize;
			this.d = align;
			this.h = textColor;
			base.o();
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06001EA0 RID: 7840 RVA: 0x00135E54 File Offset: 0x00134E54
		// (set) Token: 0x06001EA1 RID: 7841 RVA: 0x00135E6C File Offset: 0x00134E6C
		public TextAlign Align
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

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06001EA2 RID: 7842 RVA: 0x00135E78 File Offset: 0x00134E78
		// (set) Token: 0x06001EA3 RID: 7843 RVA: 0x00135E90 File Offset: 0x00134E90
		public VAlign VAlign
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

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06001EA4 RID: 7844 RVA: 0x00135E9C File Offset: 0x00134E9C
		// (set) Token: 0x06001EA5 RID: 7845 RVA: 0x00135EB4 File Offset: 0x00134EB4
		public bool Underline
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

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06001EA6 RID: 7846 RVA: 0x00135EC0 File Offset: 0x00134EC0
		// (set) Token: 0x06001EA7 RID: 7847 RVA: 0x00135ED8 File Offset: 0x00134ED8
		public string Text
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
				this.m = null;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06001EA8 RID: 7848 RVA: 0x00135EEC File Offset: 0x00134EEC
		// (set) Token: 0x06001EA9 RID: 7849 RVA: 0x00135F04 File Offset: 0x00134F04
		public Color TextColor
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

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06001EAA RID: 7850 RVA: 0x00135F10 File Offset: 0x00134F10
		// (set) Token: 0x06001EAB RID: 7851 RVA: 0x00135F28 File Offset: 0x00134F28
		public Font Font
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

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06001EAC RID: 7852 RVA: 0x00135F34 File Offset: 0x00134F34
		// (set) Token: 0x06001EAD RID: 7853 RVA: 0x00135F4C File Offset: 0x00134F4C
		public float FontSize
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06001EAE RID: 7854 RVA: 0x00135F58 File Offset: 0x00134F58
		// (set) Token: 0x06001EAF RID: 7855 RVA: 0x00135F70 File Offset: 0x00134F70
		public float Width
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

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06001EB0 RID: 7856 RVA: 0x00135F7C File Offset: 0x00134F7C
		// (set) Token: 0x06001EB1 RID: 7857 RVA: 0x00135F94 File Offset: 0x00134F94
		public int PageTotalOffset
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

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06001EB2 RID: 7858 RVA: 0x00135FA0 File Offset: 0x00134FA0
		// (set) Token: 0x06001EB3 RID: 7859 RVA: 0x00135FB8 File Offset: 0x00134FB8
		public int PageOffset
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06001EB4 RID: 7860 RVA: 0x00135FC4 File Offset: 0x00134FC4
		// (set) Token: 0x06001EB5 RID: 7861 RVA: 0x00135FDC File Offset: 0x00134FDC
		public int NumberingLength
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06001EB6 RID: 7862 RVA: 0x00135FE8 File Offset: 0x00134FE8
		// (set) Token: 0x06001EB7 RID: 7863 RVA: 0x00136000 File Offset: 0x00135000
		public char NumberingPaddingCharacter
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x06001EB8 RID: 7864 RVA: 0x0013600C File Offset: 0x0013500C
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				writer.SetTextMode();
				if (this.Tag == null)
				{
					Artifact artifact = new Artifact();
					artifact.SetType(ArtifactType.Pagination);
					this.Tag = artifact;
				}
				this.Tag.e(writer, this);
			}
			if (this.m == null)
			{
				this.m = new ahl(this.c.ToCharArray(), this.n, this.o);
			}
			int length = 0;
			char[] text;
			if (this.m.a())
			{
				int a_ = writer.DocumentWriter.z();
				text = this.m.a(writer.DocumentWriter.CurrentSection, ref length, writer.PageNumber + this.k, writer.Document.Pages.Count + this.k + this.l, writer.SectionPageNumber, a_);
			}
			else
			{
				text = this.m.a(writer.DocumentWriter.CurrentSection, ref length, writer.PageNumber + this.k, writer.Document.Pages.Count + this.k + this.l, writer.SectionPageNumber);
			}
			TextLineList lines = LineBreaker.Default.GetLines(text, 0, length, this.e, base.Height, this.f, this.g);
			switch (this.i)
			{
			case VAlign.Top:
				lines.ja(writer, base.X, base.Y, this.d, this.h, null, 0f, this.j, false, false);
				break;
			case VAlign.Center:
			{
				float a_2 = base.Y + base.Height / 2f - lines.GetTextHeight() / 2f;
				lines.ja(writer, base.X, a_2, this.d, this.h, null, 0f, this.j, false, false);
				break;
			}
			case VAlign.Bottom:
			{
				float a_3 = base.Y + base.Height - lines.GetTextHeight();
				lines.ja(writer, base.X, a_3, this.d, this.h, null, 0f, this.j, false, false);
				break;
			}
			}
			if (writer.Document.Tag != null)
			{
				writer.z();
			}
		}

		// Token: 0x06001EB9 RID: 7865 RVA: 0x00136290 File Offset: 0x00135290
		internal override byte cb()
		{
			return 51;
		}

		// Token: 0x04000D86 RID: 3462
		private new const float a = 12f;

		// Token: 0x04000D87 RID: 3463
		private const TextAlign b = TextAlign.Left;

		// Token: 0x04000D88 RID: 3464
		private string c;

		// Token: 0x04000D89 RID: 3465
		private new TextAlign d;

		// Token: 0x04000D8A RID: 3466
		private float e;

		// Token: 0x04000D8B RID: 3467
		private Font f;

		// Token: 0x04000D8C RID: 3468
		private float g;

		// Token: 0x04000D8D RID: 3469
		private Color h;

		// Token: 0x04000D8E RID: 3470
		private VAlign i = VAlign.Top;

		// Token: 0x04000D8F RID: 3471
		private bool j = false;

		// Token: 0x04000D90 RID: 3472
		private int k = 0;

		// Token: 0x04000D91 RID: 3473
		private int l = 0;

		// Token: 0x04000D92 RID: 3474
		private ahl m = null;

		// Token: 0x04000D93 RID: 3475
		private int n = 0;

		// Token: 0x04000D94 RID: 3476
		private new char o = ' ';

		// Token: 0x04000D95 RID: 3477
		private static Font p = Font.Helvetica;

		// Token: 0x04000D96 RID: 3478
		private static Color q = Grayscale.Black;
	}
}
