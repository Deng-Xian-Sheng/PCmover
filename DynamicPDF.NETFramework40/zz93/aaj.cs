using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger.Forms;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020003F5 RID: 1013
	internal class aaj : CheckBoxField
	{
		// Token: 0x06002A40 RID: 10816 RVA: 0x00189218 File Offset: 0x00188218
		internal aaj(PdfButtonField A_0, int A_1) : base(A_0.Name, (int)A_0.Flags, null)
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

		// Token: 0x06002A41 RID: 10817 RVA: 0x001892AC File Offset: 0x001882AC
		internal override ArrayList hd(ArrayList A_0)
		{
			ArrayList result;
			if (this.a.HasChildFields)
			{
				aaj[] array = new aaj[A_0.Count];
				for (int i = 0; i < A_0.Count; i++)
				{
					array[i] = (aaj)A_0[i];
				}
				PdfFormFieldList childFields = this.a.ChildFields;
				aaj[] array2 = new aaj[childFields.Count];
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

		// Token: 0x06002A42 RID: 10818 RVA: 0x0018936C File Offset: 0x0018836C
		private new aaj a(PdfFormField A_0, aaj[] A_1)
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

		// Token: 0x06002A43 RID: 10819 RVA: 0x001893B4 File Offset: 0x001883B4
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
					string text = this.c.b();
					text = text.Replace("#20", " ");
					result = text;
				}
			}
			else
			{
				result = this.a.GetValue();
			}
			return result;
		}

		// Token: 0x06002A44 RID: 10820 RVA: 0x00189434 File Offset: 0x00188434
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

		// Token: 0x06002A45 RID: 10821 RVA: 0x001894A0 File Offset: 0x001884A0
		internal override bool he()
		{
			bool result;
			if (base.InheritsValue && base.Parent is aaj)
			{
				result = ((aaj)base.Parent).he();
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x06002A46 RID: 10822 RVA: 0x001894F0 File Offset: 0x001884F0
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x06002A47 RID: 10823 RVA: 0x00189508 File Offset: 0x00188508
		internal override Symbol hf()
		{
			return Symbol.Check;
		}

		// Token: 0x06002A48 RID: 10824 RVA: 0x0018951C File Offset: 0x0018851C
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
							writer.WriteName(aaj.f);
							this.b = false;
						}
					}
				}
				else if (this.a.t() != null)
				{
					writer.WriteName(FormField.p);
					this.a.t().hz(writer);
				}
			}
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

		// Token: 0x06002A49 RID: 10825 RVA: 0x00189850 File Offset: 0x00188850
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
							zk zk = new zk(this, a_2, a_3, acp.d, A_0.DocumentWriter, zh);
							br br = zh.b(this.e.Length);
							br.a(this.e);
							zk.a(afj);
							zk.w();
							A_0.Write_q_();
							A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
							A_0.Write_Do(zk);
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

		// Token: 0x06002A4A RID: 10826 RVA: 0x00189AC8 File Offset: 0x00188AC8
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
			zk zk;
			if (this.Value == "Yes")
			{
				zk = new zk(this, a_, a_2, acp.d, A_0.DocumentWriter, A_0.DocumentWriter.v());
			}
			else
			{
				zk = new zk(this, a_, a_2, acp.e, A_0.DocumentWriter, A_0.DocumentWriter.v());
			}
			zk.j();
			zk.p();
			zk.w();
			A_0.Write_q_();
			A_0.Write_cm(1f, 0f, 0f, 1f, this.a.z().b().ke(), A_0.Dimensions.ax(this.a.GetY(A_0.Document.Pages[A_1 - 1]) + this.a.Height));
			A_0.Write_Do(zk);
			A_0.Write_Q();
		}

		// Token: 0x06002A4B RID: 10827 RVA: 0x00189C1C File Offset: 0x00188C1C
		public override RgbColor get_BackgroundColor()
		{
			return this.a.BackgroundColor;
		}

		// Token: 0x06002A4C RID: 10828 RVA: 0x00189C3C File Offset: 0x00188C3C
		public override DeviceColor get_BorderColor()
		{
			return this.a.BorderColor;
		}

		// Token: 0x06002A4D RID: 10829 RVA: 0x00189C5C File Offset: 0x00188C5C
		public override BorderStyle get_BorderStyle()
		{
			return this.a.BorderStyle;
		}

		// Token: 0x06002A4E RID: 10830 RVA: 0x00189C7C File Offset: 0x00188C7C
		public override int get_Rotate()
		{
			return this.a.Rotate;
		}

		// Token: 0x06002A4F RID: 10831 RVA: 0x00189C9C File Offset: 0x00188C9C
		public override Font get_Font()
		{
			return Font.ZapfDingbats;
		}

		// Token: 0x06002A50 RID: 10832 RVA: 0x00189CB4 File Offset: 0x00188CB4
		public override float get_FontSize()
		{
			return 0f;
		}

		// Token: 0x06002A51 RID: 10833 RVA: 0x00189CCC File Offset: 0x00188CCC
		public override DeviceColor get_TextColor()
		{
			DeviceColor result;
			if (this.a.TextColor != null)
			{
				result = this.a.TextColor;
			}
			else
			{
				result = Grayscale.Black;
			}
			return result;
		}

		// Token: 0x04001371 RID: 4977
		private new PdfButtonField a;

		// Token: 0x04001372 RID: 4978
		private new bool b = false;

		// Token: 0x04001373 RID: 4979
		private new aaq c = null;

		// Token: 0x04001374 RID: 4980
		private new int d;

		// Token: 0x04001375 RID: 4981
		private new byte[] e = null;

		// Token: 0x04001376 RID: 4982
		private new static byte[] f = new byte[]
		{
			79,
			102,
			102
		};
	}
}
