using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200031A RID: 794
	internal class ut : to
	{
		// Token: 0x060022B8 RID: 8888 RVA: 0x0014CE84 File Offset: 0x0014BE84
		internal ut(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Replace function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.b = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Replace function detected.");
			}
			A_0.a(A_0.e() + 1);
			this.c = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Replace function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x0014CF64 File Offset: 0x0014BF64
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x0014CF84 File Offset: 0x0014BF84
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x0014CFA4 File Offset: 0x0014BFA4
		internal override string eo(LayoutWriter A_0)
		{
			return this.a.eo(A_0).Replace(this.b.eo(A_0), this.c.eo(A_0));
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x0014CFE0 File Offset: 0x0014BFE0
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a.ep(A_0, A_1).Replace(this.b.ep(A_0, A_1), this.c.ep(A_0, A_1));
		}

		// Token: 0x060022BD RID: 8893 RVA: 0x0014D01E File Offset: 0x0014C01E
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022BE RID: 8894 RVA: 0x0014D030 File Offset: 0x0014C030
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'p' || A_0[A_1 + 2] == 'P') && (A_0[A_1 + 3] == 'l' || A_0[A_1 + 3] == 'L') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 'c' || A_0[A_1 + 5] == 'C') && (A_0[A_1 + 6] == 'e' || A_0[A_1 + 6] == 'E') && (A_0[A_1] == 'R' || A_0[A_1] == 'r');
		}

		// Token: 0x04000EFD RID: 3837
		private new q7 a;

		// Token: 0x04000EFE RID: 3838
		private new q7 b;

		// Token: 0x04000EFF RID: 3839
		private new q7 c;
	}
}
