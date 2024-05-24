using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000327 RID: 807
	internal class u6 : t4
	{
		// Token: 0x06002314 RID: 8980 RVA: 0x0014E8FC File Offset: 0x0014D8FC
		internal u6(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Year function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002315 RID: 8981 RVA: 0x0014E964 File Offset: 0x0014D964
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002316 RID: 8982 RVA: 0x0014E984 File Offset: 0x0014D984
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002317 RID: 8983 RVA: 0x0014E9A4 File Offset: 0x0014D9A4
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eg(A_0).Year;
		}

		// Token: 0x06002318 RID: 8984 RVA: 0x0014E9CC File Offset: 0x0014D9CC
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.eh(A_0, A_1).Year;
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x0014E9F3 File Offset: 0x0014D9F3
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600231A RID: 8986 RVA: 0x0014EA08 File Offset: 0x0014DA08
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'a' || A_0[A_1 + 2] == 'A') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1] == 'Y' || A_0[A_1] == 'y');
		}

		// Token: 0x04000F12 RID: 3858
		private new q7 a;
	}
}
