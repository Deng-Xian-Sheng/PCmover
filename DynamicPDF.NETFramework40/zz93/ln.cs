using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001C3 RID: 451
	internal class ln : k0
	{
		// Token: 0x060012F6 RID: 4854 RVA: 0x000D9724 File Offset: 0x000D8724
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000D973C File Offset: 0x000D873C
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000D974C File Offset: 0x000D874C
		internal override int dg()
		{
			return 426354867;
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000D9764 File Offset: 0x000D8764
		internal override bool de()
		{
			return this.b;
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x000D977C File Offset: 0x000D877C
		internal override void df(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x000D9788 File Offset: 0x000D8788
		internal override k0 dd()
		{
			return new mh();
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x000D97A0 File Offset: 0x000D87A0
		private void a()
		{
			if (base.n() != null)
			{
				mu mu = base.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms != null && ms.l() != null)
					{
						mr mr = ms.l().a();
						while (mr != null && mr.b() != null)
						{
							if (mr.b().de())
							{
								mr.b().ah(mr.b().aq());
							}
							mr = mr.c();
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x000D9868 File Offset: 0x000D8868
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
			x5 x2 = A_1;
			x5 x3 = A_2;
			x5 x4 = x5.e(base.aq(), a_);
			x5 x5 = x5.e(base.ar(), x);
			if (base.c5().am() != null)
			{
				x4 = base.c5().am().Value;
			}
			x5 x6 = x4;
			x5 x7 = x5.c();
			A_1 = x5.f(A_1, x5.f(base.cc(), this.dc()));
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
				if (base.c5().v() != null && x5.g(base.c5().v().Value, x5.c()))
				{
					x5 = base.c5().v().Value;
				}
			}
			x7 = x5;
			x2 = A_1;
			lf lf = base.c5().c();
			if (lf.bc())
			{
				x7 = x5.e(x7, x5.f(x5.b(lf.f(), 2), x5.b(lf.j(), 2)));
				x6 = x5.e(x6, x5.f(x5.b(lf.n(), 2), x5.b(lf.r(), 2)));
				x2 = x5.f(x2, x5.b(lf.n(), 2));
				x3 = x5.f(x3, x5.b(lf.f(), 2));
			}
			base.a(A_0, x2, x3, x6, x7);
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

		// Token: 0x060012FE RID: 4862 RVA: 0x000D9BAC File Offset: 0x000D8BAC
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x000D9BCB File Offset: 0x000D8BCB
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x000D9BD8 File Offset: 0x000D8BD8
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result = base.f(A_0, A_1);
			base.ad(x5.e(base.ar(), base.c5().a3()));
			base.y(x5.e(base.a8(), base.a2()));
			base.ac(base.a8());
			base.w(base.a3());
			this.a();
			return result;
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x000D9C4C File Offset: 0x000D8C4C
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
				if (base.c5().aa() && base.c5().b() != null)
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
						ms.a(this, mu.b());
						ms.a(A_0, A_1, A_2);
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x000DA0B4 File Offset: 0x000D90B4
		internal override kz dm()
		{
			mh mh = new mh();
			mh.j(this.dr());
			mh.dc(this.db().du());
			mh.a((lk)base.c5().du());
			mh.df(this.b);
			if (base.n() != null)
			{
				mh.c(base.n().p());
			}
			return mh;
		}

		// Token: 0x0400092C RID: 2348
		private new n5 a = new n5();

		// Token: 0x0400092D RID: 2349
		private new bool b = false;
	}
}
