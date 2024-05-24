using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002FA RID: 762
	internal class tx : ra
	{
		// Token: 0x060021C5 RID: 8645 RVA: 0x00147690 File Offset: 0x00146690
		internal tx(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.a = A_0.h();
			}
			else
			{
				this.a = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Round function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x00147714 File Offset: 0x00146714
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x00147734 File Offset: 0x00146734
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060021C8 RID: 8648 RVA: 0x00147754 File Offset: 0x00146754
		internal override decimal ei(LayoutWriter A_0)
		{
			return Math.Abs(this.a.ei(A_0));
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x00147778 File Offset: 0x00146778
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return Math.Abs(this.a.ej(A_0, A_1));
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x0014779C File Offset: 0x0014679C
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x001477B0 File Offset: 0x001467B0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'b' || A_0[A_1 + 1] == 'B') && (A_0[A_1 + 2] == 's' || A_0[A_1 + 2] == 'S') && (A_0[A_1] == 'A' || A_0[A_1] == 'a');
		}

		// Token: 0x04000EB9 RID: 3769
		private new q7 a;
	}
}
