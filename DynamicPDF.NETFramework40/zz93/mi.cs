using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E4 RID: 484
	internal class mi : k0
	{
		// Token: 0x060014D4 RID: 5332 RVA: 0x000E8FB0 File Offset: 0x000E7FB0
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x000E8FC8 File Offset: 0x000E7FC8
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x000E8FD8 File Offset: 0x000E7FD8
		internal override int dg()
		{
			return 445520207;
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x000E8FF0 File Offset: 0x000E7FF0
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x000E9008 File Offset: 0x000E8008
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x000E9014 File Offset: 0x000E8014
		internal override k0 dd()
		{
			return new mi();
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x000E902C File Offset: 0x000E802C
		internal l2 a()
		{
			return this.b;
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x000E9044 File Offset: 0x000E8044
		internal void a(l2 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x000E9050 File Offset: 0x000E8050
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x000E9068 File Offset: 0x000E8068
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x000E9074 File Offset: 0x000E8074
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x000E9093 File Offset: 0x000E8093
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x000E90A0 File Offset: 0x000E80A0
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			if (base.c5().v() != null && x5.c(x5.f(x5.f(base.c5().v().Value, base.c5().a2()), base.c5().a3()), A_1))
			{
				this.am(false);
				this.dr().am(false);
				base.an(false);
				result = this;
			}
			else
			{
				if (base.c5().v() != null)
				{
					base.ad(x5.f(x5.f(base.c5().v().Value, base.c5().e().a()), base.c5().f().a()));
					if (base.c5().d())
					{
						base.ad(x5.f(base.a8(), base.c5().c().f()));
					}
					base.y(base.a8());
					base.ac(base.a8());
					base.w(base.a8());
				}
				kz kz = base.f(A_0, A_1);
				result = kz;
			}
			return result;
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x000E91F8 File Offset: 0x000E81F8
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			switch (base.c5().q())
			{
			case g6.b:
			{
				if (base.c5().b() != null)
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				bool flag;
				if (base.c5().s() != null)
				{
					x5? x = base.c5().s();
					x5 a_ = x5.c();
					flag = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					A_1 = x5.e(base.aq(), base.c5().s().Value);
				}
				if (base.c5().a() != null)
				{
					A_2 = x5.f(A_2, base.c5().a().Value);
				}
				bool flag2;
				if (base.c5().h() != null)
				{
					x5? x = base.c5().h();
					x5 a_ = x5.c();
					flag2 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag2 = true;
				}
				if (!flag2)
				{
					A_2 = x5.e(A_2, base.c5().h().Value);
				}
				break;
			}
			case g6.c:
			{
				if (base.c5().aa())
				{
					A_1 = x5.f(A_1, base.c5().b().Value);
				}
				else
				{
					bool flag3;
					if (base.c5().b() != null)
					{
						x5? x = base.c5().b();
						x5 a_ = x5.c();
						flag3 = (x == null || !x5.a(x.GetValueOrDefault(), a_));
					}
					else
					{
						flag3 = true;
					}
					if (!flag3)
					{
						A_1 = x5.f(A_1, base.c5().b().Value);
					}
				}
				bool flag4;
				if (base.c5().s() != null)
				{
					x5? x = base.c5().s();
					x5 a_ = x5.c();
					flag4 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag4 = true;
				}
				if (!flag4)
				{
					A_1 = x5.e(base.bi(), base.c5().s().Value);
				}
				if (base.c5().a() != null)
				{
					A_2 = base.c5().a().Value;
				}
				bool flag5;
				if (base.c5().h() != null)
				{
					x5? x = base.c5().h();
					x5 a_ = x5.c();
					flag5 = (x != null && !x5.g(x.GetValueOrDefault(), a_));
				}
				else
				{
					flag5 = true;
				}
				if (!flag5)
				{
					A_2 = x5.e(base.bl(), base.c5().h().Value);
				}
				break;
			}
			}
			x5 a_2 = x5.f(base.c5().e().a(), base.c5().e().c());
			x5 a_3 = x5.f(base.c5().e().d(), base.c5().e().b());
			A_1 = x5.f(A_1, x5.f(base.cc(), this.dc()));
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
			}
			x5 x2 = A_1;
			x2 = x5.f(x2, base.c5().e().d());
			mu mu = base.n().c();
			ms ms = mu.a();
			x5 x3 = A_2;
			x3 = x5.f(x3, x5.f(x5.f(x5.e(ms.ah(), base.ar()), base.c5().a3()), base.c5().e().a()));
			if (base.c5().am() != null)
			{
				base.a(A_0, x2, x3, x5.e(base.aq(), a_3), x5.e(base.ar(), a_2));
			}
			else
			{
				base.a(A_0, A_1, x3, x5.e(base.aq(), a_3), x5.e(base.ar(), a_2));
			}
			x5 a_4 = x5.e(base.ar(), base.ab());
			x5 a_5 = base.n().c().a().l().a().b().ar();
			x5 a_6 = base.n().c().a().l().a().b().aq();
			if (x5.d(x5.f(a_4, base.c5().a2()), ms.ah()))
			{
				A_2 = x5.f(A_2, x5.f(x5.e(ms.ah(), base.ar()), base.c5().a2()));
			}
			else
			{
				A_2 = x5.f(A_2, x5.e(x5.a(a_4, 2), x5.a(a_5, 2)));
			}
			if (x5.c(x5.e(base.aq(), base.aa()), a_6))
			{
				A_1 = x5.f(A_1, x5.e(x5.a(base.aq(), 2), x5.a(ms.r(), 2)));
			}
			else
			{
				A_1 = x5.f(A_1, base.c5().a1());
			}
			while (mu != null && mu.a() != null)
			{
				ms = mu.a();
				switch (base.c5().az())
				{
				case g9.b:
				case g9.c:
					ms.m(true);
					break;
				default:
					ms.m(false);
					break;
				}
				if (ms != null && ms.l() != null)
				{
					ms.a(A_0, A_1, A_2);
				}
				mu = mu.b();
			}
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x000E98B0 File Offset: 0x000E88B0
		internal override kz dm()
		{
			mi mi = new mi();
			mi.j(this.dr());
			mi.dc(this.db().du());
			mi.a((lk)base.c5().du());
			mi.df(this.d);
			mi.a(this.c);
			mi.a(this.b);
			if (base.n() != null)
			{
				mi.c(base.n().p());
			}
			return mi;
		}

		// Token: 0x040009DB RID: 2523
		private new n5 a = new n5();

		// Token: 0x040009DC RID: 2524
		private new l2 b = null;

		// Token: 0x040009DD RID: 2525
		private new bool c = false;

		// Token: 0x040009DE RID: 2526
		private new bool d = false;
	}
}
