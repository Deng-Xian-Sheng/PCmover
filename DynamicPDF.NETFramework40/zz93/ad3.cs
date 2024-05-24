using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Text.OpenTypeFontTables;
using ceTe.DynamicPDF.Xmp;

namespace zz93
{
	// Token: 0x02000480 RID: 1152
	internal class ad3 : ad1
	{
		// Token: 0x06002F9B RID: 12187 RVA: 0x001AEDE4 File Offset: 0x001ADDE4
		internal ad3()
		{
			this.b = base.b();
		}

		// Token: 0x06002F9C RID: 12188 RVA: 0x001AEE0C File Offset: 0x001ADE0C
		internal override void jq(DocumentWriter A_0, OpenTypeFont A_1)
		{
			this.c(A_0, this.b);
			FontSubsetter fontSubsetter = A_0.SetFontSubsetter(A_1);
			ad7 ad;
			if (fontSubsetter.b.Count > 0)
			{
				ad = new agg(fontSubsetter);
			}
			else
			{
				ad = new ad7(fontSubsetter.GlyphsUsed);
			}
			ad.k3(base.w().c());
			ad.a(A_0);
			this.b(A_0, this.b);
			this.a(A_0, this.b);
			if (base.c())
			{
				add add;
				if (base.d())
				{
					add = new add(A_0.FontSubsetter.GlyphsUsed);
				}
				else
				{
					add = new add(A_0.FontSubsetter.GlyphsUsed);
				}
				this.a.a(add, base.d());
				add.a(A_0);
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(Resource.e);
				A_0.WriteReference(A_0.GetObjectNumber(1));
				A_0.WriteName(Resource.c);
				A_0.WriteName(Resource.d);
				A_0.WriteDictionaryClose();
				PdfAStandard? pdfAStandard = A_0.Document.f();
				byte[] array;
				if (pdfAStandard != null)
				{
					if ((pdfAStandard == PdfAStandard.PdfA3a || pdfAStandard == PdfAStandard.PdfA3b || pdfAStandard == PdfAStandard.PdfA3u || pdfAStandard == PdfAStandard.PdfA2a || pdfAStandard == PdfAStandard.PdfA2b || pdfAStandard == PdfAStandard.PdfA2u) && base.d())
					{
						array = base.b(A_0);
					}
					else
					{
						array = base.a(A_0);
					}
				}
				else
				{
					array = base.a(A_0);
				}
				int value = A_0.WriteStreamWithCompression(array, array.Length);
				A_0.WriteEndObject();
				A_0.WriteBeginObject();
				A_0.WriteNumber(value);
				A_0.WriteEndObject();
			}
		}

		// Token: 0x06002F9D RID: 12189 RVA: 0x001AF06C File Offset: 0x001AE06C
		internal override OutLineType jr()
		{
			return OutLineType.PostScriptOutLine;
		}

		// Token: 0x06002F9E RID: 12190 RVA: 0x001AF080 File Offset: 0x001AE080
		private void c(DocumentWriter A_0, byte[] A_1)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(Resource.i);
			A_0.WriteName(Resource.b);
			A_0.WriteName(Font.b);
			A_0.WriteName(Font.c);
			if (base.c() && base.d())
			{
				A_0.WriteName(A_1, base.u().a());
			}
			else
			{
				A_0.WriteName(base.u().a());
			}
			A_0.WriteName(Font.g);
			A_0.WriteName(ad1.g);
			A_0.WriteName(ad1.h);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(Font.h);
			A_0.WriteArrayOpen();
			A_0.WriteReference(A_0.GetObjectNumber(3));
			A_0.WriteArrayClose();
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06002F9F RID: 12191 RVA: 0x001AF180 File Offset: 0x001AE180
		private void b(DocumentWriter A_0, byte[] A_1)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(Resource.i);
			A_0.WriteName(Resource.b);
			A_0.WriteName(Font.j);
			A_0.WriteName(Font.c);
			if (base.c() && base.d())
			{
				A_0.WriteName(A_1, base.u().a());
			}
			else
			{
				A_0.WriteName(base.u().a());
			}
			A_0.WriteName(Font.k);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Font.o);
			A_0.WriteText("Identity");
			A_0.WriteName(Font.l);
			A_0.WriteText("Adobe");
			A_0.WriteName(Font.m);
			A_0.WriteNumber0();
			A_0.WriteDictionaryClose();
			A_0.WriteName(Font.n);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(Font.q);
			A_0.WriteNumber(1000);
			A_0.WriteName(87);
			A_0.WriteArrayOpen();
			ushort num = 0;
			while ((int)num < base.aa().a())
			{
				if (A_0.FontSubsetter.GlyphsUsed[(int)num] && base.x().a()[(int)num] != 1000)
				{
					A_0.WriteNumber((int)num);
					A_0.WriteArrayOpen();
					A_0.WriteNumber(base.x().a()[(int)num]);
					while ((int)(num + 1) < base.aa().a() && A_0.FontSubsetter.GlyphsUsed[(int)(num + 1)])
					{
						A_0.WriteNumber(base.x().a()[(int)(num += 1)]);
					}
					A_0.WriteArrayClose();
				}
				num += 1;
			}
			A_0.WriteArrayClose();
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06002FA0 RID: 12192 RVA: 0x001AF38C File Offset: 0x001AE38C
		private void a(DocumentWriter A_0, byte[] A_1)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(Font.n);
			A_0.WriteName(Font.y);
			A_0.WriteNumber(32);
			A_0.WriteName(Font.r);
			if (base.c() && base.d())
			{
				A_0.WriteName(A_1, base.u().a());
			}
			else
			{
				A_0.WriteName(base.u().a());
			}
			A_0.WriteName(Font.p);
			A_0.WriteArrayOpen();
			A_0.WriteNumber(base.z().b());
			A_0.WriteNumber(base.z().c());
			A_0.WriteNumber(base.z().d());
			A_0.WriteNumber(base.z().e());
			A_0.WriteArrayClose();
			A_0.WriteName(Font.x);
			A_0.WriteNumber(base.v().a());
			A_0.WriteName(Font.v);
			A_0.WriteNumber(base.z().e());
			A_0.WriteName(Font.w);
			A_0.WriteNumber(base.z().c());
			A_0.WriteName(Font.u);
			A_0.WriteNumber(base.e());
			A_0.WriteName(Font.t);
			A_0.WriteNumber0();
			if (base.c())
			{
				A_0.WriteName(ad1.j);
				A_0.WriteReference(A_0.GetObjectNumber(1));
				A_0.WriteName(Font.aa);
				A_0.WriteReference(A_0.GetObjectNumber(3));
			}
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06002FA1 RID: 12193 RVA: 0x001AF55C File Offset: 0x001AE55C
		internal adc a()
		{
			return this.a;
		}

		// Token: 0x06002FA2 RID: 12194 RVA: 0x001AF574 File Offset: 0x001AE574
		internal void a(adc A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002FA3 RID: 12195 RVA: 0x001AF580 File Offset: 0x001AE580
		internal override byte[] js()
		{
			return this.b;
		}

		// Token: 0x040016AB RID: 5803
		private new adc a = null;

		// Token: 0x040016AC RID: 5804
		private new byte[] b = null;
	}
}
