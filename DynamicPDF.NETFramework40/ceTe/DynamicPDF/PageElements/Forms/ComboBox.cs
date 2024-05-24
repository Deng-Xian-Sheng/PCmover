using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007ED RID: 2029
	public class ComboBox : ChoiceField
	{
		// Token: 0x06005270 RID: 21104 RVA: 0x0028D608 File Offset: 0x0028C608
		public ComboBox(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06005271 RID: 21105 RVA: 0x0028D630 File Offset: 0x0028C630
		// (set) Token: 0x06005272 RID: 21106 RVA: 0x0028D648 File Offset: 0x0028C648
		public bool Editable
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

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06005273 RID: 21107 RVA: 0x0028D654 File Offset: 0x0028C654
		// (set) Token: 0x06005274 RID: 21108 RVA: 0x0028D66C File Offset: 0x0028C66C
		public bool Required
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

		// Token: 0x06005275 RID: 21109 RVA: 0x0028D678 File Offset: 0x0028C678
		public override void Draw(PageWriter writer)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			acs acs = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acs))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acs acs2 = (acs)formField;
					FormField formField2 = acs2.a(formFieldList);
					((acs)formField2).a(this);
					acs.Name = "";
					formField2.ChildFields.Add(acs);
				}
				else
				{
					((acs)formField).a(this);
					acs.Name = "";
					formField.ChildFields.Add(acs);
				}
			}
			else
			{
				formFieldList.Add(acs);
			}
			acs.Output = base.Output;
			writer.Annotations.Add(acs);
			base.a(writer, acs);
			acs.a((StructureElement)this.Tag);
		}

		// Token: 0x06005276 RID: 21110 RVA: 0x0028D7C4 File Offset: 0x0028C7C4
		internal override void cf(PageWriter A_0)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			acs acs = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acs))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acs acs2 = (acs)formField;
					FormField formField2 = acs2.a(formFieldList);
					((acs)formField2).a(this);
					acs.Name = "";
					acs.ce(A_0);
				}
				else
				{
					((acs)formField).a(this);
					acs.Name = "";
					acs.ce(A_0);
				}
			}
			else
			{
				acs.ce(A_0);
			}
		}

		// Token: 0x06005277 RID: 21111 RVA: 0x0028D8CC File Offset: 0x0028C8CC
		internal int a()
		{
			if (this.c == 0)
			{
				this.c = 131072;
				if (this.b)
				{
					this.c ^= 262144;
				}
				if (this.a)
				{
					this.c ^= 2;
				}
				if (base.NoExport)
				{
					this.c ^= 4;
				}
				if (base.ReadOnly)
				{
					this.c ^= 1;
				}
			}
			return this.c;
		}

		// Token: 0x06005278 RID: 21112 RVA: 0x0028D974 File Offset: 0x0028C974
		private acs a(string A_0, PageWriter A_1)
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
			return new acs(A_0, this, a_5, a_6, a_2, a_, a_3, a_4, A_1.PageNumber);
		}

		// Token: 0x04002C0F RID: 11279
		private new bool a = false;

		// Token: 0x04002C10 RID: 11280
		private bool b = false;

		// Token: 0x04002C11 RID: 11281
		private int c = 0;
	}
}
