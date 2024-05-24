using System;
using System.Text;

namespace zz93
{
	// Token: 0x02000497 RID: 1175
	internal class aeq : Encoding
	{
		// Token: 0x06003082 RID: 12418 RVA: 0x001B2900 File Offset: 0x001B1900
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x06003083 RID: 12419 RVA: 0x001B2930 File Offset: 0x001B1930
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aeq.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003084 RID: 12420 RVA: 0x001B2974 File Offset: 0x001B1974
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '\u0080')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= '…')
				{
					if (A_0 <= '»')
					{
						if (A_0 == '\u0098')
						{
							return 152;
						}
						switch (A_0)
						{
						case '\u00a0':
							return 160;
						case '¤':
							return 164;
						case '¦':
							return 166;
						case '§':
							return 167;
						case '©':
							return 169;
						case '«':
							return 171;
						case '¬':
							return 172;
						case '­':
							return 173;
						case '®':
							return 174;
						case '°':
							return 176;
						case '±':
							return 177;
						case 'µ':
							return 181;
						case '¶':
							return 182;
						case '·':
							return 183;
						case '»':
							return 187;
						}
					}
					else
					{
						switch (A_0)
						{
						case 'Ё':
							return 168;
						case 'Ђ':
							return 128;
						case 'Ѓ':
							return 129;
						case 'Є':
							return 170;
						case 'Ѕ':
							return 189;
						case 'І':
							return 178;
						case 'Ї':
							return 175;
						case 'Ј':
							return 163;
						case 'Љ':
							return 138;
						case 'Њ':
							return 140;
						case 'Ћ':
							return 142;
						case 'Ќ':
							return 141;
						case 'Ѝ':
						case 'ѐ':
						case 'ѝ':
						case 'Ѡ':
						case 'ѡ':
						case 'Ѣ':
						case 'ѣ':
						case 'Ѥ':
						case 'ѥ':
						case 'Ѧ':
						case 'ѧ':
						case 'Ѩ':
						case 'ѩ':
						case 'Ѫ':
						case 'ѫ':
						case 'Ѭ':
						case 'ѭ':
						case 'Ѯ':
						case 'ѯ':
						case 'Ѱ':
						case 'ѱ':
						case 'Ѳ':
						case 'ѳ':
						case 'Ѵ':
						case 'ѵ':
						case 'Ѷ':
						case 'ѷ':
						case 'Ѹ':
						case 'ѹ':
						case 'Ѻ':
						case 'ѻ':
						case 'Ѽ':
						case 'ѽ':
						case 'Ѿ':
						case 'ѿ':
						case 'Ҁ':
						case 'ҁ':
						case '҂':
						case '҃':
						case '҄':
						case '҅':
						case '҆':
						case '҇':
						case '҈':
						case '҉':
						case 'Ҋ':
						case 'ҋ':
						case 'Ҍ':
						case 'ҍ':
						case 'Ҏ':
						case 'ҏ':
							break;
						case 'Ў':
							return 161;
						case 'Џ':
							return 143;
						case 'А':
							return 192;
						case 'Б':
							return 193;
						case 'В':
							return 194;
						case 'Г':
							return 195;
						case 'Д':
							return 196;
						case 'Е':
							return 197;
						case 'Ж':
							return 198;
						case 'З':
							return 199;
						case 'И':
							return 200;
						case 'Й':
							return 201;
						case 'К':
							return 202;
						case 'Л':
							return 203;
						case 'М':
							return 204;
						case 'Н':
							return 205;
						case 'О':
							return 206;
						case 'П':
							return 207;
						case 'Р':
							return 208;
						case 'С':
							return 209;
						case 'Т':
							return 210;
						case 'У':
							return 211;
						case 'Ф':
							return 212;
						case 'Х':
							return 213;
						case 'Ц':
							return 214;
						case 'Ч':
							return 215;
						case 'Ш':
							return 216;
						case 'Щ':
							return 217;
						case 'Ъ':
							return 218;
						case 'Ы':
							return 219;
						case 'Ь':
							return 220;
						case 'Э':
							return 221;
						case 'Ю':
							return 222;
						case 'Я':
							return 223;
						case 'а':
							return 224;
						case 'б':
							return 225;
						case 'в':
							return 226;
						case 'г':
							return 227;
						case 'д':
							return 228;
						case 'е':
							return 229;
						case 'ж':
							return 230;
						case 'з':
							return 231;
						case 'и':
							return 232;
						case 'й':
							return 233;
						case 'к':
							return 234;
						case 'л':
							return 235;
						case 'м':
							return 236;
						case 'н':
							return 237;
						case 'о':
							return 238;
						case 'п':
							return 239;
						case 'р':
							return 240;
						case 'с':
							return 241;
						case 'т':
							return 252;
						case 'у':
							return 243;
						case 'ф':
							return 244;
						case 'х':
							return 245;
						case 'ц':
							return 246;
						case 'ч':
							return 247;
						case 'ш':
							return 248;
						case 'щ':
							return 249;
						case 'ъ':
							return 250;
						case 'ы':
							return 251;
						case 'ь':
							return 252;
						case 'э':
							return 253;
						case 'ю':
							return 254;
						case 'я':
							return byte.MaxValue;
						case 'ё':
							return 184;
						case 'ђ':
							return 144;
						case 'ѓ':
							return 131;
						case 'є':
							return 186;
						case 'ѕ':
							return 190;
						case 'і':
							return 179;
						case 'ї':
							return 191;
						case 'ј':
							return 188;
						case 'љ':
							return 154;
						case 'њ':
							return 156;
						case 'ћ':
							return 158;
						case 'ќ':
							return 157;
						case 'ў':
							return 162;
						case 'џ':
							return 159;
						case 'Ґ':
							return 165;
						case 'ґ':
							return 180;
						default:
							switch (A_0)
							{
							case '–':
								return 150;
							case '—':
								return 151;
							case '‘':
								return 145;
							case '’':
								return 146;
							case '‚':
								return 130;
							case '“':
								return 147;
							case '”':
								return 148;
							case '„':
								return 132;
							case '†':
								return 134;
							case '‡':
								return 135;
							case '•':
								return 149;
							case '…':
								return 133;
							}
							break;
						}
					}
				}
				else if (A_0 <= '›')
				{
					if (A_0 == '‰')
					{
						return 137;
					}
					switch (A_0)
					{
					case '‹':
						return 139;
					case '›':
						return 155;
					}
				}
				else
				{
					if (A_0 == '€')
					{
						return 136;
					}
					if (A_0 == '№')
					{
						return 185;
					}
					if (A_0 == '™')
					{
						return 153;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x06003085 RID: 12421 RVA: 0x001B3294 File Offset: 0x001B2294
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003086 RID: 12422 RVA: 0x001B329C File Offset: 0x001B229C
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003087 RID: 12423 RVA: 0x001B32A4 File Offset: 0x001B22A4
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003088 RID: 12424 RVA: 0x001B32AC File Offset: 0x001B22AC
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003089 RID: 12425 RVA: 0x001B32B4 File Offset: 0x001B22B4
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600308A RID: 12426 RVA: 0x001B32BC File Offset: 0x001B22BC
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600308B RID: 12427 RVA: 0x001B32C4 File Offset: 0x001B22C4
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x0600308C RID: 12428 RVA: 0x001B32E4 File Offset: 0x001B22E4
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aeq.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F2 RID: 5874
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
			'Ђ',
			'Ѓ',
			'‚',
			'ѓ',
			'„',
			'…',
			'†',
			'‡',
			'€',
			'‰',
			'Љ',
			'‹',
			'Њ',
			'Ќ',
			'Ћ',
			'Џ',
			'ђ',
			'‘',
			'’',
			'“',
			'”',
			'•',
			'–',
			'—',
			'\u0098',
			'™',
			'љ',
			'›',
			'њ',
			'ќ',
			'ћ',
			'џ',
			'\u00a0',
			'Ў',
			'ў',
			'Ј',
			'¤',
			'Ґ',
			'¦',
			'§',
			'Ё',
			'©',
			'Є',
			'«',
			'¬',
			'­',
			'®',
			'Ї',
			'°',
			'±',
			'І',
			'і',
			'ґ',
			'µ',
			'¶',
			'·',
			'ё',
			'№',
			'є',
			'»',
			'ј',
			'Ѕ',
			'ѕ',
			'ї',
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
			'я'
		};
	}
}
