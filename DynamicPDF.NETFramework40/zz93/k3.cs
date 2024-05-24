using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001AF RID: 431
	internal class k3 : k0
	{
		// Token: 0x06001076 RID: 4214 RVA: 0x000BF418 File Offset: 0x000BE418
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x000BF430 File Offset: 0x000BE430
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x000BF440 File Offset: 0x000BE440
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x000BF458 File Offset: 0x000BE458
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x000BF464 File Offset: 0x000BE464
		internal override k0 dd()
		{
			return new k3();
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x000BF47C File Offset: 0x000BE47C
		internal override int dg()
		{
			return 142298369;
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x000BF494 File Offset: 0x000BE494
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x000BF4B3 File Offset: 0x000BE4B3
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x000BF4C0 File Offset: 0x000BE4C0
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			if (this.b)
			{
				result = base.f(A_0, A_1);
			}
			else
			{
				result = base.c(A_0, A_1);
			}
			return result;
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x000BF4F4 File Offset: 0x000BE4F4
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			if (this.b)
			{
				base.d(A_0, A_1, A_2);
			}
			else
			{
				base.c(A_0, A_1, A_2);
			}
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x000BF528 File Offset: 0x000BE528
		internal override kz dm()
		{
			k3 k = new k3();
			k.j(this.dr());
			k.dc(this.db().du());
			k.a((lk)base.c5().du());
			k.df(this.b);
			k.c(base.n().p());
			return k;
		}

		// Token: 0x040007F9 RID: 2041
		private new n5 a = new n5();

		// Token: 0x040007FA RID: 2042
		private new bool b = true;
	}
}
