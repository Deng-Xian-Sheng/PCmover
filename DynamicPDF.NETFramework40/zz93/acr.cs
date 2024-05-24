using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x0200044E RID: 1102
	internal class acr : CheckBoxField
	{
		// Token: 0x06002D47 RID: 11591 RVA: 0x0019BDF0 File Offset: 0x0019ADF0
		internal acr(string A_0, CheckBox A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8) : base(A_0, A_1.b(), A_1.ReaderEvents)
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

		// Token: 0x06002D48 RID: 11592 RVA: 0x0019BEA4 File Offset: 0x0019AEA4
		internal acr(string A_0, CheckBox A_1) : base(A_0, A_1.b(), A_1.ReaderEvents)
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

		// Token: 0x06002D49 RID: 11593 RVA: 0x0019BF20 File Offset: 0x0019AF20
		internal new bool a()
		{
			bool result;
			if (base.Parent is acr && base.InheritsName)
			{
				result = (((acr)base.Parent).c().ExportValue == this.f.ExportValue && this.f.DefaultChecked);
			}
			else
			{
				result = this.f.DefaultChecked;
			}
			return result;
		}

		// Token: 0x06002D4A RID: 11594 RVA: 0x0019BF94 File Offset: 0x0019AF94
		internal new void a(int A_0)
		{
			base.b(A_0);
		}

		// Token: 0x06002D4B RID: 11595 RVA: 0x0019BFA0 File Offset: 0x0019AFA0
		internal new void a(string A_0)
		{
			if (A_0 != null)
			{
				this.AlternateName = A_0;
			}
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x0019BFC0 File Offset: 0x0019AFC0
		internal new FormField a(FormFieldList A_0)
		{
			if (this.g == null)
			{
				this.g = new acr(this.Name, this.f);
				A_0.Add(this.g);
				base.f();
				this.g.ChildFields.Add(this);
			}
			return this.g;
		}

		// Token: 0x06002D4D RID: 11597 RVA: 0x0019C028 File Offset: 0x0019B028
		internal new CheckBox c()
		{
			return this.f;
		}

		// Token: 0x06002D4E RID: 11598 RVA: 0x0019C040 File Offset: 0x0019B040
		internal new void a(CheckBox A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06002D4F RID: 11599 RVA: 0x0019C04C File Offset: 0x0019B04C
		internal override Symbol hf()
		{
			return this.f.Symbol;
		}

		// Token: 0x06002D50 RID: 11600 RVA: 0x0019C06C File Offset: 0x0019B06C
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

		// Token: 0x06002D51 RID: 11601 RVA: 0x0019C24C File Offset: 0x0019B24C
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

		// Token: 0x06002D52 RID: 11602 RVA: 0x0019C338 File Offset: 0x0019B338
		private new void b(DocumentWriter A_0)
		{
			base.Form.e().a(this.f.a());
			base.Form.b(A_0);
			base.Form.a(A_0, this.f.a(), this.f.FontSize, this.f.TextColor);
		}

		// Token: 0x06002D53 RID: 11603 RVA: 0x0019C3A0 File Offset: 0x0019B3A0
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
			zk a_ = new zk(this, this.h, this.i, acp.d, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteName(acr.j);
			a_ = new zk(this, this.h, this.i, acp.e, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteDictionaryClose();
			A_0.WriteName(FormField.ac);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(text);
			a_ = new zk(this, this.h, this.i, acp.f, A_0, A_0.u());
			this.a(a_, A_0);
			A_0.WriteName(acr.j);
			a_ = new zk(this, this.h, this.i, acp.g, A_0, A_0.u());
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
				A_0.WriteName(acr.j);
			}
		}

		// Token: 0x06002D54 RID: 11604 RVA: 0x0019C55E File Offset: 0x0019B55E
		private new void a(zk A_0, DocumentWriter A_1)
		{
			A_0.j();
			A_0.w();
			A_1.WriteReference(A_1.Resources.Add(A_0));
		}

		// Token: 0x06002D55 RID: 11605 RVA: 0x0019C584 File Offset: 0x0019B584
		internal override void ce(PageWriter A_0)
		{
			if (this.f.Visible)
			{
				zh a_ = A_0.DocumentWriter.v();
				zk zk;
				if (this.f.DefaultChecked)
				{
					zk = new zk(this, this.h, this.i, acp.d, A_0.DocumentWriter, a_);
				}
				else
				{
					zk = new zk(this, this.h, this.i, acp.e, A_0.DocumentWriter, a_);
				}
				zk.j();
				zk.w();
				A_0.Write_q_();
				A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(this.f.X), A_0.Dimensions.ax(this.f.Y + this.f.Height));
				int num = this.f.Rotate % 360;
				if (num > 0 && (num == 90 || num == 270))
				{
					A_0.Write_cm(1f, 0f, 0f, 1f, 0f, -(this.f.Width - this.f.Height));
				}
				A_0.Write_Do(zk);
				A_0.Write_Q();
			}
		}

		// Token: 0x06002D56 RID: 11606 RVA: 0x0019C6E8 File Offset: 0x0019B6E8
		public override Font get_Font()
		{
			return this.f.a();
		}

		// Token: 0x06002D57 RID: 11607 RVA: 0x0019C708 File Offset: 0x0019B708
		public override float get_FontSize()
		{
			return this.f.FontSize;
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x0019C728 File Offset: 0x0019B728
		public override BorderStyle get_BorderStyle()
		{
			return this.f.BorderStyle;
		}

		// Token: 0x06002D59 RID: 11609 RVA: 0x0019C748 File Offset: 0x0019B748
		public override DeviceColor get_BorderColor()
		{
			return this.f.BorderColor;
		}

		// Token: 0x06002D5A RID: 11610 RVA: 0x0019C768 File Offset: 0x0019B768
		public override RgbColor get_BackgroundColor()
		{
			return this.f.BackgroundColor;
		}

		// Token: 0x06002D5B RID: 11611 RVA: 0x0019C788 File Offset: 0x0019B788
		public override DeviceColor get_TextColor()
		{
			return this.f.TextColor;
		}

		// Token: 0x06002D5C RID: 11612 RVA: 0x0019C7A8 File Offset: 0x0019B7A8
		public override int get_Rotate()
		{
			return this.f.Rotate;
		}

		// Token: 0x04001587 RID: 5511
		private new float a;

		// Token: 0x04001588 RID: 5512
		private new float b;

		// Token: 0x04001589 RID: 5513
		private new float c;

		// Token: 0x0400158A RID: 5514
		private new float d;

		// Token: 0x0400158B RID: 5515
		private new int e;

		// Token: 0x0400158C RID: 5516
		private new CheckBox f;

		// Token: 0x0400158D RID: 5517
		private new FormField g = null;

		// Token: 0x0400158E RID: 5518
		private new float h = 0f;

		// Token: 0x0400158F RID: 5519
		private new float i = 0f;

		// Token: 0x04001590 RID: 5520
		private static byte[] j = new byte[]
		{
			79,
			102,
			102
		};
	}
}
