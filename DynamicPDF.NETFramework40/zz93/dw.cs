using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Text.OpenTypeFontTables;

namespace zz93
{
	// Token: 0x020000AB RID: 171
	internal class dw : Font
	{
		// Token: 0x060007FF RID: 2047 RVA: 0x00071E2E File Offset: 0x00070E2E
		internal dw(OpenTypeFont A_0, LineBreaker A_1) : base(A_0.Encoder)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00071E50 File Offset: 0x00070E50
		public override short get_Descender()
		{
			return this.a.Descender;
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00071E70 File Offset: 0x00070E70
		public override short get_Ascender()
		{
			return this.a.Ascender;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00071E90 File Offset: 0x00070E90
		internal override short bc()
		{
			return 0;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00071EA4 File Offset: 0x00070EA4
		internal override short bd()
		{
			return 0;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00071EB8 File Offset: 0x00070EB8
		internal override short be()
		{
			return 0;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00071ECC File Offset: 0x00070ECC
		internal override short bf()
		{
			return 0;
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00071EE0 File Offset: 0x00070EE0
		public override LineBreaker get_LineBreaker()
		{
			return this.b;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00071EF8 File Offset: 0x00070EF8
		public override string get_Name()
		{
			return this.a.a().u().a();
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00071F20 File Offset: 0x00070F20
		public override short GetGlyphWidth(char glyph)
		{
			return this.a.a().x().a()[(int)this.a.a().w().b()[(int)glyph]];
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00071F60 File Offset: 0x00070F60
		public override int get_RequiredPdfObjects()
		{
			return 4;
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00071F74 File Offset: 0x00070F74
		internal override string bg()
		{
			return this.Name;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00071F8C File Offset: 0x00070F8C
		internal override short bh()
		{
			return this.a.bh();
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00071FAC File Offset: 0x00070FAC
		internal override short bi()
		{
			return this.a.bi();
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00071FCC File Offset: 0x00070FCC
		public override void Draw(DocumentWriter writer)
		{
			this.b(writer);
			this.a(writer);
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.e);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(Resource.c);
			writer.WriteName(Resource.d);
			writer.WriteName(dw.c);
			writer.ai(this.a.a().ad().Length);
			if (this.a.OutLineType == OutLineType.PostScriptOutLine)
			{
				writer.WriteName(Resource.b);
				writer.WriteName(dw.g);
			}
			writer.WriteDictionaryClose();
			int value = writer.WriteStreamWithCompression(this.a.a().ad(), this.a.a().ad().Length);
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteNumber(value);
			writer.WriteEndObject();
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x000720CC File Offset: 0x000710CC
		private new void b(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(Resource.i);
			A_0.WriteName(Resource.b);
			if (this.a.OutLineType == OutLineType.TrueTypeOutline)
			{
				A_0.WriteName(dw.f);
			}
			else if (this.a.OutLineType == OutLineType.PostScriptOutLine)
			{
				A_0.WriteName(Font.a);
			}
			A_0.WriteName(Font.c);
			A_0.WriteName(this.a.a().u().a());
			A_0.WriteName(Font.d);
			A_0.WriteNumber0();
			A_0.WriteName(Font.e);
			A_0.WriteNumber(255);
			A_0.WriteName(Font.n);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(Font.g);
			A_0.WriteName(dw.h);
			A_0.WriteName(Font.f);
			A_0.WriteArrayOpen();
			short[] array = new short[256];
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < this.a.a().w().c().Length; j++)
				{
					if ((int)this.a.a().w().c()[j] == i)
					{
						array[i] = this.a.a().x().a()[j];
						break;
					}
				}
				if (i > 0 && array[i] == 0)
				{
					array[i] = array[0];
				}
				A_0.WriteNumber(array[i]);
			}
			A_0.WriteArrayClose();
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x000722B4 File Offset: 0x000712B4
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.a);
			A_0.WriteName(Font.n);
			A_0.WriteName(Font.y);
			A_0.WriteNumber(32);
			A_0.WriteName(Font.r);
			A_0.WriteName(this.a.a().u().a());
			A_0.WriteName(Font.p);
			A_0.WriteArrayOpen();
			A_0.WriteNumber(this.a.a().z().b());
			A_0.WriteNumber(this.a.a().z().c());
			A_0.WriteNumber(this.a.a().z().d());
			A_0.WriteNumber(this.a.a().z().e());
			A_0.WriteArrayClose();
			A_0.WriteName(Font.x);
			A_0.WriteNumber(this.a.a().v().a());
			A_0.WriteName(Font.v);
			A_0.WriteNumber(this.a.a().z().e());
			A_0.WriteName(Font.w);
			A_0.WriteNumber(this.a.a().z().c());
			A_0.WriteName(Font.u);
			A_0.WriteNumber(this.a.a().e());
			A_0.WriteName(Font.t);
			A_0.WriteNumber0();
			if (this.a.OutLineType == OutLineType.TrueTypeOutline)
			{
				A_0.WriteName(dw.d);
			}
			else if (this.a.OutLineType == OutLineType.PostScriptOutLine)
			{
				A_0.WriteName(dw.e);
			}
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x0400045C RID: 1116
		private new OpenTypeFont a;

		// Token: 0x0400045D RID: 1117
		private new LineBreaker b;

		// Token: 0x0400045E RID: 1118
		private new static byte[] c = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104,
			49
		};

		// Token: 0x0400045F RID: 1119
		private new static byte[] d = new byte[]
		{
			70,
			111,
			110,
			116,
			70,
			105,
			108,
			101,
			50
		};

		// Token: 0x04000460 RID: 1120
		private new static byte[] e = new byte[]
		{
			70,
			111,
			110,
			116,
			70,
			105,
			108,
			101,
			51
		};

		// Token: 0x04000461 RID: 1121
		private new static byte[] f = new byte[]
		{
			84,
			114,
			117,
			101,
			84,
			121,
			112,
			101
		};

		// Token: 0x04000462 RID: 1122
		private new static byte[] g = new byte[]
		{
			79,
			112,
			101,
			110,
			84,
			121,
			112,
			101
		};

		// Token: 0x04000463 RID: 1123
		private new static byte[] h = new byte[]
		{
			87,
			105,
			110,
			65,
			110,
			115,
			105,
			69,
			110,
			99,
			111,
			100,
			105,
			110,
			103
		};
	}
}
