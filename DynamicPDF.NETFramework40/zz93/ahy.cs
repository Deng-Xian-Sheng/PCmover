using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200050E RID: 1294
	internal class ahy : ahr
	{
		// Token: 0x060034A0 RID: 13472 RVA: 0x001D0670 File Offset: 0x001CF670
		internal ahy(al5 A_0)
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
				throw new DlexParseException("Invalid Last function detected.");
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

		// Token: 0x060034A1 RID: 13473 RVA: 0x001D0768 File Offset: 0x001CF768
		internal override ahu md()
		{
			return new ahz(this.a);
		}

		// Token: 0x060034A2 RID: 13474 RVA: 0x001D0788 File Offset: 0x001CF788
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 's' || A_0[A_1 + 2] == 'S') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x04001969 RID: 6505
		private new ahq a;
	}
}
