using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200048B RID: 1163
	internal class aee : Font
	{
		// Token: 0x06002FFF RID: 12287 RVA: 0x001B13A3 File Offset: 0x001B03A3
		internal aee() : base(aee.a, -205L)
		{
		}

		// Token: 0x06003000 RID: 12288 RVA: 0x001B13BC File Offset: 0x001B03BC
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.a);
			writer.WriteName(Font.c);
			writer.WriteName(aee.b);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06003001 RID: 12289 RVA: 0x001B1430 File Offset: 0x001B0430
		public override short GetGlyphWidth(char glyph)
		{
			return aee.c[(int)aee.a.a(glyph)];
		}

		// Token: 0x06003002 RID: 12290 RVA: 0x001B1454 File Offset: 0x001B0454
		public override short get_Descender()
		{
			return -220;
		}

		// Token: 0x06003003 RID: 12291 RVA: 0x001B146C File Offset: 0x001B046C
		public override short get_Ascender()
		{
			return 900;
		}

		// Token: 0x06003004 RID: 12292 RVA: 0x001B1484 File Offset: 0x001B0484
		public override short get_LineGap()
		{
			return 30;
		}

		// Token: 0x06003005 RID: 12293 RVA: 0x001B1498 File Offset: 0x001B0498
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06003006 RID: 12294 RVA: 0x001B14AC File Offset: 0x001B04AC
		internal override short bd()
		{
			return 250;
		}

		// Token: 0x06003007 RID: 12295 RVA: 0x001B14C4 File Offset: 0x001B04C4
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06003008 RID: 12296 RVA: 0x001B14D8 File Offset: 0x001B04D8
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06003009 RID: 12297 RVA: 0x001B14EC File Offset: 0x001B04EC
		public override int get_RequiredPdfObjects()
		{
			return 1;
		}

		// Token: 0x0600300A RID: 12298 RVA: 0x001B1500 File Offset: 0x001B0500
		public override string get_Name()
		{
			return "ZapfDingbats";
		}

		// Token: 0x0600300B RID: 12299 RVA: 0x001B1518 File Offset: 0x001B0518
		public override string get_FormFontName()
		{
			return "ZaDb";
		}

		// Token: 0x0600300C RID: 12300 RVA: 0x001B1530 File Offset: 0x001B0530
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Latin;
		}

		// Token: 0x0600300D RID: 12301 RVA: 0x001B1548 File Offset: 0x001B0548
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x0600300E RID: 12302 RVA: 0x001B1560 File Offset: 0x001B0560
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x040016DC RID: 5852
		private new static aef a = new aef();

		// Token: 0x040016DD RID: 5853
		private new static byte[] b = new byte[]
		{
			90,
			97,
			112,
			102,
			68,
			105,
			110,
			103,
			98,
			97,
			116,
			115
		};

		// Token: 0x040016DE RID: 5854
		private new static short[] c = new short[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			278,
			974,
			961,
			974,
			980,
			719,
			789,
			790,
			791,
			690,
			960,
			939,
			549,
			855,
			911,
			933,
			911,
			945,
			974,
			755,
			846,
			762,
			761,
			571,
			677,
			763,
			760,
			759,
			754,
			494,
			552,
			537,
			577,
			692,
			786,
			788,
			788,
			790,
			793,
			794,
			816,
			823,
			789,
			841,
			823,
			833,
			816,
			831,
			923,
			744,
			723,
			749,
			790,
			792,
			695,
			776,
			768,
			792,
			759,
			707,
			708,
			682,
			701,
			826,
			815,
			789,
			789,
			707,
			687,
			696,
			689,
			786,
			787,
			713,
			791,
			785,
			791,
			873,
			761,
			762,
			762,
			759,
			759,
			892,
			892,
			788,
			784,
			438,
			138,
			277,
			415,
			392,
			392,
			668,
			668,
			0,
			390,
			390,
			317,
			317,
			276,
			276,
			509,
			509,
			410,
			410,
			234,
			234,
			334,
			334,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			732,
			544,
			544,
			910,
			667,
			760,
			760,
			776,
			595,
			694,
			626,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			788,
			894,
			838,
			1016,
			458,
			748,
			924,
			748,
			918,
			927,
			928,
			928,
			834,
			873,
			828,
			924,
			924,
			917,
			930,
			931,
			463,
			883,
			836,
			836,
			867,
			867,
			696,
			696,
			874,
			0,
			874,
			760,
			946,
			771,
			865,
			771,
			888,
			967,
			888,
			831,
			873,
			927,
			970,
			918,
			0
		};
	}
}
