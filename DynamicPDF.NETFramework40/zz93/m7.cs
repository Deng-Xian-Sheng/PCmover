using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001FD RID: 509
	internal class m7 : k0
	{
		// Token: 0x06001703 RID: 5891 RVA: 0x000F9458 File Offset: 0x000F8458
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001704 RID: 5892 RVA: 0x000F9470 File Offset: 0x000F8470
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001705 RID: 5893 RVA: 0x000F9480 File Offset: 0x000F8480
		internal override int dg()
		{
			return 506042859;
		}

		// Token: 0x06001706 RID: 5894 RVA: 0x000F9498 File Offset: 0x000F8498
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x000F94B0 File Offset: 0x000F84B0
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001708 RID: 5896 RVA: 0x000F94BC File Offset: 0x000F84BC
		internal override k0 dd()
		{
			return new m7();
		}

		// Token: 0x06001709 RID: 5897 RVA: 0x000F94D4 File Offset: 0x000F84D4
		internal bool a()
		{
			return this.b;
		}

		// Token: 0x0600170A RID: 5898 RVA: 0x000F94EC File Offset: 0x000F84EC
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600170B RID: 5899 RVA: 0x000F94F8 File Offset: 0x000F84F8
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x0600170C RID: 5900 RVA: 0x000F9510 File Offset: 0x000F8510
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600170D RID: 5901 RVA: 0x000F951C File Offset: 0x000F851C
		private void a(PageWriter A_0, ref x5 A_1, ref x5 A_2)
		{
			x5 a_ = x5.f(base.c5().e().d(), base.c5().e().b());
			x5 x = x5.c();
			if (!base.s() && !this.@do())
			{
				x = x5.f(x, base.c5().e().a());
				A_2 = x5.f(A_2, base.c5().e().a());
			}
			if (!base.t())
			{
				x = x5.f(x, base.c5().e().c());
			}
			A_1 = x5.f(A_1, base.c5().e().d());
			x5 a_2 = x5.e(base.aq(), a_);
			x5 a_3 = x5.e(base.ar(), x);
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
				if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
				{
					a_3 = base.c5().v().Value;
				}
			}
			base.a(A_0, A_1, A_2, a_2, a_3);
			if (!base.s())
			{
				A_2 = x5.f(A_2, base.c5().f().a());
			}
			if (!base.q())
			{
				A_1 = x5.f(A_1, base.c5().f().d());
				if (base.c5().c().o() != ft.a)
				{
					A_1 = x5.f(A_1, base.c5().c().n());
				}
			}
		}

		// Token: 0x0600170E RID: 5902 RVA: 0x000F9734 File Offset: 0x000F8734
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x0600170F RID: 5903 RVA: 0x000F9753 File Offset: 0x000F8753
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x000F9760 File Offset: 0x000F8760
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.f(A_0, A_1);
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x000F977C File Offset: 0x000F877C
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			A_1 = x5.f(A_1, base.cc());
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
			}
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
			if (this.c)
			{
				this.a.a(Color.d("#BFBFBF"));
			}
			this.a(A_0, ref A_1, ref A_2);
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
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
						((n5)ms.l().a().b().db()).a(this.a.j());
						ms.a(A_0, A_1, A_2);
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x06001712 RID: 5906 RVA: 0x000F9C34 File Offset: 0x000F8C34
		internal override kz dm()
		{
			m7 m = new m7();
			m.j(this.dr());
			m.dc(this.db().du());
			m.a((lk)base.c5().du());
			m.df(this.d);
			m.a(this.b);
			m.b(this.c);
			if (base.n() != null)
			{
				m.c(base.n().p());
			}
			return m;
		}

		// Token: 0x04000A88 RID: 2696
		private new n5 a = new n5();

		// Token: 0x04000A89 RID: 2697
		private new bool b = false;

		// Token: 0x04000A8A RID: 2698
		private new bool c = false;

		// Token: 0x04000A8B RID: 2699
		private new bool d = false;
	}
}
