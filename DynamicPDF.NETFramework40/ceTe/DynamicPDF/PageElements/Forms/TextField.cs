using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007F5 RID: 2037
	public class TextField : FormElement
	{
		// Token: 0x060052A5 RID: 21157 RVA: 0x0028E8A0 File Offset: 0x0028D8A0
		public TextField(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x060052A6 RID: 21158 RVA: 0x0028E910 File Offset: 0x0028D910
		// (set) Token: 0x060052A7 RID: 21159 RVA: 0x0028E928 File Offset: 0x0028D928
		public Font Font
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x060052A8 RID: 21160 RVA: 0x0028E934 File Offset: 0x0028D934
		// (set) Token: 0x060052A9 RID: 21161 RVA: 0x0028E94C File Offset: 0x0028D94C
		public float FontSize
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x060052AA RID: 21162 RVA: 0x0028E958 File Offset: 0x0028D958
		// (set) Token: 0x060052AB RID: 21163 RVA: 0x0028E9C0 File Offset: 0x0028D9C0
		public string DefaultValue
		{
			get
			{
				if (this.c != null && this.i > 0)
				{
					if (this.c.Length > this.i)
					{
						this.c = this.c.Substring(0, this.i);
					}
				}
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x060052AC RID: 21164 RVA: 0x0028E9CC File Offset: 0x0028D9CC
		// (set) Token: 0x060052AD RID: 21165 RVA: 0x0028EA1C File Offset: 0x0028DA1C
		public int MaxLength
		{
			get
			{
				int num = this.i;
				if (num == 0 && this.f)
				{
					if (this.c != null)
					{
						num = this.c.Length;
					}
					else
					{
						num = 10;
					}
				}
				return num;
			}
			set
			{
				if (value < 1 || value > 1000000000)
				{
					throw new GeneratorException("The value must be between 1 and 1000000000.");
				}
				this.i = value;
			}
		}

		// Token: 0x17000762 RID: 1890
		// (set) Token: 0x060052AE RID: 21166 RVA: 0x0028EA53 File Offset: 0x0028DA53
		public Align TextAlign
		{
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x060052AF RID: 21167 RVA: 0x0028EA60 File Offset: 0x0028DA60
		// (set) Token: 0x060052B0 RID: 21168 RVA: 0x0028EA78 File Offset: 0x0028DA78
		public bool Password
		{
			get
			{
				return this.e;
			}
			set
			{
				if (value)
				{
					this.d = false;
					this.f = false;
				}
				this.e = value;
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x060052B1 RID: 21169 RVA: 0x0028EAA8 File Offset: 0x0028DAA8
		// (set) Token: 0x060052B2 RID: 21170 RVA: 0x0028EAC0 File Offset: 0x0028DAC0
		public bool MultiLine
		{
			get
			{
				return this.d;
			}
			set
			{
				if (value)
				{
					this.e = false;
					this.f = false;
				}
				this.d = value;
			}
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x060052B3 RID: 21171 RVA: 0x0028EAF0 File Offset: 0x0028DAF0
		// (set) Token: 0x060052B4 RID: 21172 RVA: 0x0028EB08 File Offset: 0x0028DB08
		public bool Comb
		{
			get
			{
				return this.f;
			}
			set
			{
				if (value)
				{
					this.d = false;
					this.e = false;
				}
				this.f = value;
			}
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x060052B5 RID: 21173 RVA: 0x0028EB38 File Offset: 0x0028DB38
		// (set) Token: 0x060052B6 RID: 21174 RVA: 0x0028EB50 File Offset: 0x0028DB50
		public bool Required
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

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x060052B7 RID: 21175 RVA: 0x0028EB5C File Offset: 0x0028DB5C
		// (set) Token: 0x060052B8 RID: 21176 RVA: 0x0028EB74 File Offset: 0x0028DB74
		public bool NoExport
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

		// Token: 0x060052B9 RID: 21177 RVA: 0x0028EB80 File Offset: 0x0028DB80
		public override void Draw(PageWriter writer)
		{
			if (this.a is OpenTypeFont && ((OpenTypeFont)this.a).a() is ad3)
			{
				if (writer.Document.PdfVersion == PdfVersion.v1_3 || writer.Document.PdfVersion == PdfVersion.v1_4 || writer.Document.PdfVersion == PdfVersion.v1_5)
				{
					throw new GeneratorException("The PDF version should be greater than or equal to 1.6");
				}
			}
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			acv acv = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acv))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acv acv2 = (acv)formField;
					FormField formField2 = acv2.a(formFieldList);
					((acv)formField2).a(this);
					acv.Name = "";
					formField2.ChildFields.Add(acv);
				}
				else
				{
					((acv)formField).a(this);
					acv.Name = "";
					formField.ChildFields.Add(acv);
				}
			}
			else
			{
				formFieldList.Add(acv);
			}
			acv.Output = base.Output;
			writer.Annotations.Add(acv);
			base.a(writer, acv);
			acv.a((StructureElement)this.Tag);
		}

		// Token: 0x060052BA RID: 21178 RVA: 0x0028ED44 File Offset: 0x0028DD44
		internal override void cf(PageWriter A_0)
		{
			if (this.a is OpenTypeFont && ((OpenTypeFont)this.a).a() is ad3)
			{
				if (A_0.Document.PdfVersion == PdfVersion.v1_3 || A_0.Document.PdfVersion == PdfVersion.v1_4 || A_0.Document.PdfVersion == PdfVersion.v1_5)
				{
					throw new GeneratorException("The PDF version should be greater than or equal to 1.6");
				}
			}
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			acv acv = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acv))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acv acv2 = (acv)formField;
					FormField formField2 = acv2.a(formFieldList);
					((acv)formField2).a(this);
					acv.Name = "";
					acv.ce(A_0);
				}
				else
				{
					((acv)formField).a(this);
					acv.Name = "";
					acv.ce(A_0);
				}
			}
			else
			{
				acv.ce(A_0);
			}
		}

		// Token: 0x060052BB RID: 21179 RVA: 0x0028EEC4 File Offset: 0x0028DEC4
		internal int a()
		{
			if (this.k == 0)
			{
				if (this.d)
				{
					this.k ^= 4096;
				}
				if (this.e)
				{
					this.k ^= 4202496;
				}
				if (this.f)
				{
					this.k ^= 29360128;
				}
				if (base.ReadOnly)
				{
					this.k ^= 1;
				}
				if (this.g)
				{
					this.k ^= 2;
				}
				if (this.h)
				{
					this.k ^= 4;
				}
			}
			return this.k;
		}

		// Token: 0x060052BC RID: 21180 RVA: 0x0028EFA0 File Offset: 0x0028DFA0
		internal FormFieldAlign b()
		{
			FormFieldAlign result;
			switch (this.j)
			{
			case Align.Center:
				result = FormFieldAlign.Center;
				break;
			case Align.Right:
				result = FormFieldAlign.Right;
				break;
			default:
				result = FormFieldAlign.Left;
				break;
			}
			return result;
		}

		// Token: 0x060052BD RID: 21181 RVA: 0x0028EFD4 File Offset: 0x0028DFD4
		private acv a(string A_0, PageWriter A_1)
		{
			float a_ = A_1.Dimensions.aw(base.X);
			float a_2 = A_1.Dimensions.ax(base.Y);
			float a_3;
			float a_4;
			float a_5;
			float a_6;
			if (base.Rotate % 360 == 90 || base.Rotate % 360 == 270)
			{
				a_3 = A_1.Dimensions.aw(base.X + base.Height);
				a_4 = A_1.Dimensions.ax(base.Y + base.Width);
				a_5 = base.Width * A_1.Dimensions.a0();
				a_6 = base.Height * A_1.Dimensions.az();
			}
			else
			{
				a_3 = A_1.Dimensions.aw(base.X + base.Width);
				a_4 = A_1.Dimensions.ax(base.Y + base.Height);
				a_5 = base.Width * A_1.Dimensions.az();
				a_6 = base.Height * A_1.Dimensions.a0();
			}
			return new acv(A_0, this, a_5, a_6, a_2, a_, a_3, a_4, A_1.PageNumber);
		}

		// Token: 0x04002C32 RID: 11314
		private new Font a = null;

		// Token: 0x04002C33 RID: 11315
		private float b = 0f;

		// Token: 0x04002C34 RID: 11316
		private string c = null;

		// Token: 0x04002C35 RID: 11317
		private new bool d = false;

		// Token: 0x04002C36 RID: 11318
		private bool e = false;

		// Token: 0x04002C37 RID: 11319
		private bool f = false;

		// Token: 0x04002C38 RID: 11320
		private bool g = false;

		// Token: 0x04002C39 RID: 11321
		private bool h = false;

		// Token: 0x04002C3A RID: 11322
		private int i = 0;

		// Token: 0x04002C3B RID: 11323
		private Align j = Align.Left;

		// Token: 0x04002C3C RID: 11324
		private int k = 0;
	}
}
