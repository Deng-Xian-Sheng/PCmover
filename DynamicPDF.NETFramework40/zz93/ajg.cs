using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000544 RID: 1348
	internal class ajg : aij
	{
		// Token: 0x06003636 RID: 13878 RVA: 0x001D8C88 File Offset: 0x001D7C88
		internal ajg(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Len function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003637 RID: 13879 RVA: 0x001D8CF0 File Offset: 0x001D7CF0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x06003638 RID: 13880 RVA: 0x001D8D10 File Offset: 0x001D7D10
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003639 RID: 13881 RVA: 0x001D8D30 File Offset: 0x001D7D30
		internal override decimal l7(LayoutWriter A_0)
		{
			return this.a.mb(A_0).Length;
		}

		// Token: 0x0600363A RID: 13882 RVA: 0x001D8D58 File Offset: 0x001D7D58
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return this.a.l3(A_0, A_1).Length;
		}

		// Token: 0x0600363B RID: 13883 RVA: 0x001D8D81 File Offset: 0x001D7D81
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600363C RID: 13884 RVA: 0x001D8D94 File Offset: 0x001D7D94
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x040019D1 RID: 6609
		private new ahq a;
	}
}
