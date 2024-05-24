using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000510 RID: 1296
	internal class ah0 : ahr
	{
		// Token: 0x060034AB RID: 13483 RVA: 0x001D0A48 File Offset: 0x001CFA48
		internal ah0(al5 A_0)
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
				throw new DlexParseException("Invalid Max function detected.");
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

		// Token: 0x060034AC RID: 13484 RVA: 0x001D0B64 File Offset: 0x001CFB64
		internal override ahu md()
		{
			return new ah1(this.a);
		}

		// Token: 0x060034AD RID: 13485 RVA: 0x001D0B84 File Offset: 0x001CFB84
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 'x' || A_0[A_1 + 2] == 'X') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x0400196E RID: 6510
		private new ahq a;
	}
}
