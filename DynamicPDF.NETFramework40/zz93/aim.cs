using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000526 RID: 1318
	internal class aim : ail
	{
		// Token: 0x0600353F RID: 13631 RVA: 0x001D4448 File Offset: 0x001D3448
		internal aim(al5 A_0)
		{
			A_0.n();
			int num = A_0.d();
			A_0.q();
			this.a = new string(A_0.c(), num, A_0.d() - num);
			A_0.n();
			A_0.p();
		}

		// Token: 0x06003540 RID: 13632 RVA: 0x001D449C File Offset: 0x001D349C
		internal override bool l4(LayoutWriter A_0)
		{
			return false;
		}

		// Token: 0x06003541 RID: 13633 RVA: 0x001D44B0 File Offset: 0x001D34B0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return false;
		}

		// Token: 0x06003542 RID: 13634 RVA: 0x001D44C4 File Offset: 0x001D34C4
		internal override string mb(LayoutWriter A_0)
		{
			return this.a;
		}

		// Token: 0x06003543 RID: 13635 RVA: 0x001D44DC File Offset: 0x001D34DC
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			return this.a;
		}

		// Token: 0x06003544 RID: 13636 RVA: 0x001D44F4 File Offset: 0x001D34F4
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
		}

		// Token: 0x0400199D RID: 6557
		private new string a;
	}
}
