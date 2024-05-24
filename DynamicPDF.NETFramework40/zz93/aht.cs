using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000509 RID: 1289
	internal class aht : ahr
	{
		// Token: 0x06003474 RID: 13428 RVA: 0x001CFABC File Offset: 0x001CEABC
		internal aht(al5 A_0)
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

		// Token: 0x06003475 RID: 13429 RVA: 0x001CFBD8 File Offset: 0x001CEBD8
		internal override ahu md()
		{
			return new ahv(this.a);
		}

		// Token: 0x06003476 RID: 13430 RVA: 0x001CFBF8 File Offset: 0x001CEBF8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1] == 'C' || A_0[A_1] == 'c');
		}

		// Token: 0x04001959 RID: 6489
		private new ahq a;
	}
}
