using System;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000088 RID: 136
	internal abstract class c1
	{
		// Token: 0x0600062F RID: 1583
		internal abstract string bx(de A_0);

		// Token: 0x06000630 RID: 1584
		internal abstract bool bz();

		// Token: 0x06000631 RID: 1585
		internal abstract bool b0();

		// Token: 0x06000632 RID: 1586 RVA: 0x0005B618 File Offset: 0x0005A618
		internal virtual Font b1()
		{
			return this.c;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0005B630 File Offset: 0x0005A630
		internal string a()
		{
			return "WinAnsiEncoding";
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0005B648 File Offset: 0x0005A648
		internal string b()
		{
			return "MacRomanEncoding";
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0005B660 File Offset: 0x0005A660
		internal virtual char? by(byte A_0)
		{
			return null;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0005B67C File Offset: 0x0005A67C
		internal virtual char? b2(string A_0)
		{
			return null;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0005B698 File Offset: 0x0005A698
		internal byte[] a(byte[] A_0)
		{
			byte[] array = new byte[A_0.Length];
			int num = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				bool flag = true;
				if (A_0[i].Equals(92) && ((i > 0 && A_0[i - 1] != 92) || i == 0))
				{
					byte[] array2 = new byte[3];
					int num2 = 0;
					if (i + 3 < A_0.Length)
					{
						for (int j = i + 1; j < i + 4; j++)
						{
							if (A_0[j] <= 47 || A_0[j] >= 56)
							{
								flag = false;
								break;
							}
							array2[num2] = A_0[j];
							num2++;
							if (j == i + 3 && j + 1 < A_0.Length && A_0[j + 1] > 47 && A_0[j + 1] < 56 && array2[0] == 92)
							{
								flag = false;
								break;
							}
						}
					}
					else
					{
						flag = false;
					}
					if (!flag)
					{
						array[num] = A_0[i];
						num++;
					}
					else
					{
						char[] value = new char[]
						{
							Convert.ToChar(array2[0]),
							Convert.ToChar(array2[1]),
							Convert.ToChar(array2[2])
						};
						string value2 = new string(value);
						int value3 = Convert.ToInt32(value2, 8);
						byte[] bytes = BitConverter.GetBytes(value3);
						Array.Copy(bytes, 0, array, num, 1);
						num++;
						Array.Copy(A_0, i + 4, array, num, A_0.Length - (i + 4));
						i += 3;
					}
				}
				else
				{
					array[num] = A_0[i];
					num++;
				}
			}
			Array.Resize<byte>(ref array, num);
			return array;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0005B868 File Offset: 0x0005A868
		internal byte a(int A_0, byte[] A_1)
		{
			byte b = A_1[A_0];
			if (b <= 92)
			{
				if (b <= 34)
				{
					if (b == 13)
					{
						return 32;
					}
					if (b == 34)
					{
						return 34;
					}
				}
				else
				{
					switch (b)
					{
					case 39:
						return 39;
					case 40:
						return 40;
					case 41:
						return 41;
					default:
						if (b == 92)
						{
							return 92;
						}
						break;
					}
				}
			}
			else if (b <= 102)
			{
				switch (b)
				{
				case 97:
					return 7;
				case 98:
					return 8;
				default:
					if (b == 102)
					{
						return 12;
					}
					break;
				}
			}
			else
			{
				if (b == 110)
				{
					return 10;
				}
				switch (b)
				{
				case 114:
					return 13;
				case 116:
					return 9;
				case 118:
					return 11;
				}
			}
			return 0;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0005B93C File Offset: 0x0005A93C
		internal byte[] b(byte[] A_0)
		{
			byte[] array = new byte[A_0.Length];
			int num = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] == 92 && i + 1 < A_0.Length)
				{
					byte b = this.a(i + 1, A_0);
					if (b != 0)
					{
						array[num] = b;
						i++;
					}
					else
					{
						array[num] = A_0[i];
					}
				}
				else
				{
					array[num] = A_0[i];
				}
				num++;
			}
			Array.Resize<byte>(ref array, num);
			return array;
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0005B9D0 File Offset: 0x0005A9D0
		internal string c(byte[] A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < A_0.Length; i++)
			{
				stringBuilder.Append((char)c1.d[(int)A_0[i]]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0005BA14 File Offset: 0x0005AA14
		internal string b(string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < A_0.Length; i += 2)
			{
				int num;
				if (A_0.Length > 2)
				{
					num = Convert.ToInt32(A_0.Substring(i, 2), 16);
				}
				else
				{
					num = Convert.ToInt32(A_0, 16);
				}
				stringBuilder.Append((char)c1.d[num]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0005BA88 File Offset: 0x0005AA88
		internal string c(string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < A_0.Length; i += 2)
			{
				int num;
				if (A_0.Length > 2)
				{
					num = Convert.ToInt32(A_0.Substring(i, 2), 16);
				}
				else
				{
					num = Convert.ToInt32(A_0, 16);
				}
				stringBuilder.Append((char)num);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000347 RID: 839
		private const string a = "WinAnsiEncoding";

		// Token: 0x04000348 RID: 840
		private const string b = "MacRomanEncoding";

		// Token: 0x04000349 RID: 841
		private Font c = Font.Helvetica;

		// Token: 0x0400034A RID: 842
		private static ushort[] d = new ushort[]
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
			196,
			197,
			199,
			201,
			209,
			214,
			220,
			225,
			224,
			226,
			228,
			227,
			229,
			231,
			233,
			232,
			234,
			235,
			237,
			236,
			238,
			239,
			241,
			243,
			242,
			244,
			246,
			245,
			250,
			249,
			251,
			252,
			8224,
			176,
			162,
			163,
			167,
			8226,
			182,
			223,
			174,
			169,
			8482,
			180,
			171,
			8800,
			198,
			219,
			8734,
			177,
			8804,
			8805,
			165,
			181,
			8706,
			8721,
			8719,
			960,
			8747,
			170,
			186,
			937,
			230,
			248,
			191,
			161,
			172,
			8730,
			402,
			8776,
			8710,
			171,
			187,
			8230,
			160,
			192,
			195,
			213,
			338,
			339,
			8211,
			8212,
			8220,
			8221,
			8216,
			8217,
			247,
			9674,
			255,
			376,
			8260,
			8364,
			8249,
			8250,
			64257,
			64258,
			8225,
			183,
			8218,
			8222,
			8240,
			194,
			202,
			193,
			203,
			200,
			205,
			206,
			207,
			204,
			211,
			212,
			64511,
			210,
			218,
			219,
			217,
			305,
			710,
			732,
			175,
			731,
			729,
			730,
			184,
			733,
			731,
			711
		};
	}
}
