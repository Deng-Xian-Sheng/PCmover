using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001FC RID: 508
	internal class m6 : k0
	{
		// Token: 0x060016F2 RID: 5874 RVA: 0x000F8BF8 File Offset: 0x000F7BF8
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060016F3 RID: 5875 RVA: 0x000F8C10 File Offset: 0x000F7C10
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x000F8C20 File Offset: 0x000F7C20
		internal override int dg()
		{
			return 423471123;
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x000F8C38 File Offset: 0x000F7C38
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x060016F6 RID: 5878 RVA: 0x000F8C50 File Offset: 0x000F7C50
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x000F8C5C File Offset: 0x000F7C5C
		internal override k0 dd()
		{
			return new m6();
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x000F8C74 File Offset: 0x000F7C74
		internal bool a()
		{
			return this.b;
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x000F8C8C File Offset: 0x000F7C8C
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x000F8C98 File Offset: 0x000F7C98
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x000F8CB0 File Offset: 0x000F7CB0
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x000F8CBC File Offset: 0x000F7CBC
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
			}
		}

		// Token: 0x060016FD RID: 5885 RVA: 0x000F8E98 File Offset: 0x000F7E98
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x000F8EB7 File Offset: 0x000F7EB7
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060016FF RID: 5887 RVA: 0x000F8EC4 File Offset: 0x000F7EC4
		internal override kz dj(x5 A_0, x5 A_1)
		{
			return base.f(A_0, A_1);
		}

		// Token: 0x06001700 RID: 5888 RVA: 0x000F8EE0 File Offset: 0x000F7EE0
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

		// Token: 0x06001701 RID: 5889 RVA: 0x000F9398 File Offset: 0x000F8398
		internal override kz dm()
		{
			m6 m = new m6();
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

		// Token: 0x04000A84 RID: 2692
		private new n5 a = new n5();

		// Token: 0x04000A85 RID: 2693
		private new bool b = false;

		// Token: 0x04000A86 RID: 2694
		private new bool c = false;

		// Token: 0x04000A87 RID: 2695
		private new bool d = false;
	}
}
