﻿using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000462 RID: 1122
	internal class ac9 : SingleByteEncoder
	{
		// Token: 0x06002EA8 RID: 11944 RVA: 0x001A8AC3 File Offset: 0x001A7AC3
		internal ac9() : base(ac9.b, 8364, false)
		{
		}

		// Token: 0x06002EA9 RID: 11945 RVA: 0x001A8ADC File Offset: 0x001A7ADC
		public override void DrawEncoding(DocumentWriter writer)
		{
			if (ac9.c == null)
			{
				ac9.c = new SingleByteEncodingResource(-304L, Encoding.ASCII.GetBytes("<</Type/Encoding/BaseEncoding/WinAnsiEncoding/Differences[164/Euro 166/Scaron 168/scaron 180/Zcaron 184/zcaron 188/OE/oe/Ydieresis]>>"));
			}
			writer.WriteName(ceTe.DynamicPDF.Text.Encoder.i);
			writer.WriteReference(writer.Resources.Add(ac9.c));
		}

		// Token: 0x04001621 RID: 5665
		private const string a = "<</Type/Encoding/BaseEncoding/WinAnsiEncoding/Differences[164/Euro 166/Scaron 168/scaron 180/Zcaron 184/zcaron 188/OE/oe/Ydieresis]>>";

		// Token: 0x04001622 RID: 5666
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
			160,
			161,
			162,
			163,
			8364,
			165,
			352,
			167,
			353,
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
			381,
			181,
			182,
			183,
			382,
			185,
			186,
			187,
			338,
			339,
			376,
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
			255
		};

		// Token: 0x04001623 RID: 5667
		private static SingleByteEncodingResource c = null;
	}
}
