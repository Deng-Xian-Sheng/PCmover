using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200051A RID: 1306
	internal class aia : ahr
	{
		// Token: 0x060034E8 RID: 13544 RVA: 0x001D2F60 File Offset: 0x001D1F60
		internal aia(al5 A_0)
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
				throw new DlexParseException("Invalid Standard Deviation function detected.");
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

		// Token: 0x060034E9 RID: 13545 RVA: 0x001D307C File Offset: 0x001D207C
		internal override ahu md()
		{
			return new aib(this.a);
		}

		// Token: 0x060034EA RID: 13546 RVA: 0x001D309C File Offset: 0x001D209C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1 + 4] == 'v' || A_0[A_1 + 4] == 'V') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x0400198A RID: 6538
		private new ahq a;
	}
}
