using System;
using System.Text;

namespace zz93
{
	// Token: 0x02000496 RID: 1174
	internal class aep : Encoding
	{
		// Token: 0x06003075 RID: 12405 RVA: 0x001B1DF4 File Offset: 0x001B0DF4
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x06003076 RID: 12406 RVA: 0x001B1E24 File Offset: 0x001B0E24
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aep.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003077 RID: 12407 RVA: 0x001B1E68 File Offset: 0x001B0E68
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '\u0080')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ž')
				{
					if (A_0 <= '\u0090')
					{
						switch (A_0)
						{
						case '\u0081':
							return 129;
						case '\u0082':
							break;
						case '\u0083':
							return 131;
						default:
							if (A_0 == '\u0088')
							{
								return 136;
							}
							if (A_0 == '\u0090')
							{
								return 144;
							}
							break;
						}
					}
					else
					{
						switch (A_0)
						{
						case '\u0098':
							return 152;
						case '\u0099':
						case '\u009a':
						case '\u009b':
						case '\u009c':
						case '\u009d':
						case '\u009e':
						case '\u009f':
						case '¡':
						case '¢':
						case '£':
						case '¥':
						case 'ª':
						case '¯':
						case '²':
						case '³':
						case '¹':
						case 'º':
						case '¼':
						case '½':
						case '¾':
						case '¿':
						case 'À':
						case 'Ã':
						case 'Å':
						case 'Æ':
						case 'È':
						case 'Ê':
						case 'Ì':
						case 'Ï':
						case 'Ð':
						case 'Ñ':
						case 'Ò':
						case 'Õ':
						case 'Ø':
						case 'Ù':
						case 'Û':
						case 'Þ':
						case 'à':
						case 'ã':
						case 'å':
						case 'æ':
						case 'è':
						case 'ê':
						case 'ì':
						case 'ï':
						case 'ð':
						case 'ñ':
						case 'ò':
						case 'õ':
						case 'ø':
						case 'ù':
						case 'û':
						case 'þ':
						case 'ÿ':
						case 'Ā':
						case 'ā':
						case 'Ĉ':
						case 'ĉ':
						case 'Ċ':
						case 'ċ':
							break;
						case '\u00a0':
							return 160;
						case '¤':
							return 164;
						case '¦':
							return 166;
						case '§':
							return 167;
						case '¨':
							return 168;
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
						case '´':
							return 180;
						case 'µ':
							return 181;
						case '¶':
							return 182;
						case '·':
							return 183;
						case '¸':
							return 184;
						case '»':
							return 187;
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
							return 165;
						case 'ą':
							return 185;
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
						default:
							switch (A_0)
							{
							case 'Ę':
								return 202;
							case 'ę':
								return 234;
							case 'Ě':
								return 204;
							case 'ě':
								return 236;
							default:
								switch (A_0)
								{
								case 'Ĺ':
									return 197;
								case 'ĺ':
									return 229;
								case 'Ľ':
									return 188;
								case 'ľ':
									return 190;
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
									return 140;
								case 'ś':
									return 156;
								case 'Ş':
									return 170;
								case 'ş':
									return 186;
								case 'Š':
									return 138;
								case 'š':
									return 154;
								case 'Ţ':
									return 222;
								case 'ţ':
									return 254;
								case 'Ť':
									return 141;
								case 'ť':
									return 157;
								case 'Ů':
									return 217;
								case 'ů':
									return 249;
								case 'Ű':
									return 219;
								case 'ű':
									return 251;
								case 'Ź':
									return 143;
								case 'ź':
									return 159;
								case 'Ż':
									return 175;
								case 'ż':
									return 191;
								case 'Ž':
									return 142;
								case 'ž':
									return 158;
								}
								break;
							}
							break;
						}
					}
				}
				else if (A_0 <= '…')
				{
					if (A_0 == 'ˇ')
					{
						return 161;
					}
					switch (A_0)
					{
					case '˘':
						return 162;
					case '˙':
						return byte.MaxValue;
					case '˚':
					case '˜':
						break;
					case '˛':
						return 178;
					case '˝':
						return 189;
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

		// Token: 0x06003078 RID: 12408 RVA: 0x001B2844 File Offset: 0x001B1844
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003079 RID: 12409 RVA: 0x001B284C File Offset: 0x001B184C
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600307A RID: 12410 RVA: 0x001B2854 File Offset: 0x001B1854
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600307B RID: 12411 RVA: 0x001B285C File Offset: 0x001B185C
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600307C RID: 12412 RVA: 0x001B2864 File Offset: 0x001B1864
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600307D RID: 12413 RVA: 0x001B286C File Offset: 0x001B186C
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600307E RID: 12414 RVA: 0x001B2874 File Offset: 0x001B1874
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x0600307F RID: 12415 RVA: 0x001B2894 File Offset: 0x001B1894
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aep.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F1 RID: 5873
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
			'\u0083',
			'„',
			'…',
			'†',
			'‡',
			'\u0088',
			'‰',
			'Š',
			'‹',
			'Ś',
			'Ť',
			'Ž',
			'Ź',
			'\u0090',
			'‘',
			'’',
			'“',
			'”',
			'•',
			'–',
			'—',
			'\u0098',
			'™',
			'š',
			'›',
			'ś',
			'ť',
			'ž',
			'ź',
			'\u00a0',
			'ˇ',
			'˘',
			'Ł',
			'¤',
			'Ą',
			'¦',
			'§',
			'¨',
			'©',
			'Ş',
			'«',
			'¬',
			'­',
			'®',
			'Ż',
			'°',
			'±',
			'˛',
			'ł',
			'´',
			'µ',
			'¶',
			'·',
			'¸',
			'ą',
			'ş',
			'»',
			'Ľ',
			'˝',
			'ľ',
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
