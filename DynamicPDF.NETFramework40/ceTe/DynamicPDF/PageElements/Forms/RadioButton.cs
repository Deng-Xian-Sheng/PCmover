using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007F1 RID: 2033
	public class RadioButton : FormElement
	{
		// Token: 0x06005287 RID: 21127 RVA: 0x0028DFB4 File Offset: 0x0028CFB4
		public RadioButton(string name, float x, float y, float width, float height) : base(name, x, y, width, height)
		{
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06005288 RID: 21128 RVA: 0x0028E008 File Offset: 0x0028D008
		// (set) Token: 0x06005289 RID: 21129 RVA: 0x0028E020 File Offset: 0x0028D020
		public bool DefaultChecked
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

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x0600528A RID: 21130 RVA: 0x0028E02C File Offset: 0x0028D02C
		// (set) Token: 0x0600528B RID: 21131 RVA: 0x0028E044 File Offset: 0x0028D044
		public string ExportValue
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

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x0600528C RID: 21132 RVA: 0x0028E050 File Offset: 0x0028D050
		// (set) Token: 0x0600528D RID: 21133 RVA: 0x0028E068 File Offset: 0x0028D068
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

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x0600528E RID: 21134 RVA: 0x0028E074 File Offset: 0x0028D074
		// (set) Token: 0x0600528F RID: 21135 RVA: 0x0028E08C File Offset: 0x0028D08C
		public bool NoExport
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

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06005290 RID: 21136 RVA: 0x0028E098 File Offset: 0x0028D098
		// (set) Token: 0x06005291 RID: 21137 RVA: 0x0028E0B0 File Offset: 0x0028D0B0
		public bool RadiosInUnison
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

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06005292 RID: 21138 RVA: 0x0028E0BC File Offset: 0x0028D0BC
		// (set) Token: 0x06005293 RID: 21139 RVA: 0x0028E0D4 File Offset: 0x0028D0D4
		public Symbol Symbol
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

		// Token: 0x06005294 RID: 21140 RVA: 0x0028E0E0 File Offset: 0x0028D0E0
		public override void Draw(PageWriter writer)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = writer.Document.a(array, array.Length - 1);
			acu acu = this.a(text, writer);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acu))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acu acu2 = (acu)formField;
					acu acu3 = (acu)acu2.a(formFieldList);
					acu3.a(this.a());
					acu3.a(base.ToolTip);
					if (this.c)
					{
						acu3.a(this);
					}
					acu.Name = "";
					acu3.ChildFields.Add(acu);
				}
				else
				{
					acu acu3 = (acu)formField;
					acu3.a(this.a());
					acu3.a(base.ToolTip);
					if (this.c)
					{
						acu3.a(this);
					}
					acu.Name = "";
					acu3.ChildFields.Add(acu);
				}
			}
			else
			{
				formFieldList.Add(acu);
			}
			acu.Output = base.Output;
			writer.Annotations.Add(acu);
			base.a(writer, acu);
			acu.a((StructureElement)this.Tag);
		}

		// Token: 0x06005295 RID: 21141 RVA: 0x0028E288 File Offset: 0x0028D288
		internal override void cf(PageWriter A_0)
		{
			string[] array = base.Name.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			FormFieldList formFieldList = A_0.Document.a(array, array.Length - 1);
			acu acu = this.a(text, A_0);
			FormField formField = formFieldList[text];
			if (formField != null)
			{
				if (!(formField is acu))
				{
					throw new GeneratorException("Form Field with the same name already exist.");
				}
				if (!formField.HasChildFields)
				{
					formFieldList.Remove(formField);
					acu acu2 = (acu)formField;
					acu acu3 = (acu)acu2.a(formFieldList);
					acu3.a(this.a());
					acu3.a(base.ToolTip);
					if (this.c)
					{
						acu3.a(this);
					}
					acu.Name = "";
					acu.ce(A_0);
				}
				else
				{
					acu acu3 = (acu)formField;
					acu3.a(this.a());
					acu3.a(base.ToolTip);
					if (this.c)
					{
						acu3.a(this);
					}
					acu.Name = "";
					acu.ce(A_0);
				}
			}
			else
			{
				acu.ce(A_0);
			}
		}

		// Token: 0x06005296 RID: 21142 RVA: 0x0028E3EC File Offset: 0x0028D3EC
		internal int a()
		{
			if (this.f == 0)
			{
				this.f = 49152;
				if (this.a)
				{
					this.f ^= 2;
				}
				if (this.b)
				{
					this.f ^= 4;
				}
				if (this.d)
				{
					this.f ^= 33554432;
				}
				if (base.ReadOnly)
				{
					this.f ^= 1;
				}
			}
			return this.f;
		}

		// Token: 0x06005297 RID: 21143 RVA: 0x0028E494 File Offset: 0x0028D494
		internal Font b()
		{
			return Font.ZapfDingbats;
		}

		// Token: 0x06005298 RID: 21144 RVA: 0x0028E4AC File Offset: 0x0028D4AC
		internal float c()
		{
			return 0f;
		}

		// Token: 0x06005299 RID: 21145 RVA: 0x0028E4C4 File Offset: 0x0028D4C4
		private acu a(string A_0, PageWriter A_1)
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
			return new acu(A_0, this, a_5, a_6, a_2, a_, a_3, a_4, A_1.PageNumber);
		}

		// Token: 0x04002C1C RID: 11292
		private new bool a = false;

		// Token: 0x04002C1D RID: 11293
		private bool b = false;

		// Token: 0x04002C1E RID: 11294
		private bool c = false;

		// Token: 0x04002C1F RID: 11295
		private new bool d = false;

		// Token: 0x04002C20 RID: 11296
		private string e = "Yes";

		// Token: 0x04002C21 RID: 11297
		private int f = 0;

		// Token: 0x04002C22 RID: 11298
		private Symbol g = Symbol.Circle;
	}
}
