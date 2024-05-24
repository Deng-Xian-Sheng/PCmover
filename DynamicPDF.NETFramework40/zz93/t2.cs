using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002FF RID: 767
	internal class t2 : tq
	{
		// Token: 0x060021E8 RID: 8680 RVA: 0x00147FDC File Offset: 0x00146FDC
		internal t2(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			this.a = A_0.k();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid DateAdd function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.m();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid DateAdd function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.c = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid DateAdd function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001480B4 File Offset: 0x001470B4
		internal override bool eq(LayoutWriter A_0)
		{
			return this.c.eq(A_0);
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001480D4 File Offset: 0x001470D4
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.c.er(A_0, A_1);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001480F4 File Offset: 0x001470F4
		internal override DateTime eg(LayoutWriter A_0)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.c.eg(A_0).AddDays((double)this.b);
				}
				if (num == 824370)
				{
					return this.c.eg(A_0).AddYears(this.b);
				}
				if (num == 8902227)
				{
					return this.c.eg(A_0).AddHours((double)this.b);
				}
			}
			else if (num <= 446125718)
			{
				if (num == 14137992)
				{
					return this.c.eg(A_0).AddMonths(this.b);
				}
				if (num == 446125718)
				{
					return this.c.eg(A_0).AddMinutes((double)this.b);
				}
			}
			else
			{
				if (num == 449285367)
				{
					return this.c.eg(A_0).AddMilliseconds((double)this.b);
				}
				if (num == 642891204)
				{
					return this.c.eg(A_0).AddSeconds((double)this.b);
				}
			}
			throw new DplxParseException("Invalid DateAdd function detected.");
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x00148254 File Offset: 0x00147254
		internal override DateTime eh(LayoutWriter A_0, vi A_1)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.c.eh(A_0, A_1).AddDays((double)this.b);
				}
				if (num == 824370)
				{
					return this.c.eh(A_0, A_1).AddYears(this.b);
				}
				if (num == 8902227)
				{
					return this.c.eh(A_0, A_1).AddHours((double)this.b);
				}
			}
			else if (num <= 446125718)
			{
				if (num == 14137992)
				{
					return this.c.eh(A_0, A_1).AddMonths(this.b);
				}
				if (num == 446125718)
				{
					return this.c.eh(A_0, A_1).AddMinutes((double)this.b);
				}
			}
			else
			{
				if (num == 449285367)
				{
					return this.c.eh(A_0, A_1).AddMilliseconds((double)this.b);
				}
				if (num == 642891204)
				{
					return this.c.eh(A_0, A_1).AddSeconds((double)this.b);
				}
			}
			throw new DplxParseException("Invalid DateAdd function detected.");
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001483BB File Offset: 0x001473BB
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001483D0 File Offset: 0x001473D0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 'd' || A_0[A_1 + 5] == 'D') && (A_0[A_1 + 6] == 'd' || A_0[A_1 + 6] == 'D') && (A_0[A_1] == 'D' || A_0[A_1] == 'd');
		}

		// Token: 0x04000EBF RID: 3775
		private new int a;

		// Token: 0x04000EC0 RID: 3776
		private new int b;

		// Token: 0x04000EC1 RID: 3777
		private new q7 c;
	}
}
