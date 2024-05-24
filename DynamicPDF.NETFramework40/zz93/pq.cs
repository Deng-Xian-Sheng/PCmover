using System;

namespace zz93
{
	// Token: 0x02000258 RID: 600
	internal class pq : dy
	{
		// Token: 0x06001B53 RID: 6995 RVA: 0x0011A30C File Offset: 0x0011930C
		internal pq(pr A_0)
		{
			this.a = A_0;
			this.b = new kl(this.a.cn());
		}

		// Token: 0x06001B54 RID: 6996 RVA: 0x0011A35C File Offset: 0x0011935C
		internal pq(pr A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kl(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001B55 RID: 6997 RVA: 0x0011A3B4 File Offset: 0x001193B4
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001B56 RID: 6998 RVA: 0x0011A3CC File Offset: 0x001193CC
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001B57 RID: 6999 RVA: 0x0011A3E4 File Offset: 0x001193E4
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001B58 RID: 7000 RVA: 0x0011A3FC File Offset: 0x001193FC
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001B59 RID: 7001 RVA: 0x0011A408 File Offset: 0x00119408
		internal override bool cp()
		{
			return true;
		}

		// Token: 0x06001B5A RID: 7002 RVA: 0x0011A41C File Offset: 0x0011941C
		internal override bool ck()
		{
			return this.d;
		}

		// Token: 0x06001B5B RID: 7003 RVA: 0x0011A434 File Offset: 0x00119434
		internal override void cl(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001B5C RID: 7004 RVA: 0x0011A440 File Offset: 0x00119440
		internal override kz cm(ij A_0, kz A_1)
		{
			np np = new np();
			A_0.c(this.ch());
			A_0.a(np);
			n5 n = (n5)np.db();
			np.c5().c().i(n.j());
			if (this.d)
			{
				A_0.b(np);
			}
			bool flag = true;
			bool a_ = false;
			lk lk = np.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					np = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				np.j(A_1);
				if (lk.ay().e() != null)
				{
					np.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				A_0.a(true);
				hd a_2 = i3.b(np);
				ig a_3 = new ig(new fc[]
				{
					new fc(6968946, a_2)
				});
				A_0.a(this.ch().cn(), a_3);
				((n5)np.db()).a().a(f7.k);
				i3.a(np);
				i3.a(np, A_0);
				m4.a(n, lk, a_);
				base.e(np, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return np;
		}

		// Token: 0x04000C57 RID: 3159
		private new pr a = null;

		// Token: 0x04000C58 RID: 3160
		private kl b = null;

		// Token: 0x04000C59 RID: 3161
		private bool c = false;

		// Token: 0x04000C5A RID: 3162
		private new bool d = true;
	}
}
