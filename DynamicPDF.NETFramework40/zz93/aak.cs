using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003F7 RID: 1015
	internal class aak : ComboBoxField
	{
		// Token: 0x06002A57 RID: 10839 RVA: 0x00189D54 File Offset: 0x00188D54
		internal aak(PdfChoiceField A_0, int A_1) : base(A_0.Name, (int)A_0.Flags, null)
		{
			base.IsAnnotation = A_0.w();
			this.a = A_0;
			this.e = A_1;
			if (A_0.q() != null)
			{
				base.AlternateName = A_0.q().kf();
			}
			if (A_0.r() != null)
			{
				base.MappingName = A_0.r().kf();
			}
		}

		// Token: 0x06002A58 RID: 10840 RVA: 0x00189DF8 File Offset: 0x00188DF8
		public override string get_Value()
		{
			string result;
			if (base.InheritsValue)
			{
				result = base.Parent.Value;
			}
			else if (this.b)
			{
				if (this.c == null)
				{
					result = string.Empty;
				}
				else
				{
					result = this.c.kf();
				}
			}
			else
			{
				result = this.a.GetValue();
			}
			return result;
		}

		// Token: 0x06002A59 RID: 10841 RVA: 0x00189E64 File Offset: 0x00188E64
		public override void set_Value(string value)
		{
			if (base.InheritsValue)
			{
				base.Parent.Value = value;
				this.c = null;
			}
			else
			{
				if (value.Length == 0)
				{
					this.d = string.Empty;
					this.c = null;
				}
				this.c = this.a.b(value);
				if (this.c == null)
				{
					this.d = value;
				}
				this.b = true;
				base.Form.RequireLicense(13);
				base.Form.a(true);
			}
		}

		// Token: 0x06002A5A RID: 10842 RVA: 0x00189F08 File Offset: 0x00188F08
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002A5B RID: 10843 RVA: 0x00189F20 File Offset: 0x00188F20
		public override string get_Default()
		{
			return this.Value;
		}

		// Token: 0x06002A5C RID: 10844 RVA: 0x00189F38 File Offset: 0x00188F38
		internal override bool he()
		{
			return this.b;
		}

		// Token: 0x06002A5D RID: 10845 RVA: 0x00189F50 File Offset: 0x00188F50
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
			if (!base.InheritsValue)
			{
				if ((this.b && (this.c != null || this.d.Length > 0)) || (!this.b && this.a.u() != null))
				{
					writer.WriteName(86);
					if (this.b)
					{
						if (this.c != null)
						{
							this.c.hz(writer);
						}
						else
						{
							writer.WriteText(this.d);
						}
					}
					else
					{
						this.a.u().hz(writer);
						if (this.a.c() != null)
						{
							this.a.c().a().hz(writer);
							this.a.c().c().hz(writer);
						}
					}
				}
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
			if ((this.b && !base.HasChildFields) || base.InheritsValue)
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
				this.a(writer);
			}
			else if (this.a.s() != null)
			{
				base.Form.a(writer, this.a.i());
				writer.WriteName(FormField.o);
				this.a.s().hz(writer);
			}
			if (this.a.t() != null)
			{
				writer.WriteName(FormField.p);
				this.a.s().hz(writer);
			}
			if (this.e > 0)
			{
				writer.WriteName(80);
				writer.WriteReferenceShallow(writer.GetPageObject(this.e));
			}
			if (base.i() != null && this.b() != -1)
			{
				base.i().a(writer, this.b());
			}
		}

		// Token: 0x06002A5E RID: 10846 RVA: 0x0018A2F0 File Offset: 0x001892F0
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
			zl zl = new zl(this, a_, a_2, A_0, A_0.u());
			zl.a(this.d);
			zl.c();
			zl.w();
			A_0.WriteReference(A_0.Resources.Add(zl));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002A5F RID: 10847 RVA: 0x0018A3C8 File Offset: 0x001893C8
		internal override void hc(PageWriter A_0, int A_1)
		{
			if (this.a.af())
			{
				if (!this.b && this.a.s() != null)
				{
					afj afj = this.a.ag();
					if (afj != null)
					{
						this.g = afj.j4();
					}
					if (this.g != null)
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
						zl zl = new zl(this, a_, a_2, A_0.DocumentWriter, zh);
						br br = zh.b(this.g.Length);
						br.a(this.g);
						zl.a(afj);
						zl.w();
						A_0.Write_q_();
						A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
						A_0.Write_Do(zl);
						A_0.Write_Q();
					}
				}
				else
				{
					this.a(A_0, A_1);
				}
			}
		}

		// Token: 0x06002A60 RID: 10848 RVA: 0x0018A588 File Offset: 0x00189588
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
			zl zl = new zl(this, a_, a_2, A_0.DocumentWriter, A_0.DocumentWriter.v());
			zl.a(this.d);
			zl.c();
			zl.p();
			zl.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
			A_0.Write_Do(zl);
			A_0.Write_Q();
		}

		// Token: 0x06002A61 RID: 10849 RVA: 0x0018A6B4 File Offset: 0x001896B4
		public override RgbColor get_BackgroundColor()
		{
			return this.a.BackgroundColor;
		}

		// Token: 0x06002A62 RID: 10850 RVA: 0x0018A6D4 File Offset: 0x001896D4
		public override DeviceColor get_BorderColor()
		{
			return this.a.BorderColor;
		}

		// Token: 0x06002A63 RID: 10851 RVA: 0x0018A6F4 File Offset: 0x001896F4
		public override BorderStyle get_BorderStyle()
		{
			return this.a.BorderStyle;
		}

		// Token: 0x06002A64 RID: 10852 RVA: 0x0018A714 File Offset: 0x00189714
		public override int get_Rotate()
		{
			return this.a.Rotate;
		}

		// Token: 0x06002A65 RID: 10853 RVA: 0x0018A734 File Offset: 0x00189734
		public override DeviceColor get_TextColor()
		{
			return this.a.TextColor;
		}

		// Token: 0x06002A66 RID: 10854 RVA: 0x0018A754 File Offset: 0x00189754
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

		// Token: 0x06002A67 RID: 10855 RVA: 0x0018A788 File Offset: 0x00189788
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

		// Token: 0x06002A68 RID: 10856 RVA: 0x0018A7C4 File Offset: 0x001897C4
		internal override string[] hg()
		{
			if (this.f == null)
			{
				this.a();
			}
			string[] array = new string[this.f.Count];
			for (int i = 0; i < this.f.Count; i++)
			{
				array[i] = this.f[i].ItemName;
			}
			return array;
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0018A830 File Offset: 0x00189830
		private new void a()
		{
			abe abe = null;
			if (this.a.b() != null)
			{
				abe = this.a.b();
			}
			else if (base.InheritsValue)
			{
				abe = ((PdfChoiceField)base.Parent.hb()).b();
			}
			this.f = new ChoiceItemList();
			if (abe != null)
			{
				for (int i = 0; i < abe.a(); i++)
				{
					if (abe.a(i).hy() == ag9.c)
					{
						this.f.Add(((ab7)abe.a(i)).kf());
					}
					else if (abe.a(i).hy() == ag9.e)
					{
						abe abe2 = (abe)abe.a(i);
						this.f.Add(((ab7)abe2.a(1)).kf(), ((ab7)abe2.a(0)).kf());
					}
				}
			}
		}

		// Token: 0x04001377 RID: 4983
		private new PdfChoiceField a;

		// Token: 0x04001378 RID: 4984
		private new bool b = false;

		// Token: 0x04001379 RID: 4985
		private new ab7 c = null;

		// Token: 0x0400137A RID: 4986
		internal new string d = string.Empty;

		// Token: 0x0400137B RID: 4987
		private new int e;

		// Token: 0x0400137C RID: 4988
		private new ChoiceItemList f = null;

		// Token: 0x0400137D RID: 4989
		private new byte[] g = null;
	}
}
