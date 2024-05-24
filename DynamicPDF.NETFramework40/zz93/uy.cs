using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200031F RID: 799
	internal class uy : t4
	{
		// Token: 0x060022DB RID: 8923 RVA: 0x0014D7B8 File Offset: 0x0014C7B8
		internal uy(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid String Compare function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid String Compare function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x0014D85C File Offset: 0x0014C85C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x0014D88C File Offset: 0x0014C88C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x0014D8C0 File Offset: 0x0014C8C0
		internal override int em(LayoutWriter A_0)
		{
			return this.a.eo(A_0).CompareTo(this.b.eo(A_0));
		}

		// Token: 0x060022DF RID: 8927 RVA: 0x0014D8F0 File Offset: 0x0014C8F0
		internal override int en(LayoutWriter A_0, vi A_1)
		{
			return this.a.ep(A_0, A_1).CompareTo(this.b.ep(A_0, A_1));
		}

		// Token: 0x060022E0 RID: 8928 RVA: 0x0014D921 File Offset: 0x0014C921
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022E1 RID: 8929 RVA: 0x0014D934 File Offset: 0x0014C934
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'c' || A_0[A_1 + 3] == 'C') && (A_0[A_1 + 4] == 'o' || A_0[A_1 + 4] == 'O') && (A_0[A_1 + 5] == 'm' || A_0[A_1 + 5] == 'M') && (A_0[A_1 + 6] == 'p' || A_0[A_1 + 6] == 'P') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000F06 RID: 3846
		private new q7 a;

		// Token: 0x04000F07 RID: 3847
		private new q7 b;
	}
}
