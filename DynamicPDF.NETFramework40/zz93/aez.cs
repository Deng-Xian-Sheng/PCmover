using System;
using System.Text;

namespace zz93
{
	// Token: 0x020004A0 RID: 1184
	internal class aez : Encoding
	{
		// Token: 0x060030F8 RID: 12536 RVA: 0x001B71D0 File Offset: 0x001B61D0
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030F9 RID: 12537 RVA: 0x001B7200 File Offset: 0x001B6200
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aez.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030FA RID: 12538 RVA: 0x001B7244 File Offset: 0x001B6244
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= '÷')
				{
					switch (A_0)
					{
					case '¢':
						return 162;
					case '£':
						return 163;
					case '¤':
						return 164;
					case '¥':
						return 165;
					case '¦':
						return 166;
					case '§':
						return 167;
					case '¨':
						return 168;
					case '©':
						return 169;
					case 'ª':
					case '¯':
					case 'º':
						break;
					case '«':
						return 171;
					case '¬':
						return 172;
					case '­':
						return 173;
					case '®':
						return 174;
					case '°':
						return 177;
					case '±':
						return 178;
					case '²':
						return 179;
					case '³':
						return 180;
					case '´':
						return 181;
					case 'µ':
						return 182;
					case '¶':
						return 183;
					case '·':
						return 184;
					case '¸':
						return 185;
					case '¹':
						return 186;
					case '»':
						return 188;
					case '¼':
						return 189;
					case '½':
						return 175;
					case '¾':
						return 190;
					default:
						if (A_0 == '×')
						{
							return 170;
						}
						if (A_0 == '÷')
						{
							return 187;
						}
						break;
					}
				}
				else if (A_0 <= '‗')
				{
					switch (A_0)
					{
					case 'א':
						return 224;
					case 'ב':
						return 225;
					case 'ג':
						return 226;
					case 'ד':
						return 227;
					case 'ה':
						return 228;
					case 'ו':
						return 229;
					case 'ז':
						return 230;
					case 'ח':
						return 231;
					case 'ט':
						return 232;
					case 'י':
						return 233;
					case 'ך':
						return 234;
					case 'כ':
						return 235;
					case 'ל':
						return 236;
					case 'ם':
						return 237;
					case 'מ':
						return 238;
					case 'ן':
						return 239;
					case 'נ':
						return 240;
					case 'ס':
						return 241;
					case 'ע':
						return 252;
					case 'ף':
						return 243;
					case 'פ':
						return 244;
					case 'ץ':
						return 245;
					case 'צ':
						return 246;
					case 'ק':
						return 247;
					case 'ר':
						return 248;
					case 'ש':
						return 249;
					case 'ת':
						return 250;
					default:
						if (A_0 == '‗')
						{
							return 223;
						}
						break;
					}
				}
				else
				{
					if (A_0 == '‾')
					{
						return 176;
					}
					switch (A_0)
					{
					case '':
						return 161;
					case '':
						return 191;
					case '':
						return 192;
					case '':
						return 193;
					case '':
						return 194;
					case '':
						return 195;
					case '':
						return 196;
					case '':
						return 197;
					case '':
						return 198;
					case '':
						return 199;
					case '':
						return 200;
					case '':
						return 201;
					case '':
						return 202;
					case '':
						return 203;
					case '':
						return 204;
					case '':
						return 205;
					case '':
						return 206;
					case '':
						return 207;
					case '':
						return 208;
					case '':
						return 209;
					case '':
						return 210;
					case '':
						return 211;
					case '':
						return 212;
					case '':
						return 213;
					case '':
						return 214;
					case '':
						return 215;
					case '':
						return 216;
					case '':
						return 217;
					case '':
						return 218;
					case '':
						return 219;
					case '':
						return 220;
					case '':
						return 221;
					case '':
						return 222;
					case '':
						return 251;
					case '':
						return 252;
					case '':
						return 253;
					case '':
						return 254;
					case '':
						return byte.MaxValue;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030FB RID: 12539 RVA: 0x001B7844 File Offset: 0x001B6844
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030FC RID: 12540 RVA: 0x001B784C File Offset: 0x001B684C
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030FD RID: 12541 RVA: 0x001B7854 File Offset: 0x001B6854
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030FE RID: 12542 RVA: 0x001B785C File Offset: 0x001B685C
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030FF RID: 12543 RVA: 0x001B7864 File Offset: 0x001B6864
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003100 RID: 12544 RVA: 0x001B786C File Offset: 0x001B686C
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003101 RID: 12545 RVA: 0x001B7874 File Offset: 0x001B6874
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x06003102 RID: 12546 RVA: 0x001B7894 File Offset: 0x001B6894
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aez.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016FB RID: 5883
		private static char[] a = new char[]
		{
			'\0',
			'\u0001',
			'\u0002',
			'\u0003',
			'\u0004',
			'\u0005',
			'\u0006',
			'\a',
			'\b',
			'\t',
			'\n',
			'\v',
			'\f',
			'\r',
			'\u000e',
			'\u000f',
			'\u0010',
			'\u0011',
			'\u0012',
			'\u0013',
			'\u0014',
			'\u0015',
			'\u0016',
			'\u0017',
			'\u0018',
			'\u0019',
			'\u001a',
			'\u001b',
			'\u001c',
			'\u001d',
			'\u001e',
			'\u001f',
			' ',
			'!',
			'"',
			'#',
			'$',
			'%',
			'&',
			'\'',
			'(',
			')',
			'*',
			'+',
			',',
			'-',
			'.',
			'/',
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			':',
			';',
			'<',
			'=',
			'>',
			'?',
			'@',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z',
			'[',
			'\\',
			']',
			'^',
			'_',
			'`',
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'w',
			'x',
			'y',
			'z',
			'{',
			'|',
			'}',
			'~',
			'\u007f',
			'\u0080',
			'\u0081',
			'\u0082',
			'\u0083',
			'\u0084',
			'\u0085',
			'\u0086',
			'\u0087',
			'\u0088',
			'\u0089',
			'\u008a',
			'\u008b',
			'\u008c',
			'\u008d',
			'\u008e',
			'\u008f',
			'\u0090',
			'\u0091',
			'\u0092',
			'\u0093',
			'\u0094',
			'\u0095',
			'\u0096',
			'\u0097',
			'\u0098',
			'\u0099',
			'\u009a',
			'\u009b',
			'\u009c',
			'\u009d',
			'\u009e',
			'\u009f',
			'\u00a0',
			'',
			'¢',
			'£',
			'¤',
			'¥',
			'¦',
			'§',
			'¨',
			'©',
			'×',
			'«',
			'¬',
			'­',
			'®',
			'‾',
			'°',
			'±',
			'²',
			'³',
			'´',
			'µ',
			'¶',
			'·',
			'¸',
			'¹',
			'÷',
			'»',
			'¼',
			'½',
			'¾',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'‗',
			'א',
			'ב',
			'ג',
			'ד',
			'ה',
			'ו',
			'ז',
			'ח',
			'ט',
			'י',
			'ך',
			'כ',
			'ל',
			'ם',
			'מ',
			'ן',
			'נ',
			'ס',
			'ע',
			'ף',
			'פ',
			'ץ',
			'צ',
			'ק',
			'ר',
			'ש',
			'ת',
			'',
			'',
			'',
			'',
			''
		};
	}
}
