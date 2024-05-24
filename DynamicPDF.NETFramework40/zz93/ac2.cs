using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200045A RID: 1114
	internal class ac2 : Font
	{
		// Token: 0x06002DE4 RID: 11748 RVA: 0x001A0882 File Offset: 0x0019F882
		internal ac2() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002DE5 RID: 11749 RVA: 0x001A08A0 File Offset: 0x0019F8A0
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(ac2.b);
			writer.WriteName(Font.g);
			writer.WriteName(ac2.c);
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
			writer.WriteName(ac2.b);
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
			writer.WriteNumber(-6);
			writer.WriteNumber(-145);
			writer.WriteNumber(1003);
			writer.WriteNumber(880);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002DE6 RID: 11750 RVA: 0x001A0B18 File Offset: 0x0019FB18
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

		// Token: 0x06002DE7 RID: 11751 RVA: 0x001A0B58 File Offset: 0x0019FB58
		public override short get_Descender()
		{
			return -120;
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x001A0B6C File Offset: 0x0019FB6C
		public override short get_Ascender()
		{
			return 880;
		}

		// Token: 0x06002DE9 RID: 11753 RVA: 0x001A0B84 File Offset: 0x0019FB84
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002DEA RID: 11754 RVA: 0x001A0B98 File Offset: 0x0019FB98
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002DEB RID: 11755 RVA: 0x001A0BAC File Offset: 0x0019FBAC
		internal override short bd()
		{
			return 286;
		}

		// Token: 0x06002DEC RID: 11756 RVA: 0x001A0BC4 File Offset: 0x0019FBC4
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002DED RID: 11757 RVA: 0x001A0BD8 File Offset: 0x0019FBD8
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002DEE RID: 11758 RVA: 0x001A0BEC File Offset: 0x0019FBEC
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002DEF RID: 11759 RVA: 0x001A0C04 File Offset: 0x0019FC04
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002DF0 RID: 11760 RVA: 0x001A0C1C File Offset: 0x0019FC1C
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002DF1 RID: 11761 RVA: 0x001A0C34 File Offset: 0x0019FC34
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x040015E9 RID: 5609
		private new string a = "HYGoThic-Medium";

		// Token: 0x040015EA RID: 5610
		private new static byte[] b = new byte[]
		{
			72,
			89,
			71,
			111,
			84,
			104,
			105,
			99,
			45,
			77,
			101,
			100,
			105,
			117,
			109
		};

		// Token: 0x040015EB RID: 5611
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
