using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine.Layout;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020005D0 RID: 1488
	internal class am7 : RotatingPageElement
	{
		// Token: 0x06003AE3 RID: 15075 RVA: 0x001F98BC File Offset: 0x001F88BC
		internal am7(am7 A_0) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(32);
			this.a = A_0.a.Font.GetTextLines(A_0.a.GetText().ToCharArray(), A_0.a.Width, A_0.a.Height, A_0.a.FontSize);
			this.b = A_0.b;
			this.c = A_0.c;
			this.d = A_0.d;
			this.g = A_0.g;
			this.e = A_0.e;
			this.f = A_0.f;
			this.Angle = A_0.Angle;
			this.h = A_0.h;
			this.a.Leading = A_0.a.Leading;
			this.a.AutoLeading = A_0.a.AutoLeading;
			this.a.CleanParagraphBreaks = A_0.a.CleanParagraphBreaks;
			this.a.ParagraphIndent = A_0.a.ParagraphIndent;
			this.a.ParagraphSpacing = A_0.a.ParagraphSpacing;
		}

		// Token: 0x06003AE4 RID: 15076 RVA: 0x001F9A10 File Offset: 0x001F8A10
		internal am7(x5 A_0, x5 A_1, LayoutTextArea A_2) : base(A_2.X, A_0, A_1, A_2.Angle)
		{
			this.a = A_2.a().a(x5.b(A_1));
			this.b = A_2.Align;
			this.c = A_2.VAlign;
			this.d = A_2.TextColor;
			this.e = A_2.TextOutlineColor;
			this.f = A_2.TextOutlineWidth;
			this.g = A_2.Underline;
			this.h = A_2.fd();
		}

		// Token: 0x06003AE5 RID: 15077 RVA: 0x001F9AA8 File Offset: 0x001F8AA8
		internal am7(x5 A_0, x5 A_1, am7 A_2) : base(A_2.X, A_0, A_1, A_2.Angle)
		{
			this.a = A_2.a().a(x5.b(A_1));
			this.b = A_2.b();
			this.c = A_2.c();
			this.d = A_2.d();
			this.e = A_2.e;
			this.f = A_2.f;
			this.g = A_2.e();
			this.h = A_2.fd();
		}

		// Token: 0x06003AE6 RID: 15078 RVA: 0x001F9B40 File Offset: 0x001F8B40
		internal TextLineList a()
		{
			return this.a;
		}

		// Token: 0x06003AE7 RID: 15079 RVA: 0x001F9B58 File Offset: 0x001F8B58
		internal TextAlign b()
		{
			return this.b;
		}

		// Token: 0x06003AE8 RID: 15080 RVA: 0x001F9B70 File Offset: 0x001F8B70
		internal VAlign c()
		{
			return this.c;
		}

		// Token: 0x06003AE9 RID: 15081 RVA: 0x001F9B88 File Offset: 0x001F8B88
		internal Color d()
		{
			return this.d;
		}

		// Token: 0x06003AEA RID: 15082 RVA: 0x001F9BA0 File Offset: 0x001F8BA0
		internal bool e()
		{
			return this.g;
		}

		// Token: 0x06003AEB RID: 15083 RVA: 0x001F9BB8 File Offset: 0x001F8BB8
		internal override short fd()
		{
			return this.h;
		}

		// Token: 0x06003AEC RID: 15084 RVA: 0x001F9BD0 File Offset: 0x001F8BD0
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
				switch (this.c)
				{
				case VAlign.Top:
					this.a.ja(writer, base.X, base.Y, this.b, this.d, this.e, this.f, this.g, false, false);
					break;
				case VAlign.Center:
				{
					float a_ = base.Y + base.Height / 2f - this.a.GetTextHeight() / 2f;
					this.a.ja(writer, base.X, a_, this.b, this.d, this.e, this.f, this.g, false, false);
					break;
				}
				case VAlign.Bottom:
				{
					float a_2 = base.Y + base.Height - this.a.GetTextHeight();
					this.a.ja(writer, base.X, a_2, this.b, this.d, this.e, this.f, this.g, false, false);
					break;
				}
				}
			}
		}

		// Token: 0x06003AED RID: 15085 RVA: 0x001F9D1C File Offset: 0x001F8D1C
		private void a(PageWriter A_0)
		{
			AttributeTypeList a_ = null;
			AttributeClassList a_2 = null;
			StructureElement structureElement = null;
			if (this.a.l())
			{
				structureElement = new StructureElement(TagType.Paragraph, true);
				AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
				attributeObject.a(A_0, null, this);
				structureElement.AttributeLists.Add(attributeObject);
				if (this.g)
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
			switch (this.c)
			{
			case VAlign.Top:
				this.a.jc(A_0, base.X, base.Y, this.b, this.d, this.e, this.f, this.g, false, false, structureElement, a_, a_2);
				break;
			case VAlign.Center:
			{
				float a_3 = base.Y + base.Height / 2f - this.a.GetTextHeight() / 2f;
				this.a.jc(A_0, base.X, a_3, this.b, this.d, this.e, this.f, this.g, false, false, structureElement, a_, a_2);
				break;
			}
			case VAlign.Bottom:
			{
				float a_4 = base.Y + base.Height - this.a.GetTextHeight();
				this.a.jc(A_0, base.X, a_4, this.b, this.d, this.e, this.f, this.g, false, false, structureElement, a_, a_2);
				break;
			}
			}
			if (!this.a.l() && !this.g)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06003AEE RID: 15086 RVA: 0x001F9F18 File Offset: 0x001F8F18
		internal override byte cb()
		{
			return 70;
		}

		// Token: 0x06003AEF RID: 15087 RVA: 0x001F9F2C File Offset: 0x001F8F2C
		internal override void b6(acw A_0)
		{
			if (this.a.VisibleLineCount == 1)
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

		// Token: 0x06003AF0 RID: 15088 RVA: 0x001F9FE1 File Offset: 0x001F8FE1
		internal override void b9(x5 A_0)
		{
			base.a(x5.e(base.l(), A_0));
		}

		// Token: 0x06003AF1 RID: 15089 RVA: 0x001F9FF8 File Offset: 0x001F8FF8
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (x5.d(A_0, x5.a(this.a.Leading)))
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

		// Token: 0x06003AF2 RID: 15090 RVA: 0x001FA120 File Offset: 0x001F9120
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

		// Token: 0x06003AF3 RID: 15091 RVA: 0x001FA190 File Offset: 0x001F9190
		internal override PageElement fc()
		{
			return new am7(this);
		}

		// Token: 0x04001BCC RID: 7116
		private new TextLineList a;

		// Token: 0x04001BCD RID: 7117
		private TextAlign b;

		// Token: 0x04001BCE RID: 7118
		private VAlign c = VAlign.Top;

		// Token: 0x04001BCF RID: 7119
		private new Color d;

		// Token: 0x04001BD0 RID: 7120
		private Color e;

		// Token: 0x04001BD1 RID: 7121
		private float f;

		// Token: 0x04001BD2 RID: 7122
		private bool g;

		// Token: 0x04001BD3 RID: 7123
		private short h;
	}
}
