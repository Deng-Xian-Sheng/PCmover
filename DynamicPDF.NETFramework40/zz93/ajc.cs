using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000540 RID: 1344
	internal class ajc : ai3
	{
		// Token: 0x06003610 RID: 13840 RVA: 0x001D7F88 File Offset: 0x001D6F88
		internal ajc(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Hour function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003611 RID: 13841 RVA: 0x001D7FF0 File Offset: 0x001D6FF0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x06003612 RID: 13842 RVA: 0x001D8010 File Offset: 0x001D7010
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003613 RID: 13843 RVA: 0x001D8030 File Offset: 0x001D7030
		internal override int l9(LayoutWriter A_0)
		{
			return this.a.l6(A_0).Hour;
		}

		// Token: 0x06003614 RID: 13844 RVA: 0x001D8058 File Offset: 0x001D7058
		internal override int l1(LayoutWriter A_0, akk A_1)
		{
			return this.a.ly(A_0, A_1).Hour;
		}

		// Token: 0x06003615 RID: 13845 RVA: 0x001D807F File Offset: 0x001D707F
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003616 RID: 13846 RVA: 0x001D8094 File Offset: 0x001D7094
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'r' || A_0[A_1 + 3] == 'R') && (A_0[A_1] == 'H' || A_0[A_1] == 'h');
		}

		// Token: 0x040019C9 RID: 6601
		private new ahq a;
	}
}
