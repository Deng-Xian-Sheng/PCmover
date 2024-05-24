using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200050C RID: 1292
	internal class ahw : ahr
	{
		// Token: 0x06003495 RID: 13461 RVA: 0x001D0234 File Offset: 0x001CF234
		internal ahw(al5 A_0)
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
				throw new DlexParseException("Invalid First function detected.");
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

		// Token: 0x06003496 RID: 13462 RVA: 0x001D032C File Offset: 0x001CF32C
		internal override ahu md()
		{
			return new ahx(this.a);
		}

		// Token: 0x06003497 RID: 13463 RVA: 0x001D034C File Offset: 0x001CF34C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 's' || A_0[A_1 + 3] == 'S') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1] == 'F' || A_0[A_1] == 'f');
		}

		// Token: 0x04001963 RID: 6499
		private new ahq a;
	}
}
