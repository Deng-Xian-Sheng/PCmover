using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200045D RID: 1117
	internal class ac5 : Font
	{
		// Token: 0x06002E11 RID: 11793 RVA: 0x001A1455 File Offset: 0x001A0455
		internal ac5() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002E12 RID: 11794 RVA: 0x001A1470 File Offset: 0x001A0470
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(ac5.b);
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
			writer.WriteName(ac5.b);
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
			writer.WriteNumber(-123);
			writer.WriteNumber(-257);
			writer.WriteNumber(1001);
			writer.WriteNumber(910);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002E13 RID: 11795 RVA: 0x001A16E8 File Offset: 0x001A06E8
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

		// Token: 0x06002E14 RID: 11796 RVA: 0x001A1728 File Offset: 0x001A0728
		public override short get_Descender()
		{
			return -143;
		}

		// Token: 0x06002E15 RID: 11797 RVA: 0x001A1740 File Offset: 0x001A0740
		public override short get_Ascender()
		{
			return 857;
		}

		// Token: 0x06002E16 RID: 11798 RVA: 0x001A1758 File Offset: 0x001A0758
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002E17 RID: 11799 RVA: 0x001A176C File Offset: 0x001A076C
		internal override short bd()
		{
			return 301;
		}

		// Token: 0x06002E18 RID: 11800 RVA: 0x001A1784 File Offset: 0x001A0784
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002E19 RID: 11801 RVA: 0x001A1798 File Offset: 0x001A0798
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x001A17AC File Offset: 0x001A07AC
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002E1B RID: 11803 RVA: 0x001A17C0 File Offset: 0x001A07C0
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002E1C RID: 11804 RVA: 0x001A17D8 File Offset: 0x001A07D8
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002E1D RID: 11805 RVA: 0x001A17F0 File Offset: 0x001A07F0
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002E1E RID: 11806 RVA: 0x001A1808 File Offset: 0x001A0808
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x040015F1 RID: 5617
		private new string a = "HeiseiMin-W3";

		// Token: 0x040015F2 RID: 5618
		private new static byte[] b = new byte[]
		{
			72,
			101,
			105,
			115,
			101,
			105,
			77,
			105,
			110,
			45,
			87,
			51
		};
	}
}
