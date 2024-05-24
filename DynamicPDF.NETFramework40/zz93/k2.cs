using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001AE RID: 430
	internal class k2 : k0
	{
		// Token: 0x06001069 RID: 4201 RVA: 0x000BF27C File Offset: 0x000BE27C
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x000BF294 File Offset: 0x000BE294
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x000BF2A4 File Offset: 0x000BE2A4
		internal override k0 dd()
		{
			k2 k = new k2();
			k.ab(base.ci());
			k.aa(base.ch());
			return k;
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x000BF2D8 File Offset: 0x000BE2D8
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x000BF2F0 File Offset: 0x000BE2F0
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x000BF2FC File Offset: 0x000BE2FC
		internal override int dg()
		{
			return 627436437;
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x000BF314 File Offset: 0x000BE314
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x000BF333 File Offset: 0x000BE333
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x000BF340 File Offset: 0x000BE340
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x000BF35A File Offset: 0x000BE35A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x000BF368 File Offset: 0x000BE368
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x000BF380 File Offset: 0x000BE380
		internal override kz dm()
		{
			k2 k = new k2();
			k.j(this.dr());
			k.dc(this.db().du());
			k.a((lk)base.c5().du());
			k.df(this.b);
			if (base.n() != null)
			{
				k.c(base.n().p());
			}
			return k;
		}

		// Token: 0x040007F7 RID: 2039
		private new n5 a = new n5();

		// Token: 0x040007F8 RID: 2040
		private new bool b = false;
	}
}
