using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200053B RID: 1339
	internal class ai7 : aiq
	{
		// Token: 0x060035EA RID: 13802 RVA: 0x001D7170 File Offset: 0x001D6170
		internal ai7(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Floor function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035EB RID: 13803 RVA: 0x001D71D8 File Offset: 0x001D61D8
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060035EC RID: 13804 RVA: 0x001D71F8 File Offset: 0x001D61F8
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060035ED RID: 13805 RVA: 0x001D7218 File Offset: 0x001D6218
		internal override double l8(LayoutWriter A_0)
		{
			return Math.Floor(this.a.l8(A_0));
		}

		// Token: 0x060035EE RID: 13806 RVA: 0x001D723C File Offset: 0x001D623C
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return Math.Floor(this.a.l0(A_0, A_1));
		}

		// Token: 0x060035EF RID: 13807 RVA: 0x001D7260 File Offset: 0x001D6260
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035F0 RID: 13808 RVA: 0x001D7274 File Offset: 0x001D6274
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'l' || A_0[A_1 + 1] == 'L') && (A_0[A_1 + 2] == 'o' || A_0[A_1 + 2] == 'O') && (A_0[A_1 + 3] == 'o' || A_0[A_1 + 3] == 'O') && (A_0[A_1 + 4] == 'r' || A_0[A_1 + 4] == 'R') && (A_0[A_1] == 'F' || A_0[A_1] == 'f');
		}

		// Token: 0x040019BD RID: 6589
		private new ahq a;
	}
}
