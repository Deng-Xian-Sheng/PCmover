using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002FD RID: 765
	internal class t0 : to
	{
		// Token: 0x060021DA RID: 8666 RVA: 0x00147BB8 File Offset: 0x00146BB8
		internal t0(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.a = A_0.g();
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid StringAdd function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			this.b = A_0.g();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid StringAdd function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x00147C5C File Offset: 0x00146C5C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x00147C8C File Offset: 0x00146C8C
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x00147CC0 File Offset: 0x00146CC0
		internal override string eo(LayoutWriter A_0)
		{
			return this.a.eo(A_0) + this.b.eo(A_0);
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x00147CF0 File Offset: 0x00146CF0
		internal override string ep(LayoutWriter A_0, vi A_1)
		{
			return this.a.eo(A_0) + this.b.eo(A_0);
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x00147D1F File Offset: 0x00146D1F
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x00147D40 File Offset: 0x00146D40
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'c' || A_0[A_1 + 3] == 'C') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 't' || A_0[A_1 + 5] == 'T') && (A_0[A_1] == 'C' || A_0[A_1] == 'c');
		}

		// Token: 0x04000EBD RID: 3773
		private new q7 a;

		// Token: 0x04000EBE RID: 3774
		private new q7 b;
	}
}
