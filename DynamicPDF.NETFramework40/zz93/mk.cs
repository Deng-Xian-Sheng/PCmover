using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E6 RID: 486
	internal class mk : k0
	{
		// Token: 0x060014F2 RID: 5362 RVA: 0x000E9E38 File Offset: 0x000E8E38
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x000E9E50 File Offset: 0x000E8E50
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x000E9E60 File Offset: 0x000E8E60
		internal override int dg()
		{
			return 445520207;
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x000E9E78 File Offset: 0x000E8E78
		internal override bool de()
		{
			return this.e;
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x000E9E90 File Offset: 0x000E8E90
		internal override void df(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x000E9E9C File Offset: 0x000E8E9C
		internal override k0 dd()
		{
			return new mk();
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x000E9EB4 File Offset: 0x000E8EB4
		internal l2 a()
		{
			return this.b;
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x000E9ECC File Offset: 0x000E8ECC
		internal void a(l2 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x000E9ED8 File Offset: 0x000E8ED8
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x000E9EF0 File Offset: 0x000E8EF0
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x000E9EFC File Offset: 0x000E8EFC
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x000E9F14 File Offset: 0x000E8F14
		internal void b(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x000E9F20 File Offset: 0x000E8F20
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x000E9F3F File Offset: 0x000E8F3F
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x000E9F4C File Offset: 0x000E8F4C
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

		// Token: 0x06001501 RID: 5377 RVA: 0x000EA0A4 File Offset: 0x000E90A4
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
				A_2 = x5.f(A_2, x5.e(ms.ah(), x5.f(a_4, base.c5().a2())));
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

		// Token: 0x06001502 RID: 5378 RVA: 0x000EA758 File Offset: 0x000E9758
		internal override kz dm()
		{
			mk mk = new mk();
			mk.j(this.dr());
			mk.dc(this.db().du());
			mk.a((lk)base.c5().du());
			mk.df(this.e);
			mk.a(this.b);
			mk.a(this.c);
			mk.b(this.d);
			if (base.n() != null)
			{
				mk.c(base.n().p());
			}
			return mk;
		}

		// Token: 0x040009E2 RID: 2530
		private new n5 a = new n5();

		// Token: 0x040009E3 RID: 2531
		private new l2 b = null;

		// Token: 0x040009E4 RID: 2532
		private new bool c = false;

		// Token: 0x040009E5 RID: 2533
		private new bool d = false;

		// Token: 0x040009E6 RID: 2534
		private new bool e = false;
	}
}
