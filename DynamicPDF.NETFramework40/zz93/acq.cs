using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x0200044D RID: 1101
	internal class acq : ButtonField
	{
		// Token: 0x06002D32 RID: 11570 RVA: 0x0019B3F0 File Offset: 0x0019A3F0
		internal acq(string A_0, Button A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8) : base(A_0, A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002D33 RID: 11571 RVA: 0x0019B4B8 File Offset: 0x0019A4B8
		internal acq(string A_0, Button A_1) : base(A_0, A_1.a(), A_1.ReaderEvents)
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

		// Token: 0x06002D34 RID: 11572 RVA: 0x0019B548 File Offset: 0x0019A548
		internal new void a(int A_0)
		{
			base.b(A_0);
		}

		// Token: 0x06002D35 RID: 11573 RVA: 0x0019B554 File Offset: 0x0019A554
		internal new void a(string A_0)
		{
			if (A_0 != null)
			{
				this.AlternateName = A_0;
			}
		}

		// Token: 0x06002D36 RID: 11574 RVA: 0x0019B574 File Offset: 0x0019A574
		internal new FormField a(FormFieldList A_0)
		{
			if (this.g == null)
			{
				this.g = new acq(this.Name, this.f);
				A_0.Add(this.g);
				base.f();
				this.g.ChildFields.Add(this);
			}
			return this.g;
		}

		// Token: 0x06002D37 RID: 11575 RVA: 0x0019B5DC File Offset: 0x0019A5DC
		protected override void DrawDictionary(DocumentWriter writer)
		{
			base.DrawDictionary(writer);
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
				if (this.f.Action != null)
				{
					if (this.f.Action.c() != 750795497 && this.f.Action.c() != 514009796)
					{
						writer.WriteName(65);
					}
					this.f.Action.Draw(writer);
				}
				if (this.f.Behavior != null)
				{
					writer.WriteName(72);
					writer.WriteName((byte)this.f.Behavior.a());
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

		// Token: 0x06002D38 RID: 11576 RVA: 0x0019B7FC File Offset: 0x0019A7FC
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
			if (this.f.Label != null)
			{
				A_0.WriteName(ButtonField.b);
				A_0.WriteText(this.f.Label);
			}
			if (this.f.Behavior.a() == Behavior.d)
			{
				PushBehavior pushBehavior = (PushBehavior)this.f.Behavior;
				if (pushBehavior.DownLabel != null)
				{
					A_0.WriteName(ButtonField.c);
					A_0.WriteText(pushBehavior.DownLabel);
				}
				if (pushBehavior.RolloverLabel != null)
				{
					A_0.WriteName(ButtonField.d);
					A_0.WriteText(pushBehavior.RolloverLabel);
				}
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002D39 RID: 11577 RVA: 0x0019B970 File Offset: 0x0019A970
		private new void b(DocumentWriter A_0)
		{
			base.Form.e().a(this.f.Font);
			base.Form.b(A_0);
			base.Form.a(A_0, this.f.Font, this.f.FontSize, this.f.TextColor);
		}

		// Token: 0x06002D3A RID: 11578 RVA: 0x0019B9D8 File Offset: 0x0019A9D8
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			A_0.WriteReference(A_0.Resources.Add(this.j));
			if (this.f.Behavior.a() == Behavior.d)
			{
				A_0.WriteName(FormField.ac);
				A_0.WriteReference(A_0.Resources.Add(this.k));
				if (((PushBehavior)this.f.Behavior).RolloverLabel != null)
				{
					A_0.WriteName(FormField.aa);
					A_0.WriteReference(A_0.Resources.Add(this.l));
				}
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002D3B RID: 11579 RVA: 0x0019BAAC File Offset: 0x0019AAAC
		internal override void cd(DocumentWriter A_0)
		{
			this.j = new zj(this, this.h, this.i, acp.a, A_0, A_0.u());
			this.a(this.j);
			if (this.f.Behavior.a() == Behavior.d)
			{
				this.k = new zj(this, this.h, this.i, acp.b, A_0, A_0.u());
				this.a(this.k);
				if (((PushBehavior)this.f.Behavior).RolloverLabel != null)
				{
					this.l = new zj(this, this.h, this.i, acp.c, A_0, A_0.u());
					this.a(this.l);
				}
			}
		}

		// Token: 0x06002D3C RID: 11580 RVA: 0x0019BB84 File Offset: 0x0019AB84
		internal override void ce(PageWriter A_0)
		{
			if (this.f.Visible)
			{
				zh a_ = A_0.DocumentWriter.v();
				zj zj = new zj(this, this.h, this.i, acp.a, A_0.DocumentWriter, a_);
				zj.i();
				zj.p();
				zj.w();
				A_0.Write_q_();
				A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(this.f.X), A_0.Dimensions.ax(this.f.Y + this.f.Height));
				int num = this.f.Rotate % 360;
				if (num > 0 && (num == 90 || num == 270))
				{
					A_0.Write_cm(1f, 0f, 0f, 1f, 0f, -(this.f.Width - this.f.Height));
				}
				A_0.Write_Do(zj);
				A_0.Write_Q();
			}
		}

		// Token: 0x06002D3D RID: 11581 RVA: 0x0019BCBD File Offset: 0x0019ACBD
		private new void a(zj A_0)
		{
			A_0.i();
			A_0.w();
		}

		// Token: 0x06002D3E RID: 11582 RVA: 0x0019BCD0 File Offset: 0x0019ACD0
		internal override Behavior i5()
		{
			return this.f.Behavior;
		}

		// Token: 0x06002D3F RID: 11583 RVA: 0x0019BCF0 File Offset: 0x0019ACF0
		internal override string i6()
		{
			return this.f.Label;
		}

		// Token: 0x06002D40 RID: 11584 RVA: 0x0019BD10 File Offset: 0x0019AD10
		public override BorderStyle get_BorderStyle()
		{
			return this.f.BorderStyle;
		}

		// Token: 0x06002D41 RID: 11585 RVA: 0x0019BD30 File Offset: 0x0019AD30
		public override DeviceColor get_BorderColor()
		{
			return this.f.BorderColor;
		}

		// Token: 0x06002D42 RID: 11586 RVA: 0x0019BD50 File Offset: 0x0019AD50
		public override RgbColor get_BackgroundColor()
		{
			return this.f.BackgroundColor;
		}

		// Token: 0x06002D43 RID: 11587 RVA: 0x0019BD70 File Offset: 0x0019AD70
		public override DeviceColor get_TextColor()
		{
			return this.f.TextColor;
		}

		// Token: 0x06002D44 RID: 11588 RVA: 0x0019BD90 File Offset: 0x0019AD90
		public override int get_Rotate()
		{
			return this.f.Rotate;
		}

		// Token: 0x06002D45 RID: 11589 RVA: 0x0019BDB0 File Offset: 0x0019ADB0
		public override Font get_Font()
		{
			return this.f.Font;
		}

		// Token: 0x06002D46 RID: 11590 RVA: 0x0019BDD0 File Offset: 0x0019ADD0
		public override float get_FontSize()
		{
			return this.f.FontSize;
		}

		// Token: 0x0400157B RID: 5499
		private new float a;

		// Token: 0x0400157C RID: 5500
		private new float b;

		// Token: 0x0400157D RID: 5501
		private new float c;

		// Token: 0x0400157E RID: 5502
		private new float d;

		// Token: 0x0400157F RID: 5503
		private new int e;

		// Token: 0x04001580 RID: 5504
		private new Button f;

		// Token: 0x04001581 RID: 5505
		private new FormField g = null;

		// Token: 0x04001582 RID: 5506
		private new float h = 0f;

		// Token: 0x04001583 RID: 5507
		private new float i = 0f;

		// Token: 0x04001584 RID: 5508
		private zj j = null;

		// Token: 0x04001585 RID: 5509
		private zj k = null;

		// Token: 0x04001586 RID: 5510
		private zj l = null;
	}
}
