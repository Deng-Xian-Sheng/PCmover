using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200030E RID: 782
	internal class uh : ra
	{
		// Token: 0x06002266 RID: 8806 RVA: 0x0014AC50 File Offset: 0x00149C50
		internal uh(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Len function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x0014ACB8 File Offset: 0x00149CB8
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x0014ACD8 File Offset: 0x00149CD8
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x0014ACF8 File Offset: 0x00149CF8
		internal override decimal ei(LayoutWriter A_0)
		{
			return this.a.eo(A_0).Length;
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x0014AD20 File Offset: 0x00149D20
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return this.a.ep(A_0, A_1).Length;
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x0014AD49 File Offset: 0x00149D49
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x0014AD5C File Offset: 0x00149D5C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x04000EDE RID: 3806
		private new q7 a;
	}
}
