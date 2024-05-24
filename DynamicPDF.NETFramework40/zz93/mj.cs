using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020001E5 RID: 485
	internal class mj : k0
	{
		// Token: 0x060014E4 RID: 5348 RVA: 0x000E9970 File Offset: 0x000E8970
		internal override lj db()
		{
			return this.a;
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x000E9988 File Offset: 0x000E8988
		internal override void dc(lj A_0)
		{
			this.a = (n5)A_0;
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x000E9998 File Offset: 0x000E8998
		internal override int dg()
		{
			return 445520207;
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x000E99B0 File Offset: 0x000E89B0
		internal override bool de()
		{
			return this.c;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x000E99C8 File Offset: 0x000E89C8
		internal override void df(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x000E99D4 File Offset: 0x000E89D4
		internal override k0 dd()
		{
			return new mj();
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x000E99EC File Offset: 0x000E89EC
		internal l2 a()
		{
			return this.b;
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x000E9A04 File Offset: 0x000E8A04
		internal void a(l2 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x000E9A10 File Offset: 0x000E8A10
		internal override x5 dh()
		{
			base.aj();
			return this.dp();
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x000E9A2F File Offset: 0x000E8A2F
		internal override void di()
		{
			base.ak();
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x000E9A3C File Offset: 0x000E8A3C
		internal override kz dj(x5 A_0, x5 A_1)
		{
			kz result;
			if (base.c5().v() != null && x5.c(x5.f(x5.f(base.c5().v().Value, base.c5().a2()), base.c5().a3()), A_1))
			{
				this.am(false);
				base.an(false);
				result = this;
			}
			else if (x5.c(base.c5().am().Value, A_0))
			{
				result = this;
			}
			else
			{
				kz kz = base.f(A_0, A_1);
				base.w(base.n().c().a().l().a().b().a1());
				base.x(base.n().c().a().l().a().b().a2());
				result = kz;
			}
			return result;
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x000E9B44 File Offset: 0x000E8B44
		internal override void dk(PageWriter A_0, x5 A_1, x5 A_2)
		{
			base.c5().c().e(base.r());
			base.c5().c().f(base.q());
			base.c5().c().g(base.s());
			base.c5().c().h(base.t());
			A_1 = x5.f(A_1, x5.f(base.cc(), this.dc()));
			if (this.c3())
			{
				A_1 = x5.f(A_1, base.an());
			}
			if (!base.q())
			{
				A_1 = x5.f(A_1, base.c5().e().d());
			}
			if (!base.s())
			{
				A_2 = x5.f(A_2, base.c5().e().a());
			}
			mu mu = base.n().c();
			ms ms = mu.a();
			if (base.ai())
			{
				x5 a_ = x5.e(ms.ah(), base.a1());
				A_2 = x5.f(x5.f(A_2, base.ca()), ms.ah());
				if (base.c5().v() == null)
				{
					A_2 = x5.e(x5.e(A_2, base.a1()), base.c5().f().a());
					if (base.c5().d() && base.c5().c().g() != ft.a)
					{
						A_2 = x5.e(A_2, base.c5().c().f());
					}
				}
				else
				{
					A_2 = x5.e(a_, x5.a(base.ar(), 2));
				}
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

		// Token: 0x060014F0 RID: 5360 RVA: 0x000E9D8C File Offset: 0x000E8D8C
		internal override kz dm()
		{
			mj mj = new mj();
			mj.j(this.dr());
			mj.dc(this.db().du());
			mj.a((lk)base.c5().du());
			mj.df(this.c);
			mj.a(this.b);
			if (base.n() != null)
			{
				mj.c(base.n().p());
			}
			return mj;
		}

		// Token: 0x040009DF RID: 2527
		private new n5 a = new n5();

		// Token: 0x040009E0 RID: 2528
		private new l2 b = null;

		// Token: 0x040009E1 RID: 2529
		private new bool c = false;
	}
}
