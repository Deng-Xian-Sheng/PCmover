using System;

namespace zz93
{
	// Token: 0x020000D0 RID: 208
	internal class ew : dy
	{
		// Token: 0x06000989 RID: 2441 RVA: 0x0007E0AC File Offset: 0x0007D0AC
		internal ew(ey A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new ex(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0007E0FC File Offset: 0x0007D0FC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0007E114 File Offset: 0x0007D114
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0007E12C File Offset: 0x0007D12C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0007E144 File Offset: 0x0007D144
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0007E150 File Offset: 0x0007D150
		internal override kz cm(ij A_0, kz A_1)
		{
			lp lp = new lp();
			A_0.c(this.ch());
			A_0.a(lp);
			n5 n = (n5)lp.db();
			lp.c5().c().i(n.j());
			A_0.b(lp);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lp.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lp = null;
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
				lp.j(A_1);
				lp.ag(true);
				if (n.v() || lp.c2())
				{
					n.a(gn.c);
					fc[] array = new fc[1];
					it it = new it();
					it.a(new iu(gn.c));
					array[0] = new fc(1982903832, it);
					ig a_2 = new ig(array);
					A_0.a(this.ch().cn(), a_2);
					A_0.a(true);
				}
				i3.a(lp);
				i3.a(lp, A_0);
				m4.a(n, lp.c5(), a_);
				if (lp.c5().ay().e() != null)
				{
					lp.b(mg.a(A_0, lp.c5().ay().e(), A_0.e()));
				}
				base.f(lp, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lp;
		}

		// Token: 0x040004D4 RID: 1236
		private new ey a = null;

		// Token: 0x040004D5 RID: 1237
		private ex b = null;

		// Token: 0x040004D6 RID: 1238
		private bool c = true;
	}
}
