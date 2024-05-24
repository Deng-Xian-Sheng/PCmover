using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000512 RID: 1298
	internal class ah2 : ahr
	{
		// Token: 0x060034B6 RID: 13494 RVA: 0x001D0FE0 File Offset: 0x001CFFE0
		internal ah2(al5 A_0)
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
				throw new DlexParseException("Invalid Mean function detected.");
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

		// Token: 0x060034B7 RID: 13495 RVA: 0x001D10FC File Offset: 0x001D00FC
		internal override ahu md()
		{
			return new ah3(this.a);
		}

		// Token: 0x060034B8 RID: 13496 RVA: 0x001D111C File Offset: 0x001D011C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'a' || A_0[A_1 + 2] == 'A') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04001973 RID: 6515
		private new ahq a;
	}
}
