using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200031E RID: 798
	internal class ux : tr
	{
		// Token: 0x060022D4 RID: 8916 RVA: 0x0014D634 File Offset: 0x0014C634
		internal ux(w5 A_0)
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
				throw new DplxParseException("Invalid Square Root function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x0014D6B8 File Offset: 0x0014C6B8
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x0014D6D8 File Offset: 0x0014C6D8
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x0014D6F8 File Offset: 0x0014C6F8
		internal override double ek(LayoutWriter A_0)
		{
			return Math.Sqrt(this.a.ek(A_0));
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x0014D71C File Offset: 0x0014C71C
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return Math.Sqrt(this.a.el(A_0, A_1));
		}

		// Token: 0x060022D9 RID: 8921 RVA: 0x0014D740 File Offset: 0x0014C740
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x0014D754 File Offset: 0x0014C754
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'q' || A_0[A_1 + 1] == 'Q') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000F05 RID: 3845
		private new q7 a;
	}
}
