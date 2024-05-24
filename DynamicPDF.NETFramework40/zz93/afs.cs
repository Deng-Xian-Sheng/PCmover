using System;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020004BF RID: 1215
	internal class afs : OperatorWriter
	{
		// Token: 0x060031EB RID: 12779 RVA: 0x001BE8E8 File Offset: 0x001BD8E8
		internal afs(TextWatermark A_0, DocumentWriter A_1, float A_2, float A_3) : base(A_1, A_1.v(), new ck(A_2, A_3))
		{
			this.j = A_0;
			this.m = A_2;
			this.n = A_3;
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x001BE93C File Offset: 0x001BD93C
		internal afs(ImageWatermark A_0, DocumentWriter A_1, float A_2, float A_3) : base(A_1, A_1.v(), new ck(A_2, A_3))
		{
			this.k = A_0;
			this.m = A_2;
			this.n = A_3;
		}

		// Token: 0x060031ED RID: 12781 RVA: 0x001BE990 File Offset: 0x001BD990
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.f);
			writer.WriteName(afs.a);
			writer.WriteDictionaryOpen();
			if (this.h != null)
			{
				this.h.a(writer);
			}
			if (this.i != null)
			{
				this.i.a(writer);
			}
			writer.WriteName(afs.c);
			writer.WriteArrayOpen();
			writer.WriteName(afs.d);
			if (this.h != null)
			{
				writer.WriteName(afs.g);
			}
			if (this.j != null && this.j.Text != "")
			{
				writer.WriteName(afs.e);
				writer.WriteArrayClose();
				writer.WriteName(Resource.i);
				writer.WriteDictionaryOpen();
				writer.WriteName(this.j.Font.bg());
				this.j.Font.bj(writer);
				writer.WriteDictionaryClose();
				writer.WriteDictionaryClose();
			}
			else
			{
				writer.WriteArrayClose();
				writer.WriteDictionaryClose();
			}
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(afs.b);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber(this.m);
			writer.WriteNumber(this.n);
			writer.WriteArrayClose();
			writer.WriteName(afs.f);
			writer.WriteNumber1();
			if (base.t().o())
			{
				writer.WriteName(Resource.c);
				writer.WriteName(Resource.d);
			}
			writer.WriteName(Resource.e);
			writer.ai(base.t().s());
			writer.WriteDictionaryClose();
			writer.ac(base.t());
			writer.WriteEndObject();
			base.a(null);
		}

		// Token: 0x060031EE RID: 12782 RVA: 0x001BEBB8 File Offset: 0x001BDBB8
		public new void c()
		{
			float a_ = this.j.Opacity / 100f;
			float a_2 = this.j.Opacity / 100f;
			BlendMode a_3 = BlendMode.Normal;
			base.Write_q_(true);
			this.a(new TransparencyGroup.a(a_, a_2, a_3));
			if (this.j.Angle != 0f)
			{
				base.SetDimensionsSimpleRotate(this.j.a(), this.j.b(), this.j.Angle);
			}
			if (this.j.Text != "")
			{
				this.l = this.j.Font.GetTextLines(this.j.Text.ToCharArray(), this.j.c(), this.j.d(), this.j.FontSize);
				this.l.ja(this, this.j.a(), this.j.b(), TextAlign.Left, this.j.TextColor, this.j.TextOutlineColor, this.j.TextOutlineWidth, this.j.Underline, false, this.j.Strikethrough);
			}
			if (this.j.Angle != 0f)
			{
				base.ResetDimensions();
			}
			base.Write_Q(true);
		}

		// Token: 0x060031EF RID: 12783 RVA: 0x001BED30 File Offset: 0x001BDD30
		public new void e()
		{
			float a_ = this.k.Opacity / 100f;
			float a_2 = this.k.Opacity / 100f;
			BlendMode a_3 = BlendMode.Normal;
			base.Write_q_(true);
			this.a(new TransparencyGroup.a(a_, a_2, a_3));
			if (this.k.Angle != 0f)
			{
				base.SetDimensionsSimpleRotate(this.k.a(), this.k.b(), this.k.Angle);
			}
			if (this.k.ImageData != null)
			{
				this.a();
			}
			if (this.k.Angle != 0f)
			{
				base.ResetDimensions();
			}
			base.Write_Q(true);
		}

		// Token: 0x060031F0 RID: 12784 RVA: 0x001BEE00 File Offset: 0x001BDE00
		private new void a()
		{
			float pdfX;
			float pdfY;
			if (this.k.Angle != 0f)
			{
				pdfX = 0f;
				pdfY = -this.k.d();
			}
			else
			{
				pdfX = this.k.a();
				pdfY = this.k.b();
			}
			this.k.ImageData.Draw(this, pdfX, pdfY, this.k.c(), this.k.d());
		}

		// Token: 0x060031F1 RID: 12785 RVA: 0x001BEE8C File Offset: 0x001BDE8C
		public override void Write_Tf(Font font, float fontSize)
		{
			if (font is IFontSubsettable)
			{
				base.DocumentWriter.SetFontSubsetter((IFontSubsettable)font);
			}
			string text = "/" + font.bg();
			byte[] array = new byte[text.Length];
			br br = base.s().b(array.Length + 15);
			Encoding.ASCII.GetBytes(text, 0, text.Length, array, 0);
			br.a(array);
			br.a(32);
			br.c(fontSize);
			br.a(32);
			br.a(84);
			br.a(102);
			br.a(10);
			base.q().Font = font;
			base.q().FontSize = fontSize;
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x001BEF60 File Offset: 0x001BDF60
		internal new void a(Resource A_0)
		{
			if (this.i == null)
			{
				this.i = new PageExtGStateList();
			}
			br br = base.s().b(18);
			this.i.a(A_0, this);
			br.a(32);
			br.a(103);
			br.a(115);
			br.a(10);
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x001BEFCC File Offset: 0x001BDFCC
		public override void Write_Do(Resource xObject)
		{
			if (this.h == null)
			{
				this.h = new PageXObjectList();
			}
			br br = base.s().b(17);
			this.h.Add(xObject, this);
			br.a(32);
			br.a(68);
			br.a(111);
			br.a(10);
		}

		// Token: 0x0400175E RID: 5982
		private new static byte[] a = new byte[]
		{
			82,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			115
		};

		// Token: 0x0400175F RID: 5983
		private new static byte[] b = new byte[]
		{
			66,
			66,
			111,
			120
		};

		// Token: 0x04001760 RID: 5984
		private new static byte[] c = new byte[]
		{
			80,
			114,
			111,
			99,
			83,
			101,
			116
		};

		// Token: 0x04001761 RID: 5985
		private new static byte[] d = new byte[]
		{
			80,
			68,
			70
		};

		// Token: 0x04001762 RID: 5986
		private new static byte[] e = new byte[]
		{
			84,
			101,
			120,
			116
		};

		// Token: 0x04001763 RID: 5987
		private new static byte[] f = new byte[]
		{
			70,
			111,
			114,
			109,
			84,
			121,
			112,
			101
		};

		// Token: 0x04001764 RID: 5988
		private new static byte[] g = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			67,
			47,
			73,
			109,
			97,
			103,
			101,
			73,
			47,
			73,
			109,
			97,
			103,
			101,
			66
		};

		// Token: 0x04001765 RID: 5989
		private new PageXObjectList h;

		// Token: 0x04001766 RID: 5990
		private new PageExtGStateList i;

		// Token: 0x04001767 RID: 5991
		private TextWatermark j;

		// Token: 0x04001768 RID: 5992
		private ImageWatermark k;

		// Token: 0x04001769 RID: 5993
		private TextLineList l;

		// Token: 0x0400176A RID: 5994
		private float m = 0f;

		// Token: 0x0400176B RID: 5995
		private float n = 0f;
	}
}
