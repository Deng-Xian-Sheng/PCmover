using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200049F RID: 1183
	internal class aey : Encoding
	{
		// Token: 0x060030EB RID: 12523 RVA: 0x001B6A84 File Offset: 0x001B5A84
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x060030EC RID: 12524 RVA: 0x001B6AB4 File Offset: 0x001B5AB4
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = aey.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x060030ED RID: 12525 RVA: 0x001B6AF8 File Offset: 0x001B5AF8
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < '¡')
			{
				result = (byte)A_0;
			}
			else
			{
				if (A_0 <= 'ʽ')
				{
					switch (A_0)
					{
					case '£':
						return 163;
					case '¤':
					case '¥':
					case 'ª':
					case '®':
					case '¯':
					case '´':
					case 'µ':
					case '¶':
					case '¸':
					case '¹':
					case 'º':
					case '¼':
						break;
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
					case '°':
						return 177;
					case '±':
						return 178;
					case '²':
						return 179;
					case '³':
						return 180;
					case '·':
						return 184;
					case '»':
						return 188;
					case '½':
						return 175;
					default:
						switch (A_0)
						{
						case 'ʼ':
							return 162;
						case 'ʽ':
							return 161;
						}
						break;
					}
				}
				else
				{
					switch (A_0)
					{
					case '΄':
						return 181;
					case '΅':
						return 182;
					case 'Ά':
						return 183;
					case '·':
					case '΋':
					case '΍':
					case '΢':
						break;
					case 'Έ':
						return 185;
					case 'Ή':
						return 186;
					case 'Ί':
						return 187;
					case 'Ό':
						return 189;
					case 'Ύ':
						return 190;
					case 'Ώ':
						return 191;
					case 'ΐ':
						return 192;
					case 'Α':
						return 193;
					case 'Β':
						return 194;
					case 'Γ':
						return 195;
					case 'Δ':
						return 196;
					case 'Ε':
						return 197;
					case 'Ζ':
						return 198;
					case 'Η':
						return 199;
					case 'Θ':
						return 200;
					case 'Ι':
						return 201;
					case 'Κ':
						return 202;
					case 'Λ':
						return 203;
					case 'Μ':
						return 204;
					case 'Ν':
						return 205;
					case 'Ξ':
						return 206;
					case 'Ο':
						return 207;
					case 'Π':
						return 208;
					case 'Ρ':
						return 209;
					case 'Σ':
						return 211;
					case 'Τ':
						return 212;
					case 'Υ':
						return 213;
					case 'Φ':
						return 214;
					case 'Χ':
						return 215;
					case 'Ψ':
						return 216;
					case 'Ω':
						return 217;
					case 'Ϊ':
						return 218;
					case 'Ϋ':
						return 219;
					case 'ά':
						return 220;
					case 'έ':
						return 221;
					case 'ή':
						return 222;
					case 'ί':
						return 223;
					case 'ΰ':
						return 224;
					case 'α':
						return 225;
					case 'β':
						return 226;
					case 'γ':
						return 227;
					case 'δ':
						return 228;
					case 'ε':
						return 229;
					case 'ζ':
						return 230;
					case 'η':
						return 231;
					case 'θ':
						return 232;
					case 'ι':
						return 233;
					case 'κ':
						return 234;
					case 'λ':
						return 235;
					case 'μ':
						return 236;
					case 'ν':
						return 237;
					case 'ξ':
						return 238;
					case 'ο':
						return 239;
					case 'π':
						return 240;
					case 'ρ':
						return 241;
					case 'ς':
						return 252;
					case 'σ':
						return 243;
					case 'τ':
						return 244;
					case 'υ':
						return 245;
					case 'φ':
						return 246;
					case 'χ':
						return 247;
					case 'ψ':
						return 248;
					case 'ω':
						return 249;
					case 'ϊ':
						return 250;
					case 'ϋ':
						return 251;
					case 'ό':
						return 252;
					case 'ύ':
						return 253;
					case 'ώ':
						return 254;
					default:
						if (A_0 == '―')
						{
							return 176;
						}
						switch (A_0)
						{
						case '':
							return 164;
						case '':
							return 165;
						case '':
							return 170;
						case '':
							return 174;
						case '':
							return 210;
						case '':
							return byte.MaxValue;
						}
						break;
					}
				}
				result = (byte)A_0;
			}
			return result;
		}

		// Token: 0x060030EE RID: 12526 RVA: 0x001B7113 File Offset: 0x001B6113
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030EF RID: 12527 RVA: 0x001B711B File Offset: 0x001B611B
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030F0 RID: 12528 RVA: 0x001B7123 File Offset: 0x001B6123
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030F1 RID: 12529 RVA: 0x001B712B File Offset: 0x001B612B
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030F2 RID: 12530 RVA: 0x001B7133 File Offset: 0x001B6133
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030F3 RID: 12531 RVA: 0x001B713B File Offset: 0x001B613B
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060030F4 RID: 12532 RVA: 0x001B7144 File Offset: 0x001B6144
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x060030F5 RID: 12533 RVA: 0x001B7164 File Offset: 0x001B6164
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = aey.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016FA RID: 5882
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
			'ʽ',
			'ʼ',
			'£',
			'',
			'',
			'¦',
			'§',
			'¨',
			'©',
			'',
			'«',
			'¬',
			'­',
			'',
			'―',
			'°',
			'±',
			'²',
			'³',
			'΄',
			'΅',
			'Ά',
			'·',
			'Έ',
			'Ή',
			'Ί',
			'»',
			'Ό',
			'½',
			'Ύ',
			'Ώ',
			'ΐ',
			'Α',
			'Β',
			'Γ',
			'Δ',
			'Ε',
			'Ζ',
			'Η',
			'Θ',
			'Ι',
			'Κ',
			'Λ',
			'Μ',
			'Ν',
			'Ξ',
			'Ο',
			'Π',
			'Ρ',
			'',
			'Σ',
			'Τ',
			'Υ',
			'Φ',
			'Χ',
			'Ψ',
			'Ω',
			'Ϊ',
			'Ϋ',
			'ά',
			'έ',
			'ή',
			'ί',
			'ΰ',
			'α',
			'β',
			'γ',
			'δ',
			'ε',
			'ζ',
			'η',
			'θ',
			'ι',
			'κ',
			'λ',
			'μ',
			'ν',
			'ξ',
			'ο',
			'π',
			'ρ',
			'ς',
			'σ',
			'τ',
			'υ',
			'φ',
			'χ',
			'ψ',
			'ω',
			'ϊ',
			'ϋ',
			'ό',
			'ύ',
			'ώ',
			''
		};
	}
}
