using System;

namespace zz93
{
	// Token: 0x02000243 RID: 579
	internal class o5 : dy
	{
		// Token: 0x06001AB1 RID: 6833 RVA: 0x001159C4 File Offset: 0x001149C4
		internal o5(pb A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new o6(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x00115A14 File Offset: 0x00114A14
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x00115A2C File Offset: 0x00114A2C
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x00115A38 File Offset: 0x00114A38
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x00115A50 File Offset: 0x00114A50
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x00115A68 File Offset: 0x00114A68
		private void a(ij A_0)
		{
			if (this.a.a() != ea.a)
			{
				it it = new it();
				switch (this.a.a())
				{
				case ea.b:
					it.a(new iu(gn.a));
					break;
				case ea.c:
					it.a(new iu(gn.b));
					break;
				case ea.d:
					it.a(new iu(gn.c));
					break;
				case ea.g:
					it.a(new iu(gn.d));
					break;
				}
				fc[] array = new fc[1];
				if (it != null)
				{
					array[0] = new fc(1982903832, it);
				}
				ig a_ = new ig(array);
				A_0.a(this.ch().cn(), a_);
				A_0.a(true);
			}
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x00115B40 File Offset: 0x00114B40
		internal override kz cm(ij A_0, kz A_1)
		{
			na na = new na();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(na);
			n5 n = (n5)na.db();
			na.c5().c().i(n.j());
			A_0.b(na);
			bool flag = true;
			bool flag2 = false;
			lk lk = na.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					na = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					flag2 = true;
					break;
				}
			}
			if (this.cg().h() == 0 && !lk.d() && flag)
			{
				na.af(true);
			}
			if (flag)
			{
				if (!flag2)
				{
					lk.e().a(new int?(na.dg()));
				}
				na.j(A_1);
				i3.a(na);
				i3.a(na, A_0);
				m4.a(n, lk, flag2);
				if (lk.ay().e() != null)
				{
					na.b(mg.a(A_0, lk.ay().e(), A_0.e()));
				}
				base.f(na, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return na;
		}

		// Token: 0x04000C26 RID: 3110
		private new pb a = null;

		// Token: 0x04000C27 RID: 3111
		private o6 b = null;

		// Token: 0x04000C28 RID: 3112
		private bool c = true;
	}
}
