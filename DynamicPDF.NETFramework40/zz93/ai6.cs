using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200053A RID: 1338
	internal class ai6 : aih
	{
		// Token: 0x060035E2 RID: 13794 RVA: 0x001D6EF8 File Offset: 0x001D5EF8
		internal ai6(al5 A_0)
		{
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
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Equal function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.b = A_0.g();
			}
			else
			{
				this.b = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Equal function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035E3 RID: 13795 RVA: 0x001D6FD8 File Offset: 0x001D5FD8
		internal ai6(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x060035E4 RID: 13796 RVA: 0x001D7040 File Offset: 0x001D6040
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x060035E5 RID: 13797 RVA: 0x001D7070 File Offset: 0x001D6070
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x060035E6 RID: 13798 RVA: 0x001D70A4 File Offset: 0x001D60A4
		internal override bool l5(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.l7(A_0), this.b.l7(A_0)) == 0;
		}

		// Token: 0x060035E7 RID: 13799 RVA: 0x001D70D8 File Offset: 0x001D60D8
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return decimal.Compare(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1)) == 0;
		}

		// Token: 0x060035E8 RID: 13800 RVA: 0x001D710C File Offset: 0x001D610C
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x001D7130 File Offset: 0x001D6130
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 'q' || A_0[A_1 + 1] == 'Q') && (A_0[A_1] == 'E' || A_0[A_1] == 'e');
		}

		// Token: 0x040019BB RID: 6587
		private new ahq a;

		// Token: 0x040019BC RID: 6588
		private new ahq b;
	}
}
