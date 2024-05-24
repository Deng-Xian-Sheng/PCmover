using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200021B RID: 539
	internal class n1 : k0
	{
		// Token: 0x0600190F RID: 6415 RVA: 0x001082D0 File Offset: 0x001072D0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001910 RID: 6416 RVA: 0x001082E8 File Offset: 0x001072E8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001911 RID: 6417 RVA: 0x001082F8 File Offset: 0x001072F8
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001912 RID: 6418 RVA: 0x00108310 File Offset: 0x00107310
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001913 RID: 6419 RVA: 0x0010831C File Offset: 0x0010731C
		internal override int dg()
		{
			return 1690;
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x00108334 File Offset: 0x00107334
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x00108353 File Offset: 0x00107353
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001916 RID: 6422 RVA: 0x00108360 File Offset: 0x00107360
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x0010837C File Offset: 0x0010737C
		internal override k0 dd()
		{
			return new n1();
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x00108393 File Offset: 0x00107393
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x001083A0 File Offset: 0x001073A0
		internal override kz dm()
		{
			n1 n = new n1();
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

		// Token: 0x04000B75 RID: 2933
		private new n5 a = new n5();

		// Token: 0x04000B76 RID: 2934
		private new bool b = false;
	}
}
