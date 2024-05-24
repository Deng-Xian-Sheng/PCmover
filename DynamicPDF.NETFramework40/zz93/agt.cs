using System;
using System.Collections.Generic;
using System.Reflection;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004E4 RID: 1252
	[DefaultMember("Item")]
	internal class agt : ags
	{
		// Token: 0x060032EF RID: 13039 RVA: 0x001C54EB File Offset: 0x001C44EB
		internal agt(aba A_0, byte[] A_1) : base(A_0)
		{
			this.a = A_1;
		}

		// Token: 0x060032F0 RID: 13040 RVA: 0x001C5500 File Offset: 0x001C4500
		internal byte[] a()
		{
			return this.a;
		}

		// Token: 0x060032F1 RID: 13041 RVA: 0x001C5518 File Offset: 0x001C4518
		internal byte b(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060032F2 RID: 13042 RVA: 0x001C5534 File Offset: 0x001C4534
		internal abd a(ref int A_0, abi A_1, bool A_2)
		{
			abd result;
			if (A_2)
			{
				result = this.a(ref A_0, A_1, int.MaxValue);
			}
			else
			{
				result = this.a(ref A_0, A_1, 0);
			}
			return result;
		}

		// Token: 0x060032F3 RID: 13043 RVA: 0x001C556C File Offset: 0x001C456C
		internal abd a(ref int A_0, abi A_1, int A_2)
		{
			abd result;
			if (A_2 == -5)
			{
				result = null;
			}
			else
			{
				A_0 = this.c(A_0);
				byte b = this.a[A_0];
				if (b <= 91)
				{
					switch (b)
					{
					case 40:
						if (this.a[A_0 + 1] == 13)
						{
							A_0 += 2;
							return null;
						}
						return this.a(ref A_0, A_1);
					case 41:
					case 42:
					case 44:
						goto IL_179;
					case 43:
						break;
					case 45:
						break;
					case 46:
						break;
					case 47:
						return this.a(ref A_0);
					default:
						if (b != 60)
						{
							if (b != 91)
							{
								goto IL_179;
							}
							return this.b(ref A_0, A_1);
						}
						else
						{
							if (this.a[A_0 + 1] != 60)
							{
								return this.a(ref A_0, A_1);
							}
							if (A_1.b().h())
							{
								return this.c(ref A_0, A_1, A_2);
							}
							return this.b(ref A_0, A_1, A_2);
						}
						break;
					}
					return this.b(ref A_0);
				}
				if (b == 102)
				{
					return this.a(ref A_0, false);
				}
				if (b == 110)
				{
					return this.c(ref A_0);
				}
				if (b == 116)
				{
					return this.a(ref A_0, true);
				}
				IL_179:
				if (!ags.d(this.a[A_0]))
				{
					throw new PdfParsingException("Invalid PDF Object Type.");
				}
				int num = A_0;
				int num2 = this.d(ref A_0);
				if (ags.b(this.a[A_0]))
				{
					int num3 = A_0 - num;
					A_0++;
					A_0 = this.c(A_0);
					if (A_0 < this.a.Length && ags.d(this.a[A_0]))
					{
						int num4 = A_0;
						A_0 = this.a(A_0);
						if (ags.b(this.a[A_0]))
						{
							A_0++;
							A_0 = this.c(A_0);
							if (A_0 < this.a.Length && this.a[A_0] == 82)
							{
								A_0++;
								result = new ab6(base.b(), num2);
							}
							else
							{
								A_0 = num4;
								result = new ag3(this, num, (short)num3, false);
							}
						}
						else
						{
							A_0 = num4;
							result = new ag3(this, num, (short)num3, false);
						}
					}
					else
					{
						result = new ag3(this, num, (short)num3, false);
					}
				}
				else if (this.a[A_0] == 46)
				{
					A_0++;
					A_0 = this.a(A_0);
					int num3 = A_0 - num;
					result = new ag3(this, num, (short)num3, true);
				}
				else
				{
					int num3 = A_0 - num;
					result = new ag3(this, num, (short)num3, num2);
				}
			}
			return result;
		}

		// Token: 0x060032F4 RID: 13044 RVA: 0x001C5878 File Offset: 0x001C4878
		internal int d(ref int A_0)
		{
			int num = 0;
			while (ags.d(this.a[A_0]))
			{
				num = num * 10 + (int)this.a[A_0] - 48;
				A_0++;
			}
			return num;
		}

		// Token: 0x060032F5 RID: 13045 RVA: 0x001C58BC File Offset: 0x001C48BC
		private abv c(ref int A_0)
		{
			A_0 += 4;
			return new abv();
		}

		// Token: 0x060032F6 RID: 13046 RVA: 0x001C58DC File Offset: 0x001C48DC
		internal abj b(ref int A_0, abi A_1, int A_2)
		{
			int num = A_0;
			A_0 += 2;
			A_0 = this.c(A_0);
			abk abk = null;
			abk abk2 = null;
			while (this.a[A_0] != 62)
			{
				abu a_ = this.a(ref A_0);
				abd a_2 = this.a(ref A_0, A_1, 0);
				abk abk3 = new abk(a_, a_2);
				if (abk2 == null)
				{
					abk2 = (abk = abk3);
				}
				else
				{
					abk2.a(abk3);
					abk2 = abk3;
				}
				A_0 = this.c(A_0);
			}
			A_0 += 2;
			abj result;
			if (A_2 == 0)
			{
				result = new abj(A_1, abk);
			}
			else
			{
				A_0 = this.c(A_0);
				if (A_2 > 0 && this.a[A_0] == 115)
				{
					result = this.a(ref A_0, A_1, abk, A_2 - A_0 + num);
				}
				else
				{
					result = new abj(A_1, abk);
				}
			}
			return result;
		}

		// Token: 0x060032F7 RID: 13047 RVA: 0x001C59D0 File Offset: 0x001C49D0
		internal abj c(ref int A_0, abi A_1, int A_2)
		{
			int num = A_0;
			A_0 += 2;
			A_0 = this.c(A_0);
			abk abk = null;
			abk abk2 = null;
			while (this.a[A_0] != 62)
			{
				abu abu = this.a(ref A_0);
				abd abd = this.a(ref A_0, A_1, 0);
				if (abu.j9() == "A")
				{
					if (abd.hy() == ag9.d)
					{
						if (((abu)abd).j9() == "A" || ((abu)abd).j9() == "Dest")
						{
							abu = (abu)abd;
							abd = this.a(ref A_0, A_1, 0);
						}
					}
				}
				abk abk3 = new abk(abu, abd);
				if (abk2 == null)
				{
					abk2 = (abk = abk3);
				}
				else
				{
					abk2.a(abk3);
					abk2 = abk3;
				}
				A_0 = this.c(A_0);
			}
			A_0 += 2;
			abj result;
			if (A_2 == 0)
			{
				result = new abj(A_1, abk);
			}
			else
			{
				A_0 = this.c(A_0);
				if (A_2 > 0 && this.a[A_0] == 115)
				{
					result = this.a(ref A_0, A_1, abk, A_2 - A_0 + num);
				}
				else
				{
					result = new abj(A_1, abk);
				}
			}
			return result;
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x001C5B48 File Offset: 0x001C4B48
		private afj a(ref int A_0, abi A_1, abk A_2, int A_3)
		{
			ag4 ag = new ag4(this, A_1, A_2);
			A_0 += 5;
			while (this.a[A_0] != 10 && this.a[A_0] != 13)
			{
				A_0++;
			}
			A_0++;
			if (this.a[A_0] == 10 && this.a[A_0 - 1] == 13)
			{
				A_0++;
			}
			int num = A_0;
			ag.d(num);
			A_0 += ag.g();
			if (A_0 - num >= A_3 || !this.a(ag.g(), num))
			{
				ag.e(this.a(ag.g(), num, A_3));
			}
			if (A_1.h2())
			{
				if (A_1.b().g() != null && !A_1.b().g().at())
				{
					if (A_1.b().g().@as())
					{
						ag.e(A_1.h1(this.a, num, ag.g()));
					}
					else if (ag.m() != ag1.e)
					{
						ag.e(A_1.h1(this.a, num, ag.g()));
					}
				}
				else if (ag.o() != null && ag.o() == A_1.b().g().c())
				{
					ag.e(A_1.h1(this.a, num, ag.g()));
				}
			}
			return ag;
		}

		// Token: 0x060032F9 RID: 13049 RVA: 0x001C5CF8 File Offset: 0x001C4CF8
		private int a(int A_0, int A_1, int A_2)
		{
			for (int i = A_1 + A_2; i > A_1; i--)
			{
				if (this.a[i] == 109 && this.a[i - 1] == 97 && this.a[i - 2] == 101 && this.a[i - 3] == 114 && this.a[i - 4] == 116 && this.a[i - 5] == 115 && this.a[i - 6] == 100 && this.a[i - 7] == 110 && this.a[i - 8] == 101)
				{
					i -= 8;
					if (this.a()[i - 1] == 10)
					{
						i--;
					}
					return i - A_1;
				}
			}
			throw new PdfParsingException("Indirect Object contains an invalid stream length (" + A_0 + " bytes).");
		}

		// Token: 0x060032FA RID: 13050 RVA: 0x001C5DEC File Offset: 0x001C4DEC
		private abf a(ref int A_0, bool A_1)
		{
			while (this.a[A_0] != 101)
			{
				A_0++;
			}
			A_0++;
			return new abf(A_1);
		}

		// Token: 0x060032FB RID: 13051 RVA: 0x001C5E28 File Offset: 0x001C4E28
		private abe b(ref int A_0, abi A_1)
		{
			A_0++;
			A_0 = this.c(A_0);
			List<abd> list = new List<abd>(4);
			while (this.a[A_0] != 93)
			{
				list.Add(this.a(ref A_0, A_1, 0));
				A_0 = this.c(A_0);
			}
			A_0++;
			return new abe(list);
		}

		// Token: 0x060032FC RID: 13052 RVA: 0x001C5E90 File Offset: 0x001C4E90
		private ab7 a(ref int A_0, abi A_1)
		{
			int num = A_0;
			bool flag = this.a[num] == 60;
			A_0++;
			if (flag)
			{
				while (this.a[A_0] != 62)
				{
					A_0++;
				}
				A_0++;
			}
			else
			{
				int i = 1;
				while (i > 0)
				{
					if (this.a[A_0] == 92)
					{
						A_0++;
					}
					else if (this.a[A_0] == 40)
					{
						i++;
					}
					else if (this.a[A_0] == 41)
					{
						i--;
					}
					A_0++;
				}
			}
			int a_ = A_0 - num;
			return new ag5(this, A_1, num, a_, flag);
		}

		// Token: 0x060032FD RID: 13053 RVA: 0x001C5F6C File Offset: 0x001C4F6C
		private abw b(ref int A_0)
		{
			int num = A_0;
			bool a_ = false;
			if (this.a[A_0] == 43 || this.a[A_0] == 45)
			{
				A_0++;
			}
			if (this.a[A_0] == 43 || this.a[A_0] == 45)
			{
				A_0++;
				num++;
			}
			A_0 = this.a(A_0);
			if (this.a[A_0] == 46)
			{
				a_ = true;
				A_0++;
				A_0 = this.a(A_0);
			}
			int num2 = A_0 - num;
			return new ag3(this, num, (short)num2, a_);
		}

		// Token: 0x060032FE RID: 13054 RVA: 0x001C6028 File Offset: 0x001C5028
		private abu a(ref int A_0)
		{
			int num = A_0++;
			while (ags.a(this.a[A_0]))
			{
				A_0++;
			}
			int num2 = A_0 - num;
			return new ag2(this, num, (short)num2);
		}

		// Token: 0x060032FF RID: 13055 RVA: 0x001C6070 File Offset: 0x001C5070
		private int a(int A_0)
		{
			while (ags.d(this.a[A_0]))
			{
				A_0++;
			}
			return A_0;
		}

		// Token: 0x06003300 RID: 13056 RVA: 0x001C609C File Offset: 0x001C509C
		internal int c(int A_0)
		{
			while (A_0 < this.a.Length && this.a[A_0] <= 32)
			{
				A_0++;
			}
			int result;
			if (A_0 < this.a.Length)
			{
				if (this.a[A_0] == 37)
				{
					A_0++;
					while (this.a[A_0] != 10 && this.a[A_0] != 13)
					{
						A_0++;
					}
					result = this.c(A_0);
				}
				else
				{
					result = A_0;
				}
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x06003301 RID: 13057 RVA: 0x001C6140 File Offset: 0x001C5140
		internal float d(int A_0)
		{
			int num = 0;
			int num2 = 0;
			while (this.a[A_0] == 48)
			{
				A_0++;
			}
			while (ags.d(this.a[A_0]))
			{
				num = num * 10 + (int)this.a[A_0] - 48;
				num2++;
				A_0++;
			}
			float result;
			if (this.a[A_0] == 46)
			{
				A_0++;
				int num3 = 1;
				while (ags.d(this.a[A_0]) && num2 < 9)
				{
					num = num * 10 + (int)this.a[A_0] - 48;
					num3 *= 10;
					num2++;
					A_0++;
				}
				result = (float)num / (float)num3;
			}
			else
			{
				result = (float)num;
			}
			return result;
		}

		// Token: 0x06003302 RID: 13058 RVA: 0x001C620C File Offset: 0x001C520C
		internal int e(int A_0)
		{
			int num = 0;
			while (this.a[A_0] == 48)
			{
				A_0++;
			}
			while (ags.d(this.a[A_0]))
			{
				num = num * 10 + (int)this.a[A_0] - 48;
				A_0++;
			}
			return num;
		}

		// Token: 0x06003303 RID: 13059 RVA: 0x001C6268 File Offset: 0x001C5268
		internal bool a(int A_0, int A_1)
		{
			int num = A_0 + A_1;
			while (this.a[num] != 10 && this.a[num] != 13)
			{
				num++;
			}
			num++;
			if (this.a[num] == 10 && this.a[num - 1] == 13)
			{
				num++;
			}
			return this.a[num + 8] == 109 && this.a[num + 7] == 97 && this.a[num + 6] == 101 && this.a[num + 5] == 114 && this.a[num + 4] == 116 && this.a[num + 3] == 115 && this.a[num + 2] == 100 && this.a[num + 1] == 110 && this.a[num] == 101;
		}

		// Token: 0x04001867 RID: 6247
		private new byte[] a;
	}
}
