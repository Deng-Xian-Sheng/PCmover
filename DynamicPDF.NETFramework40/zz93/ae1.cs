using System;
using System.Text;

namespace zz93
{
	// Token: 0x020004A2 RID: 1186
	internal class ae1 : Encoding
	{
		// Token: 0x06003112 RID: 12562 RVA: 0x001B7A90 File Offset: 0x001B6A90
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x06003113 RID: 12563 RVA: 0x001B7AC0 File Offset: 0x001B6AC0
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = ae1.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003114 RID: 12564 RVA: 0x001B7B04 File Offset: 0x001B6B04
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ņ')
				{
					if (A_0 <= 'ę')
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
						case '¨':
						case 'ª':
						case '¯':
						case '´':
						case '¸':
						case 'º':
						case '¿':
						case 'À':
						case 'Á':
						case 'Â':
						case 'Ã':
						case 'Ç':
						case 'È':
						case 'Ê':
						case 'Ë':
						case 'Ì':
						case 'Í':
						case 'Î':
						case 'Ï':
						case 'Ð':
						case 'Ñ':
						case 'Ò':
						case 'Ô':
						case 'Ù':
						case 'Ú':
						case 'Û':
						case 'Ý':
						case 'Þ':
						case 'à':
						case 'á':
						case 'â':
						case 'ã':
						case 'ç':
						case 'è':
							break;
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
						case '»':
							return 188;
						case '¼':
							return 189;
						case '½':
							return 175;
						case '¾':
							return 190;
						case 'Ä':
							return 196;
						case 'Å':
							return 197;
						case 'Æ':
							return 176;
						case 'É':
							return 201;
						case 'Ó':
							return 211;
						case 'Õ':
							return 213;
						case 'Ö':
							return 214;
						case '×':
							return 215;
						case 'Ø':
							return 168;
						case 'Ü':
							return 220;
						case 'ß':
							return 223;
						case 'ä':
							return 228;
						case 'å':
							return 229;
						case 'æ':
							return 191;
						case 'é':
							return 233;
						default:
							switch (A_0)
							{
							case 'ó':
								return 243;
							case 'õ':
								return 245;
							case 'ö':
								return 246;
							case '÷':
								return 247;
							case 'ø':
								return 185;
							case 'ü':
								return 252;
							case 'Ā':
								return 194;
							case 'ā':
								return 226;
							case 'Ą':
								return 192;
							case 'ą':
								return 224;
							case 'Ć':
								return 195;
							case 'ć':
								return 227;
							case 'Č':
								return 200;
							case 'č':
								return 232;
							case 'Ē':
								return 199;
							case 'ē':
								return 231;
							case 'Ė':
								return 203;
							case 'ė':
								return 235;
							case 'Ę':
								return 198;
							case 'ę':
								return 230;
							}
							break;
						}
					}
					else
					{
						switch (A_0)
						{
						case 'Ģ':
							return 204;
						case 'ģ':
							return 236;
						default:
							switch (A_0)
							{
							case 'Ī':
								return 206;
							case 'ī':
								return 238;
							case 'Ĭ':
							case 'ĭ':
								break;
							case 'Į':
								return 193;
							case 'į':
								return 225;
							default:
								switch (A_0)
								{
								case 'Ķ':
									return 205;
								case 'ķ':
									return 237;
								case 'Ļ':
									return 207;
								case 'ļ':
									return 239;
								case 'Ł':
									return 217;
								case 'ł':
									return 249;
								case 'Ń':
									return 209;
								case 'ń':
									return 241;
								case 'Ņ':
									return 210;
								case 'ņ':
									return 252;
								}
								break;
							}
							break;
						}
					}
				}
				else if (A_0 <= 'š')
				{
					switch (A_0)
					{
					case 'Ō':
						return 212;
					case 'ō':
						return 244;
					default:
						switch (A_0)
						{
						case 'Ŗ':
							return 170;
						case 'ŗ':
							return 187;
						case 'Ř':
						case 'ř':
							break;
						case 'Ś':
							return 218;
						case 'ś':
							return 250;
						default:
							switch (A_0)
							{
							case 'Š':
								return 208;
							case 'š':
								return 240;
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
					case 'Ū':
						return 219;
					case 'ū':
						return 251;
					default:
						switch (A_0)
						{
						case 'Ų':
							return 216;
						case 'ų':
							return 248;
						case 'Ŵ':
						case 'ŵ':
						case 'Ŷ':
						case 'ŷ':
						case 'Ÿ':
							break;
						case 'Ź':
							return 202;
						case 'ź':
							return 234;
						case 'Ż':
							return 221;
						case 'ż':
							return 253;
						case 'Ž':
							return 222;
						case 'ž':
							return 254;
						default:
							switch (A_0)
							{
							case '’':
								return byte.MaxValue;
							case '“':
								return 181;
							case '”':
								return 161;
							case '„':
								return 165;
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

		// Token: 0x06003115 RID: 12565 RVA: 0x001B8269 File Offset: 0x001B7269
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003116 RID: 12566 RVA: 0x001B8271 File Offset: 0x001B7271
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003117 RID: 12567 RVA: 0x001B8279 File Offset: 0x001B7279
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003118 RID: 12568 RVA: 0x001B8281 File Offset: 0x001B7281
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x001B8289 File Offset: 0x001B7289
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600311A RID: 12570 RVA: 0x001B8291 File Offset: 0x001B7291
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600311B RID: 12571 RVA: 0x001B829C File Offset: 0x001B729C
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x0600311C RID: 12572 RVA: 0x001B82BC File Offset: 0x001B72BC
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = ae1.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016FD RID: 5885
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
			'”',
			'¢',
			'£',
			'¤',
			'„',
			'¦',
			'§',
			'Ø',
			'©',
			'Ŗ',
			'«',
			'¬',
			'­',
			'®',
			'Æ',
			'°',
			'±',
			'²',
			'³',
			'“',
			'µ',
			'¶',
			'·',
			'ø',
			'¹',
			'ŗ',
			'»',
			'¼',
			'½',
			'¾',
			'æ',
			'Ą',
			'Į',
			'Ā',
			'Ć',
			'Ä',
			'Å',
			'Ę',
			'Ē',
			'Č',
			'É',
			'Ź',
			'Ė',
			'Ģ',
			'Ķ',
			'Ī',
			'Ļ',
			'Š',
			'Ń',
			'Ņ',
			'Ó',
			'Ō',
			'Õ',
			'Ö',
			'×',
			'Ų',
			'Ł',
			'Ś',
			'Ū',
			'Ü',
			'Ż',
			'Ž',
			'ß',
			'ą',
			'į',
			'ā',
			'ć',
			'ä',
			'å',
			'ę',
			'ē',
			'č',
			'é',
			'ź',
			'ė',
			'ģ',
			'ķ',
			'ī',
			'ļ',
			'š',
			'ń',
			'ņ',
			'ó',
			'ō',
			'õ',
			'ö',
			'÷',
			'ų',
			'ł',
			'ś',
			'ū',
			'ü',
			'ż',
			'ž',
			'’'
		};
	}
}
