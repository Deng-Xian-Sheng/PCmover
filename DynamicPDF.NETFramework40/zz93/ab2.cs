using System;

namespace zz93
{
	// Token: 0x02000434 RID: 1076
	internal class ab2
	{
		// Token: 0x06002C97 RID: 11415 RVA: 0x00197540 File Offset: 0x00196540
		private ab2()
		{
		}

		// Token: 0x06002C98 RID: 11416 RVA: 0x0019754C File Offset: 0x0019654C
		internal static string a(byte[] A_0)
		{
			char[] array = new char[A_0.Length];
			for (int i = 0; i < A_0.Length; i++)
			{
				array[i] = ab2.a(A_0[i]);
			}
			return new string(array);
		}

		// Token: 0x06002C99 RID: 11417 RVA: 0x0019758C File Offset: 0x0019658C
		internal static string a(byte[] A_0, int A_1, int A_2)
		{
			char[] array = new char[A_2];
			for (int i = 0; i < A_2; i++)
			{
				array[i] = ab2.a(A_0[A_1 + i]);
			}
			return new string(array);
		}

		// Token: 0x06002C9A RID: 11418 RVA: 0x001975CC File Offset: 0x001965CC
		internal static string a(byte[] A_0, long A_1, int A_2)
		{
			char[] array = new char[A_2];
			for (long num = 0L; num < (long)A_2; num += 1L)
			{
				checked
				{
					array[(int)((IntPtr)num)] = ab2.a(A_0[(int)((IntPtr)(unchecked(A_1 + num)))]);
				}
			}
			return new string(array);
		}

		// Token: 0x06002C9B RID: 11419 RVA: 0x00197610 File Offset: 0x00196610
		internal static char a(byte A_0)
		{
			if (A_0 >= 32)
			{
				if (A_0 <= 127 || A_0 >= 161)
				{
					return (char)A_0;
				}
				switch (A_0)
				{
				case 128:
					return '•';
				case 129:
					return '†';
				case 130:
					return '‡';
				case 131:
					return '…';
				case 132:
					return '—';
				case 133:
					return '–';
				case 134:
					return 'ƒ';
				case 135:
					return '⁄';
				case 136:
					return '‹';
				case 137:
					return '›';
				case 138:
					return '−';
				case 139:
					return '‰';
				case 140:
					return '„';
				case 141:
					return '“';
				case 142:
					return '”';
				case 143:
					return '‘';
				case 144:
					return '’';
				case 145:
					return '‚';
				case 146:
					return '™';
				case 147:
					return 'ﬁ';
				case 148:
					return 'ﬂ';
				case 149:
					return 'Ł';
				case 150:
					return 'Œ';
				case 151:
					return 'Š';
				case 152:
					return 'Ÿ';
				case 153:
					return 'Ž';
				case 154:
					return 'ı';
				case 155:
					return 'ł';
				case 156:
					return 'œ';
				case 157:
					return 'š';
				case 158:
					return 'ž';
				case 159:
					return '\u009f';
				case 160:
					return '€';
				}
			}
			else
			{
				if (A_0 <= 23)
				{
					return (char)A_0;
				}
				switch (A_0)
				{
				case 24:
					return '˘';
				case 25:
					return 'ˇ';
				case 26:
					return 'ˆ';
				case 27:
					return '˙';
				case 28:
					return '˝';
				case 29:
					return '˛';
				case 30:
					return '˚';
				case 31:
					return '˜';
				}
			}
			return '\0';
		}
	}
}
