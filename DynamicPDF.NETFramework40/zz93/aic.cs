using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200051C RID: 1308
	internal class aic : ahr
	{
		// Token: 0x060034F6 RID: 13558 RVA: 0x001D3744 File Offset: 0x001D2744
		internal aic(al5 A_0)
		{
			A_0.a(false);
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
			base.a(A_0);
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Format function detected.");
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

		// Token: 0x060034F7 RID: 13559 RVA: 0x001D383C File Offset: 0x001D283C
		internal override ahu md()
		{
			return new aid(this.a);
		}

		// Token: 0x060034F8 RID: 13560 RVA: 0x001D385C File Offset: 0x001D285C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'm' || A_0[A_1 + 2] == 'M') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04001990 RID: 6544
		private new ahq a;
	}
}
