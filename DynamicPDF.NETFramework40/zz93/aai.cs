using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003F3 RID: 1011
	internal class aai : ButtonField
	{
		// Token: 0x06002A2C RID: 10796 RVA: 0x00188A88 File Offset: 0x00187A88
		internal aai(PdfButtonField A_0, int A_1) : base(A_0.Name, (int)A_0.Flags, null)
		{
			base.IsAnnotation = A_0.w();
			this.a = A_0;
			this.b = A_1;
			if (A_0.q() != null)
			{
				base.AlternateName = A_0.q().kf();
			}
			if (A_0.r() != null)
			{
				base.MappingName = A_0.r().kf();
			}
		}

		// Token: 0x06002A2D RID: 10797 RVA: 0x00188B0C File Offset: 0x00187B0C
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002A2E RID: 10798 RVA: 0x00188B24 File Offset: 0x00187B24
		protected override void DrawDictionary(DocumentWriter writer)
		{
			if (this.a.ab() && writer.Document.j() != null)
			{
				StructureElement structureElement = this.a.g();
				if (structureElement != null && base.d() && this.a.ae())
				{
					base.a(structureElement);
					structureElement.bp(this, this.a.GetOriginalPageNumber() - 1);
					writer.Document.j().e(structureElement);
				}
			}
			this.a.a(writer);
			base.DrawDictionary(writer);
			base.Form.a(writer, this.a.h());
			base.Form.a(writer, this.a.i());
			if (this.a.s() != null)
			{
				writer.WriteName(FormField.o);
				this.a.s().hz(writer);
			}
			if (this.a.t() != null)
			{
				writer.WriteName(FormField.p);
				this.a.s().hz(writer);
			}
			if (this.b > 0)
			{
				writer.WriteName(80);
				writer.WriteReferenceShallow(writer.GetPageObject(this.b));
			}
			if (this.a.x() != null)
			{
				writer.WriteName(FormField.t);
				this.a.x().hz(writer);
			}
			if (this.a.y() != null)
			{
				writer.WriteName(FormField.ae);
				this.a.y().hz(writer);
			}
			if (base.i() != null && this.b() != -1)
			{
				base.i().a(writer, this.b());
			}
		}

		// Token: 0x06002A2F RID: 10799 RVA: 0x00188D20 File Offset: 0x00187D20
		internal override void hc(PageWriter A_0, int A_1)
		{
			if (this.a.af())
			{
				if (this.a.s() != null)
				{
					afj afj = this.a.ag();
					if (afj != null)
					{
						this.c = afj.j4();
						if (this.c != null)
						{
							float a_;
							float a_2;
							if (this.Rotate % 360 == 90 || this.Rotate % 360 == 270)
							{
								a_ = this.a.Height;
								a_2 = this.a.Width;
							}
							else
							{
								a_ = this.a.Width;
								a_2 = this.a.Height;
							}
							zh zh = A_0.DocumentWriter.v();
							zj zj = new zj(this, a_, a_2, acp.a, A_0.DocumentWriter, zh);
							br br = zh.b(this.c.Length);
							br.a(this.c);
							zj.a(afj);
							zj.w();
							A_0.Write_q_();
							A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
							A_0.Write_Do(zj);
							A_0.Write_Q();
						}
					}
				}
				else
				{
					this.a(A_0, A_1);
				}
			}
		}

		// Token: 0x06002A30 RID: 10800 RVA: 0x00188ED8 File Offset: 0x00187ED8
		private new void a(PageWriter A_0, int A_1)
		{
			float a_;
			float a_2;
			if (this.Rotate % 360 == 90 || this.Rotate % 360 == 270)
			{
				a_ = this.a.Height;
				a_2 = this.a.Width;
			}
			else
			{
				a_ = this.a.Width;
				a_2 = this.a.Height;
			}
			this.b(this.a.f());
			zj zj = new zj(this, a_, a_2, acp.a, A_0.DocumentWriter, A_0.DocumentWriter.v());
			zj.i();
			zj.p();
			zj.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
			A_0.Write_Do(zj);
			A_0.Write_Q();
		}

		// Token: 0x06002A31 RID: 10801 RVA: 0x00189008 File Offset: 0x00188008
		public override RgbColor get_BackgroundColor()
		{
			return this.a.BackgroundColor;
		}

		// Token: 0x06002A32 RID: 10802 RVA: 0x00189028 File Offset: 0x00188028
		public override DeviceColor get_BorderColor()
		{
			return this.a.BorderColor;
		}

		// Token: 0x06002A33 RID: 10803 RVA: 0x00189048 File Offset: 0x00188048
		public override BorderStyle get_BorderStyle()
		{
			return this.a.BorderStyle;
		}

		// Token: 0x06002A34 RID: 10804 RVA: 0x00189068 File Offset: 0x00188068
		public override int get_Rotate()
		{
			return this.a.Rotate;
		}

		// Token: 0x06002A35 RID: 10805 RVA: 0x00189088 File Offset: 0x00188088
		public override DeviceColor get_TextColor()
		{
			return this.a.TextColor;
		}

		// Token: 0x06002A36 RID: 10806 RVA: 0x001890A8 File Offset: 0x001880A8
		public override Font get_Font()
		{
			return this.a.Font;
		}

		// Token: 0x06002A37 RID: 10807 RVA: 0x001890C8 File Offset: 0x001880C8
		public override float get_FontSize()
		{
			return this.a.FontSize;
		}

		// Token: 0x04001368 RID: 4968
		private new PdfButtonField a;

		// Token: 0x04001369 RID: 4969
		private new int b;

		// Token: 0x0400136A RID: 4970
		private new byte[] c = null;
	}
}
