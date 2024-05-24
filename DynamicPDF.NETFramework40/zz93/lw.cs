using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001CC RID: 460
	internal class lw : k0
	{
		// Token: 0x0600137E RID: 4990 RVA: 0x000DD5B8 File Offset: 0x000DC5B8
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x000DD5D0 File Offset: 0x000DC5D0
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x000DD5E0 File Offset: 0x000DC5E0
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x000DD5F8 File Offset: 0x000DC5F8
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x000DD604 File Offset: 0x000DC604
		internal override int dg()
		{
			return 154805;
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x000DD61C File Offset: 0x000DC61C
		internal override k0 dd()
		{
			return new lw();
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x000DD634 File Offset: 0x000DC634
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x000DD653 File Offset: 0x000DC653
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x000DD660 File Offset: 0x000DC660
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x000DD67A File Offset: 0x000DC67A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x000DD688 File Offset: 0x000DC688
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x000DD6A0 File Offset: 0x000DC6A0
		internal override kz dm()
		{
			lw lw = new lw();
			lw.j(this.dr());
			lw.dc(this.db().du());
			lw.a((lk)base.c5().du());
			lw.df(this.b);
			if (base.n() != null)
			{
				lw.c(base.n().p());
			}
			return lw;
		}

		// Token: 0x04000944 RID: 2372
		private new n5 a = new n5();

		// Token: 0x04000945 RID: 2373
		private new bool b = false;
	}
}
