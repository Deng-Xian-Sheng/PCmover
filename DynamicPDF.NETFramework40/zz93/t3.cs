using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000300 RID: 768
	internal class t3 : tr
	{
		// Token: 0x060021EF RID: 8687 RVA: 0x0014846C File Offset: 0x0014746C
		internal t3(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			this.a = A_0.k();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid DateDiff function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid DateDiff function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.c = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid DateDiff function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x0014853C File Offset: 0x0014753C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.b.eq(A_0) || this.c.eq(A_0);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x0014856C File Offset: 0x0014756C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.b.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001485A0 File Offset: 0x001475A0
		internal override double ek(LayoutWriter A_0)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.b.eg(A_0).Subtract(this.c.eg(A_0)).TotalDays;
				}
				if (num == 8902227)
				{
					return this.b.eg(A_0).Subtract(this.c.eg(A_0)).TotalHours;
				}
			}
			else
			{
				if (num == 446125718)
				{
					return this.b.eg(A_0).Subtract(this.c.eg(A_0)).TotalMinutes;
				}
				if (num == 449285367)
				{
					return this.b.eg(A_0).Subtract(this.c.eg(A_0)).TotalMilliseconds;
				}
				if (num == 642891204)
				{
					return this.b.eg(A_0).Subtract(this.c.eg(A_0)).TotalSeconds;
				}
			}
			throw new DplxParseException("Invalid DateDiff function detected.");
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001486E0 File Offset: 0x001476E0
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			int num = this.a;
			if (num <= 8902227)
			{
				if (num == 4153)
				{
					return this.b.eh(A_0, A_1).Subtract(this.c.eh(A_0, A_1)).TotalDays;
				}
				if (num == 8902227)
				{
					return this.b.eh(A_0, A_1).Subtract(this.c.eh(A_0, A_1)).TotalHours;
				}
			}
			else
			{
				if (num == 446125718)
				{
					return this.b.eh(A_0, A_1).Subtract(this.c.eh(A_0, A_1)).TotalMinutes;
				}
				if (num == 449285367)
				{
					return this.b.eh(A_0, A_1).Subtract(this.c.eh(A_0, A_1)).TotalMilliseconds;
				}
				if (num == 642891204)
				{
					return this.b.eh(A_0, A_1).Subtract(this.c.eh(A_0, A_1)).TotalSeconds;
				}
			}
			throw new DplxParseException("Invalid DateDiff function detected.");
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x00148828 File Offset: 0x00147828
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.b.eu(A_0, A_1, A_2);
			this.c.eu(A_0, A_1, A_2);
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x0014884C File Offset: 0x0014784C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 8 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1 + 5] == 'i' || A_0[A_1 + 5] == 'I') && (A_0[A_1 + 6] == 'f' || A_0[A_1 + 6] == 'F') && (A_0[A_1 + 7] == 'f' || A_0[A_1 + 7] == 'F') && (A_0[A_1] == 'D' || A_0[A_1] == 'd');
		}

		// Token: 0x04000EC2 RID: 3778
		private new int a;

		// Token: 0x04000EC3 RID: 3779
		private new q7 b;

		// Token: 0x04000EC4 RID: 3780
		private new q7 c;
	}
}
