using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200053E RID: 1342
	internal class aja : aih
	{
		// Token: 0x06003600 RID: 13824 RVA: 0x001D7A84 File Offset: 0x001D6A84
		internal aja(al5 A_0)
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
				throw new DlexParseException("Invalid Greater Than Equal function detected.");
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
				throw new DlexParseException("Invalid Greater Than Equal function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003601 RID: 13825 RVA: 0x001D7B64 File Offset: 0x001D6B64
		internal aja(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003602 RID: 13826 RVA: 0x001D7BCC File Offset: 0x001D6BCC
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003603 RID: 13827 RVA: 0x001D7BFC File Offset: 0x001D6BFC
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003604 RID: 13828 RVA: 0x001D7C30 File Offset: 0x001D6C30
		internal override bool l5(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.l7(A_0), this.b.l7(A_0)) >= 0;
		}

		// Token: 0x06003605 RID: 13829 RVA: 0x001D7C68 File Offset: 0x001D6C68
		internal override bool lx(LayoutWriter A_0, akk A_1)
		{
			return decimal.Compare(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1)) >= 0;
		}

		// Token: 0x06003606 RID: 13830 RVA: 0x001D7C9F File Offset: 0x001D6C9F
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003607 RID: 13831 RVA: 0x001D7CC0 File Offset: 0x001D6CC0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1] == 'G' || A_0[A_1] == 'g');
		}

		// Token: 0x040019C5 RID: 6597
		private new ahq a;

		// Token: 0x040019C6 RID: 6598
		private new ahq b;
	}
}
