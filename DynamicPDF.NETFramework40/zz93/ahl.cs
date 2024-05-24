using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000500 RID: 1280
	internal class ahl
	{
		// Token: 0x06003418 RID: 13336 RVA: 0x001CE21C File Offset: 0x001CD21C
		internal ahl(char[] A_0, int A_1, char A_2)
		{
			this.a = A_0;
			int num = 0;
			this.h = A_1;
			this.i = A_2;
			int i;
			for (i = 1; i < A_0.Length; i++)
			{
				if (A_0[i] == '%' && A_0[i - 1] == '%')
				{
					if (i + 1 < A_0.Length && A_0[i + 1] == '%')
					{
						this.b.Add(new ahk(num, i - num));
						i++;
						num = i;
					}
					else if (i + 4 < A_0.Length && A_0[i + 1] == 'C' && A_0[i + 2] == 'P')
					{
						if (A_0[i + 3] == '%' && A_0[i + 4] == '%')
						{
							if (this.i == ' ')
							{
								this.i = '0';
							}
							this.b.Add(new ahk(num, i - num - 1, NumberingType.Numeric, ahj.a, this.h, this.i));
							i += 5;
							num = i;
						}
						else if (A_0[i + 3] == '(' && A_0[i + 5] == ')' && A_0[i + 6] == '%' && A_0[i + 7] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, A_0[i + 4], ahj.a, this.h, this.i));
							this.a(A_0[i + 4]);
							i += 8;
							num = i;
						}
						else if (A_0[i + 3] == '(')
						{
							int num2 = i;
							this.a(ref A_0, ref this.i, ref num2);
							this.b.Add(new ahk(num, i - num - 1, this.j, ahj.a, this.h, this.i));
							num = num2;
						}
					}
					else if (i + 4 < A_0.Length && A_0[i + 1] == 'T' && A_0[i + 2] == 'P')
					{
						if (A_0[i + 3] == '%' && A_0[i + 4] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, NumberingType.Numeric, ahj.b));
							i += 5;
							num = i;
						}
						else if (A_0[i + 3] == '(' && A_0[i + 5] == ')' && A_0[i + 6] == '%' && A_0[i + 7] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, A_0[i + 4], ahj.b));
							this.a(A_0[i + 4]);
							i += 8;
							num = i;
						}
						else if (A_0[i + 3] == '(')
						{
							int num2 = i;
							this.a(ref A_0, ref this.i, ref num2);
							this.b.Add(new ahk(num, i - num - 1, this.j, ahj.b, this.h, this.i));
							num = num2;
						}
					}
					else if (i + 4 < A_0.Length && A_0[i + 2] == 'P' && A_0[i + 1] == 'S')
					{
						if (A_0[i + 3] == '%' && A_0[i + 4] == '%')
						{
							if (this.i == ' ')
							{
								this.i = '0';
							}
							this.b.Add(new ahk(num, i - num - 1, NumberingType.None, ahj.c, this.h, this.i));
							i += 5;
							num = i;
						}
						else if (A_0[i + 3] == '(' && A_0[i + 5] == ')' && A_0[i + 6] == '%' && A_0[i + 7] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, A_0[i + 4], ahj.c, this.h, this.i));
							this.a(A_0[i + 4]);
							i += 8;
							num = i;
						}
						else if (A_0[i + 3] == '(')
						{
							int num2 = i;
							this.a(ref A_0, ref this.i, ref num2);
							this.b.Add(new ahk(num, i - num - 1, this.j, ahj.c, this.h, this.i));
							num = num2;
						}
					}
					else if (i + 4 < A_0.Length && A_0[i + 2] == 'T' && A_0[i + 1] == 'S')
					{
						if (A_0[i + 3] == '%' && A_0[i + 4] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, NumberingType.None, ahj.d));
							i += 5;
							num = i;
							this.d = true;
						}
						else if (A_0[i + 3] == '(' && A_0[i + 5] == ')' && A_0[i + 6] == '%' && A_0[i + 7] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, A_0[i + 4], ahj.d));
							this.a(A_0[i + 4]);
							i += 8;
							num = i;
							this.d = true;
						}
						else if (A_0[i + 3] == '(')
						{
							int num2 = i;
							this.a(ref A_0, ref this.i, ref num2);
							this.b.Add(new ahk(num, i - num - 1, this.j, ahj.d, this.h, this.i));
							num = num2;
						}
					}
					else if (i + 4 < A_0.Length && A_0[i + 1] == 'P' && A_0[i + 2] == 'R')
					{
						if (A_0[i + 3] == '%' && A_0[i + 4] == '%')
						{
							this.b.Add(new ahk(num, i - num - 1, NumberingType.None, ahj.e));
							i += 5;
							num = i;
							this.e++;
						}
					}
				}
			}
			if (num < A_0.Length)
			{
				this.b.Add(new ahk(num, i - num));
			}
			this.c += A_0.Length;
		}

		// Token: 0x06003419 RID: 13337 RVA: 0x001CE8F0 File Offset: 0x001CD8F0
		internal bool a()
		{
			return this.d;
		}

		// Token: 0x0600341A RID: 13338 RVA: 0x001CE908 File Offset: 0x001CD908
		private void a(ref char[] A_0, ref char A_1, ref int A_2)
		{
			this.g = string.Empty;
			this.i = A_1;
			A_2 += 4;
			this.j = A_0[A_2];
			A_2 += 2;
			while (A_0[A_2] != ')' && A_0[A_2] != ',')
			{
				this.g += A_0[A_2].ToString();
				A_2++;
			}
			this.h = Convert.ToInt32(this.g);
			A_2++;
			if (A_0[A_2] == '\'' && A_0[A_2 + 1] == '\'' && A_0[A_2 + 2] == ')')
			{
				this.h = 0;
				A_2 += 2;
			}
			if (A_0[A_2] == '\'' && A_0[A_2 + 2] == '\'')
			{
				this.i = A_0[A_2 + 1];
				A_2 += 3;
			}
			if (A_0[A_2] == ')')
			{
				A_2++;
			}
			if (A_0[A_2] == '%' && A_0[A_2 + 1] == '%')
			{
				A_2 += 2;
			}
		}

		// Token: 0x0600341B RID: 13339 RVA: 0x001CEA50 File Offset: 0x001CDA50
		private void a(char A_0)
		{
			if (A_0 <= 'I')
			{
				if (A_0 != 'A')
				{
					if (A_0 == 'I')
					{
						this.c += 6;
					}
				}
				else
				{
					this.c += 2;
				}
			}
			else if (A_0 != 'a')
			{
				if (A_0 == 'i')
				{
					this.c += 6;
				}
			}
			else
			{
				this.c += 2;
			}
		}

		// Token: 0x0600341C RID: 13340 RVA: 0x001CEAC0 File Offset: 0x001CDAC0
		internal char[] a(Section A_0, ref int A_1, int A_2, int A_3, int A_4)
		{
			return this.a(A_0, ref A_1, A_2, A_3, A_4, A_3);
		}

		// Token: 0x0600341D RID: 13341 RVA: 0x001CEAE4 File Offset: 0x001CDAE4
		internal char[] a(Section A_0, ref int A_1, int A_2, int A_3, int A_4, int A_5)
		{
			int num = 0;
			int num2 = 0;
			char a_ = '0';
			char a_2 = '0';
			int num3 = 0;
			if (A_0 != null)
			{
				num3 = A_0.Prefix.Length * this.e;
			}
			char[] array = new char[this.c + num3];
			int num4 = 0;
			foreach (object obj in this.b)
			{
				ahk ahk = (ahk)obj;
				Array.Copy(this.a, ahk.a, array, num4, ahk.b);
				num4 += ahk.b;
				char[] array2 = null;
				switch (ahk.d)
				{
				case ahj.a:
					this.f = new ae6(ahk.c);
					array2 = this.f.h(A_2, ahk.e, ahk.f);
					break;
				case ahj.b:
					this.f = new ae6(ahk.c);
					array2 = this.f.h(A_3, ahk.e, ahk.f);
					break;
				case ahj.c:
				{
					NumberingType numberingType = ahk.c;
					if (numberingType == NumberingType.None)
					{
						if (A_0 == null)
						{
							numberingType = NumberingType.Numeric;
						}
						else
						{
							numberingType = this.a(A_0.NumberingStyle);
						}
					}
					this.f = new ae6(numberingType);
					if (num != 0)
					{
						array2 = this.f.h(A_4, num, a_);
					}
					else
					{
						array2 = this.f.h(A_4, ahk.e, ahk.f);
					}
					break;
				}
				case ahj.d:
				{
					NumberingType numberingType2 = ahk.c;
					if (numberingType2 == NumberingType.None)
					{
						if (A_0 == null)
						{
							numberingType2 = NumberingType.Numeric;
						}
						else
						{
							numberingType2 = this.a(A_0.NumberingStyle);
						}
					}
					this.f = new ae6(numberingType2);
					if (num2 != 0)
					{
						array2 = this.f.h(A_5, num2, a_2);
					}
					else
					{
						array2 = this.f.h(A_5, ahk.e, ahk.f);
					}
					break;
				}
				case ahj.e:
					if (A_0 != null)
					{
						char[] array3 = A_0.Prefix.ToCharArray();
						Array.Copy(array3, 0, array, num4, array3.Length);
						num4 += array3.Length;
					}
					break;
				}
				if (array2 != null)
				{
					if (array2.Length + num4 > array.Length)
					{
						char[] array4 = new char[array2.Length + num4];
						Array.Copy(array, 0, array4, 0, array.Length);
						array = array4;
						this.c = array.Length;
					}
					Array.Copy(array2, 0, array, num4, array2.Length);
					num4 += array2.Length;
				}
			}
			A_1 = num4;
			return array;
		}

		// Token: 0x0600341E RID: 13342 RVA: 0x001CEE18 File Offset: 0x001CDE18
		private NumberingType a(NumberingStyle A_0)
		{
			NumberingType result;
			switch (A_0)
			{
			case NumberingStyle.AlphabeticLowerCase:
				result = NumberingType.AlphabeticLowerCase;
				break;
			case NumberingStyle.AlphabeticUpperCase:
				result = NumberingType.AlphabeticUpperCase;
				break;
			case NumberingStyle.RomanLowerCase:
				result = NumberingType.RomanLowerCase;
				break;
			case NumberingStyle.RomanUpperCase:
				result = NumberingType.RomanUpperCase;
				break;
			default:
				result = NumberingType.Numeric;
				break;
			}
			return result;
		}

		// Token: 0x0400193A RID: 6458
		private char[] a;

		// Token: 0x0400193B RID: 6459
		private ArrayList b = new ArrayList();

		// Token: 0x0400193C RID: 6460
		private int c = 0;

		// Token: 0x0400193D RID: 6461
		private bool d = false;

		// Token: 0x0400193E RID: 6462
		private int e = 0;

		// Token: 0x0400193F RID: 6463
		private ae6 f = null;

		// Token: 0x04001940 RID: 6464
		private string g;

		// Token: 0x04001941 RID: 6465
		private int h = 0;

		// Token: 0x04001942 RID: 6466
		private char i;

		// Token: 0x04001943 RID: 6467
		private char j = '\0';
	}
}
