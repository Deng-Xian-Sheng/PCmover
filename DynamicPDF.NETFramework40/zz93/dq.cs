using System;
using System.Collections;

namespace zz93
{
	// Token: 0x020000A3 RID: 163
	internal class dq
	{
		// Token: 0x060007C3 RID: 1987 RVA: 0x0006F644 File Offset: 0x0006E644
		internal dq(string A_0, float A_1, float A_2, int A_3, bool A_4, bool A_5, bool A_6)
		{
			this.f = A_0;
			this.d = A_1;
			this.a = A_2;
			this.i = A_3;
			this.g = A_4;
			this.h = A_5;
			this.m = A_6;
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0006F6CC File Offset: 0x0006E6CC
		internal dq(string A_0, float A_1, int A_2, bool A_3, bool A_4, bool A_5)
		{
			this.f = A_0;
			this.i = A_2;
			this.g = A_3;
			this.h = A_4;
			this.a = A_1;
			this.m = A_5;
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0006F74C File Offset: 0x0006E74C
		internal int d()
		{
			return this.k;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0006F764 File Offset: 0x0006E764
		internal float e()
		{
			return this.e;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0006F77C File Offset: 0x0006E77C
		internal static string a(string A_0)
		{
			if (A_0.Length > 14)
			{
				throw new ap("Invalid EAN-14/GTIN-14 character, allows only 13 or 14 digits.");
			}
			foreach (char c in A_0)
			{
				if (c < '0' && c > '9')
				{
					throw new ap("Invalid EAN-14/GTIN-14 character, allows only digits.");
				}
			}
			while (A_0.Length < 13)
			{
				A_0 = "0" + A_0;
			}
			if (A_0.Length != 14)
			{
				int num = 0;
				for (int j = A_0.Length - 1; j >= 0; j--)
				{
					if (j % 2 == 0)
					{
						num += int.Parse(A_0[j].ToString()) * 3;
					}
					else
					{
						num += int.Parse(A_0[j].ToString());
					}
				}
				A_0 += ((num % 10 > 0) ? (10 - num % 10) : 0).ToString();
			}
			return "(01)" + A_0;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0006F8C0 File Offset: 0x0006E8C0
		internal BitArray f()
		{
			if (!this.c())
			{
				throw new ap("Invalid character for Code128 barcode.");
			}
			this.l = true;
			byte[] array = this.a();
			this.n = this.a(array);
			this.e = this.d;
			int num = 1;
			ar ar = this.c(array, 0);
			int num2 = (int)ar;
			int i = 0;
			this.j = new BitArray(this.b(), true);
			this.l = true;
			if (this.g)
			{
				if (ar == ar.c)
				{
					num2 = 104;
					this.b(ar.b, ref this.e);
					if (this.h)
					{
						this.b(102, ref this.e);
						num2 += 102 * num++;
					}
					this.b(97, ref this.e);
					num2 += 97 * num++;
					this.a(ar, ref this.e);
					num2 = (int)(num2 + ((ar)204 - (int)ar) * (ar)(num++));
				}
				else
				{
					this.b(ar, ref this.e);
					if (this.h)
					{
						this.b(102, ref this.e);
						num2 += 102 * num++;
					}
					this.b(97, ref this.e);
					num2 += 97 * num++;
				}
			}
			else
			{
				this.b(ar, ref this.e);
				if (this.h)
				{
					this.b(102, ref this.e);
					num2 += 102 * num++;
				}
			}
			while (i < array.Length)
			{
				if (i != 0)
				{
					this.a(ar, ref this.e);
					num2 = (int)(num2 + ((ar)204 - (int)ar) * (ar)(num++));
				}
				switch (ar)
				{
				case ar.a:
					ar = this.c(array, ref i, ref num, ref this.e, ref num2);
					break;
				case ar.b:
					ar = this.b(array, ref i, ref num, ref this.e, ref num2);
					break;
				default:
					ar = this.a(array, ref i, ref num, ref this.e, ref num2);
					break;
				}
			}
			this.b((byte)(num2 % 103), ref this.e);
			this.a(2, ref this.e);
			this.a(3, ref this.e);
			this.a(3, ref this.e);
			this.a(1, ref this.e);
			this.a(1, ref this.e);
			this.a(1, ref this.e);
			this.a(2, ref this.e);
			return this.j;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0006FB80 File Offset: 0x0006EB80
		internal float g()
		{
			return (float)this.b() * this.a;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0006FBA0 File Offset: 0x0006EBA0
		private bool c()
		{
			for (int i = 0; i < this.f.Length; i++)
			{
				if (this.f[i] > '\u0080')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0006FBF0 File Offset: 0x0006EBF0
		private int b()
		{
			int i = 0;
			int num = 1;
			byte[] array = this.a();
			if (this.h)
			{
				num++;
			}
			ar ar = this.c(array, 0);
			if (this.g)
			{
				if (ar == ar.c)
				{
					num += 2;
				}
				else
				{
					num++;
				}
			}
			while (i < array.Length)
			{
				if (i != 0)
				{
					num++;
				}
				switch (ar)
				{
				case ar.a:
					ar = this.c(array, ref i, ref num);
					break;
				case ar.b:
					ar = this.b(array, ref i, ref num);
					break;
				default:
					ar = this.a(array, ref i, ref num);
					break;
				}
			}
			num += 2;
			num *= 11;
			num += 2;
			return num;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0006FCC4 File Offset: 0x0006ECC4
		private ar c(byte[] A_0, ref int A_1, ref int A_2)
		{
			while (A_1 < A_0.Length)
			{
				if (A_0[A_1] < 128)
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 65)
					{
						A_1 += 2;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 66)
					{
						result = ar.b;
					}
					else if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 67)
					{
						result = ar.c;
					}
					else if (A_0[A_1] > 95)
					{
						result = ar.b;
					}
					else
					{
						if (A_0[A_1] < 48 || A_0[A_1] > 57 || !dq.a(A_0, A_1) || this.n)
						{
							goto IL_15B;
						}
						result = ar.c;
					}
					return result;
				}
				IL_15B:
				A_1++;
				A_2++;
				this.o = false;
			}
			return ar.b;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0006FE54 File Offset: 0x0006EE54
		private ar b(byte[] A_0, ref int A_1, ref int A_2)
		{
			while (A_1 < A_0.Length)
			{
				if (A_0[A_1] < 128)
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 65)
					{
						result = ar.a;
					}
					else
					{
						if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 66)
						{
							A_1 += 2;
							continue;
						}
						if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 67)
						{
							result = ar.c;
						}
						else
						{
							byte b = dq.q[(int)A_0[A_1]];
							if (b == 255)
							{
								result = ar.a;
							}
							else
							{
								if (b < 16 || b > 25 || !dq.a(A_0, A_1) || this.n)
								{
									goto IL_162;
								}
								result = ar.c;
							}
						}
					}
					return result;
				}
				IL_162:
				A_1++;
				A_2++;
				this.o = false;
			}
			return ar.a;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0006FFEC File Offset: 0x0006EFEC
		private ar a(byte[] A_0, ref int A_1, ref int A_2)
		{
			while (A_1 < A_0.Length - 1)
			{
				if (A_0[A_1] < 128)
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 65)
					{
						result = ar.a;
					}
					else if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 66)
					{
						result = ar.b;
					}
					else
					{
						if (!this.o && this.n && A_0[A_1] == 126 && A_1 + 1 <= A_0.Length && A_0[A_1 + 1] == 67)
						{
							A_1 += 2;
							continue;
						}
						byte b = A_0[A_1];
						byte b2 = A_0[A_1 + 1];
						if (b2 == 128)
						{
							result = ar.b;
						}
						else
						{
							if (b >= 48 && b <= 57 && b2 >= 48 && b2 <= 57)
							{
								A_1 += 2;
								goto IL_17A;
							}
							result = this.b(A_0, A_1);
						}
					}
					return result;
				}
				else
				{
					A_1++;
				}
				IL_17A:
				A_2++;
				this.o = false;
			}
			return ar.b;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00070198 File Offset: 0x0006F198
		private void b(byte A_0, ref float A_1)
		{
			this.a(dq.r[(int)A_0, 0], ref A_1);
			this.a((int)dq.r[(int)A_0, 1], ref A_1);
			this.a(dq.r[(int)A_0, 2], ref A_1);
			this.a((int)dq.r[(int)A_0, 3], ref A_1);
			this.a(dq.r[(int)A_0, 4], ref A_1);
			this.a((int)dq.r[(int)A_0, 5], ref A_1);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00070220 File Offset: 0x0006F220
		private void a(byte A_0, ref float A_1)
		{
			if (this.l)
			{
				for (int i = 0; i < (int)A_0; i++)
				{
					this.j[this.k] = false;
					this.k++;
				}
				A_1 += this.a * (float)A_0;
				this.b = A_1;
				this.l = false;
			}
			else if (A_1 != this.b)
			{
				int num = 0;
				while ((float)num < this.c)
				{
					this.j[this.k] = true;
					this.k++;
					num++;
				}
				for (int i = 0; i < (int)A_0; i++)
				{
					this.j[this.k] = false;
					this.k++;
				}
				A_1 += this.a * (float)A_0;
				this.b = A_1;
			}
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0007032C File Offset: 0x0006F32C
		private void b(ar A_0, ref float A_1)
		{
			switch (A_0)
			{
			case ar.a:
				this.b(103, ref A_1);
				break;
			case ar.b:
				this.b(104, ref A_1);
				break;
			default:
				this.b(105, ref A_1);
				break;
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x00070374 File Offset: 0x0006F374
		private byte[] a()
		{
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[this.f.Length];
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < this.f.Length; i++)
			{
				if (this.f[i] == '\\' && this.m && i + 1 < this.f.Length && this.f[i + 1] == '~')
				{
					flag2 = true;
					if (this.m && i + 2 < this.f.Length && this.f[i + 1] == '~' && (this.f[i + 2] == 'A' || this.f[i + 2] == 'B' || this.f[i + 2] == 'C'))
					{
						array[num2] = (byte)this.f[i];
						num2++;
					}
				}
				else if (!flag2 && this.m && i + 1 < this.f.Length && this.f[i] == '~' && this.f[i + 1] == '1')
				{
					flag = true;
					array[num2] = 128;
					num2++;
					i++;
				}
				else
				{
					flag2 = false;
					if (this.f[i] > '\u0080')
					{
						array[num2] = (byte)(this.f[i] & '\u007f');
						num2++;
					}
					else if ((this.f[i] == '(' || this.f[i] == ')') && (this.h || flag))
					{
						num++;
					}
					else
					{
						array[num2] = (byte)this.f[i];
						num2++;
					}
				}
			}
			if (array[0] == 128)
			{
				this.h = true;
			}
			byte[] array2;
			if (this.h && array[0] == 128)
			{
				array2 = new byte[num2 - 1];
				Array.Copy(array, 1, array2, 0, num2 - 1);
			}
			else
			{
				array2 = new byte[num2];
				Array.Copy(array, array2, num2);
			}
			return array2;
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00070618 File Offset: 0x0006F618
		private bool a(byte[] A_0)
		{
			bool flag = false;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] == 92 && this.m && i + 1 < A_0.Length && A_0[i + 1] == 126)
				{
					flag = true;
				}
				else
				{
					if (!flag && this.m && i + 1 < A_0.Length && A_0[i] == 126 && (A_0[i + 1] == 65 || A_0[i + 1] == 66 || A_0[i + 1] == 67))
					{
						return true;
					}
					flag = false;
				}
			}
			return false;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000706C4 File Offset: 0x0006F6C4
		private ar c(byte[] A_0, int A_1)
		{
			bool flag = false;
			int num = A_1;
			while (A_1 < A_0.Length)
			{
				byte b = A_0[A_1];
				if (A_1 == 0 && b == 128)
				{
					num++;
				}
				if (b < 128)
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 65)
					{
						result = ar.a;
					}
					else if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 66)
					{
						result = ar.b;
					}
					else if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 67)
					{
						result = ar.c;
					}
					else
					{
						if (b < 48 || b > 57)
						{
							flag = true;
						}
						else if (!flag && A_1 - num > 0)
						{
							return ar.c;
						}
						if (b > 95)
						{
							result = ar.b;
						}
						else if (b < 32)
						{
							result = ar.a;
						}
						else
						{
							if (A_1 - num < this.i)
							{
								goto IL_1A9;
							}
							result = ar.b;
						}
					}
					return result;
				}
				IL_1A9:
				A_1++;
				this.o = false;
			}
			return ar.b;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0007089C File Offset: 0x0006F89C
		private void a(ar A_0, ref float A_1)
		{
			switch (A_0)
			{
			case ar.a:
				this.b(101, ref A_1);
				break;
			case ar.b:
				this.b(100, ref A_1);
				break;
			default:
				this.b(99, ref A_1);
				break;
			}
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000708E4 File Offset: 0x0006F8E4
		private ar c(byte[] A_0, ref int A_1, ref int A_2, ref float A_3, ref int A_4)
		{
			while (A_1 < A_0.Length)
			{
				if (A_0[A_1] == 128)
				{
					this.b(102, ref A_3);
					A_4 += 102 * A_2++;
				}
				else
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 65)
					{
						A_1 += 2;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 66)
					{
						result = ar.b;
					}
					else if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 67)
					{
						result = ar.c;
					}
					else if (A_0[A_1] > 95)
					{
						result = ar.b;
					}
					else
					{
						if (A_0[A_1] < 48 || A_0[A_1] > 57 || !dq.a(A_0, A_1) || this.n)
						{
							byte b = dq.p[(int)A_0[A_1]];
							this.b(b, ref A_3);
							A_4 += (int)b * A_2++;
							goto IL_1A7;
						}
						result = ar.c;
					}
					return result;
				}
				IL_1A7:
				A_1++;
				this.o = false;
			}
			return ar.b;
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00070ABC File Offset: 0x0006FABC
		private ar b(byte[] A_0, ref int A_1, ref int A_2, ref float A_3, ref int A_4)
		{
			while (A_1 < A_0.Length)
			{
				if (A_0[A_1] == 128)
				{
					this.b(102, ref A_3);
					A_4 += 102 * A_2++;
				}
				else
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 65)
					{
						result = ar.a;
					}
					else
					{
						if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 66)
						{
							A_1 += 2;
							continue;
						}
						if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 67)
						{
							result = ar.c;
						}
						else
						{
							byte b = dq.q[(int)A_0[A_1]];
							if (b == 255)
							{
								result = ar.a;
							}
							else
							{
								if (b < 16 || b > 25 || !dq.a(A_0, A_1) || this.n)
								{
									this.b(b, ref A_3);
									A_4 += (int)b * A_2++;
									goto IL_1A1;
								}
								result = ar.c;
							}
						}
					}
					return result;
				}
				IL_1A1:
				A_1++;
				this.o = false;
			}
			return ar.a;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00070C8C File Offset: 0x0006FC8C
		private ar a(byte[] A_0, ref int A_1, ref int A_2, ref float A_3, ref int A_4)
		{
			while (A_1 < A_0.Length - 1)
			{
				if (A_0[A_1] == 128)
				{
					this.b(102, ref A_3);
					A_4 += 102 * A_2++;
					A_1++;
				}
				else
				{
					if (A_0[A_1] != 92 || !this.n || A_1 + 1 >= A_0.Length || A_0[A_1 + 1] != 126)
					{
						ar result;
						if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 65)
						{
							result = ar.a;
						}
						else if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 66)
						{
							result = ar.b;
						}
						else
						{
							if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 67)
							{
								A_1 += 2;
								continue;
							}
							byte b = A_0[A_1];
							byte b2 = A_0[A_1 + 1];
							if (b2 == 128)
							{
								result = ar.b;
							}
							else
							{
								if (b >= 48 && b <= 57 && b2 >= 48 && b2 <= 57)
								{
									byte b3 = (b - 48) * 10 + b2 - 48;
									this.b(b3, ref A_3);
									A_4 += (int)b3 * A_2++;
									A_1 += 2;
									this.o = false;
									continue;
								}
								result = this.b(A_0, A_1);
							}
						}
						return result;
					}
					this.o = true;
					A_1++;
				}
			}
			return ar.b;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00070E90 File Offset: 0x0006FE90
		private ar b(byte[] A_0, int A_1)
		{
			bool flag = false;
			int num = A_1;
			while (A_1 < A_0.Length)
			{
				byte b = A_0[A_1];
				if (b < 128)
				{
					if (A_0[A_1] == 92 && this.n && A_1 + 1 < A_0.Length && A_0[A_1 + 1] == 126)
					{
						this.o = true;
						A_1++;
						continue;
					}
					ar result;
					if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 65)
					{
						result = ar.a;
					}
					else if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 66)
					{
						result = ar.b;
					}
					else if (!this.o && this.n && A_1 + 1 <= A_0.Length && A_0[A_1] == 126 && A_0[A_1 + 1] == 67)
					{
						result = ar.c;
					}
					else
					{
						if (b < 48 || b > 57)
						{
							flag = true;
						}
						else if (!flag && A_1 - num > 4)
						{
							return ar.c;
						}
						if (b > 95)
						{
							result = ar.b;
						}
						else if (b < 32)
						{
							result = ar.a;
						}
						else
						{
							if (A_1 - num < this.i)
							{
								goto IL_18D;
							}
							result = ar.b;
						}
					}
					return result;
				}
				IL_18D:
				A_1++;
				this.o = false;
			}
			return ar.b;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0007104C File Offset: 0x0007004C
		private static bool a(byte[] A_0, int A_1)
		{
			A_1++;
			int num = A_1;
			while (A_1 < A_0.Length && A_0[A_1] >= 48 && A_0[A_1] <= 57)
			{
				if (A_0[A_1] == 128)
				{
					num++;
				}
				if (A_1 - num > 3)
				{
					return true;
				}
				A_1++;
			}
			return false;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x000710B8 File Offset: 0x000700B8
		private void a(int A_0, ref float A_1)
		{
			A_1 += this.a * (float)A_0;
			this.c = (float)A_0;
		}

		// Token: 0x0400043A RID: 1082
		private float a = 1f;

		// Token: 0x0400043B RID: 1083
		private float b;

		// Token: 0x0400043C RID: 1084
		private float c;

		// Token: 0x0400043D RID: 1085
		private float d;

		// Token: 0x0400043E RID: 1086
		private float e;

		// Token: 0x0400043F RID: 1087
		private string f;

		// Token: 0x04000440 RID: 1088
		private bool g = false;

		// Token: 0x04000441 RID: 1089
		private bool h = false;

		// Token: 0x04000442 RID: 1090
		private int i = 32;

		// Token: 0x04000443 RID: 1091
		private BitArray j;

		// Token: 0x04000444 RID: 1092
		private int k;

		// Token: 0x04000445 RID: 1093
		private bool l = true;

		// Token: 0x04000446 RID: 1094
		private bool m = false;

		// Token: 0x04000447 RID: 1095
		private bool n = false;

		// Token: 0x04000448 RID: 1096
		private bool o = false;

		// Token: 0x04000449 RID: 1097
		private static byte[] p = new byte[]
		{
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62,
			63,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue
		};

		// Token: 0x0400044A RID: 1098
		private static byte[] q = new byte[]
		{
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62,
			63,
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95
		};

		// Token: 0x0400044B RID: 1099
		private static byte[,] r = new byte[,]
		{
			{
				2,
				1,
				2,
				2,
				2,
				2
			},
			{
				2,
				2,
				2,
				1,
				2,
				2
			},
			{
				2,
				2,
				2,
				2,
				2,
				1
			},
			{
				1,
				2,
				1,
				2,
				2,
				3
			},
			{
				1,
				2,
				1,
				3,
				2,
				2
			},
			{
				1,
				3,
				1,
				2,
				2,
				2
			},
			{
				1,
				2,
				2,
				2,
				1,
				3
			},
			{
				1,
				2,
				2,
				3,
				1,
				2
			},
			{
				1,
				3,
				2,
				2,
				1,
				2
			},
			{
				2,
				2,
				1,
				2,
				1,
				3
			},
			{
				2,
				2,
				1,
				3,
				1,
				2
			},
			{
				2,
				3,
				1,
				2,
				1,
				2
			},
			{
				1,
				1,
				2,
				2,
				3,
				2
			},
			{
				1,
				2,
				2,
				1,
				3,
				2
			},
			{
				1,
				2,
				2,
				2,
				3,
				1
			},
			{
				1,
				1,
				3,
				2,
				2,
				2
			},
			{
				1,
				2,
				3,
				1,
				2,
				2
			},
			{
				1,
				2,
				3,
				2,
				2,
				1
			},
			{
				2,
				2,
				3,
				2,
				1,
				1
			},
			{
				2,
				2,
				1,
				1,
				3,
				2
			},
			{
				2,
				2,
				1,
				2,
				3,
				1
			},
			{
				2,
				1,
				3,
				2,
				1,
				2
			},
			{
				2,
				2,
				3,
				1,
				1,
				2
			},
			{
				3,
				1,
				2,
				1,
				3,
				1
			},
			{
				3,
				1,
				1,
				2,
				2,
				2
			},
			{
				3,
				2,
				1,
				1,
				2,
				2
			},
			{
				3,
				2,
				1,
				2,
				2,
				1
			},
			{
				3,
				1,
				2,
				2,
				1,
				2
			},
			{
				3,
				2,
				2,
				1,
				1,
				2
			},
			{
				3,
				2,
				2,
				2,
				1,
				1
			},
			{
				2,
				1,
				2,
				1,
				2,
				3
			},
			{
				2,
				1,
				2,
				3,
				2,
				1
			},
			{
				2,
				3,
				2,
				1,
				2,
				1
			},
			{
				1,
				1,
				1,
				3,
				2,
				3
			},
			{
				1,
				3,
				1,
				1,
				2,
				3
			},
			{
				1,
				3,
				1,
				3,
				2,
				1
			},
			{
				1,
				1,
				2,
				3,
				1,
				3
			},
			{
				1,
				3,
				2,
				1,
				1,
				3
			},
			{
				1,
				3,
				2,
				3,
				1,
				1
			},
			{
				2,
				1,
				1,
				3,
				1,
				3
			},
			{
				2,
				3,
				1,
				1,
				1,
				3
			},
			{
				2,
				3,
				1,
				3,
				1,
				1
			},
			{
				1,
				1,
				2,
				1,
				3,
				3
			},
			{
				1,
				1,
				2,
				3,
				3,
				1
			},
			{
				1,
				3,
				2,
				1,
				3,
				1
			},
			{
				1,
				1,
				3,
				1,
				2,
				3
			},
			{
				1,
				1,
				3,
				3,
				2,
				1
			},
			{
				1,
				3,
				3,
				1,
				2,
				1
			},
			{
				3,
				1,
				3,
				1,
				2,
				1
			},
			{
				2,
				1,
				1,
				3,
				3,
				1
			},
			{
				2,
				3,
				1,
				1,
				3,
				1
			},
			{
				2,
				1,
				3,
				1,
				1,
				3
			},
			{
				2,
				1,
				3,
				3,
				1,
				1
			},
			{
				2,
				1,
				3,
				1,
				3,
				1
			},
			{
				3,
				1,
				1,
				1,
				2,
				3
			},
			{
				3,
				1,
				1,
				3,
				2,
				1
			},
			{
				3,
				3,
				1,
				1,
				2,
				1
			},
			{
				3,
				1,
				2,
				1,
				1,
				3
			},
			{
				3,
				1,
				2,
				3,
				1,
				1
			},
			{
				3,
				3,
				2,
				1,
				1,
				1
			},
			{
				3,
				1,
				4,
				1,
				1,
				1
			},
			{
				2,
				2,
				1,
				4,
				1,
				1
			},
			{
				4,
				3,
				1,
				1,
				1,
				1
			},
			{
				1,
				1,
				1,
				2,
				2,
				4
			},
			{
				1,
				1,
				1,
				4,
				2,
				2
			},
			{
				1,
				2,
				1,
				1,
				2,
				4
			},
			{
				1,
				2,
				1,
				4,
				2,
				1
			},
			{
				1,
				4,
				1,
				1,
				2,
				2
			},
			{
				1,
				4,
				1,
				2,
				2,
				1
			},
			{
				1,
				1,
				2,
				2,
				1,
				4
			},
			{
				1,
				1,
				2,
				4,
				1,
				2
			},
			{
				1,
				2,
				2,
				1,
				1,
				4
			},
			{
				1,
				2,
				2,
				4,
				1,
				1
			},
			{
				1,
				4,
				2,
				1,
				1,
				2
			},
			{
				1,
				4,
				2,
				2,
				1,
				1
			},
			{
				2,
				4,
				1,
				2,
				1,
				1
			},
			{
				2,
				2,
				1,
				1,
				1,
				4
			},
			{
				4,
				1,
				3,
				1,
				1,
				1
			},
			{
				2,
				4,
				1,
				1,
				1,
				2
			},
			{
				1,
				3,
				4,
				1,
				1,
				1
			},
			{
				1,
				1,
				1,
				2,
				4,
				2
			},
			{
				1,
				2,
				1,
				1,
				4,
				2
			},
			{
				1,
				2,
				1,
				2,
				4,
				1
			},
			{
				1,
				1,
				4,
				2,
				1,
				2
			},
			{
				1,
				2,
				4,
				1,
				1,
				2
			},
			{
				1,
				2,
				4,
				2,
				1,
				1
			},
			{
				4,
				1,
				1,
				2,
				1,
				2
			},
			{
				4,
				2,
				1,
				1,
				1,
				2
			},
			{
				4,
				2,
				1,
				2,
				1,
				1
			},
			{
				2,
				1,
				2,
				1,
				4,
				1
			},
			{
				2,
				1,
				4,
				1,
				2,
				1
			},
			{
				4,
				1,
				2,
				1,
				2,
				1
			},
			{
				1,
				1,
				1,
				1,
				4,
				3
			},
			{
				1,
				1,
				1,
				3,
				4,
				1
			},
			{
				1,
				3,
				1,
				1,
				4,
				1
			},
			{
				1,
				1,
				4,
				1,
				1,
				3
			},
			{
				1,
				1,
				4,
				3,
				1,
				1
			},
			{
				4,
				1,
				1,
				1,
				1,
				3
			},
			{
				4,
				1,
				1,
				3,
				1,
				1
			},
			{
				1,
				1,
				3,
				1,
				4,
				1
			},
			{
				1,
				1,
				4,
				1,
				3,
				1
			},
			{
				3,
				1,
				1,
				1,
				4,
				1
			},
			{
				4,
				1,
				1,
				1,
				3,
				1
			},
			{
				2,
				1,
				1,
				4,
				1,
				2
			},
			{
				2,
				1,
				1,
				2,
				1,
				4
			},
			{
				2,
				1,
				1,
				2,
				3,
				2
			}
		};
	}
}
