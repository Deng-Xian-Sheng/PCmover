using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200049A RID: 1178
	internal class aet : Encoding
	{
		// Token: 0x060030AA RID: 12458 RVA: 0x001B42E4 File Offset: 0x001B32E4
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030AB RID: 12459 RVA: 0x001B4314 File Offset: 0x001B3314
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aet.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030AC RID: 12460 RVA: 0x001B4358 File Offset: 0x001B3358
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= '´')
				{
					if (A_0 <= '­')
					{
						switch (A_0)
						{
						case '¤':
							return 164;
						case '¥':
						case '¦':
							break;
						case '§':
							return 167;
						case '¨':
							return 168;
						default:
							if (A_0 == '­')
							{
								return 173;
							}
							break;
						}
					}
					else
					{
						if (A_0 == '°')
						{
							return 176;
						}
						if (A_0 == '´')
						{
							return 180;
						}
					}
				}
				else if (A_0 <= 'ě')
				{
					if (A_0 == '¸')
					{
						return 184;
					}
					switch (A_0)
					{
					case 'Á':
						return 193;
					case 'Â':
						return 194;
					case 'Ä':
						return 196;
					case 'Ç':
						return 199;
					case 'É':
						return 201;
					case 'Ë':
						return 203;
					case 'Í':
						return 205;
					case 'Î':
						return 206;
					case 'Ó':
						return 211;
					case 'Ô':
						return 212;
					case 'Ö':
						return 214;
					case '×':
						return 215;
					case 'Ú':
						return 218;
					case 'Ü':
						return 220;
					case 'Ý':
						return 221;
					case 'ß':
						return 223;
					case 'á':
						return 225;
					case 'â':
						return 226;
					case 'ä':
						return 228;
					case 'ç':
						return 231;
					case 'é':
						return 233;
					case 'ë':
						return 235;
					case 'í':
						return 237;
					case 'î':
						return 238;
					case 'ó':
						return 243;
					case 'ô':
						return 244;
					case 'ö':
						return 246;
					case '÷':
						return 247;
					case 'ú':
						return 250;
					case 'ü':
						return 252;
					case 'ý':
						return 253;
					case 'Ă':
						return 195;
					case 'ă':
						return 227;
					case 'Ą':
						return 161;
					case 'ą':
						return 177;
					case 'Ć':
						return 198;
					case 'ć':
						return 230;
					case 'Č':
						return 200;
					case 'č':
						return 232;
					case 'Ď':
						return 207;
					case 'ď':
						return 239;
					case 'Đ':
						return 208;
					case 'đ':
						return 240;
					case 'Ę':
						return 202;
					case 'ę':
						return 234;
					case 'Ě':
						return 204;
					case 'ě':
						return 236;
					}
				}
				else
				{
					switch (A_0)
					{
					case 'Ĺ':
						return 197;
					case 'ĺ':
						return 229;
					case 'Ļ':
					case 'ļ':
					case 'Ŀ':
					case 'ŀ':
					case 'Ņ':
					case 'ņ':
					case 'ŉ':
					case 'Ŋ':
					case 'ŋ':
					case 'Ō':
					case 'ō':
					case 'Ŏ':
					case 'ŏ':
					case 'Œ':
					case 'œ':
					case 'Ŗ':
					case 'ŗ':
					case 'Ŝ':
					case 'ŝ':
					case 'Ŧ':
					case 'ŧ':
					case 'Ũ':
					case 'ũ':
					case 'Ū':
					case 'ū':
					case 'Ŭ':
					case 'ŭ':
					case 'Ų':
					case 'ų':
					case 'Ŵ':
					case 'ŵ':
					case 'Ŷ':
					case 'ŷ':
					case 'Ÿ':
						break;
					case 'Ľ':
						return 165;
					case 'ľ':
						return 181;
					case 'Ł':
						return 163;
					case 'ł':
						return 179;
					case 'Ń':
						return 209;
					case 'ń':
						return 241;
					case 'Ň':
						return 210;
					case 'ň':
						return 252;
					case 'Ő':
						return 213;
					case 'ő':
						return 245;
					case 'Ŕ':
						return 192;
					case 'ŕ':
						return 224;
					case 'Ř':
						return 216;
					case 'ř':
						return 248;
					case 'Ś':
						return 166;
					case 'ś':
						return 182;
					case 'Ş':
						return 170;
					case 'ş':
						return 186;
					case 'Š':
						return 169;
					case 'š':
						return 185;
					case 'Ţ':
						return 222;
					case 'ţ':
						return 254;
					case 'Ť':
						return 171;
					case 'ť':
						return 187;
					case 'Ů':
						return 217;
					case 'ů':
						return 249;
					case 'Ű':
						return 219;
					case 'ű':
						return 251;
					case 'Ź':
						return 172;
					case 'ź':
						return 188;
					case 'Ż':
						return 175;
					case 'ż':
						return 191;
					case 'Ž':
						return 174;
					case 'ž':
						return 190;
					default:
						if (A_0 == 'ˇ')
						{
							return 183;
						}
						switch (A_0)
						{
						case '˘':
							return 162;
						case '˙':
							return byte.MaxValue;
						case '˛':
							return 178;
						case '˝':
							return 189;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030AD RID: 12461 RVA: 0x001B4AB1 File Offset: 0x001B3AB1
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030AE RID: 12462 RVA: 0x001B4AB9 File Offset: 0x001B3AB9
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030AF RID: 12463 RVA: 0x001B4AC1 File Offset: 0x001B3AC1
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030B0 RID: 12464 RVA: 0x001B4AC9 File Offset: 0x001B3AC9
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030B1 RID: 12465 RVA: 0x001B4AD1 File Offset: 0x001B3AD1
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030B2 RID: 12466 RVA: 0x001B4AD9 File Offset: 0x001B3AD9
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030B3 RID: 12467 RVA: 0x001B4AE4 File Offset: 0x001B3AE4
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030B4 RID: 12468 RVA: 0x001B4B04 File Offset: 0x001B3B04
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aet.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F5 RID: 5877
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
			'Ą',
			'˘',
			'Ł',
			'¤',
			'Ľ',
			'Ś',
			'§',
			'¨',
			'Š',
			'Ş',
			'Ť',
			'Ź',
			'­',
			'Ž',
			'Ż',
			'°',
			'ą',
			'˛',
			'ł',
			'´',
			'ľ',
			'ś',
			'ˇ',
			'¸',
			'š',
			'ş',
			'ť',
			'ź',
			'˝',
			'ž',
			'ż',
			'Ŕ',
			'Á',
			'Â',
			'Ă',
			'Ä',
			'Ĺ',
			'Ć',
			'Ç',
			'Č',
			'É',
			'Ę',
			'Ë',
			'Ě',
			'Í',
			'Î',
			'Ď',
			'Đ',
			'Ń',
			'Ň',
			'Ó',
			'Ô',
			'Ő',
			'Ö',
			'×',
			'Ř',
			'Ů',
			'Ú',
			'Ű',
			'Ü',
			'Ý',
			'Ţ',
			'ß',
			'ŕ',
			'á',
			'â',
			'ă',
			'ä',
			'ĺ',
			'ć',
			'ç',
			'č',
			'é',
			'ę',
			'ë',
			'ě',
			'í',
			'î',
			'ď',
			'đ',
			'ń',
			'ň',
			'ó',
			'ô',
			'ő',
			'ö',
			'÷',
			'ř',
			'ů',
			'ú',
			'ű',
			'ü',
			'ý',
			'ţ',
			'˙'
		};
	}
}
