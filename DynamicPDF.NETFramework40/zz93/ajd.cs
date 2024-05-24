using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000541 RID: 1345
	internal class ajd : ait
	{
		// Token: 0x06003617 RID: 13847 RVA: 0x001D80F8 File Offset: 0x001D70F8
		internal ajd(al5 A_0)
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
				throw new DlexParseException("Invalid IIF function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.b = A_0.f();
			if (A_0.b() != ',')
			{
				this.c = null;
			}
			else
			{
				A_0.a(A_0.d() + 1);
				A_0.p();
				this.c = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid IIF function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003618 RID: 13848 RVA: 0x001D81FC File Offset: 0x001D71FC
		internal override bool l4(LayoutWriter A_0)
		{
			bool result;
			if (this.a.l4(A_0))
			{
				result = this.b.l4(A_0);
			}
			else
			{
				result = (this.c.l4(A_0) || this.c.l4(A_0));
			}
			return result;
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x001D8258 File Offset: 0x001D7258
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			bool result;
			if (this.a.lw(A_0, A_1))
			{
				result = this.b.lw(A_0, A_1);
			}
			else
			{
				result = (this.c.lw(A_0, A_1) || this.c.lw(A_0, A_1));
			}
			return result;
		}

		// Token: 0x0600361A RID: 13850 RVA: 0x001D82B8 File Offset: 0x001D72B8
		internal override object ma(LayoutWriter A_0)
		{
			object result;
			if (this.a.l5(A_0))
			{
				result = this.b.ma(A_0);
			}
			else if (this.c == null)
			{
				result = null;
			}
			else
			{
				result = this.c.ma(A_0);
			}
			return result;
		}

		// Token: 0x0600361B RID: 13851 RVA: 0x001D8310 File Offset: 0x001D7310
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object result;
			if (this.a.lx(A_0, A_1))
			{
				result = this.b.l2(A_0, A_1);
			}
			else if (this.c == null)
			{
				result = null;
			}
			else
			{
				result = this.c.l2(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600361C RID: 13852 RVA: 0x001D836B File Offset: 0x001D736B
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
			this.c.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600361D RID: 13853 RVA: 0x001D839C File Offset: 0x001D739C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'f' || A_0[A_1 + 2] == 'F') && (A_0[A_1] == 'I' || A_0[A_1] == 'i');
		}

		// Token: 0x040019CA RID: 6602
		private new ahq a;

		// Token: 0x040019CB RID: 6603
		private new ahq b;

		// Token: 0x040019CC RID: 6604
		private new ahq c;
	}
}
