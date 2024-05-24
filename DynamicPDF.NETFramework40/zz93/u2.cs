using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000323 RID: 803
	internal class u2 : to
	{
		// Token: 0x060022F8 RID: 8952 RVA: 0x0014E18C File Offset: 0x0014D18C
		internal u2(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid ToLower function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060022F9 RID: 8953 RVA: 0x0014E1F4 File Offset: 0x0014D1F4
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060022FA RID: 8954 RVA: 0x0014E214 File Offset: 0x0014D214
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060022FB RID: 8955 RVA: 0x0014E234 File Offset: 0x0014D234
		internal override string eo(LayoutWriter A_0)
		{
			return this.a.eo(A_0).ToLower();
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x0014E258 File Offset: 0x0014D258
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a.ep(A_0, A_1).ToLower();
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x0014E27C File Offset: 0x0014D27C
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x0014E290 File Offset: 0x0014D290
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'l' || A_0[A_1 + 2] == 'L') && (A_0[A_1 + 3] == 'o' || A_0[A_1 + 3] == 'O') && (A_0[A_1 + 4] == 'w' || A_0[A_1 + 4] == 'W') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 'r' || A_0[A_1 + 6] == 'R') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04000F0E RID: 3854
		private new q7 a;
	}
}
