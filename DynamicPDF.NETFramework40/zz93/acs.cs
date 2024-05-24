using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x0200044F RID: 1103
	internal class acs : ComboBoxField
	{
		// Token: 0x06002D5E RID: 11614 RVA: 0x0019C7E0 File Offset: 0x0019B7E0
		internal acs(string A_0, ComboBox A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8) : base(A_0, A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002D5F RID: 11615 RVA: 0x0019C89C File Offset: 0x0019B89C
		internal acs(string A_0, ComboBox A_1) : base(A_0, A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002D60 RID: 11616 RVA: 0x0019C920 File Offset: 0x0019B920
		public override string get_Default()
		{
			ChoiceItem[] array;
			if (base.Parent is acs && base.InheritsName)
			{
				array = ((acs)base.Parent).a().Items.a();
			}
			else
			{
				array = this.f.Items.a();
			}
			ChoiceItem choiceItem = null;
			if (array != null && array.Length > 0)
			{
				choiceItem = ((array.Length == 1) ? array[0] : array[array.Length - 1]);
			}
			else if (this.f.Items.Count > 0)
			{
				choiceItem = this.f.Items[this.f.Items.Count - 1];
			}
			string result;
			if (choiceItem != null)
			{
				result = choiceItem.ItemName;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002D61 RID: 11617 RVA: 0x0019CA00 File Offset: 0x0019BA00
		internal new ComboBox a()
		{
			return this.f;
		}

		// Token: 0x06002D62 RID: 11618 RVA: 0x0019CA18 File Offset: 0x0019BA18
		internal new void a(ComboBox A_0)
		{
			this.f = A_0;
			if (A_0.ToolTip != null)
			{
				this.AlternateName = A_0.ToolTip;
			}
			base.b(A_0.a());
		}

		// Token: 0x06002D63 RID: 11619 RVA: 0x0019CA54 File Offset: 0x0019BA54
		internal new FormField a(FormFieldList A_0)
		{
			if (this.g == null)
			{
				this.g = new acs(this.Name, this.f);
				A_0.Add(this.g);
				base.f();
				this.g.ChildFields.Add(this);
			}
			return this.g;
		}

		// Token: 0x06002D64 RID: 11620 RVA: 0x0019CABC File Offset: 0x0019BABC
		protected override void DrawDictionary(DocumentWriter writer)
		{
			base.DrawDictionary(writer);
			ChoiceItem[] array = this.f.Items.a();
			ChoiceItem choiceItem = null;
			if (array != null && array.Length > 1)
			{
				throw new GeneratorException("The ComboBox cannot have multiple items selected.");
			}
			if (array != null && array.Length > 0)
			{
				choiceItem = array[array.Length - 1];
			}
			else if (this.f.Items.Count > 0)
			{
				choiceItem = this.f.Items[this.f.Items.Count - 1];
			}
			if (!base.InheritsValue && this.f.Items.Count > 0)
			{
				if (choiceItem != null)
				{
					int num = this.f.Items.a(choiceItem);
					if (num >= 0)
					{
						writer.WriteName(73);
						writer.WriteArrayOpen();
						writer.WriteNumber(num);
						writer.WriteArrayClose();
					}
					writer.WriteName(FormField.ad);
					if (choiceItem.ExportValue != null)
					{
						writer.WriteText(choiceItem.ExportValue);
					}
					else
					{
						writer.WriteText(choiceItem.ItemName);
					}
					writer.WriteName(FormField.w);
					if (choiceItem.ExportValue != null)
					{
						writer.WriteText(choiceItem.ExportValue);
					}
					else
					{
						writer.WriteText(choiceItem.ItemName);
					}
				}
				writer.WriteName(ceTe.DynamicPDF.Forms.ChoiceField.b);
				writer.WriteArrayOpen();
				for (int i = 0; i < this.f.Items.Count; i++)
				{
					if (this.f.Items[i].ExportValue == null)
					{
						writer.WriteText(this.f.Items[i].ItemName);
					}
					else
					{
						writer.WriteArrayOpen();
						writer.WriteText(this.f.Items[i].ExportValue);
						writer.WriteText(this.f.Items[i].ItemName);
						writer.WriteArrayClose();
					}
				}
				writer.WriteArrayClose();
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
				this.c(writer);
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

		// Token: 0x06002D65 RID: 11621 RVA: 0x0019CE98 File Offset: 0x0019BE98
		internal override void ce(PageWriter A_0)
		{
			if (this.f.Visible)
			{
				zh a_ = A_0.DocumentWriter.v();
				this.j = new zl(this, this.h, this.i, A_0.DocumentWriter, a_);
				this.j.c();
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

		// Token: 0x06002D66 RID: 11622 RVA: 0x0019CFE8 File Offset: 0x0019BFE8
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
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002D67 RID: 11623 RVA: 0x0019D0A8 File Offset: 0x0019C0A8
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

		// Token: 0x06002D68 RID: 11624 RVA: 0x0019D13C File Offset: 0x0019C13C
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			A_0.WriteReference(A_0.Resources.Add(this.j));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002D69 RID: 11625 RVA: 0x0019D188 File Offset: 0x0019C188
		internal override void cd(DocumentWriter A_0)
		{
			this.j = new zl(this, this.h, this.i, A_0, A_0.u());
			this.j.c();
			this.j.w();
		}

		// Token: 0x06002D6A RID: 11626 RVA: 0x0019D1C4 File Offset: 0x0019C1C4
		public override Font get_Font()
		{
			return this.f.Font;
		}

		// Token: 0x06002D6B RID: 11627 RVA: 0x0019D1E4 File Offset: 0x0019C1E4
		public override float get_FontSize()
		{
			return this.f.FontSize;
		}

		// Token: 0x06002D6C RID: 11628 RVA: 0x0019D204 File Offset: 0x0019C204
		public override BorderStyle get_BorderStyle()
		{
			return this.f.BorderStyle;
		}

		// Token: 0x06002D6D RID: 11629 RVA: 0x0019D224 File Offset: 0x0019C224
		public override DeviceColor get_BorderColor()
		{
			return this.f.BorderColor;
		}

		// Token: 0x06002D6E RID: 11630 RVA: 0x0019D244 File Offset: 0x0019C244
		public override RgbColor get_BackgroundColor()
		{
			return this.f.BackgroundColor;
		}

		// Token: 0x06002D6F RID: 11631 RVA: 0x0019D264 File Offset: 0x0019C264
		public override DeviceColor get_TextColor()
		{
			return this.f.TextColor;
		}

		// Token: 0x06002D70 RID: 11632 RVA: 0x0019D284 File Offset: 0x0019C284
		public override int get_Rotate()
		{
			return this.f.Rotate;
		}

		// Token: 0x06002D71 RID: 11633 RVA: 0x0019D2A4 File Offset: 0x0019C2A4
		internal override string[] hg()
		{
			string[] array;
			if (base.Parent is acs && base.InheritsName)
			{
				acs acs = (acs)base.Parent;
				array = new string[acs.a().Items.Count];
				for (int i = 0; i < acs.a().Items.Count; i++)
				{
					array[i] = acs.a().Items[i].ItemName;
				}
			}
			else
			{
				array = new string[this.f.Items.Count];
				for (int i = 0; i < this.f.Items.Count; i++)
				{
					array[i] = this.f.Items[i].ItemName;
				}
			}
			return array;
		}

		// Token: 0x04001591 RID: 5521
		private new float a;

		// Token: 0x04001592 RID: 5522
		private new float b;

		// Token: 0x04001593 RID: 5523
		private new float c;

		// Token: 0x04001594 RID: 5524
		private new float d;

		// Token: 0x04001595 RID: 5525
		private new int e;

		// Token: 0x04001596 RID: 5526
		private new ComboBox f;

		// Token: 0x04001597 RID: 5527
		private new FormField g = null;

		// Token: 0x04001598 RID: 5528
		private new float h = 0f;

		// Token: 0x04001599 RID: 5529
		private new float i = 0f;

		// Token: 0x0400159A RID: 5530
		private zl j = null;
	}
}
