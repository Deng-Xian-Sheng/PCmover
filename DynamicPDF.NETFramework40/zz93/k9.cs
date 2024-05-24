using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001B5 RID: 437
	internal class k9 : k0
	{
		// Token: 0x060010DD RID: 4317 RVA: 0x000C20AC File Offset: 0x000C10AC
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x000C20C4 File Offset: 0x000C10C4
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x000C20D4 File Offset: 0x000C10D4
		internal override k0 dd()
		{
			k9 k = new k9();
			k.ab(base.ci());
			k.aa(base.ch());
			return k;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x000C2108 File Offset: 0x000C1108
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x000C2120 File Offset: 0x000C1120
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x000C212C File Offset: 0x000C112C
		internal override int dg()
		{
			return 46073;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x000C2144 File Offset: 0x000C1144
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x000C2163 File Offset: 0x000C1163
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x000C2170 File Offset: 0x000C1170
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x000C218A File Offset: 0x000C118A
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x000C2198 File Offset: 0x000C1198
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x000C21B0 File Offset: 0x000C11B0
		internal override kz dm()
		{
			k9 k = new k9();
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

		// Token: 0x04000820 RID: 2080
		private new n5 a = new n5();

		// Token: 0x04000821 RID: 2081
		private new bool b = false;
	}
}
