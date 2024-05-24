using System;

namespace zz93
{
	// Token: 0x02000196 RID: 406
	internal class ke : dy
	{
		// Token: 0x06000DFF RID: 3583 RVA: 0x0009D1D9 File Offset: 0x0009C1D9
		internal ke(kf A_0) : base(null)
		{
			this.a = A_0;
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x0009D20C File Offset: 0x0009C20C
		internal override bool ci()
		{
			return true;
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x0009D220 File Offset: 0x0009C220
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x0009D238 File Offset: 0x0009C238
		internal float a()
		{
			return this.b;
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0009D250 File Offset: 0x0009C250
		internal float b()
		{
			return this.c;
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x0009D268 File Offset: 0x0009C268
		private void a(ij A_0, l9 A_1)
		{
			it it = new it();
			ja ja = null;
			hh hh = null;
			int num = 0;
			switch (this.a.a())
			{
			case ea.b:
				it.a(new iu(gn.a));
				goto IL_88;
			case ea.c:
				it.a(new iu(gn.b));
				goto IL_88;
			case ea.g:
				it.a(new iu(gn.d));
				goto IL_88;
			}
			this.a.a(ea.d);
			it.a(new iu(gn.c));
			IL_88:
			num++;
			if (this.a.c().a().a() != 0f)
			{
				ja = new ja();
				ja.a(new f9(m4.a(this.a.c())));
				if (this.a.c().a().b() == i2.b)
				{
					ja.a().a(true);
				}
				num++;
			}
			if (this.a.b().a().a() != 0f)
			{
				hh = new hh();
				hh.a(new f9(m4.a(this.a.b())));
				num++;
			}
			num++;
			fc[] array = new fc[num];
			num = 0;
			if (this.a.a() != ea.a)
			{
				array[num] = new fc(1982903832, it);
				num++;
			}
			if (ja != null)
			{
				array[num] = new fc(795562982, ja);
				num++;
			}
			if (hh != null)
			{
				array[num] = new fc(791474715, hh);
				num++;
			}
			if (this.a.d() == null)
			{
				fg a_ = this.a(true);
				array[num] = new fc(148235845, a_);
			}
			else
			{
				fg a_ = this.a(false);
				array[num] = new fc(148235845, a_);
				A_1.a(true);
			}
			num++;
			ig a_2 = new ig(array);
			A_0.a(this.ch().cn(), a_2);
			A_0.a(true);
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x0009D4D8 File Offset: 0x0009C4D8
		private void a(l9 A_0)
		{
			if (!A_0.c5().a7())
			{
				A_0.c5().e().a(x5.a(6f));
				A_0.c5().e().c(x5.a(6f));
			}
			else
			{
				if (A_0.c5().e().i())
				{
					A_0.c5().e().a(x5.a(6f));
				}
				if (A_0.c5().e().j())
				{
					A_0.c5().e().c(x5.a(6f));
				}
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x0009D598 File Offset: 0x0009C598
		private fg a(bool A_0)
		{
			fg fg = new fg();
			fv a_;
			fx a_2;
			fx a_3;
			if (A_0)
			{
				a_ = new fv(ft.b);
				a_2 = new fx("#9A9A9A");
				a_3 = new fx("#EEEEEE");
			}
			else
			{
				a_ = new fv(ft.h);
				a_2 = new fx("#808080");
				a_3 = new fx("#808080");
			}
			fw a_4 = new fw(x5.a(0.75));
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, a_4);
			fg.a()[2] = new fb<fu>(1274012590, a_);
			fg.a()[3] = new fb<fu>(789921929, a_4);
			fg.a()[4] = new fb<fu>(1304279675, a_);
			fg.a()[5] = new fb<fu>(1930785673, a_4);
			fg.a()[6] = new fb<fu>(758017896, a_);
			fg.a()[7] = new fb<fu>(1656587748, a_4);
			fg.a()[8] = new fb<fu>(83960424, a_2);
			fg.a()[9] = new fb<fu>(704614712, a_3);
			fg.a()[10] = new fb<fu>(1235296202, a_3);
			fg.a()[11] = new fb<fu>(10890914, a_2);
			return fg;
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0009D774 File Offset: 0x0009C774
		internal override kz cm(ij A_0, kz A_1)
		{
			l9 l = new l9();
			this.a(A_0, l);
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
				l.aa(A_1.ch());
				if (l.ch())
				{
					l.ab(A_1.ci());
					l.az(A_1.cl());
					l.ay(A_1.ck());
				}
				this.a(l);
				l.c5().c().i(false);
				l.c(new mt(new ms(null)));
			}
			if (A_0.i().b() > 0)
			{
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return l;
		}

		// Token: 0x040006FC RID: 1788
		private new kf a = null;

		// Token: 0x040006FD RID: 1789
		private float b = 0f;

		// Token: 0x040006FE RID: 1790
		private float c = 0f;
	}
}
