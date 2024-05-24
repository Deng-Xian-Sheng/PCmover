using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000548 RID: 1352
	internal class ajk : aij
	{
		// Token: 0x06003654 RID: 13908 RVA: 0x001D947C File Offset: 0x001D847C
		internal ajk(al5 A_0)
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
				throw new DlexParseException("Invalid Mod function detected.");
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
				throw new DlexParseException("Invalid Mod function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003655 RID: 13909 RVA: 0x001D955C File Offset: 0x001D855C
		internal ajk(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003656 RID: 13910 RVA: 0x001D95C4 File Offset: 0x001D85C4
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003657 RID: 13911 RVA: 0x001D95F4 File Offset: 0x001D85F4
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003658 RID: 13912 RVA: 0x001D9628 File Offset: 0x001D8628
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Remainder(this.a.l7(A_0), this.b.l7(A_0));
		}

		// Token: 0x06003659 RID: 13913 RVA: 0x001D9658 File Offset: 0x001D8658
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Remainder(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1));
		}

		// Token: 0x0600365A RID: 13914 RVA: 0x001D9689 File Offset: 0x001D8689
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600365B RID: 13915 RVA: 0x001D96AC File Offset: 0x001D86AC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x040019D7 RID: 6615
		private new ahq a;

		// Token: 0x040019D8 RID: 6616
		private new ahq b;
	}
}
