using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001AD RID: 429
	internal class k1 : k0
	{
		// Token: 0x0600105C RID: 4188 RVA: 0x000BF0EC File Offset: 0x000BE0EC
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x000BF104 File Offset: 0x000BE104
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x000BF114 File Offset: 0x000BE114
		internal override k0 dd()
		{
			k1 k = new k1();
			k.ab(base.ci());
			return k;
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x000BF13C File Offset: 0x000BE13C
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x000BF154 File Offset: 0x000BE154
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x000BF160 File Offset: 0x000BE160
		internal override int dg()
		{
			return 8101441;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x000BF178 File Offset: 0x000BE178
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x000BF197 File Offset: 0x000BE197
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x000BF1A4 File Offset: 0x000BE1A4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.c(A_0, A_1);
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x000BF1BE File Offset: 0x000BE1BE
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c(A_0, A_1, A_2);
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x000BF1CC File Offset: 0x000BE1CC
		internal override kz dl()
		{
			return base.am();
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x000BF1E4 File Offset: 0x000BE1E4
		internal override kz dm()
		{
			k1 k = new k1();
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

		// Token: 0x040007F5 RID: 2037
		private new n5 a = new n5();

		// Token: 0x040007F6 RID: 2038
		private new bool b = false;
	}
}
