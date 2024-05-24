using System;
using System.Text;

namespace zz93
{
	// Token: 0x020004A5 RID: 1189
	internal class ae4 : Encoding
	{
		// Token: 0x06003139 RID: 12601 RVA: 0x001B9600 File Offset: 0x001B8600
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x0600313A RID: 12602 RVA: 0x001B9630 File Offset: 0x001B8630
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = ae4.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x0600313B RID: 12603 RVA: 0x001B9674 File Offset: 0x001B8674
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '\u0080')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= '”')
				{
					switch (A_0)
					{
					case '\u0081':
						return 129;
					case '\u0082':
						return 130;
					case '\u0083':
						return 131;
					case '\u0084':
						return 132;
					case '\u0085':
					case '\u0091':
					case '\u0092':
					case '\u0093':
					case '\u0094':
					case '\u0095':
					case '\u0096':
					case '\u0097':
						break;
					case '\u0086':
						return 134;
					case '\u0087':
						return 135;
					case '\u0088':
						return 136;
					case '\u0089':
						return 137;
					case '\u008a':
						return 138;
					case '\u008b':
						return 139;
					case '\u008c':
						return 140;
					case '\u008d':
						return 141;
					case '\u008e':
						return 142;
					case '\u008f':
						return 143;
					case '\u0090':
						return 144;
					case '\u0098':
						return 152;
					case '\u0099':
						return 153;
					case '\u009a':
						return 154;
					case '\u009b':
						return 155;
					case '\u009c':
						return 156;
					case '\u009d':
						return 157;
					case '\u009e':
						return 158;
					case '\u009f':
						return 159;
					case '\u00a0':
						return 160;
					default:
						switch (A_0)
						{
						case 'ก':
							return 161;
						case 'ข':
							return 162;
						case 'ฃ':
							return 163;
						case 'ค':
							return 164;
						case 'ฅ':
							return 165;
						case 'ฆ':
							return 166;
						case 'ง':
							return 167;
						case 'จ':
							return 168;
						case 'ฉ':
							return 169;
						case 'ช':
							return 170;
						case 'ซ':
							return 171;
						case 'ฌ':
							return 172;
						case 'ญ':
							return 173;
						case 'ฎ':
							return 174;
						case 'ฏ':
							return 175;
						case 'ฐ':
							return 176;
						case 'ฑ':
							return 177;
						case 'ฒ':
							return 178;
						case 'ณ':
							return 179;
						case 'ด':
							return 180;
						case 'ต':
							return 181;
						case 'ถ':
							return 182;
						case 'ท':
							return 183;
						case 'ธ':
							return 184;
						case 'น':
							return 185;
						case 'บ':
							return 186;
						case 'ป':
							return 187;
						case 'ผ':
							return 188;
						case 'ฝ':
							return 189;
						case 'พ':
							return 190;
						case 'ฟ':
							return 191;
						case 'ภ':
							return 192;
						case 'ม':
							return 193;
						case 'ย':
							return 194;
						case 'ร':
							return 195;
						case 'ฤ':
							return 196;
						case 'ล':
							return 197;
						case 'ฦ':
							return 198;
						case 'ว':
							return 199;
						case 'ศ':
							return 200;
						case 'ษ':
							return 201;
						case 'ส':
							return 202;
						case 'ห':
							return 203;
						case 'ฬ':
							return 204;
						case 'อ':
							return 205;
						case 'ฮ':
							return 206;
						case 'ฯ':
							return 207;
						case 'ะ':
							return 208;
						case 'ั':
							return 209;
						case 'า':
							return 210;
						case 'ำ':
							return 211;
						case 'ิ':
							return 212;
						case 'ี':
							return 213;
						case 'ึ':
							return 214;
						case 'ื':
							return 215;
						case 'ุ':
							return 216;
						case 'ู':
							return 217;
						case 'ฺ':
							return 218;
						case '฻':
						case '฼':
						case '฽':
						case '฾':
							break;
						case '฿':
							return 223;
						case 'เ':
							return 224;
						case 'แ':
							return 225;
						case 'โ':
							return 226;
						case 'ใ':
							return 227;
						case 'ไ':
							return 228;
						case 'ๅ':
							return 229;
						case 'ๆ':
							return 230;
						case '็':
							return 231;
						case '่':
							return 232;
						case '้':
							return 233;
						case '๊':
							return 234;
						case '๋':
							return 235;
						case '์':
							return 236;
						case 'ํ':
							return 237;
						case '๎':
							return 238;
						case '๏':
							return 239;
						case '๐':
							return 240;
						case '๑':
							return 241;
						case '๒':
							return 252;
						case '๓':
							return 243;
						case '๔':
							return 244;
						case '๕':
							return 245;
						case '๖':
							return 246;
						case '๗':
							return 247;
						case '๘':
							return 248;
						case '๙':
							return 249;
						case '๚':
							return 250;
						case '๛':
							return 251;
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
							case '“':
								return 147;
							case '”':
								return 148;
							}
							break;
						}
						break;
					}
				}
				else if (A_0 <= '…')
				{
					if (A_0 == '•')
					{
						return 149;
					}
					if (A_0 == '…')
					{
						return 133;
					}
				}
				else
				{
					if (A_0 == '€')
					{
						return 128;
					}
					switch (A_0)
					{
					case '':
						return 219;
					case '':
						return 220;
					case '':
						return 221;
					case '':
						return 222;
					case '':
						return 252;
					case '':
						return 253;
					case '':
						return 254;
					case '':
						return byte.MaxValue;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x001B9E97 File Offset: 0x001B8E97
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600313D RID: 12605 RVA: 0x001B9E9F File Offset: 0x001B8E9F
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600313E RID: 12606 RVA: 0x001B9EA7 File Offset: 0x001B8EA7
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600313F RID: 12607 RVA: 0x001B9EAF File Offset: 0x001B8EAF
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003140 RID: 12608 RVA: 0x001B9EB7 File Offset: 0x001B8EB7
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003141 RID: 12609 RVA: 0x001B9EBF File Offset: 0x001B8EBF
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003142 RID: 12610 RVA: 0x001B9EC8 File Offset: 0x001B8EC8
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x06003143 RID: 12611 RVA: 0x001B9EE8 File Offset: 0x001B8EE8
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = ae4.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x04001700 RID: 5888
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
			'\u0082',
			'\u0083',
			'\u0084',
			'…',
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
			'‘',
			'’',
			'“',
			'”',
			'•',
			'–',
			'—',
			'\u0098',
			'\u0099',
			'\u009a',
			'\u009b',
			'\u009c',
			'\u009d',
			'\u009e',
			'\u009f',
			'\u00a0',
			'ก',
			'ข',
			'ฃ',
			'ค',
			'ฅ',
			'ฆ',
			'ง',
			'จ',
			'ฉ',
			'ช',
			'ซ',
			'ฌ',
			'ญ',
			'ฎ',
			'ฏ',
			'ฐ',
			'ฑ',
			'ฒ',
			'ณ',
			'ด',
			'ต',
			'ถ',
			'ท',
			'ธ',
			'น',
			'บ',
			'ป',
			'ผ',
			'ฝ',
			'พ',
			'ฟ',
			'ภ',
			'ม',
			'ย',
			'ร',
			'ฤ',
			'ล',
			'ฦ',
			'ว',
			'ศ',
			'ษ',
			'ส',
			'ห',
			'ฬ',
			'อ',
			'ฮ',
			'ฯ',
			'ะ',
			'ั',
			'า',
			'ำ',
			'ิ',
			'ี',
			'ึ',
			'ื',
			'ุ',
			'ู',
			'ฺ',
			'',
			'',
			'',
			'',
			'฿',
			'เ',
			'แ',
			'โ',
			'ใ',
			'ไ',
			'ๅ',
			'ๆ',
			'็',
			'่',
			'้',
			'๊',
			'๋',
			'์',
			'ํ',
			'๎',
			'๏',
			'๐',
			'๑',
			'๒',
			'๓',
			'๔',
			'๕',
			'๖',
			'๗',
			'๘',
			'๙',
			'๚',
			'๛',
			'',
			'',
			'',
			''
		};
	}
}
