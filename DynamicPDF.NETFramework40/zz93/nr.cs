using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000211 RID: 529
	internal class nr : k0
	{
		// Token: 0x0600183C RID: 6204 RVA: 0x00101364 File Offset: 0x00100364
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x0010137C File Offset: 0x0010037C
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x0010138C File Offset: 0x0010038C
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x001013A4 File Offset: 0x001003A4
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x001013B0 File Offset: 0x001003B0
		internal override int dg()
		{
			return 137440;
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x001013C8 File Offset: 0x001003C8
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x001013E7 File Offset: 0x001003E7
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x001013F4 File Offset: 0x001003F4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x00101410 File Offset: 0x00100410
		internal override k0 dd()
		{
			nr nr = new nr();
			nr.ab(base.ci());
			nr.aa(base.ch());
			return nr;
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x00101443 File Offset: 0x00100443
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x00101450 File Offset: 0x00100450
		internal override kz dm()
		{
			nr nr = new nr();
			nr.j(this.dr());
			nr.dc(this.db().du());
			nr.a((lk)base.c5().du());
			nr.df(this.b);
			if (base.n() != null)
			{
				nr.c(base.n().p());
			}
			return nr;
		}

		// Token: 0x04000AE2 RID: 2786
		private new n5 a = new n5();

		// Token: 0x04000AE3 RID: 2787
		private new bool b = false;

		// Token: 0x04000AE4 RID: 2788
		private new x5 c = x5.c();

		// Token: 0x04000AE5 RID: 2789
		private new x5 d = x5.c();
	}
}
