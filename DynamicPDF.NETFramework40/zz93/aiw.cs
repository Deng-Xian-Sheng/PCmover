using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000530 RID: 1328
	internal class aiw : aij
	{
		// Token: 0x06003594 RID: 13716 RVA: 0x001D5534 File Offset: 0x001D4534
		internal aiw(al5 A_0)
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
				throw new DlexParseException("Invalid Add function detected.");
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
				throw new DlexParseException("Invalid Add function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003595 RID: 13717 RVA: 0x001D5614 File Offset: 0x001D4614
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003596 RID: 13718 RVA: 0x001D5644 File Offset: 0x001D4644
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003597 RID: 13719 RVA: 0x001D5678 File Offset: 0x001D4678
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Add(this.a.l7(A_0), this.b.l7(A_0));
		}

		// Token: 0x06003598 RID: 13720 RVA: 0x001D56A8 File Offset: 0x001D46A8
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Add(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1));
		}

		// Token: 0x06003599 RID: 13721 RVA: 0x001D56D9 File Offset: 0x001D46D9
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600359A RID: 13722 RVA: 0x001D56FC File Offset: 0x001D46FC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'd' || A_0[A_1 + 1] == 'D') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1] == 'A' || A_0[A_1] == 'a');
		}

		// Token: 0x040019AB RID: 6571
		private new ahq a;

		// Token: 0x040019AC RID: 6572
		private new ahq b;
	}
}
