using System;

namespace zz93
{
	// Token: 0x02000231 RID: 561
	internal class on : dy
	{
		// Token: 0x06001A36 RID: 6710 RVA: 0x00111503 File Offset: 0x00110503
		internal on(op A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new oo(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x00111540 File Offset: 0x00110540
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00111558 File Offset: 0x00110558
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x00111570 File Offset: 0x00110570
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x00111584 File Offset: 0x00110584
		private void a(ij A_0)
		{
			ja ja = null;
			fe fe = null;
			hh hh = null;
			int num = 0;
			if (this.a.b().a().a() != 0f)
			{
				ja = new ja();
				ja.a(new f9(m4.a(this.a.b())));
				if (this.a.b().a().b() == i2.b)
				{
					ja.a().a(true);
				}
				num++;
			}
			if (this.a.c().a().a() != 0f)
			{
				f9 f = new f9(m4.a(this.a.c()));
				if (this.a.c().a().b() == i2.b)
				{
					f.a(true);
				}
				hh = new hh();
				hh.a(f);
				num++;
			}
			if (this.a.f() != null)
			{
				fb<fs>[] array = new fb<fs>[5];
				array[0] = new fb<fs>(510035525, new afu(this.a.f()));
				fe = new fe();
				fe.a(array);
				num++;
			}
			fc[] array2 = new fc[num];
			num = 0;
			if (ja != null)
			{
				array2[num] = new fc(795562982, ja);
				num++;
			}
			if (hh != null)
			{
				array2[num] = new fc(791474715, hh);
				num++;
			}
			if (fe != null)
			{
				array2[num] = new fc(1617181893, fe);
				num++;
			}
			ig a_ = new ig(array2);
			A_0.a(this.ch().cn(), a_);
			A_0.a(true);
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x00111790 File Offset: 0x00110790
		internal override kz cm(ij A_0, kz A_1)
		{
			m3 m = new m3();
			this.a(A_0);
			A_0.c(this.ch());
			A_0.a(m);
			n5 n = (n5)m.db();
			m.c5().c().i(n.j());
			A_0.b(m);
			bool flag = true;
			bool a_ = false;
			g2 valueOrDefault = m.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					m = null;
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
				m.j(A_1);
				i3.a(m);
				i3.a(m, A_0);
				if (this.a.e().a().a() != 0f)
				{
					m2 m2 = m.c5().e();
					m2 m3 = m.c5().e();
					x5 x;
					m.c5().e().g(x = x5.a(this.a.e().a().a()));
					m3.h(x = x);
					m2.a(x);
					m2 m4 = m.c5().e();
					m2 m5 = m.c5().e();
					m.c5().e().i(x = x5.a(this.a.e().a().a()));
					m5.j(x = x);
					m4.c(x);
				}
				if (this.a.d().a().a() != 0f)
				{
					m.c5().e().d(x5.a(this.a.d().a().a()));
					m.c5().e().b(x5.a(this.a.d().a().a()));
				}
				m4.a(n, m.c5(), a_);
				if (m.c5().ay().d() && m.c5().ay().e() != null)
				{
					m.b(mg.a(A_0, m.c5().ay().e(), A_0.e()));
				}
				if (A_1.dg() != 594666565)
				{
					if (this.a.g() == ga.c || this.a.g() == ga.d)
					{
						if (m.c5().v() == null)
						{
							m.c5().i(new x5?(x5.a(150f)));
							m.c5().a(i2.d);
						}
						m.ax(m.c5().v().Value);
						m.ab(true);
						m.ay(m.c5().v().Value);
					}
				}
				base.f(m, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return m;
		}

		// Token: 0x04000BF1 RID: 3057
		private new op a = null;

		// Token: 0x04000BF2 RID: 3058
		private oo b = null;
	}
}
