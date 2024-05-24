using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000325 RID: 805
	internal class u4 : to
	{
		// Token: 0x06002306 RID: 8966 RVA: 0x0014E4CC File Offset: 0x0014D4CC
		internal u4(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Trim function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002307 RID: 8967 RVA: 0x0014E534 File Offset: 0x0014D534
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002308 RID: 8968 RVA: 0x0014E554 File Offset: 0x0014D554
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002309 RID: 8969 RVA: 0x0014E574 File Offset: 0x0014D574
		internal override string eo(LayoutWriter A_0)
		{
			return this.a.eo(A_0).Trim();
		}

		// Token: 0x0600230A RID: 8970 RVA: 0x0014E598 File Offset: 0x0014D598
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a.ep(A_0, A_1).Trim();
		}

		// Token: 0x0600230B RID: 8971 RVA: 0x0014E5BC File Offset: 0x0014D5BC
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600230C RID: 8972 RVA: 0x0014E5D0 File Offset: 0x0014D5D0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'r' || A_0[A_1 + 1] == 'R') && (A_0[A_1 + 2] == 'i' || A_0[A_1 + 2] == 'I') && (A_0[A_1 + 3] == 'm' || A_0[A_1 + 3] == 'M') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04000F10 RID: 3856
		private new q7 a;
	}
}
