using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000222 RID: 546
	internal class n8 : k0
	{
		// Token: 0x060019DC RID: 6620 RVA: 0x0010E548 File Offset: 0x0010D548
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x0010E560 File Offset: 0x0010D560
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x0010E570 File Offset: 0x0010D570
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x0010E588 File Offset: 0x0010D588
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x0010E594 File Offset: 0x0010D594
		internal override int dg()
		{
			return 35;
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x0010E5A8 File Offset: 0x0010D5A8
		internal override k0 dd()
		{
			return new n8();
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x0010E5C0 File Offset: 0x0010D5C0
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x0010E5DF File Offset: 0x0010D5DF
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x0010E5EC File Offset: 0x0010D5EC
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x0010E606 File Offset: 0x0010D606
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x0010E614 File Offset: 0x0010D614
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x0010E62C File Offset: 0x0010D62C
		internal override kz dm()
		{
			n8 n = new n8();
			n.j(this.dr());
			n.dc(this.db().du());
			n.a((lk)base.c5().du());
			n.df(this.b);
			if (base.n() != null)
			{
				n.c(base.n().p());
			}
			return n;
		}

		// Token: 0x04000BBC RID: 3004
		private new n5 a = new n5();

		// Token: 0x04000BBD RID: 3005
		private new bool b = false;
	}
}
