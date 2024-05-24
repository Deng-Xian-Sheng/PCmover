using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200049B RID: 1179
	internal class aeu : Encoding
	{
		// Token: 0x060030B7 RID: 12471 RVA: 0x001B4B70 File Offset: 0x001B3B70
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030B8 RID: 12472 RVA: 0x001B4BA0 File Offset: 0x001B3BA0
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aeu.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030B9 RID: 12473 RVA: 0x001B4BE4 File Offset: 0x001B3BE4
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ŭ')
				{
					switch (A_0)
					{
					case '£':
						return 163;
					case '¤':
						return 164;
					case '¥':
					case '¦':
					case '©':
					case 'ª':
					case '«':
					case '¬':
					case '®':
					case '¯':
					case '±':
					case '¶':
					case '¹':
					case 'º':
					case '»':
					case '¼':
					case '¾':
					case '¿':
					case 'Ã':
					case 'Å':
					case 'Æ':
					case 'Ð':
					case 'Õ':
					case 'Ø':
					case 'Ý':
					case 'Þ':
					case 'ã':
					case 'å':
					case 'æ':
					case 'ð':
					case 'õ':
					case 'ø':
					case 'ý':
					case 'þ':
					case 'ÿ':
					case 'Ā':
					case 'ā':
					case 'Ă':
					case 'ă':
					case 'Ą':
					case 'ą':
					case 'Ć':
					case 'ć':
					case 'Č':
					case 'č':
					case 'Ď':
					case 'ď':
					case 'Đ':
					case 'đ':
					case 'Ē':
					case 'ē':
					case 'Ĕ':
					case 'ĕ':
					case 'Ė':
					case 'ė':
					case 'Ę':
					case 'ę':
					case 'Ě':
					case 'ě':
					case 'Ģ':
					case 'ģ':
					case 'Ĩ':
					case 'ĩ':
					case 'Ī':
					case 'ī':
					case 'Ĭ':
					case 'ĭ':
					case 'Į':
					case 'į':
					case 'Ĳ':
					case 'ĳ':
						break;
					case '§':
						return 167;
					case '¨':
						return 168;
					case '­':
						return 173;
					case '°':
						return 176;
					case '²':
						return 178;
					case '³':
						return 179;
					case '´':
						return 180;
					case 'µ':
						return 181;
					case '·':
						return 183;
					case '¸':
						return 184;
					case '½':
						return 189;
					case 'À':
						return 192;
					case 'Á':
						return 193;
					case 'Â':
						return 194;
					case 'Ä':
						return 196;
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
					case 'Ñ':
						return 209;
					case 'Ò':
						return 210;
					case 'Ó':
						return 211;
					case 'Ô':
						return 212;
					case 'Ö':
						return 214;
					case '×':
						return 215;
					case 'Ù':
						return 217;
					case 'Ú':
						return 218;
					case 'Û':
						return 219;
					case 'Ü':
						return 220;
					case 'ß':
						return 223;
					case 'à':
						return 224;
					case 'á':
						return 225;
					case 'â':
						return 226;
					case 'ä':
						return 228;
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
					case 'ñ':
						return 241;
					case 'ò':
						return 252;
					case 'ó':
						return 243;
					case 'ô':
						return 244;
					case 'ö':
						return 246;
					case '÷':
						return 247;
					case 'ù':
						return 249;
					case 'ú':
						return 250;
					case 'û':
						return 251;
					case 'ü':
						return 252;
					case 'Ĉ':
						return 198;
					case 'ĉ':
						return 230;
					case 'Ċ':
						return 197;
					case 'ċ':
						return 229;
					case 'Ĝ':
						return 216;
					case 'ĝ':
						return 248;
					case 'Ğ':
						return 171;
					case 'ğ':
						return 187;
					case 'Ġ':
						return 213;
					case 'ġ':
						return 245;
					case 'Ĥ':
						return 166;
					case 'ĥ':
						return 182;
					case 'Ħ':
						return 161;
					case 'ħ':
						return 177;
					case 'İ':
						return 169;
					case 'ı':
						return 185;
					case 'Ĵ':
						return 172;
					case 'ĵ':
						return 188;
					default:
						switch (A_0)
						{
						case 'Ŝ':
							return 222;
						case 'ŝ':
							return 254;
						case 'Ş':
							return 170;
						case 'ş':
							return 186;
						default:
							switch (A_0)
							{
							case 'Ŭ':
								return 221;
							case 'ŭ':
								return 253;
							}
							break;
						}
						break;
					}
				}
				else
				{
					switch (A_0)
					{
					case 'Ż':
						return 175;
					case 'ż':
						return 191;
					default:
						switch (A_0)
						{
						case '˘':
							return 162;
						case '˙':
							return byte.MaxValue;
						default:
							switch (A_0)
							{
							case '':
								return 165;
							case '':
								return 174;
							case '':
								return 190;
							case '':
								return 195;
							case '':
								return 208;
							case '':
								return 227;
							case '':
								return 240;
							}
							break;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030BA RID: 12474 RVA: 0x001B52E4 File Offset: 0x001B42E4
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030BB RID: 12475 RVA: 0x001B52EC File Offset: 0x001B42EC
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030BC RID: 12476 RVA: 0x001B52F4 File Offset: 0x001B42F4
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030BD RID: 12477 RVA: 0x001B52FC File Offset: 0x001B42FC
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030BE RID: 12478 RVA: 0x001B5304 File Offset: 0x001B4304
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030BF RID: 12479 RVA: 0x001B530C File Offset: 0x001B430C
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030C0 RID: 12480 RVA: 0x001B5314 File Offset: 0x001B4314
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030C1 RID: 12481 RVA: 0x001B5334 File Offset: 0x001B4334
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aeu.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F6 RID: 5878
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
			'Ħ',
			'˘',
			'£',
			'¤',
			'',
			'Ĥ',
			'§',
			'¨',
			'İ',
			'Ş',
			'Ğ',
			'Ĵ',
			'­',
			'',
			'Ż',
			'°',
			'ħ',
			'²',
			'³',
			'´',
			'µ',
			'ĥ',
			'·',
			'¸',
			'ı',
			'ş',
			'ğ',
			'ĵ',
			'½',
			'',
			'ż',
			'À',
			'Á',
			'Â',
			'',
			'Ä',
			'Ċ',
			'Ĉ',
			'Ç',
			'È',
			'É',
			'Ê',
			'Ë',
			'Ì',
			'Í',
			'Î',
			'Ï',
			'',
			'Ñ',
			'Ò',
			'Ó',
			'Ô',
			'Ġ',
			'Ö',
			'×',
			'Ĝ',
			'Ù',
			'Ú',
			'Û',
			'Ü',
			'Ŭ',
			'Ŝ',
			'ß',
			'à',
			'á',
			'â',
			'',
			'ä',
			'ċ',
			'ĉ',
			'ç',
			'è',
			'é',
			'ê',
			'ë',
			'ì',
			'í',
			'î',
			'ï',
			'',
			'ñ',
			'ò',
			'ó',
			'ô',
			'ġ',
			'ö',
			'÷',
			'ĝ',
			'ù',
			'ú',
			'û',
			'ü',
			'ŭ',
			'ŝ',
			'˙'
		};
	}
}
