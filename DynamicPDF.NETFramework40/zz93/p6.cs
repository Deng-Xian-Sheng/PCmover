using System;

namespace zz93
{
	// Token: 0x02000268 RID: 616
	internal class p6 : er
	{
		// Token: 0x06001BCF RID: 7119 RVA: 0x0011EA00 File Offset: 0x0011DA00
		internal p6(p8 A_0, kg A_1, d3 A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new p7(A_1, A_2.k(), A_3);
			this.b.cq();
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x0011EA54 File Offset: 0x0011DA54
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001BD1 RID: 7121 RVA: 0x0011EA6C File Offset: 0x0011DA6C
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001BD2 RID: 7122 RVA: 0x0011EA84 File Offset: 0x0011DA84
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x0011EA98 File Offset: 0x0011DA98
		internal override fa cr()
		{
			return fa.h;
		}

		// Token: 0x06001BD4 RID: 7124 RVA: 0x0011EAAC File Offset: 0x0011DAAC
		internal nt a()
		{
			return this.c;
		}

		// Token: 0x06001BD5 RID: 7125 RVA: 0x0011EAC4 File Offset: 0x0011DAC4
		private void a(ij A_0)
		{
			int num = 0;
			it it = null;
			i5 i = null;
			fe fe = null;
			ja ja = null;
			hh hh = null;
			i8 i2 = null;
			if (this.a.i() != gn.e)
			{
				it = new it();
				it.a(new iu(this.a.i()));
				num++;
			}
			if (this.a.j() != gs.a)
			{
				i = new i5();
				i.a(new i6(this.a.j(), x5.c()));
				num++;
			}
			if (this.a.a() != null)
			{
				fb<fs>[] a_ = new fb<fs>[]
				{
					new fb<fs>(510035525, new afu(this.a.a())),
					new fb<fs>(137106767, new afv(null)),
					new fb<fs>(19010090, new afx(gl.a)),
					new fb<fs>(808234079, new aft(fq.c)),
					new fb<fs>(440052479, new afw(fr.a, x5.c(), i2.d, x5.c(), i2.d))
				};
				fe = new fe();
				fe.a(a_);
				num++;
			}
			if (this.a.f().a().a() != 0f)
			{
				f9 f = new f9(m4.a(this.a.f()));
				if (this.a.f().a().b() == i2.b)
				{
					f.a(true);
				}
				ja = new ja();
				ja.a(f);
				num++;
			}
			if (this.a.c().a().a() != 0f)
			{
				f9 f2 = new f9(m4.a(this.a.c()));
				if (this.a.c().a().b() == i2.b)
				{
					f2.a(true);
				}
				hh = new hh();
				hh.a(f2);
				num++;
			}
			if (this.a.d())
			{
				i2 = new i8();
				i2.a(new i9(gu.b));
				num++;
			}
			fc[] array = new fc[num];
			int num2 = 0;
			if (it != null)
			{
				array[num2] = new fc(1982903832, it);
				num2++;
			}
			if (i != null)
			{
				array[num2] = new fc(202920309, i);
				num2++;
			}
			if (fe != null)
			{
				array[num2] = new fc(1617181893, fe);
				num2++;
			}
			if (ja != null)
			{
				array[num2] = new fc(795562982, ja);
				num2++;
			}
			if (hh != null)
			{
				array[num2] = new fc(791474715, hh);
				num2++;
			}
			if (i2 != null)
			{
				array[num2] = new fc(40160150, i2);
				num2++;
			}
			ig a_2 = new ig(array);
			A_0.a(this.ch().cn(), a_2);
			A_0.a(true);
		}

		// Token: 0x06001BD6 RID: 7126 RVA: 0x0011EE78 File Offset: 0x0011DE78
		private void a(nt A_0, ij A_1, bool A_2)
		{
			i3.a(A_0);
			i3.a(A_0, A_1);
			n5 a_ = (n5)A_0.db();
			m4.a(a_, A_0.c5(), A_2);
			if (A_0.c5().ay().d() && A_0.c5().ay().e() != null)
			{
				A_0.b(mg.a(A_1, A_0.c5().ay().e(), A_1.e()));
			}
			if (base.k() != null)
			{
				lf lf = new lf();
				lf.a(base.k().a());
				if (!A_0.c5().d())
				{
					A_0.c5().a(lf);
					A_0.c5().a(true);
				}
				else
				{
					if (!A_0.c5().c().aw())
					{
						A_0.c5().c().d(ft.h);
						A_0.c5().c().d(lf.r());
						A_0.c5().c().d(lf.t());
					}
					if (!A_0.c5().c().ax())
					{
						A_0.c5().c().c(ft.h);
						A_0.c5().c().c(lf.n());
						A_0.c5().c().c(lf.p());
					}
					if (!A_0.c5().c().ay())
					{
						A_0.c5().c().a(ft.h);
						A_0.c5().c().a(lf.f());
						A_0.c5().c().a(lf.h());
					}
					if (!A_0.c5().c().az())
					{
						A_0.c5().c().b(ft.h);
						A_0.c5().c().b(lf.j());
						A_0.c5().c().b(lf.l());
					}
				}
			}
			switch (A_0.c5().g())
			{
			case false:
				if (base.l() != null)
				{
					m8 m = new m8();
					m.a(base.l().a());
					A_0.c5().a(m);
					A_0.c5().b(true);
				}
				break;
			case true:
				if (base.l() != null)
				{
					x5 a_2 = base.l().a()[0].b().a();
					if (!A_0.c5().f().i())
					{
						A_0.c5().f().d(a_2);
					}
					if (!A_0.c5().f().j())
					{
						A_0.c5().f().b(a_2);
					}
					if (!A_0.c5().f().k())
					{
						A_0.c5().f().a(a_2);
					}
					if (!A_0.c5().f().l())
					{
						A_0.c5().f().c(a_2);
					}
				}
				break;
			}
			((n5)A_0.db()).a(this.a.b());
			((n5)A_0.db()).b(this.a.e());
		}

		// Token: 0x06001BD7 RID: 7127 RVA: 0x0011F234 File Offset: 0x0011E234
		internal override kz cm(ij A_0, kz A_1)
		{
			this.c = new nt();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(this.c);
			n5 n = (n5)this.c.db();
			this.c.c5().c().i(n.j());
			this.c.d2(base.f());
			this.c.b(base.e());
			this.c.j(A_1);
			this.c.a(base.g());
			A_0.b(this.c);
			A_0.a(false);
			bool flag = true;
			bool a_ = false;
			lk lk = this.c.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					this.c = null;
					flag = false;
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				this.c.c5().e().u();
				if (lk.v() != null && lk.ah() == i2.b)
				{
					lk.i(null);
					lk.a(i2.d);
					lk.j(false);
				}
				this.c.aa(A_1.ch());
				if (this.c.ch())
				{
					this.c.ab(A_1.ci());
					this.c.az(A_1.cl());
					this.c.ay(A_1.ck());
				}
				this.a(this.c, A_0, a_);
				switch (lk.n())
				{
				case g3.a:
				case g3.b:
					lk.a(g3.c);
					break;
				}
				base.g(this.c, A_0);
				this.c.dw(base.j());
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return this.c;
		}

		// Token: 0x04000C8F RID: 3215
		private new p8 a = null;

		// Token: 0x04000C90 RID: 3216
		private p7 b = null;

		// Token: 0x04000C91 RID: 3217
		private nt c = null;
	}
}
