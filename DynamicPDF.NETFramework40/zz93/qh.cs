using System;

namespace zz93
{
	// Token: 0x02000273 RID: 627
	internal class qh : er
	{
		// Token: 0x06001C27 RID: 7207 RVA: 0x00121D84 File Offset: 0x00120D84
		internal qh(qm A_0, kg A_1, d3 A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new qi(A_1, A_2.k(), A_3);
			this.b.cq();
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x00121DD8 File Offset: 0x00120DD8
		internal qh(qm A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new qi(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x00121E28 File Offset: 0x00120E28
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x00121E40 File Offset: 0x00120E40
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x00121E58 File Offset: 0x00120E58
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06001C2C RID: 7212 RVA: 0x00121E6C File Offset: 0x00120E6C
		internal override fa cr()
		{
			return fa.f;
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x00121E80 File Offset: 0x00120E80
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
				this.c = false;
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

		// Token: 0x06001C2E RID: 7214 RVA: 0x0012223C File Offset: 0x0012123C
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
						A_0.c5().c().d(ft.d);
						A_0.c5().c().d(lf.r());
						A_0.c5().c().d(lf.t());
					}
					if (!A_0.c5().c().ax())
					{
						A_0.c5().c().c(ft.d);
						A_0.c5().c().c(lf.n());
						A_0.c5().c().c(lf.p());
					}
					if (!A_0.c5().c().ay())
					{
						A_0.c5().c().a(ft.d);
						A_0.c5().c().a(lf.f());
						A_0.c5().c().a(lf.h());
					}
					if (!A_0.c5().c().az())
					{
						A_0.c5().c().b(ft.d);
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
					A_0.c5().b(false);
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
			if (this.c)
			{
				((n5)A_0.db()).a(gn.c);
			}
			((n5)A_0.db()).a().a(f7.k);
			((n5)A_0.db()).a(this.a.b());
			((n5)A_0.db()).b(this.a.e());
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x00122634 File Offset: 0x00121634
		internal override kz cm(ij A_0, kz A_1)
		{
			nt nt = new nt();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(nt);
			n5 n = (n5)nt.db();
			nt.c5().c().i(n.j());
			nt.d2(base.f());
			nt.b(base.e());
			nt.j(A_1);
			nt.a(base.g());
			A_0.b(nt);
			A_0.a(false);
			bool flag = true;
			bool a_ = false;
			lk lk = nt.c5();
			g2 valueOrDefault = lk.t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					nt = null;
					flag = false;
					break;
				case g2.c:
					a_ = true;
					break;
				}
			}
			if (flag)
			{
				if (lk.v() != null && lk.ah() == i2.b)
				{
					lk.i(null);
					lk.a(i2.d);
					lk.j(false);
				}
				nt.aa(A_1.ch());
				if (nt.ch())
				{
					nt.ab(A_1.ci());
					nt.az(A_1.cl());
					nt.ay(A_1.ck());
				}
				this.a(nt, A_0, a_);
				switch (nt.c5().n())
				{
				case g3.a:
				case g3.b:
					lk.a(g3.c);
					break;
				}
				base.g(nt, A_0);
				nt.dw(base.j());
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return nt;
		}

		// Token: 0x04000CAF RID: 3247
		private new qm a = null;

		// Token: 0x04000CB0 RID: 3248
		private qi b = null;

		// Token: 0x04000CB1 RID: 3249
		private bool c = true;
	}
}
