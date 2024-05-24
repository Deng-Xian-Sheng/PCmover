using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007EA RID: 2026
	public class Button : FormElement
	{
		// Token: 0x06005249 RID: 21065 RVA: 0x0028C9D4 File Offset: 0x0028B9D4
		public Button(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
			base.BackgroundColor = RgbColor.LightGrey;
		}

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x0600524A RID: 21066 RVA: 0x0028CA34 File Offset: 0x0028BA34
		// (set) Token: 0x0600524B RID: 21067 RVA: 0x0028CA4C File Offset: 0x0028BA4C
		public Font Font
		{
			get
			{
				return this.d;
			}
			set
			{
				if (value != null)
				{
					this.d = value;
				}
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x0600524C RID: 21068 RVA: 0x0028CA6C File Offset: 0x0028BA6C
		// (set) Token: 0x0600524D RID: 21069 RVA: 0x0028CA84 File Offset: 0x0028BA84
		public float FontSize
		{
			get
			{
				return this.c;
			}
			set
			{
				if (value > 0f)
				{
					this.c = value;
				}
			}
		}

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x0600524E RID: 21070 RVA: 0x0028CAA8 File Offset: 0x0028BAA8
		// (set) Token: 0x0600524F RID: 21071 RVA: 0x0028CAC0 File Offset: 0x0028BAC0
		public string Label
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

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x06005250 RID: 21072 RVA: 0x0028CACC File Offset: 0x0028BACC
		// (set) Token: 0x06005251 RID: 21073 RVA: 0x0028CAE4 File Offset: 0x0028BAE4
		public Behavior Behavior
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06005252 RID: 21074 RVA: 0x0028CAF0 File Offset: 0x0028BAF0
		// (set) Token: 0x06005253 RID: 21075 RVA: 0x0028CB08 File Offset: 0x0028BB08
		public Action Action
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

		// Token: 0x06005254 RID: 21076 RVA: 0x0028CB14 File Offset: 0x0028BB14
		public override void Draw(PageWriter writer)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			acq acq = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acq))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acq acq2 = (acq)formField;
					acq acq3 = (acq)acq2.a(formFieldList);
					acq3.a(this.a());
					acq3.a(base.ToolTip);
					acq.Name = "";
					acq3.ChildFields.Add(acq);
				}
				else
				{
					acq acq3 = (acq)formField;
					acq3.a(this.a());
					acq3.a(base.ToolTip);
					acq.Name = "";
					acq3.ChildFields.Add(acq);
				}
			}
			else
			{
				formFieldList.Add(acq);
			}
			acq.Output = base.Output;
			writer.Annotations.Add(acq);
			base.a(writer, acq);
			acq.a((StructureElement)this.Tag);
		}

		// Token: 0x06005255 RID: 21077 RVA: 0x0028CC8C File Offset: 0x0028BC8C
		internal override void cf(PageWriter A_0)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			acq acq = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acq))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acq acq2 = (acq)formField;
					acq acq3 = (acq)acq2.a(formFieldList);
					acq3.a(this.a());
					acq3.a(base.ToolTip);
					acq.Name = "";
					acq.ce(A_0);
				}
				else
				{
					acq acq3 = (acq)formField;
					acq3.a(this.a());
					acq3.a(base.ToolTip);
					acq.Name = "";
					acq.ce(A_0);
				}
			}
			else
			{
				acq.ce(A_0);
			}
		}

		// Token: 0x06005256 RID: 21078 RVA: 0x0028CDC0 File Offset: 0x0028BDC0
		internal int a()
		{
			if (this.f == 0)
			{
				this.f = 65536;
				if (base.ReadOnly)
				{
					this.f ^= 1;
				}
			}
			return this.f;
		}

		// Token: 0x06005257 RID: 21079 RVA: 0x0028CE10 File Offset: 0x0028BE10
		private acq a(string A_0, PageWriter A_1)
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
			return new acq(A_0, this, a_5, a_6, a_2, a_, a_3, a_4, A_1.PageNumber);
		}

		// Token: 0x04002BFF RID: 11263
		private new string a = null;

		// Token: 0x04002C00 RID: 11264
		private Action b = null;

		// Token: 0x04002C01 RID: 11265
		private float c = 0f;

		// Token: 0x04002C02 RID: 11266
		private new Font d = Font.HelveticaBold;

		// Token: 0x04002C03 RID: 11267
		private Behavior e = Behavior.Invert;

		// Token: 0x04002C04 RID: 11268
		private int f = 0;
	}
}
