using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003FB RID: 1019
	internal class aam : ListBoxField
	{
		// Token: 0x06002AAC RID: 10924 RVA: 0x0018B7B0 File Offset: 0x0018A7B0
		internal aam(PdfChoiceField A_0, int A_1) : base(A_0.Name, (int)A_0.Flags, null)
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

		// Token: 0x06002AAD RID: 10925 RVA: 0x0018B854 File Offset: 0x0018A854
		public override string get_Value()
		{
			string result;
			if (base.InheritsValue)
			{
				result = base.Parent.Value;
			}
			else if (this.b)
			{
				string text = string.Empty;
				for (int i = 0; i < this.c.Length; i++)
				{
					if (this.c[i] == null)
					{
						return text;
					}
					if (i > 0)
					{
						text += ",";
					}
					if (this.f[this.c[i].a()].ExportValue != null && this.f[this.c[i].a()].ExportValue.Equals(this.c[i].b().kf()))
					{
						text += this.f[this.c[i].a()].ItemName;
					}
					else
					{
						text += this.c[i].b().kf();
					}
				}
				result = text;
			}
			else
			{
				result = this.a.GetValue();
			}
			return result;
		}

		// Token: 0x06002AAE RID: 10926 RVA: 0x0018B998 File Offset: 0x0018A998
		public override void set_Value(string value)
		{
			if (base.InheritsValue)
			{
				base.Parent.Value = value;
			}
			else
			{
				string[] array = new string[1];
				if (this.f == null)
				{
					this.a();
				}
				if (this.f[value] != null && this.f[value].ExportValue != null)
				{
					array[0] = this.f[value].ExportValue;
				}
				else
				{
					array[0] = value;
				}
				this.c = this.a.a(array);
				this.b = true;
				base.Form.RequireLicense(13);
				base.Form.a(true);
			}
		}

		// Token: 0x06002AAF RID: 10927 RVA: 0x0018BA60 File Offset: 0x0018AA60
		public override string get_Default()
		{
			if (this.e == string.Empty)
			{
				abd abd = this.a.v().h6();
				if (abd.hy() == ag9.c)
				{
					this.e = ((ab7)abd).kf();
				}
				else if (abd.hy() == ag9.e)
				{
					abe abe = (abe)abd;
					for (int i = 0; i < abe.a(); i++)
					{
						if (i > 0)
						{
							this.e += ",";
						}
						this.e += ((ab7)abe.a(i)).kf();
					}
				}
			}
			return this.e;
		}

		// Token: 0x06002AB0 RID: 10928 RVA: 0x0018BB48 File Offset: 0x0018AB48
		public override void SetValues(string[] values)
		{
			if (base.InheritsValue)
			{
				if (base.Parent is ListBoxField)
				{
					((ListBoxField)base.Parent).SetValues(values);
				}
			}
			else
			{
				if (base.Flags != FormFieldFlags.MultiSelect && values.Length > 1)
				{
					throw new MergerException("The ListBox is not having the Multiselect property set to true.");
				}
				if (this.f == null)
				{
					this.a();
				}
				string[] array = new string[values.Length];
				int num = 0;
				foreach (string text in values)
				{
					if (this.f[text] != null && this.f[text].ExportValue != null)
					{
						array[num++] = this.f[text].ExportValue;
					}
					else
					{
						array[num++] = text;
					}
				}
				this.c = this.a.a(array);
				this.b = true;
				base.Form.a(true);
			}
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x0018BC74 File Offset: 0x0018AC74
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x0018BC8C File Offset: 0x0018AC8C
		internal override int hh()
		{
			if (this.f == null)
			{
				this.a();
			}
			return this.f.Count;
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x0018BCC0 File Offset: 0x0018ACC0
		internal override int hi(string A_0)
		{
			if (this.f == null)
			{
				this.a();
			}
			return this.f.a(this.f[A_0]);
		}

		// Token: 0x06002AB4 RID: 10932 RVA: 0x0018BD00 File Offset: 0x0018AD00
		internal override string[] hj()
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

		// Token: 0x06002AB5 RID: 10933 RVA: 0x0018BD6C File Offset: 0x0018AD6C
		internal override bool he()
		{
			return this.b;
		}

		// Token: 0x06002AB6 RID: 10934 RVA: 0x0018BD84 File Offset: 0x0018AD84
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
			if (!base.InheritsValue)
			{
				if ((this.b && this.c.Length > 0) || (!this.b && this.a.u() != null))
				{
					writer.WriteName(86);
					if (this.b)
					{
						writer.WriteArrayOpen();
						for (int i = 0; i < this.c.Length; i++)
						{
							if (this.c[i] != null)
							{
								this.c[i].b().hz(writer);
							}
						}
						writer.WriteArrayClose();
						writer.WriteName(73);
						writer.WriteArrayOpen();
						for (int i = 0; i < this.c.Length; i++)
						{
							if (this.c[i] != null)
							{
								writer.WriteNumber(this.c[i].a());
							}
						}
						writer.WriteArrayClose();
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
			else if (this.a.aa() != null)
			{
				base.Form.a(writer, this.a.i());
			}
			if (this.a.t() != null)
			{
				writer.WriteName(FormField.p);
				this.a.s().hz(writer);
			}
			base.Form.a(writer, this.a.h());
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

		// Token: 0x06002AB7 RID: 10935 RVA: 0x0018C1C0 File Offset: 0x0018B1C0
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

		// Token: 0x06002AB8 RID: 10936 RVA: 0x0018C2D4 File Offset: 0x0018B2D4
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
			zm zm = new zm(this, a_, a_2, A_0, A_0.u());
			zm.c();
			zm.w();
			A_0.WriteReference(A_0.Resources.Add(zm));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002AB9 RID: 10937 RVA: 0x0018C3A0 File Offset: 0x0018B3A0
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
						zm zm = new zm(this, a_, a_2, A_0.DocumentWriter, zh);
						br br = zh.b(this.g.Length);
						br.a(this.g);
						zm.a(afj);
						zm.w();
						A_0.Write_q_();
						A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
						A_0.Write_Do(zm);
						A_0.Write_Q();
					}
				}
				else
				{
					this.a(A_0, A_1);
				}
			}
		}

		// Token: 0x06002ABA RID: 10938 RVA: 0x0018C560 File Offset: 0x0018B560
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
			zm zm = new zm(this, a_, a_2, A_0.DocumentWriter, A_0.DocumentWriter.v());
			zm.c();
			zm.p();
			zm.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
			A_0.Write_Do(zm);
			A_0.Write_Q();
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x0018C67C File Offset: 0x0018B67C
		public override RgbColor get_BackgroundColor()
		{
			return this.a.BackgroundColor;
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x0018C69C File Offset: 0x0018B69C
		public override DeviceColor get_BorderColor()
		{
			return this.a.BorderColor;
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x0018C6BC File Offset: 0x0018B6BC
		public override BorderStyle get_BorderStyle()
		{
			return this.a.BorderStyle;
		}

		// Token: 0x06002ABE RID: 10942 RVA: 0x0018C6DC File Offset: 0x0018B6DC
		public override int get_Rotate()
		{
			return this.a.Rotate;
		}

		// Token: 0x06002ABF RID: 10943 RVA: 0x0018C6FC File Offset: 0x0018B6FC
		public override DeviceColor get_TextColor()
		{
			return this.a.TextColor;
		}

		// Token: 0x06002AC0 RID: 10944 RVA: 0x0018C71C File Offset: 0x0018B71C
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

		// Token: 0x06002AC1 RID: 10945 RVA: 0x0018C750 File Offset: 0x0018B750
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

		// Token: 0x040013AF RID: 5039
		private new PdfChoiceField a;

		// Token: 0x040013B0 RID: 5040
		private new bool b = false;

		// Token: 0x040013B1 RID: 5041
		private new aah[] c = null;

		// Token: 0x040013B2 RID: 5042
		private new int d;

		// Token: 0x040013B3 RID: 5043
		private new string e = string.Empty;

		// Token: 0x040013B4 RID: 5044
		private new ChoiceItemList f = null;

		// Token: 0x040013B5 RID: 5045
		private new byte[] g = null;
	}
}
