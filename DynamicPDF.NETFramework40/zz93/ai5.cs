using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000539 RID: 1337
	internal class ai5 : aij
	{
		// Token: 0x060035DA RID: 13786 RVA: 0x001D6C40 File Offset: 0x001D5C40
		internal ai5(al5 A_0)
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
				throw new DlexParseException("Invalid Format function detected.");
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
				throw new DlexParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060035DB RID: 13787 RVA: 0x001D6D20 File Offset: 0x001D5D20
		internal ai5(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x060035DC RID: 13788 RVA: 0x001D6D88 File Offset: 0x001D5D88
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x060035DD RID: 13789 RVA: 0x001D6DB8 File Offset: 0x001D5DB8
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x060035DE RID: 13790 RVA: 0x001D6DEC File Offset: 0x001D5DEC
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Divide(this.a.l7(A_0), this.b.l7(A_0));
		}

		// Token: 0x060035DF RID: 13791 RVA: 0x001D6E1C File Offset: 0x001D5E1C
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Divide(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1));
		}

		// Token: 0x060035E0 RID: 13792 RVA: 0x001D6E4D File Offset: 0x001D5E4D
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035E1 RID: 13793 RVA: 0x001D6E70 File Offset: 0x001D5E70
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 2] == 'v' || A_0[A_1 + 2] == 'V') && (A_0[A_1 + 3] == 'i' || A_0[A_1 + 3] == 'I') && (A_0[A_1 + 4] == 'd' || A_0[A_1 + 4] == 'D') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1] == 'D' || A_0[A_1] == 'd') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I');
		}

		// Token: 0x040019B9 RID: 6585
		private new ahq a;

		// Token: 0x040019BA RID: 6586
		private new ahq b;
	}
}
