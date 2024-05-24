using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000516 RID: 1302
	internal class ah6 : ahr
	{
		// Token: 0x060034CF RID: 13519 RVA: 0x001D20B0 File Offset: 0x001D10B0
		internal ah6(al5 A_0)
		{
			A_0.a(false);
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.b() == '*')
			{
				this.a = null;
				A_0.n();
			}
			else if (A_0.v())
			{
				this.a = A_0.g();
			}
			else
			{
				this.a = A_0.f();
			}
			A_0.p();
			base.a(A_0);
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Min function detected.");
			}
			A_0.a(A_0.d() + 1);
			if (A_0.x())
			{
				A_0.e().a(this);
			}
			else if (base.b() != "CurrentPage" && base.b() != "PreviousPage")
			{
				A_0.e().a(this);
			}
			A_0.a(true);
		}

		// Token: 0x060034D0 RID: 13520 RVA: 0x001D21CC File Offset: 0x001D11CC
		internal override ahu md()
		{
			return new ah7(this.a);
		}

		// Token: 0x060034D1 RID: 13521 RVA: 0x001D21EC File Offset: 0x001D11EC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x0400197F RID: 6527
		private new ahq a;
	}
}
