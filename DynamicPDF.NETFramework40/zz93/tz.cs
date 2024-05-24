using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002FC RID: 764
	internal class tz : tr
	{
		// Token: 0x060021D3 RID: 8659 RVA: 0x00147A18 File Offset: 0x00146A18
		internal tz(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Ceiling function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x00147A80 File Offset: 0x00146A80
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x00147AA0 File Offset: 0x00146AA0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x00147AC0 File Offset: 0x00146AC0
		internal override double ek(LayoutWriter A_0)
		{
			return Math.Ceiling(this.a.ek(A_0));
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x00147AE4 File Offset: 0x00146AE4
		internal override double el(LayoutWriter A_0, vi A_1)
		{
			return Math.Ceiling(this.a.el(A_0, A_1));
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x00147B08 File Offset: 0x00146B08
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x00147B1C File Offset: 0x00146B1C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 7 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'i' || A_0[A_1 + 2] == 'I') && (A_0[A_1 + 3] == 'l' || A_0[A_1 + 3] == 'L') && (A_0[A_1 + 4] == 'i' || A_0[A_1 + 4] == 'I') && (A_0[A_1 + 5] == 'n' || A_0[A_1 + 5] == 'N') && (A_0[A_1 + 6] == 'g' || A_0[A_1 + 6] == 'G') && (A_0[A_1] == 'C' || A_0[A_1] == 'c');
		}

		// Token: 0x04000EBC RID: 3772
		private new q7 a;
	}
}
