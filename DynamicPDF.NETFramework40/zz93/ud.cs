using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200030A RID: 778
	internal class ud : t4
	{
		// Token: 0x06002240 RID: 8768 RVA: 0x00149F50 File Offset: 0x00148F50
		internal ud(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Hour function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x00149FB8 File Offset: 0x00148FB8
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x00149FD8 File Offset: 0x00148FD8
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x00149FF8 File Offset: 0x00148FF8
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eg(A_0).Hour;
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x0014A020 File Offset: 0x00149020
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.eh(A_0, A_1).Hour;
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x0014A047 File Offset: 0x00149047
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002246 RID: 8774 RVA: 0x0014A05C File Offset: 0x0014905C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1] == 'H' || A_0[A_1] == 'h');
		}

		// Token: 0x04000ED6 RID: 3798
		private new q7 a;
	}
}
