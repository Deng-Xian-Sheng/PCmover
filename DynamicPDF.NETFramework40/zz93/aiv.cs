using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200052F RID: 1327
	internal class aiv : aij
	{
		// Token: 0x0600358D RID: 13709 RVA: 0x001D53C4 File Offset: 0x001D43C4
		internal aiv(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.a = A_0.g();
			}
			else
			{
				this.a = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Round function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600358E RID: 13710 RVA: 0x001D5448 File Offset: 0x001D4448
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600358F RID: 13711 RVA: 0x001D5468 File Offset: 0x001D4468
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003590 RID: 13712 RVA: 0x001D5488 File Offset: 0x001D4488
		internal override decimal l7(LayoutWriter A_0)
		{
			return Math.Abs(this.a.l7(A_0));
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x001D54AC File Offset: 0x001D44AC
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return Math.Abs(this.a.lz(A_0, A_1));
		}

		// Token: 0x06003592 RID: 13714 RVA: 0x001D54D0 File Offset: 0x001D44D0
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003593 RID: 13715 RVA: 0x001D54E4 File Offset: 0x001D44E4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'b' || A_0[A_1 + 1] == 'B') && (A_0[A_1 + 2] == 's' || A_0[A_1 + 2] == 'S') && (A_0[A_1] == 'A' || A_0[A_1] == 'a');
		}

		// Token: 0x040019AA RID: 6570
		private new ahq a;
	}
}
