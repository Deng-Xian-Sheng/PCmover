using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200049D RID: 1181
	internal class aew : Encoding
	{
		// Token: 0x060030D1 RID: 12497 RVA: 0x001B5C30 File Offset: 0x001B4C30
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030D2 RID: 12498 RVA: 0x001B5C60 File Offset: 0x001B4C60
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aew.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030D3 RID: 12499 RVA: 0x001B5CA4 File Offset: 0x001B4CA4
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= '­')
				{
					if (A_0 == '§')
					{
						return 253;
					}
					if (A_0 == '­')
					{
						return 173;
					}
				}
				else
				{
					switch (A_0)
					{
					case 'Ё':
						return 161;
					case 'Ђ':
						return 162;
					case 'Ѓ':
						return 163;
					case 'Є':
						return 164;
					case 'Ѕ':
						return 165;
					case 'І':
						return 166;
					case 'Ї':
						return 167;
					case 'Ј':
						return 168;
					case 'Љ':
						return 169;
					case 'Њ':
						return 170;
					case 'Ћ':
						return 171;
					case 'Ќ':
						return 172;
					case 'Ѝ':
					case 'ѐ':
					case 'ѝ':
						break;
					case 'Ў':
						return 174;
					case 'Џ':
						return 175;
					case 'А':
						return 176;
					case 'Б':
						return 177;
					case 'В':
						return 178;
					case 'Г':
						return 179;
					case 'Д':
						return 180;
					case 'Е':
						return 181;
					case 'Ж':
						return 182;
					case 'З':
						return 183;
					case 'И':
						return 184;
					case 'Й':
						return 185;
					case 'К':
						return 186;
					case 'Л':
						return 187;
					case 'М':
						return 188;
					case 'Н':
						return 189;
					case 'О':
						return 190;
					case 'П':
						return 191;
					case 'Р':
						return 192;
					case 'С':
						return 193;
					case 'Т':
						return 194;
					case 'У':
						return 195;
					case 'Ф':
						return 196;
					case 'Х':
						return 197;
					case 'Ц':
						return 198;
					case 'Ч':
						return 199;
					case 'Ш':
						return 200;
					case 'Щ':
						return 201;
					case 'Ъ':
						return 202;
					case 'Ы':
						return 203;
					case 'Ь':
						return 204;
					case 'Э':
						return 205;
					case 'Ю':
						return 206;
					case 'Я':
						return 207;
					case 'а':
						return 208;
					case 'б':
						return 209;
					case 'в':
						return 210;
					case 'г':
						return 211;
					case 'д':
						return 212;
					case 'е':
						return 213;
					case 'ж':
						return 214;
					case 'з':
						return 215;
					case 'и':
						return 216;
					case 'й':
						return 217;
					case 'к':
						return 218;
					case 'л':
						return 219;
					case 'м':
						return 220;
					case 'н':
						return 221;
					case 'о':
						return 222;
					case 'п':
						return 223;
					case 'р':
						return 224;
					case 'с':
						return 225;
					case 'т':
						return 226;
					case 'у':
						return 227;
					case 'ф':
						return 228;
					case 'х':
						return 229;
					case 'ц':
						return 230;
					case 'ч':
						return 231;
					case 'ш':
						return 232;
					case 'щ':
						return 233;
					case 'ъ':
						return 234;
					case 'ы':
						return 235;
					case 'ь':
						return 236;
					case 'э':
						return 237;
					case 'ю':
						return 238;
					case 'я':
						return 239;
					case 'ё':
						return 241;
					case 'ђ':
						return 252;
					case 'ѓ':
						return 243;
					case 'є':
						return 244;
					case 'ѕ':
						return 245;
					case 'і':
						return 246;
					case 'ї':
						return 247;
					case 'ј':
						return 248;
					case 'љ':
						return 249;
					case 'њ':
						return 250;
					case 'ћ':
						return 251;
					case 'ќ':
						return 252;
					case 'ў':
						return 254;
					case 'џ':
						return byte.MaxValue;
					default:
						if (A_0 == '№')
						{
							return 240;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030D4 RID: 12500 RVA: 0x001B6272 File Offset: 0x001B5272
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030D5 RID: 12501 RVA: 0x001B627A File Offset: 0x001B527A
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030D6 RID: 12502 RVA: 0x001B6282 File Offset: 0x001B5282
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030D7 RID: 12503 RVA: 0x001B628A File Offset: 0x001B528A
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030D8 RID: 12504 RVA: 0x001B6292 File Offset: 0x001B5292
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030D9 RID: 12505 RVA: 0x001B629A File Offset: 0x001B529A
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030DA RID: 12506 RVA: 0x001B62A4 File Offset: 0x001B52A4
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030DB RID: 12507 RVA: 0x001B62C4 File Offset: 0x001B52C4
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aew.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F8 RID: 5880
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
			'Ё',
			'Ђ',
			'Ѓ',
			'Є',
			'Ѕ',
			'І',
			'Ї',
			'Ј',
			'Љ',
			'Њ',
			'Ћ',
			'Ќ',
			'­',
			'Ў',
			'Џ',
			'А',
			'Б',
			'В',
			'Г',
			'Д',
			'Е',
			'Ж',
			'З',
			'И',
			'Й',
			'К',
			'Л',
			'М',
			'Н',
			'О',
			'П',
			'Р',
			'С',
			'Т',
			'У',
			'Ф',
			'Х',
			'Ц',
			'Ч',
			'Ш',
			'Щ',
			'Ъ',
			'Ы',
			'Ь',
			'Э',
			'Ю',
			'Я',
			'а',
			'б',
			'в',
			'г',
			'д',
			'е',
			'ж',
			'з',
			'и',
			'й',
			'к',
			'л',
			'м',
			'н',
			'о',
			'п',
			'р',
			'с',
			'т',
			'у',
			'ф',
			'х',
			'ц',
			'ч',
			'ш',
			'щ',
			'ъ',
			'ы',
			'ь',
			'э',
			'ю',
			'я',
			'№',
			'ё',
			'ђ',
			'ѓ',
			'є',
			'ѕ',
			'і',
			'ї',
			'ј',
			'љ',
			'њ',
			'ћ',
			'ќ',
			'§',
			'ў',
			'џ'
		};
	}
}
