using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020000C8 RID: 200
	internal class eo : dy
	{
		// Token: 0x0600093A RID: 2362 RVA: 0x0007BBFC File Offset: 0x0007ABFC
		internal eo(eq A_0, p1 A_1, kg A_2, ij A_3) : base(null)
		{
			this.a = A_0;
			this.b = new ep(A_2, A_1, A_3);
			this.b.cq();
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0007BC4C File Offset: 0x0007AC4C
		internal override d3 cg()
		{
			return this.b;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0007BC64 File Offset: 0x0007AC64
		internal override d0 ch()
		{
			return this.a;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0007BC7C File Offset: 0x0007AC7C
		internal override bool ci()
		{
			return this.c;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0007BC94 File Offset: 0x0007AC94
		internal override void cj(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0007BCA0 File Offset: 0x0007ACA0
		private void b(ln A_0)
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
					A_0.c5().f().d(x5.a(6f));
				}
				if (!A_0.c5().f().j())
				{
					A_0.c5().f().b(x5.a(6f));
				}
				if (!A_0.c5().f().k())
				{
					A_0.c5().f().a(x5.a(0.75));
				}
				if (!A_0.c5().f().l())
				{
					A_0.c5().f().c(x5.a(0.75));
				}
				break;
			}
			if (!A_0.c5().d())
			{
				lf lf = new lf();
				x5 a_ = x5.a(0.75);
				string a_2 = "#707070";
				lf.a(this.a(a_, a_2).a());
				lf.n(true);
				A_0.c5().a(lf);
				A_0.c5().a(true);
				m8 m2 = A_0.c5().f();
				m2.a(x5.f(m2.a(), x5.a(0.75)));
				m8 m3 = A_0.c5().f();
				m3.c(x5.f(m3.c(), x5.a(0.75)));
				m8 m4 = A_0.c5().f();
				m4.b(x5.f(m4.b(), x5.a(0.75)));
				m8 m5 = A_0.c5().f();
				m5.d(x5.f(m5.d(), x5.a(0.75)));
			}
			string a_3 = "#D8D8D8";
			this.a(a_3, A_0);
			this.a(A_0);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0007BEFC File Offset: 0x0007AEFC
		private void a(ln A_0)
		{
			m2 m = A_0.c5().e();
			if (m.j())
			{
				m.c(x5.a(0.25));
				m.c(i2.d);
			}
			if (m.i())
			{
				m.a(x5.a(0.25));
				m.a(i2.d);
			}
			if (m.k())
			{
				m.d(x5.a(0.25));
				m.d(i2.d);
			}
			if (m.l())
			{
				m.b(x5.a(0.25));
				m.b(i2.d);
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0007BFC8 File Offset: 0x0007AFC8
		private hx a()
		{
			hx hx = new hx();
			ge ge = new ge(x5.a(6f));
			ge ge2 = new ge(x5.a(0.75));
			ge.a(i2.d);
			ge2.a(i2.d);
			hx.a()[0] = new fb<ge>(136794, ge2);
			hx.a()[1] = new fb<ge>(426354259, ge2);
			hx.a()[2] = new fb<ge>(7021096, ge);
			hx.a()[3] = new fb<ge>(448574430, ge);
			return hx;
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0007C088 File Offset: 0x0007B088
		private fg a(x5 A_0, string A_1)
		{
			fg fg = new fg();
			fv a_ = new fv(ft.h);
			fx a_2 = new fx(A_1);
			fw fw = new fw(A_0);
			fw.a(i2.d);
			fg.a()[0] = new fb<fu>(548864878, a_);
			fg.a()[1] = new fb<fu>(663309508, fw);
			fg.a()[2] = new fb<fu>(83960424, a_2);
			fg.a()[3] = new fb<fu>(1274012590, a_);
			fg.a()[4] = new fb<fu>(789921929, fw);
			fg.a()[5] = new fb<fu>(704614712, a_2);
			fg.a()[6] = new fb<fu>(1304279675, a_);
			fg.a()[7] = new fb<fu>(1930785673, fw);
			fg.a()[8] = new fb<fu>(1235296202, a_2);
			fg.a()[9] = new fb<fu>(758017896, a_);
			fg.a()[10] = new fb<fu>(1656587748, fw);
			fg.a()[11] = new fb<fu>(10890914, a_2);
			return fg;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0007C214 File Offset: 0x0007B214
		private void a(string A_0, ln A_1)
		{
			if (A_1.c5().ay() != null)
			{
				if (!A_1.c5().ay().b())
				{
					A_1.c5().ay().a(Color.d(A_0));
				}
			}
			else
			{
				fe fe = new fe();
				fb<fs>[] array = new fb<fs>[5];
				array[0] = new fb<fs>(510035525, new afu(A_0));
				fe.a(array);
				k8 k = new k8();
				k.a(array);
				A_1.c5().a(k);
			}
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0007C2B4 File Offset: 0x0007B2B4
		internal override kz cm(ij A_0, kz A_1)
		{
			ln ln = new ln();
			if (this.a.c())
			{
				fc[] array = new fc[1];
				iv iv = new iv();
				iv.a(new go("#A0A0A0"));
				array[0] = new fc(510035525, iv);
				ig a_ = new ig(array);
				A_0.a(this.ch().cn(), a_);
				A_0.a(true);
			}
			A_0.c(this.ch());
			A_0.a(ln);
			A_0.b(ln);
			bool flag = true;
			bool a_2 = false;
			g2 valueOrDefault = ln.c5().t().GetValueOrDefault();
			g2? g;
			if (g != null)
			{
				switch (valueOrDefault)
				{
				case g2.a:
					ln = null;
					flag = false;
					A_0.a(false);
					break;
				case g2.c:
					a_2 = true;
					break;
				}
			}
			if (flag)
			{
				ln.j(A_1);
				i3.a(ln);
				i3.a(ln, A_0);
				n5 n = (n5)ln.db();
				m4.a(n, ln.c5(), a_2);
				if (ln.c5().ay().d() && ln.c5().ay().e() != null)
				{
					ln.b(mg.a(A_0, ln.c5().ay().e(), A_0.e()));
				}
				this.b(ln);
				base.f(ln, A_0);
				ln.c5().c().i(n.j());
			}
			if (A_0.i().b() > 0)
			{
				A_0.b().a(A_0.i().b(), A_0);
				A_0.i().l(A_0.i().b());
				ik ik = A_0.i();
				ik.j(ik.b() - 1);
			}
			return ln;
		}

		// Token: 0x040004BF RID: 1215
		private new eq a = null;

		// Token: 0x040004C0 RID: 1216
		private ep b = null;

		// Token: 0x040004C1 RID: 1217
		private bool c = false;
	}
}
