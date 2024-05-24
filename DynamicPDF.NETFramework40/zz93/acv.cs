using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x02000452 RID: 1106
	internal class acv : ceTe.DynamicPDF.Forms.TextField
	{
		// Token: 0x06002DA2 RID: 11682 RVA: 0x0019EB1C File Offset: 0x0019DB1C
		internal acv(string A_0, ceTe.DynamicPDF.PageElements.Forms.TextField A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8) : base(A_0, A_1.b(), A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002DA3 RID: 11683 RVA: 0x0019EBDC File Offset: 0x0019DBDC
		internal acv(string A_0, ceTe.DynamicPDF.PageElements.Forms.TextField A_1) : base(A_0, A_1.b(), A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002DA4 RID: 11684 RVA: 0x0019EC64 File Offset: 0x0019DC64
		internal override string hl()
		{
			string defaultValue;
			if (base.Parent is acv && base.InheritsName)
			{
				defaultValue = ((acv)base.Parent).a().DefaultValue;
			}
			else
			{
				defaultValue = this.f.DefaultValue;
			}
			return defaultValue;
		}

		// Token: 0x06002DA5 RID: 11685 RVA: 0x0019ECB8 File Offset: 0x0019DCB8
		public override int get_MaximumLength()
		{
			int maxLength;
			if (base.Parent is acv && base.InheritsName)
			{
				maxLength = ((acv)base.Parent).a().MaxLength;
			}
			else
			{
				maxLength = this.f.MaxLength;
			}
			return maxLength;
		}

		// Token: 0x06002DA6 RID: 11686 RVA: 0x0019ED0C File Offset: 0x0019DD0C
		public override BorderStyle get_BorderStyle()
		{
			return this.f.BorderStyle;
		}

		// Token: 0x06002DA7 RID: 11687 RVA: 0x0019ED2C File Offset: 0x0019DD2C
		public override DeviceColor get_BorderColor()
		{
			return this.f.BorderColor;
		}

		// Token: 0x06002DA8 RID: 11688 RVA: 0x0019ED4C File Offset: 0x0019DD4C
		public override RgbColor get_BackgroundColor()
		{
			return this.f.BackgroundColor;
		}

		// Token: 0x06002DA9 RID: 11689 RVA: 0x0019ED6C File Offset: 0x0019DD6C
		public override DeviceColor get_TextColor()
		{
			return this.f.TextColor;
		}

		// Token: 0x06002DAA RID: 11690 RVA: 0x0019ED8C File Offset: 0x0019DD8C
		public override int get_Rotate()
		{
			return this.f.Rotate;
		}

		// Token: 0x06002DAB RID: 11691 RVA: 0x0019EDAC File Offset: 0x0019DDAC
		public override Font get_Font()
		{
			return this.f.Font;
		}

		// Token: 0x06002DAC RID: 11692 RVA: 0x0019EDCC File Offset: 0x0019DDCC
		public override float get_FontSize()
		{
			return this.f.FontSize;
		}

		// Token: 0x06002DAD RID: 11693 RVA: 0x0019EDEC File Offset: 0x0019DDEC
		internal new ceTe.DynamicPDF.PageElements.Forms.TextField a()
		{
			return this.f;
		}

		// Token: 0x06002DAE RID: 11694 RVA: 0x0019EE04 File Offset: 0x0019DE04
		internal new void a(ceTe.DynamicPDF.PageElements.Forms.TextField A_0)
		{
			this.f = A_0;
			if (A_0.ToolTip != null)
			{
				this.AlternateName = A_0.ToolTip;
			}
			this.a(A_0.a());
		}

		// Token: 0x06002DAF RID: 11695 RVA: 0x0019EE40 File Offset: 0x0019DE40
		private new void a(int A_0)
		{
			if ((A_0 & 8192) == 8192 && (base.Flags & FormFieldFlags.Multiline) == FormFieldFlags.Multiline)
			{
				base.d(4096);
				base.b(A_0);
			}
			else if ((A_0 & 4096) == 4096 && (base.Flags & FormFieldFlags.Password) == FormFieldFlags.Password)
			{
				base.d(8192);
				base.d(4194304);
				base.b(A_0);
			}
			else
			{
				base.b(A_0);
			}
		}

		// Token: 0x06002DB0 RID: 11696 RVA: 0x0019EEEC File Offset: 0x0019DEEC
		internal override int hk()
		{
			int flags;
			if (base.Parent is acv && base.InheritsName)
			{
				flags = (int)((acv)base.Parent).Flags;
			}
			else
			{
				flags = (int)base.Flags;
			}
			return flags;
		}

		// Token: 0x06002DB1 RID: 11697 RVA: 0x0019EF38 File Offset: 0x0019DF38
		internal new FormField a(FormFieldList A_0)
		{
			if (this.g == null)
			{
				this.g = new acv(this.Name, this.a());
				A_0.Add(this.g);
				base.f();
				this.g.ChildFields.Add(this);
			}
			return this.g;
		}

		// Token: 0x06002DB2 RID: 11698 RVA: 0x0019EFA0 File Offset: 0x0019DFA0
		protected override void DrawDictionary(DocumentWriter writer)
		{
			base.DrawDictionary(writer);
			if (!base.InheritsValue)
			{
				if (this.MaximumLength > 0)
				{
					writer.WriteName(acv.k);
					writer.WriteNumber(this.MaximumLength);
				}
				if (this.hl() != null)
				{
					writer.WriteName(FormField.ad);
					writer.WriteText(this.hl());
					writer.WriteName(FormField.w);
					writer.WriteText(this.hl());
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
				this.b(writer);
				if (this.c(writer) || this.hl() != null)
				{
					if (!base.Form.NeedsAppearances)
					{
						this.a(writer);
					}
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

		// Token: 0x06002DB3 RID: 11699 RVA: 0x0019F1B4 File Offset: 0x0019E1B4
		private new bool c(DocumentWriter A_0)
		{
			int num = this.f.Rotate % 360;
			bool result = false;
			if (num > 0 || this.f.BorderColor != null || this.f.BackgroundColor != null)
			{
				A_0.WriteName(FormField.t);
				A_0.WriteDictionaryOpen();
				if (num > 0)
				{
					A_0.WriteName(FormField.aa);
					A_0.WriteNumber(num);
				}
				if (this.f.BorderColor != null)
				{
					A_0.WriteName(FormField.u);
					this.f.BorderColor.gr(A_0);
					result = true;
				}
				if (this.f.BackgroundColor != null)
				{
					A_0.WriteName(FormField.v);
					this.f.BackgroundColor.gr(A_0);
					result = true;
				}
				A_0.WriteDictionaryClose();
			}
			return result;
		}

		// Token: 0x06002DB4 RID: 11700 RVA: 0x0019F2AC File Offset: 0x0019E2AC
		private new void b(DocumentWriter A_0)
		{
			if (this.f.Font == null)
			{
				this.f.Font = base.Form.DefaultFont;
			}
			base.Form.e().a(this.f.Font);
			base.Form.b(A_0);
			base.Form.a(A_0, this.f.Font, this.f.FontSize, this.f.TextColor);
		}

		// Token: 0x06002DB5 RID: 11701 RVA: 0x0019F340 File Offset: 0x0019E340
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			A_0.WriteReference(A_0.Resources.Add(this.j));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002DB6 RID: 11702 RVA: 0x0019F38C File Offset: 0x0019E38C
		internal override void cd(DocumentWriter A_0)
		{
			this.j = new zo(this, this.h, this.i, A_0, A_0.v());
			this.j.f();
			this.j.w();
		}

		// Token: 0x06002DB7 RID: 11703 RVA: 0x0019F3C8 File Offset: 0x0019E3C8
		internal override void ce(PageWriter A_0)
		{
			if (this.f.Visible)
			{
				if (this.f.BorderColor != null || this.f.BackgroundColor != null || this.hl() != null)
				{
					zh a_ = A_0.DocumentWriter.v();
					this.j = new zo(this, this.h, this.i, A_0.DocumentWriter, a_);
					this.j.f();
					this.j.p();
					this.j.w();
					A_0.Write_q_();
					A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(this.f.X), A_0.Dimensions.ax(this.f.Y + this.f.Height));
					int num = this.f.Rotate % 360;
					if (num > 0 && (num == 90 || num == 270))
					{
						A_0.Write_cm(1f, 0f, 0f, 1f, 0f, -(this.f.Width - this.f.Height));
					}
					A_0.Write_Do(this.j);
					A_0.Write_Q();
				}
			}
		}

		// Token: 0x040015AF RID: 5551
		private new float a;

		// Token: 0x040015B0 RID: 5552
		private new float b;

		// Token: 0x040015B1 RID: 5553
		private new float c;

		// Token: 0x040015B2 RID: 5554
		private new float d;

		// Token: 0x040015B3 RID: 5555
		private new int e;

		// Token: 0x040015B4 RID: 5556
		private new ceTe.DynamicPDF.PageElements.Forms.TextField f;

		// Token: 0x040015B5 RID: 5557
		private new FormField g = null;

		// Token: 0x040015B6 RID: 5558
		private new float h = 0f;

		// Token: 0x040015B7 RID: 5559
		private new float i = 0f;

		// Token: 0x040015B8 RID: 5560
		private zo j = null;

		// Token: 0x040015B9 RID: 5561
		private static byte[] k = new byte[]
		{
			77,
			97,
			120,
			76,
			101,
			110
		};
	}
}
