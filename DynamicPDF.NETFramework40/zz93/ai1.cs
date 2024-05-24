using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000535 RID: 1333
	internal class ai1 : aip
	{
		// Token: 0x060035B8 RID: 13752 RVA: 0x001D6014 File Offset: 0x001D5014
		internal ai1(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			this.a = A_0.j();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid DateAdd function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.l();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid DateAdd function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.c = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid DateAdd function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035B9 RID: 13753 RVA: 0x001D60EC File Offset: 0x001D50EC
		internal override bool l4(LayoutWriter A_0)
		{
			return this.c.l4(A_0);
		}

		// Token: 0x060035BA RID: 13754 RVA: 0x001D610C File Offset: 0x001D510C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.c.lw(A_0, A_1);
		}

		// Token: 0x060035BB RID: 13755 RVA: 0x001D612C File Offset: 0x001D512C
		internal override DateTime l6(LayoutWriter A_0)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.c.l6(A_0).AddDays((double)this.b);
				}
				if (num == 824370)
				{
					return this.c.l6(A_0).AddYears(this.b);
				}
				if (num == 8902227)
				{
					return this.c.l6(A_0).AddHours((double)this.b);
				}
			}
			else if (num <= 446125718)
			{
				if (num == 14137992)
				{
					return this.c.l6(A_0).AddMonths(this.b);
				}
				if (num == 446125718)
				{
					return this.c.l6(A_0).AddMinutes((double)this.b);
				}
			}
			else
			{
				if (num == 449285367)
				{
					return this.c.l6(A_0).AddMilliseconds((double)this.b);
				}
				if (num == 642891204)
				{
					return this.c.l6(A_0).AddSeconds((double)this.b);
				}
			}
			throw new DlexParseException("Invalid DateAdd function detected.");
		}

		// Token: 0x060035BC RID: 13756 RVA: 0x001D628C File Offset: 0x001D528C
		internal override DateTime ly(LayoutWriter A_0, akk A_1)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.c.ly(A_0, A_1).AddDays((double)this.b);
				}
				if (num == 824370)
				{
					return this.c.ly(A_0, A_1).AddYears(this.b);
				}
				if (num == 8902227)
				{
					return this.c.ly(A_0, A_1).AddHours((double)this.b);
				}
			}
			else if (num <= 446125718)
			{
				if (num == 14137992)
				{
					return this.c.ly(A_0, A_1).AddMonths(this.b);
				}
				if (num == 446125718)
				{
					return this.c.ly(A_0, A_1).AddMinutes((double)this.b);
				}
			}
			else
			{
				if (num == 449285367)
				{
					return this.c.ly(A_0, A_1).AddMilliseconds((double)this.b);
				}
				if (num == 642891204)
				{
					return this.c.ly(A_0, A_1).AddSeconds((double)this.b);
				}
			}
			throw new DlexParseException("Invalid DateAdd function detected.");
		}

		// Token: 0x060035BD RID: 13757 RVA: 0x001D63F3 File Offset: 0x001D53F3
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035BE RID: 13758 RVA: 0x001D6408 File Offset: 0x001D5408
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 'd' || A_0[A_1 + 5] == 'D') && (A_0[A_1 + 6] == 'd' || A_0[A_1 + 6] == 'D') && (A_0[A_1] == 'D' || A_0[A_1] == 'd');
		}

		// Token: 0x040019B2 RID: 6578
		private new int a;

		// Token: 0x040019B3 RID: 6579
		private new int b;

		// Token: 0x040019B4 RID: 6580
		private new ahq c;
	}
}
