using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000856 RID: 2134
	public abstract class CoreLatinFont : Font
	{
		// Token: 0x06005696 RID: 22166 RVA: 0x0029B408 File Offset: 0x0029A408
		internal CoreLatinFont(short[] A_0, SingleByteEncoder A_1, long A_2, string A_3, short A_4, short A_5, short A_6) : base(A_1, A_2)
		{
			this.i = A_1;
			this.h = A_3;
			this.j = A_4;
			this.k = A_5;
			this.l = A_6;
			for (int i = 0; i < CoreLatinFont.a.Length; i++)
			{
				this.m[(int)CoreLatinFont.a[i]] = A_0[i];
			}
			if (this.i.Encode('◊') == 0)
			{
				this.b = 0;
			}
			else
			{
				this.b = A_0[320];
			}
			if (this.i.Encode('') == 0)
			{
				this.c = 0;
			}
			else
			{
				this.c = A_0[321];
			}
			if (this.i.Encode('') == 0)
			{
				this.d = 0;
			}
			else
			{
				this.d = A_0[322];
			}
			if (this.i.Encode('') == 0)
			{
				this.e = 0;
			}
			else
			{
				this.e = A_0[323];
			}
			if (this.i.Encode('ﬁ') == 0)
			{
				this.f = 0;
			}
			else
			{
				this.f = A_0[324];
			}
			if (this.i.Encode('ﬂ') == 0)
			{
				this.g = 0;
			}
			else
			{
				this.g = A_0[325];
			}
		}

		// Token: 0x06005697 RID: 22167 RVA: 0x0029B5A0 File Offset: 0x0029A5A0
		internal CoreLatinFont(short A_0, SingleByteEncoder A_1, long A_2, string A_3, short A_4, short A_5, short A_6) : base(A_1, A_2)
		{
			this.i = A_1;
			this.h = A_3;
			this.j = A_4;
			this.k = A_5;
			this.l = A_6;
			for (int i = 0; i < CoreLatinFont.a.Length; i++)
			{
				this.m[(int)CoreLatinFont.a[i]] = A_0;
			}
			if (this.i.Encode('◊') == 0)
			{
				this.b = 0;
			}
			else
			{
				this.b = A_0;
			}
			if (this.i.Encode('') == 0)
			{
				this.c = 0;
			}
			else
			{
				this.c = A_0;
			}
			if (this.i.Encode('') == 0)
			{
				this.d = 0;
			}
			else
			{
				this.d = A_0;
			}
			if (this.i.Encode('') == 0)
			{
				this.e = 0;
			}
			else
			{
				this.e = A_0;
			}
			if (this.i.Encode('ﬁ') == 0)
			{
				this.f = 0;
			}
			else
			{
				this.f = A_0;
			}
			if (this.i.Encode('ﬂ') == 0)
			{
				this.g = 0;
			}
			else
			{
				this.g = A_0;
			}
		}

		// Token: 0x06005698 RID: 22168 RVA: 0x0029B714 File Offset: 0x0029A714
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.a);
			writer.WriteName(Font.c);
			writer.WriteName(this.h);
			base.Encoder.DrawEncoding(writer);
			if (!this.i.IsBuiltInEncoding)
			{
				writer.WriteName(Font.d);
				writer.WriteNumber(32);
				writer.WriteName(Font.e);
				writer.WriteNumber(255);
				writer.WriteName(Font.f);
				writer.WriteArrayOpen();
				for (int i = 32; i < 256; i++)
				{
					writer.WriteNumber(this.GetGlyphWidth(this.i.Decode((byte)i)));
				}
				writer.WriteArrayClose();
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06005699 RID: 22169 RVA: 0x0029B820 File Offset: 0x0029A820
		public override short GetGlyphWidth(char glyph)
		{
			short result;
			if (glyph < '≦')
			{
				result = this.m[(int)glyph];
			}
			else if (glyph != '◊')
			{
				switch (glyph)
				{
				case '':
					result = this.c;
					break;
				case '':
					result = this.d;
					break;
				case '':
					result = this.e;
					break;
				default:
					switch (glyph)
					{
					case 'ﬁ':
						result = this.f;
						break;
					case 'ﬂ':
						result = this.g;
						break;
					default:
						result = 0;
						break;
					}
					break;
				}
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x0600569A RID: 22170 RVA: 0x0029B8C0 File Offset: 0x0029A8C0
		public override short Descender
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x0600569B RID: 22171 RVA: 0x0029B8D8 File Offset: 0x0029A8D8
		public override short Ascender
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x0600569C RID: 22172 RVA: 0x0029B8F0 File Offset: 0x0029A8F0
		public override short LineGap
		{
			get
			{
				return this.l;
			}
		}

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x0600569D RID: 22173 RVA: 0x0029B908 File Offset: 0x0029A908
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x0600569E RID: 22174 RVA: 0x0029B91C File Offset: 0x0029A91C
		public override string Name
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x0600569F RID: 22175 RVA: 0x0029B934 File Offset: 0x0029A934
		public SingleByteEncoder SingleByteEncoder
		{
			get
			{
				return this.i;
			}
		}

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x060056A0 RID: 22176 RVA: 0x0029B94C File Offset: 0x0029A94C
		public override LineBreaker LineBreaker
		{
			get
			{
				return LineBreaker.Latin;
			}
		}

		// Token: 0x060056A1 RID: 22177 RVA: 0x0029B964 File Offset: 0x0029A964
		internal override short bc()
		{
			return 52;
		}

		// Token: 0x060056A2 RID: 22178 RVA: 0x0029B978 File Offset: 0x0029A978
		internal override short bd()
		{
			return 261;
		}

		// Token: 0x060056A3 RID: 22179 RVA: 0x0029B990 File Offset: 0x0029A990
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x060056A4 RID: 22180 RVA: 0x0029B9A8 File Offset: 0x0029A9A8
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x04002E24 RID: 11812
		private new static short[] a = new short[]
		{
			32,
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62,
			63,
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95,
			96,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			123,
			124,
			125,
			126,
			160,
			161,
			162,
			163,
			164,
			165,
			166,
			167,
			168,
			169,
			170,
			171,
			172,
			173,
			174,
			175,
			176,
			177,
			178,
			179,
			180,
			181,
			182,
			183,
			184,
			185,
			186,
			187,
			188,
			189,
			190,
			191,
			192,
			193,
			194,
			195,
			196,
			197,
			198,
			199,
			200,
			201,
			202,
			203,
			204,
			205,
			206,
			207,
			208,
			209,
			210,
			211,
			212,
			213,
			214,
			215,
			216,
			217,
			218,
			219,
			220,
			221,
			222,
			223,
			224,
			225,
			226,
			227,
			228,
			229,
			230,
			231,
			232,
			233,
			234,
			235,
			236,
			237,
			238,
			239,
			240,
			241,
			242,
			243,
			244,
			245,
			246,
			247,
			248,
			249,
			250,
			251,
			252,
			253,
			254,
			255,
			256,
			257,
			258,
			259,
			260,
			261,
			262,
			263,
			268,
			269,
			270,
			271,
			272,
			273,
			274,
			275,
			278,
			279,
			280,
			281,
			282,
			283,
			286,
			287,
			290,
			291,
			298,
			299,
			302,
			303,
			304,
			305,
			310,
			311,
			313,
			314,
			315,
			316,
			317,
			318,
			321,
			322,
			323,
			324,
			325,
			326,
			327,
			328,
			332,
			333,
			336,
			337,
			338,
			339,
			340,
			341,
			342,
			343,
			344,
			345,
			346,
			347,
			350,
			351,
			352,
			353,
			354,
			355,
			356,
			357,
			362,
			363,
			366,
			367,
			368,
			369,
			370,
			371,
			376,
			377,
			378,
			379,
			380,
			381,
			382,
			402,
			536,
			537,
			538,
			539,
			710,
			711,
			713,
			728,
			729,
			730,
			731,
			732,
			733,
			916,
			956,
			8211,
			8212,
			8216,
			8217,
			8218,
			8220,
			8221,
			8222,
			8224,
			8225,
			8226,
			8230,
			8240,
			8249,
			8250,
			8260,
			8364,
			8482,
			8706,
			8710,
			8721,
			8722,
			8725,
			8729,
			8730,
			8800,
			8804,
			8805
		};

		// Token: 0x04002E25 RID: 11813
		private new short b;

		// Token: 0x04002E26 RID: 11814
		private new short c;

		// Token: 0x04002E27 RID: 11815
		private new short d;

		// Token: 0x04002E28 RID: 11816
		private new short e;

		// Token: 0x04002E29 RID: 11817
		private new short f;

		// Token: 0x04002E2A RID: 11818
		private new short g;

		// Token: 0x04002E2B RID: 11819
		private new string h;

		// Token: 0x04002E2C RID: 11820
		private new SingleByteEncoder i;

		// Token: 0x04002E2D RID: 11821
		private new short j;

		// Token: 0x04002E2E RID: 11822
		private new short k;

		// Token: 0x04002E2F RID: 11823
		private new short l;

		// Token: 0x04002E30 RID: 11824
		private new short[] m = new short[8806];
	}
}
