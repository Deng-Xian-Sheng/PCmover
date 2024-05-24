using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001CF RID: 463
	internal class lz : k0
	{
		// Token: 0x060013A3 RID: 5027 RVA: 0x000DDB18 File Offset: 0x000DCB18
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x000DDB30 File Offset: 0x000DCB30
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x000DDB40 File Offset: 0x000DCB40
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x000DDB58 File Offset: 0x000DCB58
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x000DDB64 File Offset: 0x000DCB64
		internal override int dg()
		{
			return 1352;
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x000DDB7C File Offset: 0x000DCB7C
		internal override k0 dd()
		{
			return new lz();
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x000DDB94 File Offset: 0x000DCB94
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x000DDBB3 File Offset: 0x000DCBB3
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x000DDBC0 File Offset: 0x000DCBC0
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x000DDBDA File Offset: 0x000DCBDA
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x000DDBE8 File Offset: 0x000DCBE8
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x000DDC00 File Offset: 0x000DCC00
		internal override kz dm()
		{
			lz lz = new lz();
			lz.j(this.dr());
			lz.dc(this.db().du());
			lz.a((lk)base.c5().du());
			lz.df(this.b);
			if (base.n() != null)
			{
				lz.c(base.n().p());
			}
			return lz;
		}

		// Token: 0x0400094A RID: 2378
		private new n5 a = new n5();

		// Token: 0x0400094B RID: 2379
		private new bool b = false;
	}
}
