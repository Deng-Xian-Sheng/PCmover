using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000324 RID: 804
	internal class u3 : to
	{
		// Token: 0x060022FF RID: 8959 RVA: 0x0014E32C File Offset: 0x0014D32C
		internal u3(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid ToUpper function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002300 RID: 8960 RVA: 0x0014E394 File Offset: 0x0014D394
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002301 RID: 8961 RVA: 0x0014E3B4 File Offset: 0x0014D3B4
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x0014E3D4 File Offset: 0x0014D3D4
		internal override string eo(LayoutWriter A_0)
		{
			return this.a.eo(A_0).ToUpper();
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x0014E3F8 File Offset: 0x0014D3F8
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a.ep(A_0, A_1).ToUpper();
		}

		// Token: 0x06002304 RID: 8964 RVA: 0x0014E41C File Offset: 0x0014D41C
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002305 RID: 8965 RVA: 0x0014E430 File Offset: 0x0014D430
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'p' || A_0[A_1 + 3] == 'P') && (A_0[A_1 + 4] == 'p' || A_0[A_1 + 4] == 'P') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 'r' || A_0[A_1 + 6] == 'R') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04000F0F RID: 3855
		private new q7 a;
	}
}
