using System;
using System.Text;

namespace zz93
{
	// Token: 0x020004A1 RID: 1185
	internal class ae0 : Encoding
	{
		// Token: 0x06003105 RID: 12549 RVA: 0x001B7900 File Offset: 0x001B6900
		public override byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length];
			this.GetBytes(str, 0, str.Length, array, 0);
			return array;
		}

		// Token: 0x06003106 RID: 12550 RVA: 0x001B7930 File Offset: 0x001B6930
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = byteIndex;
			int i = charIndex;
			while (i < charIndex + charCount)
			{
				bytes[byteIndex] = ae0.a(s[i]);
				i++;
				byteIndex++;
			}
			return byteIndex - num;
		}

		// Token: 0x06003107 RID: 12551 RVA: 0x001B7974 File Offset: 0x001B6974
		private static byte a(char A_0)
		{
			byte result;
			if (A_0 < 'ý')
			{
				result = (byte)A_0;
			}
			else if (A_0 != 'ÿ')
			{
				if (A_0 != 'ı')
				{
					if (A_0 != 'ş')
					{
						result = (byte)A_0;
					}
					else
					{
						result = 254;
					}
				}
				else
				{
					result = 253;
				}
			}
			else
			{
				result = byte.MaxValue;
			}
			return result;
		}

		// Token: 0x06003108 RID: 12552 RVA: 0x001B79D1 File Offset: 0x001B69D1
		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003109 RID: 12553 RVA: 0x001B79D9 File Offset: 0x001B69D9
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600310A RID: 12554 RVA: 0x001B79E1 File Offset: 0x001B69E1
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600310B RID: 12555 RVA: 0x001B79E9 File Offset: 0x001B69E9
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600310C RID: 12556 RVA: 0x001B79F1 File Offset: 0x001B69F1
		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600310D RID: 12557 RVA: 0x001B79F9 File Offset: 0x001B69F9
		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600310E RID: 12558 RVA: 0x001B7A04 File Offset: 0x001B6A04
		public override string GetString(byte[] bytes)
		{
			return this.GetString(bytes, 0, bytes.Length);
		}

		// Token: 0x0600310F RID: 12559 RVA: 0x001B7A24 File Offset: 0x001B6A24
		public override string GetString(byte[] bytes, int index, int count)
		{
			char[] array = new char[count];
			int i = index;
			int num = 0;
			while (i < index + count)
			{
				array[num] = ae0.a[(int)bytes[i]];
				i++;
				num++;
			}
			return new string(array);
		}

		// Token: 0x040016FC RID: 5884
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
			'Ğ',
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
			'İ',
			'Ş',
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
			'ğ',
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
			'ı',
			'ş',
			'ÿ'
		};
	}
}
