using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000855 RID: 2133
	public class CeTeBullets : Font
	{
		// Token: 0x06005686 RID: 22150 RVA: 0x0029ADA0 File Offset: 0x00299DA0
		internal CeTeBullets() : base(ceTe.DynamicPDF.Text.CeTeBullets.i)
		{
		}

		// Token: 0x06005687 RID: 22151 RVA: 0x0029ADB0 File Offset: 0x00299DB0
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.a);
			writer.WriteName(Font.p);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber(500);
			writer.WriteNumber(600);
			writer.WriteArrayClose();
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.b);
			writer.WriteArrayOpen();
			writer.WriteNumberColor(0.001f);
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumberColor(0.001f);
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteArrayClose();
			writer.WriteName(Font.g);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.c);
			writer.WriteReference(writer.GetObjectNumber(2));
			writer.WriteName(Font.d);
			writer.WriteNumber(97);
			writer.WriteName(Font.e);
			writer.WriteNumber(100);
			writer.WriteName(Font.f);
			writer.WriteArrayOpen();
			writer.WriteNumber(500);
			writer.WriteNumber(500);
			writer.WriteNumber(500);
			writer.WriteNumber(500);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Font.g);
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.d);
			writer.WriteArrayOpen();
			writer.WriteNumber(97);
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.e);
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.f);
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.g);
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.h);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.e);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.f);
			writer.WriteReference(writer.GetObjectNumber(2));
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.g);
			writer.WriteReference(writer.GetObjectNumber(3));
			writer.WriteName(ceTe.DynamicPDF.Text.CeTeBullets.h);
			writer.WriteReference(writer.GetObjectNumber(4));
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.c);
			writer.WriteName(Resource.d);
			writer.WriteName(Resource.e);
			writer.ai(ceTe.DynamicPDF.Text.CeTeBullets.j.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(ceTe.DynamicPDF.Text.CeTeBullets.j, 0, ceTe.DynamicPDF.Text.CeTeBullets.j.Length);
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.c);
			writer.WriteName(Resource.d);
			writer.WriteName(Resource.e);
			writer.ai(ceTe.DynamicPDF.Text.CeTeBullets.k.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(ceTe.DynamicPDF.Text.CeTeBullets.k, 0, ceTe.DynamicPDF.Text.CeTeBullets.k.Length);
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.e);
			writer.ai(ceTe.DynamicPDF.Text.CeTeBullets.l.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(ceTe.DynamicPDF.Text.CeTeBullets.l, 0, ceTe.DynamicPDF.Text.CeTeBullets.l.Length);
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.e);
			writer.ai(ceTe.DynamicPDF.Text.CeTeBullets.m.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(ceTe.DynamicPDF.Text.CeTeBullets.m, 0, ceTe.DynamicPDF.Text.CeTeBullets.m.Length);
			writer.WriteEndObject();
		}

		// Token: 0x06005688 RID: 22152 RVA: 0x0029B1A4 File Offset: 0x0029A1A4
		public override short GetGlyphWidth(char glyph)
		{
			short result;
			if (glyph >= 'a' && glyph <= 'd')
			{
				result = 500;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06005689 RID: 22153 RVA: 0x0029B1D4 File Offset: 0x0029A1D4
		internal override short bc()
		{
			return 102;
		}

		// Token: 0x0600568A RID: 22154 RVA: 0x0029B1E8 File Offset: 0x0029A1E8
		internal override short bd()
		{
			return 250;
		}

		// Token: 0x0600568B RID: 22155 RVA: 0x0029B200 File Offset: 0x0029A200
		internal override short be()
		{
			return 0;
		}

		// Token: 0x0600568C RID: 22156 RVA: 0x0029B214 File Offset: 0x0029A214
		internal override short bf()
		{
			return 0;
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x0600568D RID: 22157 RVA: 0x0029B228 File Offset: 0x0029A228
		public override short Descender
		{
			get
			{
				return 50;
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x0600568E RID: 22158 RVA: 0x0029B23C File Offset: 0x0029A23C
		public override short Ascender
		{
			get
			{
				return 800;
			}
		}

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x0600568F RID: 22159 RVA: 0x0029B254 File Offset: 0x0029A254
		public override short LineGap
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06005690 RID: 22160 RVA: 0x0029B268 File Offset: 0x0029A268
		public override int RequiredPdfObjects
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06005691 RID: 22161 RVA: 0x0029B27C File Offset: 0x0029A27C
		public override string Name
		{
			get
			{
				return "CeTeBullets";
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06005692 RID: 22162 RVA: 0x0029B294 File Offset: 0x0029A294
		public override LineBreaker LineBreaker
		{
			get
			{
				return LineBreaker.Latin;
			}
		}

		// Token: 0x06005693 RID: 22163 RVA: 0x0029B2AC File Offset: 0x0029A2AC
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06005694 RID: 22164 RVA: 0x0029B2C4 File Offset: 0x0029A2C4
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x04002E17 RID: 11799
		private new static byte[] a = new byte[]
		{
			84,
			121,
			112,
			101,
			51
		};

		// Token: 0x04002E18 RID: 11800
		private new static byte[] b = new byte[]
		{
			70,
			111,
			110,
			116,
			77,
			97,
			116,
			114,
			105,
			120
		};

		// Token: 0x04002E19 RID: 11801
		private new static byte[] c = new byte[]
		{
			67,
			104,
			97,
			114,
			80,
			114,
			111,
			99,
			115
		};

		// Token: 0x04002E1A RID: 11802
		private new static byte[] d = new byte[]
		{
			68,
			105,
			102,
			102,
			101,
			114,
			101,
			110,
			99,
			101,
			115
		};

		// Token: 0x04002E1B RID: 11803
		private new static byte[] e = new byte[]
		{
			99,
			105,
			114,
			99,
			108,
			101
		};

		// Token: 0x04002E1C RID: 11804
		private new static byte[] f = new byte[]
		{
			100,
			105,
			115,
			99
		};

		// Token: 0x04002E1D RID: 11805
		private new static byte[] g = new byte[]
		{
			115,
			113,
			117,
			97,
			114,
			101
		};

		// Token: 0x04002E1E RID: 11806
		private new static byte[] h = new byte[]
		{
			98,
			111,
			120
		};

		// Token: 0x04002E1F RID: 11807
		private new static ac1 i = new ac1();

		// Token: 0x04002E20 RID: 11808
		private new static byte[] j = new byte[]
		{
			120,
			156,
			69,
			78,
			57,
			18,
			196,
			48,
			8,
			235,
			253,
			10,
			234,
			45,
			60,
			200,
			134,
			196,
			121,
			79,
			118,
			182,
			219,
			byte.MaxValue,
			183,
			49,
			68,
			99,
			119,
			18,
			58,
			16,
			84,
			85,
			84,
			92,
			101,
			34,
			49,
			15,
			168,
			242,
			69,
			105,
			132,
			byte.MaxValue,
			210,
			15,
			173,
			230,
			73,
			66,
			55,
			36,
			13,
			216,
			231,
			233,
			46,
			129,
			48,
			174,
			234,
			38,
			180,
			70,
			85,
			99,
			229,
			93,
			208,
			83,
			11,
			178,
			157,
			43,
			189,
			27,
			233,
			115,
			134,
			61,
			229,
			64,
			241,
			96,
			206,
			232,
			173,
			14,
			123,
			39,
			76,
			169,
			143,
			151,
			234,
			154,
			17,
			57,
			156,
			21,
			46,
			180,
			194,
			57,
			195,
			115,
			198,
			145,
			26,
			184,
			139,
			86,
			172,
			60,
			118,
			41,
			173,
			198,
			188,
			101,
			254,
			247,
			41,
			15,
			166,
			43,
			55,
			117
		};

		// Token: 0x04002E21 RID: 11809
		private new static byte[] k = new byte[]
		{
			120,
			156,
			69,
			140,
			187,
			13,
			128,
			48,
			12,
			68,
			123,
			79,
			113,
			19,
			68,
			231,
			196,
			70,
			48,
			79,
			16,
			29,
			251,
			183,
			196,
			150,
			69,
			186,
			119,
			95,
			37,
			9,
			194,
			137,
			69,
			48,
			15,
			36,
			110,
			149,
			94,
			248,
			202,
			56,
			216,
			204,
			83,
			68,
			110,
			154,
			50,
			112,
			44,
			107,
			74,
			144,
			158,
			87,
			115,
			67,
			85,
			227,
			170,
			215,
			229,
			20,
			29,
			153,
			133,
			216,
			205,
			127,
			189,
			31,
			171,
			231,
			53,
			246,
			140,
			31,
			249,
			0,
			115,
			198,
			29,
			206
		};

		// Token: 0x04002E22 RID: 11810
		private new static byte[] l = new byte[]
		{
			49,
			48,
			48,
			48,
			32,
			48,
			32,
			53,
			48,
			32,
			49,
			48,
			48,
			32,
			52,
			53,
			48,
			32,
			53,
			48,
			48,
			32,
			100,
			49,
			10,
			53,
			48,
			32,
			49,
			48,
			48,
			32,
			52,
			48,
			48,
			32,
			52,
			48,
			48,
			32,
			114,
			101,
			10,
			49,
			48,
			48,
			32,
			49,
			53,
			48,
			32,
			51,
			48,
			48,
			32,
			51,
			48,
			48,
			32,
			114,
			101,
			10,
			102,
			42,
			10
		};

		// Token: 0x04002E23 RID: 11811
		private new static byte[] m = new byte[]
		{
			49,
			48,
			48,
			48,
			32,
			48,
			32,
			53,
			48,
			32,
			49,
			48,
			48,
			32,
			52,
			53,
			48,
			32,
			53,
			48,
			48,
			32,
			100,
			49,
			10,
			53,
			48,
			32,
			49,
			48,
			48,
			32,
			52,
			48,
			48,
			32,
			52,
			48,
			48,
			32,
			114,
			101,
			10,
			102,
			10
		};
	}
}
