using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007EF RID: 2031
	public class ListBox : ChoiceField
	{
		// Token: 0x06005279 RID: 21113 RVA: 0x0028DAC1 File Offset: 0x0028CAC1
		public ListBox(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x0600527A RID: 21114 RVA: 0x0028DAE4 File Offset: 0x0028CAE4
		// (set) Token: 0x0600527B RID: 21115 RVA: 0x0028DAFC File Offset: 0x0028CAFC
		public bool Multiselect
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

		// Token: 0x0600527C RID: 21116 RVA: 0x0028DB08 File Offset: 0x0028CB08
		public override void Draw(PageWriter writer)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			act act = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is act))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					act act2 = (act)formField;
					FormField formField2 = act2.a(formFieldList);
					((act)formField2).a(this);
					act.Name = "";
					formField2.ChildFields.Add(act);
				}
				else
				{
					((act)formField).a(this);
					act.Name = "";
					formField.ChildFields.Add(act);
				}
			}
			else
			{
				formFieldList.Add(act);
			}
			act.Output = base.Output;
			writer.Annotations.Add(act);
			base.a(writer, act);
			act.a((StructureElement)this.Tag);
		}

		// Token: 0x0600527D RID: 21117 RVA: 0x0028DC54 File Offset: 0x0028CC54
		internal override void cf(PageWriter A_0)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			act act = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is act))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					act act2 = (act)formField;
					FormField formField2 = act2.a(formFieldList);
					((act)formField2).a(this);
					act.Name = "";
					act.ce(A_0);
				}
				else
				{
					((act)formField).a(this);
					act.Name = "";
					act.ce(A_0);
				}
			}
			else
			{
				act.ce(A_0);
			}
		}

		// Token: 0x0600527E RID: 21118 RVA: 0x0028DD5C File Offset: 0x0028CD5C
		internal int a()
		{
			if (this.b == 0)
			{
				if (this.a)
				{
					this.b ^= 2097152;
				}
				if (base.NoExport)
				{
					this.b ^= 4;
				}
				if (base.ReadOnly)
				{
					this.b ^= 1;
				}
			}
			return this.b;
		}

		// Token: 0x0600527F RID: 21119 RVA: 0x0028DDDC File Offset: 0x0028CDDC
		private act a(string A_0, PageWriter A_1)
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
			return new act(A_0, this, a_5, a_6, a_2, a_, a_3, a_4, A_1.PageNumber);
		}

		// Token: 0x04002C18 RID: 11288
		private new bool a = false;

		// Token: 0x04002C19 RID: 11289
		private int b = 0;
	}
}
