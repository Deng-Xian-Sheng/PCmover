using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200054B RID: 1355
	internal class ajn : aij
	{
		// Token: 0x0600366B RID: 13931 RVA: 0x001D9B5C File Offset: 0x001D8B5C
		internal ajn(al5 A_0)
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
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Negate function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600366C RID: 13932 RVA: 0x001D9BDE File Offset: 0x001D8BDE
		internal ajn(ArrayList A_0)
		{
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x001D9C14 File Offset: 0x001D8C14
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x001D9C34 File Offset: 0x001D8C34
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x0600366F RID: 13935 RVA: 0x001D9C54 File Offset: 0x001D8C54
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Negate(this.a.l7(A_0));
		}

		// Token: 0x06003670 RID: 13936 RVA: 0x001D9C78 File Offset: 0x001D8C78
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Negate(this.a.lz(A_0, A_1));
		}

		// Token: 0x06003671 RID: 13937 RVA: 0x001D9C9C File Offset: 0x001D8C9C
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003672 RID: 13938 RVA: 0x001D9CB0 File Offset: 0x001D8CB0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 6 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'g' || A_0[A_1 + 2] == 'G') && (A_0[A_1 + 3] == 'a' || A_0[A_1 + 3] == 'A') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1] == 'N' || A_0[A_1] == 'n');
		}

		// Token: 0x040019DC RID: 6620
		private new ahq a;
	}
}
