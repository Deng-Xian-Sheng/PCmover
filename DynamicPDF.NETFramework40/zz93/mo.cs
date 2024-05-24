using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001EA RID: 490
	internal class mo : k0
	{
		// Token: 0x06001530 RID: 5424 RVA: 0x000EB2C0 File Offset: 0x000EA2C0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x000EB2D8 File Offset: 0x000EA2D8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x000EB2E8 File Offset: 0x000EA2E8
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x000EB300 File Offset: 0x000EA300
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x000EB30C File Offset: 0x000EA30C
		internal override int dg()
		{
			return 220754;
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x000EB324 File Offset: 0x000EA324
		internal override k0 dd()
		{
			return new mo();
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x000EB33C File Offset: 0x000EA33C
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x000EB35B File Offset: 0x000EA35B
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x000EB368 File Offset: 0x000EA368
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x000EB382 File Offset: 0x000EA382
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x000EB390 File Offset: 0x000EA390
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x000EB3A8 File Offset: 0x000EA3A8
		internal override kz dm()
		{
			mo mo = new mo();
			mo.j(this.dr());
			mo.dc(this.db().du());
			mo.a((lk)base.c5().du());
			mo.df(this.b);
			if (base.n() != null)
			{
				mo.c(base.n().p());
			}
			return mo;
		}

		// Token: 0x040009F0 RID: 2544
		private new n5 a = new n5();

		// Token: 0x040009F1 RID: 2545
		private new bool b = false;
	}
}
