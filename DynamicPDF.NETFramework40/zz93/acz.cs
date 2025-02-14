﻿using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000457 RID: 1111
	internal class acz : SingleByteEncoder
	{
		// Token: 0x06002DD9 RID: 11737 RVA: 0x001A056D File Offset: 0x0019F56D
		internal acz() : base(acz.b, 8482, false)
		{
		}

		// Token: 0x06002DDA RID: 11738 RVA: 0x001A0584 File Offset: 0x0019F584
		public override void DrawEncoding(DocumentWriter writer)
		{
			if (acz.c == null)
			{
				acz.c = new SingleByteEncodingResource(-302L, Encoding.ASCII.GetBytes("<</Type/Encoding/BaseEncoding/WinAnsiEncoding/Differences[142/caron 158/ogonek 168/Oslash 170/Rcommaaccent 175/AE 184/oslash 186/rcommaaccent 191/ae/Aogonek/Iogonek/Amacron/Cacute 198/Eogonek/Emacron/Ccaron 202/Zacute/Edotaccent/Gcommaaccent/Kcommaaccent/Imacron/Lcommaaccent/Scaron/Nacute/Ncommaaccent 212/Omacron 216/Uogonek/Lslash/Sacute/Umacron 221/Zdotaccent/Zcaron 224/aogonek/iogonek/amacron/cacute 230/eogonek/emacron/ccaron 234/zacute/edotaccent/gcommaaccent/kcommaaccent/imacron/lcommaaccent/scaron/nacute/ncommaaccent 244/omacron 248/uogonek/lslash/sacute/umacron 253/zdotaccent/zcaron/dotaccent]>>"));
			}
			writer.WriteName(ceTe.DynamicPDF.Text.Encoder.i);
			writer.WriteReference(writer.Resources.Add(acz.c));
		}

		// Token: 0x040015E3 RID: 5603
		private const string a = "<</Type/Encoding/BaseEncoding/WinAnsiEncoding/Differences[142/caron 158/ogonek 168/Oslash 170/Rcommaaccent 175/AE 184/oslash 186/rcommaaccent 191/ae/Aogonek/Iogonek/Amacron/Cacute 198/Eogonek/Emacron/Ccaron 202/Zacute/Edotaccent/Gcommaaccent/Kcommaaccent/Imacron/Lcommaaccent/Scaron/Nacute/Ncommaaccent 212/Omacron 216/Uogonek/Lslash/Sacute/Umacron 221/Zdotaccent/Zcaron 224/aogonek/iogonek/amacron/cacute 230/eogonek/emacron/ccaron 234/zacute/edotaccent/gcommaaccent/kcommaaccent/imacron/lcommaaccent/scaron/nacute/ncommaaccent 244/omacron 248/uogonek/lslash/sacute/umacron 253/zdotaccent/zcaron/dotaccent]>>";

		// Token: 0x040015E4 RID: 5604
		private static ushort[] b = new ushort[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
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
			127,
			8364,
			0,
			8218,
			0,
			8222,
			8230,
			8224,
			8225,
			0,
			8240,
			0,
			8249,
			0,
			168,
			711,
			184,
			0,
			8216,
			8217,
			8220,
			8221,
			8226,
			8211,
			8212,
			0,
			8482,
			0,
			8250,
			0,
			175,
			731,
			0,
			160,
			0,
			162,
			163,
			164,
			0,
			166,
			167,
			216,
			169,
			342,
			171,
			172,
			173,
			174,
			198,
			176,
			177,
			178,
			179,
			180,
			181,
			182,
			183,
			248,
			185,
			343,
			187,
			188,
			189,
			190,
			230,
			260,
			302,
			256,
			262,
			196,
			197,
			280,
			274,
			268,
			201,
			377,
			278,
			290,
			310,
			298,
			315,
			352,
			323,
			325,
			211,
			332,
			213,
			214,
			215,
			370,
			321,
			346,
			362,
			220,
			379,
			381,
			223,
			261,
			303,
			257,
			263,
			228,
			229,
			281,
			275,
			269,
			233,
			378,
			279,
			291,
			311,
			299,
			316,
			353,
			324,
			326,
			243,
			333,
			245,
			246,
			247,
			371,
			322,
			347,
			363,
			252,
			380,
			382,
			729
		};

		// Token: 0x040015E5 RID: 5605
		private static SingleByteEncodingResource c = null;
	}
}
