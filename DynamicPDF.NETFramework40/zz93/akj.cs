using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200056B RID: 1387
	internal class akj
	{
		// Token: 0x06003742 RID: 14146 RVA: 0x001DE1AC File Offset: 0x001DD1AC
		internal char[] b(char[] A_0)
		{
			int num = 0;
			char[] array = new char[A_0.Length * 3];
			int num2 = -1;
			byte[] array2 = new byte[10];
			bool a_ = true;
			bool a_2 = true;
			int i = 0;
			while (i < A_0.Length)
			{
				char c = A_0[i];
				switch (c)
				{
				case ' ':
					break;
				case '!':
					goto IL_C6;
				case '"':
					do
					{
						array[num++] = A_0[i];
						i++;
					}
					while (A_0[i] != '"');
					array[num++] = A_0[i];
					i++;
					break;
				default:
					if (c != '[')
					{
						goto IL_C6;
					}
					while (A_0[i] != ']')
					{
						array[num++] = A_0[i];
						i++;
					}
					array[num++] = A_0[i];
					i++;
					break;
				}
				IL_2FF:
				i++;
				continue;
				IL_C6:
				if (akj.b(A_0[i]))
				{
					if (A_0[i] == '(')
					{
						if (num != 0 && this.a(array[num - 1]))
						{
							array[num++] = A_0[i];
							int num3 = 0;
							int num4 = i + 1;
							while (num3 != -1)
							{
								if (A_0[i] == '(')
								{
									num3++;
								}
								if (A_0[i] == ')')
								{
									num3--;
								}
								if (num3 == 0 || (num3 == 1 && A_0[i] == ','))
								{
									char[] array3 = new char[i - num4];
									Array.Copy(A_0, num4, array3, 0, i - num4);
									array3 = this.b(array3);
									Array.Copy(array3, 0, array, num, array3.Length);
									num += array3.Length;
									array[num++] = A_0[i];
									num4 = i + 1;
								}
								if (num3 == 0)
								{
									num3--;
								}
								i++;
							}
						}
					}
					array[++num] = ' ';
					int num5 = i;
					char a_3 = ' ';
					char a_4 = ' ';
					if (num5 + 1 < A_0.Length)
					{
						a_3 = A_0[num5];
						while (A_0[++num5] == ' ')
						{
							a_ = true;
						}
						a_4 = A_0[num5];
					}
					byte b = this.a(a_3, a_4, a_, a_2, ref i, num5);
					a_2 = true;
					if (b == 0)
					{
						a_2 = false;
					}
					if (b == 0)
					{
						while (array2[num2] != 141)
						{
							this.a(array, ref num, this.a(array2, ref num2));
						}
						this.a(array2, ref num2);
					}
					else
					{
						while (this.a(array2, num2, b))
						{
							this.a(array, ref num, this.a(array2, ref num2));
						}
						this.a(array2, ref num2, b);
					}
				}
				else
				{
					array[num++] = A_0[i];
					a_2 = false;
				}
				goto IL_2FF;
			}
			array[++num] = ' ';
			while (num2 != -1)
			{
				this.a(array, ref num, this.a(array2, ref num2));
			}
			return this.a(array);
		}

		// Token: 0x06003743 RID: 14147 RVA: 0x001DE508 File Offset: 0x001DD508
		internal static bool b(char A_0)
		{
			if (A_0 <= '>')
			{
				switch (A_0)
				{
				case '!':
					return true;
				case '"':
				case '#':
				case '$':
				case '\'':
				case ',':
				case '.':
					break;
				case '%':
					return true;
				case '&':
					return true;
				case '(':
					return true;
				case ')':
					return true;
				case '*':
					return true;
				case '+':
					return true;
				case '-':
					return true;
				case '/':
					return true;
				default:
					switch (A_0)
					{
					case '<':
						return true;
					case '=':
						return true;
					case '>':
						return true;
					}
					break;
				}
			}
			else
			{
				if (A_0 == '^')
				{
					return true;
				}
				switch (A_0)
				{
				case '|':
					return true;
				case '~':
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003744 RID: 14148 RVA: 0x001DE5D8 File Offset: 0x001DD5D8
		private bool a(char A_0)
		{
			return A_0 <= 'z' && (A_0 >= 'a' || (A_0 <= 'Z' && (A_0 >= 'A' || (A_0 <= '9' && A_0 >= '0'))));
		}

		// Token: 0x06003745 RID: 14149 RVA: 0x001DE644 File Offset: 0x001DD644
		private char[] a(char[] A_0)
		{
			int num = A_0.Length - 1;
			while (A_0[num] == '\0' || A_0[num] == ' ')
			{
				num--;
			}
			char[] array = new char[num + 1];
			Array.Copy(A_0, 0, array, 0, num + 1);
			return array;
		}

		// Token: 0x06003746 RID: 14150 RVA: 0x001DE690 File Offset: 0x001DD690
		private byte a(byte[] A_0, ref int A_1)
		{
			byte result = A_0[A_1];
			A_0[A_1] = 0;
			A_1--;
			return result;
		}

		// Token: 0x06003747 RID: 14151 RVA: 0x001DE6B3 File Offset: 0x001DD6B3
		private void a(byte[] A_0, ref int A_1, byte A_2)
		{
			A_1++;
			A_0[A_1] = A_2;
		}

		// Token: 0x06003748 RID: 14152 RVA: 0x001DE6C4 File Offset: 0x001DD6C4
		private bool a(byte[] A_0, int A_1, byte A_2)
		{
			return A_1 != -1 && A_2 != 141 && A_0[A_1] / 10 <= A_2 / 10;
		}

		// Token: 0x06003749 RID: 14153 RVA: 0x001DE708 File Offset: 0x001DD708
		private byte a(char A_0, char A_1, bool A_2, bool A_3, ref int A_4, int A_5)
		{
			if (A_0 <= '>')
			{
				switch (A_0)
				{
				case '!':
					if (A_1 == '=')
					{
						A_4 = A_5;
						return 72;
					}
					return 23;
				case '"':
				case '#':
				case '$':
				case '\'':
				case ',':
				case '.':
					break;
				case '%':
					return 33;
				case '&':
					return 81;
				case '(':
					return 141;
				case ')':
					return 0;
				case '*':
					return 31;
				case '+':
					if (A_1 == '+')
					{
						if (A_2)
						{
							return 41;
						}
						A_4 = A_5;
						return 25;
					}
					else
					{
						if (A_3)
						{
							return 21;
						}
						return 41;
					}
					break;
				case '-':
					if (A_1 == '-')
					{
						if (A_2)
						{
							return 42;
						}
						A_4 = A_5;
						return 26;
					}
					else
					{
						if (A_3)
						{
							return 22;
						}
						return 42;
					}
					break;
				case '/':
					return 32;
				default:
					switch (A_0)
					{
					case '<':
						if (A_1 == '=')
						{
							A_4 = A_5;
							return 63;
						}
						return 61;
					case '=':
						if (A_1 == '=')
						{
							A_4 = A_5;
							return 71;
						}
						throw new LayoutEngineException("Invalid expression for Equality Operator");
					case '>':
						if (A_1 == '=')
						{
							A_4 = A_5;
							return 64;
						}
						return 62;
					}
					break;
				}
			}
			else
			{
				if (A_0 == '^')
				{
					return 91;
				}
				switch (A_0)
				{
				case '|':
					return 101;
				case '~':
					return 24;
				}
			}
			return 161;
		}

		// Token: 0x0600374A RID: 14154 RVA: 0x001DE8EC File Offset: 0x001DD8EC
		private void a(char[] A_0, ref int A_1, byte A_2)
		{
			if (A_2 <= 64)
			{
				if (A_2 <= 33)
				{
					if (A_2 == 0)
					{
						return;
					}
					switch (A_2)
					{
					case 21:
						A_0[A_1] = '+';
						break;
					case 22:
						A_0[A_1] = '_';
						break;
					case 23:
						A_0[A_1] = '!';
						break;
					case 24:
						A_0[A_1] = '~';
						break;
					case 25:
						A_0[A_1] = '+';
						A_0[++A_1] = '+';
						break;
					case 26:
						A_0[A_1] = '-';
						A_0[++A_1] = '-';
						break;
					case 31:
						A_0[A_1] = '*';
						break;
					case 32:
						A_0[A_1] = '/';
						break;
					case 33:
						A_0[A_1] = '%';
						break;
					}
				}
				else
				{
					switch (A_2)
					{
					case 41:
						A_0[A_1] = '+';
						break;
					case 42:
						A_0[A_1] = '-';
						break;
					default:
						switch (A_2)
						{
						case 61:
							A_0[A_1] = '<';
							break;
						case 62:
							A_0[A_1] = '>';
							break;
						case 63:
							A_0[A_1] = '<';
							A_0[++A_1] = '=';
							break;
						case 64:
							A_0[A_1] = '>';
							A_0[++A_1] = '=';
							break;
						}
						break;
					}
				}
			}
			else if (A_2 <= 81)
			{
				switch (A_2)
				{
				case 71:
					A_0[A_1] = '=';
					A_0[++A_1] = '=';
					break;
				case 72:
					A_0[A_1] = '!';
					A_0[++A_1] = '=';
					break;
				default:
					if (A_2 == 81)
					{
						A_0[A_1] = '&';
					}
					break;
				}
			}
			else if (A_2 != 91)
			{
				if (A_2 == 101)
				{
					A_0[A_1] = '|';
				}
			}
			else
			{
				A_0[A_1] = '^';
			}
			A_0[++A_1] = ' ';
			A_1++;
		}
	}
}
