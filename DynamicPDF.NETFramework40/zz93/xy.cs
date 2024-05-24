using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.Layout;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000392 RID: 914
	internal class xy : RotatingPageElement
	{
		// Token: 0x06002707 RID: 9991 RVA: 0x00168DA0 File Offset: 0x00167DA0
		internal xy(xy A_0) : base(A_0.X, A_0.Y, A_0.Height)
		{
			base.d(33);
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

		// Token: 0x06002708 RID: 9992 RVA: 0x00168EF4 File Offset: 0x00167EF4
		internal xy(x5 A_0, x5 A_1, LayoutTextArea A_2) : base(A_2.X, A_0, A_1, A_2.Angle)
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

		// Token: 0x06002709 RID: 9993 RVA: 0x00168F8C File Offset: 0x00167F8C
		internal xy(x5 A_0, x5 A_1, xy A_2) : base(A_2.X, A_0, A_1, A_2.Angle)
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

		// Token: 0x0600270A RID: 9994 RVA: 0x00169024 File Offset: 0x00168024
		internal TextLineList a()
		{
			return this.a;
		}

		// Token: 0x0600270B RID: 9995 RVA: 0x0016903C File Offset: 0x0016803C
		internal TextAlign b()
		{
			return this.b;
		}

		// Token: 0x0600270C RID: 9996 RVA: 0x00169054 File Offset: 0x00168054
		internal VAlign c()
		{
			return this.c;
		}

		// Token: 0x0600270D RID: 9997 RVA: 0x0016906C File Offset: 0x0016806C
		internal Color d()
		{
			return this.d;
		}

		// Token: 0x0600270E RID: 9998 RVA: 0x00169084 File Offset: 0x00168084
		internal bool e()
		{
			return this.g;
		}

		// Token: 0x0600270F RID: 9999 RVA: 0x0016909C File Offset: 0x0016809C
		internal override short fd()
		{
			return this.h;
		}

		// Token: 0x06002710 RID: 10000 RVA: 0x001690B4 File Offset: 0x001680B4
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

		// Token: 0x06002711 RID: 10001 RVA: 0x00169200 File Offset: 0x00168200
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

		// Token: 0x06002712 RID: 10002 RVA: 0x001693FC File Offset: 0x001683FC
		internal override byte cb()
		{
			return 70;
		}

		// Token: 0x06002713 RID: 10003 RVA: 0x00169410 File Offset: 0x00168410
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

		// Token: 0x06002714 RID: 10004 RVA: 0x001694C5 File Offset: 0x001684C5
		internal override void b9(x5 A_0)
		{
			base.a(x5.e(base.l(), A_0));
		}

		// Token: 0x06002715 RID: 10005 RVA: 0x001694DC File Offset: 0x001684DC
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (x5.d(A_0, x5.a(this.a.Leading)))
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

		// Token: 0x06002716 RID: 10006 RVA: 0x001695CC File Offset: 0x001685CC
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

		// Token: 0x06002717 RID: 10007 RVA: 0x0016963C File Offset: 0x0016863C
		internal override PageElement fc()
		{
			return new xy(this);
		}

		// Token: 0x040010F4 RID: 4340
		private new TextLineList a;

		// Token: 0x040010F5 RID: 4341
		private TextAlign b;

		// Token: 0x040010F6 RID: 4342
		private VAlign c = VAlign.Top;

		// Token: 0x040010F7 RID: 4343
		private new Color d;

		// Token: 0x040010F8 RID: 4344
		private Color e;

		// Token: 0x040010F9 RID: 4345
		private float f;

		// Token: 0x040010FA RID: 4346
		private bool g;

		// Token: 0x040010FB RID: 4347
		private short h;
	}
}
