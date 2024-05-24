using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x02000400 RID: 1024
	internal class aap : ceTe.DynamicPDF.Forms.TextField
	{
		// Token: 0x06002AE4 RID: 10980 RVA: 0x0018D734 File Offset: 0x0018C734
		internal aap(PdfTextField A_0, int A_1) : base(A_0.Name, A_0.k(), (int)A_0.Flags)
		{
			base.IsAnnotation = A_0.w();
			this.a = A_0;
			this.d = A_1;
			if (A_0.q() != null)
			{
				base.AlternateName = A_0.q().kf();
			}
			if (A_0.r() != null)
			{
				base.MappingName = A_0.r().kf();
			}
		}

		// Token: 0x06002AE5 RID: 10981 RVA: 0x0018D7D0 File Offset: 0x0018C7D0
		public override string get_Value()
		{
			string result;
			if (this.c)
			{
				result = this.b;
			}
			else if (base.InheritsValue)
			{
				result = base.Parent.Value;
			}
			else
			{
				result = this.a.Text;
			}
			return result;
		}

		// Token: 0x06002AE6 RID: 10982 RVA: 0x0018D820 File Offset: 0x0018C820
		public override void set_Value(string value)
		{
			if (base.InheritsValue)
			{
				base.Parent.Value = value;
			}
			this.b = value;
			base.Form.RequireLicense(13);
			base.Form.a(true);
			this.c = true;
		}

		// Token: 0x06002AE7 RID: 10983 RVA: 0x0018D874 File Offset: 0x0018C874
		public override int get_MaximumLength()
		{
			return this.a.MaximumLength;
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x0018D894 File Offset: 0x0018C894
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x0018D8AC File Offset: 0x0018C8AC
		internal override int hk()
		{
			return (int)this.a.Flags;
		}

		// Token: 0x06002AEA RID: 10986 RVA: 0x0018D8CC File Offset: 0x0018C8CC
		internal override string hl()
		{
			string result;
			if (this.Value != string.Empty)
			{
				result = this.Value;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x0018D900 File Offset: 0x0018C900
		internal override bool he()
		{
			bool result;
			if (base.InheritsValue && base.Parent is aap)
			{
				result = ((aap)base.Parent).he();
			}
			else
			{
				result = this.c;
			}
			return result;
		}

		// Token: 0x06002AEC RID: 10988 RVA: 0x0018D94C File Offset: 0x0018C94C
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
			if (this.c)
			{
				if (this.b != null && this.b.Length > 0)
				{
					writer.WriteName(86);
					writer.WriteText(this.b);
				}
			}
			else if (this.a.u() != null)
			{
				writer.WriteName(86);
				this.a.u().hz(writer);
			}
			FormFieldAlign formFieldAlign = this.a.k();
			if (formFieldAlign != writer.Document.Form.DefaultAlign)
			{
				if (formFieldAlign != FormFieldAlign.Left)
				{
					writer.WriteName(81);
					writer.WriteNumber((int)formFieldAlign);
				}
			}
			base.Form.a(writer, this.a.h());
			if (!this.he())
			{
				base.Form.a(writer, this.a.i());
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
				if (this.a.s() != null)
				{
					writer.WriteName(FormField.o);
					this.a.s().hz(writer);
				}
			}
			else if (!this.a.HasChildFields)
			{
				if (this.Font == null)
				{
					if (!base.UseSubstituteFont || (base.UseSubstituteFont && writer.Document.Form.SubstituteFont == null))
					{
						throw new FontNotFoundException("One or more Form Field font not found.");
					}
					this.Font = writer.Document.Form.SubstituteFont;
				}
				base.Form.a(writer, this.Font, this.FontSize, this.TextColor);
				this.b(writer);
				if (this.BorderStyle != null)
				{
					this.BorderStyle.Draw(writer);
				}
				this.a(writer);
			}
			if (!this.he() && this.a.t() != null)
			{
				writer.WriteName(FormField.p);
				this.a.t().hz(writer);
			}
			if (this.d > 0)
			{
				writer.WriteName(80);
				writer.WriteReferenceShallow(writer.GetPageObject(this.d));
			}
			if (base.i() != null && this.b() != -1)
			{
				base.i().a(writer, this.b());
			}
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x0018DCE8 File Offset: 0x0018CCE8
		private new void b(DocumentWriter A_0)
		{
			int num = this.Rotate % 360;
			if (num > 0 || this.BorderColor != null || this.BackgroundColor != null)
			{
				A_0.WriteName(FormField.t);
				A_0.WriteDictionaryOpen();
				if (num > 0)
				{
					A_0.WriteName(FormField.aa);
					A_0.WriteNumber(num);
				}
				if (this.BorderColor != null)
				{
					A_0.WriteName(FormField.u);
					this.BorderColor.gr(A_0);
				}
				if (this.BackgroundColor != null)
				{
					A_0.WriteName(FormField.v);
					this.BackgroundColor.gr(A_0);
				}
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x0018DDB0 File Offset: 0x0018CDB0
		private new void a(DocumentWriter A_0)
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
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			zo zo = new zo(this, a_, a_2, A_0, A_0.u());
			zo.f();
			zo.w();
			A_0.WriteReference(A_0.Resources.Add(zo));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x0018DE7C File Offset: 0x0018CE7C
		internal override void hc(PageWriter A_0, int A_1)
		{
			if (this.a.af())
			{
				if (!this.he() && this.a.s() != null && !A_0.Document.Form.NeedsAppearances)
				{
					afj afj = this.a.ag();
					if (afj != null)
					{
						this.e = afj.j4();
					}
					if (this.e != null)
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
						zo zo = new zo(this, a_, a_2, A_0.DocumentWriter, zh);
						br br = zh.b(this.e.Length);
						br.a(this.e);
						zo.a(afj);
						zo.w();
						A_0.Write_q_();
						A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
						A_0.Write_Do(zo);
						A_0.Write_Q();
					}
				}
				else
				{
					this.a(A_0, A_1);
				}
			}
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x0018E048 File Offset: 0x0018D048
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
			zo zo = new zo(this, a_, a_2, A_0.DocumentWriter, A_0.DocumentWriter.v());
			zo.f();
			zo.p();
			zo.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
			A_0.Write_Do(zo);
			A_0.Write_Q();
		}

		// Token: 0x06002AF1 RID: 10993 RVA: 0x0018E164 File Offset: 0x0018D164
		public override RgbColor get_BackgroundColor()
		{
			return this.a.BackgroundColor;
		}

		// Token: 0x06002AF2 RID: 10994 RVA: 0x0018E184 File Offset: 0x0018D184
		public override DeviceColor get_BorderColor()
		{
			return this.a.BorderColor;
		}

		// Token: 0x06002AF3 RID: 10995 RVA: 0x0018E1A4 File Offset: 0x0018D1A4
		public override BorderStyle get_BorderStyle()
		{
			return this.a.BorderStyle;
		}

		// Token: 0x06002AF4 RID: 10996 RVA: 0x0018E1C4 File Offset: 0x0018D1C4
		public override int get_Rotate()
		{
			return this.a.Rotate;
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x0018E1E4 File Offset: 0x0018D1E4
		public override DeviceColor get_TextColor()
		{
			return this.a.TextColor;
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x0018E204 File Offset: 0x0018D204
		public override Font get_Font()
		{
			Font font;
			if (base.Font != null)
			{
				font = base.Font;
			}
			else
			{
				font = this.a.Font;
			}
			return font;
		}

		// Token: 0x06002AF7 RID: 10999 RVA: 0x0018E238 File Offset: 0x0018D238
		public override float get_FontSize()
		{
			float fontSize;
			if (base.FontSize > -3.4028235E+38f)
			{
				fontSize = base.FontSize;
			}
			else
			{
				fontSize = this.a.FontSize;
			}
			return fontSize;
		}

		// Token: 0x040013BE RID: 5054
		private new PdfTextField a;

		// Token: 0x040013BF RID: 5055
		private new string b = string.Empty;

		// Token: 0x040013C0 RID: 5056
		private new bool c = false;

		// Token: 0x040013C1 RID: 5057
		private new int d;

		// Token: 0x040013C2 RID: 5058
		private new byte[] e = null;
	}
}
