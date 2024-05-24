using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000514 RID: 1300
	internal class ah4 : ahr
	{
		// Token: 0x060034C1 RID: 13505 RVA: 0x001D17C8 File Offset: 0x001D07C8
		internal ah4(al5 A_0)
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
				throw new DlexParseException("Invalid Median function detected.");
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

		// Token: 0x060034C2 RID: 13506 RVA: 0x001D18C0 File Offset: 0x001D08C0
		internal override ahu md()
		{
			return new ah5(this.a);
		}

		// Token: 0x060034C3 RID: 13507 RVA: 0x001D18E0 File Offset: 0x001D08E0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'i' || A_0[A_1 + 3] == 'I') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 'n' || A_0[A_1 + 5] == 'N') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04001979 RID: 6521
		private new ahq a;
	}
}
