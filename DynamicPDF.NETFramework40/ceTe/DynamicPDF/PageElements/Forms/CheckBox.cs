using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007EB RID: 2027
	public class CheckBox : FormElement
	{
		// Token: 0x06005258 RID: 21080 RVA: 0x0028CF60 File Offset: 0x0028BF60
		public CheckBox(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06005259 RID: 21081 RVA: 0x0028CFB0 File Offset: 0x0028BFB0
		// (set) Token: 0x0600525A RID: 21082 RVA: 0x0028CFC8 File Offset: 0x0028BFC8
		public float FontSize
		{
			get
			{
				return this.f;
			}
			set
			{
				if (value >= 0f)
				{
					this.f = value;
				}
			}
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x0600525B RID: 21083 RVA: 0x0028CFEC File Offset: 0x0028BFEC
		// (set) Token: 0x0600525C RID: 21084 RVA: 0x0028D004 File Offset: 0x0028C004
		public bool DefaultChecked
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

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x0600525D RID: 21085 RVA: 0x0028D010 File Offset: 0x0028C010
		// (set) Token: 0x0600525E RID: 21086 RVA: 0x0028D028 File Offset: 0x0028C028
		public string ExportValue
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x0600525F RID: 21087 RVA: 0x0028D034 File Offset: 0x0028C034
		// (set) Token: 0x06005260 RID: 21088 RVA: 0x0028D04C File Offset: 0x0028C04C
		public Symbol Symbol
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

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06005261 RID: 21089 RVA: 0x0028D058 File Offset: 0x0028C058
		// (set) Token: 0x06005262 RID: 21090 RVA: 0x0028D070 File Offset: 0x0028C070
		public bool NoExport
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

		// Token: 0x06005263 RID: 21091 RVA: 0x0028D07C File Offset: 0x0028C07C
		public override void Draw(PageWriter writer)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			acr acr = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acr))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acr acr2 = (acr)formField;
					acr acr3 = (acr)acr2.a(formFieldList);
					acr3.a(this.b());
					acr3.a(base.ToolTip);
					if (this.b)
					{
						acr3.a(this);
					}
					acr.Name = "";
					acr3.ChildFields.Add(acr);
				}
				else
				{
					acr acr3 = (acr)formField;
					acr3.a(this.b());
					acr3.a(base.ToolTip);
					if (this.b)
					{
						acr3.a(this);
					}
					acr.Name = "";
					acr3.ChildFields.Add(acr);
				}
			}
			else
			{
				formFieldList.Add(acr);
			}
			acr.Output = base.Output;
			writer.Annotations.Add(acr);
			base.a(writer, acr);
			acr.a((StructureElement)this.Tag);
		}

		// Token: 0x06005264 RID: 21092 RVA: 0x0028D224 File Offset: 0x0028C224
		internal override void cf(PageWriter A_0)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			acr acr = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acr))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acr acr2 = (acr)formField;
					acr acr3 = (acr)acr2.a(formFieldList);
					acr3.a(this.b());
					acr3.a(base.ToolTip);
					if (this.b)
					{
						acr3.a(this);
					}
					acr.Name = "";
					acr.ce(A_0);
				}
				else
				{
					acr acr3 = (acr)formField;
					acr3.a(this.b());
					acr3.a(base.ToolTip);
					if (this.b)
					{
						acr3.a(this);
					}
					acr.Name = "";
					acr.ce(A_0);
				}
			}
			else
			{
				acr.ce(A_0);
			}
		}

		// Token: 0x06005265 RID: 21093 RVA: 0x0028D388 File Offset: 0x0028C388
		internal Font a()
		{
			return Font.ZapfDingbats;
		}

		// Token: 0x06005266 RID: 21094 RVA: 0x0028D3A0 File Offset: 0x0028C3A0
		internal int b()
		{
			if (this.e == 0)
			{
				if (this.a)
				{
					this.e ^= 4;
				}
				if (base.ReadOnly)
				{
					this.e ^= 1;
				}
			}
			return this.e;
		}

		// Token: 0x06005267 RID: 21095 RVA: 0x0028D400 File Offset: 0x0028C400
		private acr a(string A_0, PageWriter A_1)
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
			return new acr(A_0, this, a_5, a_6, a_2, a_, a_3, a_4, A_1.PageNumber);
		}

		// Token: 0x04002C05 RID: 11269
		private new bool a = false;

		// Token: 0x04002C06 RID: 11270
		private bool b = false;

		// Token: 0x04002C07 RID: 11271
		private string c = "Yes";

		// Token: 0x04002C08 RID: 11272
		private new Symbol d = Symbol.Check;

		// Token: 0x04002C09 RID: 11273
		private int e = 0;

		// Token: 0x04002C0A RID: 11274
		private float f = 0f;
	}
}
