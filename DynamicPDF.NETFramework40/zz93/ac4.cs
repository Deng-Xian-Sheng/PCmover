using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200045C RID: 1116
	internal class ac4 : Font
	{
		// Token: 0x06002E02 RID: 11778 RVA: 0x001A1074 File Offset: 0x001A0074
		internal ac4() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002E03 RID: 11779 RVA: 0x001A1090 File Offset: 0x001A0090
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(ac4.b);
			writer.WriteName(Font.g);
			writer.WriteName(Font.s);
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
			writer.WriteName(ac4.b);
			writer.WriteName(Font.k);
			writer.WriteDictionaryOpen();
			writer.WriteName(Font.l);
			writer.WriteText("Adobe");
			writer.WriteName(Font.o);
			writer.WriteText("Japan1");
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
			writer.WriteNumber(231);
			writer.WriteNumber(632);
			writer.WriteNumber(500);
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
			writer.WriteNumber(-92);
			writer.WriteNumber(-250);
			writer.WriteNumber(1010);
			writer.WriteNumber(922);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002E04 RID: 11780 RVA: 0x001A1308 File Offset: 0x001A0308
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

		// Token: 0x06002E05 RID: 11781 RVA: 0x001A1348 File Offset: 0x001A0348
		public override short get_Descender()
		{
			return -125;
		}

		// Token: 0x06002E06 RID: 11782 RVA: 0x001A135C File Offset: 0x001A035C
		public override short get_Ascender()
		{
			return 875;
		}

		// Token: 0x06002E07 RID: 11783 RVA: 0x001A1374 File Offset: 0x001A0374
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002E08 RID: 11784 RVA: 0x001A1388 File Offset: 0x001A0388
		internal override short bd()
		{
			return 301;
		}

		// Token: 0x06002E09 RID: 11785 RVA: 0x001A13A0 File Offset: 0x001A03A0
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002E0A RID: 11786 RVA: 0x001A13B4 File Offset: 0x001A03B4
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002E0B RID: 11787 RVA: 0x001A13C8 File Offset: 0x001A03C8
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002E0C RID: 11788 RVA: 0x001A13DC File Offset: 0x001A03DC
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002E0D RID: 11789 RVA: 0x001A13F4 File Offset: 0x001A03F4
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002E0E RID: 11790 RVA: 0x001A140C File Offset: 0x001A040C
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002E0F RID: 11791 RVA: 0x001A1424 File Offset: 0x001A0424
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x040015EF RID: 5615
		private new string a = "HeiseiKakuGo-W5";

		// Token: 0x040015F0 RID: 5616
		private new static byte[] b = new byte[]
		{
			72,
			101,
			105,
			115,
			101,
			105,
			75,
			97,
			107,
			117,
			71,
			111,
			45,
			87,
			53
		};
	}
}
