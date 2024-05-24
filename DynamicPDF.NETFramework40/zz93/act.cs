using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x02000450 RID: 1104
	internal class act : ListBoxField
	{
		// Token: 0x06002D72 RID: 11634 RVA: 0x0019D38C File Offset: 0x0019C38C
		internal act(string A_0, ListBox A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8) : base(A_0, A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002D73 RID: 11635 RVA: 0x0019D448 File Offset: 0x0019C448
		internal act(string A_0, ListBox A_1) : base(A_0, A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002D74 RID: 11636 RVA: 0x0019D4CC File Offset: 0x0019C4CC
		public override string get_Value()
		{
			ChoiceItem[] array = this.f.Items.a();
			string text = string.Empty;
			string result;
			if (array != null && array.Length > 0)
			{
				foreach (ChoiceItem choiceItem in array)
				{
					if (!text.Equals(string.Empty))
					{
						text += ",";
					}
					text += choiceItem.ItemName;
				}
				result = text;
			}
			else
			{
				result = this.f.Items[this.f.Items.Count - 1].ItemName;
			}
			return result;
		}

		// Token: 0x06002D75 RID: 11637 RVA: 0x0019D588 File Offset: 0x0019C588
		internal new ListBox a()
		{
			return this.f;
		}

		// Token: 0x06002D76 RID: 11638 RVA: 0x0019D5A0 File Offset: 0x0019C5A0
		internal new void a(ListBox A_0)
		{
			this.f = A_0;
			if (A_0.ToolTip != null)
			{
				this.AlternateName = A_0.ToolTip;
			}
			base.b(A_0.a());
		}

		// Token: 0x06002D77 RID: 11639 RVA: 0x0019D5DC File Offset: 0x0019C5DC
		internal override int hi(string A_0)
		{
			int result;
			if (base.Parent is act && base.InheritsName)
			{
				result = this.f.Items.a(((act)base.Parent).a().Items[A_0]);
			}
			else
			{
				result = this.f.Items.a(this.f.Items[A_0]);
			}
			return result;
		}

		// Token: 0x06002D78 RID: 11640 RVA: 0x0019D660 File Offset: 0x0019C660
		internal override string[] hj()
		{
			string[] array;
			if (base.Parent is act && base.InheritsName)
			{
				act act = (act)base.Parent;
				array = new string[act.a().Items.Count];
				for (int i = 0; i < act.a().Items.Count; i++)
				{
					array[i] = act.a().Items[i].ItemName;
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

		// Token: 0x06002D79 RID: 11641 RVA: 0x0019D748 File Offset: 0x0019C748
		internal override int hh()
		{
			return this.a().Items.Count;
		}

		// Token: 0x06002D7A RID: 11642 RVA: 0x0019D76C File Offset: 0x0019C76C
		internal new FormField a(FormFieldList A_0)
		{
			if (this.g == null)
			{
				this.g = new act(this.Name, this.f);
				A_0.Add(this.g);
				base.f();
				this.g.ChildFields.Add(this);
			}
			return this.g;
		}

		// Token: 0x06002D7B RID: 11643 RVA: 0x0019D7D3 File Offset: 0x0019C7D3
		public override void SetValues(string[] values)
		{
		}

		// Token: 0x06002D7C RID: 11644 RVA: 0x0019D7D8 File Offset: 0x0019C7D8
		public override string get_Default()
		{
			return this.Value;
		}

		// Token: 0x06002D7D RID: 11645 RVA: 0x0019D7F0 File Offset: 0x0019C7F0
		protected override void DrawDictionary(DocumentWriter writer)
		{
			base.DrawDictionary(writer);
			if (!base.InheritsValue && this.f.Items.Count > 0)
			{
				ChoiceItem[] array = this.f.Items.a();
				if (array != null && array.Length > 1)
				{
					if ((this.f.a() & 2097152) != 2097152)
					{
						throw new GeneratorException("The listbox does not have its multi select property set to true.");
					}
					writer.WriteName(73);
					writer.WriteArrayOpen();
					foreach (ChoiceItem choiceItem in array)
					{
						int num = this.f.Items.a(choiceItem);
						if (num >= 0)
						{
							writer.WriteNumber(num);
						}
					}
					writer.WriteArrayClose();
					writer.WriteName(FormField.ad);
					this.a(array, writer);
					writer.WriteName(FormField.w);
					this.a(array, writer);
				}
				else
				{
					writer.WriteName(73);
					writer.WriteArrayOpen();
					ChoiceItem choiceItem;
					if (array == null || array.Length == 0)
					{
						choiceItem = this.f.Items[this.f.Items.Count - 1];
					}
					else
					{
						choiceItem = array[0];
					}
					writer.WriteNumber(this.f.Items.a(choiceItem));
					writer.WriteArrayClose();
					writer.WriteName(FormField.ad);
					if (choiceItem.ExportValue == null)
					{
						writer.WriteText(choiceItem.ItemName);
					}
					else
					{
						writer.WriteText(choiceItem.ExportValue);
					}
					writer.WriteName(FormField.w);
					if (choiceItem.ExportValue == null)
					{
						writer.WriteText(choiceItem.ItemName);
					}
					else
					{
						writer.WriteText(choiceItem.ExportValue);
					}
				}
				writer.WriteName(ceTe.DynamicPDF.Forms.ChoiceField.b);
				writer.WriteArrayOpen();
				for (int j = 0; j < this.f.Items.Count; j++)
				{
					if (this.f.Items[j].ExportValue == null)
					{
						writer.WriteText(this.f.Items[j].ItemName);
					}
					else
					{
						writer.WriteArrayOpen();
						writer.WriteText(this.f.Items[j].ExportValue);
						writer.WriteText(this.f.Items[j].ItemName);
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

		// Token: 0x06002D7E RID: 11646 RVA: 0x0019DC4C File Offset: 0x0019CC4C
		private new void a(ChoiceItem[] A_0, DocumentWriter A_1)
		{
			if (A_0.Length > 1)
			{
				A_1.WriteArrayOpen();
				foreach (ChoiceItem choiceItem in A_0)
				{
					if (choiceItem.ExportValue == null)
					{
						A_1.WriteText(choiceItem.ItemName);
					}
					else
					{
						A_1.WriteText(choiceItem.ExportValue);
					}
				}
				A_1.WriteArrayClose();
			}
			else if (A_0[0].ExportValue == null)
			{
				A_1.WriteText(A_0[0].ItemName);
			}
			else
			{
				A_1.WriteText(A_0[0].ExportValue);
			}
		}

		// Token: 0x06002D7F RID: 11647 RVA: 0x0019DCF4 File Offset: 0x0019CCF4
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

		// Token: 0x06002D80 RID: 11648 RVA: 0x0019DDB4 File Offset: 0x0019CDB4
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

		// Token: 0x06002D81 RID: 11649 RVA: 0x0019DE48 File Offset: 0x0019CE48
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			A_0.WriteReference(A_0.Resources.Add(this.j));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002D82 RID: 11650 RVA: 0x0019DE94 File Offset: 0x0019CE94
		internal override void cd(DocumentWriter A_0)
		{
			this.j = new zm(this, this.h, this.i, A_0, A_0.u());
			this.j.c();
			this.j.w();
		}

		// Token: 0x06002D83 RID: 11651 RVA: 0x0019DED0 File Offset: 0x0019CED0
		internal override void ce(PageWriter A_0)
		{
			if (this.f.Visible)
			{
				zh a_ = A_0.DocumentWriter.v();
				this.j = new zm(this, this.h, this.i, A_0.DocumentWriter, a_);
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

		// Token: 0x06002D84 RID: 11652 RVA: 0x0019E020 File Offset: 0x0019D020
		public override Font get_Font()
		{
			return this.f.Font;
		}

		// Token: 0x06002D85 RID: 11653 RVA: 0x0019E040 File Offset: 0x0019D040
		public override float get_FontSize()
		{
			return this.f.FontSize;
		}

		// Token: 0x06002D86 RID: 11654 RVA: 0x0019E060 File Offset: 0x0019D060
		public override BorderStyle get_BorderStyle()
		{
			return this.f.BorderStyle;
		}

		// Token: 0x06002D87 RID: 11655 RVA: 0x0019E080 File Offset: 0x0019D080
		public override DeviceColor get_BorderColor()
		{
			return this.f.BorderColor;
		}

		// Token: 0x06002D88 RID: 11656 RVA: 0x0019E0A0 File Offset: 0x0019D0A0
		public override RgbColor get_BackgroundColor()
		{
			return this.f.BackgroundColor;
		}

		// Token: 0x06002D89 RID: 11657 RVA: 0x0019E0C0 File Offset: 0x0019D0C0
		public override DeviceColor get_TextColor()
		{
			return this.f.TextColor;
		}

		// Token: 0x06002D8A RID: 11658 RVA: 0x0019E0E0 File Offset: 0x0019D0E0
		public override int get_Rotate()
		{
			return this.f.Rotate;
		}

		// Token: 0x0400159B RID: 5531
		private new float a;

		// Token: 0x0400159C RID: 5532
		private new float b;

		// Token: 0x0400159D RID: 5533
		private new float c;

		// Token: 0x0400159E RID: 5534
		private new float d;

		// Token: 0x0400159F RID: 5535
		private new int e;

		// Token: 0x040015A0 RID: 5536
		private new ListBox f;

		// Token: 0x040015A1 RID: 5537
		private new FormField g = null;

		// Token: 0x040015A2 RID: 5538
		private new float h = 0f;

		// Token: 0x040015A3 RID: 5539
		private new float i = 0f;

		// Token: 0x040015A4 RID: 5540
		private zm j = null;
	}
}
