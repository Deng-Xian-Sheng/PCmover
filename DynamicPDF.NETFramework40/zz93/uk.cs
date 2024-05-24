using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000311 RID: 785
	internal class uk : t4
	{
		// Token: 0x0600227D RID: 8829 RVA: 0x0014B2B0 File Offset: 0x0014A2B0
		internal uk(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Minute function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x0014B318 File Offset: 0x0014A318
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x0014B338 File Offset: 0x0014A338
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x0014B358 File Offset: 0x0014A358
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eg(A_0).Minute;
		}

		// Token: 0x06002281 RID: 8833 RVA: 0x0014B380 File Offset: 0x0014A380
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.eh(A_0, A_1).Minute;
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x0014B3A7 File Offset: 0x0014A3A7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x0014B3BC File Offset: 0x0014A3BC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'u' || A_0[A_1 + 3] == 'U') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000EE3 RID: 3811
		private new q7 a;
	}
}
