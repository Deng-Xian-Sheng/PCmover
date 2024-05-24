using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000206 RID: 518
	internal class ng : k0
	{
		// Token: 0x06001795 RID: 6037 RVA: 0x000FAE38 File Offset: 0x000F9E38
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x06001796 RID: 6038 RVA: 0x000FAE50 File Offset: 0x000F9E50
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x000FAE60 File Offset: 0x000F9E60
		internal override int dg()
		{
			return 86147604;
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x000FAE78 File Offset: 0x000F9E78
		internal override bool de()
		{
			return this.d;
		}

		// Token: 0x06001799 RID: 6041 RVA: 0x000FAE90 File Offset: 0x000F9E90
		internal override void df(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0600179A RID: 6042 RVA: 0x000FAE9C File Offset: 0x000F9E9C
		internal override k0 dd()
		{
			return new ng();
		}

		// Token: 0x0600179B RID: 6043 RVA: 0x000FAEB4 File Offset: 0x000F9EB4
		internal int a()
		{
			return this.b;
		}

		// Token: 0x0600179C RID: 6044 RVA: 0x000FAECC File Offset: 0x000F9ECC
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600179D RID: 6045 RVA: 0x000FAED8 File Offset: 0x000F9ED8
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x000FAEF0 File Offset: 0x000F9EF0
		internal void a(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x000FAEFC File Offset: 0x000F9EFC
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
			x5 a_2 = x5.e(base.c5().am().Value, a_);
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
				A_2 = x5.f(A_2, base.c5().c().f());
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

		// Token: 0x060017A0 RID: 6048 RVA: 0x000FB144 File Offset: 0x000FA144
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x000FB163 File Offset: 0x000FA163
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x000FB170 File Offset: 0x000FA170
		internal override kz dj(x5 A_0, x5 A_1)
		{
			base.l(x5.f(base.c5().am().Value, base.aa()));
			kz result;
			if (base.c5().v() != null && x5.c(x5.f(x5.f(base.c5().v().Value, base.c5().a2()), base.c5().a3()), A_1))
			{
				this.am(false);
				base.an(false);
				result = this;
			}
			else
			{
				kz kz = base.f(A_0, A_1);
				base.ad(x5.e(base.ar(), base.c5().a3()));
				base.y(x5.e(base.a8(), base.a2()));
				base.ac(base.a8());
				base.w(base.a3());
				result = kz;
			}
			return result;
		}

		// Token: 0x060017A3 RID: 6051 RVA: 0x000FB270 File Offset: 0x000FA270
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
			x5 a_ = x5.c();
			if (!base.s() && !this.@do())
			{
				a_ = x5.f(a_, base.c5().e().a());
				A_2 = x5.f(A_2, base.c5().e().a());
			}
			if (!base.t())
			{
				a_ = x5.f(a_, base.c5().e().c());
			}
			A_1 = x5.f(A_1, base.c5().e().d());
			if (base.c5().v() != null)
			{
				A_0.Write_q_();
				A_0.Write_re(x5.b(A_1), x5.b(A_2), x5.b(base.aq()), x5.b(base.ar()));
				A_0.Write_W();
				A_0.Write_n();
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
						ms.a(A_0, A_1, A_2);
					}
					mu = mu.b();
				}
			}
			if (base.c5().v() != null)
			{
				A_0.Write_Q();
			}
		}

		// Token: 0x060017A4 RID: 6052 RVA: 0x000FB4B4 File Offset: 0x000FA4B4
		internal override kz dm()
		{
			ng ng = new ng();
			ng.j(this.dr());
			ng.dc(this.db().du());
			ng.a((lk)base.c5().du());
			ng.a(this.b);
			ng.a(this.c);
			ng.df(this.d);
			if (base.n() != null)
			{
				ng.c(base.n().p());
			}
			return ng;
		}

		// Token: 0x04000AB9 RID: 2745
		private new n5 a = new n5();

		// Token: 0x04000ABA RID: 2746
		private new int b = 1;

		// Token: 0x04000ABB RID: 2747
		private new bool c = false;

		// Token: 0x04000ABC RID: 2748
		private new bool d = false;
	}
}
