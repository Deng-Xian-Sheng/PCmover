using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000210 RID: 528
	internal class nq : k0
	{
		// Token: 0x06001830 RID: 6192 RVA: 0x001011F0 File Offset: 0x001001F0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x00101208 File Offset: 0x00100208
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x00101218 File Offset: 0x00100218
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x00101230 File Offset: 0x00100230
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x0010123C File Offset: 0x0010023C
		internal override int dg()
		{
			return 235744;
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x00101254 File Offset: 0x00100254
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x00101273 File Offset: 0x00100273
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x00101280 File Offset: 0x00100280
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x0010129C File Offset: 0x0010029C
		internal override k0 dd()
		{
			return new nq();
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x001012B3 File Offset: 0x001002B3
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x001012C0 File Offset: 0x001002C0
		internal override kz dm()
		{
			nq nq = new nq();
			nq.j(this.dr());
			nq.dc(this.db().du());
			nq.a((lk)base.c5().du());
			nq.df(this.b);
			if (base.n() != null)
			{
				nq.c(base.n().p());
			}
			return nq;
		}

		// Token: 0x04000ADF RID: 2783
		private new n5 a = new n5();

		// Token: 0x04000AE0 RID: 2784
		private new bool b = false;

		// Token: 0x04000AE1 RID: 2785
		private new x5 c = x5.c();
	}
}
