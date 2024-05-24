using System;

namespace zz93
{
	// Token: 0x02000189 RID: 393
	internal class j1 : dy
	{
		// Token: 0x06000DD0 RID: 3536 RVA: 0x0009C010 File Offset: 0x0009B010
		internal j1(j3 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new j2(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x0009C060 File Offset: 0x0009B060
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x0009C078 File Offset: 0x0009B078
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x0009C090 File Offset: 0x0009B090
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x0009C0A8 File Offset: 0x0009B0A8
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x0009C0B4 File Offset: 0x0009B0B4
		internal override kz cm(ij A_0, kz A_1)
		{
			l6 l = new l6();
			A_0.c(this.ch());
			A_0.a(l);
			n5 n = (n5)l.db();
			l.c5().c().i(n.j());
			A_0.b(l);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = l.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					l = null;
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
				l.j(A_1);
				i3.a(l);
				i3.a(l, A_0);
				m4.a(n, l.c5(), a_);
				if (l.c5().ay().d() && l.c5().ay().e() != null)
				{
					l.b(mg.a(A_0, l.c5().ay().e(), A_0.e()));
				}
				base.f(l, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return l;
		}

		// Token: 0x040006F0 RID: 1776
		private new j3 a = null;

		// Token: 0x040006F1 RID: 1777
		private j2 b = null;

		// Token: 0x040006F2 RID: 1778
		private bool c = true;
	}
}
