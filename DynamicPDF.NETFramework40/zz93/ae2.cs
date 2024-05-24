using System;
using System.Text;

namespace zz93
{
	// Token: 0x020004A3 RID: 1187
	internal class ae2 : Encoding
	{
		// Token: 0x0600311F RID: 12575 RVA: 0x001B8328 File Offset: 0x001B7328
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x06003120 RID: 12576 RVA: 0x001B8358 File Offset: 0x001B7358
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = ae2.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003121 RID: 12577 RVA: 0x001B839C File Offset: 0x001B739C
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¤')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'š')
				{
					switch (A_0)
					{
					case '¥':
						return 165;
					case '¦':
					case '¨':
					case '´':
					case '¸':
					case '¼':
					case '½':
					case '¾':
						break;
					case '§':
						return 167;
					case '©':
						return 169;
					case 'ª':
						return 170;
					case '«':
						return 171;
					case '¬':
						return 172;
					case '­':
						return 173;
					case '®':
						return 174;
					case '¯':
						return 176;
					case '°':
						return 177;
					case '±':
						return 178;
					case '²':
						return 179;
					case '³':
						return 180;
					case 'µ':
						return 182;
					case '¶':
						return 183;
					case '·':
						return 184;
					case '¹':
						return 186;
					case 'º':
						return 187;
					case '»':
						return 188;
					case '¿':
						return 191;
					case 'À':
						return 192;
					case 'Á':
						return 193;
					case 'Â':
						return 194;
					case 'Ã':
						return 195;
					case 'Ä':
						return 196;
					case 'Å':
						return 197;
					case 'Æ':
						return 198;
					case 'Ç':
						return 199;
					case 'È':
						return 200;
					case 'É':
						return 201;
					case 'Ê':
						return 202;
					case 'Ë':
						return 203;
					case 'Ì':
						return 204;
					case 'Í':
						return 205;
					case 'Î':
						return 206;
					case 'Ï':
						return 207;
					case 'Ð':
						return 208;
					case 'Ñ':
						return 209;
					case 'Ò':
						return 210;
					case 'Ó':
						return 211;
					case 'Ô':
						return 212;
					case 'Õ':
						return 213;
					case 'Ö':
						return 214;
					case '×':
						return 215;
					case 'Ø':
						return 216;
					case 'Ù':
						return 217;
					case 'Ú':
						return 218;
					case 'Û':
						return 219;
					case 'Ü':
						return 220;
					case 'Ý':
						return 221;
					case 'Þ':
						return 222;
					case 'ß':
						return 223;
					case 'à':
						return 224;
					case 'á':
						return 225;
					case 'â':
						return 226;
					case 'ã':
						return 227;
					case 'ä':
						return 228;
					case 'å':
						return 229;
					case 'æ':
						return 230;
					case 'ç':
						return 231;
					case 'è':
						return 232;
					case 'é':
						return 233;
					case 'ê':
						return 234;
					case 'ë':
						return 235;
					case 'ì':
						return 236;
					case 'í':
						return 237;
					case 'î':
						return 238;
					case 'ï':
						return 239;
					case 'ð':
						return 240;
					case 'ñ':
						return 241;
					case 'ò':
						return 252;
					case 'ó':
						return 243;
					case 'ô':
						return 244;
					case 'õ':
						return 245;
					case 'ö':
						return 246;
					case '÷':
						return 247;
					case 'ø':
						return 248;
					case 'ù':
						return 249;
					case 'ú':
						return 250;
					case 'û':
						return 251;
					case 'ü':
						return 252;
					case 'ý':
						return 253;
					case 'þ':
						return 254;
					case 'ÿ':
						return byte.MaxValue;
					default:
						switch (A_0)
						{
						case 'Œ':
							return 189;
						case 'œ':
							return 175;
						default:
							switch (A_0)
							{
							case 'Š':
								return 166;
							case 'š':
								return 168;
							}
							break;
						}
						break;
					}
				}
				else
				{
					if (A_0 == 'Ÿ')
					{
						return 190;
					}
					switch (A_0)
					{
					case 'Ž':
						return 181;
					case 'ž':
						return 185;
					default:
						if (A_0 == '€')
						{
							return 164;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x06003122 RID: 12578 RVA: 0x001B896A File Offset: 0x001B796A
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003123 RID: 12579 RVA: 0x001B8972 File Offset: 0x001B7972
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003124 RID: 12580 RVA: 0x001B897A File Offset: 0x001B797A
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003125 RID: 12581 RVA: 0x001B8982 File Offset: 0x001B7982
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x001B898A File Offset: 0x001B798A
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003127 RID: 12583 RVA: 0x001B8992 File Offset: 0x001B7992
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003128 RID: 12584 RVA: 0x001B899C File Offset: 0x001B799C
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x06003129 RID: 12585 RVA: 0x001B89BC File Offset: 0x001B79BC
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = ae2.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016FE RID: 5886
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
			'¡',
			'¢',
			'£',
			'€',
			'¥',
			'Š',
			'§',
			'š',
			'©',
			'ª',
			'«',
			'¬',
			'­',
			'®',
			'¯',
			'°',
			'±',
			'²',
			'³',
			'Ž',
			'µ',
			'¶',
			'·',
			'ž',
			'¹',
			'º',
			'»',
			'Œ',
			'œ',
			'Ÿ',
			'¿',
			'À',
			'Á',
			'Â',
			'Ã',
			'Ä',
			'Å',
			'Æ',
			'Ç',
			'È',
			'É',
			'Ê',
			'Ë',
			'Ì',
			'Í',
			'Î',
			'Ï',
			'Ð',
			'Ñ',
			'Ò',
			'Ó',
			'Ô',
			'Õ',
			'Ö',
			'×',
			'Ø',
			'Ù',
			'Ú',
			'Û',
			'Ü',
			'Ý',
			'Þ',
			'ß',
			'à',
			'á',
			'â',
			'ã',
			'ä',
			'å',
			'æ',
			'ç',
			'è',
			'é',
			'ê',
			'ë',
			'ì',
			'í',
			'î',
			'ï',
			'ð',
			'ñ',
			'ò',
			'ó',
			'ô',
			'õ',
			'ö',
			'÷',
			'ø',
			'ù',
			'ú',
			'û',
			'ü',
			'ý',
			'þ',
			'ÿ'
		};
	}
}
