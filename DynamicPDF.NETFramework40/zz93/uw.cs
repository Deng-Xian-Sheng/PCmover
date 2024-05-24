using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200031D RID: 797
	internal class uw : t4
	{
		// Token: 0x060022CD RID: 8909 RVA: 0x0014D4A0 File Offset: 0x0014C4A0
		internal uw(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Second function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022CE RID: 8910 RVA: 0x0014D508 File Offset: 0x0014C508
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x0014D528 File Offset: 0x0014C528
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022D0 RID: 8912 RVA: 0x0014D548 File Offset: 0x0014C548
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eg(A_0).Second;
		}

		// Token: 0x060022D1 RID: 8913 RVA: 0x0014D570 File Offset: 0x0014C570
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.eh(A_0, A_1).Second;
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x0014D597 File Offset: 0x0014C597
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x0014D5AC File Offset: 0x0014C5AC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'c' || A_0[A_1 + 2] == 'C') && (A_0[A_1 + 3] == 'o' || A_0[A_1 + 3] == 'O') && (A_0[A_1 + 4] == 'n' || A_0[A_1 + 4] == 'N') && (A_0[A_1 + 5] == 'd' || A_0[A_1 + 5] == 'D') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000F04 RID: 3844
		private new q7 a;
	}
}
