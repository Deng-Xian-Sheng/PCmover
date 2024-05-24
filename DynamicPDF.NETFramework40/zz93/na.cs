using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000200 RID: 512
	internal class na : k0
	{
		// Token: 0x06001737 RID: 5943 RVA: 0x000FA2CC File Offset: 0x000F92CC
		internal override ld dq()
		{
			return this.c;
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x000FA2E4 File Offset: 0x000F92E4
		internal override void dr(ld A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x000FA2F0 File Offset: 0x000F92F0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x000FA308 File Offset: 0x000F9308
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x000FA318 File Offset: 0x000F9318
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x000FA330 File Offset: 0x000F9330
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600173D RID: 5949 RVA: 0x000FA33C File Offset: 0x000F933C
		internal override bool @do()
		{
			return this.b;
		}

		// Token: 0x0600173E RID: 5950 RVA: 0x000FA354 File Offset: 0x000F9354
		internal override void dp(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600173F RID: 5951 RVA: 0x000FA360 File Offset: 0x000F9360
		internal override int dg()
		{
			return 33;
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x000FA374 File Offset: 0x000F9374
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x000FA393 File Offset: 0x000F9393
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x000FA3A0 File Offset: 0x000F93A0
		internal override k0 dd()
		{
			na na = new na();
			na.ab(base.ci());
			na.aa(base.ch());
			return na;
		}

		// Token: 0x06001743 RID: 5955 RVA: 0x000FA3D4 File Offset: 0x000F93D4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			switch (this.de())
			{
			case false:
				result = base.c(A_0, A_1);
				break;
			case true:
				result = base.f(A_0, A_1);
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06001744 RID: 5956 RVA: 0x000FA414 File Offset: 0x000F9414
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			switch (this.de())
			{
			case false:
				base.c(A_0, A_1, A_2);
				break;
			case true:
				base.d(A_0, A_1, A_2);
				break;
			}
		}

		// Token: 0x06001745 RID: 5957 RVA: 0x000FA454 File Offset: 0x000F9454
		internal override kz dm()
		{
			na na = new na();
			na.j(this.dr());
			na.dc(this.db().du());
			na.a((lk)base.c5().du());
			na.dp(this.b);
			if (base.n() != null)
			{
				na.c(base.n().p());
			}
			return na;
		}

		// Token: 0x04000A9B RID: 2715
		private new n5 a = new n5();

		// Token: 0x04000A9C RID: 2716
		private new bool b = false;

		// Token: 0x04000A9D RID: 2717
		private new ld c = new ld();

		// Token: 0x04000A9E RID: 2718
		private new bool d = true;
	}
}
