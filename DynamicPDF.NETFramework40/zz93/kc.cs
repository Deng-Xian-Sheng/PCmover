using System;

namespace zz93
{
	// Token: 0x02000194 RID: 404
	internal class kc : dy
	{
		// Token: 0x06000DF4 RID: 3572 RVA: 0x0009CC34 File Offset: 0x0009BC34
		internal kc(j4 A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new kd(A_0, A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x0009CC84 File Offset: 0x0009BC84
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x0009CC9C File Offset: 0x0009BC9C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0009CCB4 File Offset: 0x0009BCB4
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x0009CCCC File Offset: 0x0009BCCC
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x0009CCD8 File Offset: 0x0009BCD8
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

		// Token: 0x06000DFA RID: 3578 RVA: 0x0009CDAC File Offset: 0x0009BDAC
		private void a(l8 A_0, ij A_1)
		{
			A_1.a(true);
			hd a_ = i3.b(A_0);
			ig a_2 = new ig(new fc[]
			{
				new fc(6968946, a_)
			});
			A_1.a(this.ch().cn(), a_2);
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x0009CDF8 File Offset: 0x0009BDF8
		internal override kz cm(ij A_0, kz A_1)
		{
			l8 l = new l8(this.ch().cn());
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(l);
			n5 n = (n5)l.db();
			l.c5().c().i(n.j());
			lk lk = l.c5();
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
				this.a(l, A_0);
				lk.e().a(new int?(l.dg()));
				i3.a(l);
				i3.a(l, A_0);
				m4.a(n, l.c5(), a_);
				if (l.c5().ay().e() != null)
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

		// Token: 0x040006F8 RID: 1784
		private new j4 a = null;

		// Token: 0x040006F9 RID: 1785
		private kd b = null;

		// Token: 0x040006FA RID: 1786
		private bool c = true;
	}
}
