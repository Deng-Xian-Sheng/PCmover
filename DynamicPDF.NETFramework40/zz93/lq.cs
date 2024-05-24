using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C6 RID: 454
	internal class lq : k0
	{
		// Token: 0x0600131E RID: 4894 RVA: 0x000DA5DC File Offset: 0x000D95DC
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x000DA5F4 File Offset: 0x000D95F4
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x000DA604 File Offset: 0x000D9604
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x000DA61C File Offset: 0x000D961C
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001322 RID: 4898 RVA: 0x000DA628 File Offset: 0x000D9628
		internal override int dg()
		{
			return 2204613;
		}

		// Token: 0x06001323 RID: 4899 RVA: 0x000DA640 File Offset: 0x000D9640
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x000DA65F File Offset: 0x000D965F
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x000DA66C File Offset: 0x000D966C
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x000DA688 File Offset: 0x000D9688
		internal override k0 dd()
		{
			return new lq();
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x000DA69F File Offset: 0x000D969F
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x000DA6AC File Offset: 0x000D96AC
		internal override kz dm()
		{
			lq lq = new lq();
			lq.j(this.dr());
			lq.dc(this.db().du());
			lq.a((lk)base.c5().du());
			lq.df(this.b);
			if (base.n() != null)
			{
				lq.c(base.n().p());
			}
			return lq;
		}

		// Token: 0x04000933 RID: 2355
		private new n5 a = new n5();

		// Token: 0x04000934 RID: 2356
		private new bool b = false;
	}
}
