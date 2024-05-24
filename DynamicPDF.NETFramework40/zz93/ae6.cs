using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020004A7 RID: 1191
	internal class ae6
	{
		// Token: 0x06003148 RID: 12616 RVA: 0x001BA2D0 File Offset: 0x001B92D0
		internal ae6(NumberingStyle A_0)
		{
			this.b = A_0;
			this.a = 0;
		}

		// Token: 0x06003149 RID: 12617 RVA: 0x001BA2F0 File Offset: 0x001B92F0
		internal ae6(NumberingType A_0)
		{
			this.c = A_0;
			this.a = 0;
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x001BA310 File Offset: 0x001B9310
		internal ae6(ok A_0)
		{
			this.d = A_0;
			this.e = true;
			this.a = 0;
		}

		// Token: 0x0600314B RID: 12619 RVA: 0x001BA337 File Offset: 0x001B9337
		public void s(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600314C RID: 12620 RVA: 0x001BA344 File Offset: 0x001B9344
		private char[] g(int A_0, int A_1, char A_2)
		{
			return A_0.ToString().PadLeft(A_1, A_2).ToCharArray();
		}

		// Token: 0x0600314D RID: 12621 RVA: 0x001BA36C File Offset: 0x001B936C
		private char[] f(int A_0, int A_1, char A_2)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else if (A_0 > 3999)
			{
				result = "[!i>3999]".ToCharArray();
			}
			else
			{
				int a_ = A_0 / 1000;
				A_0 %= 1000;
				int a_2 = A_0 / 100;
				A_0 %= 100;
				int a_3 = A_0 / 10;
				int a_4 = A_0 % 10;
				result = (this.k(a_) + this.j(a_2) + this.i(a_3) + this.h(a_4)).PadLeft(A_1, A_2).ToCharArray();
			}
			return result;
		}

		// Token: 0x0600314E RID: 12622 RVA: 0x001BA40C File Offset: 0x001B940C
		private char[] e(int A_0, int A_1, char A_2)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else if (A_0 > 3999)
			{
				result = "[!i>3999]".ToCharArray();
			}
			else
			{
				int a_ = A_0 / 1000;
				A_0 %= 1000;
				int a_2 = A_0 / 100;
				A_0 %= 100;
				int a_3 = A_0 / 10;
				int a_4 = A_0 % 10;
				result = (this.p(a_) + this.o(a_2) + this.n(a_3) + this.m(a_4)).PadLeft(A_1, A_2).ToCharArray();
			}
			return result;
		}

		// Token: 0x0600314F RID: 12623 RVA: 0x001BA4AC File Offset: 0x001B94AC
		private char[] d(int A_0, int A_1, char A_2)
		{
			char[] result;
			if (A_0 > 260)
			{
				result = "[!A>260]".ToCharArray();
			}
			else if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				A_0--;
				char[] array = new char[A_0 / 26 + 1];
				char c = (char)(A_0 % 26 + 65);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = c;
				}
				string text = new string(array);
				result = text.PadLeft(A_1, A_2).ToCharArray();
			}
			return result;
		}

		// Token: 0x06003150 RID: 12624 RVA: 0x001BA540 File Offset: 0x001B9540
		private char[] c(int A_0, int A_1, char A_2)
		{
			char[] result;
			if (A_0 > 260)
			{
				result = "[!a>260]".ToCharArray();
			}
			else if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				A_0--;
				char[] array = new char[A_0 / 26 + 1];
				char c = (char)(A_0 % 26 + 97);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = c;
				}
				string text = new string(array);
				result = text.PadLeft(A_1, A_2).ToCharArray();
			}
			return result;
		}

		// Token: 0x06003151 RID: 12625 RVA: 0x001BA5D4 File Offset: 0x001B95D4
		private char[] b(int A_0, int A_1, char A_2)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				char[] array;
				if (A_0 <= 26)
				{
					array = new char[1];
				}
				else if (A_0 <= 702)
				{
					array = new char[2];
				}
				else
				{
					if (A_0 > 18278)
					{
						return "[!B>18278]".ToCharArray();
					}
					array = new char[3];
				}
				for (int i = array.Length - 1; i >= 0; i--)
				{
					array[i] = (char)(A_0 % 26 + 64);
					if (array[i] == '@')
					{
						array[i] = 'Z';
					}
					A_0 = (A_0 - 1) / 26;
				}
				string text = new string(array);
				result = text.PadLeft(A_1, A_2).ToCharArray();
			}
			return result;
		}

		// Token: 0x06003152 RID: 12626 RVA: 0x001BA6A8 File Offset: 0x001B96A8
		private char[] a(int A_0, int A_1, char A_2)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				char[] array;
				if (A_0 <= 26)
				{
					array = new char[1];
				}
				else if (A_0 <= 702)
				{
					array = new char[2];
				}
				else
				{
					if (A_0 > 18278)
					{
						return "[!b>18278]".ToCharArray();
					}
					array = new char[3];
				}
				for (int i = array.Length - 1; i >= 0; i--)
				{
					array[i] = (char)(A_0 % 26 + 96);
					if (array[i] == '`')
					{
						array[i] = 'z';
					}
					A_0 = (A_0 - 1) / 26;
				}
				string text = new string(array);
				result = text.PadLeft(A_1, A_2).ToCharArray();
			}
			return result;
		}

		// Token: 0x06003153 RID: 12627 RVA: 0x001BA77C File Offset: 0x001B977C
		private char[] r(int A_0)
		{
			if (this.d == ok.j)
			{
				if (A_0 >= -9 && A_0 <= 9)
				{
					char[] result;
					if (A_0 < 0)
					{
						result = new char[]
						{
							'-',
							'0',
							(char)(48 - A_0)
						};
					}
					else
					{
						result = new char[]
						{
							'0',
							(char)(48 + A_0)
						};
					}
					return result;
				}
			}
			return A_0.ToString().ToCharArray();
		}

		// Token: 0x06003154 RID: 12628 RVA: 0x001BA804 File Offset: 0x001B9804
		private char[] q(int A_0)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else if (A_0 > 3999)
			{
				result = "[!i>3999]".ToCharArray();
			}
			else
			{
				int a_ = A_0 / 1000;
				A_0 %= 1000;
				int a_2 = A_0 / 100;
				A_0 %= 100;
				int a_3 = A_0 / 10;
				int a_4 = A_0 % 10;
				result = (this.p(a_) + this.o(a_2) + this.n(a_3) + this.m(a_4)).ToCharArray();
			}
			return result;
		}

		// Token: 0x06003155 RID: 12629 RVA: 0x001BA89C File Offset: 0x001B989C
		private string p(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "m";
				break;
			case 2:
				result = "mm";
				break;
			case 3:
				result = "mmm";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06003156 RID: 12630 RVA: 0x001BA8F0 File Offset: 0x001B98F0
		private string o(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "c";
				break;
			case 2:
				result = "cc";
				break;
			case 3:
				result = "ccc";
				break;
			case 4:
				result = "cd";
				break;
			case 5:
				result = "d";
				break;
			case 6:
				result = "dc";
				break;
			case 7:
				result = "dcc";
				break;
			case 8:
				result = "dccc";
				break;
			case 9:
				result = "cm";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06003157 RID: 12631 RVA: 0x001BA98C File Offset: 0x001B998C
		private string n(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "x";
				break;
			case 2:
				result = "xx";
				break;
			case 3:
				result = "xxx";
				break;
			case 4:
				result = "xl";
				break;
			case 5:
				result = "l";
				break;
			case 6:
				result = "lx";
				break;
			case 7:
				result = "lxx";
				break;
			case 8:
				result = "lxxx";
				break;
			case 9:
				result = "xc";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06003158 RID: 12632 RVA: 0x001BAA28 File Offset: 0x001B9A28
		private string m(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "i";
				break;
			case 2:
				result = "ii";
				break;
			case 3:
				result = "iii";
				break;
			case 4:
				result = "iv";
				break;
			case 5:
				result = "v";
				break;
			case 6:
				result = "vi";
				break;
			case 7:
				result = "vii";
				break;
			case 8:
				result = "viii";
				break;
			case 9:
				result = "ix";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06003159 RID: 12633 RVA: 0x001BAAC4 File Offset: 0x001B9AC4
		private char[] l(int A_0)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else if (A_0 > 3999)
			{
				result = "[!i>3999]".ToCharArray();
			}
			else
			{
				int a_ = A_0 / 1000;
				A_0 %= 1000;
				int a_2 = A_0 / 100;
				A_0 %= 100;
				int a_3 = A_0 / 10;
				int a_4 = A_0 % 10;
				result = (this.k(a_) + this.j(a_2) + this.i(a_3) + this.h(a_4)).ToCharArray();
			}
			return result;
		}

		// Token: 0x0600315A RID: 12634 RVA: 0x001BAB5C File Offset: 0x001B9B5C
		private string k(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "M";
				break;
			case 2:
				result = "MM";
				break;
			case 3:
				result = "MMM";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x0600315B RID: 12635 RVA: 0x001BABB0 File Offset: 0x001B9BB0
		private string j(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "C";
				break;
			case 2:
				result = "CC";
				break;
			case 3:
				result = "CCC";
				break;
			case 4:
				result = "CD";
				break;
			case 5:
				result = "D";
				break;
			case 6:
				result = "DC";
				break;
			case 7:
				result = "DCC";
				break;
			case 8:
				result = "DCCC";
				break;
			case 9:
				result = "CM";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x0600315C RID: 12636 RVA: 0x001BAC4C File Offset: 0x001B9C4C
		private string i(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "X";
				break;
			case 2:
				result = "XX";
				break;
			case 3:
				result = "XXX";
				break;
			case 4:
				result = "XL";
				break;
			case 5:
				result = "L";
				break;
			case 6:
				result = "LX";
				break;
			case 7:
				result = "LXX";
				break;
			case 8:
				result = "LXXX";
				break;
			case 9:
				result = "XC";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x0600315D RID: 12637 RVA: 0x001BACE8 File Offset: 0x001B9CE8
		private string h(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "I";
				break;
			case 2:
				result = "II";
				break;
			case 3:
				result = "III";
				break;
			case 4:
				result = "IV";
				break;
			case 5:
				result = "V";
				break;
			case 6:
				result = "VI";
				break;
			case 7:
				result = "VII";
				break;
			case 8:
				result = "VIII";
				break;
			case 9:
				result = "IX";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x0600315E RID: 12638 RVA: 0x001BAD84 File Offset: 0x001B9D84
		private char[] g(int A_0)
		{
			char[] result;
			if (A_0 > 260)
			{
				result = "[!A>260]".ToCharArray();
			}
			else if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				A_0--;
				char[] array = new char[A_0 / 26 + 1];
				char c = (char)(A_0 % 26 + 65);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = c;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x0600315F RID: 12639 RVA: 0x001BAE00 File Offset: 0x001B9E00
		private char[] f(int A_0)
		{
			char[] result;
			if (A_0 > 260)
			{
				result = "[!a>260]".ToCharArray();
			}
			else if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				A_0--;
				char[] array = new char[A_0 / 26 + 1];
				char c = (char)(A_0 % 26 + 97);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = c;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x06003160 RID: 12640 RVA: 0x001BAE7C File Offset: 0x001B9E7C
		private char[] e(int A_0)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				char[] array;
				if (A_0 <= 26)
				{
					array = new char[1];
				}
				else if (A_0 <= 702)
				{
					array = new char[2];
				}
				else
				{
					if (A_0 > 18278)
					{
						return "[!B>18278]".ToCharArray();
					}
					array = new char[3];
				}
				for (int i = array.Length - 1; i >= 0; i--)
				{
					array[i] = (char)(A_0 % 26 + 64);
					if (array[i] == '@')
					{
						array[i] = 'Z';
					}
					A_0 = (A_0 - 1) / 26;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x06003161 RID: 12641 RVA: 0x001BAF30 File Offset: 0x001B9F30
		private char[] d(int A_0)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else
			{
				char[] array;
				if (A_0 <= 26)
				{
					array = new char[1];
				}
				else if (A_0 <= 702)
				{
					array = new char[2];
				}
				else
				{
					if (A_0 > 18278)
					{
						return "[!b>18278]".ToCharArray();
					}
					array = new char[3];
				}
				for (int i = array.Length - 1; i >= 0; i--)
				{
					array[i] = (char)(A_0 % 26 + 96);
					if (array[i] == '`')
					{
						array[i] = 'z';
					}
					A_0 = (A_0 - 1) / 26;
				}
				result = array;
			}
			return result;
		}

		// Token: 0x06003162 RID: 12642 RVA: 0x001BAFE4 File Offset: 0x001B9FE4
		private char[] c(int A_0)
		{
			char[] result;
			if (A_0 == 0)
			{
				result = new char[0];
			}
			else if (A_0 > 3999)
			{
				result = "[!i>3999]".ToCharArray();
			}
			else
			{
				int a_ = 0;
				int num = A_0 / 24;
				int num2 = A_0 % 24;
				if (A_0 > 600)
				{
					a_ = A_0 / 600;
					num %= 24;
				}
				if (num >= 1 && num2 == 0)
				{
					num--;
					num2 = 24;
				}
				result = (this.b(a_) + this.b(num) + this.b(num2)).ToCharArray();
			}
			return result;
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x001BB098 File Offset: 0x001BA098
		private string b(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "a";
				break;
			case 2:
				result = "b";
				break;
			case 3:
				result = "g";
				break;
			case 4:
				result = "d";
				break;
			case 5:
				result = "e";
				break;
			case 6:
				result = "z";
				break;
			case 7:
				result = "h";
				break;
			case 8:
				result = "q";
				break;
			case 9:
				result = "i";
				break;
			case 10:
				result = "k";
				break;
			case 11:
				result = "l";
				break;
			case 12:
				result = "m";
				break;
			case 13:
				result = "n";
				break;
			case 14:
				result = "x";
				break;
			case 15:
				result = "o";
				break;
			case 16:
				result = "p";
				break;
			case 17:
				result = "r";
				break;
			case 18:
				result = "s";
				break;
			case 19:
				result = "t";
				break;
			case 20:
				result = "u";
				break;
			case 21:
				result = "f";
				break;
			case 22:
				result = "c";
				break;
			case 23:
				result = "y";
				break;
			case 24:
				result = "w";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06003164 RID: 12644 RVA: 0x001BB208 File Offset: 0x001BA208
		private string a(int A_0)
		{
			string result;
			switch (A_0)
			{
			case 0:
				result = string.Empty;
				break;
			case 1:
				result = "aa";
				break;
			case 2:
				result = "bb";
				break;
			case 3:
				result = "gg";
				break;
			case 4:
				result = "dd";
				break;
			case 5:
				result = "ee";
				break;
			case 6:
				result = "zz";
				break;
			case 7:
				result = "hh";
				break;
			case 8:
				result = "qq";
				break;
			case 9:
				result = "ii";
				break;
			case 10:
				result = "kk";
				break;
			case 11:
				result = "ll";
				break;
			case 12:
				result = "mm";
				break;
			case 13:
				result = "nn";
				break;
			case 14:
				result = "xx";
				break;
			case 15:
				result = "oo";
				break;
			case 16:
				result = "pp";
				break;
			case 17:
				result = "rr";
				break;
			case 18:
				result = "ss";
				break;
			case 19:
				result = "tt";
				break;
			case 20:
				result = "uu";
				break;
			case 21:
				result = "ff";
				break;
			case 22:
				result = "cc";
				break;
			case 23:
				result = "yy";
				break;
			case 24:
				result = "ww";
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x06003165 RID: 12645 RVA: 0x001BB378 File Offset: 0x001BA378
		public char[] a()
		{
			this.a++;
			char[] result;
			switch (this.b)
			{
			case NumberingStyle.Numeric:
				result = this.r(this.a);
				break;
			case NumberingStyle.AlphabeticLowerCase:
				result = this.f(this.a);
				break;
			case NumberingStyle.AlphabeticUpperCase:
				result = this.g(this.a);
				break;
			case NumberingStyle.RomanLowerCase:
				result = this.q(this.a);
				break;
			case NumberingStyle.RomanUpperCase:
				result = this.l(this.a);
				break;
			default:
				result = new char[0];
				break;
			}
			return result;
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x001BB40C File Offset: 0x001BA40C
		public char[] h(int A_0, int A_1, char A_2)
		{
			this.a = A_0;
			char[] result;
			switch (this.c)
			{
			case NumberingType.Numeric:
				result = this.g(this.a, A_1, A_2);
				break;
			case NumberingType.AlphabeticLowerCase:
				result = this.c(this.a, A_1, A_2);
				break;
			case NumberingType.AlphabeticUpperCase:
				result = this.d(this.a, A_1, A_2);
				break;
			case NumberingType.ShortenedAlphabeticLowerCase:
				result = this.a(this.a, A_1, A_2);
				break;
			case NumberingType.ShortenedAlphabeticUpperCase:
				result = this.b(this.a, A_1, A_2);
				break;
			case NumberingType.RomanLowerCase:
				result = this.e(this.a, A_1, A_2);
				break;
			case NumberingType.RomanUpperCase:
				result = this.f(this.a, A_1, A_2);
				break;
			default:
				result = new char[0];
				break;
			}
			return result;
		}

		// Token: 0x06003167 RID: 12647 RVA: 0x001BB4D0 File Offset: 0x001BA4D0
		internal char[] t(int A_0)
		{
			this.a = A_0;
			if (!this.e)
			{
				switch (this.c)
				{
				case NumberingType.Numeric:
					return this.r(this.a);
				case NumberingType.AlphabeticLowerCase:
					return this.f(this.a);
				case NumberingType.AlphabeticUpperCase:
					return this.g(this.a);
				case NumberingType.ShortenedAlphabeticLowerCase:
					return this.d(this.a);
				case NumberingType.ShortenedAlphabeticUpperCase:
					return this.e(this.a);
				case NumberingType.RomanLowerCase:
					return this.q(this.a);
				case NumberingType.RomanUpperCase:
					return this.l(this.a);
				}
			}
			else
			{
				switch (this.d)
				{
				case ok.a:
					return this.e(this.a);
				case ok.b:
					return this.d(this.a);
				case ok.c:
					return this.l(this.a);
				case ok.d:
					return this.q(this.a);
				case ok.e:
				case ok.j:
					return this.r(this.a);
				case ok.i:
					return this.r(this.a);
				case ok.k:
					return this.c(this.a);
				case ok.l:
					return this.f(this.a);
				case ok.m:
					return this.g(this.a);
				}
			}
			return new char[0];
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x001BB680 File Offset: 0x001BA680
		internal ok b()
		{
			return this.d;
		}

		// Token: 0x06003169 RID: 12649 RVA: 0x001BB698 File Offset: 0x001BA698
		internal void a(ok A_0)
		{
			this.d = A_0;
		}

		// Token: 0x04001701 RID: 5889
		private int a;

		// Token: 0x04001702 RID: 5890
		private NumberingStyle b;

		// Token: 0x04001703 RID: 5891
		private NumberingType c;

		// Token: 0x04001704 RID: 5892
		private ok d;

		// Token: 0x04001705 RID: 5893
		private bool e = false;
	}
}
