using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200045B RID: 1115
	internal class ac3 : Font
	{
		// Token: 0x06002DF3 RID: 11763 RVA: 0x001A0C7C File Offset: 0x0019FC7C
		internal ac3() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002DF4 RID: 11764 RVA: 0x001A0C98 File Offset: 0x0019FC98
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(ac3.b);
			writer.WriteName(Font.g);
			writer.WriteName(ac3.c);
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
			writer.WriteName(ac3.b);
			writer.WriteName(Font.k);
			writer.WriteDictionaryOpen();
			writer.WriteName(Font.l);
			writer.WriteText("Adobe");
			writer.WriteName(Font.o);
			writer.WriteText("Korea1");
			writer.WriteName(Font.m);
			writer.WriteNumber1();
			writer.WriteDictionaryClose();
			writer.WriteName(Font.n);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(87);
			writer.WriteArrayOpen();
			writer.WriteNumber1();
			writer.WriteNumber(95);
			writer.WriteNumber(500);
			writer.WriteNumber(8094);
			writer.WriteNumber(8190);
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
			writer.WriteNumber0();
			writer.WriteNumber(-148);
			writer.WriteNumber(1001);
			writer.WriteNumber(880);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002DF5 RID: 11765 RVA: 0x001A0F10 File Offset: 0x0019FF10
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

		// Token: 0x06002DF6 RID: 11766 RVA: 0x001A0F50 File Offset: 0x0019FF50
		public override short get_Descender()
		{
			return -120;
		}

		// Token: 0x06002DF7 RID: 11767 RVA: 0x001A0F64 File Offset: 0x0019FF64
		public override short get_Ascender()
		{
			return 880;
		}

		// Token: 0x06002DF8 RID: 11768 RVA: 0x001A0F7C File Offset: 0x0019FF7C
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002DF9 RID: 11769 RVA: 0x001A0F90 File Offset: 0x0019FF90
		internal override short bd()
		{
			return 286;
		}

		// Token: 0x06002DFA RID: 11770 RVA: 0x001A0FA8 File Offset: 0x0019FFA8
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002DFB RID: 11771 RVA: 0x001A0FBC File Offset: 0x0019FFBC
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002DFC RID: 11772 RVA: 0x001A0FD0 File Offset: 0x0019FFD0
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002DFD RID: 11773 RVA: 0x001A0FE4 File Offset: 0x0019FFE4
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002DFE RID: 11774 RVA: 0x001A0FFC File Offset: 0x0019FFFC
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002DFF RID: 11775 RVA: 0x001A1014 File Offset: 0x001A0014
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002E00 RID: 11776 RVA: 0x001A102C File Offset: 0x001A002C
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x040015EC RID: 5612
		private new string a = "HYSMyeongJo-Medium";

		// Token: 0x040015ED RID: 5613
		private new static byte[] b = new byte[]
		{
			72,
			89,
			83,
			77,
			121,
			101,
			111,
			110,
			103,
			74,
			111,
			45,
			77,
			101,
			100,
			105,
			117,
			109
		};

		// Token: 0x040015EE RID: 5614
		private new static byte[] c = new byte[]
		{
			85,
			110,
			105,
			75,
			83,
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
