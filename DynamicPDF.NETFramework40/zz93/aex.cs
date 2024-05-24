using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200049E RID: 1182
	internal class aex : Encoding
	{
		// Token: 0x060030DE RID: 12510 RVA: 0x001B6330 File Offset: 0x001B5330
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030DF RID: 12511 RVA: 0x001B6360 File Offset: 0x001B5360
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aex.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030E0 RID: 12512 RVA: 0x001B63A4 File Offset: 0x001B53A4
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
					if (A_0 == '¤')
					{
						return 164;
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
					case '،':
						return 172;
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
						return 188;
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
						return 215;
					case 'ظ':
						return 216;
					case 'ع':
						return 217;
					case 'غ':
						return 218;
					case 'ـ':
						return 224;
					case 'ف':
						return 225;
					case 'ق':
						return 226;
					case 'ك':
						return 227;
					case 'ل':
						return 228;
					case 'م':
						return 229;
					case 'ن':
						return 230;
					case 'ه':
						return 231;
					case 'و':
						return 232;
					case 'ى':
						return 233;
					case 'ي':
						return 234;
					case 'ً':
						return 235;
					case 'ٌ':
						return 236;
					case 'ٍ':
						return 237;
					case 'َ':
						return 238;
					case 'ُ':
						return 239;
					case 'ِ':
						return 240;
					case 'ّ':
						return 241;
					case 'ْ':
						return 252;
					default:
						switch (A_0)
						{
						case '':
							return 161;
						case '':
							return 162;
						case '':
							return 163;
						case '':
							return 165;
						case '':
							return 166;
						case '':
							return 167;
						case '':
							return 168;
						case '':
							return 169;
						case '':
							return 170;
						case '':
							return 171;
						case '':
							return 174;
						case '':
							return 176;
						case '':
							return 177;
						case '':
							return 178;
						case '':
							return 179;
						case '':
							return 180;
						case '':
							return 181;
						case '':
							return 182;
						case '':
							return 183;
						case '':
							return 184;
						case '':
							return 185;
						case '':
							return 186;
						case '':
							return 187;
						case '':
							return 189;
						case '':
							return 175;
						case '':
							return 190;
						case '':
							return 192;
						case '':
							return 219;
						case '':
							return 220;
						case '':
							return 221;
						case '':
							return 222;
						case '':
							return 223;
						case '':
							return 243;
						case '':
							return 244;
						case '':
							return 245;
						case '':
							return 246;
						case '':
							return 247;
						case '':
							return 248;
						case '':
							return 249;
						case '':
							return 250;
						case '':
							return 251;
						case '':
							return 252;
						case '':
							return 253;
						case '':
							return 254;
						case '':
							return byte.MaxValue;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030E1 RID: 12513 RVA: 0x001B69C7 File Offset: 0x001B59C7
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030E2 RID: 12514 RVA: 0x001B69CF File Offset: 0x001B59CF
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030E3 RID: 12515 RVA: 0x001B69D7 File Offset: 0x001B59D7
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030E4 RID: 12516 RVA: 0x001B69DF File Offset: 0x001B59DF
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030E5 RID: 12517 RVA: 0x001B69E7 File Offset: 0x001B59E7
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030E6 RID: 12518 RVA: 0x001B69EF File Offset: 0x001B59EF
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030E7 RID: 12519 RVA: 0x001B69F8 File Offset: 0x001B59F8
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030E8 RID: 12520 RVA: 0x001B6A18 File Offset: 0x001B5A18
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aex.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016F9 RID: 5881
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
			'',
			'',
			'',
			'¤',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'،',
			'­',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'؛',
			'',
			'',
			'',
			'؟',
			'',
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
			'ط',
			'ظ',
			'ع',
			'غ',
			'',
			'',
			'',
			'',
			'',
			'ـ',
			'ف',
			'ق',
			'ك',
			'ل',
			'م',
			'ن',
			'ه',
			'و',
			'ى',
			'ي',
			'ً',
			'ٌ',
			'ٍ',
			'َ',
			'ُ',
			'ِ',
			'ّ',
			'ْ',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			'',
			''
		};
	}
}
