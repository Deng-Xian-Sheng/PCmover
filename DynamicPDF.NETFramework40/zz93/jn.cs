using System;

namespace zz93
{
	// Token: 0x0200017B RID: 379
	internal class jn : dy
	{
		// Token: 0x06000D84 RID: 3460 RVA: 0x0009956C File Offset: 0x0009856C
		internal jn(jp A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new jo(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000995BC File Offset: 0x000985BC
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x000995D4 File Offset: 0x000985D4
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x000995EC File Offset: 0x000985EC
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00099604 File Offset: 0x00098604
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00099610 File Offset: 0x00098610
		private void a(ij A_0)
		{
			if (this.a.a() != ea.a)
			{
				it it = new it();
				switch (this.a.a())
				{
				case ea.c:
					it.a(new iu(gn.b));
					goto IL_85;
				case ea.d:
					it.a(new iu(gn.c));
					goto IL_85;
				case ea.g:
					it.a(new iu(gn.d));
					goto IL_85;
				}
				it.a(new iu(gn.a));
				IL_85:
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

		// Token: 0x06000D8A RID: 3466 RVA: 0x000996E4 File Offset: 0x000986E4
		internal override kz cm(ij A_0, kz A_1)
		{
			lx lx = new lx();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(lx);
			n5 n = (n5)lx.db();
			lx.c5().c().i(n.j());
			A_0.b(lx);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = lx.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					lx = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					a_ = true;
					break;
				case g2.j:
				case g2.k:
				case g2.l:
				case g2.m:
				case g2.n:
				case g2.o:
					lx.c5().e().u();
					break;
				}
			}
			if (flag)
			{
				lx.j(A_1);
				i3.a(lx);
				i3.a(lx, A_0);
				m4.a(n, lx.c5(), a_);
				if (lx.c5().ay().d() && lx.c5().ay().e() != null)
				{
					lx.b(mg.a(A_0, lx.c5().ay().e(), A_0.e()));
				}
				base.f(lx, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return lx;
		}

		// Token: 0x040006D9 RID: 1753
		private new jp a = null;

		// Token: 0x040006DA RID: 1754
		private jo b = null;

		// Token: 0x040006DB RID: 1755
		private bool c = true;
	}
}
