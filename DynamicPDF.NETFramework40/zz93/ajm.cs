using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200054A RID: 1354
	internal class ajm : aij
	{
		// Token: 0x06003663 RID: 13923 RVA: 0x001D987C File Offset: 0x001D887C
		internal ajm(al5 A_0)
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

		// Token: 0x06003664 RID: 13924 RVA: 0x001D995C File Offset: 0x001D895C
		internal ajm(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003665 RID: 13925 RVA: 0x001D99C4 File Offset: 0x001D89C4
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003666 RID: 13926 RVA: 0x001D99F4 File Offset: 0x001D89F4
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003667 RID: 13927 RVA: 0x001D9A28 File Offset: 0x001D8A28
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Multiply(this.a.l7(A_0), this.b.l7(A_0));
		}

		// Token: 0x06003668 RID: 13928 RVA: 0x001D9A58 File Offset: 0x001D8A58
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Multiply(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1));
		}

		// Token: 0x06003669 RID: 13929 RVA: 0x001D9A89 File Offset: 0x001D8A89
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x001D9AAC File Offset: 0x001D8AAC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 8 && (A_0[A_1 + 7] == 'y' || A_0[A_1 + 7] == 'Y') && (A_0[A_1] == 'M' || A_0[A_1] == 'm') && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'l' || A_0[A_1 + 2] == 'L') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1 + 4] == 'i' || A_0[A_1 + 4] == 'I') && (A_0[A_1 + 5] == 'p' || A_0[A_1 + 5] == 'P') && (A_0[A_1 + 6] == 'l' || A_0[A_1 + 6] == 'L');
		}

		// Token: 0x040019DA RID: 6618
		private new ahq a;

		// Token: 0x040019DB RID: 6619
		private new ahq b;
	}
}
