using System;
using System.Text;

namespace zz93
{
	// Token: 0x02000499 RID: 1177
	internal class aes : Encoding
	{
		// Token: 0x0600309D RID: 12445 RVA: 0x001B37DC File Offset: 0x001B27DC
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x0600309E RID: 12446 RVA: 0x001B380C File Offset: 0x001B280C
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aes.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x0600309F RID: 12447 RVA: 0x001B3850 File Offset: 0x001B2850
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '\u0080')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ڑ')
				{
					if (A_0 <= 'ƒ')
					{
						if (A_0 <= 'ï')
						{
							switch (A_0)
							{
							case '\u00a0':
								return 160;
							case '¡':
							case 'ª':
							case 'º':
							case '¿':
							case 'À':
							case 'Á':
							case 'Â':
							case 'Ã':
							case 'Ä':
							case 'Å':
							case 'Æ':
							case 'Ç':
							case 'È':
							case 'É':
							case 'Ê':
							case 'Ë':
							case 'Ì':
							case 'Í':
							case 'Î':
							case 'Ï':
							case 'Ð':
							case 'Ñ':
							case 'Ò':
							case 'Ó':
							case 'Ô':
							case 'Õ':
							case 'Ö':
								break;
							case '¢':
								return 162;
							case '£':
								return 163;
							case '¤':
								return 164;
							case '¥':
								return 165;
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
							case '¯':
								return 175;
							case '°':
								return 176;
							case '±':
								return 177;
							case '²':
								return 178;
							case '³':
								return 179;
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
							case '¹':
								return 185;
							case '»':
								return 187;
							case '¼':
								return 188;
							case '½':
								return 189;
							case '¾':
								return 190;
							case '×':
								return 215;
							default:
								switch (A_0)
								{
								case 'à':
									return 224;
								case 'â':
									return 226;
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
								case 'î':
									return 238;
								case 'ï':
									return 239;
								}
								break;
							}
						}
						else
						{
							switch (A_0)
							{
							case 'ô':
								return 244;
							case 'õ':
							case 'ö':
							case 'ø':
							case 'ú':
								break;
							case '÷':
								return 247;
							case 'ù':
								return 249;
							case 'û':
								return 251;
							case 'ü':
								return 252;
							default:
								switch (A_0)
								{
								case 'Œ':
									return 140;
								case 'œ':
									return 156;
								default:
									if (A_0 == 'ƒ')
									{
										return 131;
									}
									break;
								}
								break;
							}
						}
					}
					else if (A_0 <= 'ٹ')
					{
						if (A_0 == 'ˆ')
						{
							return 136;
						}
						switch (A_0)
						{
						case '،':
							return 161;
						case '؍':
						case '؎':
						case '؏':
						case 'ؐ':
						case 'ؑ':
						case 'ؒ':
						case 'ؓ':
						case 'ؔ':
						case 'ؕ':
						case 'ؖ':
						case 'ؗ':
						case 'ؘ':
						case 'ؙ':
						case 'ؚ':
						case '؜':
						case '؝':
						case '؞':
						case 'ؠ':
						case 'ػ':
						case 'ؼ':
						case 'ؽ':
						case 'ؾ':
						case 'ؿ':
							break;
						case '؛':
							return 186;
						case '؟':
							return 191;
						case 'ء':
							return 193;
						case 'آ':
							return 194;
						case 'أ':
							return 195;
						case 'ؤ':
							return 196;
						case 'إ':
							return 197;
						case 'ئ':
							return 198;
						case 'ا':
							return 199;
						case 'ب':
							return 200;
						case 'ة':
							return 201;
						case 'ت':
							return 202;
						case 'ث':
							return 203;
						case 'ج':
							return 204;
						case 'ح':
							return 205;
						case 'خ':
							return 206;
						case 'د':
							return 207;
						case 'ذ':
							return 208;
						case 'ر':
							return 209;
						case 'ز':
							return 210;
						case 'س':
							return 211;
						case 'ش':
							return 212;
						case 'ص':
							return 213;
						case 'ض':
							return 214;
						case 'ط':
							return 216;
						case 'ظ':
							return 217;
						case 'ع':
							return 218;
						case 'غ':
							return 219;
						case 'ـ':
							return 220;
						case 'ف':
							return 221;
						case 'ق':
							return 222;
						case 'ك':
							return 223;
						case 'ل':
							return 225;
						case 'م':
							return 227;
						case 'ن':
							return 228;
						case 'ه':
							return 229;
						case 'و':
							return 230;
						case 'ى':
							return 236;
						case 'ي':
							return 237;
						case 'ً':
							return 240;
						case 'ٌ':
							return 241;
						case 'ٍ':
							return 252;
						case 'َ':
							return 243;
						case 'ُ':
							return 245;
						case 'ِ':
							return 246;
						case 'ّ':
							return 248;
						case 'ْ':
							return 250;
						default:
							if (A_0 == 'ٹ')
							{
								return 138;
							}
							break;
						}
					}
					else
					{
						if (A_0 == 'پ')
						{
							return 129;
						}
						switch (A_0)
						{
						case 'چ':
							return 141;
						case 'ڇ':
							break;
						case 'ڈ':
							return 143;
						default:
							if (A_0 == 'ڑ')
							{
								return 154;
							}
							break;
						}
					}
				}
				else if (A_0 <= 'ہ')
				{
					if (A_0 <= 'گ')
					{
						if (A_0 == 'ژ')
						{
							return 142;
						}
						if (A_0 == 'ک')
						{
							return 152;
						}
						if (A_0 == 'گ')
						{
							return 144;
						}
					}
					else
					{
						if (A_0 == 'ں')
						{
							return 159;
						}
						if (A_0 == 'ھ')
						{
							return 170;
						}
						if (A_0 == 'ہ')
						{
							return 192;
						}
					}
				}
				else if (A_0 <= '‰')
				{
					if (A_0 == 'ے')
					{
						return byte.MaxValue;
					}
					switch (A_0)
					{
					case '‌':
						return 157;
					case '‍':
						return 158;
					case '‎':
						return 253;
					case '‏':
						return 254;
					case '‐':
					case '‑':
					case '‒':
					case '―':
					case '‖':
					case '‗':
					case '‛':
					case '‟':
					case '‣':
					case '․':
					case '‥':
						break;
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
					default:
						if (A_0 == '‰')
						{
							return 137;
						}
						break;
					}
				}
				else
				{
					switch (A_0)
					{
					case '‹':
						return 139;
					case '›':
						return 155;
					default:
						if (A_0 == '€')
						{
							return 128;
						}
						if (A_0 == '™')
						{
							return 153;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030A0 RID: 12448 RVA: 0x001B4227 File Offset: 0x001B3227
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030A1 RID: 12449 RVA: 0x001B422F File Offset: 0x001B322F
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030A2 RID: 12450 RVA: 0x001B4237 File Offset: 0x001B3237
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030A3 RID: 12451 RVA: 0x001B423F File Offset: 0x001B323F
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030A4 RID: 12452 RVA: 0x001B4247 File Offset: 0x001B3247
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030A5 RID: 12453 RVA: 0x001B424F File Offset: 0x001B324F
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030A6 RID: 12454 RVA: 0x001B4258 File Offset: 0x001B3258
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030A7 RID: 12455 RVA: 0x001B4278 File Offset: 0x001B3278
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aes.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F4 RID: 5876
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
			'پ',
			'‚',
			'ƒ',
			'„',
			'…',
			'†',
			'‡',
			'ˆ',
			'‰',
			'ٹ',
			'‹',
			'Œ',
			'چ',
			'ژ',
			'ڈ',
			'گ',
			'‘',
			'’',
			'“',
			'”',
			'•',
			'–',
			'—',
			'ک',
			'™',
			'ڑ',
			'›',
			'œ',
			'‌',
			'‍',
			'ں',
			'\u00a0',
			'،',
			'¢',
			'£',
			'¤',
			'¥',
			'¦',
			'§',
			'¨',
			'©',
			'ھ',
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
			'؛',
			'»',
			'¼',
			'½',
			'¾',
			'؟',
			'ہ',
			'ء',
			'آ',
			'أ',
			'ؤ',
			'إ',
			'ئ',
			'ا',
			'ب',
			'ة',
			'ت',
			'ث',
			'ج',
			'ح',
			'خ',
			'د',
			'ذ',
			'ر',
			'ز',
			'س',
			'ش',
			'ص',
			'ض',
			'×',
			'ط',
			'ظ',
			'ع',
			'غ',
			'ـ',
			'ف',
			'ق',
			'ك',
			'à',
			'ل',
			'â',
			'م',
			'ن',
			'ه',
			'و',
			'ç',
			'è',
			'é',
			'ê',
			'ë',
			'ى',
			'ي',
			'î',
			'ï',
			'ً',
			'ٌ',
			'ٍ',
			'َ',
			'ô',
			'ُ',
			'ِ',
			'÷',
			'ّ',
			'ù',
			'ْ',
			'û',
			'ü',
			'‎',
			'‏',
			'ے'
		};
	}
}
