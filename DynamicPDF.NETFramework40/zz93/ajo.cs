using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200054C RID: 1356
	internal class ajo : aih
	{
		// Token: 0x06003673 RID: 13939 RVA: 0x001D9D38 File Offset: 0x001D8D38
		internal ajo(al5 A_0)
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
				throw new DlexParseException("Invalid NotEq function detected.");
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
				throw new DlexParseException("Invalid NotEq function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x001D9E18 File Offset: 0x001D8E18
		internal ajo(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003675 RID: 13941 RVA: 0x001D9E80 File Offset: 0x001D8E80
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x001D9EB0 File Offset: 0x001D8EB0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003677 RID: 13943 RVA: 0x001D9EE4 File Offset: 0x001D8EE4
		internal override bool l5(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.l7(A_0), this.b.l7(A_0)) != 0;
		}

		// Token: 0x06003678 RID: 13944 RVA: 0x001D9F1C File Offset: 0x001D8F1C
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return decimal.Compare(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1)) != 0;
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x001D9F53 File Offset: 0x001D8F53
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600367A RID: 13946 RVA: 0x001D9F74 File Offset: 0x001D8F74
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 2] == 't' || A_0[A_1 + 2] == 'T') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 3] == 'E' || A_0[A_1 + 3] == 'e') && (A_0[A_1 + 4] == 'q' || A_0[A_1 + 4] == 'Q') && (A_0[A_1] == 'N' || A_0[A_1] == 'n');
		}

		// Token: 0x040019DD RID: 6621
		private new ahq a;

		// Token: 0x040019DE RID: 6622
		private new ahq b;
	}
}
