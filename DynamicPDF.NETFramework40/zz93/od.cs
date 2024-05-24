using System;

namespace zz93
{
	// Token: 0x02000227 RID: 551
	internal class od : dy
	{
		// Token: 0x06001A0D RID: 6669 RVA: 0x0010EDA0 File Offset: 0x0010DDA0
		internal od(of A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new oe(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x0010EDF0 File Offset: 0x0010DDF0
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x0010EE08 File Offset: 0x0010DE08
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x0010EE20 File Offset: 0x0010DE20
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x0010EE38 File Offset: 0x0010DE38
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x0010EE44 File Offset: 0x0010DE44
		internal override kz cm(ij A_0, kz A_1)
		{
			mv mv = new mv();
			A_0.c(this.ch());
			A_0.a(mv);
			n5 n = (n5)mv.db();
			mv.c5().c().i(n.j());
			A_0.b(mv);
			bool flag = true;
			bool a_ = false;
			g2? a_2 = mv.c5().t();
			g2 valueOrDefault = a_2.GetValueOrDefault();
			if (a_2 != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					mv = null;
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
				mv.j(A_1);
				lk lk = mv.c5();
				a_2 = null;
				lk.a(a_2);
				i3.a(mv);
				i3.a(mv, A_0);
				m4.a(n, mv.c5(), a_);
				if (mv.c5().ay().d() && mv.c5().ay().e() != null)
				{
					mv.b(mg.a(A_0, mv.c5().ay().e(), A_0.e()));
				}
				this.a(mv);
				base.f(mv, A_0);
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return mv;
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x0010EFF4 File Offset: 0x0010DFF4
		private void a(mv A_0)
		{
			switch (A_0.c5().g())
			{
			case false:
			{
				m8 m = new m8();
				m.a(this.a().a());
				A_0.c5().a(m);
				A_0.c5().b(true);
				break;
			}
			case true:
				if (!A_0.c5().f().i())
				{
					A_0.c5().f().d(x5.a(7.5));
				}
				if (!A_0.c5().f().j())
				{
					A_0.c5().f().b(x5.a(7.5));
				}
				if (!A_0.c5().f().k())
				{
					A_0.c5().f().a(x5.a(3.75));
				}
				if (!A_0.c5().f().l())
				{
					A_0.c5().f().c(x5.a(7.5));
				}
				break;
			}
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x0010F124 File Offset: 0x0010E124
		private hx a()
		{
			hx hx = new hx();
			ge ge = new ge(x5.a(1.5));
			ge ge2 = new ge(x5.c());
			ge.a(i2.d);
			ge2.a(i2.d);
			hx.a()[0] = new fb<ge>(136794, ge2);
			hx.a()[1] = new fb<ge>(426354259, ge2);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge);
			return hx;
		}

		// Token: 0x04000BC7 RID: 3015
		private new of a = null;

		// Token: 0x04000BC8 RID: 3016
		private oe b = null;

		// Token: 0x04000BC9 RID: 3017
		private bool c = true;
	}
}
