using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000518 RID: 1304
	internal class ah8 : ahr
	{
		// Token: 0x060034DA RID: 13530 RVA: 0x001D2648 File Offset: 0x001D1648
		internal ah8(al5 A_0)
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
				throw new DlexParseException("Invalid Mode function detected.");
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

		// Token: 0x060034DB RID: 13531 RVA: 0x001D2740 File Offset: 0x001D1740
		internal override ahu md()
		{
			return new ah9(this.a);
		}

		// Token: 0x060034DC RID: 13532 RVA: 0x001D2760 File Offset: 0x001D1760
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04001984 RID: 6532
		private new ahq a;
	}
}
