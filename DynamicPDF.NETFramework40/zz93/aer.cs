using System;
using System.Text;

namespace zz93
{
	// Token: 0x02000498 RID: 1176
	internal class aer : Encoding
	{
		// Token: 0x0600308F RID: 12431 RVA: 0x001B3350 File Offset: 0x001B2350
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x06003090 RID: 12432 RVA: 0x001B3380 File Offset: 0x001B2380
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aer.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003091 RID: 12433 RVA: 0x001B33C4 File Offset: 0x001B23C4
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '\u0080' || (A_0 > '\u009f' && A_0 < '￿'))
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ž')
				{
					if (A_0 <= '\u009d')
					{
						if (A_0 == '\u0081')
						{
							return 129;
						}
						switch (A_0)
						{
						case '\u008d':
							return 141;
						case '\u008e':
							break;
						case '\u008f':
							return 143;
						case '\u0090':
							return 144;
						default:
							if (A_0 == '\u009d')
							{
								return 157;
							}
							break;
						}
					}
					else if (A_0 <= 'š')
					{
						switch (A_0)
						{
						case 'Œ':
							return 140;
						case 'œ':
							return 156;
						default:
							switch (A_0)
							{
							case 'Š':
								return 138;
							case 'š':
								return 154;
							}
							break;
						}
					}
					else
					{
						if (A_0 == 'Ÿ')
						{
							return 159;
						}
						switch (A_0)
						{
						case 'Ž':
							return 142;
						case 'ž':
							return 158;
						}
					}
				}
				else if (A_0 <= '…')
				{
					if (A_0 <= 'ˆ')
					{
						if (A_0 == 'ƒ')
						{
							return 131;
						}
						if (A_0 == 'ˆ')
						{
							return 136;
						}
					}
					else
					{
						if (A_0 == '˜')
						{
							return 152;
						}
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
						return 128;
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

		// Token: 0x06003092 RID: 12434 RVA: 0x001B36BB File Offset: 0x001B26BB
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003093 RID: 12435 RVA: 0x001B36C4 File Offset: 0x001B26C4
		public override byte[] GetBytes(char[] chars)
		{
			byte[] array = new byte[chars.Length];
			this.GetBytes(chars, 0, chars.Length, array, 0);
			return array;
		}

		// Token: 0x06003094 RID: 12436 RVA: 0x001B36F0 File Offset: 0x001B26F0
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aer.a(chars[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003095 RID: 12437 RVA: 0x001B3730 File Offset: 0x001B2730
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003096 RID: 12438 RVA: 0x001B3738 File Offset: 0x001B2738
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003097 RID: 12439 RVA: 0x001B3740 File Offset: 0x001B2740
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003098 RID: 12440 RVA: 0x001B3748 File Offset: 0x001B2748
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x001B3750 File Offset: 0x001B2750
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x0600309A RID: 12442 RVA: 0x001B3770 File Offset: 0x001B2770
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aer.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F3 RID: 5875
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
			'€',
			'\u0081',
			'‚',
			'ƒ',
			'„',
			'…',
			'†',
			'‡',
			'ˆ',
			'‰',
			'Š',
			'‹',
			'Œ',
			'\u008d',
			'Ž',
			'\u008f',
			'\u0090',
			'‘',
			'’',
			'“',
			'”',
			'•',
			'–',
			'—',
			'˜',
			'™',
			'š',
			'›',
			'œ',
			'\u009d',
			'ž',
			'Ÿ',
			'\u00a0',
			'¡',
			'¢',
			'£',
			'¤',
			'¥',
			'¦',
			'§',
			'¨',
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
			'´',
			'µ',
			'¶',
			'·',
			'¸',
			'¹',
			'º',
			'»',
			'¼',
			'½',
			'¾',
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
