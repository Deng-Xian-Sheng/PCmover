using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200049C RID: 1180
	internal class aev : Encoding
	{
		// Token: 0x060030C4 RID: 12484 RVA: 0x001B53A0 File Offset: 0x001B43A0
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030C5 RID: 12485 RVA: 0x001B53D0 File Offset: 0x001B43D0
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aev.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030C6 RID: 12486 RVA: 0x001B5414 File Offset: 0x001B4414
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ō')
				{
					if (A_0 <= 'ę')
					{
						switch (A_0)
						{
						case '¤':
							return 164;
						case '¥':
						case '¦':
						case '©':
						case 'ª':
						case '«':
						case '¬':
						case '®':
						case '±':
						case '²':
						case '³':
						case 'µ':
						case '¶':
						case '·':
						case '¹':
						case 'º':
						case '»':
						case '¼':
						case '½':
						case '¾':
						case '¿':
						case 'À':
						case 'Ç':
						case 'È':
						case 'Ê':
						case 'Ì':
						case 'Ï':
						case 'Ð':
						case 'Ñ':
						case 'Ò':
						case 'Ó':
						case 'Ù':
						case 'Ý':
						case 'Þ':
						case 'à':
						case 'ç':
						case 'è':
						case 'ê':
						case 'ì':
						case 'ï':
						case 'ð':
						case 'ñ':
						case 'ò':
						case 'ó':
						case 'ù':
							break;
						case '§':
							return 167;
						case '¨':
							return 168;
						case '­':
							return 173;
						case '¯':
							return 175;
						case '°':
							return 176;
						case '´':
							return 180;
						case '¸':
							return 184;
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
						case 'É':
							return 201;
						case 'Ë':
							return 203;
						case 'Í':
							return 205;
						case 'Î':
							return 206;
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
						case 'Ú':
							return 218;
						case 'Û':
							return 219;
						case 'Ü':
							return 220;
						case 'ß':
							return 223;
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
						case 'é':
							return 233;
						case 'ë':
							return 235;
						case 'í':
							return 237;
						case 'î':
							return 238;
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
						case 'ú':
							return 250;
						case 'û':
							return 251;
						case 'ü':
							return 252;
						default:
							switch (A_0)
							{
							case 'Ā':
								return 192;
							case 'ā':
								return 224;
							case 'Ą':
								return 161;
							case 'ą':
								return 177;
							case 'Č':
								return 200;
							case 'č':
								return 232;
							case 'Đ':
								return 208;
							case 'đ':
								return 240;
							case 'Ē':
								return 170;
							case 'ē':
								return 186;
							case 'Ė':
								return 204;
							case 'ė':
								return 236;
							case 'Ę':
								return 202;
							case 'ę':
								return 234;
							}
							break;
						}
					}
					else
					{
						switch (A_0)
						{
						case 'Ģ':
							return 171;
						case 'ģ':
							return 187;
						case 'Ĥ':
						case 'ĥ':
						case 'Ħ':
						case 'ħ':
						case 'Ĭ':
						case 'ĭ':
							break;
						case 'Ĩ':
							return 165;
						case 'ĩ':
							return 181;
						case 'Ī':
							return 207;
						case 'ī':
							return 239;
						case 'Į':
							return 199;
						case 'į':
							return 231;
						default:
							switch (A_0)
							{
							case 'Ķ':
								return 211;
							case 'ķ':
								return 243;
							case 'ĸ':
								return 162;
							case 'Ĺ':
							case 'ĺ':
								break;
							case 'Ļ':
								return 166;
							case 'ļ':
								return 182;
							default:
								switch (A_0)
								{
								case 'Ņ':
									return 209;
								case 'ņ':
									return 241;
								case 'Ŋ':
									return 189;
								case 'ŋ':
									return 191;
								case 'Ō':
									return 210;
								case 'ō':
									return 252;
								}
								break;
							}
							break;
						}
					}
				}
				else if (A_0 <= 'ų')
				{
					switch (A_0)
					{
					case 'Ŗ':
						return 163;
					case 'ŗ':
						return 179;
					default:
						switch (A_0)
						{
						case 'Š':
							return 169;
						case 'š':
							return 185;
						case 'Ţ':
						case 'ţ':
						case 'Ť':
						case 'ť':
							break;
						case 'Ŧ':
							return 172;
						case 'ŧ':
							return 188;
						case 'Ũ':
							return 221;
						case 'ũ':
							return 253;
						case 'Ū':
							return 222;
						case 'ū':
							return 254;
						default:
							switch (A_0)
							{
							case 'Ų':
								return 217;
							case 'ų':
								return 249;
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
						case '˙':
							return byte.MaxValue;
						case '˛':
							return 178;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030C7 RID: 12487 RVA: 0x001B5B74 File Offset: 0x001B4B74
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030C8 RID: 12488 RVA: 0x001B5B7C File Offset: 0x001B4B7C
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030C9 RID: 12489 RVA: 0x001B5B84 File Offset: 0x001B4B84
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030CA RID: 12490 RVA: 0x001B5B8C File Offset: 0x001B4B8C
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030CB RID: 12491 RVA: 0x001B5B94 File Offset: 0x001B4B94
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030CC RID: 12492 RVA: 0x001B5B9C File Offset: 0x001B4B9C
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030CD RID: 12493 RVA: 0x001B5BA4 File Offset: 0x001B4BA4
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030CE RID: 12494 RVA: 0x001B5BC4 File Offset: 0x001B4BC4
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aev.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F7 RID: 5879
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
			'ĸ',
			'Ŗ',
			'¤',
			'Ĩ',
			'Ļ',
			'§',
			'¨',
			'Š',
			'Ē',
			'Ģ',
			'Ŧ',
			'­',
			'Ž',
			'¯',
			'°',
			'ą',
			'˛',
			'ŗ',
			'´',
			'ĩ',
			'ļ',
			'ˇ',
			'¸',
			'š',
			'ē',
			'ģ',
			'ŧ',
			'Ŋ',
			'ž',
			'ŋ',
			'Ā',
			'Á',
			'Â',
			'Ã',
			'Ä',
			'Å',
			'Æ',
			'Į',
			'Č',
			'É',
			'Ę',
			'Ë',
			'Ė',
			'Í',
			'Î',
			'Ī',
			'Đ',
			'Ņ',
			'Ō',
			'Ķ',
			'Ô',
			'Õ',
			'Ö',
			'×',
			'Ø',
			'Ų',
			'Ú',
			'Û',
			'Ü',
			'Ũ',
			'Ū',
			'ß',
			'ā',
			'á',
			'â',
			'ã',
			'ä',
			'å',
			'æ',
			'į',
			'č',
			'é',
			'ę',
			'ë',
			'ė',
			'í',
			'î',
			'ī',
			'đ',
			'ņ',
			'ō',
			'ķ',
			'ô',
			'õ',
			'ö',
			'÷',
			'ø',
			'ų',
			'ú',
			'û',
			'ü',
			'ũ',
			'ū',
			'˙'
		};
	}
}
