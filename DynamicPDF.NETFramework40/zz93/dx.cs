using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;

namespace zz93
{
	// Token: 0x020000AC RID: 172
	internal class dx : SignatureField
	{
		// Token: 0x06000811 RID: 2065 RVA: 0x00072558 File Offset: 0x00071558
		internal dx(string A_0, Signature A_1, float A_2, float A_3, float A_4, float A_5, float A_6, float A_7, int A_8, DocumentWriter A_9) : base(A_0, A_1.a(), A_1.ReaderEvents)
		{
			if (A_1.ToolTip != null)
			{
				base.AlternateName = A_1.ToolTip;
			}
			if (A_1.MappingName != null)
			{
				base.MappingName = A_1.MappingName;
			}
			this.h = A_1;
			this.e = A_2;
			this.f = A_3;
			this.d = A_7;
			this.a = A_5;
			this.b = A_6;
			this.c = A_4;
			this.g = A_8;
			if (A_9.Document.i() != null && A_9.Document.i().ContainsKey(this.h.Name))
			{
				int a_ = 0;
				this.l = this.a(ref a_, A_9.Document.i());
				if (A_1.Output == FormFieldOutput.Retain || (A_1.Output == FormFieldOutput.Inherit && A_9.Document.d().SignatureFieldsOutput == FormFieldOutput.Retain) || (A_1.Output == FormFieldOutput.Inherit && A_9.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && A_9.Document.d().Output == FormOutput.Retain))
				{
					this.k = A_9.Resources.Add(new cl(this.l, A_1.Reason, A_1.Location, a_));
				}
			}
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x000726F4 File Offset: 0x000716F4
		internal new Signature a()
		{
			return this.h;
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0007270C File Offset: 0x0007170C
		internal new int c()
		{
			return this.k;
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00072724 File Offset: 0x00071724
		public override int get_Rotate()
		{
			return this.h.Rotate;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00072744 File Offset: 0x00071744
		protected override void DrawDictionary(DocumentWriter writer)
		{
			base.DrawDictionary(writer);
			if (!base.HasChildFields)
			{
				writer.WriteName(Resource.a);
				writer.WriteName(FormField.q);
				writer.WriteName(Resource.b);
				writer.WriteName(FormField.r);
				if (this.h.d() != aco.a)
				{
					writer.WriteName(FormField.y);
					writer.WriteNumber((int)this.h.d());
				}
				writer.WriteName(FormField.z);
				writer.WriteReferenceShallow(writer.GetPageObject(this.g));
				writer.WriteName(FormField.s);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.a);
				writer.WriteNumber(this.c);
				writer.WriteNumber(this.b);
				writer.WriteNumber(this.d);
				writer.WriteArrayClose();
				if (writer.Document.i() != null && writer.Document.i().ContainsKey(this.h.Name))
				{
					writer.WriteName(86);
					writer.WriteReference(this.k);
					if (this.h.Visible)
					{
						this.b(writer);
						if (!base.Form.NeedsAppearances)
						{
							this.a(writer);
						}
					}
				}
				if (writer.Document.Tag != null && this.b() != -1)
				{
					if (this.h.Visible)
					{
						base.i().a(writer, this.b());
					}
				}
			}
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00072900 File Offset: 0x00071900
		private new bg a(ref int A_0, Hashtable A_1)
		{
			int num = 0;
			foreach (object obj in A_1)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if (dictionaryEntry.Key.Equals(this.h.Name))
				{
					A_0 = num;
					return (bg)dictionaryEntry.Value;
				}
				num++;
			}
			return null;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x000729A0 File Offset: 0x000719A0
		private new void b(DocumentWriter A_0)
		{
			base.Form.e().a(this.h.Font);
			base.Form.b(A_0);
			base.Form.a(A_0, this.h.Font, 12f, this.h.TextColor);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00072A00 File Offset: 0x00071A00
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(FormField.o);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(FormField.ab);
			A_0.WriteReference(A_0.Resources.Add(this.m));
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00072A4C File Offset: 0x00071A4C
		internal override void cd(DocumentWriter A_0)
		{
			if (A_0.Document.i() != null && A_0.Document.i().ContainsKey(this.h.Name))
			{
				this.m = new cn(this, this.e, this.f, this.l.a(), A_0, A_0.u());
				this.m.e();
				this.m.w();
			}
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00072AD4 File Offset: 0x00071AD4
		internal override void ce(PageWriter A_0)
		{
			if ((this.h.Visible && this.h.Output == FormFieldOutput.Flatten) || A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Flatten || (A_0.Document.d().SignatureFieldsOutput == FormFieldOutput.Inherit && A_0.Document.d().Output == FormOutput.Flatten))
			{
				if (A_0.Document.i() != null && A_0.Document.i().ContainsKey(this.h.Name))
				{
					zh a_ = A_0.DocumentWriter.v();
					cn cn = new cn(this, this.e, this.f, this.l.a(), A_0.DocumentWriter, a_);
					cn.e();
					cn.w();
					A_0.Write_q_();
					A_0.Write_cm(1f, 0f, 0f, 1f, A_0.Dimensions.aw(this.h.X), A_0.Dimensions.ax(this.h.Y + this.h.Height));
					int num = this.h.Rotate % 360;
					if (num > 0 && (num == 90 || num == 270))
					{
						A_0.Write_cm(1f, 0f, 0f, 1f, 0f, -(this.h.Width - this.h.Height));
					}
					A_0.Write_Do(cn);
					A_0.Write_Q();
				}
			}
		}

		// Token: 0x04000464 RID: 1124
		private new float a;

		// Token: 0x04000465 RID: 1125
		private new float b;

		// Token: 0x04000466 RID: 1126
		private new float c;

		// Token: 0x04000467 RID: 1127
		private new float d;

		// Token: 0x04000468 RID: 1128
		private new float e = 0f;

		// Token: 0x04000469 RID: 1129
		private new float f = 0f;

		// Token: 0x0400046A RID: 1130
		private new int g;

		// Token: 0x0400046B RID: 1131
		private new Signature h;

		// Token: 0x0400046C RID: 1132
		private new static byte[] i = new byte[]
		{
			65,
			67
		};

		// Token: 0x0400046D RID: 1133
		private static byte[] j = new byte[]
		{
			82,
			67
		};

		// Token: 0x0400046E RID: 1134
		private int k;

		// Token: 0x0400046F RID: 1135
		private bg l;

		// Token: 0x04000470 RID: 1136
		private cn m = null;
	}
}
