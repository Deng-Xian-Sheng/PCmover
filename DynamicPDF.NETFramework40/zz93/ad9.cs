using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Text.OpenTypeFontTables;
using ceTe.DynamicPDF.Xmp;

namespace zz93
{
	// Token: 0x02000486 RID: 1158
	internal class ad9 : ad1
	{
		// Token: 0x06002FCF RID: 12239 RVA: 0x001B0082 File Offset: 0x001AF082
		internal ad9()
		{
			this.j = base.b();
		}

		// Token: 0x06002FD0 RID: 12240 RVA: 0x001B00A0 File Offset: 0x001AF0A0
		internal override void jq(DocumentWriter A_0, OpenTypeFont A_1)
		{
			this.c(A_0, this.j);
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
			this.b(A_0, this.j);
			this.a(A_0, this.j);
			if (base.c())
			{
				ad8 ad2 = new ad8(A_0.FontSubsetter.GlyphsUsed);
				base.z().a(ad2);
				base.y().a(ad2);
				base.x().a(ad2);
				if (this.a != null)
				{
					this.a.a(ad2);
				}
				if (this.b != null)
				{
					this.b.a(ad2);
				}
				base.aa().a(ad2);
				if (this.c != null)
				{
					this.c.a(ad2);
				}
				if (base.w() != null)
				{
					base.w().a(ad2);
				}
				if (base.d())
				{
					this.d.a(A_0.FontSubsetter.GlyphsUsed);
				}
				this.d.a(ad2, base.d());
				this.e.jp(ad2, base.d());
				base.u().a(ad2);
				ad2.a(A_0);
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

		// Token: 0x06002FD1 RID: 12241 RVA: 0x001B03C4 File Offset: 0x001AF3C4
		internal override OutLineType jr()
		{
			return OutLineType.TrueTypeOutline;
		}

		// Token: 0x06002FD2 RID: 12242 RVA: 0x001B03D8 File Offset: 0x001AF3D8
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

		// Token: 0x06002FD3 RID: 12243 RVA: 0x001B04D8 File Offset: 0x001AF4D8
		private void b(DocumentWriter A_0, byte[] A_1)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(Resource.i);
			A_0.WriteName(Resource.b);
			A_0.WriteName(Font.i);
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
			if (base.c())
			{
				A_0.WriteName(Font.z);
				A_0.WriteName(ad9.i);
			}
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06002FD4 RID: 12244 RVA: 0x001B070C File Offset: 0x001AF70C
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
				A_0.WriteName(ad1.i);
				A_0.WriteReference(A_0.GetObjectNumber(1));
				A_0.WriteName(Font.aa);
				A_0.WriteReference(A_0.GetObjectNumber(3));
			}
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x06002FD5 RID: 12245 RVA: 0x001B08DA File Offset: 0x001AF8DA
		internal void a(adi A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002FD6 RID: 12246 RVA: 0x001B08E4 File Offset: 0x001AF8E4
		internal void a(adm A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002FD7 RID: 12247 RVA: 0x001B08EE File Offset: 0x001AF8EE
		internal void a(ad5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002FD8 RID: 12248 RVA: 0x001B08F8 File Offset: 0x001AF8F8
		internal void a(adn A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002FD9 RID: 12249 RVA: 0x001B0904 File Offset: 0x001AF904
		internal adx a()
		{
			return this.e;
		}

		// Token: 0x06002FDA RID: 12250 RVA: 0x001B091C File Offset: 0x001AF91C
		internal void a(adx A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06002FDB RID: 12251 RVA: 0x001B0928 File Offset: 0x001AF928
		internal override byte[] js()
		{
			return this.j;
		}

		// Token: 0x040016C7 RID: 5831
		private new adi a;

		// Token: 0x040016C8 RID: 5832
		private new adm b;

		// Token: 0x040016C9 RID: 5833
		private ad5 c;

		// Token: 0x040016CA RID: 5834
		private adn d;

		// Token: 0x040016CB RID: 5835
		private adx e;

		// Token: 0x040016CC RID: 5836
		private static byte[] f = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x040016CD RID: 5837
		private new static byte[] g = new byte[]
		{
			70,
			108,
			97,
			116,
			101,
			68,
			101,
			99,
			111,
			100,
			101
		};

		// Token: 0x040016CE RID: 5838
		private new static byte[] h = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104,
			49
		};

		// Token: 0x040016CF RID: 5839
		private new static byte[] i = new byte[]
		{
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121
		};

		// Token: 0x040016D0 RID: 5840
		private new byte[] j = null;
	}
}
