using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000224 RID: 548
	internal class oa : k0
	{
		// Token: 0x060019F0 RID: 6640 RVA: 0x0010EADC File Offset: 0x0010DADC
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x0010EAF4 File Offset: 0x0010DAF4
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x0010EB04 File Offset: 0x0010DB04
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x0010EB1C File Offset: 0x0010DB1C
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x0010EB28 File Offset: 0x0010DB28
		internal override int dg()
		{
			return 122967;
		}

		// Token: 0x060019F5 RID: 6645 RVA: 0x0010EB40 File Offset: 0x0010DB40
		internal override k0 dd()
		{
			return new oa();
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x0010EB58 File Offset: 0x0010DB58
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060019F7 RID: 6647 RVA: 0x0010EB77 File Offset: 0x0010DB77
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x0010EB84 File Offset: 0x0010DB84
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x0010EB9E File Offset: 0x0010DB9E
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x0010EBAC File Offset: 0x0010DBAC
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0010EBC4 File Offset: 0x0010DBC4
		internal override kz dm()
		{
			oa oa = new oa();
			oa.j(this.dr());
			oa.dc(this.db().du());
			oa.a((lk)base.c5().du());
			oa.df(this.b);
			if (base.n() != null)
			{
				oa.c(base.n().p());
			}
			return oa;
		}

		// Token: 0x04000BBE RID: 3006
		private new n5 a = new n5();

		// Token: 0x04000BBF RID: 3007
		private new bool b = false;
	}
}
