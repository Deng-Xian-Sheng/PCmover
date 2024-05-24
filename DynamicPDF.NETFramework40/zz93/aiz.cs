using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000533 RID: 1331
	internal class aiz : ail
	{
		// Token: 0x060035AA RID: 13738 RVA: 0x001D5BF0 File Offset: 0x001D4BF0
		internal aiz(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid StringAdd function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.b = A_0.f();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid StringAdd function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035AB RID: 13739 RVA: 0x001D5C94 File Offset: 0x001D4C94
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x060035AC RID: 13740 RVA: 0x001D5CC4 File Offset: 0x001D4CC4
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x060035AD RID: 13741 RVA: 0x001D5CF8 File Offset: 0x001D4CF8
		internal override string mb(LayoutWriter A_0)
		{
			return this.a.mb(A_0) + this.b.mb(A_0);
		}

		// Token: 0x060035AE RID: 13742 RVA: 0x001D5D28 File Offset: 0x001D4D28
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a.mb(A_0) + this.b.mb(A_0);
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x001D5D57 File Offset: 0x001D4D57
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035B0 RID: 13744 RVA: 0x001D5D78 File Offset: 0x001D4D78
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'c' || A_0[A_1 + 3] == 'C') && (A_0[A_1 + 4] == 'a' || A_0[A_1 + 4] == 'A') && (A_0[A_1 + 5] == 't' || A_0[A_1 + 5] == 'T') && (A_0[A_1] == 'C' || A_0[A_1] == 'c');
		}

		// Token: 0x040019B0 RID: 6576
		private new ahq a;

		// Token: 0x040019B1 RID: 6577
		private new ahq b;
	}
}
