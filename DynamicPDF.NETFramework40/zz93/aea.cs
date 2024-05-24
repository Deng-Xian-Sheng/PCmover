using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000487 RID: 1159
	internal class aea : Font
	{
		// Token: 0x06002FDD RID: 12253 RVA: 0x001B09A6 File Offset: 0x001AF9A6
		internal aea() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002FDE RID: 12254 RVA: 0x001B09C4 File Offset: 0x001AF9C4
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(aea.b);
			writer.WriteName(Font.g);
			writer.WriteName(aea.c);
			writer.WriteName(Font.h);
			writer.WriteArrayOpen();
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.i);
			writer.WriteName(Font.c);
			writer.WriteName(aea.b);
			writer.WriteName(Font.k);
			writer.WriteDictionaryOpen();
			writer.WriteName(Font.l);
			writer.WriteText("Adobe");
			writer.WriteName(Font.o);
			writer.WriteText("GB1");
			writer.WriteName(Font.m);
			writer.WriteNumber(2);
			writer.WriteDictionaryClose();
			writer.WriteName(Font.n);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(87);
			writer.WriteArrayOpen();
			writer.WriteNumber1();
			writer.WriteNumber(95);
			writer.WriteNumber(500);
			writer.WriteNumber(814);
			writer.WriteNumber(939);
			writer.WriteNumber(500);
			writer.WriteNumber(7712);
			writer.WriteArrayOpen();
			writer.WriteNumber(500);
			writer.WriteArrayClose();
			writer.WriteNumber(7716);
			writer.WriteArrayOpen();
			writer.WriteNumber(500);
			writer.WriteArrayClose();
			writer.WriteArrayClose();
			writer.WriteName(Font.q);
			writer.WriteNumber(1000);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Font.n);
			writer.WriteName(Font.p);
			writer.WriteArrayOpen();
			writer.WriteNumber(-25);
			writer.WriteNumber(-254);
			writer.WriteNumber(1000);
			writer.WriteNumber(880);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002FDF RID: 12255 RVA: 0x001B0C88 File Offset: 0x001AFC88
		public override short GetGlyphWidth(char glyph)
		{
			short result;
			if (glyph > 'ÿ')
			{
				result = 1000;
			}
			else if (glyph >= ' ')
			{
				result = 500;
			}
			else
			{
				result = 1000;
			}
			return result;
		}

		// Token: 0x06002FE0 RID: 12256 RVA: 0x001B0CC8 File Offset: 0x001AFCC8
		public override short get_Descender()
		{
			return -120;
		}

		// Token: 0x06002FE1 RID: 12257 RVA: 0x001B0CDC File Offset: 0x001AFCDC
		public override short get_Ascender()
		{
			return 880;
		}

		// Token: 0x06002FE2 RID: 12258 RVA: 0x001B0CF4 File Offset: 0x001AFCF4
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002FE3 RID: 12259 RVA: 0x001B0D08 File Offset: 0x001AFD08
		internal override short bd()
		{
			return 249;
		}

		// Token: 0x06002FE4 RID: 12260 RVA: 0x001B0D20 File Offset: 0x001AFD20
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002FE5 RID: 12261 RVA: 0x001B0D34 File Offset: 0x001AFD34
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002FE6 RID: 12262 RVA: 0x001B0D48 File Offset: 0x001AFD48
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002FE7 RID: 12263 RVA: 0x001B0D5C File Offset: 0x001AFD5C
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002FE8 RID: 12264 RVA: 0x001B0D74 File Offset: 0x001AFD74
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002FE9 RID: 12265 RVA: 0x001B0D8C File Offset: 0x001AFD8C
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002FEA RID: 12266 RVA: 0x001B0DA4 File Offset: 0x001AFDA4
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x040016D1 RID: 5841
		private new string a = "STSong-Light";

		// Token: 0x040016D2 RID: 5842
		private new static byte[] b = new byte[]
		{
			83,
			84,
			83,
			111,
			110,
			103,
			45,
			76,
			105,
			103,
			104,
			116
		};

		// Token: 0x040016D3 RID: 5843
		private new static byte[] c = new byte[]
		{
			85,
			110,
			105,
			71,
			66,
			45,
			85,
			67,
			83,
			50,
			45,
			72
		};
	}
}
