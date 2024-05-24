using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000538 RID: 1336
	internal class ai4 : ai3
	{
		// Token: 0x060035D3 RID: 13779 RVA: 0x001D6AE4 File Offset: 0x001D5AE4
		internal ai4(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Day function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035D4 RID: 13780 RVA: 0x001D6B4C File Offset: 0x001D5B4C
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060035D5 RID: 13781 RVA: 0x001D6B6C File Offset: 0x001D5B6C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060035D6 RID: 13782 RVA: 0x001D6B8C File Offset: 0x001D5B8C
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.l6(A_0).Day;
		}

		// Token: 0x060035D7 RID: 13783 RVA: 0x001D6BB4 File Offset: 0x001D5BB4
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.ly(A_0, A_1).Day;
		}

		// Token: 0x060035D8 RID: 13784 RVA: 0x001D6BDB File Offset: 0x001D5BDB
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035D9 RID: 13785 RVA: 0x001D6BF0 File Offset: 0x001D5BF0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 'y' || A_0[A_1 + 2] == 'Y') && (A_0[A_1] == 'D' || A_0[A_1] == 'd');
		}

		// Token: 0x040019B8 RID: 6584
		private new ahq a;
	}
}
