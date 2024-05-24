using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000536 RID: 1334
	internal class ai2 : aiq
	{
		// Token: 0x060035BF RID: 13759 RVA: 0x001D64A4 File Offset: 0x001D54A4
		internal ai2(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			this.a = A_0.j();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid DateDiff function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid DateDiff function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.c = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid DateDiff function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035C0 RID: 13760 RVA: 0x001D6574 File Offset: 0x001D5574
		internal override bool l4(LayoutWriter A_0)
		{
			return this.b.l4(A_0) || this.c.l4(A_0);
		}

		// Token: 0x060035C1 RID: 13761 RVA: 0x001D65A4 File Offset: 0x001D55A4
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.b.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x001D65D8 File Offset: 0x001D55D8
		internal override double l8(LayoutWriter A_0)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.b.l6(A_0).Subtract(this.c.l6(A_0)).TotalDays;
				}
				if (num == 8902227)
				{
					return this.b.l6(A_0).Subtract(this.c.l6(A_0)).TotalHours;
				}
			}
			else
			{
				if (num == 446125718)
				{
					return this.b.l6(A_0).Subtract(this.c.l6(A_0)).TotalMinutes;
				}
				if (num == 449285367)
				{
					return this.b.l6(A_0).Subtract(this.c.l6(A_0)).TotalMilliseconds;
				}
				if (num == 642891204)
				{
					return this.b.l6(A_0).Subtract(this.c.l6(A_0)).TotalSeconds;
				}
			}
			throw new DlexParseException("Invalid DateDiff function detected.");
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x001D6718 File Offset: 0x001D5718
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.b.ly(A_0, A_1).Subtract(this.c.ly(A_0, A_1)).TotalDays;
				}
				if (num == 8902227)
				{
					return this.b.ly(A_0, A_1).Subtract(this.c.ly(A_0, A_1)).TotalHours;
				}
			}
			else
			{
				if (num == 446125718)
				{
					return this.b.ly(A_0, A_1).Subtract(this.c.ly(A_0, A_1)).TotalMinutes;
				}
				if (num == 449285367)
				{
					return this.b.ly(A_0, A_1).Subtract(this.c.ly(A_0, A_1)).TotalMilliseconds;
				}
				if (num == 642891204)
				{
					return this.b.ly(A_0, A_1).Subtract(this.c.ly(A_0, A_1)).TotalSeconds;
				}
			}
			throw new DlexParseException("Invalid DateDiff function detected.");
		}

		// Token: 0x060035C4 RID: 13764 RVA: 0x001D6860 File Offset: 0x001D5860
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.b.mc(A_0, A_1, A_2);
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035C5 RID: 13765 RVA: 0x001D6884 File Offset: 0x001D5884
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 8 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1 + 5] == 'i' || A_0[A_1 + 5] == 'I') && (A_0[A_1 + 6] == 'f' || A_0[A_1 + 6] == 'F') && (A_0[A_1 + 7] == 'f' || A_0[A_1 + 7] == 'F') && (A_0[A_1] == 'D' || A_0[A_1] == 'd');
		}

		// Token: 0x040019B5 RID: 6581
		private new int a;

		// Token: 0x040019B6 RID: 6582
		private new ahq b;

		// Token: 0x040019B7 RID: 6583
		private new ahq c;
	}
}
