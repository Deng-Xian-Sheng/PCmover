using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200037A RID: 890
	internal class xd
	{
		// Token: 0x060025D7 RID: 9687 RVA: 0x0016195F File Offset: 0x0016095F
		internal xd(xc A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060025D8 RID: 9688 RVA: 0x00161971 File Offset: 0x00160971
		internal xd(xg A_0, xc A_1)
		{
			this.a = A_0;
			this.b = A_0;
			this.c = A_1;
		}

		// Token: 0x060025D9 RID: 9689 RVA: 0x00161994 File Offset: 0x00160994
		internal virtual x5 f6(PageWriter A_0, x5 A_1)
		{
			for (xg xg = this.a; xg != null; xg = xg.e())
			{
				xg.ga(A_0, A_1);
				A_1 = x5.f(A_1, x5.f(xg.d(), this.c.c()));
			}
			return A_1;
		}

		// Token: 0x060025DA RID: 9690 RVA: 0x001619EC File Offset: 0x001609EC
		internal virtual x5 f7(PageWriter A_0, x5 A_1, x5 A_2)
		{
			for (xg xg = this.a; xg != null; xg = xg.e())
			{
				xg.f9(A_0, A_1, A_2);
				A_2 = x5.f(A_2, x5.f(xg.d(), this.c.c()));
			}
			return A_2;
		}

		// Token: 0x060025DB RID: 9691 RVA: 0x00161A44 File Offset: 0x00160A44
		internal void a(xg A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
		}

		// Token: 0x060025DC RID: 9692 RVA: 0x00161A90 File Offset: 0x00160A90
		internal xg e()
		{
			return this.a;
		}

		// Token: 0x060025DD RID: 9693 RVA: 0x00161AA8 File Offset: 0x00160AA8
		internal void b(xg A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060025DE RID: 9694 RVA: 0x00161AB4 File Offset: 0x00160AB4
		internal virtual xd f8(bool A_0)
		{
			return this.f();
		}

		// Token: 0x060025DF RID: 9695 RVA: 0x00161ACC File Offset: 0x00160ACC
		internal virtual xd f()
		{
			xd xd = new xd(this.c);
			for (xg xg = this.a; xg != null; xg = xg.e())
			{
				xd.a(xg.f());
			}
			return xd;
		}

		// Token: 0x04001094 RID: 4244
		private xg a;

		// Token: 0x04001095 RID: 4245
		private xg b;

		// Token: 0x04001096 RID: 4246
		private xc c;
	}
}
