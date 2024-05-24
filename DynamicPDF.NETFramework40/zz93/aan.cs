using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003FD RID: 1021
	internal class aan : RadioButtonField
	{
		// Token: 0x06002AC9 RID: 10953 RVA: 0x0018C7C0 File Offset: 0x0018B7C0
		internal aan(PdfButtonField A_0, int A_1) : base(A_0.Name, (int)A_0.Flags, null)
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

		// Token: 0x06002ACA RID: 10954 RVA: 0x0018C854 File Offset: 0x0018B854
		internal override ArrayList hd(ArrayList A_0)
		{
			ArrayList result;
			if (this.a.HasChildFields)
			{
				aan[] array = new aan[A_0.Count];
				for (int i = 0; i < A_0.Count; i++)
				{
					array[i] = (aan)A_0[i];
				}
				PdfFormFieldList childFields = this.a.ChildFields;
				aan[] array2 = new aan[childFields.Count];
				for (int i = 0; i < childFields.Count; i++)
				{
					array2[i] = this.a(childFields[i], array);
				}
				ArrayList arrayList = new ArrayList(A_0.Count);
				arrayList.AddRange(array2);
				result = arrayList;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x0018C914 File Offset: 0x0018B914
		private new aan a(PdfFormField A_0, aan[] A_1)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].hb().l() == A_0.l())
				{
					return A_1[i];
				}
			}
			return null;
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x0018C95C File Offset: 0x0018B95C
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x0018C974 File Offset: 0x0018B974
		internal override bool he()
		{
			bool result;
			if (base.InheritsValue && base.Parent is aan)
			{
				result = ((aan)base.Parent).he();
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x06002ACE RID: 10958 RVA: 0x0018C9C4 File Offset: 0x0018B9C4
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
					result = this.c.b();
				}
			}
			else
			{
				result = this.a.GetValue();
			}
			return result;
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x0018CA30 File Offset: 0x0018BA30
		public override void set_Value(string value)
		{
			if (base.InheritsValue)
			{
				base.Parent.Value = value;
				this.c = null;
			}
			else
			{
				aaq aaq = this.a.a(value);
				this.c = aaq;
				this.b = true;
				base.Form.RequireLicense(13);
				base.Form.a(true);
			}
		}

		// Token: 0x06002AD0 RID: 10960 RVA: 0x0018CA9C File Offset: 0x0018BA9C
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
				if ((this.b && this.c != null) || (!this.b && this.a.u() != null))
				{
					writer.WriteName(86);
					if (this.b)
					{
						this.c.a().hz(writer);
					}
					else
					{
						this.a.u().hz(writer);
					}
				}
			}
			base.Form.a(writer, this.a.h());
			if (this.a.i() != null)
			{
				base.Form.a(writer, this.a.i());
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
			if (this.a.s() != null)
			{
				writer.WriteName(FormField.o);
				this.a.s().hz(writer);
			}
			if (!base.HasChildFields)
			{
				if (this.he())
				{
					writer.WriteName(FormField.p);
					if (this.c != null)
					{
						this.c.a().hz(writer);
					}
					else
					{
						string value = this.Value;
						aaq aaq = this.a.a(value);
						if (value != string.Empty && aaq != null)
						{
							aaq.a().hz(writer);
						}
						else
						{
							writer.WriteName(aan.f);
						}
					}
				}
				else if (this.a.t() != null)
				{
					writer.WriteName(FormField.p);
					this.a.t().hz(writer);
				}
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

		// Token: 0x06002AD1 RID: 10961 RVA: 0x0018CDC8 File Offset: 0x0018BDC8
		internal override void hc(PageWriter A_0, int A_1)
		{
			if (this.a.af())
			{
				if (this.a.s() != null)
				{
					string a_;
					if (this.he())
					{
						if (this.c != null)
						{
							a_ = this.c.a().j9();
						}
						else
						{
							string value = this.Value;
							aaq aaq = this.a.a(value);
							if (value != string.Empty && aaq != null)
							{
								a_ = aaq.a().j9();
							}
							else
							{
								a_ = "Off";
							}
						}
					}
					else if (this.a.t() != null)
					{
						a_ = this.a.t().j9();
					}
					else
					{
						a_ = this.a.GetValue();
					}
					afj afj = this.a.c(a_);
					if (afj != null)
					{
						this.e = afj.j4();
						if (this.e != null)
						{
							float a_2;
							float a_3;
							if (this.Rotate % 360 == 90 || this.Rotate % 360 == 270)
							{
								a_2 = this.a.Height;
								a_3 = this.a.Width;
							}
							else
							{
								a_2 = this.a.Width;
								a_3 = this.a.Height;
							}
							zh zh = A_0.DocumentWriter.v();
							zn zn = new zn(this, a_2, a_3, acp.d, A_0.DocumentWriter, zh);
							br br = zh.b(this.e.Length);
							br.a(this.e);
							zn.a(afj);
							zn.w();
							A_0.Write_q_();
							A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
							A_0.Write_Do(zn);
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

		// Token: 0x06002AD2 RID: 10962 RVA: 0x0018D040 File Offset: 0x0018C040
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
			zn zn;
			if (this.Value == "Yes")
			{
				zn = new zn(this, a_, a_2, acp.d, A_0.DocumentWriter, A_0.DocumentWriter.v());
			}
			else
			{
				zn = new zn(this, a_, a_2, acp.e, A_0.DocumentWriter, A_0.DocumentWriter.v());
			}
			zn.c();
			zn.p();
			zn.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
			A_0.Write_Do(zn);
			A_0.Write_Q();
		}

		// Token: 0x06002AD3 RID: 10963 RVA: 0x0018D194 File Offset: 0x0018C194
		public override RgbColor get_BackgroundColor()
		{
			return this.a.BackgroundColor;
		}

		// Token: 0x06002AD4 RID: 10964 RVA: 0x0018D1B4 File Offset: 0x0018C1B4
		public override DeviceColor get_BorderColor()
		{
			return this.a.BorderColor;
		}

		// Token: 0x06002AD5 RID: 10965 RVA: 0x0018D1D4 File Offset: 0x0018C1D4
		public override BorderStyle get_BorderStyle()
		{
			return this.a.BorderStyle;
		}

		// Token: 0x06002AD6 RID: 10966 RVA: 0x0018D1F4 File Offset: 0x0018C1F4
		public override int get_Rotate()
		{
			return this.a.Rotate;
		}

		// Token: 0x06002AD7 RID: 10967 RVA: 0x0018D214 File Offset: 0x0018C214
		public override DeviceColor get_TextColor()
		{
			return this.a.TextColor;
		}

		// Token: 0x06002AD8 RID: 10968 RVA: 0x0018D234 File Offset: 0x0018C234
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

		// Token: 0x06002AD9 RID: 10969 RVA: 0x0018D268 File Offset: 0x0018C268
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

		// Token: 0x040013B6 RID: 5046
		private new PdfButtonField a;

		// Token: 0x040013B7 RID: 5047
		private new bool b = false;

		// Token: 0x040013B8 RID: 5048
		private new aaq c = null;

		// Token: 0x040013B9 RID: 5049
		private new int d;

		// Token: 0x040013BA RID: 5050
		private new byte[] e = null;

		// Token: 0x040013BB RID: 5051
		private new static byte[] f = new byte[]
		{
			79,
			102,
			102
		};
	}
}
