using System;
using System.Text;

namespace zz93
{
	// Token: 0x020004A4 RID: 1188
	internal class ae3 : Encoding
	{
		// Token: 0x0600312C RID: 12588 RVA: 0x001B8A28 File Offset: 0x001B7A28
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x0600312D RID: 12589 RVA: 0x001B8A58 File Offset: 0x001B7A58
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = ae3.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x001B8A9C File Offset: 0x001B7A9C
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '\u0080')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= '≥')
				{
					if (A_0 <= 'ε')
					{
						if (A_0 <= 'Θ')
						{
							if (A_0 <= 'ƒ')
							{
								switch (A_0)
								{
								case '\u00a0':
									return byte.MaxValue;
								case '¡':
									return 173;
								case '¢':
									return 155;
								case '£':
									return 156;
								case '¤':
								case '¦':
								case '§':
								case '¨':
								case '©':
								case '­':
								case '®':
								case '¯':
								case '³':
								case '´':
								case '¶':
								case '¸':
								case '¹':
								case '¾':
								case 'À':
								case 'Á':
								case 'Â':
								case 'Ã':
								case 'È':
								case 'Ê':
								case 'Ë':
								case 'Ì':
								case 'Í':
								case 'Î':
								case 'Ï':
								case 'Ð':
								case 'Ò':
								case 'Ó':
								case 'Ô':
								case 'Õ':
								case '×':
								case 'Ø':
								case 'Ù':
								case 'Ú':
								case 'Û':
								case 'Ý':
								case 'Þ':
								case 'ã':
								case 'ð':
								case 'õ':
								case 'ø':
								case 'ý':
								case 'þ':
									break;
								case '¥':
									return 157;
								case 'ª':
									return 166;
								case '«':
									return 174;
								case '¬':
									return 170;
								case '°':
									return 248;
								case '±':
									return 241;
								case '²':
									return 253;
								case 'µ':
									return 230;
								case '·':
									return 250;
								case 'º':
									return 167;
								case '»':
									return 175;
								case '¼':
									return 172;
								case '½':
									return 171;
								case '¿':
									return 168;
								case 'Ä':
									return 142;
								case 'Å':
									return 143;
								case 'Æ':
									return 146;
								case 'Ç':
									return 128;
								case 'É':
									return 144;
								case 'Ñ':
									return 165;
								case 'Ö':
									return 153;
								case 'Ü':
									return 154;
								case 'ß':
									return 225;
								case 'à':
									return 133;
								case 'á':
									return 160;
								case 'â':
									return 131;
								case 'ä':
									return 132;
								case 'å':
									return 134;
								case 'æ':
									return 145;
								case 'ç':
									return 135;
								case 'è':
									return 138;
								case 'é':
									return 130;
								case 'ê':
									return 136;
								case 'ë':
									return 137;
								case 'ì':
									return 141;
								case 'í':
									return 161;
								case 'î':
									return 140;
								case 'ï':
									return 139;
								case 'ñ':
									return 164;
								case 'ò':
									return 149;
								case 'ó':
									return 162;
								case 'ô':
									return 147;
								case 'ö':
									return 148;
								case '÷':
									return 246;
								case 'ù':
									return 151;
								case 'ú':
									return 163;
								case 'û':
									return 150;
								case 'ü':
									return 129;
								case 'ÿ':
									return 152;
								default:
									if (A_0 == 'ƒ')
									{
										return 159;
									}
									break;
								}
							}
							else
							{
								if (A_0 == 'Γ')
								{
									return 226;
								}
								if (A_0 == 'Θ')
								{
									return 233;
								}
							}
						}
						else if (A_0 <= 'Φ')
						{
							if (A_0 == 'Σ')
							{
								return 228;
							}
							if (A_0 == 'Φ')
							{
								return 232;
							}
						}
						else
						{
							if (A_0 == 'Ω')
							{
								return 234;
							}
							switch (A_0)
							{
							case 'α':
								return 224;
							case 'δ':
								return 235;
							case 'ε':
								return 238;
							}
						}
					}
					else if (A_0 <= '√')
					{
						if (A_0 <= 'ⁿ')
						{
							switch (A_0)
							{
							case 'π':
								return 227;
							case 'ρ':
							case 'ς':
							case 'υ':
								break;
							case 'σ':
								return 229;
							case 'τ':
								return 231;
							case 'φ':
								return 237;
							default:
								if (A_0 == 'ⁿ')
								{
									return 252;
								}
								break;
							}
						}
						else
						{
							if (A_0 == '₧')
							{
								return 158;
							}
							switch (A_0)
							{
							case '∙':
								return 249;
							case '√':
								return 251;
							}
						}
					}
					else if (A_0 <= '∩')
					{
						if (A_0 == '∞')
						{
							return 236;
						}
						if (A_0 == '∩')
						{
							return 239;
						}
					}
					else
					{
						if (A_0 == '≈')
						{
							return 247;
						}
						switch (A_0)
						{
						case '≡':
							return 240;
						case '≤':
							return 243;
						case '≥':
							return 252;
						}
					}
				}
				else if (A_0 <= '├')
				{
					if (A_0 <= '┌')
					{
						if (A_0 <= '⌡')
						{
							if (A_0 == '⌐')
							{
								return 169;
							}
							switch (A_0)
							{
							case '⌠':
								return 244;
							case '⌡':
								return 245;
							}
						}
						else
						{
							switch (A_0)
							{
							case '─':
								return 196;
							case '━':
								break;
							case '│':
								return 179;
							default:
								if (A_0 == '┌')
								{
									return 218;
								}
								break;
							}
						}
					}
					else if (A_0 <= '└')
					{
						if (A_0 == '┐')
						{
							return 191;
						}
						if (A_0 == '└')
						{
							return 192;
						}
					}
					else
					{
						if (A_0 == '┘')
						{
							return 217;
						}
						if (A_0 == '├')
						{
							return 195;
						}
					}
				}
				else if (A_0 <= '▀')
				{
					if (A_0 <= '┬')
					{
						if (A_0 == '┤')
						{
							return 180;
						}
						if (A_0 == '┬')
						{
							return 194;
						}
					}
					else
					{
						switch (A_0)
						{
						case '┴':
							return 193;
						case '┵':
						case '┶':
						case '┷':
						case '┸':
						case '┹':
						case '┺':
						case '┻':
						case '┽':
						case '┾':
						case '┿':
						case '╀':
						case '╁':
						case '╂':
						case '╃':
						case '╄':
						case '╅':
						case '╆':
						case '╇':
						case '╈':
						case '╉':
						case '╊':
						case '╋':
						case '╌':
						case '╍':
						case '╎':
						case '╏':
							break;
						case '┼':
							return 197;
						case '═':
							return 205;
						case '║':
							return 186;
						case '╒':
							return 213;
						case '╓':
							return 214;
						case '╔':
							return 201;
						case '╕':
							return 184;
						case '╖':
							return 183;
						case '╗':
							return 187;
						case '╘':
							return 212;
						case '╙':
							return 211;
						case '╚':
							return 200;
						case '╛':
							return 190;
						case '╜':
							return 189;
						case '╝':
							return 188;
						case '╞':
							return 198;
						case '╟':
							return 199;
						case '╠':
							return 204;
						case '╡':
							return 181;
						case '╢':
							return 182;
						case '╣':
							return 185;
						case '╤':
							return 209;
						case '╥':
							return 210;
						case '╦':
							return 203;
						case '╧':
							return 207;
						case '╨':
							return 208;
						case '╩':
							return 202;
						case '╪':
							return 216;
						case '╫':
							return 215;
						case '╬':
							return 206;
						default:
							if (A_0 == '▀')
							{
								return 223;
							}
							break;
						}
					}
				}
				else if (A_0 <= '█')
				{
					if (A_0 == '▄')
					{
						return 220;
					}
					if (A_0 == '█')
					{
						return 219;
					}
				}
				else
				{
					switch (A_0)
					{
					case '▌':
						return 221;
					case '▍':
					case '▎':
					case '▏':
						break;
					case '▐':
						return 222;
					case '░':
						return 176;
					case '▒':
						return 177;
					case '▓':
						return 178;
					default:
						if (A_0 == '■')
						{
							return 254;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x0600312F RID: 12591 RVA: 0x001B9541 File Offset: 0x001B8541
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x001B9549 File Offset: 0x001B8549
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003131 RID: 12593 RVA: 0x001B9551 File Offset: 0x001B8551
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x001B9559 File Offset: 0x001B8559
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003133 RID: 12595 RVA: 0x001B9561 File Offset: 0x001B8561
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x001B9569 File Offset: 0x001B8569
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003135 RID: 12597 RVA: 0x001B9574 File Offset: 0x001B8574
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x06003136 RID: 12598 RVA: 0x001B9594 File Offset: 0x001B8594
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = ae3.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016FF RID: 5887
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
			'Ç',
			'ü',
			'é',
			'â',
			'ä',
			'à',
			'å',
			'ç',
			'ê',
			'ë',
			'è',
			'ï',
			'î',
			'ì',
			'Ä',
			'Å',
			'É',
			'æ',
			'Æ',
			'ô',
			'ö',
			'ò',
			'û',
			'ù',
			'ÿ',
			'Ö',
			'Ü',
			'¢',
			'£',
			'¥',
			'₧',
			'ƒ',
			'á',
			'í',
			'ó',
			'ú',
			'ñ',
			'Ñ',
			'ª',
			'º',
			'¿',
			'⌐',
			'¬',
			'½',
			'¼',
			'¡',
			'«',
			'»',
			'░',
			'▒',
			'▓',
			'│',
			'┤',
			'╡',
			'╢',
			'╖',
			'╕',
			'╣',
			'║',
			'╗',
			'╝',
			'╜',
			'╛',
			'┐',
			'└',
			'┴',
			'┬',
			'├',
			'─',
			'┼',
			'╞',
			'╟',
			'╚',
			'╔',
			'╩',
			'╦',
			'╠',
			'═',
			'╬',
			'╧',
			'╨',
			'╤',
			'╥',
			'╙',
			'╘',
			'╒',
			'╓',
			'╫',
			'╪',
			'┘',
			'┌',
			'█',
			'▄',
			'▌',
			'▐',
			'▀',
			'α',
			'ß',
			'Γ',
			'π',
			'Σ',
			'σ',
			'µ',
			'τ',
			'Φ',
			'Θ',
			'Ω',
			'δ',
			'∞',
			'φ',
			'ε',
			'∩',
			'≡',
			'±',
			'≥',
			'≤',
			'⌠',
			'⌡',
			'÷',
			'≈',
			'°',
			'∙',
			'·',
			'√',
			'ⁿ',
			'²',
			'■',
			'\u00a0'
		};
	}
}
