using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x02000451 RID: 1105
	internal class acu : RadioButtonField
	{
		// Token: 0x06002D8B RID: 11659 RVA: 0x0019E100 File Offset: 0x0019D100
		protected internal acu(string A_0, RadioButton A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8) : base(A_0, A_1.a(), A_1.ReaderEvents)
		{
			if (A_1.ToolTip != null)
			{
				base.AlternateName = A_1.ToolTip;
			}
			if (A_1.MappingName != null)
			{
				base.MappingName = A_1.MappingName;
			}
			this.f = A_1;
			this.h = A_2;
			this.i = A_3;
			this.d = A_7;
			this.a = A_5;
			this.b = A_6;
			this.c = A_4;
			this.e = A_8;
		}

		// Token: 0x06002D8C RID: 11660 RVA: 0x0019E1B4 File Offset: 0x0019D1B4
		internal acu(string A_0, RadioButton A_1) : base(A_0, A_1.a(), A_1.ReaderEvents)
		{
			if (A_1.ToolTip != null)
			{
				base.AlternateName = A_1.ToolTip;
			}
			if (A_1.MappingName != null)
			{
				base.MappingName = A_1.MappingName;
			}
			this.f = A_1;
		}

		// Token: 0x06002D8D RID: 11661 RVA: 0x0019E230 File Offset: 0x0019D230
		private new bool a()
		{
			bool result;
			if (base.Parent is acu && base.InheritsName)
			{
				bool flag = ((acu)base.Parent).c().ExportValue == this.f.ExportValue;
				if (flag)
				{
					result = (flag && ((acu)base.Parent).c().DefaultChecked);
				}
				else
				{
					result = (flag && this.f.DefaultChecked);
				}
			}
			else
			{
				result = this.f.DefaultChecked;
			}
			return result;
		}

		// Token: 0x06002D8E RID: 11662 RVA: 0x0019E2CE File Offset: 0x0019D2CE
		internal new void a(int A_0)
		{
			base.b(A_0);
		}

		// Token: 0x06002D8F RID: 11663 RVA: 0x0019E2DC File Offset: 0x0019D2DC
		internal new void a(string A_0)
		{
			if (A_0 != null)
			{
				this.AlternateName = A_0;
			}
		}

		// Token: 0x06002D90 RID: 11664 RVA: 0x0019E2FC File Offset: 0x0019D2FC
		internal new FormField a(FormFieldList A_0)
		{
			if (this.g == null)
			{
				this.g = new acu(this.Name, this.f);
				A_0.Add(this.g);
				base.f();
				this.g.ChildFields.Add(this);
			}
			return this.g;
		}

		// Token: 0x06002D91 RID: 11665 RVA: 0x0019E364 File Offset: 0x0019D364
		internal new RadioButton c()
		{
			return this.f;
		}

		// Token: 0x06002D92 RID: 11666 RVA: 0x0019E37C File Offset: 0x0019D37C
		internal new void a(RadioButton A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06002D93 RID: 11667 RVA: 0x0019E388 File Offset: 0x0019D388
		internal override Symbol i7()
		{
			return this.f.Symbol;
		}

		// Token: 0x06002D94 RID: 11668 RVA: 0x0019E3A8 File Offset: 0x0019D3A8
		protected override void DrawDictionary(DocumentWriter writer)
		{
			base.DrawDictionary(writer);
			if (!base.InheritsValue)
			{
				if (this.a())
				{
					writer.WriteName(FormField.ad);
					writer.WriteName(this.f.ExportValue);
					writer.WriteName(FormField.w);
					writer.WriteName(this.f.ExportValue);
				}
			}
			if (!base.HasChildFields)
			{
				writer.WriteName(Resource.a);
				writer.WriteName(FormField.q);
				writer.WriteName(Resource.b);
				writer.WriteName(FormField.r);
				if (this.f.d() != aco.a)
				{
					writer.WriteName(FormField.y);
					writer.WriteNumber((int)this.f.d());
				}
				writer.WriteName(FormField.z);
				writer.WriteReferenceShallow(writer.GetPageObject(this.e));
				writer.WriteName(FormField.s);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.a);
				writer.WriteNumber(this.c);
				writer.WriteNumber(this.b);
				writer.WriteNumber(this.d);
				writer.WriteArrayClose();
				if (this.f.BorderStyle != null)
				{
					this.f.BorderStyle.Draw(writer);
				}
				this.c(writer);
				this.b(writer);
				if (!base.Form.NeedsAppearances)
				{
					this.a(writer);
				}
			}
			if (writer.Document.Tag != null && this.b() != -1)
			{
				if (this.f.Visible)
				{
					base.i().a(writer, this.b());
				}
			}
		}

		// Token: 0x06002D95 RID: 11669 RVA: 0x0019E588 File Offset: 0x0019D588
		private new void c(DocumentWriter A_0)
		{
			A_0.WriteName(FormField.t);
			A_0.WriteDictionaryOpen();
			int num = this.f.Rotate % 360;
			if (num > 0)
			{
				A_0.WriteName(FormField.aa);
				A_0.WriteNumber(num);
			}
			if (this.f.BorderColor != null)
			{
				A_0.WriteName(FormField.u);
				this.f.BorderColor.gr(A_0);
			}
			if (this.f.BackgroundColor != null)
			{
				A_0.WriteName(FormField.v);
				this.f.BackgroundColor.gr(A_0);
			}
			A_0.WriteName(ButtonField.b);
			A_0.WriteText(new byte[]
			{
				(byte)this.f.Symbol
			});
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002D96 RID: 11670 RVA: 0x0019E674 File Offset: 0x0019D674
		private new void b(DocumentWriter A_0)
		{
			base.Form.e().a(this.f.b());
			base.Form.b(A_0);
			base.Form.a(A_0, this.f.b(), this.f.c(), this.f.TextColor);
		}

		// Token: 0x06002D97 RID: 11671 RVA: 0x0019E6DC File Offset: 0x0019D6DC
		private new void a(DocumentWriter A_0)
		{
			string text = this.f.ExportValue;
			text = text.Replace("#", "#23");
			text = text.Replace(" ", "#20");
			text = text.Replace("/", "#2F");
			text = text.Replace("(", "#28");
			text = text.Replace(")", "#29");
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(text);
			zn a_ = new zn(this, this.h, this.i, acp.d, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteName(acu.j);
			a_ = new zn(this, this.h, this.i, acp.e, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteDictionaryClose();
			A_0.WriteName(FormField.ac);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(text);
			a_ = new zn(this, this.h, this.i, acp.f, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteName(acu.j);
			a_ = new zn(this, this.h, this.i, acp.g, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteDictionaryClose();
			A_0.WriteDictionaryClose();
			if (this.a())
			{
				A_0.WriteName(FormField.p);
				A_0.WriteName(this.f.ExportValue);
			}
			else
			{
				A_0.WriteName(FormField.p);
				A_0.WriteName(acu.j);
			}
		}

		// Token: 0x06002D98 RID: 11672 RVA: 0x0019E89A File Offset: 0x0019D89A
		private new void a(zn A_0, DocumentWriter A_1)
		{
			A_0.c();
			A_0.w();
			A_1.WriteReference(A_1.Resources.Add(A_0));
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x0019E8C0 File Offset: 0x0019D8C0
		internal override void ce(PageWriter A_0)
		{
			if (this.f.Visible)
			{
				zh a_ = A_0.DocumentWriter.v();
				zn zn;
				if (this.f.DefaultChecked)
				{
					zn = new zn(this, this.h, this.i, acp.d, A_0.DocumentWriter, a_);
				}
				else
				{
					zn = new zn(this, this.h, this.i, acp.e, A_0.DocumentWriter, a_);
				}
				zn.c();
				zn.w();
				A_0.Write_q_();
				A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(this.f.X), A_0.Dimensions.ax(this.f.Y + this.f.Height));
				int num = this.f.Rotate % 360;
				if (num > 0 && (num == 90 || num == 270))
				{
					A_0.Write_cm(1f, 0f, 0f, 1f, 0f, -(this.f.Width - this.f.Height));
				}
				A_0.Write_Do(zn);
				A_0.Write_Q();
			}
		}

		// Token: 0x06002D9A RID: 11674 RVA: 0x0019EA24 File Offset: 0x0019DA24
		public override Font get_Font()
		{
			return this.f.b();
		}

		// Token: 0x06002D9B RID: 11675 RVA: 0x0019EA44 File Offset: 0x0019DA44
		public override float get_FontSize()
		{
			return this.f.c();
		}

		// Token: 0x06002D9C RID: 11676 RVA: 0x0019EA64 File Offset: 0x0019DA64
		public override BorderStyle get_BorderStyle()
		{
			return this.f.BorderStyle;
		}

		// Token: 0x06002D9D RID: 11677 RVA: 0x0019EA84 File Offset: 0x0019DA84
		public override DeviceColor get_BorderColor()
		{
			return this.f.BorderColor;
		}

		// Token: 0x06002D9E RID: 11678 RVA: 0x0019EAA4 File Offset: 0x0019DAA4
		public override RgbColor get_BackgroundColor()
		{
			return this.f.BackgroundColor;
		}

		// Token: 0x06002D9F RID: 11679 RVA: 0x0019EAC4 File Offset: 0x0019DAC4
		public override DeviceColor get_TextColor()
		{
			return this.f.TextColor;
		}

		// Token: 0x06002DA0 RID: 11680 RVA: 0x0019EAE4 File Offset: 0x0019DAE4
		public override int get_Rotate()
		{
			return this.f.Rotate;
		}

		// Token: 0x040015A5 RID: 5541
		private new float a;

		// Token: 0x040015A6 RID: 5542
		private new float b;

		// Token: 0x040015A7 RID: 5543
		private new float c;

		// Token: 0x040015A8 RID: 5544
		private new float d;

		// Token: 0x040015A9 RID: 5545
		private new int e;

		// Token: 0x040015AA RID: 5546
		private new RadioButton f;

		// Token: 0x040015AB RID: 5547
		private new FormField g = null;

		// Token: 0x040015AC RID: 5548
		private new float h = 0f;

		// Token: 0x040015AD RID: 5549
		private new float i = 0f;

		// Token: 0x040015AE RID: 5550
		private static byte[] j = new byte[]
		{
			79,
			102,
			102
		};
	}
}
